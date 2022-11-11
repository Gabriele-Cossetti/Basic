Public Class Form1

    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim k, I, J, l As Integer
        Dim x(11), y(11), Dx(11), Dy(11) As Integer
        Dim Velocita As Double
        Dim SpondaXmin, SpondaXmax, SpondaYmin, SpondaYmax As Integer

        Dim SuperficieGrafica As Graphics = Me.CreateGraphics
        Dim Penna As New Pen(Brushes.Red, 1)

        Velocita = 30
        SpondaXmin = 0
        SpondaXmax = Me.Width - 17
        SpondaYmin = 0
        SpondaYmax = Me.Height - 40

        '--------------------------------------Inizializzazione
        x(1) = SpondaXmax / 2
        y(1) = SpondaYmax / 2
        Dx(1) = Velocita * (1 / 10) * 4
        Dy(1) = Velocita * (1 / 10) * 4
        x(2) = SpondaXmax / 2
        y(2) = SpondaYmax / 2
        Dx(2) = Velocita * (1 / 10) * 4
        Dy(2) = -Velocita * (1 / 10) * 4
        x(3) = SpondaXmax / 2
        y(3) = SpondaYmax / 2
        Dx(3) = Velocita * (1 / 10) * 3
        Dy(3) = Velocita * (1 / 10) * 3
        x(4) = SpondaXmax / 2
        y(4) = SpondaYmax / 2
        Dx(4) = Velocita * (1 / 10) * 3
        Dy(4) = -Velocita * (1 / 10) * 3
        x(5) = SpondaXmax / 2
        y(5) = SpondaYmax / 2
        Dx(5) = Velocita * (1 / 10) * 2
        Dy(5) = Velocita * (1 / 10) * 2
        x(6) = SpondaXmax / 2
        y(6) = SpondaYmax / 2
        Dx(6) = Velocita * (1 / 10) * 2
        Dy(6) = -Velocita * (1 / 10) * 2
        x(7) = SpondaXmax / 2
        y(7) = SpondaYmax / 2
        Dx(7) = Velocita * (1 / 10) * 4
        Dy(7) = Velocita * (1 / 10) * 2
        x(8) = SpondaXmax / 2
        y(8) = SpondaYmax / 2
        Dx(8) = Velocita * (1 / 10) * 4
        Dy(8) = -Velocita * (1 / 10) * 2
        x(9) = SpondaXmax / 2
        y(9) = SpondaYmax / 2
        Dx(9) = Velocita * (1 / 10) * 3
        Dy(9) = -1
        x(10) = SpondaXmax / 2
        y(10) = SpondaYmax / 2
        Dx(10) = Velocita * (1 / 10)
        Dy(10) = 1

        '--------------------------------------Lacio Bianca
        x(11) = 25
        y(11) = SpondaYmax / 2
        Do While (x(11) < SpondaXmax / 2)

            SuperficieGrafica.FillRectangle(Brushes.Black, SpondaXmin, SpondaYmin, SpondaXmax, SpondaYmax)
            SuperficieGrafica.DrawRectangle(Penna, SpondaXmin, SpondaYmin, SpondaXmax, SpondaYmax)

            x(11) = x(11) + (SpondaXmax / 10000) * Velocita

            SuperficieGrafica.FillEllipse(Brushes.White, x(11), y(11), 10, 10)

            l = 0
            Do While (l < 400000)
                l = l + 1
                'Tempo di attesa
            Loop

            My.Application.DoEvents()
        Loop
        x(11) = SpondaXmax / 2
        y(11) = SpondaYmax / 2
        Dx(11) = Velocita * (1 / 10)
        Dy(11) = -1
        '--------------------------------------

        Do While (k < 500)
            k = k + 1

            SuperficieGrafica.FillRectangle(Brushes.Black, SpondaXmin, SpondaYmin, SpondaXmax, SpondaYmax)
            SuperficieGrafica.DrawRectangle(Penna, SpondaXmin, SpondaYmin, SpondaXmax, SpondaYmax)

            For I = 1 To 11
                x(I) = x(I) + Dx(I)
                y(I) = y(I) + Dy(I)
            Next I

            For I = 1 To 10
                For J = I + 1 To 11
                    Call Collisioni(x(I), y(I), x(J), y(J), Dx(I), Dy(I), Dx(J), Dy(J))
                Next J
            Next I

            For I = 1 To 11
                ' --------------------------------------------------rimbalzo sponde
                If (x(I) > SpondaXmax) Then Dx(I) = -Math.Abs(Dx(I))
                If (x(I) < SpondaXmin) Then Dx(I) = Math.Abs(Dx(I))
                If (y(I) > SpondaYmax) Then Dy(I) = -Math.Abs(Dy(I))
                If (y(I) < SpondaYmin) Then Dy(I) = Math.Abs(Dy(I))
                ' ---------------------------------------------------tracciamento per colore
                If I = 1 Then SuperficieGrafica.FillEllipse(Brushes.Red, x(I), y(I), 10, 10)
                If I = 2 Then SuperficieGrafica.FillEllipse(Brushes.Green, x(I), y(I), 10, 10)
                If I = 3 Then SuperficieGrafica.FillEllipse(Brushes.Blue, x(I), y(I), 10, 10)
                If I = 4 Then SuperficieGrafica.FillEllipse(Brushes.Yellow, x(I), y(I), 10, 10)
                If I = 5 Then SuperficieGrafica.FillEllipse(Brushes.Cyan, x(I), y(I), 10, 10)
                If I = 6 Then SuperficieGrafica.FillEllipse(Brushes.Magenta, x(I), y(I), 10, 10)
                If I = 7 Then SuperficieGrafica.FillEllipse(Brushes.DarkGreen, x(I), y(I), 10, 10)
                If I = 8 Then SuperficieGrafica.FillEllipse(Brushes.DarkMagenta, x(I), y(I), 10, 10)
                If I = 9 Then SuperficieGrafica.FillEllipse(Brushes.LightSteelBlue, x(I), y(I), 10, 10)
                If I = 10 Then SuperficieGrafica.FillEllipse(Brushes.Violet, x(I), y(I), 10, 10)
                If I = 11 Then SuperficieGrafica.FillEllipse(Brushes.White, x(I), y(I), 10, 10)


                l = 0
                Do While (l < 400000)
                    l = l + 1
                    'Tempo di attesa
                Loop

            Next I

            'DoEvents
            My.Application.DoEvents()
        Loop

    End Sub

    Private Sub Collisioni(x1, y1, X2, Y2, Dx1, Dy1, Dx2, Dy2)

        Dim Pivot, Dxt, Dyt As Integer
        Pivot = 1

        If x1 <= X2 + 5 And x1 >= X2 - 5 And y1 <= Y2 + 5 And y1 >= Y2 - 5 Then

            '-------------
            If Dx1 > 0 And Dy1 > 0 And Dx2 < 0 And Dy2 > 0 And Pivot = 1 Then
                Dx1 = -Dx1 : Dx2 = -Dx2 : Pivot = 2
            End If

            If Dx1 > 0 And Dy1 < 0 And Dx2 < 0 And Dy2 < 0 And Pivot = 1 Then
                Dx1 = -Dx1 : Dx2 = -Dx2 : Pivot = 2
            End If

            If Dx1 > 0 And Dy1 < 0 And Dx2 > 0 And Dy2 > 0 And Pivot = 1 Then
                Dy1 = -Dy1 : Dy2 = -Dy2 : Pivot = 2
            End If

            If Dx1 < 0 And Dy1 < 0 And Dx2 < 0 And Dy2 > 0 And Pivot = 1 Then
                Dy1 = -Dy1 : Dy2 = -Dy2 : Pivot = 2
            End If
            '-------------
            If Dx2 > 0 And Dy2 > 0 And Dx1 < 0 And Dy1 > 0 And Pivot = 1 Then
                Dx1 = -Dx1 : Dx2 = -Dx2 : Pivot = 2
            End If

            If Dx2 > 0 And Dy2 < 0 And Dx1 < 0 And Dy1 < 0 And Pivot = 1 Then
                Dx1 = -Dx1 : Dx2 = -Dx2 : Pivot = 2
            End If

            If Dx2 > 0 And Dy2 < 0 And Dx1 > 0 And Dy1 > 0 And Pivot = 1 Then
                Dy1 = -Dy1 : Dy2 = -Dy2 : Pivot = 2
            End If

            If Dx2 < 0 And Dy2 < 0 And Dx1 < 0 And Dy1 > 0 And Pivot = 1 Then
                Dy1 = -Dy1 : Dy2 = -Dy2 : Pivot = 2
            End If
            '-------------
            If Dx1 > 0 And Dy1 < 0 And Dx2 > 0 And Dy2 < 0 And Pivot = 1 Then
                Dxt = Dx1 : Dyt = Dy1 : Dx1 = Dx2 : Dy1 = Dy2 : Dx2 = Dxt : Dy2 = Dyt : Pivot = 2
            End If
            If Dx1 < 0 And Dy1 < 0 And Dx2 < 0 And Dy2 < 0 And Pivot = 1 Then
                Dxt = Dx1 : Dyt = Dy1 : Dx1 = Dx2 : Dy1 = Dy2 : Dx2 = Dxt : Dy2 = Dyt : Pivot = 2
            End If
            If Dx1 > 0 And Dy1 > 0 And Dx2 > 0 And Dy2 > 0 And Pivot = 1 Then
                Dxt = Dx1 : Dyt = Dy1 : Dx1 = Dx2 : Dy1 = Dy2 : Dx2 = Dxt : Dy2 = Dyt : Pivot = 2
            End If
            If Dx1 < 0 And Dy1 > 0 And Dx2 < 0 And Dy2 > 0 And Pivot = 1 Then
                Dxt = Dx1 : Dyt = Dy1 : Dx1 = Dx2 : Dy1 = Dy2 : Dx2 = Dxt : Dy2 = Dyt : Pivot = 2
            End If
            '-------------
            If Dx1 > 0 And Dy1 < 0 And Dx2 < 0 And Dy2 > 0 And Pivot = 1 Then
                Dx1 = -Dx1 : Dx2 = -Dx2 : Pivot = 2
            End If

            If Dx1 > 0 And Dy1 > 0 And Dx2 < 0 And Dy2 < 0 And Pivot = 1 Then
                Dy1 = -Dy1 : Dy2 = -Dy2 : Pivot = 2
            End If

            If Dx2 > 0 And Dy2 < 0 And Dx1 < 0 And Dy1 > 0 And Pivot = 1 Then
                Dx1 = -Dx1 : Dx2 = -Dx2 : Pivot = 2
            End If

            If Dx2 > 0 And Dy2 > 0 And Dx1 < 0 And Dy1 < 0 And Pivot = 1 Then
                Dy1 = -Dy1 : Dy2 = -Dy2 : Pivot = 2
            End If

        End If
    End Sub

End Class
