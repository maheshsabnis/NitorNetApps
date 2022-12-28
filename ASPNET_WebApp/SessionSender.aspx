<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SessionSender.aspx.cs" Inherits="ASPNET_WebApp.SessionSender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Select Department: <asp:DropDownList ID="lstDepts" runat="server" AutoPostBack="true"
          OnSelectedIndexChanged="lstDepts_SelectedIndexChanged"></asp:DropDownList>

    <hr />
    <asp:Label ID="lblSessionInfo" runat="server" Text="Label"></asp:Label>

</asp:Content>
