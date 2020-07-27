<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gridAvan.aspx.cs" Inherits="Lab5_6.gridAvan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
        <asp:GridView ID="gridCarroD" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"
              AutoGenerateColumns="false"
                DataKeyNames = "IdCarro"
                OnRowCommand ="gridCarroD_RowCommand"
                OnRowEditing ="gridCarroD_RowEditing"
                OnRowCancelingEdit = "gridCarroD_RowCancelingEdit"
                OnRowUpdating = "gridCarroD_RowUpdating"
                OnRowDeleting ="gridCarroD_RowDeleting"
                ShowHeaderWhenEmpty ="false"
                ShowFooter ="true">

            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />

             <Columns>
                    
                     <asp:TemplateField HeaderText="Marca">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("MarcaCarro")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMarCarro" Text='<%# Eval("MarcaCarro")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtMarCarroPie" Text='<%# Eval("MarcaCarro")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Modelo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ModeloCarro")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtModeloCarro" Text='<%# Eval("ModeloCarro")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtModeloCarroPie" Text='<%# Eval("ModeloCarro")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Pais">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("PaisCarro")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPaisCarro" Text='<%# Eval("PaisCarro")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPaisCarroPie" Text='<%# Eval("PaisCarro")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>

                    </asp:TemplateField>
                 <asp:TemplateField HeaderText="Costo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("CostoCarro")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCostoCarro" Text='<%# Eval("CostoCarro")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCostoCarroPie" Text='<%# Eval("CostoCarro")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                           <asp:ImageButton ImageUrl="~/Imagen/editar.png" runat="server" CommandName="Edit" ToolTip="Editar" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Imagen/delete2.png" runat="server" CommandName="Delete" ToolTip="Borrar" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Imagen/guardar.png" runat="server" CommandName="Update" ToolTip="Guardar" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Imagen/cancel2.png"   runat="server" CommandName="Delete" ToolTip="Cancelar" Width="20px" Height="20px" />                           
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Imagen/nuevo.png"   runat="server" CommandName="AddNew" ToolTip="Nuevo" Width="20px" Height="20px" />                           
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>

        </asp:GridView>


            <asp:Label runat="server" ID="lblExito" ForeColor="Green"></asp:Label>
            <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
