namespace Saber_Test
{
    public struct NodeContainer
    {
        public readonly ListNode Node;
        public readonly string Prev;
        public readonly string Next;
        public readonly string Rand;

        public NodeContainer(ListNode node, string data, string previous, string next, string random)
        {
            Node = node;
            Node.Data = data;
            Prev = previous;
            Next = next;
            Rand = random;
        }
    }
}