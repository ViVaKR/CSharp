# C

## Generic

- 제약조건을 사요하는 이유
    - 형식 매개 변수의 기능 및 기대치를 지정
    - 제약 형식의 작업 및 메서드 호출을 사용할 수 있음
    -

<pre>

- where T : struct -> 값형식, (record struct)
- where T : class -> 참조형식, (class, interface, delegate, array type, not null reference)
- where T : class? -> null 허용, not null (record, class, interface, delegate, array type)
- where T : notnull -> null 을 허용하지 않는 (참조 형식, 값 형식)
- where T unmanaged -> not nullable 비관리형 형식, 제챡조건은 struct 제약 조건을 나타내며 struct 또는 new() 제약 조건과 결합할 수 없음.
- where T : new() -> 매개변수가 없는 생성자가 있어야 함. 꼭 마지막에 지정해야 함.
- where T : Default Class Name -> 기본 클래스 이거나 기본 클래스에서 파생된 클래스
- where T : Default Class Name ? -> nullable, not nullable
- where T : U ->
- where T : default ->
- where T : allows ref struct -> ref struct 형식이 될 수 있음.

struct, class, class?, notnull, unmanaged 는 상호 배타적

</pre>
