using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    /*["LRUCache","put","put","put","put","put","get","put","get","get","put","get","put","put","put","get","put","get","get","get","get","put","put","get","get","get","put","put","get","put","get","put","get","get","get","put","put","put","get","put","get","get","put","put","get","put","put","put","put","get","put","put","get","put","put","get","put","put","put","put","put","get","put","put","get","put","get","get","get","put","get","get","put","put","put","put","get","put","put","put","put","get","get","get","put","put","put","get","put","put","put","get","put","put","put","get","get","get","put","put","put","put","get","put","put","put","put","put","put","put"]
[[10],[10,13],[3,17],[6,11],[10,5],[9,10],[13],[2,19],[2],[3],[5,25],[8],[9,22],[5,5],[1,30],[11],[9,12],[7],[5],[8],[9],[4,30],[9,3],[9],[10],[10],[6,14],[3,1],[3],[10,11],[8],[2,14],[1],[5],[4],[11,4],[12,24],[5,18],[13],[7,23],[8],[12],[3,27],[2,12],[5],[2,9],[13,4],[8,18],[1,7],[6],[9,29],[8,21],[5],[6,30],[1,12],[10],[4,15],[7,22],[11,26],[8,17],[9,29],[5],[3,4],[11,30],[12],[4,29],[3],[9],[6],[3,4],[1],[10],[3,29],[10,28],[1,20],[11,13],[3],[3,12],[3,8],[10,9],[3,26],[8],[7],[5],[13,17],[2,27],[11,15],[12],[9,19],[2,15],[3,16],[1],[12,17],[9,1],[6,19],[4],[5],[5],[8,1],[11,7],[5,2],[9,28],[1],[2,2],[7,4],[4,22],[7,24],[9,26],[13,28],[11,26]]
*/
    /// <summary>
    /// https://leetcode.com/problems/lru-cache/
    /// </summary>
    class LruCacheImplementation
    {
        public LruCacheImplementation()
        {

        }

        public void Execute()
        {
            LRUCache obj = new LRUCache(10);
            int param_1 = obj.Get(12);
            obj.Put(12, 100);
        }
    }


    public class LRUCache
    {

        Dictionary<int, int> dict;
        int capacity;
        LinkedList<int> linkedList;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            dict = new Dictionary<int, int>();
            linkedList = new LinkedList<int>();
        }

        public int Get(int key)
        {
            if (dict.TryGetValue(key, out int result))
            {
                UpdateCache(key);
                return result;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (dict.ContainsKey(key))
            {
                UpdateCache(key);
                dict[key] = value;
            }
            else
            {
                //Adding new item, first check, and if full remove oldest item
                RemoveLruItem();
                linkedList.AddFirst(key);
                dict.Add(key, value);
            }
        }

        private void RemoveLruItem()
        {
            if (dict.Count == capacity)
            {
                int tobeDeleted = linkedList.Last.Value;
                linkedList.RemoveLast();
                //remove the item which is at front of Queue
                dict.Remove(tobeDeleted);
            }
        }

        private void UpdateCache(int key)
        {
            //remove old key, wherever it is
            linkedList.Remove(key);
            linkedList.AddFirst(key);
        }
    }
}
