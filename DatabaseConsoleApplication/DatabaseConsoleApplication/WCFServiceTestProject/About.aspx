<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WCFServiceTestProject.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
    <p>
        The WCF web service should expose SOAP and REST(JSON) endpoints that allow me to
        query for an addon by ID or Name, and should display all 4 fields. REST webpage
        uses the REST endpoint to reply with valid JSON. SOAP webpage uses the SOAP endpoint
        of WCF Service. The WCF service also expose SOAP and REST endpoints that allow me
        to insert a new addon by supplying the Name, Description, and DatePublished to the
        method in Default webpage. The internal cache updates every 5 minutes, so records
        that I insert should get populated into the cache, based on that time interval,
        and then be selectable once they are in the cache.
    </p>
</asp:Content>
