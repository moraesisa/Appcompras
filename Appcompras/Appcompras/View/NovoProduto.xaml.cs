using Appcompras.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appcompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoProduto : ContentPage
    {
        public NovoProduto()
        {
            InitializeComponent();
        }

        private async  void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto P = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                };

                App.Database.Insert(P);

                //Navigation.PushAsync(new NovoProduto());

            }
            catch (Exception ex)

            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}