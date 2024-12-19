namespace FurnitureApp
{
    partial class EditOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSaveChanges;

        private void InitializeComponent()
        {
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblOrderID
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(20, 20);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(80, 20);
            this.lblOrderID.TabIndex = 0;

            // lblClientName
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(20, 50);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(120, 20);
            this.lblClientName.TabIndex = 1;

            // txtTotalPrice
            this.txtTotalPrice.Location = new System.Drawing.Point(20, 80);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(200, 22);
            this.txtTotalPrice.TabIndex = 2;

            // cmbStatus
            this.cmbStatus.Location = new System.Drawing.Point(20, 120);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 24);
            this.cmbStatus.TabIndex = 3;
            this.cmbStatus.Items.AddRange(new object[] { "Новый", "Обработан", "Завершён" });

            // btnSaveChanges
            this.btnSaveChanges.Location = new System.Drawing.Point(20, 160);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(120, 40);
            this.btnSaveChanges.TabIndex = 4;
            this.btnSaveChanges.Text = "Сохранить";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);

            // EditOrderForm
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSaveChanges);
            this.Name = "EditOrderForm";
            this.Text = "Редактирование заказа";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
