using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace heap_sort.cs
{
    class Program
    {
        static void Main(string[] args)
        
        {
            Console.WriteLine("Enter the size of an array:");
            int size = int.Parse(Console.ReadLine());
            int[] array = new int[size];
           

            Random rand = new Random(); // function to generate random numbers 
            int temp;
            
            for (int i = 0; i < array.Length; i++)
            {
                temp = rand.Next(size + 1);
                array[i] = temp;
            }
            Console.WriteLine("Before Heap sort");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            heapsort h = new heapsort();
            h.sort_ascending(array);
            Console.WriteLine("Sorted array in ascending order:");
            h.printarray(array);
            h.sort_descending(array);
            Console.WriteLine("Sorted array in descending order:");
            h.printarray(array);
        }
    }
    public class heapsort
    {
        public void sort_ascending(int[] array)
        {
          
            int n = array.Length;
            for (int i = n/2-1; i >=0 ; i--) // call root to build min heap 
            {
                heapify_min(array, n, i);
            }
            for (int i = n-1; i >=0; i--) // to dequeue the min element from the array 
            {
                int temp;
                temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                heapify_min(array, i, 0);
            }
           
        }
        public void heapify_min(int[] array, int n, int i) // to maintain heap property for minimum 
        {

            int smallest = i; //// Initialize smallest as root
            int L = 2 * i + 1; // initialize left of root 
            int R = 2 * i + 2; // initialize right of root 
            if (L < n && array[L] > array[smallest])
            {
                smallest = L;
            }
            if (R < n && array[R] > array[smallest])
            {
                smallest = R;
            }
            if (smallest != i)
            {
                int temp;
                temp = array[i];
                array[i] = array[smallest];
                array[smallest] = temp;
                heapify_min(array, n, smallest); // recursive calling to maintain heap property
            }
            
        }
       
        public void printarray(int[] array) // print array after sorting in ascending or descending  
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(array[i]);
            }
        }



        public void sort_descending(int[] array)
        {
           
            int n = array.Length;
           
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify_max(array, n, i);

            
            for (int i = n - 1; i >= 0; i--)
            {

              
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

               
                heapify_max(array, i, 0);
            }
           
        }
        public void heapify_max(int[] array, int n, int i) //to maintain a heap property for maximum
        {
           
            int largest = i; // Initialize largest as root 
            int l = 2 * i + 1; // initialize left of root
            int r = 2 * i + 2; // initiallize right of root 

            
            if (l < n && array[l] < array[largest])
                largest = l;

             
            if (r < n && array[r] < array[largest])
                largest = r;

            
            if (largest != i)
            {
                int temp = array[i];
                array[i] = array[largest];
                array[largest] = temp;

               
                heapify_max(array, n, largest); // recursive calling to maintain heapify property 
            }
          
        } 
    }
}
