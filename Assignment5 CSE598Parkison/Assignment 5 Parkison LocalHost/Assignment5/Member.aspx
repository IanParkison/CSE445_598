<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment5.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		.text {
			font-size: 14pt;
		}
	</style>
<div>
	<h1>Welcome Member!</h1>
	<br />
</div>
<div>
	<p class="text"><br/>With your subscription, you now have access to the services provided by API .NET.<br/><br />
		These services include:<br/><br />
		-A search engine powered by BING. This service uses a lightweight RESTful api that returns search results in JSON format.<br/><br />
		-An AES encryption service that uses strong 256 bit encryption. The clear text can only be retrieved from the cipher text with 
		the one time generated key<br /><br />
		-An image verification generator provided by Arizona State University. This service will generate an image and a random text <br/>
		string that can be used to verify that a password can only be entered by a human user.<br /><br />
	</p>
	<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</div>
<div>

</div>
</asp:Content>
