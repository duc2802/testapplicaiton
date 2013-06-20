﻿using System;
using System.IO;
using System.Windows.Forms;
using Commons.CommonGui;
using PresentationLayer.ActionController;
using PresentationLayer.Setting;
using SingleInstanceObject;

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
            fileTreeView.NodeMouseClick += FileTreeViewNodeMouseClick;
            addToolStripMenuItem.Click += AddChildToolStripMenuItemClick;
            renameToolStripMenuItem.Click += RenameToolStripMenuItemClick;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItemClick;
            Singleton<GuiActionEventController>.Instance.ChangeFolderId += ChangeForderId;
        }

        private void ChangeForderId(object sender, string parameter)
        {
            _rootNode = new NodeExplorer(parameter, contextMenuStrip1);
            _rootNode.ExpandAll();
            fileTreeView.Nodes.Add(_rootNode);
            //LoadTreeView();
        }


        private void InitTreeView()
        {
            _rootNode = new NodeExplorer("Data", contextMenuStrip1);
            _rootNode.ExpandAll();
            fileTreeView.Nodes.Add(_rootNode);
            LoadTreeView();
        }

        public void LoadTreeView()
        {
            string dataFolder = Singleton<SettingManager>.Instance.GetDataFolder();
            var dataDirectory = new DirectoryInfo(dataFolder);
            foreach (DirectoryInfo di in dataDirectory.GetDirectories())
            {
                var newNode = new NodeExplorer(di.Name, contextMenuStrip1);
                _rootNode.Nodes.Add(newNode);
            }
        }

        private void CreateDirectory(string folderName)
        {
            string folderDirectory = Singleton<SettingManager>.Instance.GetDataFolder() + "\\" + folderName;
            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }
        }

        private void RemoveDirectoty(string folderName)
        {
            string folderDirectory = Singleton<SettingManager>.Instance.GetDataFolder() + "\\" + folderName;
            if (!Directory.Exists(folderDirectory))
            {
                Directory.Delete(folderDirectory, true);
            }
        }

        #region Implement Event Here

        private void FileTreeViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Singleton<GuiActionEventController>.Instance.FolderId = fileTreeView.SelectedNode.Text;
                Singleton<GuiActionEventController>.Instance.OnClearAllQuestionItem();
            }
        }

        private void AddChildToolStripMenuItemClick(object sender, EventArgs e)
        {
            var dialog = new InputDialog("Create New Node", "Name:", "");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string nodeText = dialog.ResultText;
                if (!string.IsNullOrEmpty(nodeText.Trim()))
                {
                    var newNode = new NodeExplorer(nodeText, contextMenuStrip1);
                    _rootNode.Nodes.Add(newNode);
                    CreateDirectory(nodeText);
                }
            }
        }

        private void RenameToolStripMenuItemClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileTreeView.SelectedNode;
            var dialog = new InputDialog(string.Format("Rename Node: {0}", selectedNode.Text), "New Name:", "");
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

        private void DeleteToolStripMenuItemClick(Object sender, EventArgs e)
        {
            TreeNode selectedNode = fileTreeView.SelectedNode;
            if (selectedNode != _rootNode)
            {
                if (MessageBox.Show(this, "Do you realy want to delete!",
                                    string.Format("Delete Node: {0}", selectedNode.Text),
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RemoveDirectoty(selectedNode.Text);
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