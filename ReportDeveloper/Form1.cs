using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using ReportDeveloper.DTOs;
using System.Data.SQLite;

namespace ReportDeveloper
{
    public partial class Form1 : Form
    {
        private DataTable globalDataTable = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGridView();
            labelLoading.Visible = false;
        }

        private void LoadGridView()
        {
            try
            {
                IList<path> lstpath = new List<path>();
                string qry = @"select * from path";
                using (IDbConnection sqliteCon = new SQLiteConnection("Data Source=" + DbFile + ";version=3;new=False;datetimeformat=CurrentCulture"))
                {
                    lstpath = sqliteCon.Query<path>(qry).ToList();
                    //dataGridView1.DataSource = x;
                }
                DataTable dt = CommonHelper.ToDataTables<path>(lstpath);
                globalDataTable = dt;
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occurred during loading the data. Please try again later.\r\n" + ex.Message);
            }
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            //where icno = 550906106407
            try
            {
                labelLoading.Text = "Data sedang dijana ..";
                labelLoading.Visible = true;
                MessageBox.Show("Refreshing data from live server, click OK to continue.");
                string Query = string.Empty;
                //makkebun
                Query = "select * from makkebun";
                //GetDataFromLiveDatabase(Query, "tbl_makkebun");
                GetDataFromLiveDatabaseV2<tbl_makkebun>(Query, "tbl_makkebun");
                //sokongan
                Query = "select * from sokongan";
                //GetDataFromLiveDatabase(Query, "tbl_sokongan");
                GetDataFromLiveDatabaseV2<tbl_sokongan>(Query, "tbl_sokongan");
                //daerah
                Query = "select * from daerah ";
                //GetDataFromLiveDatabase(Query, "tbl_daerah");
                GetDataFromLiveDatabaseV2<tbl_daerah>(Query, "tbl_daerah");
                //parlimen
                Query = "select * from parlimen ";
                //GetDataFromLiveDatabase(Query, "tbl_parlimen");
                GetDataFromLiveDatabaseV2<tbl_parlimen>(Query, "tbl_parlimen");
                //dun
                Query = "select * from dun ";
                //GetDataFromLiveDatabase(Query, "tbl_dun");
                GetDataFromLiveDatabaseV2<tbl_dun>(Query, "tbl_dun");
                //variables
                Query = "select * from variables ";
                //GetDataFromLiveDatabase(Query, "tbl_variables");
                GetDataFromLiveDatabaseV2<tbl_variables>(Query, "tbl_variables");
                //pembayaran
                Query = "select * from pembayaran ";
                //GetDataFromLiveDatabase(Query, "tbl_pembayaran");
                GetDataFromLiveDatabaseV2<tbl_pembayaran>(Query, "tbl_pembayaran");
                //appinfo
                Query = "select * from appinfo ";
                //GetDataFromLiveDatabase(Query, "tbl_appinfo");
                GetDataFromLiveDatabaseV2<tbl_appinfo>(Query, "tbl_appinfo");

                //Display query  
                Query = "select a.*,d.daerah as d_daerah, p.kawasan as p_parlimen, (select value from variables where code = a.negeri limit 1) as v_negeri from appinfo a inner join daerah d on d.kod_daerah = a.daerah inner join parlimen p on p.id = a.parlimen  ";
                //string Query = "select a.*,d.daerah as d_daerah, p.kawasan as p_parlimen, v.value as v_negeri from appinfo a inner join daerah d on d.kod_daerah = a.daerah inner join parlimen p on p.id = a.parlimen inner join variables v on v.code = a.negeri";
                //dataGridView1.DataSource = GetDataFromLiveDatabase(Query, "path");
                GetDataFromLiveDatabaseV2<path>(Query, "path");
                ////using (IDbConnection sqliteCon = new SQLiteConnection("Data Source=" + DbFile))
                ////{
                ////    sqliteCon.Open();

                ////    SqlMapper.AddTypeMap(typeof(DateTime), System.Data.DbType.DateTime2);
                ////    var x = sqliteCon.Query("select id,	refno,	nama,	type_id,	icno,	nolesen,	bangsa,	addr1,	addr2,	addr3,	bandar,	daerah,	dun,	parlimen,	poskod,	negeri,	hometel,	officetel,	hptel,	faks,	email,	kelompok,	createdby,	appdate,	semak_tapak,	keputusan,	sts_bck,	status,	approved_by,	sop,	status_bantuan from path");
                ////    dataGridView1.DataSource = x;
                ////}

                //InfoKebun 
                Query = "select b.appinfo_id,c.tarikh_lulus, y.kawasan as parlimen , b.dun, b.nolot no_lot, b.addr1, b.addr2, b.addr3, b.negeri, b.daerah, c.luas from appinfo a inner join makkebun b on a.id = b.appinfo_id inner join sokongan c on a.id = c.appinfo_id inner join parlimen y on b.parlimen = y.id ";
                //GetDataFromLiveDatabase(Query, "infokebun");
                GetDataFromLiveDatabaseV2<infokebun>(Query, "infokebun");

                //Pembayaran
                Query = "select a.appinfo_id, a.tarikh_cek as tarikh ,a.penerima , a.amaun,case a.tujuan when 'B_PK' then 'B01' when 'B_BAJA' then 'B02' when 'B_BENIH' then 'B03' when 'B_KIMIA' then 'B04' when 'B_THN1' then 'B05'  when 'B_THN2' then 'B06' end as tujuan from pembayaran a ";
                //GetDataFromLiveDatabase(Query, "pembayaran");
                GetDataFromLiveDatabaseV2<pembayaran>(Query, "pembayaran");

                //Amount Calculations
                //Query = "select a.id as appinfo_id, CASE WHEN b.negeri = 'SWK' then round(9000 * c.luas, 2) WHEN b.negeri = 'SBH' then round(9000 * c.luas, 2) ELSE round(7500 * c.luas, 2) END as allocation_peruntukan from appinfo a inner join makkebun b on a.id = b.appinfo_id inner join sokongan c on a.id = c.appinfo_id inner join parlimen y on b.parlimen = y.id where c.kelulusan = 'LULUS'";
                Query = "select a.id as appinfo_id, round(sum(c.luas),4) as luas_lulus, SUM(CASE WHEN b.negeri = 'SWK' then round(9000 * c.luas, 2) WHEN b.negeri = 'SBH' then round(9000 * c.luas, 2) ELSE round(7500 * c.luas, 2) END) as allocation_peruntukan from appinfo a inner join makkebun b on a.id = b.appinfo_id inner join sokongan c on b.id_makkebun = c.makkebun_id where c.kelulusan = 'LULUS' group by a.id  ";
                //GetDataFromLiveDatabase(Query, "amtcalc");
                GetDataFromLiveDatabaseV2<amtcalc>(Query, "amtcalc");

                //Pembayaran_01
                Query = "select sum(a.amaun) as sum_tujuan, a.appinfo_id, a.tujuan from pembayaran a group by tujuan, appinfo_id ";
                //GetDataFromLiveDatabase(Query, "Pembayaran_01");
                GetDataFromLiveDatabaseV2<Pembayaran_01>(Query, "Pembayaran_01");

                ////Section c
                //Query = "select a.appinfo_id, a.nolot as no_lot, concat(a.addr1, ',', a.addr2) as alamat_kebun, c.daerah as daerah, d.kawasan as parlimen, e.dun_desc as dun, f.value as negeri, b.kelulusan as k_status, format(b.luas,4) as luas, DATE_FORMAT(b.tarikh_lulus, '%d-%m-%Y') as tarikh_kuputusan from makkebun a left join sokongan b on a.id_makkebun=b.makkebun_id join daerah c on a.daerah=c.kod_daerah join parlimen d on a.parlimen = d.id join dun e on a.dun = e.kod_dun join variables f on a.negeri=f.code";
                //GetDataFromLiveDatabase(Query, "SectionC");

                CreateIndexTable();

                labelLoading.Visible = false;
                LoadGridView();


            }
            catch (Exception ex)
            {
                labelLoading.Text = "Some error occured during refreshing the data, please restart the application and try again.\r\nError:" + ex.Message;
            }
        }

