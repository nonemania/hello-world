Public Class IncomingBP12_Gas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session.Clear()
        'Session("Group") = "BG"
        'Session("Row") = "15"
        'Session("FatchSAP") = "600000"
        'Session("Fatch") = "2000"

        Response.Redirect("Default.aspx?group=" & Request.QueryString("group") & "&ShowRow=" & Request.QueryString("ShowRow") & "&FatchSAP=" & Request.QueryString("FatchSAP") & "&Fatch=" & Request.QueryString("Fatch"))

    End Sub

End Class