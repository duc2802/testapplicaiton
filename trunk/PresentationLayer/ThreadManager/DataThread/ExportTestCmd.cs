using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using BusinessEntities;
using DataAccessLayer;
using ThreadQueueManager;

namespace PresentationLayer.ThreadManager.DataThread
{
    public class ExportTestCmd : ICommand
    {
        private readonly string _name;
        private readonly ExecuteMethod _synch = ExecuteMethod.Async;

        private string _nameFile = "test";
        private string _extend = "exb";
        private string _directory;
        private string _file;

        public ExportTestCmd(ExecuteMethod synch, string file, string directory, string nameFile)
        {
            _synch = synch;
            _name = "ExportTestCmd";

            _file = file;
            _directory = directory;
            _nameFile = nameFile;
        }

        #region ICommand Members

        public string GetName()
        {
            return _name;
        }

        public ExecuteMethod IsSeparate()
        {
            return _synch;
        }

        public int Priority
        {
            get { return 0; }
        }

        public void Execute()
        {
            try
            {
                string path = _directory + "\\" + _nameFile + "." + _extend;
                var testBE = XmlHelper.ReadExamFile(_file);
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    using (var cfs = new GZipStream(fs, CompressionMode.Compress))
                    {
                        var serializerObject = new XmlSerializer(typeof(TestBE));
                        serializerObject.Serialize(cfs, testBE);
                    }
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
