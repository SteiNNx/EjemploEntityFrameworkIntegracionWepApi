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
    public partial class frmAgregarCategoria : Form
    {
        public frmAgregarCategoria()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:58410/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string servicio = "api/CATEGORIAs";
                var categoria = new CATEGORIA()
                {
                    Id = 9,
                    Descripcion = txtCategoria.Text
                };

                HttpResponseMessage response = cliente.PostAsJsonAsync(servicio, categoria).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("almacenado");
                }
                else
                {
                    MessageBox.Show("no almaceno");
                }

            }
            catch (ArgumentException exe)
            {
                tssMensaje.Text = exe.Message;
            }
            catch (Exception ex)
            {
                Log.Mensaje(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:58410/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string servicio = "api/CATEGORIAS";


                HttpResponseMessage response = cliente.GetAsync(servicio).Result;
                if (response.IsSuccessStatusCode)
                {
                    var categorias = response.Content.ReadAsAsync<IEnumerable<CATEGORIA>>().Result;
                    foreach (var item in categorias)
                    {
                        MessageBox.Show(item.Descripcion);
                    }
                }

            }
            catch (Exception EX)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:58410/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string servicio = "api/CATEGORIAS/1";


                HttpResponseMessage response = cliente.GetAsync(servicio).Result;
                if (response.IsSuccessStatusCode)
                {
                    var categoria = response.Content.ReadAsAsync<CATEGORIA>().Result;
                    categoria.Descripcion = "PELUCHE";
                    response = cliente.PutAsJsonAsync(servicio, categoria).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("actualizo");
                    }
                    else
                    {
                        MessageBox.Show("no actualizo");
                    }

                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:58410/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string servicio = "api/TALLAS";
                var categoria = new TALLA()
                {
                    Id = 9,
                    Talla1="xSS"
                };

                HttpResponseMessage response = cliente.PostAsJsonAsync(servicio, categoria).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("almacenado");
                }
                else
                {
                    MessageBox.Show("no almaceno");
                }

            }
            catch (ArgumentException exe)
            {
                tssMensaje.Text = exe.Message;
            }
            catch (Exception ex)
            {
                Log.Mensaje(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:58410/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string servicio = "api/CATEGORIAS/9";

                HttpResponseMessage response = cliente.DeleteAsync(servicio).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("ELIMINO");
                }
                else
                {
                    MessageBox.Show("no ELIMINO");
                }

            }
            catch (ArgumentException exe)
            {
                tssMensaje.Text = exe.Message;
            }
            catch (Exception ex)
            {
                Log.Mensaje(ex.Message);
            }
        }
    }
}
