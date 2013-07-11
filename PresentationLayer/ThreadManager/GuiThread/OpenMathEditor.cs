using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Editor;
using ThreadQueueManager;

namespace PresentationLayer.ThreadManager.GuiThread
{
    public class OpenMathEditor:ICommand
    {
        private readonly string _name;
        private readonly ExecuteMethod synch_ = ExecuteMethod.Async;
        public OpenMathEditor(ExecuteMethod synch)
        {
            synch_ = synch;
            _name = "OpenMathEditor";
           
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
                var thread = new Thread(() =>
                {
                    try
                    {
                        var app = new App();
                        app.InitializeComponent();
                        app.Run();
                        System.Windows.Threading.Dispatcher.Run();
                    }
                    catch (Exception ex)
                    {

                    }
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
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
