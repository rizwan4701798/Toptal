using System;
using System.Diagnostics;
using System.IO;
using quick_code_test;
using System.Threading;

using System.Collections;
using System.Collections.Generic;

namespace TestConsoleApp
{

     public class ListNode
    {
      public int val;
      public ListNode next;
     public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
                 }
  }


  public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
                 }
  }


    class Node
    {

        public int Data;
        public Node LeftNode;
        public Node RightNode;

        public Node()
        {

        }

        public Node(int num)
        {
            this.Data = num;
        }
    }

    class BTree
    {

        public Node Root;
        public int MaxSum = 0;
        public string MaxSumPath = "";

        public Node GetRoot()
        {
            return Root;
        }

        public void FindMaxSumandPath(Node RootNode, int[] pathArray, int currentPathIndex)
        {

            if (RootNode == null)
            {
                return;
            }

            pathArray[currentPathIndex] = RootNode.Data;

            if (currentPathIndex > 0)
            {
                if ((IsEven(pathArray[currentPathIndex]) && IsEven(pathArray[currentPathIndex - 1])) || (IsOdd(pathArray[currentPathIndex]) && IsOdd(pathArray[currentPathIndex - 1])))
                {
                    return;
                }
            }
            currentPathIndex++;

            if (RootNode.LeftNode == null && RootNode.RightNode == null) // Bottom Node
            {

                int currentPathSum = 0;
                currentPathSum = GetPathSum(pathArray, currentPathIndex);

                if (currentPathSum > MaxSum)
                {
                    MaxSumPath = GetPath(pathArray, currentPathIndex);
                    MaxSum = currentPathSum;
                }
            }
            else
            {
                // recursive calls
                FindMaxSumandPath(RootNode.LeftNode, pathArray, currentPathIndex);
                FindMaxSumandPath(RootNode.RightNode, pathArray, currentPathIndex);
            }
        }

        public bool IsEven(int num)
        {
            return (num % 2 == 0) ? true : false;
        }

        public bool IsOdd(int num)
        {
            return (num % 2 == 0) ? false : true;
        }

        string GetPath(int[] ints, int len)
        {
            int i;
            string strPath = "";
            for (i = 0; i < len; i++)
            {
                strPath = strPath + ints[i].ToString();
                if (i < len - 1)
                    strPath = strPath + ", ";
            }

            return strPath;
        }

        int GetPathSum(int[] ints, int len)
        {
            int i;
            int pathSum = 0;
            for (i = 0; i < len; i++)
            {
                pathSum = pathSum + ints[i];
            }
            return pathSum;
        }


        public BTree()
        {

            Root = null;

        }

        public Node CreateNewNode(int data)
        {
            Node newNode = new Node();
            newNode.Data = data;
            newNode.LeftNode = null;
            newNode.RightNode = null;

            if (Root == null)
                Root = newNode;

            return (newNode);
        }


    }

    class Program
    {


        public static int sum = 0;
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return head;
            }

            // last node or only one node
            if (head.next == null)
            {
                return head;
            }

            ListNode newHeadNode = ReverseList(head.next);

            // change references for middle chain
            head.next.next = head;
            head.next = null;

            // send back new head 
            // node in every recursion
            return newHeadNode;
        }
        static int CompareString(string Str1, string Str2)
        {

            int firstIndex =  Str1.IndexOf(Str2);
            int secondIndex = Str1.LastIndexOf(Str2);

            if (firstIndex < 0)
            {
                return 0;
            }

            else if (firstIndex == secondIndex)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        
        }


        public static int CalPiontList(string[] ops)
        {
            int totalScore = 0;
            //  ArrayList arList = new ArrayList();
            var arList = new List<int>();





            for (int i = 0; i < ops.Length; i++)
            {
                int variable = 0;
                int.TryParse(ops[i], out variable);

                if (ops[i] == "D")
                {


                    arList.Add(2 * arList[arList.Count - 1]);
                }
                else if (ops[i] == "C")
                {
                    arList.RemoveAt(arList.Count - 1);
                }
                else if (ops[i] == "+")
                {
                    arList.Add(arList[arList.Count - 1]+ arList[arList.Count - 2]);
                }
                else
                {
                    arList.Add(variable);
                }
            }

            foreach (var item in arList)
            {
                totalScore = totalScore + int.Parse(item.ToString());
            }

            return totalScore;

        }

        public static int CalPiont(string[] ops)
        {
            int totalScore = 0;
            ArrayList arList = new ArrayList();

           

           

            for (int i = 0; i < ops.Length; i++)
            {
                int variable = 0;
                int.TryParse(ops[i], out variable);

                if (ops[i] == "D")
                {


                    arList.Add(2 * (int.Parse(arList[arList.Count - 1].ToString())));
                }
                else if (ops[i] == "C")
                {
                    arList.RemoveAt(arList.Count -1);
                }
                else if (ops[i] == "+")
                {
                    arList.Add( int.Parse(arList[arList.Count-1].ToString()) + int.Parse(arList[arList.Count - 2].ToString())) ;
                }
                else {
                    arList.Add(variable);
                }




            }

            foreach (var item in arList)
            {
                totalScore = totalScore + int.Parse(item.ToString());
            }

            return totalScore;
        
        } 


        public static int[] TwoSum(int[] nums, int target)
        {

            var numberNames = new Dictionary<int, int>();
            int[] ar = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
               if(!numberNames.ContainsKey(nums[i]))
                    numberNames.Add(nums[i], i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int result43;

                if (numberNames.TryGetValue(target - nums[i], out result43))
                {
                    if ((result43 > -1) && (result43 != i))
                    {
                        ar[0] = i;
                        ar[1] = result43;
                        break;

                    }
                }
            }
            return ar;
        }


        public static int CounElementsWithList(int[] arr)
        {

            Array.Sort(arr);
            int totalCount = 0;
            int duplicateCount = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0)
                {

                    if (arr[i] == arr[i - 1])
                    {
                        duplicateCount++;
                        continue;
                    }
                    else
                    {

                        if (i < arr.Length - 1)
                        {
                            if (arr[i] == arr[i + 1] - 1)
                            {
                                totalCount = totalCount + duplicateCount;
                            }
                            else {
                                duplicateCount = 1;
                            }
                        }
                        
                     
                    }

                }

               

            }

            return totalCount;

        }

        public static int CounElements(int[] arr)
        {

            Array.Sort(arr);
            int totalCount = 0;
            int duplicateCount = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0)
                {

                    if (arr[i] == arr[i - 1])
                    {
                        duplicateCount++;
                        continue;
                   
                    }
                    else {
                        duplicateCount = 1;
                    }

                }

                if (i < arr.Length - 1)
                {
                    if (arr[i] == arr[i+1] - 1)
                    {
                        totalCount = totalCount + duplicateCount;
                    }
                    else {
                        duplicateCount = 1;  
                      }
                }

            }

            return totalCount;
        
        }
        public static  string abInteger(int A, int B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            string Bigger = "a";
            string Smaller = "b";
            int nBigger = A;
            int nSmaller = B;
            string result = "";
            int difference = 0;
            bool isBigger = true;
            if (A > B)
            {
                Bigger = "a";
                Smaller = "b";
                difference = A - B;
                nBigger = A;
                nSmaller = B;
            }
            else
            {
                Bigger = "b";
                Smaller = "a";
                difference = B - A;
                nBigger = B;
                nSmaller = A;
            }
            for (int i = 0; i < difference;)
            {

                if (isBigger)
                {
                    result = result + Bigger + Bigger;
                    i = i + 2;
                    nBigger = nBigger - 2;
                    isBigger = false;
                }

                else 
                {

                    result = result + Smaller;
                    i++;
                    nSmaller = nSmaller - 1;
                    isBigger = true;
                }

            }
            var sum = nSmaller + nBigger;
            for (int i = 0; i < sum;)
            {
                if (isBigger)
                {
                    if (result.Length > 2)
                    { 
                    
                    }
                    if ((nBigger > 0) && ((result.Length> 2) || (result.Substring(result.Length-2) != Bigger + Bigger)))
                    { 
                        result = result + Bigger;

                    i = i + 1;
                    nBigger = nBigger - 1;
                }
                    isBigger = false;
                }
                else
                {
                    if ((nSmaller > 0) && ((result.Length > 2) || (result.Substring(result.Length - 2) != Smaller + Smaller)))
                    {
                        result = result + Smaller;
                        i++;
                        nSmaller = nSmaller - 1;
                    }
                    isBigger = true;
                }
            }

            return result;
        }

        public static void Solve(TreeNode root, TreeNode Parent)
        {
            if (root == null) return;
            if ((root.left == null) && (root.right == null) && (Parent.left == root))
            {
                sum = sum + root.val;

            }
            else
            {
                Solve(root.left, root);
                Solve(root.right, root);

            }

        }

        public static int SumOfLeftLeaves(TreeNode root)
        {

            Solve(root, root);
            return sum;


        }


        public static bool MakeEqual(string[] words)
        {
            int[] freq = new int[26];


            foreach (var word in words)
            {
                foreach (var chr in word)
                {
                    freq[chr - 'a']++;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                if (freq[i] % words.Length != 0)
                    return false;
            }

            return true;
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int nInidex = 0;
            int mInidex = 0;
            int[] result = new int[nums1.Length];
            int curElem = 0;

            if (n == 0)
            {
                return;
            }

            if (m == 0)
            {

                Array.Copy(nums2, nums1, nums2.Length);
                return;
            }

            int index = 0;
            for (int i = m; i < nums1.Length; i++)
            {
                nums1[i] = nums2[index++];
            }

            Array.Sort(nums1);
        }
        public static int MaxSubArray(int[] nums)
        {
            int MaxSum = nums[0];
            int currSum = 0;

            foreach (var num in nums)
            {
                if (currSum < 0) currSum = 0;
                currSum = currSum + num;
                MaxSum = Math.Max(MaxSum, currSum);


            }
            return MaxSum;
        }


        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            var dArray = new List<int> { };
            int nIndex = 0;
            int mIndex = 0;

            Array.Sort(nums1);
            Array.Sort(nums2);

            for (int i = 0; i < nums1.Length + nums2.Length; i++)
            {

                if (nIndex >= nums1.Length) break;
                if (mIndex >= nums2.Length) break;

                if (nums1[nIndex] == nums2[mIndex])
                {
                    dArray.Add(nums1[nIndex]);
                    nIndex++;
                    mIndex++;
                }

                else if (nums1[nIndex] > nums2[mIndex])
                {
                    mIndex++;
                }
                else
                {
                    nIndex++;

                }



            }

            return dArray.ToArray();

        }


        static void Main(string[] args)
        {


            //int[] num1 = new int[6] { 1, 2, 3, 0, 0, 0 };

            //int[] num2 = new int[3] { 2, 5, 6 };

            int[] num1 = new int[4] { 1,2,2,1};

            int[] num2 = new int[2] { 2,2};

            var ty = Intersect(num1, num2);



            Merge(num1, 1, num2, 1);


            string[] str77 = new string[3] { "abc", "aabc", "bc" };
            MakeEqual(str77);


            int[] intstaticIntArray1245 = new int[3] { 1,2,3};
            int grtr = CounElements(intstaticIntArray1245);

            int[] inst55 = new int[3] { 1, 2, 3 };





            string[] staticIntArray1245 = new string[5] { "5", "2", "C", "D", "+" };


            string[] staticIntArray12456 = new string[8] { "5", "-2", "4", "C", "D", "9", "+", "+" };

            CalPiontList(staticIntArray12456);

            SieveOfEratosthenes(50);

            #region code1

            int[][] jagged_arr =
  {
    new int[] {1, 2, 3, 4,7,8},
    new int[] {1, 2, 3, 4,7,8},
    new int[] {1, 2, 3, 4,7,8},
    new int[] {1, 2, 3, 4,7,8},
    new int[] {1, 2, 3, 4,7,8},
    new int[] {1, 2, 3, 4,7,8}
};



            int[][] jaggedArray = new int[5][];
            jaggedArray[0] = new int[3];
            jaggedArray[1] = new int[5];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[8];
            jaggedArray[4] = new int[10];
            jaggedArray[0] = new int[] { 3, 5, 7, };
            jaggedArray[1] = new int[] { 1, 0, 2, 4, 6 };
            jaggedArray[2] = new int[] { 1, 6 };
            jaggedArray[3] = new int[] { 1, 0, 2, 4, 6, 45, 67, 78 };
            jaggedArray[4] = new int[] { 1, 0, 2, 4, 6, 34, 54, 67, 87, 78 };

            int n1 = hourglassSum(jagged_arr);
            int[] staticIntArray12 = new int[7] { 200, -20, -20, -20, -20, -20, -20 };
            string[] staticIntArray13 = new string[7] { "2020-01-01", "2020-02-01", "2020-02-11", "2020-02-05", "2020-02-05", "2020-02-05", "2020-02-05" };
            solutionwitdDict(staticIntArray12, staticIntArray13);
            abInteger(3,3);
            //int[] staticIntArray12 = new int[3] { 3,2,4};
            TwoSum(staticIntArray12, 6);
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            var numberNames = new Dictionary<int, int>();
            numberNames.Add(0, 2); //adding a key/value using the Add() method
            numberNames.Add(1, 7);
            numberNames.Add(2, 9);
            int result43;
            if (numberNames.TryGetValue(0, out result43))
            {
                Console.WriteLine(result43);
            }
            int[] intArray;
            intArray = new int[5];
            //int[] intArray;
            //intArray = new int[100];

            #endregion
            #region code
            int[] staticIntArray = new int[3] { 1, 3, 5 };
            int[,] numbers = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            string[,] names = new string[2, 2] { { "Rosy", "Amy" }, { "Peter", "Albert" } };
            //int[,] numbers = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            //string[,] names = new string[,] { { "Rosy", "Amy" }, { "Peter", "Albert" } };
            var str23 = twoStrings("hi", "hello");
            Console.WriteLine(str23);
            int n = 100;   //Convert.ToInt32(Console.ReadLine());
            int[] ar = new int[100] { 50, 49, 38, 49, 78, 36, 25, 96, 10, 67, 78, 58, 98, 8, 53, 1, 4, 7, 29, 6, 59, 93, 74, 3, 67, 47, 12, 85, 84, 40, 81, 85, 89, 70, 33, 66, 6, 9, 13, 67, 75, 42, 24, 73, 49, 28, 25, 5, 86, 53, 10, 44, 45, 35, 47, 11, 81, 10, 47, 16, 49, 79, 52, 89, 100, 36, 6, 57, 96, 18, 23, 71, 11, 99, 95, 12, 78, 19, 16, 64, 23, 77, 7, 19, 11, 5, 81, 43, 14, 27, 11, 63, 57, 62, 3, 56, 50, 9, 13, 45 }; // Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
            int result = sockMerchant(n, ar);
            Console.WriteLine(result);
            Console.ReadLine();

            //  textWriter.WriteLine(result);
            ///// textWriter.Flush();
            // textWriter.Close();
            Random rnd = new Random();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            HighlyOptimizedThreadSafeDuplicateCheckService service = new HighlyOptimizedThreadSafeDuplicateCheckService();
            //for (int i = 0; i < 1000000; i++)
            //{
            //    service.IsThisTheFirstTimeWeHaveSeen(rnd.Next(1, 1000000));
            //}

            Thread[] threads = new Thread[20];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(service.IsThisTheFirstTimeWeHaveSeenTest);
            }
            foreach (Thread thread in threads)
            {
                thread.Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadLine();
            result = CompareString("tretr", "tr");
            Console.WriteLine(result);
            Console.ReadLine();
            Console.WriteLine("Hello World!");
            var bytes = FileToByteArray("D:/TimeSolv/mmm.docx");
            var str = System.Text.Encoding.Default.GetString(bytes);
            int a = 0;
            #endregion
        }
        public static byte[] FileToByteArray(string fileName)
        {
            byte[] fileData = null;

            using (FileStream fs = File.OpenRead(fileName))
            {
                var binaryReader = new BinaryReader(fs);
                fileData = binaryReader.ReadBytes((int)fs.Length);
            }
            return fileData;
        }
        public static int solutionwitdDict(int[] A, string[] D)
        {
            int totalBalace = 0;
            string currentMonth = "";
            var freeMonth = new int[12];
            int index = 0;
            int freeMonthCounter = 12;

            var dict = new Dictionary<int, string>();

            for (int i = 0; i < A.Length; i++)
            {
                totalBalace = totalBalace + A[i];
                if (A[i] < 0)
                {
                    var arrD = D[i].Split('-');

                    currentMonth = arrD[1].ToString();
            
                        index = Int32.Parse(currentMonth);
                        if (dict.ContainsKey(index))
                        {
                            var dictvalue = "";
                            if (dict.TryGetValue(index, out dictvalue))
                            {
                                var arrdictvalue = dictvalue.Split(',');

                                var counter =  Int32.Parse(arrdictvalue[0]) + 1;
                                var sum = Int32.Parse(arrdictvalue[1]) + A[i];
                                dict.Remove(index);

                           
                                dict.Add(index, counter + "," + sum);
                            }
                        }
                        else
                        {
                        dict.Add(index, "1" + "," + A[i]);
                        }    
                }
            }

            foreach (KeyValuePair<int, string> entry in dict)
            {
                var arrValue = entry.Value.Split(',');
                if ((Int32.Parse(arrValue[0]) >= 3) && (Int32.Parse(arrValue[1]) <= -100))
                {
                    freeMonthCounter = freeMonthCounter - 1;
                }
            }

            totalBalace = totalBalace - (5 * freeMonthCounter);
            return totalBalace;
        }
        public static int solution123(int[] A, string[] D)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            // write your code in Java SE 8
            int totalBalace = 0;
            int currentMonthCounter = 1;
            int currentMonthTransactions = 0;
            string currentMonth = "";
            var freeMonth = new int[12];
            int index = 0;
            int freeMonthCounter = 12;



            for (int i = 0; i < A.Length; i++)
            {
                totalBalace = totalBalace + A[i];
                if ((i > 0) && (A[i] < 0))
                {
                    var arrD = D[i].Split('-');

                    currentMonth = arrD[1].ToString();
                    var arrD1 = D[i - 1].Split('-');
                    var previousMonth = arrD1[1].ToString();


                    if ((currentMonth == previousMonth))
                    {
                        currentMonthTransactions = currentMonthTransactions + A[i];
                        currentMonthCounter = currentMonthCounter + 1;
                        if ((currentMonthCounter >= 3) && (currentMonthTransactions <= -100))
                        {
                            index = Int32.Parse(currentMonth);
                            freeMonth[index] = 1;
                        }
                    }
                    else
                    {
                        currentMonthTransactions = A[i];

                    }
                }

            }

            for (int i = 0; i < freeMonth.Length; i++)
            {
                if (freeMonth[i] > 0)
                    freeMonthCounter = freeMonthCounter - 1;
            }
            totalBalace = totalBalace - (5 * freeMonthCounter);

            return totalBalace;

        }

        public bool SearchMatrix(int[][] matrix, int target)
        {

            int pos = -1;
            for (int j = 0; j < matrix.Length; j++)
            {
                for (int k = 0; k < matrix[j].Length; k++)
                {
                    if ((matrix[j][k] > target) || (matrix[j][matrix[j].Length - 1] < target))
                    {
                        continue;
                    }
                    else
                    {
                        pos = Array.BinarySearch(matrix[j], target);
                    }
                }
            }

            if (pos > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int hourglassSum(int[][] arr)
        {
            int maxSum = -100000;
            int currentSum = 0;

            for (int j = 0; j < arr.Length - 2; j++)
            {
                for (int k = 0; k < arr[j].Length - 2; k++)
                {
                    currentSum = arr[j][k] + arr[j][k+1] + arr[j][k+2] + arr[j + 1][k + 1] + arr[j+2][k] + arr[j + 2][k + 1] + arr[j + 2][k + 2]; //+ arr[k+1][l] + arr[k + 2] + 
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            
            return maxSum; 
        }

        public static void SieveOfEratosthenes(int n)
        {

      
            bool[] prime = new bool[n + 1];

            for (int i = 0; i < n; i++)
                prime[i] = true;

            for (int p = 2; p * p <= n; p++)
            {
                // If prime[p] is not changed,
                // then it is a prime
                if (prime[p] == true)
                {
                    // Update all multiples of p
                    for (int i = p * p; i <= n; i += p)
                        prime[i] = false;
                }
            }

            // Print all prime numbers
            for (int i = 2; i <= n; i++)
            {
                if (prime[i] == true)
                    Console.Write(i + " ");
            }
        }

        // Complete the sockMerchant function below.
        static int sockMerchant(int n, int[] ar)
        {

            int Count = 0;
            string strHolder = "";

            if (n < 2)
            {
                return Count;
            }

            for (int i = 0; i < n; i++)
            {
                if (strHolder.IndexOf("," + ar[i].ToString() + ",") > -1)
                {
                    strHolder = strHolder.Remove(strHolder.IndexOf("," + ar[i].ToString() + ","), ar[i].ToString().Length + 2);
                    Count++;
                }
                else
                {
                    strHolder = strHolder + "," + ar[i].ToString() + ",";
                }
            }

            return Count;
        }

        static  int smallest(int[] A)
        {
            Hashtable my_hashtable1 = new Hashtable();

            for (int j = 0; j < A.Length; j++)
            {
                if (!my_hashtable1.Contains(A[j].ToString().GetHashCode()))
                    my_hashtable1.Add(A[j].ToString().GetHashCode(), A[j]);
            }

            for (int i = 1; i < 1000000; i++)
            {
                if (!my_hashtable1.Contains(i.ToString().GetHashCode()))
                {
                    return i;

                }
            }

            return 1000000;

        }

        public static int binaryGap(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Modfasdfsad

            string binary = Convert.ToString(N, 2);

            var s1arr = binary.ToCharArray();

            int CurrentCount = -1;
            int MaxCount = -1;

            for (int i = 0; i < s1arr.Length; i++)
            {
                if ((s1arr[i] == '1') && (CurrentCount == -1))
                {
                    CurrentCount = 0;
                }

                if ((s1arr[i] == '0') && (CurrentCount > -1))
                {
                    CurrentCount++;
                }

                if ((s1arr[i] == '1') && (CurrentCount > 0))
                {
                    if (CurrentCount > MaxCount)
                    {
                        MaxCount = CurrentCount;
                    }

                    CurrentCount = 0;

                }
            }

            if (MaxCount == -1)
            {

                return 0;
            }
            else
            {
                return MaxCount;
            }

        }

        static string twoStrings(string s1, string s2)
        {
            var s1arr = s1.ToCharArray();
            var s2arr = s2.ToCharArray();

            Hashtable my_hashtable1 = new Hashtable();
            Hashtable my_hashtable2 = new Hashtable();

            for (int i = 0; i < s1arr.Length; i++)
            {
                if (!my_hashtable1.Contains(s1arr[i].ToString().GetHashCode()))
                    my_hashtable1.Add(s1arr[i].ToString().GetHashCode(), s1arr[i]); //   GetHashString(s1arr[i].ToString()));
            }

            for (int j = 0; j < s2arr.Length; j++)
            {
                if (!my_hashtable2.Contains(s2arr[j].ToString().GetHashCode()))
                    my_hashtable2.Add(s2arr[j].ToString().GetHashCode(), s2arr[j]);
            }

            foreach (DictionaryEntry item in my_hashtable1)
            {
                if (my_hashtable2.ContainsKey(item.Key))
                {
                    return "Yes";
                }

                //}

                return "No";
            }
            return "No";

        }

    }
}
