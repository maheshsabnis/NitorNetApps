<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeptDataAccess.aspx.cs" Inherits="ASPNET_WebApp.DeptDataAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-bordered table-striped">
        <tbody>
        <tr>
            <td>DeptNo</td>
            <td>
                <asp:TextBox ID="txtdno" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="DeptNo is required"
                     ControlToValidate="txtdno"></asp:RequiredFieldValidator>
               </td>
        </tr>
         <tr>
            <td>DeptName</td>
            <td>
                <asp:TextBox ID="txtdname" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="DeptName is required"
                     ControlToValidate="txtdname"
                    ></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td>Capacity</td>
            <td>
                <asp:TextBox ID="txtcap" runat="server" class="form-control"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>Location</td>
            <td>
                <asp:TextBox ID="txtloc" runat="server" class="form-control"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td colspan="2">
                <asp:Button ID="btnNew" runat="server" Text="New" 
                     class="btn btn-warning"
                     OnClick="btnNew_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="Add" 
                    class="btn btn-primary"
                     OnClick="btnAdd_Click"/>
            </td>
            
        </tr>
            </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvDept" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AutoGenerateColumns="False" OnRowCancelingEdit="gvDept_RowCancelingEdit" OnRowEditing="gvDept_RowEditing" OnRowUpdated="gvDept_RowUpdated" OnRowUpdating="gvDept_RowUpdating" OnSelectedIndexChanged="gvDept_SelectedIndexChanged" OnSelectedIndexChanging="gvDept_SelectedIndexChanging" AllowPaging="True" PageSize="4">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <Columns>
                            <asp:BoundField DataField="DeptNo" HeaderText="DeptNo" ReadOnly="True" />
                            <asp:BoundField DataField="DeptName" HeaderText="DeptName" />
                            <asp:BoundField DataField="Capacity" HeaderText="Capacity" />
                            <asp:BoundField DataField="Location" HeaderText="Location" />
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                            <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                    </asp:GridView>
                </td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
        </tfoot>
    </table>

</asp:Content>
