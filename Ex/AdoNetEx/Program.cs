using AdoNetEx;

// --> 선행 작업 --> [ 데이터 모델링, 추상화 : 데이터베이스 테이블을 클래스로 매핑 ]
// 1. 데이터 전체를 가져오기
// 2. 데이터가 없을 경우 처리
// 3. 데이터 추출 - (샘플) Id 3번 부터 3개만 추출 후 출력
// 4. 레이블 인덱스 가상 넘버링
// 5. 선택된 데이터 출력

// // 데이터 가져오기
// var data = await Utility.GetColorTableAsync();

// // 데이터가 없을 경우 처리
// if (data is null) return;

// // 데이터 추출 - Id 3번 부터 3개만 추출 후 출력
// var selection = data.Where(x => x.Id >= 3).Take(3).ToList();

// int index = 1; // 레이블 인덱스 가상 넘버링
// foreach (var item in selection)
// {
//     Console.WriteLine($"(가상 라벨 컨트롤) label{index++}.text = {item.HexCode}");
//     Console.WriteLine($"(가상 라벨 컨트롤) label{index++}.text = {item.DecimalCode}");
// }


var result = await Utility.GetPIDigitsAsync();
Console.WriteLine($"PI : {result}");
