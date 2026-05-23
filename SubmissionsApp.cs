using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SubmissionsApp
{
    public partial class ViewSubmissionsForm : Form
    {
        private List<string> submissions;
        private int currentIndex;

        public ViewSubmissionsForm()
        {
            InitializeComponent();
            LoadSubmissions();
            DisplaySubmission();
        }

        private void LoadSubmissions()
        {
            // Load submissions (example data)
            submissions = new List<string>
            {
                "Submission 1: Name, Email, Phone, GitHub",
                "Submission 2: Name, Email, Phone, GitHub"
            };
            currentIndex = 0;
        }

        private void DisplaySubmission()
        {
            if (submissions.Count > 0 && currentIndex >= 0 && currentIndex < submissions.Count)
            {
                txtSubmissionDetails.Text = submissions[currentIndex];
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplaySubmission();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < submissions.Count - 1)
            {
                currentIndex++;
                DisplaySubmission();
            }
        }
    }
}
