

FixedSlidingWindowConsumer();



//----------------------------Consumers----------------------------
void useBinarySearch()
{
    int[] numbers = { 2, 7, 8, 18, 20, 24, 29, 36, 40, 45, 51, 53, 60, 65, 69, 77, 81, 85, 91, 97 };
    Console.Write("enter the target number: ");
    var index = BinarySearchRecursive(numbers, Convert.ToInt32(Console.ReadLine()),0,numbers.Length-1);

    Console.WriteLine("target" + $"{(index != -1 ? $" found at `{index}`" : " not found")}");
}

void FixedSlidingWindowConsumer()
{
    int[] numbers = {17,11,40,18,51,24,29,36,12,45 };

    int windowSize = 3;
    //Console.WriteLine(MaxSumWithBruteForce(numbers, windowSize));
    Console.WriteLine(MaxSumWithFixedSlidingWindow(numbers, windowSize));

}
//---------------------------Code Logic----------------------------
                         // O(lgn)
int BinarySearchRecursive(int[] numbers, int target, int left, int right)
{
    if (left > right)
        return -1;

    int mid = left + (right - left) / 2;

    if (numbers[mid] == target)
        return mid;

    else if (target > numbers[mid])
        return BinarySearchRecursive(numbers, target, mid + 1, right);

    else
        return BinarySearchRecursive(numbers, target, left, mid - 1);
}
int BinarySearchIterative(int[] numbers, int target)
{
    int left = 0;
    int right = numbers.Length - 1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (numbers[mid] == target) return mid;

        else if (target > numbers[mid])
            left = mid + 1;

        else if (target < numbers[mid])
            right = mid - 1;
    }
    return -1;
}


int MaxSumWithBruteForce(int[]numbers , int windowSize ) // O(n*k) => could reach O(n^2)
{
    int max = 0;

    for (global::System.Int32 i = 0; i <= numbers.Length-windowSize; i++)
    {
        int windowSum = 0;
        for (global::System.Int32 j = i; j <i+ windowSize; j++)
        {
            windowSum += numbers[j];
        }
        if (windowSum > max) max = windowSum;
        

    }
    return max;
}
int MaxSumWithFixedSlidingWindow(int[] numbers , int windowSize ) // O(n)
{
    int maxSum =0 ,  windowSum = 0;

    for (int i = 0; i < windowSize; i++)
        windowSum += numbers[i];

    maxSum = windowSum;

    for (int i = windowSize; i < numbers.Length; i++)
    {
        windowSum += numbers[i] - numbers[i - windowSize];
        maxSum = Math.Max(windowSum,maxSum);
    }
    return maxSum;
}