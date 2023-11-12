Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1

    Dim stopwatch As New Stopwatch()
    Public Sub New()
        InitializeComponent()
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            If (ComboBox1.Text = "" Or TextBox2.Text = "" _
                Or TextBox3.Text = "" Or TextBox4.Text = "") Then
                MsgBox("Текстовые поля ввода пусты! Введите данные")
            ElseIf Not (IsNumeric(TextBox2.Text) And IsNumeric(TextBox3.Text) And IsNumeric(TextBox4.Text)) Then
                MsgBox("Введите только числовые значения")

            Else
                Dim GSSM As GSSM_module = New GSSM_module()

                GSSM.input(ComboBox1, TextBox1, TextBox2, TextBox3,
                  TextBox4, TextBox14, TextBox13, RadioButton1,
                  RadioButton2, TextBox10)

                GSSM.output(TextBox11, TextBox12, TextBox5, TextBox6, TextBox7, TextBox9, TextBox14, TextBox13, TextBox10, TextBox8)
            End If
        Catch ef As FormatException
            MsgBox("Ошибка в формате входных данных")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
    End Sub

End Class
