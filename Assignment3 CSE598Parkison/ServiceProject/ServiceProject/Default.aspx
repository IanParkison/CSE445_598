<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServiceProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
        <h1>Service Test Page</h1>
    	<div>
			<asp:Label ID="lblEndPoint" runat="server" Font-Italic="True" Font-Size="Large"></asp:Label>
		</div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Search for wsdl links(#9)</h2>
			<p>Searches for wsdl links and returns the url endpoints. Uses Bing Search API.<br>
				Operation: WsdlDiscovery()<br>
				Input: string<br>
				Output: string array
			</p>
			<div>
				<asp:TextBox ID="txtSearchBox" runat="server" Width="470px"></asp:TextBox>
				<asp:Button ID="btnSearch" runat="server" Height="26px" Text="Search" OnClick="btnSearch_Click" />
			</div>
			<asp:TextBox ID="txtResults" runat="server" Height="108px" TextMode="MultiLine" Width="283px"></asp:TextBox>         
        </div>
        <div class="col-md-4">
            <h2>Top 10 words(#1)</h2>
			<p>Searches a web url and returns the 10 most commonly used words with counts.<br>
				Operation: Top10Words()<br>
				Input: string<br>
				Output: string array
			</p>
            <div>
            	<asp:TextBox ID="txtUrl" runat="server" Width="481px"></asp:TextBox>
				<asp:Button ID="btnReturnWords" runat="server" Text="Submit" OnClick="btnReturnWords_Click" />
            </div>                         
            <asp:TextBox ID="txtWordResults" runat="server" Height="108px" TextMode="MultiLine" Width="283px"></asp:TextBox>            
        </div>
    </div>
</asp:Content>
