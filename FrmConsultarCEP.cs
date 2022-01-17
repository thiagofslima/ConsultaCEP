using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultaCEP
{
    public partial class FrmConsultarCEP : Form
    {
        public FrmConsultarCEP()
        {
            InitializeComponent();
        }

        private void btnConsultarCEP_Click(object sender, EventArgs e)
        {
            if(mtxCEP.MaskCompleted)
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var resultado = ws.consultaCEP(mtxCEP.Text);
                        txtLogradouro.Text = resultado.end;
                        txtBairro.Text = resultado.bairro;
                        txtCidade.Text = resultado.cidade;
                        txtEstado.Text = resultado.uf;

                    }
                    catch (System.ServiceModel.FaultException)
                    {

                        MessageBox.Show("CEP não encontrado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("CEP inválido!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
