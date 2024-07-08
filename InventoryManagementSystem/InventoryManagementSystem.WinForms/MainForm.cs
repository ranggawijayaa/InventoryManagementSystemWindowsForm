using InventoryManagementSystem.Domain;

namespace InventoryManagementSystem.WinForms
{
    public partial class MainForm : Form
    {
        private readonly IProductRepository _productRepository;

        public MainForm(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadProductsAsync();
        }

        private async Task LoadProductsAsync()
        {
             var products = await _productRepository.GetAllProductAsync();
            dataGridView1.DataSource = products.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addProductForm = new AddProductForm(_productRepository);
            addProductForm.FormClosed += async (s, args) => await LoadProductsAsync();
            addProductForm.ShowDialog();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var selectedProduct = (Product)selectedRow.DataBoundItem;
                var result = MessageBox.Show("Are you sure want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes) 
                {
                    await _productRepository.DeleteProductAsync(selectedProduct.Id);
                    await LoadProductsAsync();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var selectedProduct = (Product)selectedRow.DataBoundItem;

                var updateProductForm = new UpdateProductForm(_productRepository, selectedProduct);
                updateProductForm.FormClosed += async (s, args) => await LoadProductsAsync();
                updateProductForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }
        }
    }
}