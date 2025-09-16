using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue highest priority first
    // Expected Result: "High" (pri:10) dequeued first, then "Medium" (pri:5), then "Low" (pri:1)
    // Defect(s) Found: Expected "High" but got "Medium" - indicates priority comparison logic is incorrect
    public void TestPriorityQueue_BasicPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());    // Highest priority (10)
        Assert.AreEqual("Medium", priorityQueue.Dequeue());  // Next highest (5)
        Assert.AreEqual("Low", priorityQueue.Dequeue());     // Lowest (1)
    }

    [TestMethod]
    // Scenario: Add items with same priority and verify FIFO order when dequeuing
    // Expected Result: "First" dequeued first, then "Second", then "Third" (all same priority 5)
    // Defect(s) Found: Expected "First" but got "Second" - indicates loop not checking all elements properly
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());   // First in (FIFO)
        Assert.AreEqual("Second", priorityQueue.Dequeue());  // Second in
        Assert.AreEqual("Third", priorityQueue.Dequeue());   // Third in
    }

    [TestMethod]
    // Scenario: Mix of different and same priorities to test complex priority resolution
    // Expected Result: Highest priority items first, then FIFO within same priority
    // Defect(s) Found: Expected "A" but got "D" - same loop issue as above, not finding correct highest priority item
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 3);  // Priority 3
        priorityQueue.Enqueue("B", 1);  // Priority 1
        priorityQueue.Enqueue("C", 3);  // Priority 3 (same as A)
        priorityQueue.Enqueue("D", 5);  // Priority 5 (highest)
        priorityQueue.Enqueue("E", 1);  // Priority 1 (same as B)

        Assert.AreEqual("D", priorityQueue.Dequeue());  // Highest priority (5)
        Assert.AreEqual("A", priorityQueue.Dequeue());  // Priority 3, first in
        Assert.AreEqual("C", priorityQueue.Dequeue());  // Priority 3, second in
        Assert.AreEqual("B", priorityQueue.Dequeue());  // Priority 1, first in
        Assert.AreEqual("E", priorityQueue.Dequeue());  // Priority 1, second in
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - test passed correctly
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Test with negative priorities
    // Expected Result: Higher numbers have higher priority (negative numbers are lower priority)
    // Defect(s) Found: Expected "Positive" but got "Zero" - priority comparison logic issue
    public void TestPriorityQueue_NegativePriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Negative", -5);
        priorityQueue.Enqueue("Zero", 0);
        priorityQueue.Enqueue("Positive", 5);

        Assert.AreEqual("Positive", priorityQueue.Dequeue());  // Highest priority (5)
        Assert.AreEqual("Zero", priorityQueue.Dequeue());      // Medium priority (0)
        Assert.AreEqual("Negative", priorityQueue.Dequeue());  // Lowest priority (-5)
    }

    [TestMethod]
    // Scenario: Single item in queue
    // Expected Result: That single item should be dequeued correctly
    // Defect(s) Found: None - test passed correctly
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Only", 42);

        Assert.AreEqual("Only", priorityQueue.Dequeue());  // Should dequeue the only item
    }
}