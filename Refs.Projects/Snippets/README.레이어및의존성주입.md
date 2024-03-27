# Enterprise Architecture

- 코드 재 사용성
- 대형 솔루션 프로그램 개발 사용하는 프로젝트 구성 방식
- 다양한 플랫폼을 지원하는 재 사용성이 높은 코드를 작성하는 방식

1. 데이터 엑세스 레이어 :
2. 비즈니스 로직 레이어 : 오류검사, 클래스 라이브러리(단독적으로 사용할 수 없음, API, SDK 등)
3. 프리젠테이션 레이어  : 모바일, 웹사이트, 관리자, 외부 관리자, 클레식 데스크탑, 자마린 등

## 클래스 라이브러리 종류 (DLL 생성, 모듈화 시켜주는 기능)

1. dotnet Framework  (app.net)
2. dotnet core
3. dotnet Framework(Portable) - Xamarin
4. dotnet Standard : 함께 사용하지 못하던 라이브러리의 문제점을 해결하기 위한 라이브러리, 확장성이 커짐

## 엔터프라이즈 솔루션 구성 항목

1. Common
2. BusinessLogiLayer (BLL)
3. DataAccessLayer (DAL)
4. PresentationLayer

## 각 Tier 별로 접근 순서

클라이언트 버튼 클릭 -> asp.net mvc 리스트 출력 호출 -> BLL -> IDAL -> DAL

## 의존성 주입 (Dependency Injection)

코드 제사용성의 핵심

- 프로그래밍에서 구성요소간의 의존 관계가 소스코드 내부(new 객체생성)가 아닌 외부의 설정파일 등을 통해 정의되게 하는 디자인 패턴
- new 객체 생성이 많은 것은 바람직하지 않다.

1. 생성자 주입
2. 세터를 통한 주입
3. 인터페이스를 통한 주입

% 전역변수는 언더바를 사용하도록 권장함 %

## IoC ( ) : 제어의 반전 (역행)

- new 객체 생성을 하지 않도록 함
- IoC Container : 객체를 프레임워크에서 간접적을 생성 소멸 시켜주는 컨테이너

## Mvc 의존성 주입이 가능한 3가지

1. AddSingleton<`T`>()     : Static과 비슷함, 전역 객체, 프로그램(웹사이트)이 종료될 때 까지 메모리에 유지되는 방식
2. AddScoped<`T`>()        : 프로그램(웹사이트)가 시작되어 1번의 요청이 있을 때 메모리에 유지되는 방식
3. AddTransient <`T`>()    : 각각의 요청마다 새로운 객체가 생성 소멸되는 방식, 특별한 경우가 아니면 보편적으로 사용하면됨

## appsettings

- "ConnectionStrings": { "MysqlWspCon": "server=vivakr.com;userid=wsp;password=B9037!m8947#;database=wsp;" }
- "ConnectionStrings": { "LocalMSSQLCon": "Server=(localdb)\\mssqllocaldb;Database=bm;- Trusted_Connection=True;MultipleActiveResultSets=true" }

## startup.cs

- services.AddDbContext<`DbContext`>(options => options.UseMySql(Configuration.GetConnectionString("MysqlWspCon"), b=>b.MigrationsAssembly("wsp.co.kr")));

## 스레드

1. UI Thread
2. Background Thread

- 버튼을 클릭하여 for 구문을 실행할 때는 for 구분이 끝날 때 까지 UI 는 멈춘 상태로 있다.

## 동기적 프로그래밍 : 메소드가 서로 연결되어 있을 때 사용

Method() : 3sec
Method() : 7sec
Method() : 5sec
Total 15sec

## 비 동기적 프로그래밍 : 메소드가 모두 독립적일 때 사용

Method() : 3sec
Method() : 7sec
Method() : 5sec
Total 7sec (가장 오래소요되는 것이 총 소요시간)

비 동기적인 프로그램밍을 위한 키워드
async, await, Task, Task<`T`>

## 소요시간 테스트 (동기)

            Stopwatch watch = new Stopwatch();
            watch.Start();
            Test1();
            Test2();
            Test3();
            watch.Stop();

## 소요시간 테스트(비동기)

            Stopwatch watch = new Stopwatch();
            watch.Start();
            var test1 = Test1Async();
            var test2 = Test2Async();
            var test3 = Test3Async();

            var rs1 = await test1;
            var rs2 = await test2;
            var rs3 = await test3;
            watch.Stop();

## 사이트의 응답속도가 늦으면, 검색엔진에도 좋지 않은 영향을 미침

## 비동기적으로 처리하였다고 하여도 성능이 좋아 진것은 아님

## asp.net core identity

- 로그인, 로그아웃, 개별인증(관리자, 일반 사용자),
- 일반 사용자 (나이가 19세 이상)
- 테이블 구조
- AspNetUsers => ApplicationUser (유저 클래스)
- SecurityStamp : 입력한 비밀번호와 함께 PasswordHash 코드를 복호화하는 기능
- TwofactorEnabled : 두가지 방식의 인증 여부
- AspNetRoles => ApplicationRole (룰 클래스)
- 이 웹사이트 회원 분류 - 관리자, 슈퍼관리자, 관리자, 특별사용자, 일반사용자
- AspNetUserRoles => 1과 2를 연결시켜중
- AspNetUserClaims => 예를 들어 5명의 사용자가 일반 사용자인데 그 중 2명이 나이가 20세 미만 일때 특정 게시판에 진입금지등을 시키는 등의 기능등을 수행
- AspNetRoleClaims => 특정 권한을 세분화 하는 테이블
- AspNetUserLogins => 외부 로그인 Oauth, 자체 계정이 없이도 구글이나 페이스 북 계정으로 자동으로 로그인 할 수 있는 기능
- AspNetUserLoginsTokens => 외부 로그인의 토큰 관리
