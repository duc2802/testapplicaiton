using System;

namespace ThreadQueueManager
{
    public class DelegateCommand : ICommand
    {
        private readonly Delegate _delegateToExec;
		private readonly object[] _parameters;

        public DelegateCommand(Delegate deleg)
            : this(deleg, null)
        {
        }

        public DelegateCommand(Delegate deleg, params object[] parameters)
        {
            _delegateToExec = deleg;
            this._parameters = parameters;
        }

		#region ICommand Members
        public int Priority
        {
            get { return 0; }
        }
        
		public ExecuteMethod IsSeparate()
		{
			return ExecuteMethod.Async;
		}

		public string GetName()
		{
            return "DelegateCommand";
		}

		public void Execute()
		{
            if (_delegateToExec == null)
                return;

			try
			{
				_delegateToExec.DynamicInvoke(_parameters);
			}
			catch (Exception ex)
			{
                //LogManager.Log(event_type.et_Undefined, severity_type.st_error,
                //    LocalizeManager.GetErrorMessage(ErrorMessageClient.DelegateCmdExecuteError, 
                //        delegateToExec.Target != null ? delegateToExec.Target.GetType().Name : String.Empty,
                //        delegateToExec.Method != null ? delegateToExec.Method.Name : String.Empty,
                //        ex.Message), ex);
			}
		}
		#endregion

        public override string ToString()
        {
            return "DelegateCommand: " + _delegateToExec.Method.Name;
        }
    }
}
