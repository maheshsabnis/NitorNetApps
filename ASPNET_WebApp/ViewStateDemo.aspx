<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStateDemo.aspx.cs" Inherits="ASPNET_WebApp.ViewStateDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <table>
        <tr>
            <td colspan="2">
                 Enter Name
    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnset" runat="server" Text="Set Value" 
                     OnClick="btnset_Click"/>
            </td>
            <td>
                <asp:Button ID="btnget" runat="server" Text="Get Value" 
                     OnClick="btnget_Click"/>
            </td>
        </tr>
    </table>

</asp:Content>
