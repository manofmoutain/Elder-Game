using System.Collections;
using System.Collections.Generic;
using System.Data;
using Global.Database;
using Excel;

namespace Asia.Database
{
    public class LoadColumns : LoadExcel
    {
        public List<string> ReadTargetColumns(string path, string fileName, string sheetName, int rowIndex, int targetIndex,
            int targetCount, int locationIndex, int locationCount)
        {
            string excelName = fileName + ".xlsx";
            DataRowCollection collect = ExcelReader(path, excelName, sheetName);

            List<string> _string = new List<string>();
            for (int i = 0; i < targetCount; i++)
            {
                string target = collect[rowIndex][targetIndex + i].ToString();
                _string.Add(target);
            }

            for (int i = 0; i < locationCount; i++)
            {
                string locationName = collect[rowIndex][locationIndex + i].ToString();
                _string.Add(locationName);
            }

            return _string;
        }

        public List<string> ReadLocationColumns(string path, string fileName, string sheetName, int rowIndex, int locationIndex,
            int locationCount)
        {
            string excelName = fileName + ".xlsx";
            DataRowCollection collect = ExcelReader(path, excelName, sheetName);

            List<string> _string = new List<string>();

            for (int i = 0; i < locationCount; i++)
            {
                string locationName = collect[rowIndex][locationIndex + i].ToString();
                _string.Add(locationName);
            }

            return _string;
        }
    }
}