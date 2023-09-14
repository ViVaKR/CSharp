/* 캐리지리턴과 라인피드 차이
    - Tab => char(9)
    - Carriage return (CR)  => char(13)
    - Line feed (LF) => char(10)

    - 캐리지 리턴 (CR : Carriage Return ) : 캐럿을 줄의 맨 앞으로 이동 시킨다.
    - 라인 피드 (LF : Line Feed) : 캐럿을 다음 줄(현재 위치에서 바로 아래)로 이동 시킨다.

    - 유닉스/리눅스 : LF만으로 줄 바꿈을 정의 한다.
    - 윈도우/DOS : CRLF 조합으로 줄 바꿈을 정의 한다.
    - C언어 : 유닉스 태생으로 LF만으로 줄 바꿈을 정의 한다.
*/
