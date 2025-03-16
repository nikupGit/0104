Imports CarLibrary

Public Class PerformanceCar
    Inherits SportsCar
    Public Overrides Sub TurboBoost()
        Console.WriteLine("От нуля до 60 за 4,8 секунды!")
    End Sub
End Class

Module Module1

    Sub Main()
        Console.WriteLine("***** VB CarLibrary Client App *****")
        ' Локальные переменные объявляются с помощью ключевого слова Dim.
        Dim myMiniVan As New MiniVan()
        myMiniVan.TurboBoost()
        Dim mySportsCar As New SportsCar()
        mySportsCar.TurboBoost()
        Console.ReadLine()

        Dim dreamCar As New PerformanceCar()
        ' Использование унаследованного свойства.
        dreamCar.PetName = "Hank"
        dreamCar.TurboBoost()
        Console.ReadLine()

    End Sub


End Module
