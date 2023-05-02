using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class Dijkstra
    {
		/******************************************************
		 * 다익스트라 알고리즘 (Dijkstra Algorithm)
		 * 
		 * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
		 * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
		 ******************************************************/

		//A라는 목적지에서 B까지 가는 시간보다 중간에 C라는 경유를 통해서 가는 시간이 더 빠른경우
		//A에서B의 거리는 (A에서C를 가는거리 + B에서C로 가는 거리)로 바꿔준다.
		//직접적으로 가는 거리가 거쳐가는 거리보다 더 긴 경우에 거쳐가는 거리총 합을 직접적으로 가는 거리로 바꿔주고 그 작업을 반복하면 최단거리로 가는 길만 남는다


		const int INF = 99999;//오버플로우 때문에 Max를 안줌

		public static void ShortestPath(int[,] graph, int start, out int[] distance, out int[] path)
		{
			int size=graph.GetLength(0);
			bool[] visited=new bool[size];

			distance=new int[size];
			path=new int[size];
			for(int i=0;i<size;i++)
			{
				distance[i] = INF;
				path[i] = -1;
			}

			for(int i=0;i<size; i++)
			{
				//1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
				int minCost = INF;
				int next = -1;
				for(int j=0;j<size;j++)
				{
                    if (!visited[j] &&
                    distance[j] < minCost) 
					{
						next = j;
						minCost = distance[j];
					}
                }
				
				//2.직접연결된 거리보다 거쳐서 더 짧아진다면 갱신
				for(int j=0;j<size ; j++)
				{
					//distance[j] : 목적지까지 직접 연결된 거리
					//distance[next] : 탐색중인 정점까지 거리
					//graph[next, j] : 탐색중인 정점부터 목적지의 거리
					if (distance[j] < distance[next] + graph[next,j])
					{
						distance[j] = distance[next] + graph[next, j];
						path[j]=next;

                    }
				}
				visited[next]=true;//탐색이 끝난 것을 알림
			}
		}
    }
}
