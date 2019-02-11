// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
// You may assume that each input would have exactly one solution, and you may not use the same element twice.
// leet code problem, one pass hash table.

public class Solution {
    public int[] TwoSum(int[] arr, int target) {
        
        Dictionary<int, int> ht = new Dictionary<int, int>();
        
        for (int i = 0; i < arr.Length; i++)
        {
            
            int comp = target - arr[i];
            
            if (ht.ContainsKey(comp))
            {
                return new[] { ht[comp], i };   
            }
            
            ht[arr[i]] = i;
        }
        return arr;
    }
}