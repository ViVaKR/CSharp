using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_StudentTest
{
    public class StudentManager
    {
        private Score? student;
        private string? std;
        private Menus menu = Menus.종료;
        private string underLine = string.Join("", Enumerable.Repeat("=", Console.WindowWidth));

        /// <summary>
        /// 시작점
        /// </summary>
        /// <param name="args"></param>
        public void Start()
        {
            Console.WriteLine("== 학생 정보 입력을 시작하겠습니다. ==");
            Console.WriteLine(underLine);
            menu = Menus.입력;
            InputOutput();
            System.Console.WriteLine(underLine);
            Console.WriteLine($"학생성적 관리 프로그램을 모두 마칩니다.");
            System.Console.WriteLine(underLine);
            Console.ReadLine();
        }

        /// <summary>
        /// (요청사항)학생 성적 입력 하기 및 총점, 평균 그리고 평점내기
        /// </summary>
        private void InputOutput()
        { // 12345

            do
            {
                switch (menu)
                {
                    case Menus.입력: // 학생 번호와 이름 입력 받기
                        {
                            Console.WriteLine($"관리할 학생정보를 입력하세요");
                            System.Console.WriteLine(underLine);

                            string id = string.Empty;
                            do
                            {
                                Console.Write($"Id (학번): ");
                                id = Console.ReadLine() ?? string.Empty;
                            } while (string.IsNullOrEmpty(id)); // 아이디 값이 없을 때는 무한 반복

                            string name = string.Empty;
                            do
                            {
                                Console.Write($"Name (이름): ");
                                name = Console.ReadLine() ?? string.Empty;
                            } while (string.IsNullOrEmpty(name)); // 이름 값이 없을 때는 무한반복

                            student = new Score(id, name);
                            std = $"{student.Id} {student.Name}";
                            System.Console.WriteLine();

                            for (int i = 0; i < student.jumsu.Length; i++)
                            {
                                System.Console.Write($"{std} 의 {Enum.GetName(typeof(Subject), i)} 성적:=> ");

                                // (요청사항) 인덱서를 통한 점수 데이터 Input
                                student[i] = Convert.ToDouble(Console.ReadLine());
                            }
                            System.Console.WriteLine();
                            System.Console.WriteLine(string.Join("", Enumerable.Repeat("=", Console.WindowWidth)));

                            Console.Write($"입력하신 {std} 의 성적표 내역 :=> ");
                            // (요청사항) 인덱서를 통한 점수 데이터 Output
                            Console.WriteLine($"[ {Subject.국어}: {student[0]}, {Subject.영어}: {student[1]}, {Subject.수학}: {student[2]} ]");
                            System.Console.WriteLine();
                            Console.WriteLine($"학생 {std} 의 {menu.ToString()} 작업을 마침니다. 다음 작업을 선택하세요...");
                        }
                        break;

                    case Menus.계산: // 총점과 평균
                        {
                            Console.Write($"...{std} 의 총점과 평균을 계산 중.");
                            for (int i = 0; i < 5; i++)
                            {
                                Console.Write($"{".".PadLeft(i, '.')}");
                                Thread.Sleep(1000);
                            }
                            System.Console.WriteLine();
                            System.Console.WriteLine(underLine);
                            Console.WriteLine($"학생 {std}의 총점:=> {student?.Sum ?? 0}, 평균:=> {student?.Avg ?? 0:n2}");
                            System.Console.WriteLine(underLine);
                            System.Console.WriteLine();
                            Console.WriteLine($"학생 {std} 의 {menu.ToString()} 작업을 마침니다. 다음 작업을 선택하세요...");
                        }
                        break;

                    case Menus.조회: // 평점 조회
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine(underLine);
                            Console.WriteLine($"학생 {std}의 평점 :=> {student?.Compute()} 입니다.");
                            System.Console.WriteLine(underLine);
                            Console.WriteLine($"학생 {std} 의 {menu.ToString()} 작업을 마침니다. 다음 작업을 선택하세요...");
                        }
                        break;
                }
                // 메뉴선택
                Console.Write($"{string.Join($" / ", Enum.GetNames(typeof(Menus)).Select((x, i) => $"{i + 1} {x}"))}");
                Console.Write(" => ");
                Enum.TryParse(Console.ReadLine()?.ToString(), out menu);
                if (menu != Menus.종료) InputOutput();
            } while (menu != Menus.종료);
        }
    }
}
