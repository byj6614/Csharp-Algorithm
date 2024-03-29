﻿namespace LinkedList
{
    internal class Program
    {
        /******************************************************
		 * 연결리스트 (Linked List)
		 * 
		 * 데이터를 포함하는 노드들을 연결식으로 만든 자료구조
		 * 노드는 데이터와 이전/다음 노드 객체를 참조하고 있음
		 * 노드가 메모리에 연속적으로 배치되지 않고 이전/다음노드의 위치를 확인
		 ******************************************************/

        // <링크드리스트 사용>
        void LinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            // 링크드리스트 요소 삽입
            linkedList.AddFirst("0번 앞데이터");
            linkedList.AddFirst("1번 앞데이터");
            linkedList.AddLast("0번 뒤데이터");
            linkedList.AddLast("1번 뒤데이터");

            // 링크드리스트 요소 삭제
            linkedList.Remove("1번 앞데이터");

            // 링크드리스트 요소 탐색
            LinkedListNode<string> findNode = linkedList.Find("0번 뒤데이터");

            // 링크드리스트 노드를 통한 노드 참조
            LinkedListNode<string> prevNode = findNode.Previous;
            LinkedListNode<string> nextNode = findNode.Next;

            // 링크드리스트 노드를 통한 노드 삽입
            linkedList.AddBefore(findNode, "찾은노드 앞데이터");
            linkedList.AddAfter(findNode, "찾은노드 뒤데이터");

            // 링크드리스트 노드를 통한 삭제
            linkedList.Remove(findNode);

            //링크드리스트는 배열형이 아니기에 접근이 연속적이지 않다
            //링크드리스트는 삽입 삭제가 빨라야 한다
        }
        //<List의 시간 복잡도>
        //접근    탐색   삽입     삭제
        //O(1)    O(n)   O(n)    O(n)


        // <LinkedList의 시간복잡도>      //가비지 콜렉터가 있기때문에 찬밥 신세
        // 접근		탐색		삽입		삭제
        // O(n)		O(n)	O(1)	O(1)

        static void Main(string[] args)
        {
            DataStructure.LinkedList<int> linkedList= new DataStructure.LinkedList<int>();

            linkedList.AddFirst(0);
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
                linkedList.AddFirst(3);
            linkedList.AddFirst(4);
            linkedList.AddFirst(5);
        }
    }
}