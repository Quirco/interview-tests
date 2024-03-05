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
        var result = new List<char>();
        List<TreeNode> parents = new();
        parents.Add(root);
        result.Add(root.Label);
        while (parents.Count != 0 && root is not null)
        {
            root = parents.FirstOrDefault();
            if (root is not null)
                parents.Remove(root);

            if (root is null)
                break;
            
            foreach (var child in root.Children)
            {
                result.Add(child.Label);
                parents.Add(child);
            }
        }
        return result.ToArray();
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