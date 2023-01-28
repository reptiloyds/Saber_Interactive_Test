using System;
using System.Collections.Generic;
using System.IO;

namespace Saber_Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SerializeSample();
            DeserializeSample();
        }

        private static void DeserializeSample()
        {
            // ListRand list = new ListRand();
            // using (FileStream fs = new FileStream("test.json", FileMode.Open))
            // {
            //     list.Deserialize(fs);
            // }
            //
            // ListNode node = list.Head;
            // while (node != null)
            // {
            //     Console.WriteLine($"{SerializeKeywords.DATA_KEYWORD} = {node.Data} \n{SerializeKeywords.NEXT_KEYWORD} = {node.Next} \n{SerializeKeywords.PREV_KEYWORD} = {node.Prev} \n{SerializeKeywords.RAND_KEYWORD} = {node.Rand} \n");
            //
            //     node = node.Next;
            // }
            // Console.WriteLine(list.Count);
            // Console.ReadKey();
        }

        private static void SerializeSample()
        {
            // ListRand list = new ListRand();
            //
            // int capacity = 5;
            // List<ListNode> nodes = new List<ListNode>();
            // for (int i = 0; i < capacity; i++)
            // {
            //     ListNode currentNode = new ListNode() { Data = $"data_{i}" };
            //     nodes.Add(currentNode);
            //     if (i == 0)
            //     {
            //         list.Head = currentNode;
            //     }
            //     else
            //     {
            //         currentNode.Prev = nodes[i - 1];
            //         nodes[i - 1].Next = currentNode;
            //     }
            //     if (i == capacity - 1)
            //     {
            //         list.Tail = currentNode;
            //     }
            // }
            //
            // for (int i = 1; i < capacity-1; i++)
            // {
            //     Random random = new Random();
            //     int randomIndex = random.Next(0, capacity - 1);
            //     if (randomIndex == i)
            //     {
            //         randomIndex++;
            //     }
            //
            //     nodes[i].Rand = nodes[randomIndex];
            // }
            //
            // using (FileStream fs = new FileStream("test.json", FileMode.OpenOrCreate))
            // {
            //     list.Serialize(fs);
            // }
        }
    }
}