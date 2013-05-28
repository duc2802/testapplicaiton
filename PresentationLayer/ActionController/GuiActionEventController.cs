using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commons.BusinessObjects;


namespace PresentationLayer.ActionController
{
    public class GuiActionEventController
    {
        #region Properties

        public string FolderId
        {
            set
            {
                this._folderId = value;
                OnChangeFolderId(_folderId);
            }
            get { return this._folderId; }
        }
        private string _folderId;


        public int TestId
        {
            set
            {
                this._testId = value;
                OnChangeTestId(_testId);
            }
            get { return this._testId; }
        }
        private int _testId;

        #endregion

        #region Event
        public event ActionEventHandler<string> ChangeFolderId
        {
            add
            {
                lock (_changeFolderIdLocker)
                {
                    _changeFolderIdEvent += value;
                }
            }
            remove
            {
                lock(_changeFolderIdLocker)
                {
                    _changeFolderIdEvent -= value;
                }
            }
        }

        private ActionEventHandler<string> _changeFolderIdEvent;
        private readonly object _changeFolderIdLocker = new object();

        public void OnChangeFolderId(string folderId)
        {
            ActionEventHandler<string> handler = _changeFolderIdEvent;
            if(handler != null)
            {
                try
                {
                    handler(this, folderId);
                }
                catch(Exception ex)
                {
                    //Log
                }
            }
        }


        public event ActionEventHandler<int> ChangeTestId
        {
            add
            {
                lock (_changeTestIdEventLocker)
                {
                    _changeTestIdEvent += value;
                }
            }
            remove
            {
                lock (_changeTestIdEventLocker)
                {
                    _changeTestIdEvent -= value;
                }
            }
        }

        private ActionEventHandler<int> _changeTestIdEvent;
        private readonly object _changeTestIdEventLocker = new object();

        public void OnChangeTestId(int id)
        {
            ActionEventHandler<int> handler = _changeTestIdEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, id);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        #endregion
    }
}
