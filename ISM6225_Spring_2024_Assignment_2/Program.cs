using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                if (nums == null)
                {
                    return new List<int>(); //Edge case: if it is null, input is invalid
                }

                HashSet<int> seen = new HashSet<int>(); //Set up hashset
                foreach (int num in nums)  //Go through each number in nums
                {
                    seen.Add(num);  //Record number to the hashset
                }
                List<int> missing = new List<int>(); //Create the new list to collect all the missing numbers
                for (int i=1; i<=nums.Length; i++) //Loop from 1 to nums.Length 
                {
                    if (!seen.Contains(i)) //If a number is not in the seen set, it's missing
                    {
                        missing.Add(i); //Add that the missing number here
                    }
                }
                return missing; // Return the list of missing numbers

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                if (nums == null)
                {
                    throw new ArgumentException("Invalid input"); // Edge case: if input is null, input is invalid
                }
                int left = 0;
                int right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[left] % 2 > nums[right] % 2) // For both right and left, 1 if odd and 0 if even. 
                    {
                        int temp = nums[left]; //If left is pointing at an odd number and right is pointing at an even number, swap them.
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }

                    if (nums[left] % 2 == 0) //If left is already even, it's also in the right place, move left forward.
                    { left++; }
                    if (nums[right] % 2 == 1) //If right is already odd,it's also in the right place, move right backward.
                    { right--; }
                }
                return nums; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                if (nums == null || nums.Length < 2)
                {
                    throw new ArgumentException("Invalid input"); // Edge case: if input is null, input is invalid
                }

                Dictionary<int, int> seen = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int remain = target - nums[i];

                    if (seen.ContainsKey(remain))
                    {
                        return new int[] {seen[remain], i };
                    }

                   seen[nums[i]] = i; // Add current number and index
                }
                return new int[0]; // Edge case: no valid pair found
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 3)
                {
                    throw new ArgumentException("Invalid input"); // Edge case: if input is null, input is invalid
                }

                Array.Sort(nums); //Sort in ascending order

                int max1 = nums[nums.Length - 1];  // Get the first largest number
                int max2 = nums[nums.Length - 2];  // Get the second largest number
                int max3 = nums[nums.Length - 3];  // Get the third largest number
                int product1 = max1 * max2 * max3; // Get their product

                int min1 = nums[0];  //Edge case: Need to handle the case where negative * negative = positive
                int min2 = nums[1];
                int product2 = min1 * min2 * max1;

                return Math.Max(product1, product2);

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            { 
                if (decimalNumber == 0)  //Edge case: handle where the input is 0
                {
                    return "0";
                }
                if (decimalNumber < 0)
                {
                    throw new ArgumentException("No negative input"); //Edge case: handle negative inputs
                }
                List<int> binary = new List<int>();

                while (decimalNumber > 0)  
                {
                    int remainder = decimalNumber % 2; // To get the remainder
                    binary.Add(remainder);
                    decimalNumber /= 2;
                }
                binary.Reverse(); // To reverse the string
                string binaryString = string.Join("", binary);

                return binaryString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0) //Edge case: handle where the input is empty
                {
                    throw new ArgumentException("Invalid input");
                }

                int left = 0; //Left points to the first number
                int right = nums.Length - 1; //Right points to the last number

                while (left < right) //Repeat until left and right point to the same number
                {
                    int mid = (left + right) / 2;
                    if (nums[mid] > nums[right]) //If the middle number is bigger than the last, the smallest must be on the right
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid; //If the middle number is smaller or equal to the last, the smallest is on the left.
                    }
                }
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x<0)
                {
                    return false; // Edge case: Negative numbers are not palindromes
                }
                string text = x.ToString();
                char[] charArray = text.ToCharArray();
                Array.Reverse(charArray);
                string reversed = new string(charArray);

                return text == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n < 0)
                {
                    throw new ArgumentException("Invalid input"); // Edge case: handle negative inputs
                }

                if (n == 0)
                {
                    return 0; // Base case: Fibonacci(0) is 0
                }

                if (n == 1)
                {
                    return 1; // Base case: Fibonacci(1) is 1
                }

                return Fibonacci(n - 1) + Fibonacci(n - 2);

                int a = 0; // Edge case: An iterative approach or dynamic programming can help avoid stack overflow for large values of n. 
                int b = 1;
                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b;
                    a = b;
                    b = temp;
                }
                return b;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
