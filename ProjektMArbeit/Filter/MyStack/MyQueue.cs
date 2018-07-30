namespace ProjektMArbeit.Filter.MyStack
{
    class MyQueue<T>
    {
        public class Node
        {
            private Node next;
            private Node prev;
            private T data;

            public Node(T _t)
            {
                next = null;
                prev = null;
                data = _t;
            }
            public Node Prev
            {
                get { return prev; }
                set { prev = value; }
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;
        private Node foot;
        public Node Head
        {
            get { return head; }
            set { head = value; }
        }

        public bool notEmpty()
        {
            if (head != null)
                return true;
            return false;
        }

        public bool notEmpty(T _t)
        {
            if (head != null)
                return true;
            else
            {
                Node tmp = new Node(_t);
                head = tmp;
                foot = tmp;
                return false;
            }
        }

        public void addFirst(T _t)
        {
            if (_t != null)
            {
                if (notEmpty(_t))
                {
                    Node insert = new Node(_t);
                    insert.Next = head;
                    insert.Prev = null;
                    head.Prev = insert;

                    head = insert;
                }
            }
        }

        public void addLast(T _t)
        {
            if (_t != null)
            {
                if (notEmpty(_t))
                {
                    //Node f = foot;
                    Node insert = new Node(_t);
                    insert.Next = null;
                    insert.Prev = foot;
                    foot.Next = insert;

                    foot = insert;
                }

            }
        }

        //ist das Element mitten drin
        //es wird vor current eingefügt
        public void addMiddle(T _t,Node _current)
        {
            if (_t != null)
            {
                Node tmp = new Node(_t);

                tmp.Next = _current;
                tmp.Prev = _current.Prev;
                _current.Prev.Next = tmp;
                _current.Prev = tmp;
            }
        }

        public T getFirstNode()
        {
            return head.Data;
        }

        public void deliteFirst()
        {
            if (notEmpty())
            {
                head = head.Next;
            }
        }
    }
}
