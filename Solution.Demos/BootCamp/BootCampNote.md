# BootCamp

## 암시적 진입점 메서드

```csharp
static async Task<int> Main(string[] args)
```

## 형식 시스템
## 변수 선언에서 형식 지정
## 값 형식

## 참조 형식 reference type

- class, record, delegate, array, interface

## 리터널 값 형식
## 제너릭 형식
## 암시적 형식, 무명 형식, 

## nullable 값 형식
일반적인 값 형식은 null 값을 가질 수 없으나 
형식 뒤에 ? 를 추가하여 null 허용 값 형식을 만들 수 있음
(ex) int? 
nullable 값 형식은 제네릭 구조체 형식 `System.Nullable<T>` 의 인스턴스

## 컴파일 타임 형식
## 런타임 형식 

## global using

## 네임스페이스
- 대규모 코드 프로젝트를 구성
- 연산를 사용하여 구분
- using 지시문은 모든 클래스에 대해 네임 스페이슬 이름을 지정할 필요가 없음
- global 네임스페이스는 `루트` 네임스페이스임

## 클래스

> [access modifier] - [class] - [identifier]  
> 클래스는 개체의 형식을 정의하지만 개체 자체는 아님
> 개체는 클래스에 기반을 둔 구체적인 엔터티, 클래스 인스턴스라고 함

## 클래스 상속
* sealed 로 정의되지 않는한 완전한 상속을 지원함
* 가상 메서드를 재정의 할 수 있음
* 하나 이상의 인터페이스를 구현할 수 있음
* 상속은 파생을 통해 수행됨
* 생성자를 제외한 기본 클래스의 모든 멤버를 상속함
* 클래스를 추상클래스 (abstract) 로 선언할 수 있음
* 추상 클래스는 인스턴스화 할 수 없음
* 클래스는 `partial` 여러 소스 파일로 분할 될 수 있음

## 레코드

* 변경할 할 수 없는 속성으로의 형식을 만들고 인스턴스화할 수 있음

## Span<T>

- 관리형 힙이 아닌 스택에 할당되는 ref 구조체
- 읽기전용 : System.ReadOnlySpan<T>
- 임의 메모리에 연속된 영역을 할당
- 배열의 요소 또는 배열의 일부를 가져오는데 사용할 수 있음

## Big-O Notation[^1]

-

## 윤리적 해킹 (Ethical Hacking)

[^1]:표기법
