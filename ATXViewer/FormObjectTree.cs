using ATXLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATXViewer
{
    public partial class FormObjectTree : Form
    {
        public FormObjectTree()
        {
            InitializeComponent();
        }
        public FormObjectTree(string fileName) // csv 파일 읽어와서 트리에 띄우기
        {
            InitializeComponent();
            CSVLoader csvLoader = new CSVLoader(fileName);
            Regen(csvLoader);
        }

        private void FormObjectTree_Load(object sender, EventArgs e)
        {

        }
        public void Regen(CSVLoader csvLoader)
        {
            treeView1.Nodes.Clear();

            // root
            TreeNode root = treeView1.Nodes.Add("BOM Data");
            List<BOM> bomData = csvLoader.bomData;

            int level = 0;
            int count = 0;
            List<List<BOM>> nodeList = new List<List<BOM>>();
            do //level_no 기준으로 분류
            {
                count = 0;
                nodeList.Add(new List<BOM>());
                //nodeList[level] = new List<TreeNode>();
                foreach (var bom in bomData)
                {
                    if(bom.LEVEL_NO == level)
                    {
                        nodeList[level].Add(bom);
                        count++;
                    }
                }
                level++;
            } while (count != 0);

            int totalLevel = nodeList.Count - 1;
            for(int i = 1; i < totalLevel; i++)//상위 레벨부터 하위레벨 순으로 진행. 
            {
                foreach(BOM node in nodeList[i])
                {
                    bool isFound = false;
                    foreach(BOM upperNode in nodeList[i - 1])
                    {
                        if (upperNode.ASSY.Equals(node.NEXT_ASSY) && upperNode.BLK.Equals(node.BLK))//next_assy와 assy 비교 && 상위 노드와 하위노드가 동일한 BLK인지 비교후 add
                        {
                            upperNode.treeNode.Nodes.Add(node.treeNode);
                            isFound = true;
                        }
                        else if (node.NEXT_ASSY.Equals("BLOCK") && upperNode.BLK.Equals(node.BLK))//레벨1일때는 next_assy가 BLOCK로 되어있음. && 상위 노드와 하위노드가 동일한 BLK인지 비교후 add
                        {
                            upperNode.treeNode.Nodes.Add(node.treeNode);
                            isFound = true;
                        }
                    }
                    if (isFound)
                        continue;
                }
            }
            foreach(BOM node in nodeList[0])
            {
                root.Nodes.Add(node.treeNode);
            }
            root.ExpandAll();

        }
        public void Regen(List<Loader> loaders)
        {
            treeView1.Nodes.Clear();

            // root
            TreeNode root = treeView1.Nodes.Add("ATX Model");

            foreach(var loader in loaders)
            {
                var loaderNode = root.Nodes.Add(System.IO.Path.GetFileName(loader.fileName));
                // groups
                foreach (ATXObject obj in loader.objects)
                {
                    TreeNode objNode = loaderNode.Nodes.Add(obj.name);
                    objNode.Tag = obj;
                    foreach (ATXGroup g in obj.groups)
                    {
                        TreeNode groupNode = objNode.Nodes.Add(g.IsHole() ? "(Hole)" : g.tri_name);
                        groupNode.Tag = g;
                    }
                }
            }
            root.ExpandAll();
            
        }
    }
}
