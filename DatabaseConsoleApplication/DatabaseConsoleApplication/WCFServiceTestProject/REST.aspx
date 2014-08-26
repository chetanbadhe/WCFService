<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="REST.aspx.cs" Inherits="WCFServiceTestProject.REST" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:TextBox ID="txtSearchBox" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" Height="24px" OnClick="btnSearch_Click" />
                <asp:Button ID="btnGetAllBooks" runat="server" Text="AllBooks" OnClick="btnGetAllBooks_Click" />
                <asp:Label ID="lblError" runat="server" Text="Enter Search Text" Font-Bold="true"
                    Visible="false" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtBox" runat="server" TextMode="MultiLine" Width="100%" Height="100%"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
