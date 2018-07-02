<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Service Consumer Application</h1>
        <p class="lead">ASP.NET</p>
        
    </div>

	<table>
		<tr>
			<td>
				<asp:Button ID="btn1" runat="server" Text="Celcius To Fahrenheit" OnClick="btn1_Click" style="height:40px; font-size:large"/>
			</td>
			<td>

			</td>
			<td>
				<asp:TextBox ID="txt1" runat="server" style="height:40px"/>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="btn2" runat="server" Text="Fahrenheit To Celcius" OnClick="btn2_Click" style="height:40px; font-size:large"/>
			</td>
			<td>

			</td>
			<td>
				<asp:TextBox ID="txt2" runat="server" style="height:40px"/>
			</td>
		</tr>


	</table>



</asp:Content>
