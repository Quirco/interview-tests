﻿using FluentAssertions;
using Interview.Tests.Implementations;
using Xunit;

namespace Interview.Tests;

public class Tests
{
    [Theory]
    [InlineData("abcacd", 'b')]
    [InlineData("", null)]
    [InlineData("abc", 'a')]
    [InlineData("cba", 'c')]
    [InlineData("abcabc", null)]
    [InlineData("adbceabc", 'd')]
    public void TestUniqueCharFinder(string input, char? expected)
    {
        // Act
        var res = UniqueCharFinder.FirstUnique(input);

        // Assert
        res.Should().Be(expected);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 2, new[] { 3, 5 })]
    [InlineData(new[] { 1, 2, 3 }, 1, new[] { 1, 2, 3 })]
    [InlineData(new[] { 1, 2, 3 }, 3, new[] { 6 })]
    public void TestWindowSummator(int[] input, int size, int[] expected)
    {
        // Act
        var res = WindowSummator.Window(input, size);

        // Assert
        res.Should().Equal(expected);
    }

    [Fact]
    public void TestTreeIterationInWidth()
    {
        // Arrange
        var rootNode = new TreeIterator.TreeNode('A')
        {
            Children = new[]
            {
                new TreeIterator.TreeNode('B')
                {
                    Children = new[]
                    {
                        new TreeIterator.TreeNode('D'),
                        new TreeIterator.TreeNode('E')
                    }
                },
                new TreeIterator.TreeNode('C')
                {
                    Children = new[]
                    {
                        new TreeIterator.TreeNode('F')
                    }
                },
            }
        };

        // Act
        var resInWidth = TreeIterator.IterateTreeInWidth(rootNode);

        // Assert
        resInWidth.Should().Equal(new[] { 'A', 'B', 'C', 'D', 'E', 'F' });
    }

    [Fact]
    public void TestTreeIterationInDepth()
    {
        // Arrange
        var rootNode = new TreeIterator.TreeNode('A')
        {
            Children = new[]
            {
                new TreeIterator.TreeNode('B')
                {
                    Children = new[]
                    {
                        new TreeIterator.TreeNode('D'),
                        new TreeIterator.TreeNode('E')
                    }
                }
            }
        };

        // Act
        var resInDepth = TreeIterator.IterateTreeInDepth(rootNode);

        // Assert
        resInDepth.Should().Equal(new[] { 'A', 'B', 'D', 'E', 'C', 'F' });
    }

    [Fact]
    public void TestChunker()
    {
        // Arrange
        var source = Enumerable.Range(0, 10).ToArray();

        // Act
        var chunked = source.SplitByChunks(3);

        var expectedResult = new List<IEnumerable<int>>
        {
            new[] { 0, 1, 2 },
            new[] { 3, 4, 5 },
            new[] { 6, 7, 8 },
            new[] { 9 }
        };

        // Assert
        var index = 0;
        foreach (var chunk in chunked)
        {
            chunk.Should().BeEquivalentTo(expectedResult[index++]);
        }

        index.Should().Be(4);
    }
}