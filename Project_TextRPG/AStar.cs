using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    internal class AStar
    {
        /******************************************************
		 * A☆ 알고리즘
		 * 
		 * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		 * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
		 ******************************************************/
        //다익스트라와 다르게 가장 가까운 접점을 검색하는것이 아닌
        //경로 탐색을 우선으로 탐색을 한다
        //f =g+h  총거리
        //g =걸린거리
        //h =예상거리(휴리스택)
        //f값이 가장 작은 정점을 탐색한 정점의 f값
        //대각선은 루트2 칸이다 루트2=1.4...이므로 대략 1.4로 정한다

        const int CostStraight = 10;
        const int CostDiagonal = 14;

        static Point[] Direction =
        {
            new Point(0, +1),//상
			new Point(0, -1),//하
			new Point(+1, 0),//우
			new Point(-1, 0),//좌
			// new Point( -1, +1 ),		    // 좌상
			// new Point( -1, -1 ),		    // 좌하
			// new Point( +1, +1 ),		    // 우상
			// new Point( +1, -1 )		    // 우하
		};
        public static bool PathFinding(bool[,] tileMap, Point start, Point end, out List<Point> Path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            bool[,] visited = new bool[ySize, xSize];
            ASNode[,] nodes = new ASNode[ySize, xSize];
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

            //0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);

            while (nextPointPQ.Count > 0)
            {
                //1. 다음으로 탐생할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();

                //2. 방문한 정점은 방문표시
                visited[nextNode.point.y, nextNode.point.x] = true;
                //3.탐색할 정점이 도착지인 경우
                //도착했다고 판단해서 경로 반환
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    Point? pathPoint = end;
                    Path = new List<Point>();

                    while (pathPoint != null)
                    {
                        Point point = pathPoint.GetValueOrDefault();
                        Path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;
                    }

                    Path.Reverse();
                    return true;
                }

                //4. Astar 탐색을 진행
                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y; ;

                    //4-1 탐색하면 안되는 경우 제외
                    //맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    //탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false)
                        continue;
                    //이미 방문한 접점이면
                    else if (visited[y, x])
                        continue;

                    //4-2 탐색
                    int g = nextNode.g + 10;
                    int h = Heuristic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

                    //4-3 정덤의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[x, y] == null ||     //점수계산이 되지 않은 정점이거나
                        nodes[y, x].f > newNode.f) //가중치가 더 높은 정점인 경우
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }
            Path = null;
            return true;
        }

        //휴리스틱(Heuristic) : 최상의 경로를 추정하는 순위값 ,휴리스틱에 의해 경로탐색 효율이 걸졍됨
        private static int Heuristic(Point start, Point end)
        {
            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            // 맨해튼 거리 : 가로 세로를 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }
        private class ASNode
        {
            public Point point; //현재 정점 위치
            public Point? parent;//이 정점을 탐색한 정점

            public int f;   //f(x)=g(X)+h(x) : 총거리
            public int g;   //현재까지의 거리, 즉 지금까지 경로 가중치
            public int h;   //휴리스택 : 앞으로 예상되는 거리

            public ASNode(Point point, Point? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.f = g + h;
                this.g = g;
                this.h = h;
            }
        }

    }
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
