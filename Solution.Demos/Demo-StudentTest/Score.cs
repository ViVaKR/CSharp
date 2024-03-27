using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_StudentTest
{
    public class Score : Person
    {
        // (요청사항) 프로퍼티 : 합계, 평균, 평점
        public double Sum { get; set; }
        public double Avg { get; set; }
        public Grade Grade { get; set; }

        public double[] jumsu;

        // (요청사항) 인덱서, 입력과 동시에 합계와 평균 미리 작성하기
        public double this[int index]
        {
            get => jumsu[index];
            set
            {
                jumsu[index] = value;
                Sum = jumsu.Sum();
                Avg = jumsu.Average();
            }
        }

        // (요청사항) 디폴트 매개변수로 초기화
        public Score(string Id = "A00", string Name = "컴퓨터") : base(Id, Name)
        {
            jumsu = new double[Enum.GetValues(typeof(Subject)).Length];
        }

        // (요청사항) 평점 계산 com() 메소드 : 네이밍 규칙 => 메소드는 대문자이면서. 이해가능한 단어 선택으로 데체함
        public string Compute()
        {
            switch (Avg)
            {
                case double n when Enumerable.Range(90, 10).Contains((int)n): Grade = Grade.A; break;
                case double n when Enumerable.Range(80, 9).Contains((int)n): Grade = Grade.B; break;
                case double n when Enumerable.Range(70, 9).Contains((int)n): Grade = Grade.C; break;
                case double n when Enumerable.Range(60, 9).Contains((int)n): Grade = Grade.D; break;
                case double n when Enumerable.Range(0, 59).Contains((int)n): Grade = Grade.F; break;
            }
            return Grade.ToString();
        }
    }

    // 평점
    public enum Grade { A = 90, B = 80, C = 70, D = 60, F = 0 }
    // 과목
    public enum Subject { 국어 = 0, 영어, 수학 }
    // 메뉴
    public enum Menus { 입력 = 1, 계산 = 2, 조회 = 3, 종료 = 4 }



}
