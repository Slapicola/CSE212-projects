using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue where the high priority number is at the end. A (10), B (9), C(7), D(10)
    // Expected Result: D, B, C, A
    // Defect(s) Found: The Dequeue Method never removed items from the queue.
    public void TestPriorityQueue_1()
    {

        var a = new PriorityItem("A", 1);
        var b = new PriorityItem("B", 9);
        var c = new PriorityItem("C", 7);
        var d = new PriorityItem("D", 10);

        PriorityItem[] expectedResult = [d, b, c, a];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(a.Value, a.Priority);
        priorityQueue.Enqueue(b.Value, b.Priority);
        priorityQueue.Enqueue(c.Value, c.Priority);
        priorityQueue.Enqueue(d.Value, d.Priority);

            int i = 0;
        while (priorityQueue.Length > 0)
        {
            var dequeuedLetter = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, dequeuedLetter);
            i++;
        }
        Assert.AreEqual(expectedResult.Length, i);

    }

    [TestMethod]
    // Scenario: Create a queue where there are multiple data values with high priority. A(9), B(10), C(7), D(10) 
    // Expected Result: B, D, A, C
    // Defect(s) Found: The Dequeue function was updating the index even if there were multiple values with high priority.
    public void TestPriorityQueue_2()
    {
        var a = new PriorityItem("A", 9);
        var b = new PriorityItem("B", 10);
        var c = new PriorityItem("C", 7);
        var d = new PriorityItem("D", 10);

        PriorityItem[] expectedResult = [b, d, a, c];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(a.Value, a.Priority);
        priorityQueue.Enqueue(b.Value, b.Priority);
        priorityQueue.Enqueue(c.Value, c.Priority);
        priorityQueue.Enqueue(d.Value, d.Priority);

            int i = 0;
        while (priorityQueue.Length > 0)
        {
            var dequeuedLetter = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, dequeuedLetter);
            i++;
        }
        Assert.AreEqual(expectedResult.Length, i);
    }

    // Add more test cases as needed below.
}