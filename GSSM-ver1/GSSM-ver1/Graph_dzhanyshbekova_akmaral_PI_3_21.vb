Public Class Graph_dzhanyshbekova_akmaral_PI_3_21
    Private Sub Graph_dzhanyshbekova_akmaral_PI_3_21_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Устанавливаем диапазон значений на оси X и Y

        Chart1.ChartAreas(0).AxisX.Minimum = -1.5
        Chart1.ChartAreas(0).AxisX.Maximum = 4
        Chart1.ChartAreas(0).AxisY.Maximum = 1
        Chart1.ChartAreas(0).AxisY.Minimum = -0.1
        ' Установите интервал мажорных делений для оси X
        Chart1.ChartAreas(0).AxisX.Interval = 0.5 ' Например, устанавливаем интервал в 1

        ' Установите интервал мажорных делений для оси Y
        Chart1.ChartAreas(0).AxisY.Interval = 0.1 ' Например, устанавливаем интервал в 0.2

        ' Добавляем серию для графика
        Dim series As New DataVisualization.Charting.Series()
        series.ChartType = DataVisualization.Charting.SeriesChartType.Line
        series.Name = "y = (x^2/2-x^3/6)^2"

        ' Добавляем точки на график, вычисляя значения функции
        For x As Double = -3 To 5 Step 0.01
            Dim y As Double = (x * x / 2 - x * x * x / 6) ^ 2
            series.Points.AddXY(x, y)
        Next

        ' Добавляем серию на график
        Chart1.Series.Add(series)
        series.BorderWidth = 4


        Dim intersectionX As Double = 0
        Dim intersectionY As Double = 0

        ' Добавляем серию для прямой x = 0
        Dim lineX As New DataVisualization.Charting.Series()
        lineX.ChartType = DataVisualization.Charting.SeriesChartType.Line
        lineX.Name = "X Line"
        lineX.Points.AddXY(0, -0.4)
        lineX.Points.AddXY(0, 2)
        ' Настройка стиля и цвета линии
        lineX.Color = Color.Black
        lineX.BorderWidth = 2
        Chart1.Series.Add(lineX)

        ' Добавляем серию для прямой y = 0
        Dim lineY As New DataVisualization.Charting.Series()
        lineY.ChartType = DataVisualization.Charting.SeriesChartType.Line
        lineY.Name = "Y Line"
        lineY.Points.AddXY(-2, 0)
        lineY.Points.AddXY(4, 0)
        ' Настройка стиля и цвета линии
        lineY.Color = Color.Black
        lineY.BorderWidth = 2
        Chart1.Series.Add(lineY)

        Chart1.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        Chart1.ChartAreas(0).AxisY.MajorTickMark.Enabled = True

        ' Настройка внешнего вида главных линий и делений сетки (по вашим предпочтениям)
        Chart1.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisX.MajorTickMark.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisY.MajorTickMark.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisX.MajorTickMark.Size = 1
        Chart1.ChartAreas(0).AxisY.MajorTickMark.Size = 1

    End Sub
End Class