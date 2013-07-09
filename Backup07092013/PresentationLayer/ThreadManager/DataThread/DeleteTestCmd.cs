using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntities;
using SingleInstanceObject;
using TestApplication;
using ThreadQueueManager;

namespace PresentationLayer.ThreadManager.DataThread
{
    public class DeleteTestCmd : ICommand
    {
        private readonly string _name;
        private readonly ExecuteMethod synch_ = ExecuteMethod.Async;

        private TestBE _testBE;

        public DeleteTestCmd(ExecuteMethod synch, TestBE testBE)
        {
            synch_ = synch;
            _name = "DeleteTestCmd";
            _testBE = testBE;
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
                var businessObject = new TestBLL();
                if (businessObject.DeleteTestExamFile(_testBE.TestID, _testBE.FolderId))
                {
                    var testBE = Singleton<List<TestBE>>.Instance.FirstOrDefault(test => test.TestID.Equals(_testBE.TestID));
                    if (testBE != null)
                    {
                        Singleton<List<TestBE>>.Instance.Remove(testBE);
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("Can't delete {0}", _testBE.TestID), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //LogManager.Log(event_type.et_Internal, severity_type.st_error,
                //    "PositionsClosedCmd: " + LocalizeManager.GetErrorMessage(ErrorMessageClient.ErrorOccurred, ex));
            }
        }

        #endregion
    }
}
