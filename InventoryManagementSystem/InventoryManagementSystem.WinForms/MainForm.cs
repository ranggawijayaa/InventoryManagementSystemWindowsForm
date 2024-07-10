using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Interface;
using System.Windows.Forms;

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

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Quantity"].Index)
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.KeyPress -= TextBox_KeyPress;
                    textBox.KeyPress += TextBox_KeyPress;
                }
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}