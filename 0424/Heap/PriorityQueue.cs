using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0424.Heap
{
    internal class PriorityQueue<TElement>
    {
        private struct Node
        {
            public TElement element;    //값
            public int priority;        //우선순위
        }
        private List<Node> nodes;       //값과 우선순위를 배열로 저장할 List


        public PriorityQueue()
        {
            this.nodes = new List<Node>();//인스턴스 생성
        }
        public int Count { get { return nodes.Count; } }//배열의 크기 get

        public void Enqueue(TElement element, int priority)//새로운 값을 추가하는 함수
        {
            Node newNode = new Node() { element = element, priority = priority };//새로운 노드를 생성 새로운 값과 우선순위를 넣는다.

            // 1. 가장 뒤에 데이터 추가
            nodes.Add(newNode);//기존 노드에 가장 뒤에 데이터 입력
            int newNodeIndex = nodes.Count - 1;     //새로 추가된 노드의 index를 생성

            // 2. 새로운 노드를 힙상태가 유지되도록 승격 작업 반복
            while (newNodeIndex > 0)    //새로운 노드의 index가 0이 되면 최우선순위가 되었다는 뜻
            {
                //2-1부모 노드 확인
                int parentIndex = GetParentIndex(newNodeIndex); //부모위치를 찾는 함수를 실행하고 그값을 부모위치index에 저장
                Node parentNode = nodes[parentIndex];       //부모노드그릇을 생성
                //2-2 자식 노드가 부모 노드보다 우선순위가 높으면 교체
                if (newNode.priority < parentNode.priority)//새노드가 부모노드보다 우선순위가 높을경우
                {
                    nodes[newNodeIndex] = parentNode;//새노드의 위치에는 부모노드가 들어가고
                    nodes[parentIndex] = newNode;//부모노드위치에는 새 노드가 들어간다.
                    newNodeIndex = parentIndex; //새로운노드의 위치는 교환되었으므로 부모위치를 넣어준다.
                }
                else   //새노드의 우선순위가 부모보다 낮으니 여기까지 한다.
                {
                    break;
                }
            }
        }

        public TElement Dequeue()//맨 위에 있는 값을 내보내고 아래 있는 노드들을다시 올리는 함수
        {
            Node rootNode = nodes[0];// 맨 우선순위 값을 따로 저장
            //1.가장 마지막 노드를 최상단으로 위치
            Node lastNode = nodes[nodes.Count - 1]; //마지막 우선순위 노드의 element와 priority를 lastNode에 넣는다
            nodes[0] = lastNode;//마지막 순서 노드를 맨우선 순위 위치로 끌어 올린다.
            nodes.RemoveAt(nodes.Count - 1);//기존 마지막 노드의 위치를 지운다.

            int index = 0;//최우선순위 노드 위치를 생성
            //2. 자식 노드들과 비교하여 더 작은 자식과 교체
            while (index < nodes.Count)//nodes.Count보다 커질경우 비교할게 없으니 그전 까지 반복
            {
                int leftChildIndex = GetLeftChildIndex(index);//왼쪽 자식의 위치를 계산하는 함수를 실행 후 값을 넣어준다.
                int rightChildIndex = GetRightChildIndex(index);//오른쪽 자식의 위치를 계산하는 함수를 실행 후 값을 넣어준다.

                //2-1 자식이 둘 다 있는 경우
                if (rightChildIndex < nodes.Count)
                {
                    //2-1-1 왼쪽 자식과 오른쪽 자식을 비교하여 더 우선순위가 높은 자식을 선정
                    int lessCHildIndex = nodes[leftChildIndex].priority < nodes[rightChildIndex].priority//왼쪽 자식이 작을때는 왼쪽 자식이 왼쪽 자식이 클때는 오른쪽 자식이 들어간다.
                        ? leftChildIndex : rightChildIndex;
                    //2-1-2 더 우선순위가 높은 자식과 부모 노드를 비교하여
                    //부모가 우선순위가 더 낮은 경우 바꾸기
                    if (nodes[lessCHildIndex].priority < nodes[index].priority)//강등 작업은 위에 승격작업과 같다
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
                else if (leftChildIndex < nodes.Count)
                {
                    if (nodes[leftChildIndex].priority < nodes[index].priority)//강등작업은 위에 승격작업과 방법이 같다.
                    {
                        nodes[index] = nodes[leftChildIndex];
                        nodes[leftChildIndex] = lastNode;
                        index = leftChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else//2-3 자식이 없는경우
                {
                    break;//자식이 없는경우 마지막이라는 뜻이기도 하니 여기까지 한다.
                }
            }
            return rootNode.element;  //따로 저장해둔 우선순위 노드의 값을 내보낸다.
        }

        public TElement Peek() //가장 위에 있는 값을 내보내는 함수
        {
            return nodes[0].element;
        }


        private int GetParentIndex(int ChildIndex)//부모의 위치를 찾는 함수
        {
            return (ChildIndex - 1) / 2;
        }
        private int GetLeftChildIndex(int parentIndex)//왼쪽 자식의 위차값을 찾는 함수
        {
            return parentIndex * 2 + 1;
        }
        private int GetRightChildIndex(int parentIndex)//오른쪽 자식의 위치값을 찾는 함수
        {
            return parentIndex * 2 + 2;
        }
    }
}
