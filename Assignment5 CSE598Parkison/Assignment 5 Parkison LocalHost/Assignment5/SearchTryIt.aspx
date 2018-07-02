<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchTryIt.aspx.cs" Inherits="Assignment5.SearchTryIt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div style="height: 80px">
		<h1>Bing Search</h1>
		<p>http://localhost:51195/Service1.svc/search?query=</p>
		</div>
	<div style="height: 50px">
		<asp:TextBox ID="TextBox1" runat="server" Width="500px" ForeColor="Black"></asp:TextBox>
		Query</div>
	<div style="height: 50px">
		<asp:Button ID="Button1" Text="Search" runat="server" Width="100px" ForeColor="Black" OnClick="Button1_Click"></asp:Button>
		</div>
	<div style="height: auto">
		Results
		<asp:Table ID="Table1" runat="server" Borderstyle="Solid" GridLines="Both" ></asp:Table>
		</div>
</asp:Content>
