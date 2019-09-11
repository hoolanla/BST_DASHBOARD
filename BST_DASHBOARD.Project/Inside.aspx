<%@ Page   EnableEventValidation="false" Title=""  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inside.aspx.cs" Inherits="BST_DASHBOARD.Project.Inside" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




<div class="container">

        <div class="row">
           <div class='col-sm-4'></div>
                  <div class='col-sm-4'>
                      <H3>INSIDE REPORT</H3>
                

                  </div>
                  <div class='col-sm-4'></div>

    </div>

    <br />
    <br />




          <div class="row">

               <div class='col-sm-2'>
            <div class="form-group">
            &nbsp
            </div>
          </div>


               <div class='col-sm-1'>
            <div class="form-group">
            From
            </div>
        </div>

        <div class='col-sm-2'>
      
      <div class="form-group">
                <telerik:RadDateTimePicker ID="RadDateTimePicker1" runat="server" AllowPaging="True" AllowFilteringByColumn="False" AllowSorting="True" DateInput-DisplayDateFormat="dd/MM/yyyy HH:mm" TimeView-Interval="00:10:00"></telerik:RadDateTimePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="RadDateTimePicker1" 
                    runat="server" ErrorMessage="โปรดกรอกข้อมูล"></asp:RequiredFieldValidator>
            </div>
        
       
            </div>
     

              
               <div class='col-sm-1'>
            <div class="form-group">
            To
            </div>
        </div>

        <div class='col-sm-2'>
            <div class="form-group">
             
                    <div class="form-group">
                <telerik:RadDateTimePicker ID="RadDateTimePicker2" runat="server" AllowPaging="True" AllowFilteringByColumn="False" AllowSorting="True" DateInput-DisplayDateFormat="dd/MM/yyyy HH:mm" TimeView-Interval="00:10:00"></telerik:RadDateTimePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="RadDateTimePicker2" 
                    runat="server" ErrorMessage="โปรดกรอกข้อมูล"></asp:RequiredFieldValidator>
            </div>
                
                
              <asp:CompareValidator ID="CompareValidator1" Operator="GreaterThan" ControlToValidate="RadDateTimePicker2" ControlToCompare="RadDatetimePicker1" ErrorMessage="EndDate ต้องมากกว่า StartDate" ForeColor="Red" runat="server"></asp:CompareValidator>
            </div>
        </div>
                          <div class='col-sm-1'>
            <div class="form-group">
                <asp:LinkButton runat="server" ID="LinkButton1"
            CssClass="btn btn-success btn-sm" 
            OnClick="SubmitLinkButton_Click">
            SEARCH
        </asp:LinkButton>


            </div>
            </div>
          <div class='col-sm-3'>
            <div class="form-group">
            &nbsp
            </div>
          </div>



    </div>


    <div class="row">
           <div class='col-sm-1'></div>
                  <div class='col-sm-10'>

                      <telerik:RadAjaxManager ID="RadAjaxMgr" runat="server">
     <AjaxSettings>
          <telerik:AjaxSetting AjaxControlID="radgrid1">
               <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radgrid1" />
               </UpdatedControls>
          </telerik:AjaxSetting>
     </AjaxSettings>
</telerik:RadAjaxManager>


                      <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AllowFilteringByColumn="False" AllowSorting="True" PageSize="25">

                                       <MasterTableView AutoGenerateColumns="False" TableLayout="Fixed">
                     <PagerStyle PageSizes="25,50,100" PagerTextFormat="{4}<strong>{5}</strong> Personal matching your search criteria"
                            PageSizeLabelText="Personal access per page:" />

                 <Columns>
                     <telerik:GridTemplateColumn HeaderText="#" UniqueName="RowNumber" >
                          <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblRowNumber" Width="10%" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                             <telerik:GridBoundColumn DataField="firstName" HeaderText="ชื่อ" UniqueName="firstname">
           
                                <HeaderStyle Width="20%" />
                            </telerik:GridBoundColumn>

                

                       

                        <telerik:GridBoundColumn DataField="company" HeaderText="บริษัท" UniqueName="company"
                         >
                                <HeaderStyle Width="20%" />
                            </telerik:GridBoundColumn>


                     
                        <telerik:GridBoundColumn DataField="Dept" HeaderText="สายงาน" UniqueName="Dept"
                         >
                                <HeaderStyle Width="20%" />
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="paneltimeOutput" HeaderText="เวลาเข้า" UniqueName="paneltimeOutput">
                       
                                <HeaderStyle Width="20%" />
                            </telerik:GridBoundColumn>


                 </Columns>



                 </MasterTableView>



                      </telerik:RadGrid>

                  </div>
                  <div class='col-sm-1'></div>

    </div>

    <br />
    <br />


     <div class="row">
            <div class='col-sm-1'></div>
           <div class='col-sm-2'>
                    <div class="form-group">
                <asp:LinkButton runat="server" ID="ButtonReport"
            CssClass="btn btn-success btn-sm" 
            OnClick="SubmitButtonReport_Click">
            REPORT
        </asp:LinkButton>
            </div>
           </div>

                  <div class='col-sm-1'>
                  </div>
                  <div class='col-sm-2'></div>
            <div class='col-sm-6'></div>

    </div>


</div>
</asp:Content>
