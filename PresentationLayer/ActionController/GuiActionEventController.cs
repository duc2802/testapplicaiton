using System;
using Commons.BusinessObjects;
using PresentationLayer.QuestionEditor.Data;

namespace PresentationLayer.ActionController
{
    public class GuiActionEventController
    {
        #region Properties

        private string _folderId;


        private int _testId;

        public string FolderId
        {
            set
            {
                _folderId = value;
                OnChangeFolderId(_folderId);
            }
            get { return _folderId; }
        }

        public int TestId
        {
            set
            {
                _testId = value;
                OnChangeTestId(_testId);
            }
            get { return _testId; }
        }

        #endregion

        #region Events

        #region Event change forder id

        private readonly object _changeFolderIdLocker = new object();
        private ActionEventHandler<string> _changeFolderIdEvent;

        /// <summary>
        /// 
        /// </summary>
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
                lock (_changeFolderIdLocker)
                {
                    _changeFolderIdEvent -= value;
                }
            }
        }

        public void OnChangeFolderId(string folderId)
        {
            ActionEventHandler<string> handler = _changeFolderIdEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, folderId);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        #endregion End event change forder id

        #region Event Change Test id

        private readonly object _changeTestIdEventLocker = new object();
        private ActionEventHandler<int> _changeTestIdEvent;

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

        #endregion End event change test id

        #region Event add question to test.

        private readonly object __addQuestionItemEventLocker = new object();
        private ActionEventHandler<QuestionDataItem> _addQuestionItemEvent;

        /// <summary>
        /// Event add question to test.
        /// </summary>
        public event ActionEventHandler<QuestionDataItem> AddQuestionItem
        {
            add
            {
                lock (__addQuestionItemEventLocker)
                {
                    _addQuestionItemEvent += value;
                }
            }
            remove
            {
                lock (__addQuestionItemEventLocker)
                {
                    _addQuestionItemEvent -= value;
                }
            }
        }

        public void OnAddQuestionItem(QuestionDataItem questionDataItem)
        {
            ActionEventHandler<QuestionDataItem> handler = _addQuestionItemEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, questionDataItem);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        #endregion End event add question to test.

        #endregion
    }
}