Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        If txtUsuario.Text.ToLower() = "admin" And txtClave.Text = "admin" Then
            Page.Response.Write("Ingreso OK")
        Else
            Page.Response.Write("Usuario y/o contraseña incorrectos")
        End If
    End Sub

    Protected Sub lnkRecordarClave_Click(sender As Object, e As EventArgs) Handles lnkRecordarClave.Click
        Response.Redirect("~/Default.aspx?msj=Es Ud. un usuario muy descuidado, haga memoria")
    End Sub
End Class