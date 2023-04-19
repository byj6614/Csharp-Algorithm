using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _DataStructer
{
    /* 
        1. LinkedList 구현해보기
        AddFirst, AddLast,
        AddBefore, AddAfter,
        Remove(T value), Remove(node), Find
        + 주석 추가
        -------------------------------
        2. LinkedList 기술면접 준비
        -------------------------------
        0. msdn C# LinkedList 참고해서
     */
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
    public class LinkedList<T>
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

        public void AddFirst(T node)
        {
            //노드 생성
            LinkedListNode<T> newNode =new LinkedListNode<T>(this, node);
            //노드 연결
            if (head!=null)
            {
                newNode.next = head;            //newNode의 next에 head 주소를 넣는다.
                head = newNode;                 //head는 이제 newNode이므로 head에 newNd
            }
            else                                //head가 null일 경우 newNode가 head이며 tail가 된다.
            {
                head = newNode;
                tail = newNode;
            }
            //LinkedList 의 크기 증가
            count++;
        }
        public void AddLast(T node)
        {
            //노드 생성
            LinkedListNode<T> newNode=new LinkedListNode<T>(this, node);
            //노드 연결
            if (tail!=null)
            {
                newNode.prev = tail;        //newNode가 꼬리가 되어야 하므로 전에 주소에 tail을 넣는다.
                tail = newNode;             //newNode가 꼬리이므로 tail에 newNode 주소를 넣는다.
            }
            else                            //tail이 null 인경우 아무것도 없는거니 newNode가 꼬리이자 머리가 됨
            {
                tail = newNode;
                head = newNode;
            }
            //LinkedList 의 크기 증가
            count++;
        }
        public void AddBefore(LinkedListNode<T> before,T value)//(새로운 노드 뒤에.next, 새 노드에 들어갈 값)
        {
            if (before.list != this)//예외1 : node가 linkedList에 포함된 노드가 아닌경우
                throw new InvalidOperationException();

            if (before == null)//예외2 : 노드가 null인 경우
                throw new ArgumentNullException(nameof(before));
            //노드 생성
            LinkedListNode<T> newnode = new LinkedListNode<T>(this,value);
            //노드 연결
            if(head==before)//before가 head일 경우
            {
                before.prev= newnode;
                newnode.next= before;
                head = newnode;
            }
            else
            {
                newnode.prev = before.prev;         //newnode.prev는 before.prev와 before 사이에 들어감
                before.prev.next = newnode;         //before.prev.next는 before.prev의 next이며 newnode와 연결해준다
                before.prev = newnode;              //before 전에 newnode가 생성됨으로 넣는다.     
                newnode.next = before;              //newnode 다음에는 before가 있으므로 위와 연결 되는식
            }
            //LinkedList의 크기 증가
            count++;
        }
        public void AddAfter(LinkedListNode<T> after,T value)
        {
            if (after.list != this)//예외1 : node가 linkedList에 포함된 노드가 아닌경우
                throw new InvalidOperationException();

            if (after == null)//예외2 : 노드가 null인 경우
                throw new ArgumentNullException(nameof(after));
            //노드 생성
            LinkedListNode<T> newNode= new LinkedListNode<T>(this,value);
            //노드 연결
            if(tail==after) //after가 tail일 경우
            {
                newNode.prev = after;   //newNode전에 after가 연결된다
                after.next = newNode;   //after다음에 newNode가 연결되어 after와 newNode가 서로 연결됨
                tail= newNode;          //newNode를 꼬리로 만든다
            }
            else
            {
                after.next.prev = newNode;      //after.next의 prev에 newNode를 넣기
                newNode.next = after.next;      //newnode.next에 after.next를 넣기
                after.next= newNode;            //after.next에 newnode를 넣기
                newNode.prev = after;           //newNode.prev에 after를 넣기
            }
            //LinkedList의 크기 증가
            count++;
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
            //LinkedList 노드감소
            count--;
            

        }
        public bool Remove(T value)
        {
            LinkedListNode<T>? node = Find(value); //node를 Find()함수를 통해 값을 넣어준다
            if (node != null)   //null인경우 찾는 값이 없다는 뜻으로 false를 반환
            {
                Remove(node);   //node 노드를 지워주는 함수 실행
                return true;
            }
            else
            {
                return false;
            }
        }
        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> target = head;        //value가 들어가 있는 list의 head를 target에 주소복사
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;     
            while (target != null)  //target에 null이 발견될때까지 반복
            {
                if (comparer.Equals(value, target.Item))//Equals를 통해 value와 target.Item의 개체가 같은지 확인 같을시 true 아닐시 false
                    return target;  //true일시 target을 내보낸다
                else
                    target = target.next; //target의 next를 보기위해 null이 나올때까지
            }
            return null;
        }
    }
}
