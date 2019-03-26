using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb.UI.Registros
{
    public partial class RegistroInversion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void LlenaCampos(EntradaInversion entrada)
        {
            EntradaInversionIDTextbox.Text = entrada.EntradaInversionID.ToString();
            MontoTexbox.Text = entrada.Monto.ToString();
        }
        private EntradaInversion Llenaclase()
        {
            EntradaInversion entradaInversion = new EntradaInversion();

            entradaInversion.EntradaInversionID = Convert.ToInt32(EntradaInversionIDTextbox.Text);
            entradaInversion.InversionID = 1;

            entradaInversion.Monto = Convert.ToDecimal(MontoTexbox.Text.ToString());

            return entradaInversion;
        }

        private void Limpiar()
        {
            EntradaInversionIDTextbox.Text = "0";
            MontoTexbox.Text = "0";

        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;


            EntradaInversion entrada = Llenaclase();

            if (Utilities.Utils.ToInt(EntradaInversionIDTextbox.Text) == 0)
            {
                paso = EntradaInversionBLL.Guardar(entrada);
            }
            else
            {
                int id = Convert.ToInt32(EntradaInversionIDTextbox.Text);
                var entry = EntradaInversionBLL.Buscar(id);

                if (entry != null)
                {
                    paso = EntradaInversionBLL.Editar(entrada);
                }
                else
                    Utilities.Utils.ShowToastr(this, "ID no existe", "Fallido", "error");
                Limpiar();
            }



            if (paso)
            {
                Utilities.Utils.ShowToastr(this, "Guardado", "exito", "exito");
                Limpiar();
            }
            else
            {
                Utilities.Utils.ShowToastr(this, "No se pudo Guardar", "Fallido", "error");
            }

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
             int id = Convert.ToInt32(EntradaInversionIDTextbox.Text);

                if (BLL.EntradaInversionBLL.Eliminar(id))
                {
                Utilities.Utils.ShowToastr(this, "eliminado", "exito", "exito");
                Limpiar();
                }
                else
                {
                Utilities.Utils.ShowToastr(this, "No se pudo eliminar", "Fallido", "error");
            }
                
            
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(EntradaInversionIDTextbox.Text);
            EntradaInversion entrada = BLL.EntradaInversionBLL.Buscar(id);

            if (entrada != null)
            {
                LlenaCampos(entrada);

            }
            else
            {
                Utilities.Utils.ShowToastr(this, "No se pudo Encontrar", "Fallido", "error");
            }
            
        }
    }
}