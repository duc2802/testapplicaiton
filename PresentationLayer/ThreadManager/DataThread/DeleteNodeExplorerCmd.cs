using System;
using System.Collections.Generic;
using System.IO;
using BusinessEntities;
using Commons;
using SingleInstanceObject;
using ThreadQueueManager;
using System.Linq;

namespace PresentationLayer.ThreadManager.DataThread
{
    public class DeleteNodeExplorerCmd : ICommand
    {
        private readonly string _name;
        private readonly ExecuteMethod synch_ = ExecuteMethod.Async;

        private Folder _folder;

        public DeleteNodeExplorerCmd(ExecuteMethod synch, Folder folder)
        {
            synch_ = synch;
            _name = "DeleteTestCmd";
            _folder = folder;
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
                ClearFolder(pathFolder);

                //Clear on mem.
                var testList = (from test in Singleton<List<TestBE>>.Instance
                                where test.FolderId.Equals(_folder.FolderName)
                                select test);
                testList.ToList().ForEach(f => Singleton<List<TestBE>>.Instance.Remove(f));

            }
            catch (Exception ex)
            {
                //LogManager.Log(event_type.et_Internal, severity_type.st_error,
                //    "PositionsClosedCmd: " + LocalizeManager.GetErrorMessage(ErrorMessageClient.ErrorOccurred, ex));
            }
        }

        private void ClearFolder(string folderName)
        {
            var dir = new DirectoryInfo(folderName);

            foreach (var fi in dir.GetFiles())
            {
                fi.Delete();
            }
            foreach (var di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
            dir.Delete();
        }

        #endregion
    }
}