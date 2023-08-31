using Demo_Recursion;

var rec = new Recursion();
Console.WriteLine("선택 >> ");
int choice = Convert.ToInt32(Console.ReadLine());

var a = new int[] { -1, 0, 1, 2, 3, 4, 7, 9, 10, 20 };
switch (choice)
{
    case 1: Console.WriteLine(rec.RecursionA(1)); return;
    case 2: Console.WriteLine(rec.DecimalToBinary(253, string.Empty)); return;
    case 3: Console.WriteLine(rec.SumOfNaturalNumbers(10)); return;
    case 4: Console.WriteLine(rec.BinarySearch(a, 0, 10, 7)); return;
}
// ATM Analogy (비유)
// ATM 기계 앞에서 당신의 앞에 얼마나 많은 사람들이 서있는지?
// How many people are in front of me?
// 바로 앞의 사람에게 당신은 몇번째 입니까? 하고 물음
// 제일 앞에 있는 사람까지 반복하여 질문을 함
// 제일 앞에 있는 사람이 정지 조건 즉 1을 반환하고 
// 다시 역순으로 2, 3, 4 .. 되돌아 오게 하는 알고리즘
// 즉 정지 조건이 현재 ATM 에서 돈을 인출하는 사람이 됨
