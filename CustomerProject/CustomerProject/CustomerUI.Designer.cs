namespace CustomerProject
{
    partial class CustomerUI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblBillAmount = new System.Windows.Forms.Label();
            this.txtBillAmount = new System.Windows.Forms.TextBox();
            this.Customerid = new System.Windows.Forms.Label();
            this.txtCustomerid = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();

            // lblCustomerName
            this.lblCustomerName.Text = "Customer Name";
            this.lblCustomerName.Location = new System.Drawing.Point(20, 20);
            this.lblCustomerName.Size = new System.Drawing.Size(100, 20);

            // txtCustomerName
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Location = new System.Drawing.Point(130, 17);
            this.txtCustomerName.Size = new System.Drawing.Size(150, 20);

            // lblPhoneNumber
            this.lblPhoneNumber.Text = "Phone Number";
            this.lblPhoneNumber.Location = new System.Drawing.Point(20, 55);
            this.lblPhoneNumber.Size = new System.Drawing.Size(100, 20);

            // txtPhoneNumber
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Location = new System.Drawing.Point(130, 52);
            this.txtPhoneNumber.Size = new System.Drawing.Size(150, 20);

            // lblProduct
            this.lblProduct.Text = "Product Name";
            this.lblProduct.Location = new System.Drawing.Point(20, 90);
            this.lblProduct.Size = new System.Drawing.Size(100, 20);

            // txtProduct
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Location = new System.Drawing.Point(130, 87);
            this.txtProduct.Size = new System.Drawing.Size(150, 20);

            // lblBillAmount
            this.lblBillAmount.Text = "Bill Amount";
            this.lblBillAmount.Location = new System.Drawing.Point(20, 125);
            this.lblBillAmount.Size = new System.Drawing.Size(100, 20);

            // txtBillAmount
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.Location = new System.Drawing.Point(130, 122);
            this.txtBillAmount.Size = new System.Drawing.Size(150, 20);

            // Customerid label
            this.Customerid.Text = "Customer ID";
            this.Customerid.Location = new System.Drawing.Point(20, 160);
            this.Customerid.Size = new System.Drawing.Size(100, 20);

            // txtCustomerid
            this.txtCustomerid.Name = "txtCustomerid";
            this.txtCustomerid.Location = new System.Drawing.Point(130, 157);
            this.txtCustomerid.Size = new System.Drawing.Size(150, 20);
            this.txtCustomerid.ReadOnly = true;

            // button1 - Add
            this.button1.Name = "button1";
            this.button1.Text = "Add";
            this.button1.Location = new System.Drawing.Point(310, 17);
            this.button1.Size = new System.Drawing.Size(80, 25);
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // btnUpdate
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Location = new System.Drawing.Point(310, 52);
            this.btnUpdate.Size = new System.Drawing.Size(80, 25);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(310, 87);
            this.btnDelete.Size = new System.Drawing.Size(80, 25);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // dataGridView1
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Location = new System.Drawing.Point(20, 200);
            this.dataGridView1.Size = new System.Drawing.Size(740, 200);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Name = "CustomerUI";
            this.Text = "Customer Management";
            this.Load += new System.EventHandler(this.CustomerUI_Load_1);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.lblBillAmount);
            this.Controls.Add(this.txtBillAmount);
            this.Controls.Add(this.Customerid);
            this.Controls.Add(this.txtCustomerid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtBillAmount;
        private System.Windows.Forms.Label lblBillAmount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCustomerid;
        private System.Windows.Forms.Label Customerid;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}