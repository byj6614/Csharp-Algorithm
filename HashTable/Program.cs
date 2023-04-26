﻿using System.Linq;

namespace HashTable
{
    internal class Program
    {
        /******************************************************
		 * 해시테이블 (HashTable)
		 * 
		 * 키 값을 해시함수로 해싱하여 해시테이블의 특정 위치로 직접 엑세스하도록 만든 방식
		 * 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑
		 ******************************************************/
        //큰 데이터를 집어 넣을 때 데이터를 판가름하기 위한 키값도 같이 넣는 형식
        //키값을 인덱스를 바꾸는 과정을 해싱이라 한다 키를 해시함수로 인데스로 반환해준다
        //해시테이블은 공간을 포기하고 속도를 택한 자료구조라 생각하면된다

        //<해시 함수의 조건>
        //1.입력에 대한 해시함수의 결과가 항상 동일한 값이어야 한다.

        //<해시함수의 효율>
        //1.해시함수 자체가 느린경우 의미가 없음
        //2.해시함수의 결과가 밀집도가 낮아야 함.
        //3.해시테이블의 크기가 클수록 효율이 좋음

        // <해시테이블 주의점 - 충돌>
        // 해시함수가 서로 다른 입력 값에 대해 동일한 해시테이블 주소를 반환하는 것
        // 모든 입력 값에 대해 고유한 해시 값을 만드는 것은 불가능하며 충돌은 피할 수 없음
        // 대표적인 충돌 해결방안으로 체이닝과 개방주소법이 있음

        // <충돌해결방안 - 체이닝>
        // 해시 충돌이 발생하면 연결리스트로 데이터들을 연결하는 방식
        // 장점 : 해시테이블에 자료가 많아지더라도 성능저하가 적음
        // 단점 : 해시테이블 외 추가적인 저장공간이 필요

        // <충돌해결방안 - 개방주소법>
        // 해시 충돌이 발생하면 다른 빈 공간에 데이터를 삽입하는 방식
        // 해시 충돌시 선형탐색, 제곱탐색, 이중해시 등을 통해 다른 빈 공간을 선정
        // 장점 : 추가적인 저장공간이 필요하지 않음, 삽입삭제시 오버헤드가 적음
        // 단점 : 해시테이블에 자료가 많아질수록 성능저하가 많음
        // 해시테이블의 공간 사용률이 높을 경우 성능저하가 발생하므로 재해싱 과정을 진행함
        // 재해싱 : 해시테이블의 크기를 늘리고 테이블 내의 모든 데이터를 다시 해싱 


        //c#은 체이닝 보다는 개방주소법을 쓴다고 보면 된다
        static void Dictionary()
        {
            Dictionary<string,Item> dictionary= new Dictionary<string,Item>();
            
            //추가
            dictionary.Add("초기아이템",new Item("초보자용 검",10));
            dictionary.Add("초기방어구", new Item("초보자횽 가죽갑옷", 30));
            dictionary.Add("전직아이템", new Item("전직의검", 5));
            //탐색
            Console.WriteLine(dictionary["초기아이템"].name);
            //접근
            dictionary.Remove("전직아이템");
            //확인
            if(dictionary.ContainsKey("초기아이템"))
            {
                Console.WriteLine("딕셔너리에 초기아이템이 있음");
            }
        }
        static void Main(string[] args)
        {
            Dictionary();
        }
        public class Item
        {
            public string name;
            public string image;
            public int weight;
            public Item(string name,int weight)
            {
                this.name = name;
                this.weight = weight;
            }
        }
    }
}