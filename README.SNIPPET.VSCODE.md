# Code Snippet for VSCode `C#`

```json
{
 "Snippets Examples": {
  "prefix": "vsnp",
  "body": [
   "$BLOCK_COMMENT_START  =======================================",
   "! [ Snippet Variable Examples ]",
   "?\tCURRENT_YEAR : $CURRENT_YEAR",
   "?\tCURRENT_MONTH : $CURRENT_MONTH",
   "?\tCURRENT_MONTH_NAME : $CURRENT_MONTH_NAME",
   "?\tCURRENT_MONTH_NAME_SHORT : $CURRENT_MONTH_NAME_SHORT",
   "?\tCURRENT_DATE : $CURRENT_DATE",
   "?\tCURRENT_DAY_NAME : $CURRENT_DAY_NAME",
   "?\tCURRENT_DAY_NAME_SHORT : $CURRENT_DAY_NAME_SHORT",
   "?\tCURRENT_HOUR : $CURRENT_HOUR",
   "?\tCURRENT_MINUTE : $CURRENT_MINUTE",
   "?\tCURRENT_SECOND : $CURRENT_SECOND",
   "?\tTM_FILENAME_BASE : $TM_FILENAME_BASE",
   "?\tTM_FILEPATH : $TM_FILEPATH",
   "?\tCLIPBOARD : $CLIPBOARD",
   "?\tRELATIVE_FILEPATH : $RELATIVE_FILEPATH",
   "?\tWORKSPACE_FOLDER : $WORKSPACE_FOLDER",
   "?\t{TM_DIRECTORY/^.+[\\/\\\\]+(.*)$/$1/} -> ${TM_DIRECTORY/^.+[\\/\\\\]+(.*)$/$1/}",
   "?\tTM_DIRECTORY -> ${TM_DIRECTORY}",
   "?\tConsole.WriteLine(@\"TM_LINE_INDEX : $TM_LINE_INDEX\");",
   "?\tConsole.WriteLine(@\"TM_LINE_NUMBER : $TM_LINE_NUMBER\");",
   "?\tConsole.WriteLine(@\"TM_FILENAME : $TM_FILENAME\");",
   "?\tConsole.WriteLine(@\"TM_CURRENT_LINE, $TM_CURRENT_LINE\");",
   "?\tConsole.WriteLine(@\"TM_CURRENT_WORD, $TM_CURRENT_WORD\");",
   "?\tConsole.WriteLine(@\"CURSOR_INDEX, $CURSOR_INDEX\");",
   "?\tConsole.WriteLine(@\"CURSOR_NUMBER, $CURSOR_NUMBER\");",
   "======================================= $BLOCK_COMMENT_END",
   "Console.WriteLine(@\"BLOCK_COMMENT_START : $BLOCK_COMMENT_START\");",
   "Console.WriteLine(@\"BLOCK_COMMENT_END : $BLOCK_COMMENT_END\");",
   "Console.WriteLine(@\"LINE_COMMENT : $LINE_COMMENT\");$0",
  ],
  "description": "Blank WriteLine"
 },
 "Viv namespace & class": {
  "prefix": "vnc",
  "body": [
   "namespace ${TM_DIRECTORY/^.+[\\/\\\\]+(.*)$/$1/};",
   "public class ${TM_FILENAME_BASE}",
   "{",
   "\tpublic ${TM_FILENAME_BASE} ($1)",
   "\t{",
   "\t\t$0",
   "\t}",
   "}"
  ],
  "description": "Viv namespace and class"
 },
 "Viv namespace": {
  "prefix": "vnamespace",
  "body": [
   "namespace ${TM_DIRECTORY/^.+[\\/\\\\]+(.*)$/$1/};"
  ],
  "description": "Viv namespace"
 },
 "Viv Class": {
  "prefix": "vclass",
  "body": [
   "public class ${TM_FILENAME_BASE}",
   "{",
   "\tpublic ${TM_FILENAME_BASE} ($1)",
   "\t{",
   "\t\t$0",
   "\t}",
   "}"
  ],
  "description": "Viv Class"
 },
 "Viv Constructor": {
  "prefix": "vctor",
  "body": [
   "public ${TM_FILENAME_BASE} ($1)",
   "{",
   "\t$0",
   "}"
  ],
  "description": "Viv Class"
 },
 "Console.WriteLine Blank": {
  "prefix": "vcwb",
  "body": [
   "Console.WriteLine(${1:Hi})$0"
  ],
  "description": "Variable WriteLine"
 },
 "Console.WriteLine Var": {
  "prefix": "vcwv",
  "body": [
   "Console.WriteLine($\"${1:var}${2: = }{${3:Hi}}\")$0",
  ],
  "description": "Variable WriteLine"
 }
}
```
<!-- /* 
! 변수
	TM_SELECTED_TEXT 현재 선택된 텍스트 또는 빈 문자열입니다
	TM_CURRENT_LINE 현재 줄의 내용
	TM_CURRENT_WORD 커서 아래에 있는 단어의 내용 또는 빈 문자열
	TM_LINE_INDEX 인덱스가 0인 줄 번호입니다
	TM_LINE_NUMBER 하나의 인덱스 기반 줄 번호
	TM_FILENAME 현재 문서의 파일 이름입니다
	TM_FILENAME_BASE 확장명이 없는 현재 문서의 파일 이름입니다
	TM_DIRECTORY 현재 문서의 디렉토리
	TM_FILEPATH 현재 문서의 전체 파일 경로입니다
	RELATIVE_FILEPATH 현재 문서의 상대(열려 있는 작업 영역 또는 폴더에 대한) 파일 경로
	CLIPBOARD 클립보드의 내용
	WORKSPACE_NAME 열려 있는 작업 영역 또는 폴더의 이름입니다
	WORKSPACE_FOLDER 열려 있는 작업 영역 또는 폴더의 경로입니다
	CURSOR_INDEX 인덱스가 0인 커서 번호입니다
	CURSOR_NUMBER 1 인덱스 기반 커서 번호
*/

/* 
! 현재 날짜 및 시간을 삽입하는 경우:
	CURRENT_YEAR 현재 연도
	CURRENT_YEAR_SHORT 현재 연도의 마지막 두 자리 숫자
	CURRENT_MONTH 두 자리 숫자로 된 월(예: '02')
	CURRENT_MONTH_NAME 월의 전체 이름(예: 'July')
	CURRENT_MONTH_NAME_SHORT 월의 짧은 이름(예: 'Jul')
	CURRENT_DATE 두 자리 숫자로 된 월의 날짜(예: '08')
	CURRENT_DAY_NAME 요일 이름(예: 'Monday')
	CURRENT_DAY_NAME_SHORT 요일의 짧은 이름(예: 'Mon')
	CURRENT_HOUR 24시간제 형식의 현재 시간
	CURRENT_MINUTE 현재 분(두 자리 숫자)
	CURRENT_SECOND 현재 두 자리 숫자의 초
	CURRENT_SECONDS_UNIX Unix epoch 이후의 시간(초)
	CURRENT_TIMEZONE_OFFSET 현재 UTC 표준 시간대 오프셋 또는 (예).+HH:MM-HH:MM-07:00
*/

 
// 또는 블록 주석을 삽입하고 현재 언어를 적용:

// BLOCK_COMMENT_START
// BLOCK_COMMENT_END
// LINE_COMMENT -->
