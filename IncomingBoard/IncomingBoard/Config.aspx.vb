Public Class Config
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Request.QueryString("group") <> "undefined" Then

                ddlGroup.SelectedValue = Request.QueryString("group")
                ddlShowRow.SelectedValue = Request.QueryString("ShowRow")
                ddlFatchSAP.SelectedValue = Request.QueryString("FatchSAP")
                ddlFatch.SelectedValue = Request.QueryString("Fatch")

            Else

                ddlShowRow.SelectedValue = 15
                ddlFatchSAP.SelectedValue = 600000
                ddlFatch.SelectedValue = 2000
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ReloadParent", "ReloadParent('" & ddlGroup.SelectedValue & "','" & ddlShowRow.SelectedValue & "','" & ddlFatchSAP.SelectedValue & "','" & ddlFatch.SelectedValue & "');", True)

    End Sub
End Class