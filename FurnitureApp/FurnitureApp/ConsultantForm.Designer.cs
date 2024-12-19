namespace FurnitureApp
{
    partial class ConsultantForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.Button btnDeleteOrder;

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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(20, 20);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.Size = new System.Drawing.Size(760, 300);
            this.dgvOrders.TabIndex = 0;
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Location = new System.Drawing.Point(20, 340);
            this.btnEditOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(120, 47);
            this.btnEditOrder.TabIndex = 1;
            this.btnEditOrder.Text = "Редактировать заказ";
            this.btnEditOrder.UseVisualStyleBackColor = true;
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(160, 340);
            this.btnDeleteOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(133, 39);
            this.btnDeleteOrder.TabIndex = 2;
            this.btnDeleteOrder.Text = "Удалить заказ";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // ConsultantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnEditOrder);
            this.Controls.Add(this.btnDeleteOrder);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConsultantForm";
            this.Text = "Панель консультанта";
            this.Load += new System.EventHandler(this.ConsultantForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
