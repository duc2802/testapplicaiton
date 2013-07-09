using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using Commons;
using PresentationLayer.Explorer.Data;
using SingleInstanceObject;
using TestApplication;
using ThreadQueueManager;

namespace PresentationLayer.ThreadManager.DataThread
{
    public class RenameNodeExplorerCmd : ICommand
    {
        private readonly string _name;
        private readonly ExecuteMethod synch_ = ExecuteMethod.Async;

        private Folder _folder;
        private string _newName;

        public RenameNodeExplorerCmd(ExecuteMethod synch, Folder folder, string newName)
        {
            synch_ = synch;
            _name = "RenameNodeExplorerCmd";
            _folder = folder;
            _newName = newName;
        }

        #region ICommand Members

        public string GetName()
        {
            return _name;
        }

        public ExecuteMethod IsSeparate()
        {
            return synch_;
        }

        public int Priority
        {
            get { return 0; }
        }

        public void Execute()
        {
            try
            {
                //Clear on dics.
                string pathFolder = Singleton<SettingManager>.Instance.GetDataFolder() + "\\" + _folder.FolderName;
                string newPathFolder = Singleton<SettingManager>.Instance.GetDataFolder() + "\\" + _newName;
                RemaneFolder(pathFolder, newPathFolder);
                var listTestBE = (from test in Singleton<List<TestBE>>.Instance
                                  where test.FolderId.Equals(_folder.FolderName)
                                  select test);
                foreach (var test in listTestBE)
                {
                    test.FolderId = _newName;
                    var businessObject = new TestBLL();
                    if (!businessObject.ExportTestExamFile(test, test.TestID, test.FolderId))
                    {
                        MessageBox.Show(string.Format("Can't save {0}", test.TestID), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void RemaneFolder(string oldName, string newName)
        {
            var oldDir = new DirectoryInfo(oldName);
            oldDir.MoveTo(newName);
        }

        #endregion
    }
}
