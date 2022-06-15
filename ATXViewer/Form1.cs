using ATXLoader;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ATXViewer
{
    public partial class Form1 : Form
    {
        private bool segmentInfo = false;
        FormObjectTree formTree;
        FormObjectTree formTree_forCSV;

        // 지금까지 불러온 파일
        List<Loader> loaders = new List<Loader>();
        List<Entity> selectedEntities = new List<Entity>();
        List<string> selected_tri_names = new List<string>();


        public Form1()
        {
            InitializeComponent();
            model1.Unlock("US21-JAP7X-12AD0-8EDC-RYR7");
            model1.AntiAliasing = true;
            model1.AntiAliasingSamples = devDept.Graphics.antialiasingSamplesNumberType.x4;
            model1.AskForAntiAliasing = true;

            model1.Rendered.ShowEdges = false;
            model1.Rendered.ShadowMode = devDept.Graphics.shadowType.None;
        
            MakeDefaultLayers();
        }

        // 기본 레이어를 만든다.
        // Hole은 보이지 않게..
        private void MakeDefaultLayers()
        {
            Layer holeLayer = new Layer("Hole")
            {
                Visible = false
            };
            model1.Layers.Add(holeLayer);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            model1.WorkCompleted += Model1_WorkCompleted;
            model1.WorkCancelled += Model1_WorkCancelled;
            model1.WorkFailed += Model1_WorkFailed;

            model1.SelectionChanged += Model1_SelectionChanged;
            model1.MouseDown += Model1_MouseDown;
            model1.ActionMode = actionType.SelectVisibleByPick;

            model1.KeyDown += Model1_KeyDown;

            foreach(ToolStripMenuItem tsm in header로구분ToolStripMenuItem.DropDownItems)
            {
                tsm.CheckedChanged += Tsm_CheckedChanged;
            }
            foreach (ToolStripMenuItem partMenu in partType으로구분ToolStripMenuItem.DropDownItems)
            {
                partMenu.CheckedChanged += PartMenu_CheckedChanged;
            }
        }

        private void PartMenu_CheckedChanged(object sender, EventArgs e)
        {
            int checkedCount = 0;
            foreach (ToolStripMenuItem tsm in partType으로구분ToolStripMenuItem.DropDownItems)
            {
                if (tsm == null)
                    continue;
                if (tsm.Checked)
                    checkedCount++;
            }

            if (checkedCount == 0)
            {
                BasePanelType.visible = true;
                BracketType.visible = true;
                CollarPlateType.visible = true;
                EmptyType.visible = true;
                FrameType.visible = true;
                GirderType.visible = true;
                LongiType.visible = true;
                TransType.visible = true;
                TopPanelType.visible = true;
            }
            else
            {
                BasePanelType.visible = false;
                BracketType.visible = false;
                CollarPlateType.visible = false;
                EmptyType.visible = false;
                FrameType.visible = false;
                GirderType.visible = false;
                LongiType.visible = false;
                TransType.visible = false;
                TopPanelType.visible = false;
                foreach (ToolStripMenuItem tsm in partType으로구분ToolStripMenuItem.DropDownItems)
                {
                    if (tsm == null)
                        continue;
                    switch (tsm.Text)
                    {
                        case "BasePanelType":
                            BasePanelType.visible = tsm.Checked;
                            break;
                        case "BracketType":
                            BracketType.visible = tsm.Checked;
                            break;
                        case "CollarPlateType":
                            CollarPlateType.visible = tsm.Checked;
                            break;
                        case "EmptyType":
                            EmptyType.visible = tsm.Checked;
                            break;
                        case "FrameType":
                            FrameType.visible = tsm.Checked;
                            break;
                        case "GirderType":
                            GirderType.visible = tsm.Checked;
                            break;
                        case "LongiType":
                            LongiType.visible = tsm.Checked;
                            break;
                        case "TransType":
                            TransType.visible = tsm.Checked;
                            break;
                        case "TopPanelType":
                            TopPanelType.visible = tsm.Checked;
                            break;
                    }

                }
            }

            foreach (var ent in model1.Entities)
            {
                if (ent == null)
                    continue;
                var entityData = ent.EntityData as ATXGroup;
                if (entityData == null)
                    continue;

                if (entityData.part == null)
                    continue;

                entityData.part.partType.setVisibility();
                ent.Visible = entityData.part.partType.isVisible;

            }

            model1.Entities.Regen();
            model1.Invalidate();
        }

        private void Tsm_CheckedChanged(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////////////
            //check 된 항목 개수 확인. 0개면 전체 보이기. 1개이상이면 선택된것만 보이기
            int checkedCount = 0; 
            foreach (ToolStripMenuItem tsm in header로구분ToolStripMenuItem.DropDownItems)
            {
                if (tsm == null)
                    continue;
                if (tsm.Checked)
                    checkedCount++;
            }

            foreach (var ent in model1.Entities)
            {
                if (ent == null)
                    continue;
                var entityData = ent.EntityData as ATXGroup;
                if (entityData == null)
                    continue;

                if (checkedCount == 0)
                    ent.Visible = true;
                else if (checkedCount == 1)
                    ent.Visible = false;
            }
            ////////////////////////////////////////////////////////////////////////////////
            
            foreach (ToolStripMenuItem tsm in header로구분ToolStripMenuItem.DropDownItems)
            {
                if (tsm == null)
                    continue;
                if (tsm.Checked)
                {
                    RecordTypeManager.RecordType rt = RecordTypeManager.recordTypes[(tsm.Text).ToInt()];

                    if (RecordTypeManager.IsStartOfObject(rt)) // header가 object 시작이라면
                    {
                        foreach(var loader in loaders)
                        {
                            foreach(var obj in loader.objects)
                            {
                                if (obj == null)
                                    continue;
                                if (obj.start_record_type != rt) // 선택된 header에 대응하는 object만 통과
                                    continue;

                                foreach (var group in obj.groups) // 통과된 각 object의 소속 group들 디스플레이
                                {
                                    foreach(var ent in model1.Entities)
                                    {
                                        if (ent == null)
                                            continue;
                                        var entityData = ent.EntityData as ATXGroup;
                                        if (entityData == null)
                                            continue;

                                        if (entityData.Equals(group))
                                            ent.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                    else if (RecordTypeManager.IsStartOfGroup(rt)) // header가 group 시작이라면
                    {
                        foreach (var ent in model1.Entities)
                        {
                            if (ent == null)
                                continue;
                            var entityData = ent.EntityData as ATXGroup;
                            if (entityData == null)
                                continue;

                            if (entityData.start_record_type == rt) // 전체 entities 중 선택된 header에 대응하는 entity만 디스플레이
                            {
                                //ent.Selected = true;
                                ent.Visible = true;
                            }
                        }
                    }
                        
                }
            }
            model1.Entities.Regen();
            model1.Invalidate();
        }

        private void Model1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Delete))
            {
                foreach(string tri_name in selected_tri_names) // 선택된 entity들의 tri_name을 조회
                {
                    foreach (Loader loader in loaders)
                    {
                        List<ATXObject> obj_buffer = new List<ATXObject>();
                        foreach (ATXObject obj in loader.objects)
                        {
                            List<ATXGroup> group_buffer = new List<ATXGroup>();
                            foreach (ATXGroup group in obj.groups)
                            {
                                if (group.tri_name == null) // 구조상 tri_name이 없는 그룹들이 있음. 이에 대한 예외처리 필요
                                {
                                    if (group.start_record_type == RecordTypeManager.RecordType.start_of_hole)
                                        continue;
                                    else
                                        throw new NotImplementedException(); // hole 외의 그룹들에 대한 예외처리 그때그때 작성
                                }

                                if (group.tri_name.Equals(tri_name)) // tri_name 이 동일한 그룹 확인되면 삭제할 그룹 버퍼에 추가
                                {
                                    group_buffer.Add(group);
                                    continue;
                                }
                            }
                            foreach(var group in group_buffer) // 버퍼에 추가된 그룹들 삭제
                            {
                                obj.groups.Remove(group);
                            }
                            int holeCount = 0;
                            foreach(var group in obj.groups) // object내 hole 개수 확인
                            {
                                if (group.start_record_type == RecordTypeManager.RecordType.start_of_hole)
                                    holeCount++;
                            }
                            if (holeCount == obj.groups.Count) // hole 개수와 그룹 개수 비교. 둘이 같다면 hole 만 있다는 것이고 그경우 모든 그룹 삭제
                                obj.groups.Clear();

                            if (obj.groups.Count == 0) // 그룹 개수가 0 이라면 삭제할 object 버퍼에 추가
                                obj_buffer.Add(obj);
                        }
                        foreach(var obj in obj_buffer) // 버퍼에 추가된 object 들 삭제
                        {
                            loader.objects.Remove(obj);
                        }
                    }
                }

                List<Loader> loader_buffer = new List<Loader>(); // object가 없는 loader 삭제
                foreach(Loader loader in loaders)
                {
                    if (loader.objects.Count == 0)
                        loader_buffer.Add(loader);
                }
                foreach(Loader loader in loader_buffer)
                {
                    loaders.Remove(loader);
                }

                selected_tri_names.Clear(); // 선택된 tri_name 비우기
            }
                
            
        }


        private void Model1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void UpdatePropertiesGrid(object obj)
        {
            Entity ent = obj as Entity;
            if (ent != null)
            {
                obj = ent.EntityData;
            }

            ATXGroup group = obj as ATXGroup;
            if (group != null)
            {
                richTextBox1.Lines = group.codes.ToArray();
                return;
            }

            ATXObject atxObj = obj as ATXObject;
            if(atxObj != null)
            {
                richTextBox1.Lines = atxObj.GetAllCodes().ToArray();
                return;
            }

        }

        private void Model1_SelectionChanged(object sender, devDept.Eyeshot.Environment.SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count > 0)
            {
                var ent = e.AddedItems[0].Item as Entity;
                UpdatePropertiesGrid(ent);

                if (sender != dataGridView1)
                {
                    BindingSource bs = dataGridView1.DataSource as BindingSource;
                    if (bs != null)
                    {
                        List<ATXGroupListGridBindingData> bds = bs.DataSource as List<ATXGroupListGridBindingData>;
                        if (bds != null)
                        {
                            var idx = bds.FindIndex(x => x.GetGroup().entity == ent);
                            if(idx > -1)
                            {
                                dataGridView1.FirstDisplayedScrollingRowIndex = idx;
                                dataGridView1.ClearSelection();
                                dataGridView1.Rows[idx].Selected = true;
                            }
                                
                        }

                    }

                }
            }
            else
            {
                UpdatePropertiesGrid(null);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // 주익찬. tri_name 동일한 파트 동시 선택, 동시 해제, 동시 삭제를 위한 기능
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            foreach (var si in e.AddedItems)
            {
                var ent = si.Item as Entity;
                if (ent == null)
                    continue;
                var entityData = ent.EntityData as ATXGroup;
                if (entityData == null)
                    continue;

                selectedEntities.Add(ent);
                string tri_name = entityData.tri_name;
                selected_tri_names.Add(tri_name);
                foreach (var ent_forSearch in model1.Entities) // 모든 entity 중 tri_name 이 동일한 entity 조회 및 선택
                {
                    var entityData_forSearch = ent_forSearch.EntityData as ATXGroup;
                    if (entityData_forSearch == null)
                        continue;
                    if (entityData_forSearch.tri_name == null)
                        continue;
                    if (entityData_forSearch.tri_name.Equals(tri_name))
                    {
                        ent_forSearch.Selected = true;
                        selectedEntities.Add(ent);
                    }
                }
            }

            foreach (var ri in e.RemovedItems) // 선택해제 된 entity와 관련된 전역변수들 함께 해제
            {
                var ent = ri.Item as Entity;
                if (ent == null)
                    continue;
                var entityData = ent.EntityData as ATXGroup;
                if (entityData == null)
                    continue;
                selectedEntities.Remove(ent);
                selected_tri_names.Remove(entityData.tri_name);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void Model1_WorkFailed(object sender, WorkFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Model1_WorkCancelled(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Model1_WorkCompleted(object sender, WorkCompletedEventArgs e)
        {
            if (e.WorkUnit is WriteFileAsync)
            {
                MessageBox.Show("exported!");
            }
            else if (e.WorkUnit is ATXLoader.Loader)
            {
                Loader loader = e.WorkUnit as ATXLoader.Loader;
                if (loader != null)
                {
                    

                    loader.AddToModel(model1);
                    model1.Entities.Regen();
                    model1.Invalidate();

                    if (segmentInfo)
                    {
                        loader.ShowSegmentInfo(model1);
                    }

                    model1.ZoomFit();
                    MessageBox.Show($"{loader.fileName} loaded!");

                    // loaders에 추가
                    loaders.Add(loader);

                    // regen tree
                    if (formTree != null)
                        formTree.Regen(loaders);

                    // regen grid
                    RegenGrid();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "ATX files|*.atx"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ATXLoader.Loader loader = new ATXLoader.Loader(dlg.FileName);
                model1.StartWork(loader);
            }
        }

        // dwg export
        private void dwgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "dwg|*.dwg|obj|*.obj|dxf|*.dxf|stl|*.stl|html|*.html"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                WriteFileAsync wf = GetWriteFileAsync(model1, dlg.FileName);
                if (wf == null)
                {
                    return;
                }

                try
                {
                    model1.StartWork(wf);
                }
                catch
                {

                }

            }
        }

        // 파일이름을 받아서 WriteFileAsync를 리턴한다.
        public static WriteFileAsync GetWriteFileAsync(Model vp, string filename, WriteParamsWithTextStyles writeParam = null, bool ascii = false)
        {
            string ext = System.IO.Path.GetExtension(filename);
            ext = ext.ToUpper();


            if (writeParam == null)
            {
                writeParam = new WriteParamsWithTextStyles(vp.Entities, vp.Layers, vp.Blocks, vp.Materials, vp.TextStyles, vp.LineTypes, vp.Units); ;
            }


            WriteFileAsync wf = null;
            if (ext == ".IGES" || ext == ".IGS")
            {
                wf = new WriteIGES(writeParam, filename);
            }
            else if (ext == ".STL")
            {
                wf = new WriteSTL(writeParam, filename, ascii);
            }
            else if (ext == ".STEP" || ext == ".STP")
            {
                wf = new WriteSTEP(writeParam, filename);
            }
            else if (ext == ".OBJ")
            {
                wf = new WriteOBJ(writeParam, filename);
            }
            else if (ext == ".DWG" || ext == ".DXF")
            {
                WriteAutodeskParams aWriteParam = null;
                if (writeParam != null)
                {
                    aWriteParam = new WriteAutodeskParams(writeParam.Entities);
                }
                wf = new WriteAutodesk(aWriteParam, filename);
            }
            else if (ext == ".HTML")
            {
                WriteParamsWithMaterials writeParamTmp = new WriteParamsWithMaterials(vp);

                wf = new WriteWebGL(writeParamTmp, null, filename);
            }
            else if (ext == ".XML")
            {
                wf = new WriteXML(writeParam, filename);
            }
            else if (ext == ".PRC")
            {
                WritePrcParams prcParam = new WritePrcParams(vp);
                wf = new WritePRC(prcParam, filename);
            }
            else
            {
                System.Diagnostics.Debug.Assert(false);
            }


            return wf;
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            segmentInfo = true;
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            segmentInfo = false;
        }

        private void wireframeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model1.ActiveViewport.DisplayMode = displayType.Wireframe;
            model1.Invalidate();
        }

        private void renderedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model1.ActiveViewport.DisplayMode = displayType.Rendered;
            model1.Invalidate();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model1.ShowNormals = true;
            model1.Invalidate();
        }

        // 선택후
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            model1.Entities.ClearSelection();

            ATXObject obj = e.Node.Tag as ATXObject;
            if (obj != null)
            {
                foreach (ATXGroup group in obj.groups)
                {
                    if (group.entity == null)
                    {
                        continue;
                    }

                    group.entity.Selected = true;
                }
                UpdatePropertiesGrid(obj);

                model1.Invalidate();
                return;
            }



            ATXGroup g = e.Node.Tag as ATXGroup;
            if (g != null)
            {
                if (g.entity != null)
                {
                    g.entity.Selected = true;
                }

                UpdatePropertiesGrid(g);

                model1.Invalidate();
                return;
            }




        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model1.ActiveViewport.DisplayMode = displayType.HiddenLines;
        }

        private void holeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model1.Layers["Hole"].Visible = !model1.Layers["Hole"].Visible;
            model1.Invalidate();
        }

        private void objectTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formTree == null)
                formTree = new FormObjectTree();
            
            formTree.Regen(loaders);
            formTree.Show();
        }


        // group 단위로 grid 구성
        void RegenGridByGroup()
        {
            dataGridView1.Enabled = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            BindingSource bs = new BindingSource();
            
            List<ATXGroupListGridBindingData> bds = new List<ATXGroupListGridBindingData>();
            foreach (var loader in loaders)
            {
                foreach (var obj in loader.objects)
                {
                    foreach (var g in obj.groups)
                    {
                        if (g.IsHole())
                            continue;

                        bds.Add(new ATXGroupListGridBindingData(g));
                    }
                }
            }

            bs.DataSource = bds;
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns();

            dataGridView1.Enabled = true;


            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged1;

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DataGridView1_CellValueChanged1(object sender, DataGridViewCellEventArgs e)
        {
            BindingSource bs = dataGridView1.DataSource as BindingSource;
            if (bs == null)
                return;

            ATXGroupListGridBindingData bd = bs.Current as ATXGroupListGridBindingData;
            if (bd == null)
                return;
            var group = bd.GetGroup();
            if (group == null)
                return;

            group.entity.Visible = bd.Visible;
            model1.Invalidate();
        }

        // grid를 regen한다.
        void RegenGrid()
        {
            RegenGridByGroup();
        }

        // 다른이름으로 저장. 주익찬 수정
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                Filter = "ATX files|*.atx"
            };

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                List<string> outputStringList = new List<string>();

                MakeNewATXFile_asStringList(loaders, out outputStringList); // 각 loader들이 보관하고있는 object & group의 정보들을 하나의 List<string>으로 반환

                SaveAsNewFile(outputStringList, dlg.FileName); // 앞서 합쳐진 List<string>을 atx 파일로 저장
            }
        }

        // 읽어드린 ATX 파일을 Object 단위로 분할해서 저장
        private static void SaveAsSeperatedFile(List<Loader> loaders, string outputFilePath)
        {
            List<string>  stringBuffer = new List<string>();
            foreach (Loader loader in loaders)
            {
                foreach (ATXObject obj in loader.objects)
                {
                    foreach (string str in obj.codes)
                    {
                        if (str.Equals("99"))
                        {
                            foreach (ATXGroup group in obj.groups)
                            {
                                foreach (string str2 in group.codes)
                                {
                                    stringBuffer.Add(str2);
                                }
                            }
                        }
                        stringBuffer.Add(str);
                    }

                    using (StreamWriter outputStream = new StreamWriter(outputFilePath.Insert(outputFilePath.Length - 4, "_" + obj.name)))//(var outputStream = File.Create(outputFilePath))
                    {
                        foreach (string line in stringBuffer)
                        {
                            outputStream.WriteLine(line);
                        }
                        stringBuffer.Clear();
                    }
                }
            }
        }

        private static void MakeNewATXFile_asStringList(List<Loader> loaders, out List<string> outputStringList)
        {
            outputStringList = new List<string>();
            foreach(Loader loader in loaders)
            {
                foreach (ATXObject obj in loader.objects)
                {
                    foreach (string str in obj.codes)
                    {
                        if (str.Equals("99"))
                        {
                            foreach (ATXGroup group in obj.groups)
                            {
                                foreach (string str2 in group.codes)
                                {
                                    outputStringList.Add(str2);
                                }
                            }
                        }
                        outputStringList.Add(str);
                    }
                }
            }
        }
        private static void SaveAsNewFile(List<string> stringBuffer, string outputFilePath)
        {
            using (StreamWriter outputStream = new StreamWriter(outputFilePath))
            {
                foreach (string line in stringBuffer)
                {
                    outputStream.WriteLine(line);
                }
            }
        }

        private static void CombineMultipleFilesIntoSingleFile(string[] inputFilePaths, string outputFilePath)
        {
            Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);
            using (var outputStream = File.Create(outputFilePath))
            {
                foreach (var inputFilePath in inputFilePaths)
                {
                    using (var inputStream = File.OpenRead(inputFilePath))
                    {
                        // Buffer size can be passed as the second argument.
                        inputStream.CopyTo(outputStream);
                    }
                    Console.WriteLine("The file {0} has been processed.", inputFilePath);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            BindingSource bs = dataGridView1.DataSource as BindingSource;
            if (bs == null)
                return;

            ATXGroupListGridBindingData bd = bs.Current as ATXGroupListGridBindingData;
            if (bd == null)
                return;

            var group = bd.GetGroup();
            if (group == null)
                return;

            model1.Entities.ClearSelection();
            group.entity.Selected = true;
            model1.Invalidate();
            
            
        }

        private void 개별ATX로분리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                Filter = "ATX files|*.atx"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveAsSeperatedFile(loaders, dlg.FileName);
            }
        }

        // 현재 읽어온 ATX 파일들의 모든 Hole을 제거. 에러 방지 용도로 작성되었고, 나중에 불필요.
        private void hole제거ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Loader loader in loaders)
            {
                List<ATXObject> obj_buffer = new List<ATXObject>();
                foreach (ATXObject obj in loader.objects)
                {
                    List<ATXGroup> group_buffer = new List<ATXGroup>();
                    foreach (ATXGroup group in obj.groups)
                    {
                        if (group.tri_name == null)
                        {
                            if (group.start_record_type == RecordTypeManager.RecordType.start_of_hole)
                                continue;
                            else
                                throw new NotImplementedException();
                        }

                    }
                    foreach (var group in obj.groups)
                    {
                        if (group.start_record_type == RecordTypeManager.RecordType.start_of_hole)
                        {
                            group_buffer.Add(group);
                            continue;
                        }
                    }
                    foreach (var group in group_buffer)
                    {
                        obj.groups.Remove(group);
                    }

                    if (obj.groups.Count == 0)
                        obj_buffer.Add(obj);
                }
                foreach (var obj in obj_buffer)
                {
                    loader.objects.Remove(obj);
                }
            }
            List<Loader> loader_buffer = new List<Loader>();
            foreach (Loader loader in loaders)
            {
                if (loader.objects.Count == 0)
                    loader_buffer.Add(loader);
            }
            foreach (Loader loader in loader_buffer)
            {
                loaders.Remove(loader);
            }
        }

        // BOM 정보를 기반으로 트리 작성
        private void bOMTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "CSV files|*.csv"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (formTree_forCSV == null)
                    formTree_forCSV = new FormObjectTree(dlg.FileName);

                formTree_forCSV.Show();
            }
        }
    }

}
