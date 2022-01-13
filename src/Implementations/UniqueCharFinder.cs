namespace Interview.Tests.Implementations;

public static class UniqueCharFinder
{
    /// <summary>
    /// Принимает на вход строку, а на выходе выдаёт первый символ, который встречается в строке ровно 1 раз, либо null, если такого символа нет
    /// </summary>
    /// <param name="input">Входная строка</param>
    /// <returns>Первый уникальный символ либо null, если такого нет</returns>
    public static char? FirstUnique(string input)
    {
        return input.GroupBy(c => c).FirstOrDefault(c => c.Count() == 1)?.Key;
    }
}