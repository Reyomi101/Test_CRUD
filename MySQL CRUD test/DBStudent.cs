using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_CRUD_test
{
    class DbStudent
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=root;database=student";
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            return conn;
        }


        public static void AddStudent(Student std)
        {
            string sql = "Insert Into student_table Value (Null, @StudentName, @StudentReg, @StudentClass, @StudentSection, Null)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentReg", MySqlDbType.VarChar).Value = std.Reg;
            cmd.Parameters.Add("@StudentClass", MySqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StudentSection", MySqlDbType.VarChar).Value = std.Section;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added." , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Somethings Wrong! Unable to insert!  \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();

        }


        public static void UpdateStudent(Student std, string id)
        {
            string sql = "Update student_table Set Name=@StudentName, Reg=@StudentReg, Class=@StudentClass, Section=@StudentSection Where id=@Studentid";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Studentid", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentReg", MySqlDbType.VarChar).Value = std.Reg;
            cmd.Parameters.Add("@StudentClass", MySqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StudentSection", MySqlDbType.VarChar).Value = std.Section;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Somethings Wrong! Unable to Update!  \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();

        }

        public static void DeleteStudent(string id)
        {
            string sql = "Delete from student_table Where id = @Studentid";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Studentid", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Somethings Wrong! Unable to Delete!  \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            conn.Close();

        }
    }
}
