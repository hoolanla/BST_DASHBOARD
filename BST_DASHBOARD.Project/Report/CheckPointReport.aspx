<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="CheckPointReport.aspx.cs" Inherits="BST_DASHBOARD.Project.Report.CheckPointReport" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div>
    
        <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="True" ToolPanelView="None"  Height="50px" ReportSourceID="CrystalReportSource1"  ToolPanelWidth="200px" Width="350px" />
        
    
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Report\Inside.rpt">
            </Report>
        </CR:CrystalReportSource>
        
    
    </div>
  


    </asp:Content>