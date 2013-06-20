using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace TestApplication
{
    public class TestBLL
    {
        public bool exportTestXMLFile(TestBE testData, string name, string placeToSave)
        {
            bool result = ActionXML.saveExam(testData,name,placeToSave);
            return result;
        }
    }
}
