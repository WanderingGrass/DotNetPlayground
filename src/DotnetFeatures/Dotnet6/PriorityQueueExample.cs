namespace DotnetFeatures;

/// <summary>
/// 优先队列底层是使用二叉树，具体来说是最小堆。
/// 优先队列的元素类型必须实现IComparable接口，或者提供一个IComparer比较器。
/// 优先队列的元素类型必须实现IEquatable接口，或者提供一个IEqualityComparer比较器。
/// </summary>
public class PriorityQueueExample
{
    public void BasicExample()
    {
        // 创建一个优先队列，元素为string类型，优先级为int类型
        var priorityQueue = new PriorityQueue<string, int>();

        // 入队元素，第二个参数是优先级（数字越小优先级越高）
        priorityQueue.Enqueue("任务A", 3);
        priorityQueue.Enqueue("任务B", 1);
        priorityQueue.Enqueue("任务C", 2);

        // 查看队列中的元素数量
        Console.WriteLine($"队列中的元素数量: {priorityQueue.Count}"); // 输出: 3

        // 出队（会按照优先级从高到低出队）
        while (priorityQueue.TryDequeue(out string? item, out int priority))
        {
            Console.WriteLine($"处理任务: {item}, 优先级: {priority}");
        }
        // 输出顺序：
        // 处理任务: 任务B, 优先级: 1
        // 处理任务: 任务C, 优先级: 2
        // 处理任务: 任务A, 优先级: 3
    }

    public void CustomTypeExample()
    {
        // 使用自定义类型作为优先级的例子
        var taskQueue = new PriorityQueue<string, TaskPriority>();

        taskQueue.Enqueue("紧急任务", new TaskPriority { Urgency = 1, ImportanceLevel = 5 });
        taskQueue.Enqueue("普通任务", new TaskPriority { Urgency = 3, ImportanceLevel = 2 });
        taskQueue.Enqueue("低优先级任务", new TaskPriority { Urgency = 5, ImportanceLevel = 1 });

        // 使用Peek方法查看下一个要处理的元素，但不移除它
        if (taskQueue.TryPeek(out string? nextTask, out TaskPriority priority))
        {
            Console.WriteLine($"下一个要处理的任务: {nextTask}");
        }
    }

    // 自定义优先级类型
    private class TaskPriority : IComparable<TaskPriority>
    {
        public int Urgency { get; set; }          // 紧急程度（数字越小越紧急）
        public int ImportanceLevel { get; set; }  // 重要程度（数字越大越重要）

        public int CompareTo(TaskPriority? other)
        {
            if (other == null) return 1;

            // 首先比较紧急程度
            int urgencyComparison = Urgency.CompareTo(other.Urgency);
            if (urgencyComparison != 0)
                return urgencyComparison;

            // 如果紧急程度相同，则比较重要程度（注意这里是反向比较，因为重要程度数字越大越重要）
            return other.ImportanceLevel.CompareTo(ImportanceLevel);
        }
    }

    public void ClearAndCountExample()
    {
        var pq = new PriorityQueue<string, int>();

        // 添加一些元素
        pq.Enqueue("Item1", 1);
        pq.Enqueue("Item2", 2);

        // 清空队列
        pq.Clear();

        // 检查队列是否为空
        Console.WriteLine($"队列是否为空: {pq.Count == 0}"); // 输出: true
    }
}
