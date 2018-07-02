<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImageVerifyTryIt.aspx.cs" Inherits="Assignment5.ImageVerifyTryIt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div>
		<h1>Image Verification</h1>
		<p>http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifierSvc/Service.svc?wsdl</p>
	</div>
<div>
	<asp:Image ID="Image1" runat="server" />
	<asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox>
	<asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click"/>
	<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</div>
</asp:Content>
