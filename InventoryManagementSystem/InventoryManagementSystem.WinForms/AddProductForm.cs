using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interface;

namespace InventoryManagementSystem.WinForms
{
    public partial class AddProductForm : Form
    {
        private readonly IProductRepository _productRepository;

        public AddProductForm(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            InitializeComponent();
            txtQuantity.KeyPress += TxtQuantity_KeyPress;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var product = new Product()
            {
                Name = txtName.Text,
                Category = txtCategory.Text,
                Quantity = int.Parse(txtQuantity.Text)
            };

            await _productRepository.AddProductAsync(product);
            this.Close();
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}