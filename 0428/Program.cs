﻿namespace _0428
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /*
            1. 선형정렬 3종 구현 원리 조사*오름차순을 기준으로 설명*
            선택정렬 : 해당 순서에 따라 들어갈 원소를 찾아 자리를 교환 해주는 정렬
                      3 ,2 ,4 ,5 ,1 ,6 을 배열을 통해 만들고 선택정렬을 통해 정렬한다고 하면
                      0번 자리의 숫자와 나머지 뒤를 다 비교한 후 가장 작은 숫자와 자리를 교체해준다
                      0번 자리가 끝나면 1번부터 나머지 뒤에 숫자를 비교하고 작은 숫자를 교체하는것을
                      배열이 끝날때 까지 반복해준다.

            삽입정렬 : 숫자 배열이 있다면 두번째 숫자부터([1]) 시작하여 앞에 숫자들과 비교하여 
                      앞에보다 작으면 그 자리에 삽입하고 정렬한다. 두번째는 앞에 첫번째 숫자 뿐이니 한번만 하지만
                      세번째는 두번째와 비교하고 삽입후 다시 첫번째와 비교후 첫번째 보다 작다면 첫번째에 삽입하고 크다면 그 자리에 머문다.

            버블정렬 : 서로 근접한 두개의 숫자를 비교하고 작으면 서로 자리를 교환해준다. 교환이 되었다면 다시 근접한 숫자와
                      비교하여 마지막 숫자까지 비교하거나 바꿀 필요가 없어질 때 까지 반복한다.
                      반복이 끝났다면 다시 처음으로 돌아와 위 방법을 다시 실행하면서 정렬을 시도한다.   
            */
            /*
            2 분할정복정렬 3종 구현 원리 조사 
                힙정렬 : 완전 이진 트리를 통해서 정렬하며 처음 순서로는 이진트리에서 가장 큰 값을 0깊이 까지 올린다.
                        이후 이진트리 안에 가장 마지막에 있는 숫자와 0깊이에 있는 숫자의 위치를 교환해주고 마지막 자리를
                        지운다 그리고 다시 가장 큰 숫자를 0깊이로 올리고 이진트리가 없어질 때 까지 반복해주면서 정려한다.

                합병정렬 : 길이가8인 배열이 있다면 그걸 반으로 나눈 4와 4의 길이의 배열 2개가 생긴다 여기서 다시 반으로 나누어
                          2와 2로 또 여기서 나누어 1과 1로 나누어 졌을때 분할이 다 되었다고 생각하고 비교를 하고 분할이 완료되
                          두 배열중 작은 값을 앞에두고 한배열에 합친다. 2의 길이가 된 배열과 따로 나누어 졌던 2길이의 배열을 합치며
                          2배열의 서로 가장 앞에 있는 숫자부터 비교하며 하나씩 나열후 합치는걸 원래 길이가 될 때 까지 반복한다.
                          
                퀵정렬 : 배열이 있을때 가장 맨 앞에 있는 숫자를 기준으로(그 숫자는 pivot으로 부른다) pivot을 배열의 가운데로 옮기고
                        pivot 보다 크기가 작다면 앞으로 옮기고 반대로 크기가 크다면 뒤로 보내는 것이 하나의 사이클이다 그 사이클이 끝나고서는
                        작은 값중 가장 큰값과 pivot의 자리를 교환해준다 그후 pivot을 기준으로 나눠진 작은값과 큰값 배열을 다시 한번 퀵 정렬을 하며
                        바꿀 필요가 없어질 때 까지 반복하며 정렬한다.
             */
            /*
                3 분할정복 정렬 3종의 원리의 의한 특징 조사
                힙정렬 특징 : 힙정렬은 최악이든 최선이든 속도가O(n log n)을 가진다는 장점이 있지만
                             정렬해야하는 값의 갯수에 따라 처리 속도가 달라지게 된다.

                병합정렬 특징 :장점으로는 데이터의 분포에 영향을 덜 받는다. 즉, 입력 데이터가 무엇이든 간에 정렬되는 시간은 동일하다.
                               큰 레코드를 정렬할 때 LinkedList를 사용한다면 다른 정렬법보다 훨씬 효율적이다
                              단점은 만약 배열로 레코드를 정렬한다면 제자리 정렬이 아니기에 임시로 값을 저장해줄 배열을 만들어줘야 한다.
                              레코드가 크기가 많이 크다면 시간이 오래 걸릴 수도 있다.

                퀵정렬 특징 : 퀵정렬은 시간복잡도가 O(log2n)으로 다른 정렬 알고리즘에 비해 훨씬 빠르며
                             추가 메모리 공간을 필요로 하지 않든다는 장점이 있다
                             단점으로는 정렬이 잘못 되었을 때는 퀵정렬의 분균형으로 인해 시간이 느려질 수 있다 O(n^2)
                             그러므로 불균형한 분할을 방지하기 위해 균등하게 분할 할 수 있는 리스트에 사용해야 한다.
             */
        }
    }
}