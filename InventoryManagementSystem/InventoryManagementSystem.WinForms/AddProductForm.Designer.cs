namespace InventoryManagementSystem.WinForms
{
    partial class AddProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdd = new Button();
            txtName = new TextBox();
            txtCategory = new TextBox();
            txtQuantity = new TextBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(197, 90);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(260, 20);
            txtName.TabIndex = 0;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(12, 38);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(260, 20);
            txtCategory.TabIndex = 1;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(12, 64);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(260, 20);
            txtQuantity.TabIndex = 2;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 125);
            Controls.Add(txtQuantity);
            Controls.Add(txtCategory);
            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Name = "AddProductForm";
            Text = "AddProductForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private TextBox txtName;
        private TextBox txtCategory;
        private TextBox txtQuantity;
    }
}