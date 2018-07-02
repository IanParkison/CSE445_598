<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EncryptionTryIt.aspx.cs" Inherits="Assignment5.EncryptionTryIt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<div style="height: 80px">
		<h1>Encryption</h1>
		<p>http://localhost:50913/Service1.svc?wsdl</p>
		</div>
	<div style="height: 50px" class="tryIt-text">
		<asp:TextBox ID="TextBox1" runat="server" Width="500px" ForeColor="Black"></asp:TextBox>
		Clear Text</div>
	<div style="height: 50px">
		<asp:Button ID="Button1" Text="Encrypt" runat="server" Width="100px" ForeColor="Black" OnClick="Button1_Click"></asp:Button>
		</div>
	<div style="height: 50px" class="tryIt-text">
		<table>
			<tr>
				<td style="vertical-align: middle">
					<asp:TextBox ID="TextBox2" runat="server" Width="700px" ForeColor="Black"></asp:TextBox>
				</td>
				<td style="vertical-align: middle">Cipher Text</td>				
			</tr>				
		</table>
	</div>
	<div style="height: 20px">
	</div>
	<div style="height: 50px" class="tryIt-text">
		<table>
			<tr>
				<td style="vertical-align: middle">
					<asp:TextBox ID="TextBox3" runat="server" Width="500px" ForeColor="Black"></asp:TextBox>
				</td>
					<td style="vertical-align: middle">Cipher Text To Decrypt</td>
				</tr>
		</table>
	</div>
	<div style="height: 50px">
		<asp:Button ID="Button2" runat="server" Text="Decrypt" ForeColor="Black" Width="100px" OnClick="Button2_Click"/>
	</div>
	<div style="height: 50px" class="tryIt-text">
		<asp:TextBox ID="TextBox4" runat="server" Width="500px" ForeColor="Black"></asp:TextBox>
		Clear Text</div>
</asp:Content>