        private void CreateIndexTable()
        {
            string qry = @"CREATE INDEX IF NOT EXISTS [IDXAPPINFOID] ON [tbl_appinfo] ([id]);
                                    CREATE INDEX IF NOT EXISTS [IDXAPPINFOID] ON [tbl_makkebun] ([appinfo_id]);
                                    CREATE INDEX IF NOT EXISTS [idxmakkebun_id] ON [tbl_sokongan] ([makkebun_id]);
                                    CREATE INDEX IF NOT EXISTS [IDXAPPINFOID] ON [tbl_pembayaran] ([appinfo_id]);
                                    CREATE INDEX IF NOT EXISTS [IDXAPPINFOID] ON [amtcalc] ([appinfo_id]);
                                    CREATE INDEX IF NOT EXISTS [IDXAPPINFOID] ON [infokebun] ([appinfo_id]);
                                    CREATE INDEX IF NOT EXISTS [IDXAPPINFOID] ON [path] ([id]);
                                    CREATE INDEX IF NOT EXISTS [IDXAPPINFOID] ON [pembayaran] ([appinfo_id]);
                                    CREATE INDEX IF NOT EXISTS [IDXAPPINFOID] ON [Pembayaran_01] ([appinfo_id]);
                ";
            using (IDbConnection sqliteCon = new SQLiteConnection("Data Source=" + DbFile + ";version=3;new=False;datetimeformat=CurrentCulture"))
            {
                int i = 0;
                sqliteCon.Open();
                using (IDbTransaction trans = sqliteCon.BeginTransaction())
                {
                    i = sqliteCon.Execute(qry, transaction: trans);
                    trans.Commit();
                }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //where icno = 550906106407
            try
            {
                labelLoading.Text = "Data sedang dijana ..";
                labelLoading.Visible = true;
                MessageBox.Show("Refreshing data from live server, click OK to continue.");
                string Query = string.Empty;
                //makkebun
                Query = "select * from makkebun";
                //GetDataFromLiveDatabase(Query, "tbl_makkebun");
                //sokongan
                Query = "select * from sokongan";
                //GetDataFromLiveDatabase(Query, "tbl_sokongan");
                //daerah
                Query = "select * from daerah";
                //GetDataFromLiveDatabase(Query, "tbl_daerah");
                //parlimen
                Query = "select * from parlimen";
                //GetDataFromLiveDatabase(Query, "tbl_parlimen");
                //dun
                Query = "select * from dun";
                //GetDataFromLiveDatabase(Query, "tbl_dun");
                //variables
                Query = "select * from variables";
                //GetDataFromLiveDatabase(Query, "tbl_variables");
                //pembayaran
                Query = "select * from pembayaran";
                //GetDataFromLiveDatabase(Query, "tbl_pembayaran");
                //appinfo
                Query = "select * from appinfo";
                //GetDataFromLiveDatabase(Query, "tbl_appinfo");

                //Display query  
                Query = "select a.*,d.daerah as d_daerah, p.kawasan as p_parlimen, (select value from variables where code = a.negeri limit 1) as v_negeri from appinfo a inner join daerah d on d.kod_daerah = a.daerah inner join parlimen p on p.id = a.parlimen";
                //string Query = "select a.*,d.daerah as d_daerah, p.kawasan as p_parlimen, v.value as v_negeri from appinfo a inner join daerah d on d.kod_daerah = a.daerah inner join parlimen p on p.id = a.parlimen inner join variables v on v.code = a.negeri";
                //dataGridView1.DataSource = GetDataFromLiveDatabase(Query, "path");

                //InfoKebun 
                Query = "select b.appinfo_id,c.tarikh_lulus, y.kawasan as parlimen , b.dun, b.nolot no_lot, b.addr1, b.addr2, b.addr3, b.negeri, b.daerah, c.luas from appinfo a inner join makkebun b on a.id = b.appinfo_id inner join sokongan c on a.id = c.appinfo_id inner join parlimen y on b.parlimen = y.id";
                //GetDataFromLiveDatabase(Query, "infokebun");

                //Pembayaran
                Query = "select a.appinfo_id, a.tarikh_cek as tarikh ,a.penerima , a.amaun,case a.tujuan when 'B_PK' then 'B01' when 'B_BAJA' then 'B02' when 'B_BENIH' then 'B03' when 'B_KIMIA' then 'B04' when 'B_THN1' then 'B05'  when 'B_THN2' then 'B06' end as tujuan from pembayaran a";
                //GetDataFromLiveDatabase(Query, "pembayaran");

                //Amount Calculations
                //Query = "select a.id as appinfo_id, CASE WHEN b.negeri = 'SWK' then round(9000 * c.luas, 2) WHEN b.negeri = 'SBH' then round(9000 * c.luas, 2) ELSE round(7500 * c.luas, 2) END as allocation_peruntukan from appinfo a inner join makkebun b on a.id = b.appinfo_id inner join sokongan c on a.id = c.appinfo_id inner join parlimen y on b.parlimen = y.id where c.kelulusan = 'LULUS'";
                Query = "select a.id as appinfo_id, round(sum(c.luas),4) as luas_lulus, SUM(CASE WHEN b.negeri = 'SWK' then round(9000 * c.luas, 2) WHEN b.negeri = 'SBH' then round(9000 * c.luas, 2) ELSE round(7500 * c.luas, 2) END) as allocation_peruntukan from appinfo a inner join makkebun b on a.id = b.appinfo_id inner join sokongan c on b.id_makkebun = c.makkebun_id where c.kelulusan = 'LULUS' group by a.id ";
                //GetDataFromLiveDatabase(Query, "amtcalc");

                //Pembayaran_01
                Query = "select sum(a.amaun) as sum_tujuan, a.appinfo_id, a.tujuan from pembayaran a group by tujuan, appinfo_id";
                //GetDataFromLiveDatabase(Query, "Pembayaran_01");

                //////Section c
                ////Query = "select a.appinfo_id, a.nolot as no_lot, concat(a.addr1, ',', a.addr2) as alamat_kebun, c.daerah as daerah, d.kawasan as parlimen, e.dun_desc as dun, f.value as negeri, b.kelulusan as k_status, format(b.luas,4) as luas, DATE_FORMAT(b.tarikh_lulus, '%d-%m-%Y') as tarikh_kuputusan from makkebun a left join sokongan b on a.id_makkebun=b.makkebun_id join daerah c on a.daerah=c.kod_daerah join parlimen d on a.parlimen = d.id join dun e on a.dun = e.kod_dun join variables f on a.negeri=f.code";
                ////GetDataFromLiveDatabase(Query, "SectionC");

                labelLoading.Visible = false;
                LoadGridView();
            }
            catch (Exception ex)
            {
                labelLoading.Text = "Some error occured during refreshing the data, please restart the application and try again.\r\nError:" + ex.Message;
            }
        }

        private DataTable GetDataFromLiveDatabase(string query, string fileName)
        {
            string MyConnection2 = ConfigurationSettings.AppSettings["MySqlDB"].ToString();
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);

            MyConn2.Open();

            MySqlCommand cmd = new MySqlCommand("set net_write_timeout=99999; set net_read_timeout=99999", MyConn2); // Setting tiimeout on mysqlServer
            cmd.ExecuteNonQuery();


            //For offline connection we weill use  MySqlDataAdapter class.  
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand2;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            string jsonData = CommonHelper.DataTableToJSONWithStringBuilder(dTable);
            //string jsonData = CommonHelper.DataTableToJSONWithJSONNet(dTable);

            //open file stream
            using (StreamWriter file = File.CreateText(Directory.GetCurrentDirectory() + @"\" + fileName + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, jsonData);
            }
            return dTable;
        }

        public string DbFile
        {
            get { return Environment.CurrentDirectory + "\\ReportDeveloperDB.sqlite"; }
        }

        private void GetDataFromLiveDatabaseV2<T>(string query, string tblname) where T : class
        {
            string MyConnection2 = ConfigurationSettings.AppSettings["MySqlDB"].ToString();
            #region mysql Comment
            //MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            //MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);

            //MyConn2.Open();

            //MySqlCommand cmd = new MySqlCommand("set net_write_timeout=99999; set net_read_timeout=99999", MyConn2); // Setting tiimeout on mysqlServer
            //cmd.ExecuteNonQuery();


            ////For offline connection we weill use  MySqlDataAdapter class.  
            //MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            //MyAdapter.SelectCommand = MyCommand2;
            //DataTable dTable = new DataTable();
            //MyAdapter.Fill(dTable);
            ////string jsonData = CommonHelper.DataTableToJSON(dTable);
            ////string jsonData = CommonHelper.DataTableToJSONWithJSONNet(dTable);

            ////open file stream
            //using (StreamWriter file = File.CreateText(Directory.GetCurrentDirectory() + @"\" + fileName + ".json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    //serialize object directly into file stream
            //    serializer.Serialize(file, CommonHelper.DataTableToJSON(dTable));
            //}
            //return dTable;
            #endregion

            #region from server
            IList<T> lstT = new List<T>();
            using (IDbConnection mysqlCon = new MySqlConnection(MyConnection2))
            {
                mysqlCon.Open();
                lstT = mysqlCon.Query<T>(query, commandTimeout: 99999).ToList();
            }
            #endregion

            using (IDbConnection sqliteCon = new SQLiteConnection("Data Source=" + DbFile + ";version=3;new=False;datetimeformat=CurrentCulture"))
            {
                sqliteCon.Open();
                int i = 0;
                using (IDbTransaction trans = sqliteCon.BeginTransaction())
                {
                    string qry = @"DROP TABLE IF EXISTS " + tblname;
                    i = sqliteCon.Execute(qry);
                    T t = Activator.CreateInstance<T>();
                    var props = t.GetType().GetProperties();
                    qry = CreateTable(tblname, props);
                    i = sqliteCon.Execute(qry);
                    SqlMapper.AddTypeMap(typeof(DateTime), System.Data.DbType.DateTime2);
                    qry = InsertTable(tblname, props);
                    i = sqliteCon.Execute(qry, lstT, trans);
                    trans.Commit();
                }

            }
        }

        private string InsertTable(string tblname, System.Reflection.PropertyInfo[] props)
        {
            string Start = @"INSERT INTO " + tblname; //
            string Bracket1 = " ( ";
            string Bracket2 = " ) ";
            string field1 = "";
            string field2 = "";
            for (int i = 0; i < props.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(field1))
                {
                    field1 = props[i].Name;
                }
                else
                {
                    field1 = field1 + Environment.NewLine + ", " + props[i].Name;
                }

                if (string.IsNullOrWhiteSpace(field2))
                {
                    field2 = "@" + props[i].Name;
                }
                else
                {
                    field2 = field2 + Environment.NewLine + ", " + "@" + props[i].Name;
                }
            }
            string insertQry = Start + Bracket1 + field1 + Bracket2 + " VALUES " + Bracket1 + field2 + Bracket2;
            return insertQry;
        }

