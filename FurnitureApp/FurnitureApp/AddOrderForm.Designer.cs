namespace FurnitureApp
{
    partial class AddOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnSubmitOrder;

        private void InitializeComponent()
        {
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnSubmitOrder = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblProductName
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(20, 20);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(150, 20);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Название продукта:";

            // lblProductPrice
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Location = new System.Drawing.Point(20, 60);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(95, 20);
            this.lblProductPrice.TabIndex = 1;
            this.lblProductPrice.Text = "Цена за шт.:";

            // nudQuantity
            this.nudQuantity.Location = new System.Drawing.Point(20, 100);
            this.nudQuantity.Minimum = 1;
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 26);
            this.nudQuantity.TabIndex = 2;

            // btnSubmitOrder
            this.btnSubmitOrder.Location = new System.Drawing.Point(20, 140);
            this.btnSubmitOrder.Name = "btnSubmitOrder";
            this.btnSubmitOrder.Size = new System.Drawing.Size(120, 40);
            this.btnSubmitOrder.TabIndex = 3;
            this.btnSubmitOrder.Text = "Оформить заказ";
            this.btnSubmitOrder.UseVisualStyleBackColor = true;
            this.btnSubmitOrder.Click += new System.EventHandler(this.btnSubmitOrder_Click);

            // AddOrderForm
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.btnSubmitOrder);
            this.Name = "AddOrderForm";
            this.Text = "Оформление заказа";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
