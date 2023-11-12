Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1

    Dim stopwatch As New Stopwatch()

    Public Sub New()
        InitializeComponent()
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
    End Sub
    Private Function CalculateFunction(x As Decimal) As Decimal
        ' Функция f(x)
        Return (x * x / 2 - x * x * x / 6) ^ 2
    End Function
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

                GSSM.output(TextBox11, TextBox12, TextBox5, TextBox6, TextBox7, TextBox9, TextBox14, TextBox13, TextBox10)
            End If
        Catch ef As FormatException
            MsgBox("Ошибка в формате входных данных")
        End Try









        'Try
        '    Dim a As Decimal = Decimal.Parse(TextBox1.Text)
        '    Dim b As Decimal = Decimal.Parse(TextBox2.Text)
        '    Dim tol As Decimal = Decimal.Parse(TextBox3.Text)
        '    Dim k_max As Integer = Integer.Parse(TextBox4.Text)
        '    Dim cond As Integer = 0


        '    Dim r As Decimal = (Math.Sqrt(5) - 1) / 2
        '    Dim x1 As Decimal = a + (1 - r) * (b - a)
        '    Dim f1 As Decimal = CalculateFunction(x1)
        '    Dim x2 As Decimal = a + r * (b - a)
        '    Dim f2 As Decimal = CalculateFunction(x2)
        '    Dim k As Integer = 0



        '    Try

        '        'минимум ===================================================================

        '        If (RadioButton1.Checked) Then
        '            stopwatch.Start()
        '            While cond = 0


        '                While k < k_max And (b - a) > tol
        '                    If f1 > f2 Then
        '                        a = x1
        '                        x1 = x2
        '                        f1 = f2
        '                        x2 = a + r * (b - a)
        '                        f2 = CalculateFunction(x2)

        '                    Else
        '                        b = x2
        '                        x2 = x1
        '                        f2 = f1
        '                        x1 = a + (1 - r) * (b - a)
        '                        f1 = CalculateFunction(x1)
        '                    End If
        '                    k += 1
        '                End While
        '                cond = 2
        '            End While
        '            Dim minimumValue As Decimal = Math.Abs(b - a)
        '            TextBox5.Text = x2.ToString()
        '            TextBox6.Text = f2.ToString()
        '            TextBox7.Text = k.ToString()
        '            TextBox8.Text = minimumValue.ToString()
        '            k = 0
        '            x1 = 0
        '            x2 = 0
        '            f1 = 0
        '            f2 = 0
        '            cond = 0

        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show("Ошибка ввода данных. Убедитесь, что все поля заполнены корректно.")
        '    End Try
        '    stopwatch.Stop()
        '    Dim elapsedSecondsMin As Double = stopwatch.Elapsed.TotalSeconds
        '    TextBox9.Text = elapsedSecondsMin.ToString()






        '    Try
        '        'максимум ===================================================================

        '        If (RadioButton2.Checked) Then
        '            stopwatch.Start()
        '            While cond = 0


        '                While k < k_max And (b - a) > tol
        '                    If f1 < f2 Then
        '                        a = x1
        '                        x1 = x2
        '                        f1 = f2
        '                        x2 = a + r * (b - a)
        '                        f2 = CalculateFunction(x2)

        '                    Else
        '                        b = x2
        '                        x2 = x1
        '                        f2 = f1
        '                        x1 = a + (1 - r) * (b - a)
        '                        f1 = CalculateFunction(x1)
        '                    End If


        '                    k += 1
        '                End While
        '                cond = 2
        '            End While
        '            Dim minimumValue As Decimal = Math.Abs(b - a)
        '            TextBox5.Text = x2.ToString()
        '            TextBox6.Text = f2.ToString()
        '            TextBox7.Text = k.ToString()
        '            TextBox8.Text = minimumValue.ToString()
        '            k = 0
        '            x1 = 0
        '            x2 = 0
        '            f1 = 0
        '            f2 = 0
        '            cond = 0


        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show("Ошибка ввода данных. Убедитесь, что все поля заполнены корректно.")
        '    End Try
        '    stopwatch.Stop()
        '    Dim elapsedSecondsMax As Double = stopwatch.Elapsed.TotalSeconds
        '    TextBox9.Text = elapsedSecondsMax.ToString()
        '    stopwatch.Reset()

        'Catch ex As Exception
        '    MessageBox.Show("Ошибка ввода данных. Убедитесь, что все поля заполнены корректно.")
        'End Try


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
    End Sub

End Class
