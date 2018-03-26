<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Change_URL_without_page_load_Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <input id="customerName" name="customerName" type="text" />
        <input id="customerPhone" name="customerPhone" type="text" />
        <input value="Save" type="submit" />

        <asp:Button ID="btnSubmit" Text="ASP Submit" runat="server" OnClick="btnSubmit_Click" />
</asp:Content>

