using System.Collections.Generic; // Needed for List<T>
using System.Linq; // Potentially useful for some list operations, though not strictly required for the chosen approach.
using System.Diagnostics; // For Debug.WriteLine() if you want to use it for debugging tests.

// Removed namespace declaration to put Arrays class in global namespace.
// This should resolve "CS0103: The name 'Arrays' does not exist in the current context" errors
// if the test file is not correctly referencing a specific namespace.
public class Arrays
{
    /// <summary>
    /// Creates and returns an array of multiples of a number.
    /// The starting number and the number of multiples are provided as inputs.
    /// </summary>
    /// <param name="start">The number to find multiples of.</param>
    /// <param name="count">The number of multiples to generate.</param>
    /// <returns>An array containing the multiples.</returns>
    public double[] MultiplesOf(int start, int count)
    {
        // Step 1: Declare a new array of doubles with the specified 'count'.
        // This array will hold our calculated multiples.
        double[] result = new double[count];

        // Step 2: Loop through the array 'count' times.
        // In each iteration, we'll calculate a multiple and store it.
        for (int i = 0; i < count; i++)
        {
            // Step 3: Calculate each multiple.
            // The first multiple is 'start * 1', the second is 'start * 2', and so on.
            // Since 'i' starts at 0, we use 'i + 1' to get the correct multiplier.
            result[i] = start * (i + 1);
        }

        // Step 4: Return the populated array.
        return result;
    }

    /// <summary>
    /// Rotates a list of data to the right by a specified amount.
    /// </summary>
    /// <param name="data">The list of integers to rotate.</param>
    /// <param name="amount">The number of positions to rotate to the right.</param>
    public void RotateListRight(List<int> data, int amount)
    {
        // Plan for RotateListRight:
        // This approach modifies the original 'data' list in place for efficiency.
        // We'll leverage List<T>'s built-in methods: GetRange, RemoveRange, and InsertRange.

        // Step 1: Handle edge cases.
        // If the list is empty, or the amount to rotate is 0, or if rotating by
        // the full length of the list (which brings it back to its original state),
        // there's nothing to do. The problem statement says 'amount' will be 1 to data.Count,
        // so 0 and data.Count are technically not in the range for 'amount', but good to consider generally.
        if (data == null || data.Count == 0 || amount % data.Count == 0)
        {
            return;
        }

        // Step 2: Calculate the effective rotation amount.
        // If 'amount' is greater than 'data.Count', we only care about the remainder
        // after dividing by data.Count, because rotating 'data.Count' times is
        // equivalent to no rotation at all.
        // Example: A list of 5 items rotated 7 times is same as rotated 2 times (7 % 5 = 2).
        int effectiveAmount = amount % data.Count;

        // Step 3: Determine the split point.
        // The elements from the end of the list (data.Count - effectiveAmount)
        // up to the end (data.Count - 1) will be moved to the beginning.
        int splitIndex = data.Count - effectiveAmount;

        // Step 4: Extract the elements that will move to the front.
        // Use GetRange to create a temporary list containing these elements.
        // The starting index for the range is 'splitIndex', and the number of elements
        // to extract is 'effectiveAmount'.
        List<int> suffix = data.GetRange(splitIndex, effectiveAmount);

        // Step 5: Remove these elements from their original position in the 'data' list.
        // Use RemoveRange, starting at 'splitIndex' and removing 'effectiveAmount' elements.
        data.RemoveRange(splitIndex, effectiveAmount);

        // Step 6: Insert the extracted elements at the beginning of the 'data' list.
        // Use InsertRange with an index of 0 (for the beginning) and the 'suffix' list.
        data.InsertRange(0, suffix);
    }
}