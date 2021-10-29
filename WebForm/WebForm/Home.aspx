<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebForm.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblCount" runat="server"></asp:Label>
    <br />
        <br />
    <br />
    <asp:Label ID="lblVstorCount" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnlogout" runat="server" OnClick="btnlogout_Click" Text="Logout" Width="94px" />
        <br />
</form>
</asp:Content>
