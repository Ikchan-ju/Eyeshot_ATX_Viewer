namespace ATXViewer
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            devDept.Eyeshot.CancelToolBarButton cancelToolBarButton1 = new devDept.Eyeshot.CancelToolBarButton("Cancel", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ProgressBar progressBar1 = new devDept.Eyeshot.ProgressBar(devDept.Eyeshot.ProgressBar.styleType.Circular, 0, "Idle", System.Drawing.Color.Black, System.Drawing.Color.Transparent, System.Drawing.Color.Green, 1D, true, cancelToolBarButton1, false, 0.1D, 0.333D, true);
            devDept.Graphics.BackgroundSettings backgroundSettings1 = new devDept.Graphics.BackgroundSettings(devDept.Graphics.backgroundStyleType.LinearGradient, System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(239))))), System.Drawing.Color.DodgerBlue, System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(235)))), ((int)(((byte)(211))))), 0.75D, null, devDept.Graphics.colorThemeType.Auto, 0.33D);
            devDept.Eyeshot.Camera camera1 = new devDept.Eyeshot.Camera(new devDept.Geometry.Point3D(0D, 0D, 45D), 380D, new devDept.Geometry.Quaternion(0.018434349666532526D, 0.039532590434972079D, 0.42221602280006187D, 0.90544518284475428D), devDept.Graphics.projectionType.Perspective, 40D, 6.5200013146826663D, false, 0.001D);
            devDept.Eyeshot.HomeToolBarButton homeToolBarButton1 = new devDept.Eyeshot.HomeToolBarButton("Home", devDept.Eyeshot.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.MagnifyingGlassToolBarButton magnifyingGlassToolBarButton1 = new devDept.Eyeshot.MagnifyingGlassToolBarButton("Magnifying Glass", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomWindowToolBarButton zoomWindowToolBarButton1 = new devDept.Eyeshot.ZoomWindowToolBarButton("Zoom Window", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomToolBarButton zoomToolBarButton1 = new devDept.Eyeshot.ZoomToolBarButton("Zoom", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.PanToolBarButton panToolBarButton1 = new devDept.Eyeshot.PanToolBarButton("Pan", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.RotateToolBarButton rotateToolBarButton1 = new devDept.Eyeshot.RotateToolBarButton("Rotate", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomFitToolBarButton zoomFitToolBarButton1 = new devDept.Eyeshot.ZoomFitToolBarButton("Zoom Fit", devDept.Eyeshot.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.ToolBar toolBar1 = new devDept.Eyeshot.ToolBar(devDept.Eyeshot.ToolBar.positionType.HorizontalTopCenter, true, new devDept.Eyeshot.ToolBarButton[] {
            ((devDept.Eyeshot.ToolBarButton)(homeToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(magnifyingGlassToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(zoomWindowToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(zoomToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(panToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(rotateToolBarButton1)),
            ((devDept.Eyeshot.ToolBarButton)(zoomFitToolBarButton1))});
            devDept.Eyeshot.Grid grid1 = new devDept.Eyeshot.Grid(new devDept.Geometry.Point3D(-100D, -100D, 0D), new devDept.Geometry.Point3D(100D, 100D, 0D), 10D, new devDept.Geometry.Plane(new devDept.Geometry.Point3D(0D, 0D, 0D), new devDept.Geometry.Vector3D(0D, 0D, 1D)), System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), false, true, false, false, 10, 100, 10, System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90))))), System.Drawing.Color.Transparent, false, System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))));
            devDept.Eyeshot.OriginSymbol originSymbol1 = new devDept.Eyeshot.OriginSymbol(10, devDept.Eyeshot.originSymbolStyleType.Ball, new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))), System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Blue, "Origin", "X", "Y", "Z", true, null, false);
            devDept.Eyeshot.RotateSettings rotateSettings1 = new devDept.Eyeshot.RotateSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.None), 10D, true, 1D, devDept.Eyeshot.rotationType.Trackball, devDept.Eyeshot.rotationCenterType.CursorLocation, new devDept.Geometry.Point3D(0D, 0D, 0D), false);
            devDept.Eyeshot.ZoomSettings zoomSettings1 = new devDept.Eyeshot.ZoomSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.Shift), 25, true, devDept.Eyeshot.zoomStyleType.AtCursorLocation, false, 1D, System.Drawing.Color.Empty, devDept.Eyeshot.Camera.perspectiveFitType.Accurate, false, 10, true);
            devDept.Eyeshot.PanSettings panSettings1 = new devDept.Eyeshot.PanSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.Ctrl), 25, true);
            devDept.Eyeshot.NavigationSettings navigationSettings1 = new devDept.Eyeshot.NavigationSettings(devDept.Eyeshot.Camera.navigationType.Examine, new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Left, devDept.Eyeshot.modifierKeys.None), new devDept.Geometry.Point3D(-1000D, -1000D, -1000D), new devDept.Geometry.Point3D(1000D, 1000D, 1000D), 8D, 50D, 50D);
            devDept.Eyeshot.CoordinateSystemIcon coordinateSystemIcon1 = new devDept.Eyeshot.CoordinateSystemIcon(new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))), System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80))))), System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80))))), System.Drawing.Color.OrangeRed, "Origin", "X", "Y", "Z", true, devDept.Eyeshot.coordinateSystemPositionType.BottomLeft, 37, null, false);
            devDept.Eyeshot.ViewCubeIcon viewCubeIcon1 = new devDept.Eyeshot.ViewCubeIcon(devDept.Eyeshot.coordinateSystemPositionType.TopRight, true, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(20)))), ((int)(((byte)(147))))), true, "FRONT", "BACK", "LEFT", "RIGHT", "TOP", "BOTTOM", System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), 'S', 'N', 'W', 'E', true, null, System.Drawing.Color.White, System.Drawing.Color.Black, 120, true, true, null, null, null, null, null, null, false, new devDept.Geometry.Quaternion(0D, 0D, 0D, 1D));
            devDept.Eyeshot.Viewport.SavedViewsManager savedViewsManager1 = new devDept.Eyeshot.Viewport.SavedViewsManager(8);
            devDept.Eyeshot.Viewport viewport1 = new devDept.Eyeshot.Viewport(new System.Drawing.Point(0, 0), new System.Drawing.Size(1139, 652), backgroundSettings1, camera1, new devDept.Eyeshot.ToolBar[] {
            toolBar1}, new devDept.Eyeshot.Legend[0], devDept.Eyeshot.displayType.Rendered, true, false, false, false, new devDept.Eyeshot.Grid[] {
            grid1}, new devDept.Eyeshot.OriginSymbol[] {
            originSymbol1}, false, rotateSettings1, zoomSettings1, panSettings1, navigationSettings1, coordinateSystemIcon1, viewCubeIcon1, savedViewsManager1, devDept.Eyeshot.viewType.Trimetric);
            this.model1 = new devDept.Eyeshot.Model();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dwgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.개별ATX로분리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hole제거ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentInfomationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wireframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.header로구분ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.partType으로구분ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basePanelTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bracketTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.girderTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.longiTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collarPlateTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transeTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topPanelTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bOMTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // model1
            // 
            this.model1.Cursor = System.Windows.Forms.Cursors.Default;
            this.model1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.model1.Location = new System.Drawing.Point(0, 0);
            this.model1.Margin = new System.Windows.Forms.Padding(4);
            this.model1.Name = "model1";
            this.model1.ProgressBar = progressBar1;
            this.model1.Size = new System.Drawing.Size(1139, 652);
            this.model1.TabIndex = 0;
            this.model1.Text = "model1";
            this.model1.Viewports.Add(viewport1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.controlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1491, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.개별ATX로분리ToolStripMenuItem,
            this.hole제거ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(297, 34);
            this.openToolStripMenuItem.Text = "ATX불러오기";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(297, 34);
            this.saveAsToolStripMenuItem.Text = "ATX다른이름으로 저장";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dwgToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(297, 34);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // dwgToolStripMenuItem
            // 
            this.dwgToolStripMenuItem.Name = "dwgToolStripMenuItem";
            this.dwgToolStripMenuItem.Size = new System.Drawing.Size(151, 34);
            this.dwgToolStripMenuItem.Text = "Dwg";
            this.dwgToolStripMenuItem.Click += new System.EventHandler(this.dwgToolStripMenuItem_Click);
            // 
            // 개별ATX로분리ToolStripMenuItem
            // 
            this.개별ATX로분리ToolStripMenuItem.Name = "개별ATX로분리ToolStripMenuItem";
            this.개별ATX로분리ToolStripMenuItem.Size = new System.Drawing.Size(297, 34);
            this.개별ATX로분리ToolStripMenuItem.Text = "개별 ATX로 분리";
            this.개별ATX로분리ToolStripMenuItem.Click += new System.EventHandler(this.개별ATX로분리ToolStripMenuItem_Click);
            // 
            // hole제거ToolStripMenuItem
            // 
            this.hole제거ToolStripMenuItem.Name = "hole제거ToolStripMenuItem";
            this.hole제거ToolStripMenuItem.Size = new System.Drawing.Size(297, 34);
            this.hole제거ToolStripMenuItem.Text = "Hole 제거";
            this.hole제거ToolStripMenuItem.Click += new System.EventHandler(this.hole제거ToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.segmentInfomationToolStripMenuItem,
            this.displayModeToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.header로구분ToolStripMenuItem,
            this.partType으로구분ToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(66, 29);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // segmentInfomationToolStripMenuItem
            // 
            this.segmentInfomationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onToolStripMenuItem,
            this.offToolStripMenuItem});
            this.segmentInfomationToolStripMenuItem.Name = "segmentInfomationToolStripMenuItem";
            this.segmentInfomationToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.segmentInfomationToolStripMenuItem.Text = "Segment Infomation";
            // 
            // onToolStripMenuItem
            // 
            this.onToolStripMenuItem.Name = "onToolStripMenuItem";
            this.onToolStripMenuItem.Size = new System.Drawing.Size(140, 34);
            this.onToolStripMenuItem.Text = "On";
            this.onToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuItem_Click);
            // 
            // offToolStripMenuItem
            // 
            this.offToolStripMenuItem.Name = "offToolStripMenuItem";
            this.offToolStripMenuItem.Size = new System.Drawing.Size(140, 34);
            this.offToolStripMenuItem.Text = "Off";
            this.offToolStripMenuItem.Click += new System.EventHandler(this.offToolStripMenuItem_Click);
            // 
            // displayModeToolStripMenuItem
            // 
            this.displayModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wireframeToolStripMenuItem,
            this.renderedToolStripMenuItem,
            this.hideToolStripMenuItem});
            this.displayModeToolStripMenuItem.Name = "displayModeToolStripMenuItem";
            this.displayModeToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.displayModeToolStripMenuItem.Text = "Display Mode";
            // 
            // wireframeToolStripMenuItem
            // 
            this.wireframeToolStripMenuItem.Name = "wireframeToolStripMenuItem";
            this.wireframeToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.wireframeToolStripMenuItem.Text = "Wireframe";
            this.wireframeToolStripMenuItem.Click += new System.EventHandler(this.wireframeToolStripMenuItem_Click);
            // 
            // renderedToolStripMenuItem
            // 
            this.renderedToolStripMenuItem.Name = "renderedToolStripMenuItem";
            this.renderedToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.renderedToolStripMenuItem.Text = "Rendered";
            this.renderedToolStripMenuItem.Click += new System.EventHandler(this.renderedToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.holeToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(174, 34);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // holeToolStripMenuItem
            // 
            this.holeToolStripMenuItem.Name = "holeToolStripMenuItem";
            this.holeToolStripMenuItem.Size = new System.Drawing.Size(174, 34);
            this.holeToolStripMenuItem.Text = "Hole";
            this.holeToolStripMenuItem.Click += new System.EventHandler(this.holeToolStripMenuItem_Click);
            // 
            // header로구분ToolStripMenuItem
            // 
            this.header로구분ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15,
            this.toolStripMenuItem16,
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19,
            this.toolStripMenuItem20});
            this.header로구분ToolStripMenuItem.Name = "header로구분ToolStripMenuItem";
            this.header로구분ToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.header로구분ToolStripMenuItem.Text = "Header로 구분";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.CheckOnClick = true;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem2.Text = "71702";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.CheckOnClick = true;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem3.Text = "71703";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.CheckOnClick = true;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem4.Text = "71704";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.CheckOnClick = true;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem5.Text = "71705";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.CheckOnClick = true;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem6.Text = "71706";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.CheckOnClick = true;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem7.Text = "71707";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.CheckOnClick = true;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem8.Text = "71708";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.CheckOnClick = true;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem9.Text = "71722";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.CheckOnClick = true;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem10.Text = "71724";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.CheckOnClick = true;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem11.Text = "71732";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.CheckOnClick = true;
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem12.Text = "71733";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.CheckOnClick = true;
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem13.Text = "71734";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.CheckOnClick = true;
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem14.Text = "71750";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.CheckOnClick = true;
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem15.Text = "71752";
            // 
            // partType으로구분ToolStripMenuItem
            // 
            this.partType으로구분ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basePanelTypeToolStripMenuItem,
            this.bracketTypeToolStripMenuItem,
            this.frameTypeToolStripMenuItem,
            this.girderTypeToolStripMenuItem,
            this.longiTypeToolStripMenuItem,
            this.collarPlateTypeToolStripMenuItem,
            this.transeTypeToolStripMenuItem,
            this.emptyTypeToolStripMenuItem,
            this.topPanelTypeToolStripMenuItem});
            this.partType으로구분ToolStripMenuItem.Name = "partType으로구분ToolStripMenuItem";
            this.partType으로구분ToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.partType으로구분ToolStripMenuItem.Text = "PartType으로 구분";
            // 
            // basePanelTypeToolStripMenuItem
            // 
            this.basePanelTypeToolStripMenuItem.CheckOnClick = true;
            this.basePanelTypeToolStripMenuItem.Name = "basePanelTypeToolStripMenuItem";
            this.basePanelTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.basePanelTypeToolStripMenuItem.Text = "BasePanelType";
            // 
            // bracketTypeToolStripMenuItem
            // 
            this.bracketTypeToolStripMenuItem.CheckOnClick = true;
            this.bracketTypeToolStripMenuItem.Name = "bracketTypeToolStripMenuItem";
            this.bracketTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.bracketTypeToolStripMenuItem.Text = "BracketType";
            // 
            // frameTypeToolStripMenuItem
            // 
            this.frameTypeToolStripMenuItem.CheckOnClick = true;
            this.frameTypeToolStripMenuItem.Name = "frameTypeToolStripMenuItem";
            this.frameTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.frameTypeToolStripMenuItem.Text = "FrameType";
            // 
            // girderTypeToolStripMenuItem
            // 
            this.girderTypeToolStripMenuItem.CheckOnClick = true;
            this.girderTypeToolStripMenuItem.Name = "girderTypeToolStripMenuItem";
            this.girderTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.girderTypeToolStripMenuItem.Text = "GirderType";
            // 
            // longiTypeToolStripMenuItem
            // 
            this.longiTypeToolStripMenuItem.CheckOnClick = true;
            this.longiTypeToolStripMenuItem.Name = "longiTypeToolStripMenuItem";
            this.longiTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.longiTypeToolStripMenuItem.Text = "LongiType";
            // 
            // collarPlateTypeToolStripMenuItem
            // 
            this.collarPlateTypeToolStripMenuItem.CheckOnClick = true;
            this.collarPlateTypeToolStripMenuItem.Name = "collarPlateTypeToolStripMenuItem";
            this.collarPlateTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.collarPlateTypeToolStripMenuItem.Text = "CollarPlateType";
            // 
            // transeTypeToolStripMenuItem
            // 
            this.transeTypeToolStripMenuItem.CheckOnClick = true;
            this.transeTypeToolStripMenuItem.Name = "transeTypeToolStripMenuItem";
            this.transeTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.transeTypeToolStripMenuItem.Text = "TransType";
            // 
            // emptyTypeToolStripMenuItem
            // 
            this.emptyTypeToolStripMenuItem.CheckOnClick = true;
            this.emptyTypeToolStripMenuItem.Name = "emptyTypeToolStripMenuItem";
            this.emptyTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.emptyTypeToolStripMenuItem.Text = "EmptyType";
            // 
            // topPanelTypeToolStripMenuItem
            // 
            this.topPanelTypeToolStripMenuItem.CheckOnClick = true;
            this.topPanelTypeToolStripMenuItem.Name = "topPanelTypeToolStripMenuItem";
            this.topPanelTypeToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.topPanelTypeToolStripMenuItem.Text = "TopPanelType";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.objectTreeToolStripMenuItem,
            this.bOMTreeToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(87, 29);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // objectTreeToolStripMenuItem
            // 
            this.objectTreeToolStripMenuItem.Name = "objectTreeToolStripMenuItem";
            this.objectTreeToolStripMenuItem.Size = new System.Drawing.Size(210, 34);
            this.objectTreeToolStripMenuItem.Text = "Object Tree";
            this.objectTreeToolStripMenuItem.Click += new System.EventHandler(this.objectTreeToolStripMenuItem_Click);
            // 
            // bOMTreeToolStripMenuItem
            // 
            this.bOMTreeToolStripMenuItem.Name = "bOMTreeToolStripMenuItem";
            this.bOMTreeToolStripMenuItem.Size = new System.Drawing.Size(210, 34);
            this.bOMTreeToolStripMenuItem.Text = "BOM Tree";
            this.bOMTreeToolStripMenuItem.Click += new System.EventHandler(this.bOMTreeToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 33);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1491, 911);
            this.splitContainer1.SplitterDistance = 346;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(346, 911);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.model1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer2.Size = new System.Drawing.Size(1139, 911);
            this.splitContainer2.SplitterDistance = 652;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1139, 253);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.CheckOnClick = true;
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem16.Text = "1701";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.CheckOnClick = true;
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem17.Text = "1731";
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.CheckOnClick = true;
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem18.Text = "1733";
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.CheckOnClick = true;
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem19.Text = "1735";
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.CheckOnClick = true;
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem20.Text = "1741";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 944);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ATXViewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.model1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private devDept.Eyeshot.Model model1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dwgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentInfomationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wireframeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem holeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 개별ATX로분리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hole제거ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem header로구분ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem bOMTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partType으로구분ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basePanelTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bracketTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frameTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem girderTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem longiTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collarPlateTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transeTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emptyTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topPanelTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
    }
}

