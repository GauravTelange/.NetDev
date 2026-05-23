namespace FileSearchUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textdir = new TextBox();
            searchfile = new Button();
            List = new ListBox();
            SuspendLayout();
            // 
            // textdir
            // 
            textdir.Location = new Point(62, 39);
            textdir.Name = "textdir";
            textdir.Size = new Size(233, 31);
            textdir.TabIndex = 0;
            textdir.TextChanged += textBox1_TextChanged;
            // 
            // searchfile
            // 
            searchfile.AutoSize = true;
            searchfile.Location = new Point(322, 39);
            searchfile.Name = "searchfile";
            searchfile.Size = new Size(116, 35);
            searchfile.TabIndex = 1;
            searchfile.Text = "Search Now";
            searchfile.TextAlign = ContentAlignment.BottomLeft;
            searchfile.UseVisualStyleBackColor = true;
            searchfile.Click += searchfile_Click;
            // 
            // List
            // 
            List.FormattingEnabled = true;
            List.Location = new Point(12, 118);
            List.Name = "List";
            List.Size = new Size(727, 304);
            List.TabIndex = 2;
            List.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(List);
            Controls.Add(searchfile);
            Controls.Add(textdir);
            Name = "Form1";
            Text = "Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textdir;
        private Button searchfile;
        private ListBox List;
    }
}
