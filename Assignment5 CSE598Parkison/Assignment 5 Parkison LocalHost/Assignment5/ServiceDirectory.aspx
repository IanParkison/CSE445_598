<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceDirectory.aspx.cs" Inherits="Assignment5.ServiceDirectory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>		
		.table{
        border: solid 2px;
		margin-top: 50px;
        }
		.table-headers{
        font-weight: bold;
        font-family: Arial;
		font-size: 14pt;
        }
		.table-data{
        font-size: 12pt;
        font-family: Arial;
        text-align: center;
		width: auto;
        }		
		td, th {
			border: solid 1px;
			width: auto;
		}		
	</style>
	<table class="table">
		<tr class="table-headers">
			<th style="text-align: center">Provider Name</th>
			<th style="text-align: center">Service Name, Input & Output</th>
			<th style="text-align: center">Try It</th>
			<th style="text-align: center">Description</th>
		</tr>
		<tr class="table-data">
			<td>Ian Parkison/BING</td>
			<td>Web search: Input: String Output: String</td>
			<td><a runat="server" href="~/SearchTryIt">TRY IT</a></td>
			<td>RESTful search service powered by BING</td>
		</tr>
		<tr class="table-data">
			<td>Ian Parkison</td>
			<td>Encrypt/Decrypt: Input: String Output: String</td>
			<td><a runat="server" href="~/EncryptionTryIt">TRY IT</a></td>
			<td>Symmetric encryption service</td>
		</tr>
		<tr class="table-data">
			<td>ASU</td>
			<td>Image Verifier: Input: Integer Output: Image and String</td>
			<td><a runat="server" href="~/ImageVerifyTryIt">TRY IT</a></td>
			<td>Image verifier service</td>
		</tr>
	</table>
	<img style="margin:0px auto; display:block" src="Images/ServiceRepo.png" />
</asp:Content>
