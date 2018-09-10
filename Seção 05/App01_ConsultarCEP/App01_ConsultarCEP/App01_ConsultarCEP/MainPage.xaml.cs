using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Lógica do programa

            
            string cep = CEP.Text.Trim();// trim remove os espaços

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0},{1} {2}, {3}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO","Cep Inexistente: " + cep, "OK");
                    }

                    

                }catch(Exception e)
                {
                    DisplayAlert("ERRO Critivo",e.Message, "OK");
                }
            }
                       
        }

        private bool isValidCEP( string cep)
        {
            bool valido = true;
            int novoCEP = 0;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP Invalido! CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            if (!int.TryParse(cep,out novoCEP))
            {
                DisplayAlert("Erro", "CEP Invalido! Apenas Numeros.", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
