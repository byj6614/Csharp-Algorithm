using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    //index*2+1을 한다면 왼쪽 자식이 나온다 
    //index*2+2를 한다면 오른쪽 자식이 나온다
    //(index-1)/2를 한다면 부모가 나온다(나머지는 버린다고 생각하면 된다.)
    //깊이 순서대로 숫자를 넣는다.
    //새로운 데이터가 들어 왔을때는 일단 마지막에 넣어주고 그 마지막과 마지막 자리의 부모와 비교해서 부모보다 우선순위가 높다면 자식자리와 부모 자리의 교체를 한다.\
    //시간 복잡도
    //탐색(가장우선순위 높은)     추가      삭제
    //O(1)                     O(logN)   O(logN)
    //데이터를 삭제할땐 맨 마지막에 있는 자식 데이터를 맨 위에 있는 부모 자리로 끌고 온다
    //왼쪽 자식과 오른쪽 자식을 비교하고 가장 차이가 큰쪽으로 자리를 바꾼다
    internal class PriorityQueue<TElement>
    {
        private struct Node
        {
            public TElement element;
            public int priority;
        }
        private List<Node> nodes;


        public PriorityQueue() 
        {
            this.nodes = new List<Node>();
        }
        public int Count { get { return nodes.Count;} }

        public void Enqueue(TElement element, int priority)
        {
            Node newNode= new Node() { element=element, priority=priority};

            // 1. 가장 뒤에 데이터 추가
            nodes.Add(newNode);
            int newNodeIndex= nodes.Count - 1;

            // 2. 새로운 노드를 힙상태가 유지되도록 승격 작업 반복
            while(newNodeIndex > 0)
            {
                //2-1부모 노드 확인
                int parentIndex = GetParentIndex(newNodeIndex);  
                Node parentNode= nodes[parentIndex];
                //2-2 자식 노드가 부모 노드보다 우선순위가 높으면 교체
                if(newNode.priority < parentNode.priority)
                {
                    nodes[newNodeIndex] = parentNode;
                    nodes[parentIndex] = newNode;
                    newNodeIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public TElement Dequeue()//맨 위에 있는 값을 내보내고 아래 있는 힙들을 다시 올리는 함수
        {
            Node rootNode = nodes[0];
            //1.가장 마지막 노드를 최상단으로 위치
            Node lastNode = nodes[nodes.Count - 1];
            nodes[0] = lastNode;
            nodes.RemoveAt(nodes.Count-1);

            int index = 0;
            //2. 자식 노드들과 비교하여 더 작은 자식과 교체
            while(index < nodes.Count)
            {
                int leftChildIndex = GetLeftChildIndex(index);
                int rightChildIndex = GetRightChildIndex(index);

                //2-1 자식이 둘 다 있는 경우
                if(rightChildIndex<nodes.Count)
                {
                    //2-1-1 왼쪽 자식과 오른쪽 자식을 비교하여 더 우선순위가 높은 자식을 선정
                    int lessCHildIndex = nodes[leftChildIndex].priority < nodes[rightChildIndex].priority//왼쪽 자식이 작을때는 왼쪽 자식이 왼쪽 자식이 클때는 오른쪽 자식이 들어간다.
                        ? leftChildIndex : rightChildIndex;
                    //2-1-2 더 우선순위가 높은 자식과 부모 노드를 비교하여
                    //부모가 우선순위가 더 낮은 경우 바꾸기
                    if (nodes[lessCHildIndex].priority < nodes[index].priority)//
                    {
                        nodes[index] = nodes[lessCHildIndex];
                        nodes[lessCHildIndex] = lastNode;
                        index = lessCHildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                //2-2 자식히 하나만 있는 경우 == 왼쪽 자식만 있는 경우
                else if(leftChildIndex<nodes.Count)
                {
                    if (nodes[leftChildIndex].priority < nodes[index].priority)//왼쪽 자식과 비교해서 우선 순위가 높은지 확인
                    {
                        nodes[index]= nodes[leftChildIndex];
                        nodes[leftChildIndex]=lastNode; 
                        index=leftChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else//2-3 자식이 없는경우
                {
                    break;
                }
            }
            return rootNode.element;
        }

        public TElement Peek() //가장 위에 있는 값을 내보내는 함수
        {
            return nodes[0].element;
        }


        private int GetParentIndex(int ChildIndex)//부모의 위치를 찾는 함수
        {
            return (ChildIndex - 1) / 2;
        }
        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }
        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }
    }
}
