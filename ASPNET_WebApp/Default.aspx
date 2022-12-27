<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPNET_WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    First Name :<asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
    <br />
    Last Name: <asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnDisplay" runat="server" Text="Dispay" OnClick="btnDisplay_Click" />
    <hr />
    <asp:Label ID="lblName" runat="server" ></asp:Label>
    <hr />
    <asp:DropDownList ID="lstNames" runat="server"
         OnSelectedIndexChanged="lstNames_SelectedIndexChanged" AutoPostBack="True">

    </asp:DropDownList>
    <hr />
    <asp:Label ID="lblselectedname" runat="server"
         ></asp:Label>
</asp:Content>
