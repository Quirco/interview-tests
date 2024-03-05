namespace Interview.Tests.Implementations;

public static class WindowSummator
{
    /// <summary>
    /// Осуществляет вычисление суммы массива методом скользящего окна
    /// </summary>
    /// <param name="input">Входной массив чисел</param>
    /// <param name="size">Ширина окна для суммирования</param>
    /// <returns>Выходной массив просуммированных значений</returns>
    public static IEnumerable<int> Window(int[] input, int size)
    {
        var sum = 0;
        for (var i = 0; i < size - 1; i++)
            sum += input[i];
        
        for (var i = size - 1; i < input.Length; i++)
        {
            sum += input[i];
            yield return sum;
            sum -= input[i - size + 1];
        }
    }
}