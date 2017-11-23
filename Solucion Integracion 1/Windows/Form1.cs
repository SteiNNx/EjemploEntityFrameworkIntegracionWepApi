using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
namespace Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:58410/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string servicio = "api/USUARIOS/"+txtUsuario.Text;
                HttpResponseMessage response = cliente.GetAsync(servicio).Result;
                if (response.IsSuccessStatusCode)
                {
                    var USUARIO= response.Content.ReadAsAsync<USUARIOS>().Result;
                    if (USUARIO.PASSWORD.Equals(txtPassword.Text))
                    {
                        MessageBox.Show("Correcto");
                        frmMenu menu = new frmMenu();
                        this.Hide();
                        menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Password Incorrecta");
                    }
                }
                else
                {
                    MessageBox.Show("NO EXISTE");
                }
            }
            catch (Exception ex)
            {

            }

            

        }
    }
}
