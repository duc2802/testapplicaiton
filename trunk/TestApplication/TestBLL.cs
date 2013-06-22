using BusinessEntities;
using DataAccessLayer;

namespace TestApplication
{
    public class TestBLL
    {
        public bool ExportTestExamFile(TestBE testData, string name, string placeToSave)
        {
            return XmlHelper.WriteExamFile(testData, name, placeToSave);
        }

    }
}