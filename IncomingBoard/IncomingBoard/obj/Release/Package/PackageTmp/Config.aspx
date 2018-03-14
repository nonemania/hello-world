<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Config.aspx.vb" Inherits="IncomingBoard.Config" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Config</title>
    
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>

     <script type="text/javascript">

         function ReloadParent() {

             if (window.opener != null && !window.opener.closed) {

                 window.opener.location.href = 'Default.aspx'

                 self.close();
             }
         }

    </script>


    
</head>
<body bgcolor="Black">
    <form id="form1" runat="server">
    <div>
    
        <table  style="font-family:Tahoma;width:100%;color:white;font-size:16pt;" cellspacing="10" cellpadding = "4" rules="all" >
            <tr >
                <td class="auto-style1"><strong>Monitor Config</strong></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Group</td>
                <td>
                    <asp:DropDownList ID="ddlGroup" runat="server">
                         <asp:ListItem Value="" Selected="True">- Select -</asp:ListItem>
<asp:ListItem Value="BG">BP12-GAS</asp:ListItem>
<asp:ListItem Value="BS">BP12-PHOSPHATE</asp:ListItem>
<asp:ListItem Value="BP">BP12-PALLUBE</asp:ListItem>
<asp:ListItem Value="BV">BP12-PVD</asp:ListItem>
<asp:ListItem Value="BK">BP12-KANIGEN</asp:ListItem>
<asp:ListItem Value="GG">GW-GAS</asp:ListItem>
<asp:ListItem Value="HG">HES-GAS</asp:ListItem>
<asp:ListItem Value="HS">HES-PHOSPHATE</asp:ListItem>
<asp:ListItem Value="HP">HES-PALLUBE</asp:ListItem>
<asp:ListItem Value="HI">HES-ISONITE</asp:ListItem>
<asp:ListItem Value="HH">HES-HYDRO</asp:ListItem>
<asp:ListItem Value="HD">HES-DELTA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Amount Row/Page (default : 10 row)</td>
                <td>
                    <asp:DropDownList ID="ddlShowRow" runat="server">
                         <asp:ListItem Value="" Selected="True">- Select -</asp:ListItem>
                                             <asp:ListItem Value="10">10</asp:ListItem>
                                             <asp:ListItem Value="11">11</asp:ListItem>
                                             <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                       
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Time fetch data from SAP (default : 10 minute)</td>
                <td>
                    <asp:DropDownList ID="ddlFatchSAP" runat="server">
                         <asp:ListItem Value="" Selected="True">- Select -</asp:ListItem>
                          <asp:ListItem Value="60000">1</asp:ListItem>
                        <asp:ListItem Value="300000">5</asp:ListItem>
                                             <asp:ListItem Value="600000">10</asp:ListItem>
                                              <asp:ListItem Value="900000">15</asp:ListItem>
                                      
                    </asp:DropDownList>
                    &nbsp;minute</td>
            </tr>
            <tr>
                <td>Time fetch data (default : 2 second)</td>
                <td>
                    <asp:DropDownList ID="ddlFatch" runat="server">
                         <asp:ListItem Value="" Selected="True">- Select -</asp:ListItem>
                         <asp:ListItem Value="1000">1</asp:ListItem>
                        <asp:ListItem Value="2000">2</asp:ListItem>
                                             <asp:ListItem Value="3000">3</asp:ListItem>
                                              <asp:ListItem Value="4000">4</asp:ListItem>
                                       <asp:ListItem Value="5000">5</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;second</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
