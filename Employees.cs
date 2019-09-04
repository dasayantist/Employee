using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee
{
    public class Employees
    {

        string strFilename;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public string Id { get; set; }
        public string Mid { get; set; }
        public long Salary { get; set; }

        public void TakeCSV(string id, string mid, long salary)
        {
            Id = id;
            Mid = mid;
            Salary = salary;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strFilename = openFileDialog1.FileName;
            }
            StreamReader sr = new StreamReader(strFilename);
            StringBuilder sb = new StringBuilder();
            DataTable dt = CreateTable();
            DataRow dr;
            string s;
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();

                string[] str = s.Split(',');

                dr = dt.NewRow();
                
                string str1 = str[0].ToString();
                if (!str1.Equals("Id"))
                {
                    dr["Id"] = str[0].ToString();
                    dr["Mid"] = str[1].ToString();
                    dr["Salary"] = str[2].ToString();
                    dt.Rows.Add(dr);
                }
            }
            // test with console
           // Console.Write(dt);

            // test with console
            //GridView1.DataSource = dt;
            //GridView1.DataBind();



        }

        protected DataTable CreateTable()
        {
            // Create a new DataTable.
            DataTable table = new DataTable("Employees");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            //DataRow row;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Id";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Mid";
            column.AutoIncrement = false;
            column.Caption = "Manager Id";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Create third column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.int32");
            column.ColumnName = "Salary";
            column.AutoIncrement = false;
            column.Caption = "Salary";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[0];
            PrimaryKeyColumns[0] = table.Columns["Id"];
            table.PrimaryKey = PrimaryKeyColumns;

            return table;
        }

        public long ReadData(string id, string strFilenames)
        {
            Id = id;
            strFilename = strFilenames;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strFilename = openFileDialog1.FileName;
            }
            StreamReader sr = new StreamReader(strFilename);
            StringBuilder sb = new StringBuilder();
            DataTable dt = CreateTable();
            DataRow dr;
            string s;
            string str1;
            string[] str;
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();

                str = s.Split(',');

                dr = dt.NewRow();
                //because the first line is header
                str1 = str[0].ToString();
                if (!str1.Equals(id))
                {
                    dr["Salary"] = str[2].ToString();
                    dt.Rows.Add(dr);
                }
            }

            return Convert.ToInt64(dt);
        }

    }
}
