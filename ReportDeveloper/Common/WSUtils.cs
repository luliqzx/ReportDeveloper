using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace ReportDeveloper.Common
{
    public class WSUtils
    {
        #region SQLite
        public string DbFile
        {
            get { return Environment.CurrentDirectory + "\\ReportPDFDB.sqlite"; }
        }

        private static IDbConnection _sqliteCon { get; set; }

        private IDbConnection MySQLiteConnection()
        {
            try
            {
                if (_sqliteCon == null)
                {
                    _sqliteCon = new SQLiteConnection("Data Source=" + DbFile);
                }
            }
            catch (Exception)
            {
                _sqliteCon = null;
            }

            return _sqliteCon;
        }

        public IDbConnection sqliteCon { get { return MySQLiteConnection(); } }

        #endregion

        public static void EnsureFolder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            {
                Directory.CreateDirectory(directoryName);
            }
        }

    }
}
