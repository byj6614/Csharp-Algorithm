namespace Heap
{
    internal class Program
    {
        /******************************************************
		 * 힙 (Heap)
		 * 
		 * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 ******************************************************/

        static void PriorityQueue()
        {
            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();   //우선 순위 queue : PriorityQueue<값, 우선순위 값>

            pq.Enqueue("감자", 3);
            pq.Enqueue("양파", 5);
            pq.Enqueue("당근", 1);
            pq.Enqueue("토마토", 2);
            pq.Enqueue("마늘", 4);

            while(pq.Count > 0)
            {
                Console.WriteLine(pq.Dequeue());          //우선순위가 높은 순으로 출력
            }
        }
        static void Main(string[] args)
        {
            PriorityQueue();
        }
    }
}