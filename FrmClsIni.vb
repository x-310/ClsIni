' System.Runtime.InteropServicesクラスをインポート
Imports System.Runtime.InteropServices

Public Class FrmClsIni
    ' iniファイルの場所を定数として宣言
    Private Const INI_FILE_PATH As String = "./ini/test.ini"

    ' API宣言
    ' ------------------------------------------------------
    ' ini ファイル書き込み
    ' ------------------------------------------------------
    <DllImport("Kernel32.dll")>
    Private Shared Function WritePrivateProfileString(
                    ByVal lpAppName As String,                      'セクション名
                    ByVal lpKeyName As String,                      'キー名
                    ByVal lpString As String,
                    ByVal lpFileName As String) As Integer
    End Function

    ' ------------------------------------------------------
    ' ini ファイル読み込み
    ' ------------------------------------------------------
    <DllImport("Kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetPrivateProfileString(
                    ByVal lpAppName As String,                                              ' セクション名
                    ByVal lpKeyName As String,                                              ' キー名
                    ByVal lpDefault As String,                                              ' キーが見つからなかった場合に取得するデフォルト値
                    ByVal lpReturnedString As System.Text.StringBuilder,                    ' 取得した文字列が入るバッファ
                    ByVal nSize As Integer,                                                 ' 取得した文字列のバッファサイズ
                    ByVal lpFileName As String) As Integer
    End Function

    ''' <summary>
    ''' INIファイル読取(文字列)
    ''' </summary>
    ''' <param name="lpAppName"></param>
    ''' <param name="lpKeyName"></param>
    ''' <returns></returns>
    Public Function GetIniString(ByVal lpAppName As String, ByVal lpKeyName As String) As String
        Dim BuffSize As Integer = 256
        Dim str As System.Text.StringBuilder = New System.Text.StringBuilder(BuffSize)
        Try
            Call GetPrivateProfileString(lpAppName, lpKeyName, str.ToString, str, str.Capacity, INI_FILE_PATH)
            Return str.ToString
        Catch ex As Exception
            Return str.ToString
        End Try
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' iniファイルを読み込む
        Me.RichTextBox1.Text = GetIniString("TEST", "key")
        Me.RichTextBox1.Text += vbCrLf
        Me.RichTextBox1.Text += GetIniString("TEST", "key2")

    End Sub

End Class