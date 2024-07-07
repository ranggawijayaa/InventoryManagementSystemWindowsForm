using InventoryManagementSystem.Domain;

namespace InventoryManagementSystem.WinForms
{
    public partial class AddProductForm : Form
    {
        private readonly IProductRepository _productRepository;

        public AddProductForm(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            InitializeComponent();
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
    }
}