using System.IO;

namespace Saber_Test
{
    public class ListRand
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(FileStream s)
        {
            ListRandSerializer.Serialize(s, this);
        }

        public void Deserialize(FileStream s)
        {
            ListRandDeserializer.Deserialize(s, this);
        }
    }
}