using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0425.ABCD
{
    internal class BinarySearchTree<T> where T : IComparable<T>     //일반화를 제약을 걸어 비교가능한 것만 <T>에 들어가게 한다.
    {
        private Node root;  //트리형식 0깊이의 노드

        public BinarySearchTree()
        {
            this.root = null;//이 클래스를 사용시 null로 초기화

        }

        public void Add(T item)     //값을 추가하는 함수
        {
            Node newNode = new Node(item, null, null, null);        //새로운 노드는 item에 T item이라는 값과 left,right,parent의 값은 null로 비워준다
            if (root == null) //0깊이 자리가 비워져 있을경우
            {
                root = newNode; //newNode가 0깊이 자리로 간다.
                return;     //맨처음 추가한 값이라는 뜻이기도 하다.
            }

            Node current = root;    // current를 만들어 0깊이에 있는 노드를 넣어준다.
            while (current != null) // current가 비워질때 까지 반복
            {
                //a.CompareTo(b)는 a와 b를 비교해서 크다면 1을 작으면 -1을 같다면 0을 내보내는 함수
                //CompareTo를 통해서 작은경우 왼쪽 큰경우 오른쪽으로 가게 해주며 아래 if를 작성
                if (item.CompareTo(current.item) < 0)   //item이 current.item보다 작을 경우 왼쪽 자식
                {
                    //비교 노드가 왼쪽 자식이 있는 경우
                    if (current.left != null)
                    {
                        //왼쪽 자식과 또 비교하기 위해 current 왼쪽으로 설정
                        current = current.left;
                    }
                    //비교 노드가 왼쪽 자식이 없는경우
                    else
                    {
                        // 그자리가 지금 추가될 자리
                        current.left = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                else if (item.CompareTo(current.item) > 0) //item이 current.item보다 클 경우 오른쪽 자식
                {
                    //비교 노드가 오른쪽 자식이 있는 경우
                    if (current.right != null)
                    {
                        //오른쪽 자식과 또 비교하기 위해 current 오른쪽 자식으로 설정
                        current = current.right;
                    }
                    else//비교노드가 오른쪽 자식이 없는 경우
                    {
                        // 그자리가 지금 추가가 될 자리
                        current.right = newNode;
                        newNode = current;
                    }
                }
                //동일한 데이터가 들어온 경우
                else
                {
                    break;
                }
            }
        }
        public bool Remove(T item)  //item의 값을 찾아 지워주는 함수
        {
            Node findNode = FindNode(item);//findNode에 FindNode(item)으로 발견한 노드를 넣어준다.

            if (findNode == null)   //찾는 값이 없을 경우 
            {
                return false;   //false를 내보내준다.
            }
            else
            {
                EraseeNode(findNode); //값이 있다면 findNode의 노드를 지워주는 함수 실행
                return true;          //후 true를 내보낸다.
            }
        }
        public bool TryGetValue(T item, out T outValue) //T item의 값을 찾아 outValue의 넣어주며 비워져 있을때는 default(T)를 반환해주는 함수
        {
            Node findNode = FindNode(item); //FindNode를 통해서 값을 찾는다.
            if (findNode == null)   //찾는 값이 없을 경우
            {
                outValue = default(T);     
                return false;
            }
            else         //찾는 값이 있을 경우
            {
                outValue = findNode.item;  
                return true;
            }
        }
        private Node FindNode(T item)   //T item의 값을 노드에서 찾는 함수
        {
            if (root == null)   //root가 null인경우 노드가 아직 생성 안된 상태인 경우
                return null;    //null을 내보낸다.

            Node current = root;    //current에 root를 넣어준다.
            while (current != null) //current가 null이 될 때 까지 반복 해준다
            {
                if (item.CompareTo(current.item) < 0)//item이 current.item보다 클 경우
                {
                    //왼쪽 자식으로 내려가 반복하며 다시 찾기
                    current = current.left;
                }
                else if (item.CompareTo(current.item) > 0)//item이 current.item보다 클 경우
                {
                    //오른쪽 자식으로 내려가 반복하며 다시 찾기
                    current = current.right;
                }
                //현재 노드의 값이 찾고자 하는 값이랑 같은 경우
                else
                {
                    //찾음
                    return current;//current의(item,parent,left,right)노드를 내보낸다.
                }
            }
            return null;//찾는 값이 발견되지 않았으므로 null을 내보낸다.

        }
        private void EraseeNode(Node node)  //node를 지워주는 함수
        {
            if (node.HasNoChild)//HasNoChild메소드가 true일 경우 지울려는 node에 자식노드가 없는 경우다
            {
                if (node.IsLeftChild)   //IsLeftChild가 true일 경우 지금 node가 왼쪽 자식의 위치에 있는 경우
                    node.parent.left = null;    //이 node의 parent노드의 왼쪽자식(지금의 node)를 null로 지워준다.
                else if (node.IsRightChild) //IsRightChild가 true일 경우 지금 node가 오른쪽 자식의 위치에 있는 경우
                    node.parent.right = null;   //이 node의 parent노드의 오른쪽자식(지금의 node)를 null로 지워준다.
                else  //if(node.IsRootNode) //이노드가 root(0깊이에 있는 노드)인 경우
                    root = null;    //아래 자식도 없고 root 하나뿐이란 뜻이므로 root에 null 주어 지워준다. 
            }            
            else if (node.HasLeftchild || node.HasRightchild)   //||연산자를 통해 둘중 하나만 true라면 true이며 둘다  true일 경우 false를 주어 노드가 1개인 경우만 나타낸다.
            {
                //현 node의 부모와 자식노드를 이어 주어야 하기때문에 부모와 자식 노드를 만든다.
                Node parent = node.parent;  //부모노드 생성
                Node child = node.HasLeftchild ? node.left : node.right;    //자식 노드를 생성 현 노드가 왼쪽자식이 있을 경우 true인 node.left를 
                                                                            //false인 경우 오른쪽 자식이 있다는 뜻이므로 node.false를 넣어준다.
                if (node.IsLeftChild)   //노드가 부모노드의 왼쪽 자식일 경우
                {
                    parent.left = child;    //부모의 왼쪽 자식에 현node의 자식 노드를 넣어주며
                    child.parent = parent;  //자식 노드에 부모는 현node의 부모를 넣어주며 현node를 없애준다.
                }
                else if (node.IsRightChild) //노드가 부모노드의 오른쪽 자식일 경우
                {
                    parent.right = child;   //부모의 오른쪽 자식에 현node의 자식 노드를 넣어주며
                    child.parent = parent;  //자식 노드에 부모는 현node의 부모를 넣어주며 현node를 없애준다.
                }
                else //if(node.IsRootNode)      //현 노드가 root인 경우
                {
                    root = child;           //하나 연결된 자식 노드가 현 root 대신 들어가고
                    child.parent = null;  //root의 부모는 null이니 자식노드는 없어지고 null이 들어간다.
                }
            }
           
            else//if(node.HasBothChild)//자식 노드가 2개인 노드일 경우
                //왼쪽 자식중 가장 큰값과 데이터 교환한 후, 그 노드를 지워주는 방식으로 대체
            {
                Node replaceNode = node.left;   //현 노드의 왼쪽자식 노드를 생성
                while (replaceNode.right != null)//왼쪽 자식의 오른쪽으로 계속 진행
                {
                    replaceNode = replaceNode.right;//null이 나올때까지
                }
                node.item = replaceNode.item;//끝까지 도달해 반복이 중단되었을 경우 현node의item에 왼쪽 자식중 제일큰 값을 지니고 있는
                                             //replaceNode의 item을 넣어준다   
                EraseeNode(replaceNode);     //마지막 위치로 간 replaceNode는 없애주며 끝
                //반대로 오른쪽 자식의 왼쪽으로 null까지 계속 진행하는 방법도 가능
            }
        } 
        public class Node       //Node 클래스를 생성
        {   
            public T item;                
            public Node parent;
            public Node left;
            public Node right;

            public Node(T item, Node parent, Node left, Node right) //값을 초기화
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }
            public bool IsRootNode { get { return parent == null; } }   //node가 root인지 확인하는 메소드
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }   //node가 왼쪽자식인지 확인하는 메소드
            public bool IsRightChild { get { return parent != null && parent.right == this; } } //node가 오른쪽 자식인지 확인하는 메소드
            public bool HasNoChild { get { return left == null && right == null; } }    //node가 자식이 없는 노드인지 확인하는 메소드

            public bool HasLeftchild { get { return left != null && right == null; } }  //node가 왼쪽 자식이 있는지 확인하는 메소드

            public bool HasRightchild { get { return left == null && right != null; } } //node가 오른쪽 자식이 있는지 확인하는 메소드

            public bool HasBothChild { get { return left != null && right != null; } }  //node가 자식이 둘 다 있는지 확인하는 메소드
        } 
    }
}
