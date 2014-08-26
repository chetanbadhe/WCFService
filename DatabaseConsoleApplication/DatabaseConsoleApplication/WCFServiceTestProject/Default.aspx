<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WCFServiceTestProject._Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>
        Welcome to ASP.NET!
    </h2>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Visible="false" Text="*"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" ForeColor="Red" Visible="false" Text="*"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Date Published"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDatePublished" runat="server"></asp:TextBox>
                <ajaxtoolkit:calendarextender runat="server" id="calExtender2" targetcontrolid="txtDatePublished" />
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" ForeColor="Red" Visible="false" Text="*"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Add REST" 
                    onclick="Button1_Click" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Add SOAP" 
                    onclick="Button2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
