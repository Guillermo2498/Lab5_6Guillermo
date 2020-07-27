using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Lab5_6
{
    public partial class gridAvan : System.Web.UI.Page
    {
        GestionBD objGestion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaCarroD();
            }

        }
        void mostrarMensaje(string txtMensaje, bool Tipo)
        {
            if (Tipo)
            {
                lblExito.Text = txtMensaje;
                lblError.Text = "";
            }
            else
            {
                lblExito.Text = "";
                lblError.Text = txtMensaje;
            }
        }
        void cargaCarroD()
        {
            DataTable datosPersonas = new DataTable();
            objGestion = new GestionBD();
            datosPersonas = objGestion.cargaCarrosD();

            if (datosPersonas.Rows.Count > 0)
            {
                gridCarroD.DataSource = datosPersonas;
                gridCarroD.DataBind();
            }
            else
            {
                datosPersonas.Rows.Add(datosPersonas.NewRow());
                gridCarroD.DataSource = datosPersonas;
                gridCarroD.DataBind();
                gridCarroD.Rows[0].Cells.Clear();
                gridCarroD.Rows[0].Cells.Add(new TableCell());
                gridCarroD.Rows[0].Cells[0].ColumnSpan = datosPersonas.Columns.Count;
                gridCarroD.Rows[0].Cells[0].Text = "No hay datos que mostrar.....";
                gridCarroD.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void gridCarroD_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                objGestion = new GestionBD();
                CarroD objCarro = new CarroD();
                
                objCarro.Marca = (gridCarroD.FooterRow.FindControl("txtMarCarroPie") as TextBox).Text.Trim();
                objCarro.Modelo = (gridCarroD.FooterRow.FindControl("txtModeloCarroPie") as TextBox).Text.Trim();
                objCarro.Pais = (gridCarroD.FooterRow.FindControl("txtPaisCarroPie") as TextBox).Text.Trim();
                objCarro.Costo = (gridCarroD.FooterRow.FindControl("txtCostoCarroPie") as TextBox).Text.Length;
                int resultado = objGestion.registrarCarro(objCarro);

                if (resultado == 1)
                {
                    cargaCarroD();
                    mostrarMensaje("Registro con exito", true);
                }
                else
                {
                    mostrarMensaje("Existe un error en el registro de la persona", false);

                }

            }
          


        } 
        protected void gridCarroD_RowEditing(object sender, GridViewEditEventArgs e)
            {
                gridCarroD.EditIndex = e.NewEditIndex;
                cargaCarroD();
            }
        protected void gridCarroD_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCarroD.EditIndex = -1;
            cargaCarroD();
        }
        protected void gridCarroD_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objGestion = new GestionBD();
            CarroD objCarroD = new CarroD();
            objCarroD.Marca = (gridCarroD.Rows[e.RowIndex].FindControl("txtMarCarro") as TextBox).Text.Trim();
            objCarroD.Modelo = (gridCarroD.Rows[e.RowIndex].FindControl("txtModeloCarro") as TextBox).Text.Trim();
            objCarroD.Pais = (gridCarroD.Rows[e.RowIndex].FindControl("txtPaisCarro") as TextBox).Text.Trim();
            objCarroD.Costo = Convert.ToInt32(gridCarroD.DataKeys[e.RowIndex].Value.ToString());
            objCarroD.IdCarro = Convert.ToInt32(gridCarroD.DataKeys[e.RowIndex].Value.ToString());
            int resultado = objGestion.actualizarCarro(objCarroD);
            gridCarroD.EditIndex = -1;


            if (resultado == 1)
            {
                cargaCarroD();
                mostrarMensaje("Actualización con exito", true);
            }
            else
            {
                mostrarMensaje("Existe un error en el registro de la persona", false);

            }


        }
        protected void gridCarroD_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objGestion = new GestionBD();
            CarroD objCarroD = new CarroD();
            objCarroD.IdCarro = Convert.ToInt32(gridCarroD.DataKeys[e.RowIndex].Value.ToString());
            objGestion.eliminarCarro(objCarroD);
            gridCarroD.EditIndex = -1;
            cargaCarroD();

            mostrarMensaje("Elimino con exito", true);
        }

    }
}