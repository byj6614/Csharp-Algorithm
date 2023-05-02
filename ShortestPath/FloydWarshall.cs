using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class FloydWarshall
    {
        /******************************************************
		 * 플로이드-워셜 알고리즘 (Floyd-Warshall Algorithm)
		 * 
		 * 모든 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 모든 노드를 거쳐가며 최단 거리가 갱신되는 조합이 있을 경우 갱신
		 ******************************************************/

		//그래프에서 각각의 정점에서 다른정점까지 가는 최단 경로를 구하는 알고리즘
		//
		public static void ShortestPaht(int[,] graph,out int[,] costTable,out int[,] pathTabel)
		{
			int size=graph.GetLength(0);
			costTable=new int[size,size];
			pathTabel=new int[size,size];

			for(int y=0;y<size;y++)
			{
				for(int x=0;x<size;x++)
				{
					costTable[y, x] = graph[y, x];
					pathTabel[y, x] = -1;
				}
			}

			for(int middle=0;middle<size;middle++)
			{
				for(int start=0;start<size;start++)
				{
					for(int end=0;end<size;end++)
					{
						if (costTable[start,end] > costTable[start, middle] + costTable[middle,end])
						{
							costTable[start, end] = costTable[start, middle] + costTable[middle, end];
							pathTabel[start, end] = middle;
                        }
					}
				}
			}
		}
    }
}
