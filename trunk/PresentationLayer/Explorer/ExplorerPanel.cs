using System;
using System.Windows.Forms;
using Commons.CommonGui;


namespace PresentationLayer.Explorer
{
    public partial class ExplorerPanel : UserControl
    {
        private NodeExplorer _rootNode;

        public ExplorerPanel()
        {
            InitializeComponent();
            InitGui();
            InitEvent();
        }

        private void InitGui()
        {
            InitTreeView();
        }

        private void InitEvent()
        {
            //tree view
            fileTreeView.NodeMouseClick += FileTreeViewNodeMouseClick;

            //Context menu
            addToolStripMenuItem.Click += AddChildToolStripMenuItemClick;
            renameToolStripMenuItem.Click += RenameToolStripMenuItemClick;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItemClick;
        }

        private void InitTreeView()
        {
            _rootNode = new NodeExplorer("Catologue", contextMenuStrip1);
            fileTreeView.Nodes.Add(_rootNode);
        }

        public void LoadTreeView()
        {

        }

        #region Implement Event Here

        private void FileTreeViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void AddChildToolStripMenuItemClick(object sender, EventArgs e)
        {
            InputDialog dialog = new InputDialog("Create New Node", "Name:", "");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string nodeText = dialog.ResultText;
                if (!string.IsNullOrEmpty(nodeText.Trim()))
                {
                    NodeExplorer newNode = new NodeExplorer(nodeText, contextMenuStrip1);
                    fileTreeView.SelectedNode.Nodes.Add(newNode);
                }
            }
        }

        private void RenameToolStripMenuItemClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileTreeView.SelectedNode;
            InputDialog dialog = new InputDialog(string.Format("Rename Node: {0}", selectedNode.Text), "New Name:", "");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string nodeText = dialog.ResultText;
                if (!string.IsNullOrEmpty(nodeText.Trim()))
                {
                    if (!string.IsNullOrEmpty(nodeText.Trim()))
                    {
                        selectedNode.Text = nodeText;
                    }
                }
            }
        }

        private void DeleteToolStripMenuItemClick(System.Object sender, System.EventArgs e)
        {
            TreeNode selectedNode = fileTreeView.SelectedNode;
            if(selectedNode != _rootNode )
            {
                if (MessageBox.Show(this, "Do you realy want to delete!", 
                                    string.Format("Delete Node: {0}", selectedNode.Text), 
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    selectedNode.Remove();
                }
            }
            else
            {
                MessageBox.Show(this, "You can't delete root folder.",
                                string.Format("Can Not Delete Node: {0}", selectedNode.Text),
                                MessageBoxButtons.OK);
            }
        }


        #endregion
    }
}
