<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QueryStringSender.aspx.cs" Inherits="ASPNET_WebApp.QueryStringSender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    First Name:<asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
    <br />
     Last Name:<asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnSend" runat="server" Text="Button" OnClick="btnSend_Click" />
    <hr />
    <asp:DropDownList ID="lstDepats" runat="server" AutoPostBack="true"
         OnSelectedIndexChanged="lstDepats_SelectedIndexChanged"></asp:DropDownList>

</asp:Content>
