Imports System.IO
Public Class _Default
    Inherits System.Web.UI.Page

    Dim obj As New clsMain
    Dim dsSAP As New DataSet
    Dim ds As New DataSet

 
    Dim stsTimer As String

#Region "GetSAP2Insert"
    Private Sub GetSAP2Insert(Group)

        obj.DeleteData(Group)

        dsSAP = obj.GetSAP(Group)

        If dsSAP.Tables(0).Rows.Count <> 0 Then

            hfcntSAP.Value = dsSAP.Tables(0).Rows.Count

            obj.UpdateDate = DateTime.Now

            For i As Integer = 0 To dsSAP.Tables(0).Rows.Count - 1

                obj.ZITEM = dsSAP.Tables(0).Rows(i)("ZITEM").ToString()
                obj.CUST_NM = dsSAP.Tables(0).Rows(i)("CUST_NM").ToString()
                obj.MAKT = dsSAP.Tables(0).Rows(i)("MAKT").ToString()
                obj.CHARG_CP = dsSAP.Tables(0).Rows(i)("CHARG_CP").ToString()
                obj.ENMNG = dsSAP.Tables(0).Rows(i)("ENMNG").ToString()
                obj.GMEIN = dsSAP.Tables(0).Rows(i)("GMEIN").ToString()
                obj.ZGROUP = dsSAP.Tables(0).Rows(i)("ZGROUP").ToString()
                obj.STSCOL = dsSAP.Tables(0).Rows(i)("STSCOL").ToString()
                obj.ACT_DTE = dsSAP.Tables(0).Rows(i)("ACT_DTE").ToString()
                obj.ACT_TIME = dsSAP.Tables(0).Rows(i)("ACT_TIME").ToString()
                obj.TOT_ORD = dsSAP.Tables(0).Rows(i)("TOT_ORD").ToString()
                obj.T_ONPLAN = dsSAP.Tables(0).Rows(i)("T_ONPLAN").ToString()
                obj.T_WARNING = dsSAP.Tables(0).Rows(i)("T_WARNING").ToString()
                obj.T_DELAY = dsSAP.Tables(0).Rows(i)("T_DELAY").ToString()
                obj.T_SM = dsSAP.Tables(0).Rows(i)("T_SM").ToString()
                obj.T_INVALID = dsSAP.Tables(0).Rows(i)("T_INVALID").ToString()
                obj.InsertData()

            Next


        End If

    End Sub

#End Region

