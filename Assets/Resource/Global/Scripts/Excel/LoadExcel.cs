using System.Data;
using System.IO;
using UnityEngine;
using Excel;

namespace Global.Database
{
    public class LoadExcel
    {
        private int columns;

        private int rows;

        public string ReadExcelSimplePasses(string path, string fileName, string sheetName, int rowIndex, int columnsIndex)
        {
            // excelFileName = fileName;
            string excelName = fileName + ".xlsx";
            // string sheetName = "sheet1";
            DataRowCollection collect = ExcelReader(path, excelName, sheetName);

            // SetLesson(collect[0][2].ToString());
            // SetSchool(collect[1][2].ToString());

            //洗白


            return collect[rowIndex][columnsIndex].ToString();
        }

        /// <summary>
        /// 取得Excel檔的欄位資訊
        /// </summary>
        /// <param name="excelName">檔案名稱</param>
        /// <param name="sheetName">第幾項資料</param>
        /// <param name="columnsIndex">總共幾個欄位</param>
        /// <returns></returns>
        protected DataRowCollection ExcelReader(string excelPath, string excelName, string sheetName)
        {
            string path = Application.dataPath + excelPath + excelName;
            // Debug.Log(path);
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet result = excelReader.AsDataSet();
            columns = result.Tables[0].Columns.Count;
            // columns = columnsIndex;
            rows = result.Tables[0].Rows.Count;
            excelReader.Close();


            //tables可以按照sheet名获取，也可以按照sheet索引获取
            //return result.Tables[0].Rows;
            // Debug.Log(result.Tables[sheetName].Rows);
            return result.Tables[sheetName].Rows;
        }
    }
}