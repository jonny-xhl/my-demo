using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jonny.AllDemo.SQLiteFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnInitBusiness.Click += InitBusiness;
        }
        private readonly static object _lock = new object();
        private void InitBusiness(object sender, EventArgs e)
        {
            SQLiteConnection conn = null;
            string dbPath = System.Configuration.ConfigurationManager.AppSettings["connStr1"];
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
            SQLiteCommand command = new SQLiteCommand(conn);
            string exists1 = "select count(1) from Business where Name=@name";
            command.CommandText = exists1;
            command.Parameters.Add(new SQLiteParameter("@name", "方案定制-健康体检"));
            if (command.ExecuteScalar().ToString() == "0")
            {
                command.CommandText = "INSERT INTO Business(Name,Num,ZhuYi) VALUES('方案定制-健康体检','A','无')";//插入几条数据  
                command.ExecuteNonQuery();
            }
            command.Parameters.Clear();
            command.CommandText = exists1;
            command.Parameters.Add(new SQLiteParameter("@name", "方案定制-职工体检"));
            if (command.ExecuteScalar().ToString() == "0")
            {
                command.CommandText = "INSERT INTO Business(Name,Num,ZhuYi) VALUES('方案定制-职工体检','B','无')";
                command.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("初始化成功");
        }

        private void InitBusinessToMssql(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            string dbPath = System.Configuration.ConfigurationManager.AppSettings["connStr1"];
            conn = new SqlConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
            var command = new SqlCommand();
            command.Connection = conn;
            string exists1 = "select count(1) from Business where Name=@name";
            command.CommandText = exists1;
            command.Parameters.Add(new SqlParameter("@name", "方案定制-健康体检"));
            if (command.ExecuteScalar().ToString() == "0")
            {
                command.CommandText = "INSERT INTO Business VALUES('方案定制-健康体检','A','无')";//插入几条数据  
                command.ExecuteNonQuery();
            }
            command.Parameters.Clear();
            command.CommandText = exists1;
            command.Parameters.Add(new SqlParameter("@name", "方案定制-职工体检"));
            if (command.ExecuteScalar().ToString() == "0")
            {
                command.CommandText = "INSERT INTO Business VALUES('方案定制-职工体检','B','无')";
                command.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("初始化成功");
        }

        private void Ticket(int bid, string bname, string businessNum)
        {
            SQLiteConnection conn = null;
            string dbPath = System.Configuration.ConfigurationManager.AppSettings["connStr1"];
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
            SQLiteCommand command = new SQLiteCommand(conn);
            // 下一位序列
            string next = "select ifnull(max(Seq),0)+1 as \"NextSeq\" from Note where BusinessId=@businessId";
            command.CommandText = next;
            command.Parameters.Add(new SQLiteParameter("@businessId", bid));
            var seq = int.Parse(command.ExecuteScalar().ToString());

            // 等候人数
            var waitCountSql = "select count(1) as \"WaitCount\" from Note where BusinessId=@businessId and Status=1 and Seq<@seq";
            command.CommandText = waitCountSql;
            command.Parameters.Clear();
            command.Parameters.Add(new SQLiteParameter("@businessId", bid));
            command.Parameters.Add(new SQLiteParameter("@seq", seq));
            var waitCount = int.Parse(command.ExecuteScalar().ToString());

            // 受理窗口
            var windowsSql = @"select GROUP_CONCAT(Name) as WinNames
                 from BusinessWindow w
                 where w.Id in (select bw.WindowId FROM BusinessOfWindow bw where bw.BusinessId = @businessId)";
            command.CommandText = windowsSql;
            command.Parameters.Clear();
            command.Parameters.Add(new SQLiteParameter("@businessId", bid));
            var windows = command.ExecuteScalar().ToString();

            // 存储票号
            command.CommandText = @"INSERT INTO Note
                VALUES (NULL, @businessId,
                @businessName,
                @windows,
                @seq,
                1)";//插入几条数据  
            command.Parameters.Clear();
            command.Parameters.AddRange(new[]{
                new SQLiteParameter("@businessId",bid),
                new SQLiteParameter("@businessName",bname),
                new SQLiteParameter("@windows",windows),
                new SQLiteParameter("@seq",seq)
            });
            command.ExecuteNonQuery();
            //出票
            Ticketing(new NoteDto(businessNum + seq.ToString().PadLeft(3, '0'), bname, windows, waitCount));
        }

        /// <summary>
        /// 出票，打印
        /// </summary>
        private void Ticketing(NoteDto note)
        {
            this.Invoke(new Action(() =>
            {
                lbl票号.Text = note.Seq;
                lbl等候人数.Text = "" + note.WaitCount;
                lbl业务.Text = note.BusinessName;
                lbl受理窗口.Text = note.WindowsNames;
            }));
            Print(note);
        }

        private void btn健康体检_Click(object sender, EventArgs e)
        {
            // 后期自动查询
            var businessId = 6;
            var businessNum = "A";
            var name = "方案定制-健康体检";
            Ticket(businessId, name, businessNum);
        }

        private void btn团检_Click(object sender, EventArgs e)
        {
            var businessId = 7;
            var businessNum = "B";
            var name = "方案定制-职工体检";
            Ticket(businessId, name, businessNum);
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="templateFileName">模板文件名称</param>
        /// <param name="printer">打印机名称</param>
        private bool Print(NoteDto note, string templateFileName = @"E:\studyspace\all demo\Jonny.AllDemo\src\sqlite\Jonny.AllDemo.SQLiteFirst\frxs\test.frx", string printer = "Microsoft Print to PDF")
        {
            lock (_lock)
            {
                try
                {
                    using (Report report = new Report())
                    {
                        report.Load(templateFileName);
                        DataSet ds = new DataSet();
                        var dt = new DataTable("Note");
                        dt.Columns.Add(new DataColumn("Seq", typeof(String)));
                        dt.Columns.Add(new DataColumn("WaitCount", typeof(Int32)));
                        dt.Columns.Add(new DataColumn("BusinessName", typeof(String)));
                        dt.Columns.Add(new DataColumn("WindowsNames", typeof(String)));
                        dt.Rows.Add(note.Seq, note.WaitCount, note.BusinessName, note.WindowsNames);

                        ds.Tables.Add(dt);

                        report.RegisterData(ds);

                        // 集合
                        //var dataSet = new List<NoteDto>();
                        //dataSet.Add(note);
                        //report.RegisterData(dataSet, "Note");
                        report.PrintSettings.Printer = printer;
                        //report.PrintSettings.ShowDialog = true;
                        report.Print();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

        }
    }
}
