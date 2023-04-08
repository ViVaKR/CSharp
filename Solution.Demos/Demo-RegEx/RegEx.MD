# Regular Expression

## Note

- Sign
  - `^`  : Starts with
  - `$`  : Ends with
  - `[]` : Range
  - `()` : Group
  - `.`  : Single character once
  - `+`  : one or more characters in a row
  - `?`  : optional preceding character match
  - `\`  : escape character
  - `\n` : New line
  - `\d` : Digit
  - `\D` : Non digit
  - `\s` : White space
  - `\S` : non white space
  - `\w` : alphanumeric / underscore character (word chars)
  - `\W` : non-word characters
  - `{x,y}` : Repeat low (x) to hight (y) (no "y" means at least x, no ",y" means that  -any)
  - `(x|y)` : Alternative - x or y
  - `[^x]` : Anything but x (where x is qhaterver character you want)

- 정규식은 다음 두 가지 유형의 문자를 사용하여 구성됩니다.
  - 특수 문자 또는 메타 문자.
  - 리터럴 또는 일반 텍스트입니다.
  - 정규 표현은 언어로 생각할 수 있습니다.
  - 문법: 메타 문자.
  - 단어: 리터럴 텍스트.
  - 대소문자를 일치시킵니다.
  - 패턴 또는 문자열이 일치합니다.
  - 문자 반복을 정량화합니다.
  - 문자 클래스를 일치시킵니다.
  - 임의의 문자를 일치시킵니다다.
  - 식을 조합할 수 있습니다.
  - 정규식을 사용하여 모든 항목을 일치시킬 수 있습니다.

- Single Characters
  - `.` => The dot matches any single characer. E.g. ab. matches aba, abc, etc.
  - `[]` => A bracket expression matches a single character contained within the bracket.
  - `[abc]` matches a, b or c
  - `[a-z]` specifies a range which matches any lowercase letter from a to z.
  - `[abcx-z]` matches a, b, c, x, y, and z.

- Control Characters == //
  - `\t` horizontal tab (\0009)
  - `\v` vertical tab (\u000b)
  - `\b` backspace (\u0008)
  - `\e` escape (\u0018)
  - `\r` carriage return (\u000d)
  - `\f` form feed (\000c)
  - `\n` new liiiiine (\u000a)

- Meta Characters == //
  - `[^ ]` negation of [ ] i.e. matches a single character not contained in bracket. 
  - `[^abc]` matches any character other than a, b or c.
  - `^` matches the starting position of a string
  - `$` matches the ending position of a string
  - `\b` matches a word boundary
  - `?` 0 or 1 time matches the previous element zero or once
  - `*` matches the previous element zero or more times. E.g. abc*d matches abd, abcd, abcccd, etc.
  - `+` 1 or more times matches the previous element one or more times. E.g. abc+d matches abcd, abccccd, etc.
  - `{n}` Exactly n time
  - `{n,}` At least n times
  - `{n,m}` From n to m times

- Character classes == //
  - `\w` word character  ==> [a-zA-Z0-9]
  - `\W` non-word character
  - `\d` decimal digit
  - `\D` non-decimal digit
  - `\s` white-space
  - `\S` non-white-space

- 유니코드 범주 또는 유니코드 블록
  - `\p{L}` 모든 문자, Lu, Ll, Lt, Lm, Lo
  - `\p{Lo}` 한글, 문자 기타 E.g. 한글단어 그룹:=> @"(\p{Lo})+"
  - `\p{Lu}` 대문자
  - `\p{Ll}` 소문자
  - `\p{Lt}` 문자, 제목 스타일
  - `\p{Nd}` 10진수수
  - `\p{Sm}` 수학기호
  - `\p{Zl}` 단락 구분기호
  - `\p{Pd}` 문장부호 '-' 대쉬
  - `\p{Mn}` 표시, 공백없음
  - `\p{Sc}` 모든 통화기호를 제거, E.g. @"(\p{Sc})+"
  - `(\(\d{3,}\))` 괄호안의 숫자 E.g. (212)-111-1111, (010)-8877-8947, (010) (0123) (239399239293)

- Posix Regular Expressions == //
  - `[:alnum:]` matches alpha-numerical characters
  - `[:alphar"]` matches alphabetical characters
  - `[:digit:]` mataches numerals
  - `[:upper:]` matches upper case characters
  - `[:lower:]` matches lower case characters
