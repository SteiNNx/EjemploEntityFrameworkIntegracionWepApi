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
    public partial class frmPrendas : Form
    {
        public frmPrendas()
        {
            InitializeComponent();
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
                comboBox1.Items.Clear();
                
                if (response.IsSuccessStatusCode)
                {
                    var categorias = response.Content.ReadAsAsync<IEnumerable<CATEGORIA>>().Result;
                    foreach (var item in categorias)
                    {
                        comboBox1.Items.Add(item.Descripcion);
                    }
                }

            }
            catch (ArgumentException exe)
            {

            }
            catch (Exception ex)
            {
                Log.Mensaje(ex.Message);
            }
        }
    }
}