        private string CreateTable(string tblname, System.Reflection.PropertyInfo[] props)
        {
            string Start = @"Create Table " + tblname + " ( ";
            string fields = "";
            for (int i = 0; i < props.Length; i++)
            {
                string PropertyType = GetPropertyTypeName(props[i]);
                if (string.IsNullOrWhiteSpace(fields))
                {
                    fields = props[i].Name + " " + PropertyType;
                }
                else
                {
                    fields = fields + Environment.NewLine + ", " + props[i].Name + " " + PropertyType;
                }
            }
            string End = @" ) ";
            string table = Start + fields + End;
            return table;
        }

        private string GetPropertyTypeName(System.Reflection.PropertyInfo propertyInfo)
        {
            string PropTypeName = "";
            if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(object))
            {
                PropTypeName = "varchar COLLATE NOCASE NULL";
            }
            else if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(int?))
            {
                PropTypeName = "Integer default null";
            }
            else
            {
                if (propertyInfo.PropertyType == typeof(decimal?))
                {
                    PropTypeName = "decimal(18,4) default null";
                }
                else if (propertyInfo.PropertyType == typeof(DateTime?))
                {
                    PropTypeName = "datetime default null";
                }
                else if (propertyInfo.PropertyType == typeof(decimal?))
                {
                    PropTypeName = "datetime default null";
                }
                else
                {
                    PropTypeName = propertyInfo.PropertyType.Name + " default null";
                }
            }
            return PropTypeName;
        }

        private Int32 GetCount(string query)
        {
            string MyConnection2 = ConfigurationSettings.AppSettings["MySqlDB"].ToString();
            using (var conn = new MySqlConnection(MyConnection2))
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand("set net_write_timeout=9999999; set net_read_timeout=9999999", conn); // Setting tiimeout on mysqlServer
                cmd1.ExecuteNonQuery();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                labelLoading.Visible = true;
                if (string.IsNullOrEmpty(mtxtIcno.Text) && mtxtRefno.Text.Replace(" ", "").Length == 2)
                {
                    dataGridView1.DataSource = globalDataTable;
                    labelLoading.Visible = false;
                    return;
                }
                string icno = string.Empty;
                string searchString = string.Empty;
                string refrenceNo = mtxtRefno.Text.Replace(" ", "").Replace("-", @"/");


                if (!string.IsNullOrEmpty(mtxtIcno.Text) && mtxtRefno.Text.Replace(" ", "").Length == 2)
                    searchString = "icno like  '%" + mtxtIcno.Text + "%'";
                else if (!string.IsNullOrEmpty(mtxtIcno.Text) && mtxtRefno.Text.Replace(" ", "").Length != 2)
                    searchString = "icno like '%" + mtxtIcno.Text + "%' and refno like '%" + refrenceNo + "%'";
                else if (string.IsNullOrEmpty(mtxtIcno.Text) && mtxtRefno.Text.Replace(" ", "").Length != 2)
                    searchString = "refno like '%" + refrenceNo + "%'";

                DataTable dt = new DataTable();
                dt = globalDataTable.Clone();
                DataRow[] drs = globalDataTable.Select(searchString, "id asc");
                foreach (var item in drs)
                {
                    dt.Rows.Add(item.ItemArray);
                }

                if (dt.Rows.Count > 0)
                    dataGridView1.DataSource = dt;
                else
                {
                    MessageBox.Show("No result found.");
                }
                labelLoading.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong in search, try again with different search term.");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            labelLoading.Text = "Generating pdf please wait...";
            labelLoading.Visible = true;
            MessageBox.Show("Generating PDF report, click OK to continue.");
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string file = dataGridView1.SelectedRows[0].Cells["icno"].Value + ".pdf";
                    try
                    {
                        // read parameters from the form
                        string htmlString = CommonHelper.GetReportHTML(dataGridView1.SelectedRows[0]);
                        string baseUrl = Directory.GetCurrentDirectory() + "\\LAPORAN";

                        string pdf_page_size = "A4";
                        PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                            pdf_page_size, true);

                        string pdf_orientation = "Portrait";
                        PdfPageOrientation pdfOrientation =
                            (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                            pdf_orientation, true);

                        int webPageWidth = 1024;
                        try
                        {
                            webPageWidth = 900;
                        }
                        catch { }

                        int webPageHeight = 0;
                        try
                        {
                            webPageHeight = 1024;
                        }
                        catch { }

                        // instantiate a html to pdf converter object
                        HtmlToPdf converter = new HtmlToPdf();

                        // set converter options
                        converter.Options.PdfPageSize = pageSize;
                        converter.Options.PdfPageOrientation = pdfOrientation;
                        converter.Options.WebPageWidth = webPageWidth;
                        converter.Options.WebPageHeight = webPageHeight;
                        int margin = 40;
                        converter.Options.MarginTop = margin;
                        converter.Options.MarginRight = margin;
                        converter.Options.MarginBottom = margin;
                        converter.Options.MarginLeft = margin;

                        // create a new pdf document converting an url
                        PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

                        // save pdf document
                        doc.Save(baseUrl + "\\" + file);

                        // close pdf document
                        doc.Close();
                        MessageBox.Show("Document generated successfully.");
                        try
                        {
                            string filePath = Directory.GetCurrentDirectory() + @"\LAPORAN\" + file;
                            System.Diagnostics.Process.Start(filePath);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in printing. Error:" + ex.Message);
                    }
                }
                else
                    MessageBox.Show("No row selected.");
            }
            catch (Exception ex)
            {
                labelLoading.Visible = false;
            }
            labelLoading.Visible = false;
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            labelLoading.Text = "Generating pdf please wait...";
            labelLoading.Visible = true;
            MessageBox.Show("Generating PDF report, click OK to continue.");
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string file = dataGridView1.SelectedRows[0].Cells["icno"].Value + ".pdf";
                    try
                    //{
                    //    // read parameters from the form
                    //    string htmlString = CommonHelper.GetReportHTML(dataGridView1.SelectedRows[0]);
                    //    string baseUrl = Directory.GetCurrentDirectory() + "\\LAPORAN";

                    //    string pdf_page_size = "A4";
                    //    PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                    //        pdf_page_size, true);

                    //    string pdf_orientation = "Portrait";
                    //    PdfPageOrientation pdfOrientation =
                    //        (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                    //        pdf_orientation, true);

                    //    int webPageWidth = 1024;
                    //    try
                    //    {
                    //        webPageWidth = 900;
                    //    }
                    //    catch { }

                    //    int webPageHeight = 0;
                    //    try
                    //    {
                    //        webPageHeight = 1024;
                    //    }
                    //    catch { }

                    //    // instantiate a html to pdf converter object
                    //    HtmlToPdf converter = new HtmlToPdf();

                    //    // set converter options
                    //    converter.Options.PdfPageSize = pageSize;
                    //    converter.Options.PdfPageOrientation = pdfOrientation;
                    //    converter.Options.WebPageWidth = webPageWidth;
                    //    converter.Options.WebPageHeight = webPageHeight;
                    //    int margin = 40;
                    //    converter.Options.MarginTop = margin;
                    //    converter.Options.MarginRight = margin;
                    //    converter.Options.MarginBottom = margin;
                    //    converter.Options.MarginLeft = margin;

                    //    // create a new pdf document converting an url
                    //    PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

                    //    // save pdf document
                    //    doc.Save(baseUrl + "\\" + file);

                    //    // close pdf document
                    //    doc.Close();
                    //    MessageBox.Show("Document generated successfully.");
                    //    try
                    //    {
                    //        string filePath = Directory.GetCurrentDirectory() + @"\LAPORAN\" + file;
                    //        System.Diagnostics.Process.Start(filePath);
                    //    }
                    //    catch (Exception ex)
                    //    {

                    //    }
                    //}
                    {
                        //CommonHelper.GetDataToPDF(dataGridView1.SelectedRows[0]);

                        //LocalReport localReport = new LocalReport();
                        //localReport.ReportPath = "Report.rdlc";
                        //string baseUrl = Directory.GetCurrentDirectory() + "\\LAPORAN";
                        //string FilePath = baseUrl + "\\" + file;

                        //CommonHelper.RenderReport(localReport, null, "PDF", filePath: FilePath, IsDownloadable: false);
                        //System.Diagnostics.Process.Start(FilePath);


                        // read parameters from the form
                        string htmlString = CommonHelper.GetDataToPDF(dataGridView1.SelectedRows[0]);
                        string baseUrl = Directory.GetCurrentDirectory() + "\\LAPORAN";

                        string pdf_page_size = "A4";
                        PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                            pdf_page_size, true);

                        string pdf_orientation = "Portrait";
                        PdfPageOrientation pdfOrientation =
                            (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                            pdf_orientation, true);

                        int webPageWidth = 1024;
                        try
                        {
                            webPageWidth = 900;
                        }
                        catch { }

                        int webPageHeight = 0;
                        try
                        {
                            webPageHeight = 1024;
                        }
                        catch { }

                        // instantiate a html to pdf converter object
                        HtmlToPdf converter = new HtmlToPdf();

                        // set converter options
                        converter.Options.PdfPageSize = pageSize;
                        converter.Options.PdfPageOrientation = pdfOrientation;
                        converter.Options.WebPageWidth = webPageWidth;
                        converter.Options.WebPageHeight = webPageHeight;
                        int margin = 40;
                        converter.Options.MarginTop = margin;
                        converter.Options.MarginRight = margin;
                        converter.Options.MarginBottom = margin;
                        converter.Options.MarginLeft = margin;

                        // create a new pdf document converting an url
                        PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

                        // save pdf document
                        doc.Save(baseUrl + "\\" + file);

                        // close pdf document
                        doc.Close();
                        MessageBox.Show("Document generated successfully.");
                        try
                        {
                            string filePath = Directory.GetCurrentDirectory() + @"\LAPORAN\" + file;
                            System.Diagnostics.Process.Start(filePath);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in printing. Error:" + ex.Message);
                    }
                }
                else
                    MessageBox.Show("No row selected.");
            }
            catch (Exception ex)
            {
                labelLoading.Visible = false;
            }
            labelLoading.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
