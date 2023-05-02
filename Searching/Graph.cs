using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
	internal class Graph
	{
		/******************************************************
		 * 그래프 (Graph)
		 * 
		 * 정점의 모음과 이 정점을 잇는 간선의 모음의 결합
		 * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가짐
		 * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
		 * 간선의 가중치에 따라   연결 그래프, 가중치 그래프가 있음
		 ******************************************************/
		//순환 구조가 하나라도 되는 순간이 그래프다
		//연결의 제한이 없다


		//인접행렬 그래프 경우 그래프 내의 각 정점의 인접 관계를 나타내는 행렬이며
		//2차원 배열을 [출발정점,도착정점]으로 표현
		//장접 : 인접여부 접근이 빠르다  O(1)
		//단점 : 메모리 사용량이 많다    O(n^2)

		//인접리스트 그래프는 그래프 내의 각 정점의 인접 관계를 표현하는건 리스트로 한다
		//인접한 간선만을 리스트에 추가하여 관리한다.
		//장접 : 메모리 사용량이 적다.  O(n)
		//단점 : 인접여부를 확인하기 위해 리스트 탐색이 필요하다. O(n)

		//<인접행렬 그래프>
		//2차원 배열을 통한 구현 [시작정점,끝정점] ex)[1,3] 1정점->3정점
		bool[,] matrixGraph1 = new bool[5, 5]
		{   {false,true, true, true ,true,},
			{true,false, true, false ,true,},
			{true,true, false, false,false,},
			{ true,false, false, false ,true,},
			{ true,true, false, true ,false,}
		};

		//가중치 그래-1로 단절을 표현할 수 있다.
		//최대값이면 단절이다 로 표현 할 수 있다.↓
		const int INF = int.MaxValue;
		int[,] matrixGraph2 = new int[5, 5]
		{
			{0,132,16,INF,INF },
			{ 12,132,16,INF,INF },
			{ 12,132,16,INF,INF },
			{ 12,132,16,INF,INF },
			{ 12,132,16,INF,INF }
		};

		
		//<인접리스트 그래프>
		List<List<int>> listGraph1;	//연결 그래프
		List<List<(int,int)>> listGraph2;	//가중치 그래프
		public void CreateGraph()
		{
			listGraph1 = new List<List<int>>();
			for(int i = 0;i < 5;i++)
			{
				listGraph1.Add(new List<int>());
			}
			listGraph1[0].Add(1);
			listGraph1[1].Add(0);
			listGraph1[1].Add(3);
		}

		//DFS BFS (중요)
		//<DFS> 깊이 우선 탐색(Depth-first- search)
		//그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
		//더 이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
		//백트래킹 방식(분할 정복)
		public static void DFS(bool[,] graph,int start,out bool[] visited,out int[] parent)
		{
			visited =new bool[graph.GetLength(0)];
			parent = new int[graph.GetLength(0)];

			for(int i=0;i<graph.GetLength(0);i++)
			{
				visited[i] = false;
				parent[i] = -1;
			}
			SearchNode(graph, start, visited, parent);//start부터 SearchNode를 하겠다
		}

		private static void SearchNode(bool[,] graph,int start, bool[] visited, int[] parent)
		{
			visited[start] = true;
			for(int i=0;i<graph.GetLength(0);i++)
			{
				if (graph[start,i] &&//연결되어 있는 정점이며,
					!visited[i])     //방문한적 없는 정점
				{
					parent[i] = start;
					SearchNode(graph,i, visited, parent);
				}
			}
		}
		//<BFS> 너비 우선 탐색(Breadth first search)
		//그래프의 분기를 만났을 때 모든 분기를 하나씩 저장하고,
		//저장한 분기를 한번씩 거치면서 탐색
		public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parent)
		{
            visited = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(0)];

			for (int i = 0; i < graph.GetLength(0); i++)
			{
				visited[i] = false;
				parent[i] = -1;
			}

			Queue<int> bfsQueue = new Queue<int>();

			bfsQueue.Enqueue(start);
			while(bfsQueue.Count > 0)
			{
				int next=bfsQueue.Dequeue();
				visited[next] = true;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[start, i] &&//연결되어 있는 정점이며,
                        !visited[i])     //방문한적 없는 정점
                    {
                        parent[i] = start;
						bfsQueue.Enqueue(i);
                    }
                }
            }
        }
    }
}
