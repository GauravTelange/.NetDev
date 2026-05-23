using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnViewSubmissions_Click(object sender, EventArgs e)
        {
            ViewSubmissionsForm viewForm = new ViewSubmissionsForm();
            viewForm.Show();
        }

        private void btnCreateSubmission_Click(object sender, EventArgs e)
        {
            CreateSubmissionForm createForm = new CreateSubmissionForm();
            createForm.Show();
        }
    }
}
