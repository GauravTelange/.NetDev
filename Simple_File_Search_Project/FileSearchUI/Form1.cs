namespace FileSearchUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void searchfile_Click(object sender, EventArgs e)
        {
            List.Items.Clear();

            if (string.IsNullOrEmpty(textdir.Text))
            {
                MessageBox.Show("Please enter a directory path.");
                return;
            }

            FileSearch.File fileobj = new FileSearch.File();
            fileobj.sendFileName += Fileobj_sendFileName;
            Thread thread = new Thread(() => fileobj.Search(textdir.Text));
            thread.Start();
        }

        private void Fileobj_sendFileName(string file)
        {
            Invoke(() => List.Items.Add(file));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}