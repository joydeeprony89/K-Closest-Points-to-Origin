using System;
using System.Collections.Generic;

namespace K_Closest_Points_to_Origin
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = new int[3][] { new int[] { 1, 3 }, new int[] { -2, 2}, new int[] { 2, -2 } };
            var results = KClosest(points, 2);
            foreach(var result in results)
                Console.WriteLine(string.Join(",", result));
        }

        // complexity O(NlogN)

        static public int[][] KClosest(int[][] points, int k)
        {
            SortedDictionary<double, List<int[]>> map = new SortedDictionary<double, List<int[]>>();
            foreach(int[] point in points)
            {
                int a = point[0], b = point[1];
                double distance = Math.Sqrt(a * a + b * b);
                if (!map.ContainsKey(distance))
                {
                    map.Add(distance, new List<int[]>());
                }
                map[distance].Add(point);
            }

            var result = new List<int[]>();
            foreach(List<int[]> x in map.Values)
            {
                result.AddRange(x);
                if (result.Count == k) return result.ToArray();
            }

            return result.ToArray();
        }
    }
}