#Region "BindData"
    Private Sub BindData(cnt, row, Group)



        ds = obj.GetData(cnt, row, Group)

        If ds.Tables(0).Rows.Count <> 0 Then

            If Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "BG" Then
                lblGroup.Text = "BP12-GAS"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "BS" Then
                lblGroup.Text = "BP12-PHOSPHATE"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "BP" Then
                lblGroup.Text = "BP12-PALLUBE"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "BV" Then
                lblGroup.Text = "BP12-PVD"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "BK" Then
                lblGroup.Text = "BP12-KANIGEN"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "GG" Then
                lblGroup.Text = "GW-GAS"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "BK" Then
                lblGroup.Text = "BP12-KANIGEN"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "GG" Then
                lblGroup.Text = "GW-GAS"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "HG" Then
                lblGroup.Text = "HES-GAS"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "HS" Then
                lblGroup.Text = "HES-PHOSPHATE"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "HP" Then
                lblGroup.Text = "HES-PALLUBE"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "HI" Then
                lblGroup.Text = "HES-ISONITE"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "HH" Then
                lblGroup.Text = "HES-HYDRO"
            ElseIf Trim(ds.Tables(0).Rows(0)("ZGROUP").ToString()) = "HD" Then
                lblGroup.Text = "HES-DELTA"

            Else

                lblGroup.Text = "No Group"
            End If



            lblUpdateDate.Text = Right(ds.Tables(0).Rows(0)("ACT_DTE").ToString(), 2) & "/" & Mid(ds.Tables(0).Rows(0)("ACT_DTE").ToString(), 5, 2) & "/" & Left(ds.Tables(0).Rows(0)("ACT_DTE").ToString(), 4) & "<br/>  " & Left(ds.Tables(0).Rows(0)("ACT_TIME").ToString(), 2) & ":" & Mid(ds.Tables(0).Rows(0)("ACT_TIME").ToString(), 3, 2) & ":" & Right(ds.Tables(0).Rows(0)("ACT_TIME").ToString(), 2)
            lblTotal.Text = ds.Tables(0).Rows(0)("TOT_ORD").ToString()
            lblT_ONPLAN.Text = ds.Tables(0).Rows(0)("T_ONPLAN").ToString()
            lblT_WARNING.Text = ds.Tables(0).Rows(0)("T_WARNING").ToString()
            lblT_DELAY.Text = ds.Tables(0).Rows(0)("T_DELAY").ToString()
            lblT_SM.Text = ds.Tables(0).Rows(0)("T_SM").ToString()
            lblT_INVALID.Text = ds.Tables(0).Rows(0)("T_INVALID").ToString()
            GridView1.DataSource = ds
            GridView1.DataBind()

        Else
            If Group = "BG" Then
                Response.Redirect("http://tp-portal/ManPowerMonitoringGas?group=" & Request.QueryString("group") & "&ShowRow=" & Request.QueryString("ShowRow") & "&FatchSAP=" & Request.QueryString("FatchSAP") & "&Fatch=" & Request.QueryString("Fatch"))
            End If
        End If

    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Not String.IsNullOrEmpty(Request.QueryString("group")) Then

                ctlTimer.Interval = Request.QueryString("Fatch")
                ctlTimerSAP.Interval = Request.QueryString("FatchSAP")
                GetSAP2Insert(Request.QueryString("group"))
                BindData(hfCnt.Value, Request.QueryString("ShowRow"), Request.QueryString("group"))
                lbConfig.Attributes.Add("onClick", "OpenWindow('" + Request.QueryString("group") + "','" + Request.QueryString("ShowRow") + "','" + Request.QueryString("FatchSAP") + "','" + Request.QueryString("Fatch") + "')")



            End If

        End If


    End Sub

    Protected Sub OnTimerIntervalElapse(sender As Object, e As EventArgs)

        If Int32.Parse(hfCntSAP.Value) < Int32.Parse(hfFalde.Value) Then
            hfCnt.Value = 0
            hfFalde.Value = 0
            BindData(hfCnt.Value, Request.QueryString("ShowRow"), Request.QueryString("group"))
        Else
            If stsTimer = "" Then
                hfFalde.Value = hfFalde.Value + 1
                hfCnt.Value = hfFalde.Value
                BindData(hfCnt.Value, Request.QueryString("ShowRow"), Request.QueryString("group"))
            ElseIf stsTimer = "play" Then
                BindData(hfCnt.Value, Request.QueryString("ShowRow"), Request.QueryString("group"))
            Else
                BindData(hfCnt.Value, Request.QueryString("ShowRow"), Request.QueryString("group"))
            End If
        End If
    End Sub

    Protected Sub OnTimerIntervalElapseSAP(sender As Object, e As EventArgs)

        GetSAP2Insert(Request.QueryString("group"))

        hfFalde.Value = 0
        Response.Redirect("Default.aspx?group=" & Request.QueryString("group") & "&ShowRow=" & Request.QueryString("ShowRow") & "&FatchSAP=" & Request.QueryString("FatchSAP") & "&Fatch=" & Request.QueryString("Fatch"))

    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim STSCOL As String = DataBinder.Eval(e.Row.DataItem, "STSCOL").ToString()

            If STSCOL.Substring(0, 3) = "010" Then
                e.Row.ForeColor = Drawing.Color.Red

            ElseIf STSCOL.Substring(0, 3) = "020" Then
                e.Row.ForeColor = Drawing.Color.Yellow

            ElseIf STSCOL.Substring(0, 3) = "039" Then
                e.Row.ForeColor = Drawing.Color.SpringGreen

            ElseIf STSCOL.Substring(0, 3) = "031" Then
                e.Row.ForeColor = Drawing.Color.Red
                e.Row.BackColor = Drawing.Color.GreenYellow

            ElseIf STSCOL.Substring(0, 3) = "032" Then
                e.Row.ForeColor = Drawing.Color.Black
                e.Row.BackColor = Drawing.Color.GreenYellow


            ElseIf STSCOL.Substring(0, 3) = "099" Then
                e.Row.ForeColor = Drawing.Color.White
                e.Row.BackColor = Drawing.Color.SlateGray
            End If


            Dim CUST_NM As String = DataBinder.Eval(e.Row.DataItem, "CUST_NM").ToString()

            If CUST_NM.Length > 8 Then

                e.Row.Cells(1).Font.Size = "20"

            End If


            Dim MAKT As String = DataBinder.Eval(e.Row.DataItem, "MAKT").ToString()

            If MAKT.Length > 37 Then

                e.Row.Cells(2).Font.Size = "20"

            End If

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Button" Or Button1.Text = "Pause" Then
            Button1.Text = "Continue"
            stsTimer = "pause"
          
            hfCnt.Value = hfFalde.Value
            ctlTimer.Enabled = False
            ctlTimerSAP.Enabled = False


        ElseIf Button1.Text = "Continue" Then
            Button1.Text = "Pause"
            stsTimer = "play"
            hfCnt.Value = hfFalde.Value
            ctlTimer.Enabled = True
            ctlTimerSAP.Enabled = True

        End If
    End Sub


End Class