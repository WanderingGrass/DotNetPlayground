using DotnetFeatures;

namespace DotNetPlayground.Tests;

public class PriorityQueueTests
{
    private readonly PriorityQueueExample _example;

    public PriorityQueueTests()
    {
        _example = new PriorityQueueExample();
    }

    [Fact]
    public void BasicExample_ShouldDequeueInPriorityOrder()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        _example.BasicExample();
        var result = output.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        // Assert
        Assert.Equal("队列中的元素数量: 3", result[0]);
        Assert.Equal("处理任务: 任务B, 优先级: 1", result[1]);
        Assert.Equal("处理任务: 任务C, 优先级: 2", result[2]);
        Assert.Equal("处理任务: 任务A, 优先级: 3", result[3]);
    }

    [Fact]
    public void CustomTypeExample_ShouldPeekHighestPriorityTask()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        _example.CustomTypeExample();
        var result = output.ToString().Trim();

        // Assert
        Assert.Equal("下一个要处理的任务: 紧急任务", result);
    }

    [Fact]
    public void ClearAndCountExample_ShouldShowEmptyQueueAfterClear()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        _example.ClearAndCountExample();
        var result = output.ToString().Trim();

        // Assert
        Assert.Equal("队列是否为空: True", result);
    }

    [Fact]
    public void PriorityQueue_ManualTest()
    {
        // Arrange
        var queue = new PriorityQueue<string, int>();

        // Act
        queue.Enqueue("第三优先级", 3);
        queue.Enqueue("最高优先级", 1);
        queue.Enqueue("第二优先级", 2);

        // Assert
        Assert.Equal(3, queue.Count);

        queue.TryDequeue(out string? item1, out int priority1);
        Assert.Equal("最高优先级", item1);
        Assert.Equal(1, priority1);

        queue.TryDequeue(out string? item2, out int priority2);
        Assert.Equal("第二优先级", item2);
        Assert.Equal(2, priority2);

        queue.TryDequeue(out string? item3, out int priority3);
        Assert.Equal("第三优先级", item3);
        Assert.Equal(3, priority3);

        Assert.Equal(0, queue.Count);
    }
}
