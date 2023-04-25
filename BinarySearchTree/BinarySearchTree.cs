using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructre
{
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node root;

        public BinarySearchTree()
        {
            this.root = null;

        }

        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null);
            if (root == null)
            {
                root = newNode;
                return;
            }

            Node current = root;
            while (current != null)
            {
                //비교해서 더 작은 경우 왼쪽으로 감
                if (item.CompareTo(current.item) < 0)
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
                //비교해서 더큰 경우 오른쪽으로 감
                else if (item.CompareTo(current.item) > 0)
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
        public bool Remove(T item)
        {
            Node findNode = FindNode(item);

            if (findNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool TryGetValue(T item, out T outValue)
        {
            Node findNode = FindNode(item);
            if (findNode == null)
            {
                outValue = default(T);
                return false;


            }
            else
            {
                outValue = findNode.item;
                return true;
            }
        }
        private Node FindNode(T item)
        {
            if (root == null)
                return null;

            Node current = root;
            while (current != null)
            {
                //현재 노드의 값이 찾고자 하는 값보다 작은 경우
                if (item.CompareTo(current.item) < 0)
                {
                    //왼쪽 자식부터 다시 찾기
                    current = current.left;
                }
                //현재 노드의 값이 찾고자 하는 값보다 큰 경우
                else if (item.CompareTo(current.item) > 0)
                {
                    //오른쪽 자식부터 다시 찾기 시작
                    current = current.right;
                }
                //현재 노드의 값이 찾고자 하는 값이랑 같은 경우
                else
                {
                    //찾음
                    return current;
                }
            }
            return null;

        }
        //1. 자식이 없는경우
        //2. 자식이 하나있는 경우 자식을 내 위치로 올린다
        //3.자식이 둘 다 있는 경우 부모보다 가장 가까우면서 크거나 작은 값을 올려준다(제일 까다로움)
        private void EraseeNode(Node node)
        {
            //자식 노드가 없는 노드일 경우
            if (node.HasNoChild)
            {
                if (node.IsLeftChild)
                    node.parent.left = null;
                else if (node.IsRightChild)
                    node.parent.right = null;
                else  //if(node.IsRootNode)
                    root=null;
            }

            //자식 노드가 1개인 노드일 경우
            else if (node.HasLeftchild||node.HasRightchild)
            {
                Node parent = node.parent;
                Node child=node.HasLeftchild? parent.left : parent.right;

                if(node.IsLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                }
               else if(node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                else //if(node.IsRootNode)
                {
                    root = child;
                    child.parent = parent;
                }
            }
            //자식 노드가 2개인 노드일 경우
            //왼쪽 자식중 가장 큰값과 데이터 교환한 후, 그 노드를 지워주는 방식으로 대체
            else//if(node.HasBothChild)
            {
                Node replaceNode = node.left;
                while(replaceNode.right!= null)//왼쪽 자식의 오른쪽으로 계속 진행
                {
                    replaceNode= replaceNode.right;//null이 나올때까지
                }
                node.item = replaceNode.item;
                EraseeNode(replaceNode);
                //반대로 오른쪽 자식의 왼쪽으로 null까지 계속 진행하는 방법도 가능
            }
        }
        public void Print()
        {
            Print(root);
        }
        public void Print(Node node)
        {
            if(node.left!=null) Print(node.left);
            Console.WriteLine(node.item);
            if(node.right!=null) Print(node.right);
        }
        public class Node
        {
            public T item;
            public Node parent;
            public Node left;
            public Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }
            public bool IsRootNode { get { return parent==null; } }
            public bool IsLeftChild { get { return parent != null&&parent.left==this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }
            public bool HasNoChild { get { return left==null&& right==null; } } 

            public bool HasLeftchild { get { return left!=null && right==null;} }

            public bool HasRightchild { get { return left==null && right!=null;} }

            public bool HasBothChild {  get { return left!=null && right!=null;} }
        }
    }
}
