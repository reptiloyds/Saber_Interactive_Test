using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Saber_Test
{
    public static class ListRandDeserializer
    {
        public static void Deserialize(FileStream fileStream, ListRand listRand)
        {
            CheckFileStreamFormat(fileStream);

            List<NodeContainer> nodeContainers = new List<NodeContainer>();
            bool inNode = false;
            while (true)
            {
                int currentByte = fileStream.ReadByte();

                if (currentByte == '{' && !inNode)
                {
                    inNode = true;
                    nodeContainers.Add(DeserializeNode(fileStream));
                }
                else if (currentByte == ',' && inNode)
                {
                    inNode = false;
                }
                else if (currentByte == -1)
                {
                    throw new Exception("Wrong char in FileStream");
                }
                else if (currentByte == ']')
                {
                    break;
                }
                else
                {
                    throw new Exception("Unexpected char in FileStream");
                }
            }

            FillList(listRand, nodeContainers);
        }

        private static void CheckFileStreamFormat(FileStream fileStream)
        {
            int firstByte = fileStream.ReadByte();
            if (firstByte == -1 || firstByte != '[')
            {
                throw new Exception("Wrong format of FileStream");
            }
        }

        private static NodeContainer DeserializeNode(FileStream fileStream)
        {
            ListNode node = new ListNode();
            Dictionary<string, string> nodeFields = new Dictionary<string, string>();
            int fieldCapacity = 3;
            for (int i = 0; i < fieldCapacity; i++)
            {
                ReadNodeField(',', fileStream, nodeFields);
            
            }
            ReadNodeField('}', fileStream, nodeFields);
            
            return new NodeContainer(
                node, 
                nodeFields[SerializeKeywords.DATA_KEYWORD], 
                nodeFields[SerializeKeywords.PREV_KEYWORD],
                nodeFields[SerializeKeywords.NEXT_KEYWORD], 
                nodeFields[SerializeKeywords.RAND_KEYWORD]
                );
        }

        private static void ReadNodeField(char stopCharacter, FileStream fileStream, Dictionary<string, string> nodeFields)
        {
            string line = ReadUntil(fileStream, stopCharacter);
            string[] typeValueString = line.Split(new[] { '=' }, 2);
            nodeFields.Add(typeValueString[0], typeValueString[1]);
        }

        private static string ReadUntil(FileStream fileStream, char stopCharacter)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (true)
            {
                int currentByte = fileStream.ReadByte();
                if (currentByte == -1)
                {
                    throw new Exception("Wrong character in FileStream");
                }

                if ((char)currentByte == stopCharacter)
                {
                    break;
                }

                if (currentByte == '\'')
                {
                    stringBuilder.Append(ReadUntil(fileStream, '\''));
                }
                else
                {
                    stringBuilder.Append((char)currentByte);
                }
            }

            return stringBuilder.ToString();
        }

        private static void FillList(ListRand listRand, List<NodeContainer> nodeContainers)
        {
            if (nodeContainers.Count == 0) return;
            
            ConvertContainersToNodes(nodeContainers);
            listRand.Head = nodeContainers[0].Node;
            listRand.Tail = nodeContainers[nodeContainers.Count - 1].Node;
            listRand.Count = nodeContainers.Count;
        }

        private static void ConvertContainersToNodes(List<NodeContainer> nodeContainers)
        {
            for (int i = 0; i < nodeContainers.Count; i++)
            {
                if (nodeContainers[i].Next != "null")
                {
                    nodeContainers[i].Node.Next = nodeContainers[int.Parse(nodeContainers[i].Next)].Node;
                }

                if (nodeContainers[i].Prev != "null")
                {
                    nodeContainers[i].Node.Prev = nodeContainers[int.Parse(nodeContainers[i].Prev)].Node;
                }

                if (nodeContainers[i].Rand != "null")
                {
                    nodeContainers[i].Node.Rand = nodeContainers[int.Parse(nodeContainers[i].Rand)].Node;
                }

                if (nodeContainers.Count > 1 && nodeContainers[i].Node.Next == null &&
                    nodeContainers[i].Node.Prev == null)
                {
                    throw new Exception("Unconnected node");
                }
            }
        }
    }
}