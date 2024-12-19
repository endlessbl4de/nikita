namespace FurnitureApp
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView Products;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblUsers;

        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.Products = new System.Windows.Forms.DataGridView();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeight = 29;
            this.dgvOrders.Location = new System.Drawing.Point(20, 40);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.Size = new System.Drawing.Size(760, 150);
            this.dgvOrders.TabIndex = 0;
            // 
            // Products
            // 
            this.Products.ColumnHeadersHeight = 29;
            this.Products.Location = new System.Drawing.Point(20, 220);
            this.Products.Name = "Products";
            this.Products.RowHeadersWidth = 51;
            this.Products.Size = new System.Drawing.Size(760, 150);
            this.Products.TabIndex = 1;
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeight = 29;
            this.dgvUsers.Location = new System.Drawing.Point(20, 400);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.Size = new System.Drawing.Size(760, 150);
            this.dgvUsers.TabIndex = 2;
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Location = new System.Drawing.Point(800, 40);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(75, 23);
            this.btnEditOrder.TabIndex = 3;
            this.btnEditOrder.Text = "Edit Order";
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(800, 80);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOrder.TabIndex = 4;
            this.btnDeleteOrder.Text = "Delete Order";
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(800, 400);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(75, 23);
            this.btnEditUser.TabIndex = 5;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // lblOrders
            // 
            this.lblOrders.Location = new System.Drawing.Point(20, 20);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(100, 23);
            this.lblOrders.TabIndex = 6;
            this.lblOrders.Text = "Orders";
            // 
            // lblProducts
            // 
            this.lblProducts.Location = new System.Drawing.Point(20, 200);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(100, 23);
            this.lblProducts.TabIndex = 7;
            this.lblProducts.Text = "Products";
            // 
            // lblUsers
            // 
            this.lblUsers.Location = new System.Drawing.Point(20, 380);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(100, 23);
            this.lblUsers.TabIndex = 8;
            this.lblUsers.Text = "Users";
            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.Products);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnEditOrder);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lblUsers);
            this.Name = "AdminForm";
            this.Text = "Admin Form";
            this.Load += new System.EventHandler(this.AdminForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
