using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;
        internal LinkedListNode<T> next;
        private T item;

        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }

        public T Item { get { return item; } set { item = value; } }
    }
    public class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddFirst(T value)
        {
            //1.새로운 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            //2연결구조 바꾸기
            if (head != null)//2-1 Head 노드가 있었을 때
            {
                newNode.next = head;
                head.prev= newNode;
                head = newNode;
            }
            else //2-2 Head 노드가 없었을 때
            {
                head = newNode;
                tail = newNode;
            }
            count++;

            return newNode;
        }
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            if (node.list != this)//예외1 : node가 linkedList에 포함된 노드가 아닌경우
                throw new InvalidOperationException();

            if (node == null)//예외2 : 노드가 null인 경우
                throw new ArgumentNullException(nameof(node));
            //1.새로운 노드 만들기
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            //2.연결구조 바꾸기
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            if (node.prev != null)
                node.prev = newNode;
            else
                head = newNode;
            //3.갯수 증가
            count++;
            return newNode;
        }
        public LinkedListNode<T> AddLast(T value)
        {

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (tail != null)
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            else
            {
                head = newNode;
                tail = newNode;
            }
            count++;
            return newNode;
        }


        public void Remove(LinkedListNode<T> node)
        {
            if (node.list != this)//예외1 : node가 linkedList에 포함된 노드가 아닌경우
                throw new InvalidOperationException();

            if (node == null)//예외2 : 노드가 null인 경우
                throw new ArgumentNullException(nameof(node));
            //0.지웠을 때 head나 tail이 변경되는 경우
            if (head == node)
                head = node.next;
            if (tail == node)
                tail = node.prev;
            //1.연결구조 바꾸기
            if (node.prev != null)
                node.prev.next = node.next;       //node(지우려는것).prev(이전의).next(다음)
            if (node.next != null)
                node.next.prev = node.prev;       //node(지우려는것).next(다음의).prev(이전)
            count--;
            //2.노드지우기

        }
        public bool Remove(T value)
        {
            LinkedListNode<T> findnode = Find(value); //찾기
            if (findnode != null)
            {
                Remove(findnode);
                return true;
            }
            else
            {
                return false;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> target = head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            while (target != null)
            {
                if (comparer.Equals(value, target.Item))
                    return target;
                else
                    target = target.next;
            }
            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private LinkedListNode<T> node;
            private LinkedList<T> list;
            private T current;

            public Enumerator(LinkedList<T> list)
            {
                this.list = list;
                this.node=list.head;
                this.current = default(T);
            }
            public T Current {get { return current; } }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
               
            }

            public bool MoveNext()
            {
                if(node != null)
                {
                    current = node.Item;
                    node=node.next;
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
                
            }

            public void Reset()
            {
                node = list.head;
                current = default(T);
            }
        }
    }
}
