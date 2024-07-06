using InventoryManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem.WinForms
{
    public partial class UpdateProductForm : Form
    {
        private readonly IProductRepository _productRepository;
        private Product _product;

        public UpdateProductForm(IProductRepository productRepository, Product product)
        {
            _productRepository = productRepository;
            _product = product;
            InitializeComponent();
            PopulateFields();
        }

        private void PopulateFields()
        {
            txtName.Text = _product.Name;
            txtCategory.Text = _product.Category;
            txtQuantity.Text = _product.Quantity.ToString();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            _product.Name = txtName.Text;
            _product.Category = txtCategory.Text;
            _product.Quantity = int.Parse(txtQuantity.Text);

            await _productRepository.UpdateProductAsync(_product);
            this.Close();
        }
    }
}