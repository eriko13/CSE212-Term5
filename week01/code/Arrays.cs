public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create a new array of doubles with the specified length to store the multiples
        double[] multiples = new double[length];

        // Loop through each position in the array (from 0 to length-1)
        for (int i = 0; i < length; i++)
        {
            // Calculate the multiple for this position
            // The first multiple (i=0) should be number * 1
            // The second multiple (i=1) should be number * 2
            // And so on...
            multiples[i] = number * (i + 1);
        }

        // Return the completed array of multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Calculate the effective rotation amount using modulo to handle cases where
        // amount might be larger than the list size (though the problem states it's 1 to data.Count)
        int effectiveAmount = amount % data.Count;

        // If the effective amount is 0, no rotation is needed (rotating by data.Count brings it back to original)
        if (effectiveAmount == 0)
        {
            return;
        }

        // Get the last 'effectiveAmount' elements that will move to the front
        // These are the elements from index (data.Count - effectiveAmount) to the end
        List<int> lastElements = data.GetRange(data.Count - effectiveAmount, effectiveAmount);

        // Get the first (data.Count - effectiveAmount) elements that will move to the end
        // These are the elements from index 0 to (data.Count - effectiveAmount - 1)
        List<int> firstElements = data.GetRange(0, data.Count - effectiveAmount);

        // Clear the original list to prepare for rebuilding
        data.Clear();

        // Add the last elements first (they move to the front after rotation)
        data.AddRange(lastElements);

        // Add the first elements after the last elements (they move to the end after rotation)
        data.AddRange(firstElements);
    }
}
