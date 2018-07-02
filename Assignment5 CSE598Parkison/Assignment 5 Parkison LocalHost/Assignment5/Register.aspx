<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Assignment5.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script>
		function duplicateAccount() {
			alert("This email account already exists.");
		}
		function failed() {
			alert("Image verification failed. Please try again.");
		}
		//validate form is filled out correctly
		function validateFields() {
			var name = document.getElementById('<%= TextBox1.ClientID%>');
			var email = document.getElementById('<%= TextBox5.ClientID%>');
			var password1 = document.getElementById('<%= TextBox6.ClientID%>');
			var password2 = document.getElementById('<%= TextBox3.ClientID%>');
			var card = document.getElementById('<%= TextBox7.ClientID%>');
			name.style.backgroundColor = ""
			email.style.backgroundColor = ""
			password1.style.backgroundColor = ""
			password2.style.backgroundColor = ""
			card.style.backgroundColor = ""

			if (name.value.trim() == "") {
				name.focus();
				name.style.backgroundColor = "#ff0000"
				return false;
			}
			if (email.value.trim() == "") {
				email.focus();
				email.style.backgroundColor = "#ff0000"
				return false;
			}
			if (password1.value.trim() == "") {	
				password1.focus();
				password1.style.backgroundColor = "#ff0000"
				return false;
			}
			if (password2.value.trim() == "") {	
				password2.focus();
				password2.style.backgroundColor = "#ff0000"
				return false;
			}
			if (card.value.trim() == "") {	
				card.focus();
				card.style.backgroundColor = "#ff0000"
				return false;
			}
			if (password1.value != password2.value) {
				password1.style.backgroundColor = "#ff0000"
				password2.style.backgroundColor = "#ff0000"
				return false;
			}
		}
</script>

<style>
	.textbox {
		color: black;
	}
</style>
<div style="height: 50px">

</div>
<div style="height: 50px">
	<asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox>
	<asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
</div>
<div style="height: 50px">
	<asp:TextBox ID="TextBox5" runat="server" CssClass="textbox"></asp:TextBox>
	<asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
</div>
<div style="height: 50px">
	<asp:TextBox ID="TextBox6" runat="server" CssClass="textbox"></asp:TextBox>
	<asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
</div>
<div style="height: 50px">
	<asp:TextBox ID="TextBox3" runat="server" CssClass="textbox"></asp:TextBox>
	<asp:Label ID="Label3" runat="server" Text="Re-Enter Password"></asp:Label>
</div>
<div style="height: 50px">
	<asp:TextBox ID="TextBox7" runat="server" CssClass="textbox"></asp:TextBox>
	<asp:Label ID="Label6" runat="server" Text="Credit Card Number"></asp:Label>
</div>
<div style="height: 50px">
	<asp:Image ID="Image1" runat="server" />
	<asp:TextBox ID="TextBox4" runat="server" CssClass="textbox"></asp:TextBox>
	<asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" OnClientClick="return validateFields()"/>
</div>
</asp:Content>
