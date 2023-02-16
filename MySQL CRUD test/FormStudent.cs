using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_CRUD_test
{
    public partial class FormStudent : Form
    {
        private readonly FormStudentInfo _parent;
        public string id, name, reg, @class, section;

        public FormStudent(FormStudentInfo parent)
        {
            InitializeComponent();
            _parent = parent;
        }


        public void UpdateInfo()
        {
            lbltext.Text = "Update Student";
            btnSave.Text = "Update";
            txtName.Text = name;
            txtReg.Text = reg;
            txtClass.Text = @class;
            txtSec.Text = section;
        }

        public void SaveInfo()
        {
            lbltext.Text = "Add Student";
            btnSave.Text = "Save";
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            txtName.Text = txtReg.Text = txtClass.Text = txtSec.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student Name is Empty ( > 3).");
                return;
            }
            if (txtReg.Text.Trim().Length < 1)
            {
                MessageBox.Show("Student Reg is Empty ( > 1).");
                return;
            }
            if (txtClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student Class is Empty ( > 1).");
                return;
            }
            if (txtSec.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student Section is Empty ( > 1).");
                return;
            }
            if (btnSave.Text == "Save")
            {
                Student std = new Student(txtName.Text.Trim(), txtReg.Text.Trim(), txtClass.Text.Trim(), txtSec.Text.Trim());
                DbStudent.AddStudent(std);
                Clear();
            }
            if(btnSave.Text == "Update")
            {
                Student std = new Student(txtName.Text.Trim(), txtReg.Text.Trim(), txtClass.Text.Trim(), txtSec.Text.Trim());
                DbStudent.UpdateStudent(std, id);
            }
            _parent.Display();


        }
    }
}
