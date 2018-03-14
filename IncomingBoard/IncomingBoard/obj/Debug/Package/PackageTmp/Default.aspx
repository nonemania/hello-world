<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="IncomingBoard._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <script  type="text/javascript">

           function OpenWindow(g1, g2, g3, g4) {
               window.open("Config.aspx?group=" + g1 + "&ShowRow=" + g2 + "&FatchSAP=" + g3 + "&Fatch=" + g4,
                  "mywindow", "menubar=0,resizable=0,scrollbars=1," +
                  "width=700,height=300,toolbars=0");

           }
             </script>

    <style type="text/css">
        .auto-style1 {
            width: 10%;
        }
        </style>

</head>
<body bgcolor="Black">
    <form id="form1" runat="server" >

              <asp:ScriptManager ID="ScriptManager1" runat="server"/>        
    <asp:Timer runat="server" ID="ctlTimer"  OnTick="OnTimerIntervalElapse" />       
    <asp:Timer runat="server" ID="ctlTimerSAP"  OnTick="OnTimerIntervalElapseSAP" />      
    <asp:UpdatePanel runat="server" id="pnlUpdate">     
         <Triggers>
             <asp:AsyncPostBackTrigger ControlID="ctlTimer" eventname="Tick"/>
               <asp:AsyncPostBackTrigger ControlID="ctlTimerSAP" eventname="Tick"/>
        </Triggers>        
        <ContentTemplate>      

        <asp:HiddenField ID="hfFalde" runat="server" Value="0"/>
            <asp:HiddenField ID="hfCnt" runat="server" Value="0"/>
              <asp:HiddenField ID="hfCntSAP" runat="server" Value="0"/>
       

                         <div style =" background-color:black;  
        height:100px;width:100%; margin:0;padding:0">
        <table cellspacing="10" cellpadding = "4" rules="all" 
         style="font-family:Tahoma;width:100%;color:white;
         border-collapse:collapse;height:100%;">
            <tr>
                   <td style ="width:15%;font-size:18pt; text-align: right;" rowspan="3" >Last update : <br />  <asp:Label ID="lblUpdateDate" runat="server" style ="text-align:center;font-size:20pt;" ></asp:Label></td>
               <td style ="width:30%;font-size:28pt;" rowspan="2"><center><asp:LinkButton ID="lbConfig" runat="server" ForeColor="White" onclientclick="OpenWindow()">INCOMING BOARD</asp:LinkButton>&nbsp;<asp:Button ID="Button1" runat="server" Text="Pause" />
                   </center></td>
               
               <td style ="width:20%;font-size:28pt;" rowspan="2"><center><asp:Label ID="lblGroup" runat="server" ></asp:Label></center></td>
               
               <td style ="width:20%;text-align:center;font-size:25pt;" colspan="5" >Total Part No. : <asp:Label ID="lblTotal" runat="server" ></asp:Label></td>
            
            </tr>
            <tr>
               <td style ="width:7%;text-align:center;font-size:20pt;color:red;border-color:gray;"><asp:Label ID="lblT_DELAY" runat="server" style="font-weight: 700" ></asp:Label></td>
               <td style ="width:7%;text-align:center;font-size:20pt;color:Yellow;border-color:gray;"><asp:Label ID="lblT_WARNING" runat="server" style="font-weight: 700" ></asp:Label></td>
                <td style ="width:7%;text-align:center;font-size:20pt;color:SpringGreen;border-color:gray;"  class="auto-style1" ><asp:Label ID="lblT_ONPLAN" runat="server" style="font-weight: 700" ></asp:Label></td>

                              <td style ="text-align:center;width:7%;font-size:20pt;color:yellowgreen;border-color:gray;background-color:GreenYellow;"><asp:Label ID="lblT_SM" runat="server" style="color: #000000; font-weight: 700;" ></asp:Label></td>
                
                <td style ="width:55%;text-align:center;font-size:20pt;color:GreenYellow;border-color:gray;background-color:DarkGray;"><asp:Label ID="lblT_INVALID" runat="server" style="color: #FFFFFF; font-weight: 700;" ></asp:Label></td>
            </tr>
        </table>
     
              
        <asp:gridview ID="GridView1" Width="100%"  BackColor="Black" BorderColor="#999999" BorderStyle="Solid"  OnRowDataBound ="OnRowDataBound"   
            BorderWidth="3px" CellPadding="10" CellSpacing="4" ForeColor="White" Font-Size="30px" Font-Names ="tahoma"     
            AutoGenerateColumns="False" runat="server" Style="max-width: 1920px;max-height:1080px">           

            <Columns>
              
                <asp:BoundField DataField="ZITEM" HeaderText="NO." >  
                <HeaderStyle Width="5%" Wrap="true" />
                <ItemStyle Width="5%" Wrap="true" HorizontalAlign="Right" BorderColor="Gray"  />  
                   
                </asp:BoundField>
                <asp:BoundField DataField="CUST_NM" HeaderText="CUST."  >  
                <HeaderStyle Width="10%" Wrap="true" />
                <ItemStyle Width="10%" Wrap="true"  HorizontalAlign="Center" BorderColor="Gray"/>

                </asp:BoundField>  
                <asp:BoundField DataField="MAKT" HeaderText="PART NAME"  >  
                <HeaderStyle Width="45%" Wrap="true" />
                <ItemStyle Width="45%" Wrap="true" BorderColor="Gray"/>
                </asp:BoundField>  
                  <asp:BoundField DataField="CHARG_CP" HeaderText="CP LOT."   >  
                <HeaderStyle Width="15%" Wrap="true" />
                <ItemStyle Width="15%" Wrap="true"  HorizontalAlign="Center" BorderColor="Gray"/>
                </asp:BoundField>  
               <asp:BoundField DataField="ENMNG" HeaderText="QTY" DataFormatString = "{0:N0}" >  
                <HeaderStyle Width="10%" Wrap="true" />
                <ItemStyle Width="10%" Wrap="true" HorizontalAlign="Right" BorderColor="Gray" />
                </asp:BoundField>  
               <asp:BoundField DataField="GMEIN" HeaderText="UNIT" >  
                <HeaderStyle Width="10%" Wrap="true" />
                <ItemStyle Width="10%" Wrap="true" HorizontalAlign="Center" BorderColor="Gray" />
                </asp:BoundField>  
            </Columns>  
        </asp:gridview>    </div>                             
        </ContentTemplate>
    </asp:UpdatePanel>    


          
        
    </form>
</body>
</html>
