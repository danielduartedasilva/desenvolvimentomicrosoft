using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VendasWPF.DAL;
using VendasWPF.Models;

namespace VendasWPF.Views
{
    /// <summary>
    /// Interaction logic for frmCadastrarVenda.xaml
    /// </summary>
    public partial class frmCadastrarVenda : Window
    {
        private Venda venda = new Venda();
        private List<dynamic> itens = new List<dynamic>();
        private double total = 0;
        public frmCadastrarVenda()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar os dados de cliente
            cboClientes.ItemsSource = ClienteDAO.Listar(); //ItemsSource a lista que a gente passar ele preenche o combobox
            cboClientes.DisplayMemberPath = "Nome";
            cboClientes.SelectedValuePath = "Id";

            //Carregar os dados de vendedor
            cboVendedores.ItemsSource = VendedorDAO.Listar();
            cboVendedores.DisplayMemberPath = "Nome";
            cboVendedores.SelectedValuePath = "Id";

            //Carregar os dados de produto
            cboProdutos.ItemsSource = ProdutoDAO.Listar();
            cboProdutos.DisplayMemberPath = "Nome";
            cboProdutos.SelectedValuePath = "Id";
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int) cboProdutos.SelectedValue;
            Produto produto = ProdutoDAO.BuscarPorId(id);
            PopularItensVenda(produto);
            PopularDataGrid(produto);
            dtaProdutos.ItemsSource = itens;
            dtaProdutos.Items.Refresh();
            total += Convert.ToInt32(txtQuantidade.Text) * produto.Preco;
            lblTotal.Content = $"Total: {total:C2}";
        }
        private void PopularDataGrid(Produto produto)//tem haver com o tela
        {
            itens.Add(new
            {
                Nome = produto.Nome,
                Preco = produto.Preco.ToString("C2"),
                Quantidade = Convert.ToInt32(txtQuantidade.Text),
                Subtotal = (Convert.ToInt32(txtQuantidade.Text) * produto.Preco).ToString("C2")
            });
        }
        private void PopularItensVenda(Produto produto)// tem haver com o banco
        {
            venda.Itens.Add(
                new ItemVenda
                {
                    Produto = produto,
                    Preco = produto.Preco,
                    Quantidade = Convert.ToInt32(txtQuantidade.Text),
                }
             );
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            int idCliente = (int)cboClientes.SelectedValue;
            int idVendedor = (int)cboVendedores.SelectedValue;
            venda.Cliente = ClienteDAO.BuscarPorId(idCliente);
            venda.Vendedor = VendedorDAO.BuscarPorId(idVendedor);
            VendaDAO.Cadastrar(venda);
            MessageBox.Show("Venda cadastrada com sucesso !!!");
        }
    }
}
