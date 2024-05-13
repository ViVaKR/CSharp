# Document

```bash

# (1) 솔루션 만들기
$ dotnet new sln

# (2) 클래스 라이브러리 프로젝트 만들기
$ dotnet new classlib -o StringLib

# (3) 라리브러리 프로젝트를 솔루션에 추가하기
$ dotnet sln add StringLib/StringLib.csproj

# (4) 빌드
$ dotnet build

# (5) 콘솔 앱 만들기
$ dotnet new console -o ConsoleViv

# (6) 솔루션에 콘솔 앱 추가
$ dotnet sln add ConsoleViv/ConsoleViv.csproj

# (7) 콘솔 앱에 라이브러리 프로젝트 참조 추가
$ dotnet add ConsoleViv/ConsoleViv.csproj reference StringLib/StringLib.csproj

# (8) Main 코드 작성

# (9) Run
$ dotnet run --project ConsoleViv/ConsoleViv.csproj

# (10) Create Unit Test Project
$ dotnet new mstest -o StringLibTest

# (11) Add Test Project to Solution
$ dotnet sln add StringLibTest/StringLibTest.csproj

# (12) 테스트 라이브러리가 StringLib 클래스에 대해 작동하도록 프로젝트 추가, StringLib -> StringLibTest
$

# Create new class
dotnet new class -n Utils -o ConsoleViv/Models --project ConsoleViv/ConsoleViv.csproj
dotnet run --configuration Release
dotnet publish --configuration Release

# HelloWorld.deps.json : 애플리케이션 런타임 종속성 파일, 앱을 실행하는 데 필요한 .NET 구성 요소 및 라이브러리를 정의
# HelloWorld.dll : 애플리케이션 종속 배포. -> $ dotnet HelloWorld.dll -> .NET 런타임 이 설치된 모든 플랫폼에서 작동.
# HelloWorld or HelloWorld.exe : 프레임워크 종속 실행 파일, 이파일은 운영체제 마다 다름.
# HelloWorld.pdb : 디버그 기호(심볼) 파일, 게시된 애플리케이션 버전을 디버그 해야 하는 경우에는 이파일을 저장하지만, 필수요소는 아님.
# HelloWorld.runtimeconfig.json : 애플리케이션의 런타임 구성 파일. 구성옵션을 추가 할 수 있음.

# [ 실행 ]
# Windows : $ .\HelloWorld.exe (Enter)
# MacOS, Linux : ./HelloWorld (Enter)
# [ 모든 플랫폼에서 실행 ]
# $ dotnet HelloWorld.dll (Enter)

```
