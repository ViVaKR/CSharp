using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Stack
{
    public class Stack
    {
        private int[] stack;

        // 현재 어느 포인트에 있는지 적어놓은 인텍스 좌표
        public int StackPoint { get; set; }

        // 처음에 초기화 할 때 스택 사이즈 크기
        public int StackSize { get; set; }

        public Stack()
        {

        }

        public void Start()
        {
            // 모양 파트
            Console.Clear();
            string pushMessage = "-- Stack Pushing Progress --";
            Console.Write($"{pushMessage}");
            const int size = 100; // 스텍 사이즈

            // (1) 위 스텍 사이즈와 함께 스텍 인스턴스 생성하기
            Stack stack = new Stack(size);

            // Push Start ...
            for (int i = 0; i < size; i++)
            {
                stack.Push(i);
                var padding = Enumerable.Repeat("-", i).ToList();
                Console.Write(pushMessage + string.Join("", padding) + "->");

                // 푸시 작업을 천천히 지연시킴으로서 먼가 있어보이게 하는 시뮬레이션 흉내내기
                Thread.Sleep(100);

                Console.Clear();
            }

            // Push End
            Console.WriteLine();

            Console.WriteLine("-- Stack Pop Progress --");

            // Pop Start
            for (int i = 0; i < size; i++)
            {
                // 팝 실행하기 : 실질적인 Pop
                int? value = stack.Pop();
                // 혹시 널값이면 위로 다시 올라가고 i index 증가시킴
                if (value == null) continue;

                // 5칸 썩 두부각 만들기
                Console.Write((value % 5 == 0) ? ", " + value + Environment.NewLine : (i == 0 || i % 5 == 0 ? string.Empty : ", ") + value);

                // 힘들게 연산하는 척하기..
                Thread.Sleep(50);
            }
        }

        // 스텍 생성자
        public Stack(int size)
        {
            // Push 를 시작하면 먼저 1을 증가시킴으로 
            // 실질 적으로 0부터 올바른 스택 시작
            StackPoint = -1;

            // 전체 스텍사이즈 제한시키기
            StackSize = size;

            // 스텍 배열 초기화
            stack = new int[size];
        }

        /// <summary>
        /// Push : 푸쉬 하면서 스택위치를 1씩 증가 시키면서 스택 사이즈와 같아지면 중단하기
        /// </summary>
        /// <param name="data"></param>
        public void Push(int data)
        {
            if (StackPoint == StackSize - 1) return;
            stack[++StackPoint] = data;
        }

        /// <summary>
        /// Pop : 팝하면서 스택위치를 -1 씩 빼면서, -1 이 되면 널값을 반환
        /// </summary>
        /// <returns></returns>
        public int? Pop() => (StackPoint == -1) ? null : stack[StackPoint--];
    }
}
