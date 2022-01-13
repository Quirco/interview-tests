namespace Interview.Tests.Implementations;

public static class TreeIterator
{
    /// <summary>
    /// Осуществляет обход дерева вширь
    /// </summary>
    /// <param name="root">Корневой узел дерева</param>
    /// <returns>Метки узлов дерева вширь (слева направо, от менее глубоких узлов к более глубоким)</returns>
    public static char[] IterateTreeInWidth(TreeNode root)
    {
        // TODO: Ваша реализация метода
        throw new NotImplementedException();
    }

    /// <summary>
    /// Осуществляет обход дерева вглубь
    /// </summary>
    /// <param name="root">Корневой узел дерева</param>
    /// <returns>Метки узлов дерева вглубь</returns>
    public static char[] IterateTreeInDepth(TreeNode root)
    {
        // TODO: Ваша реализация метода
        throw new NotImplementedException();
    }

    /// <summary>
    /// Узел дерева
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// Метка узла (A, B, C и т.д.)
        /// </summary>
        public char Label { get; }

        /// <summary>
        /// Дочерние узлы
        /// </summary>
        public TreeNode[] Children { get; set; } = { };

        /// <summary>
        /// Создаёт узел с меткой
        /// </summary>
        /// <param name="label">Символьная метка узла</param>
        public TreeNode(char label)
        {
            Label = label;
        }
    }
}