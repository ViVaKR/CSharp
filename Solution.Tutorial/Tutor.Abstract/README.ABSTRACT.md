# 추상메서드 (Abstract)

* 클래스, 메서드, 속성, 인덱서 및 이벤트와 함께 사용될 수 있음
* 선언 : `abstract` modifier 사용
* 추상 클래스는 인스턴스화수 없음
* 추상으로 표시된 멤버는 추상 클래스에서 파생된 비 추상 클래스에 의해 구현되어야 함
* sealed 한정자를 사용하면 추상 클래스를 수정할 수 없음
* 파생 클래스는 상속된 메서드 및 접근자의 실제 구현이 포함되어야 함
* 추상 메서드는 암묵적으로 가상(virtual) 메서드임
* 추상 메서드 선언은 추상 클래스에서만 허용됨
* 추상 메서드 선언은 실제 구현을 제공하지 않으므로 메서드 본문이 없음, 즉 세미콜론 으로 끝난 시그니처 뒤에 중괄호 ({}) 가 없음
* 추상 메서드 선언에서 static 또는 virtual 한정자를 사용하는 것은 오류를 발생시킴
* 인터페이스를 구현하는 추상 클래스는 인터페이스 메서드를 추상 메서드를 매핑할 수 있음