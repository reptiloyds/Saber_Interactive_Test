using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Saber_Test
{
    public static class ListRandSerializer
    {
        public static void Serialize(FileStream fileStream, ListRand listRand)
        {
            Dictionary<ListNode, int> dictionaryRand = ConvertListToDictionary(listRand);
            string serializedString = GetSerializedString(listRand, dictionaryRand);
            byte[] byteArray = ConvertStringToByteArray(serializedString);
            
            fileStream.Write(byteArray, 0, byteArray.Length);
        }
        
        private static Dictionary<ListNode, int> ConvertListToDictionary(ListRand listRand)
        {
            Dictionary<ListNode, int> dictionaryRand = new Dictionary<ListNode, int>();
            ListNode node = listRand.Head;
            int index = 0;
            while (node != null && !dictionaryRand.ContainsKey(node))
            {
                dictionaryRand.Add(node, index++);
                node = node.Next;
            }

            return dictionaryRand;
        }

        private static string GetSerializedString(ListRand listRand, Dictionary<ListNode, int> dictionaryRand)
        {
            StringBuilder stringBuilder = new StringBuilder();
            HashSet<ListNode> writtenNodes = new HashSet<ListNode>();
            stringBuilder.Append("[");
            ListNode currentNode = listRand.Head;
            while (currentNode != null)
            {
                WriteNode(currentNode, stringBuilder, dictionaryRand);
                
                writtenNodes.Add(currentNode);
                currentNode = currentNode.Next;

                if (currentNode == null || writtenNodes.Contains(currentNode))
                {
                    break;
                }

                stringBuilder.Append(",");
            }

            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        private static void WriteNode(ListNode node, StringBuilder stringBuilder,
            Dictionary<ListNode, int> dictionaryRand)
        {
            stringBuilder.Append("{");
            stringBuilder.Append($"{SerializeKeywords.DATA_KEYWORD}='{node.Data}',");
            stringBuilder.Append($"{SerializeKeywords.PREV_KEYWORD}={(node.Prev == null ? "null" : dictionaryRand[node.Prev].ToString())},");
            stringBuilder.Append($"{SerializeKeywords.NEXT_KEYWORD}={(node.Next == null ? "null" : dictionaryRand[node.Next].ToString())},");
            stringBuilder.Append($"{SerializeKeywords.RAND_KEYWORD}={(node.Rand == null ? "null" : dictionaryRand[node.Rand].ToString())}");
            stringBuilder.Append("}");
        }

        private static byte[] ConvertStringToByteArray(string line)
        {
            return new UTF8Encoding(true).GetBytes(line);
        }
    }
}