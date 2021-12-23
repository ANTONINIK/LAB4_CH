using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LAB4_CH
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    class TestCollections<TKey, Tvalue>
    {
        private List<TKey> tList;
        private List<string> strList;
        private Dictionary<TKey, Tvalue> keyDictionary;
        private Dictionary<string, Tvalue> strDictionary;
        private GenerateElement<TKey, Tvalue> generateElement;
        public TestCollections(int count, GenerateElement<TKey, Tvalue> j)
        {
            tList = new List<TKey>();
            strList = new List<string>();
            keyDictionary = new Dictionary<TKey, Tvalue>();
            strDictionary = new Dictionary<string, Tvalue>();
            generateElement = j;
            for (int i = 0; i < count; i++)
            {
                var element = generateElement(i);
                tList.Add(element.Key);
                strList.Add(element.Value.ToString());
                keyDictionary.Add(element.Key, element.Value);
                strDictionary.Add(element.Key.ToString(), element.Value);
            }
        }
        public void searchKeyList()
        {
            Console.WriteLine("List<TKey>...................");

            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();
            Stopwatch sw4 = new Stopwatch();
            var first = tList[0];
            var middle = tList[tList.Count / 2];
            var last = tList[tList.Count - 1];
            var notIncluded = generateElement(tList.Count + 1).Key;

            sw1.Start();
            tList.Contains(first);
            sw1.Stop();
            Console.WriteLine("search time of the first element: " + sw1.ElapsedTicks);

            sw2.Start();
            tList.Contains(middle);
            sw2.Stop();
            Console.WriteLine("search time of the middle element: " + sw2.ElapsedTicks);

            sw3.Start();
            tList.Contains(last);
            sw3.Stop();
            Console.WriteLine("search time of the last element: " + sw3.ElapsedTicks);

            sw4.Start();
            tList.Contains(notIncluded);
            sw4.Stop();
            Console.WriteLine("search time of the notIncluded element: " + sw4.ElapsedTicks);
        }
        public void searchStringList()
        {
            Console.WriteLine("List<string>...................");

            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();
            Stopwatch sw4 = new Stopwatch();
            var first = strList[0];
            var middle = strList[strList.Count / 2];
            var last = strList[strList.Count - 1];
            var notIncluded = generateElement(strList.Count + 1).Key.ToString();
            sw1.Start();
            strList.Contains(first);
            sw1.Stop();
            Console.WriteLine("search time of the first element: " + sw1.ElapsedTicks);

            sw2.Start();
            strList.Contains(middle);
            sw2.Stop();
            Console.WriteLine("search time of the middle element: " + sw2.ElapsedTicks);

            sw3.Start();
            strList.Contains(last);
            sw3.Stop();
            Console.WriteLine("search time of the last element: " + sw3.ElapsedTicks);

            sw4.Start();
            strList.Contains(notIncluded);
            sw4.Stop();
            Console.WriteLine("search time of the notIncluded element: " + sw4.ElapsedTicks);
        }
        public void searchDictionaryKey()
        {
            Console.WriteLine("Dictionary<TKey, Tvalue>...................");

            var first = keyDictionary.ElementAt(0).Key;
            var middle = keyDictionary.ElementAt(keyDictionary.Count / 2).Key;
            var last = keyDictionary.ElementAt(keyDictionary.Count - 1).Key;
            var notIncluded = generateElement(keyDictionary.Count + 1).Key;

            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();
            Stopwatch sw4 = new Stopwatch();
            sw1.Start();
            keyDictionary.ContainsKey(first);
            sw1.Stop();
            Console.WriteLine("search time of the first element: " + sw1.ElapsedTicks);

            sw2.Start();
            keyDictionary.ContainsKey(middle);
            sw2.Stop();
            Console.WriteLine("search time of the middle element: " + sw2.ElapsedTicks);

            sw3.Start();
            keyDictionary.ContainsKey(last);
            sw3.Stop();
            Console.WriteLine("search time of the last element: " + sw3.ElapsedTicks);

            sw4.Start();
            keyDictionary.ContainsKey(notIncluded);
            sw4.Stop();
            Console.WriteLine("search time of the notIncluded element: " + sw4.ElapsedTicks);
        }
        public void searchDictionaryByValue()
        {
            Console.WriteLine("Dictionary<string, Tvalue>...................");

            var first = keyDictionary.ElementAt(0).Value;
            var middle = keyDictionary.ElementAt(keyDictionary.Count / 2).Value;
            var last = keyDictionary.ElementAt(keyDictionary.Count - 1).Value;
            var notIncluded = generateElement(keyDictionary.Count + 1).Value;

            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();
            Stopwatch sw4 = new Stopwatch();

            sw1.Start();
            keyDictionary.ContainsValue(first);
            sw1.Stop();
            Console.WriteLine("search time of the first element: " + sw1.ElapsedTicks);

            sw2.Start();
            keyDictionary.ContainsValue(middle);
            sw2.Stop();
            Console.WriteLine("search time of the middle element: " + sw2.ElapsedTicks);

            sw3.Start();
            keyDictionary.ContainsValue(last);
            sw3.Stop();
            Console.WriteLine("search time of the last element: " + sw3.ElapsedTicks);

            sw4.Start();
            keyDictionary.ContainsValue(notIncluded);
            sw4.Stop();
            Console.WriteLine("search time of the notIncluded element: " + sw4.ElapsedTicks);
        }
    }
}
