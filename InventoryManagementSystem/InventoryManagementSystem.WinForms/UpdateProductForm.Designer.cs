namespace InventoryManagementSystem.WinForms
{
    partial class UpdateProductForm
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
            txtName = new TextBox();
            txtCategory = new TextBox();
            txtQuantity = new TextBox();
            btnUpdate = new Button();
            SuspendLayout();
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
            // btnUpdate
            // 
            btnUpdate.Location = new Point(197, 90);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // UpdateProductForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 125);
            Controls.Add(btnUpdate);
            Controls.Add(txtQuantity);
            Controls.Add(txtCategory);
            Controls.Add(txtName);
            Name = "UpdateProductForm";
            Text = "UpdateProductForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtCategory;
        private TextBox txtQuantity;
        private Button btnUpdate;
    }
}