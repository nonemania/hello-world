Imports BoardDB
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class clsMain

    Public ZITEM As String
    Public CUST_NM As String
    Public MAKT As String
    Public CHARG_CP As String
    Public ENMNG As String
    Public GMEIN As String
    Public ZGROUP As String
    Public STSCOL As String
    Public ACT_DTE As String
    Public ACT_TIME As String
    Public TOT_ORD As String
    Public T_ONPLAN As String
    Public T_WARNING As String
    Public T_DELAY As String
    Public T_SM As String
    Public UpdateDate As String
    Public T_INVALID As String

#Region "GetSAP"
    Public Function GetSAP(Group) As DataSet


        Dim obj As New clsConnDB
        Dim Conn2 As New OleDbConnection
        Dim cmd As New OleDbCommand

        Try

            obj.SAPConn(Conn2)

            cmd.Connection = Conn2
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " SELECT ZITEM,CUST_NM,MAKT,CHARG_CP,ENMNG,GMEIN,ZGROUP,STSCOL,ACT_DTE,ACT_TIME,TOT_ORD,T_ONPLAN,T_WARNING,T_DELAY,T_SM,T_INVALID FROM R3P11DATA.ZBINCOMING WHERE ZGROUP = '" & Group & "' "
            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()


            Dim cmdReader As OleDbDataReader
            Dim ds As New DataSet
            Dim dt As New DataTable
            cmdReader = cmd.ExecuteReader()

            dt.Load(cmdReader)

            ds.Tables.Add(dt)

            Return ds

            cmd.Dispose()
        Catch ex As Exception
            Throw ex
        Finally
            obj.CloseSAPConn(Conn2)
            Conn2.Dispose()
        End Try
    End Function

#End Region

#Region "GetData"
    Public Function GetData(ByVal flade As Integer, ByVal row As Integer, ByVal Group As String) As DataSet


        Dim obj As New clsConnDB
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand

        Try

            obj.SqlConn(conn)

            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " SELECT ACT_DTE,ACT_TIME,T_INVALID,ZITEM,CUST_NM,MAKT,CHARG_CP,ENMNG,GMEIN,ZGROUP,TOT_ORD,T_ONPLAN,T_WARNING,T_DELAY,T_SM,STSCOL,CONVERT(NVARCHAR,UpdateDate,105) + ' ' + CONVERT(VARCHAR(5), UpdateDate, 8) as UpdateDate FROM tblIncoming WHERE ZGROUP  = '" & Group & "'  ORDER BY STSCOL,CUST_NM,MAKT,CHARG_CP  OFFSET " & flade & " ROWS FETCH NEXT " & row & " ROWS ONLY "
            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()


            Dim cmdReader As SqlDataReader
            Dim ds As New DataSet
            Dim dt As New DataTable
            cmdReader = cmd.ExecuteReader()

            dt.Load(cmdReader)

            ds.Tables.Add(dt)

            Return ds

            cmd.Dispose()
        Catch ex As Exception
            Throw ex
        Finally
            obj.CloseSqlConn(conn)
            conn.Dispose()
        End Try
    End Function

#End Region

#Region "InsertData"
    Public Sub InsertData()

        Dim obj As New clsConnDB
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand


        Try

            obj.SqlConn(conn)

            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " INSERT INTO tblIncoming(ZITEM,CUST_NM,MAKT,CHARG_CP,ENMNG,GMEIN,ZGROUP,STSCOL,ACT_DTE,ACT_TIME,TOT_ORD,T_ONPLAN,T_WARNING,T_DELAY,T_SM,T_INVALID) VALUES (@ZITEM,@CUST_NM,@MAKT,@CHARG_CP,@ENMNG,@GMEIN,@ZGROUP,@STSCOL,@ACT_DTE,@ACT_TIME,@TOT_ORD,@T_ONPLAN,@T_WARNING,@T_DELAY,@T_SM,@T_INVALID) "
            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()



            cmd.Parameters.AddWithValue("@ZITEM", ZITEM)
            cmd.Parameters.AddWithValue("@CUST_NM", CUST_NM)
            cmd.Parameters.AddWithValue("@MAKT", MAKT)
            cmd.Parameters.AddWithValue("@CHARG_CP", CHARG_CP)
            cmd.Parameters.AddWithValue("@ENMNG", ENMNG)
            cmd.Parameters.AddWithValue("@GMEIN", GMEIN)
            cmd.Parameters.AddWithValue("@ZGROUP", ZGROUP)
            cmd.Parameters.AddWithValue("@STSCOL", STSCOL)
            cmd.Parameters.AddWithValue("@ACT_DTE", ACT_DTE)
            cmd.Parameters.AddWithValue("@ACT_TIME", ACT_TIME)
            cmd.Parameters.AddWithValue("@TOT_ORD", TOT_ORD)
            cmd.Parameters.AddWithValue("@T_ONPLAN", T_ONPLAN)
            cmd.Parameters.AddWithValue("@T_WARNING", T_WARNING)
            cmd.Parameters.AddWithValue("@T_SM", T_SM)
            cmd.Parameters.AddWithValue("@T_DELAY", T_DELAY)
            cmd.Parameters.AddWithValue("@T_INVALID", T_INVALID)
            ' cmd.Parameters.AddWithValue("@UpdateDate", UpdateDate)

            cmd.ExecuteNonQuery()

            cmd.Dispose()

        Catch ex As Exception
            Throw ex
        Finally
            obj.CloseSqlConn(conn)
            conn.Dispose()
        End Try
    End Sub

#End Region

#Region "DeleteData"
    Public Sub DeleteData(Group)

        Dim obj As New clsConnDB
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand


        Try

            obj.SqlConn(conn)

            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " DELETE FROM tblIncoming WHERE ZGROUP  = '" & Group & "'  "
            cmd.CommandTimeout = 0
            cmd.Parameters.Clear()

            cmd.ExecuteNonQuery()

            cmd.Dispose()

        Catch ex As Exception
            Throw ex
        Finally
            obj.CloseSqlConn(conn)
            conn.Dispose()
        End Try
    End Sub

#End Region

End Class
