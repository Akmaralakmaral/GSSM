Imports System.Math
Imports org.mariuszgromada.math.mxparser
Imports aziretParser
Imports System.Windows.Forms.VisualStyles


Public Class GSSM_module
    Declare Function GetCurrentProcessId Lib "kernel32" () As Long
    Dim Func As String
    Dim cond As Integer
    Dim stopwatch As New Stopwatch()
    Dim elapsedSeconds As Double
    Dim SolutionOfTask As Decimal
    Dim ValueOfFunction As Decimal
    Dim FinalInaccuracy As Decimal
    Dim Fx1 As Decimal
    Dim Fx2 As Decimal
    Dim k As Integer

    Function Fd(a As Decimal, Search_Step As Decimal) As Decimal

        If Search_Step > 0.000000000000001 Then
            Dim x As New Argument("x = " + a.ToString())
            Dim parser = New Expression(Func, x)
            Return parser.calculate
        Else
            Return aziretParser.ParserDecimal.Compute(Func, a)
        End If
    End Function

    Public Sub input(funcBox As ComboBox, left As TextBox, right As TextBox,
                     ToleranceBox As TextBox, k_maxBox As TextBox,
                     xminusBox As TextBox, xplusBox As TextBox,
                     RadioButton1 As RadioButton, RadioButton2 As RadioButton,
                     TextBox1 As TextBox)

        Dim H As Decimal
        Dim f1 As Decimal
        Dim f2 As Decimal
        Func = funcBox.SelectedItem.ToString
        Dim Tolerance As Decimal
        Dim x1 As Decimal
        Dim x2 As Decimal
        Dim a As Decimal
        Dim b As Decimal
        Dim k_max As Integer
        x1 = 0
        H = 0
        x2 = 0

        Try
            a = Decimal.Parse(left.Text)
            b = Decimal.Parse(right.Text)
            Tolerance = Double.Parse(ToleranceBox.Text)
            H = Tolerance
            k_max = Integer.Parse(k_maxBox.Text)
            k = 0

            Dim r As Decimal = (Math.Sqrt(5) - 1) / 2
            x1 = a + (1 - r) * (b - a)
            f1 = Fd(x1, H)
            x2 = a + r * (b - a)
            f2 = Fd(x2, H)

            If k_max <= 0 Then
                MessageBox.Show("Количество итераций должно быть не менее 1",
                 "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Tolerance <= 0 Then
                MessageBox.Show("Tolerance должен быть больше нуля",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Else
                If (RadioButton1.Checked) Then   'минимум 
                    stopwatch.Start()

                    While Math.Abs(b - a) > Tolerance And k < k_max
                        If f1 > f2 Then
                            a = x1
                            x1 = x2
                            f1 = f2
                            x2 = a + r * (b - a)
                            f2 = Fd(x2, H)
                            ValueOfFunction = f2
                            SolutionOfTask = x2

                        Else
                            b = x2
                            x2 = x1
                            f2 = f1
                            x1 = a + (1 - r) * (b - a)
                            f1 = Fd(x1, H)
                            ValueOfFunction = f1
                            SolutionOfTask = x1
                        End If
                        k += 1
                    End While

                    Fx1 = Fd(x1 - Tolerance, H)
                    Fx2 = Fd(x1 + Tolerance, H)

                    If ValueOfFunction <= Fx1 And ValueOfFunction <= Fx2 Then
                        TextBox1.ForeColor = System.Drawing.Color.Green
                        TextBox1.Text = "Результат x* минимайзером этой функции, потому что" & vbCrLf &
                                            "Знак [F(x*)—F(x*–Tolerance)]  = " & Sign(ValueOfFunction - f1) & vbCrLf &
                                            "и " & vbCrLf &
                                            "Знак [F(x*)-F(x*+Tolerance)]  = " & Sign(ValueOfFunction - f2) & vbCrLf &
                                            "имеют одинаковые (минусовые) знаки" & vbCrLf &
                                            "Он был найден с ошибкой H = " & ToleranceBox.Text & vbCrLf &
                                            "Это равно заданному Tolerance!"
                    Else
                        TextBox1.ForeColor = System.Drawing.Color.Red
                        TextBox1.Text = "Результат x* не является минимайзером этой функции, потому что" & vbCrLf &
                                            "Знак [F(x*)-F(x*–Tolerance)]  = " & Sign(ValueOfFunction - f1) & vbCrLf &
                                            "и " & vbCrLf &
                                            "Знак [F(x*)-F(x*+Tolerance)]  = " & Sign(ValueOfFunction - f2) & vbCrLf &
                                            "имеют разные знаки"
                        MsgBox(" Вы должны увеличить Limit of iteration! Эта функция не нашла минимум при заданном количестве итераций")
                    End If

                ElseIf (RadioButton2.Checked) Then 'максимум
                    stopwatch.Start()

                    While Math.Abs(b - a) > Tolerance And k < k_max
                        If f1 < f2 Then
                            a = x1
                            x1 = x2
                            f1 = f2
                            x2 = a + r * (b - a)
                            f2 = Fd(x2, H)
                            ValueOfFunction = f2
                            SolutionOfTask = x2
                        Else
                            b = x2
                            x2 = x1
                            f2 = f1
                            x1 = a + (1 - r) * (b - a)
                            f1 = Fd(x1, H)
                            ValueOfFunction = f1
                            SolutionOfTask = x1
                        End If
                        k += 1
                    End While

                    Fx1 = Fd(x1 - Tolerance, H)
                    Fx2 = Fd(x1 + Tolerance, H)
                    If Sign(ValueOfFunction - Fx1) = Sign(ValueOfFunction - Fx2) Then
                        TextBox1.ForeColor = System.Drawing.Color.Green
                        TextBox1.Text = "Результат x* максимайзером этой функции, потому что" & vbCrLf &
                                        "Знак [F(x*) — F(x*–Tolerance)]  = " & Sign(ValueOfFunction - f1) & vbCrLf &
                                        "и " & vbCrLf &
                                        "Знак [F(x*) — F(x*+Tolerance)]  = " & Sign(ValueOfFunction - f2) & vbCrLf &
                                        "имеют одинаковые (плюсовые) знаки" & vbCrLf &
                                        "Он был найден с ошибкой H = " & ToleranceBox.Text & vbCrLf &
                                        "Это равно заданному Tolerance!"
                    Else
                        TextBox1.ForeColor = System.Drawing.Color.Red
                        TextBox1.Text = "Результат x * не является максимайзером этой функции, потому что " & vbCrLf &
                                        "Знак [F(x*) — F(x*–Tolerance)]  = " & Sign(ValueOfFunction - f1) & vbCrLf &
                                        "и" & vbCrLf &
                                        "Знак[F(x*) — F(x*+Tolerance)]  = " & Sign(ValueOfFunction - f2) & vbCrLf &
                                        "имеют разные знаки"
                        MsgBox("Эта функция не нашла максимум при заданном количестве итераций, вы должны увеличить Limit of iteration!")
                    End If

                Else
                    MessageBox.Show("Выберите какой экстремум функции вы хотите найти")
                End If
            End If
        Catch ex As ArithmeticException
            MessageBox.Show("Ошибка, Логорифмическая функция для значения 'X0' должен быть больше 0")
        Catch ex As Exception
            MessageBox.Show("Ошибка ввода данных. Убедитесь, что все поля заполнены корректно.")
        End Try
        stopwatch.Stop()
        elapsedSeconds = stopwatch.Elapsed.TotalSeconds
        FinalInaccuracy = Math.Abs(b - a)
    End Sub

    Public Sub output(Fplus2 As TextBox, Fminus2 As TextBox, xResultBox As TextBox, funcResultBox As TextBox, NumberOfIterationsBox As TextBox,
                      TimeBox As TextBox, xminusBox As TextBox, xplusBox As TextBox, TextBox1 As TextBox, a_b As TextBox)

        xResultBox.Text = SolutionOfTask.ToString("N28")
        xResultBox.ForeColor = System.Drawing.Color.Red
        funcResultBox.Text = ValueOfFunction.ToString("N28")
        NumberOfIterationsBox.Text = k
        xminusBox.Text = Fx1.ToString("0.0e0")
        xplusBox.Text = Fx2.ToString("0.0e0")
        Fplus2.Text = (ValueOfFunction - Fx2).ToString("0.0e0")
        Fminus2.Text = (ValueOfFunction - Fx1).ToString("0.0e0")
        TimeBox.Text = elapsedSeconds.ToString
        a_b.Text = FinalInaccuracy
        stopwatch.Reset()


    End Sub
End Class
