using System;
using Commons.BusinessObjects;
using PresentationLayer.Explorer.Data;
using PresentationLayer.QuestionEditor.Data;
using PresentationLayer.Explorer;

namespace PresentationLayer.ActionController
{
    public class GuiActionEventController
    {
        #region Properties

        private string _folderId;
        private string _testId;
        private string _leaveTest;

        private int _questionID;

        public string FolderId
        {
            set
            {
                _folderId = value;
                OnChangeFolderId(_folderId);
            }
            get { return _folderId; }
        }
        public int QuestionId
        {
            set
            {
                _questionID = value;
                OnChangeQuestionId(_questionID);
            }
            get { return _questionID; }
        }

        public int LeaveQuestion
        {
            set
            {
                _questionID = value;
                OnChangeLeaveQuestion(_questionID);
            }
            get { return _questionID; }
        }

        public string LeaveTest
        {
            set
            {
                _leaveTest = value;
                OnChangeLeaveTest(_leaveTest);
            }
            get { return _testId; }
 
        }

        public string TestId
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
        private ActionEventHandler<string> _changeTestIdEvent;

        public event ActionEventHandler<string> ChangeTestId
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

        public void OnChangeTestId(string id)
        {
            ActionEventHandler<string> handler = _changeTestIdEvent;
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

        #region Event clear question item on list panel

        private readonly object _clearAllQuestionItemLocker = new object();
        private ActionEventHandler _clearAllQuestionItemEvent;

        /// <summary>
        /// 
        /// </summary>
        public event ActionEventHandler ClearAllQuestionItem
        {
            add
            {
                lock (_clearAllQuestionItemLocker)
                {
                    _clearAllQuestionItemEvent += value;
                }
            }
            remove
            {
                lock (_clearAllQuestionItemLocker)
                {
                    _clearAllQuestionItemEvent -= value;
                }
            }
        }

        public void OnClearAllQuestionItem()
        {
            ActionEventHandler handler = _clearAllQuestionItemEvent;
            if (handler != null)
            {
                try
                {
                    handler(this);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        #endregion End event clear question item on list panel

        #endregion

        private readonly object __addTestItemEventLocker = new object();
        private ActionEventHandler<TestDataItem> _addTestDataItemEvent;

        public event ActionEventHandler<TestDataItem> AddTestItem
        {
            add
            {
                lock (__addTestItemEventLocker)
                {
                    _addTestDataItemEvent += value;
                }
            }
            remove
            {
                lock (__addTestItemEventLocker)
                {
                    _addTestDataItemEvent -= value;
                }
            }
        }

        internal void OnAddTestItem( TestDataItem dataItem)
        {
            ActionEventHandler<TestDataItem> handler = _addTestDataItemEvent;
            if (handler != null)
            {
                try
                {
                    handler(this, dataItem);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        private readonly object _clearAllTestItemLocker = new object();
        private ActionEventHandler _clearAllTestItemEvent;

        /// <summary>
        /// 
        /// </summary>
        public event ActionEventHandler ClearAllTestItem
        {
            add
            {
                lock (_clearAllTestItemLocker)
                {
                    _clearAllTestItemEvent += value;
                }
            }
            remove
            {
                lock (_clearAllTestItemLocker)
                {
                    _clearAllTestItemEvent -= value;
                }
            }
        }

        public void OnClearAllTestItem()
        {
            ActionEventHandler handler = _clearAllTestItemEvent;
            if (handler != null)
            {
                try
                {
                    handler(this);
                }
                catch (Exception ex)
                {
                    //Log
                }
            }
        }

        private readonly object _changeLeaveTestEventLocker = new object();
        private ActionEventHandler<string> _changeLeaveTestEvent;

        public event ActionEventHandler<string> ChangeLeaveTest
        {
            add
            {
                lock (_changeLeaveTestEventLocker)
                {
                    _changeLeaveTestEvent += value;
                }
            }
            remove
            {
                lock (_changeLeaveTestEventLocker)
                {
                    _changeLeaveTestEvent -= value;
                }
            }
        }

        public void OnChangeLeaveTest(string id)
        {
            ActionEventHandler<string> handler = _changeLeaveTestEvent;
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

        #region Event Change Question id

        private readonly object _changeQuestionIdEventLocker = new object();
        private ActionEventHandler<int> _changeQuestionIdEvent;

        public event ActionEventHandler<int> ChangeQuestionId
        {
            add
            {
                lock (_changeQuestionIdEventLocker)
                {
                    _changeQuestionIdEvent += value;
                }
            }
            remove
            {
                lock (_changeQuestionIdEventLocker)
                {
                    _changeQuestionIdEvent -= value;
                }
            }
        }

        public void OnChangeQuestionId(int id)
        {
            ActionEventHandler<int> handler = _changeQuestionIdEvent;
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

        #endregion End event change question id

        private readonly object _changeLeaveQuestionEventLocker = new object();
        private ActionEventHandler<int> _changeLeaveQuestionEvent;

        public event ActionEventHandler<int> ChangeLeaveQuestion
        {
            add
            {
                lock (_changeLeaveQuestionEventLocker)
                {
                    _changeLeaveQuestionEvent += value;
                }
            }
            remove
            {
                lock (_changeLeaveQuestionEventLocker)
                {
                    _changeLeaveQuestionEvent -= value;
                }
            }
        }

        public void OnChangeLeaveQuestion(int id)
        {
            ActionEventHandler<int> handler = _changeLeaveQuestionEvent;
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
    }
}