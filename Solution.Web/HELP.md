.NET SDK (7.0.302)
사용법: dotnet [runtime-options] [path-to-application] [arguments]

.NET 애플리케이션을 실행합니다.

runtime-options:
  --additionalprobingpath <path>   프로브할 프로빙 정책 및 어셈블리를 포함하는 경로입니다.
  --additional-deps <path>         추가 deps.json 파일의 경로입니다.
  --depsfile                       <application>.deps.json 파일의 경로입니다.
  --fx-version <version>           애플리케이션을 실행하는 데 사용할 설치된 공유 프레임워크의 버전입니다.
  --roll-forward <setting>         프레임워크 버전(LatestPatch, Minor, LatestMinor, Major, LatestMajor, Disable)으로 롤포워드합니다.
  --runtimeconfig                  <application>.runtimeconfig.json 파일의 경로입니다.

path-to-application:
  실행할 애플리케이션 .dll 파일의 경로입니다.

사용법: dotnet [sdk-options] [command] [command-options] [arguments]

.NET SDK 명령을 실행합니다.

sdk-options:
  -d|--diagnostics  진단 출력을 사용합니다.
  -h|--help         명령줄 도움말을 표시합니다.
  --info            .NET 정보를 표시합니다.
  --list-runtimes   설치된 런타임을 표시합니다.
  --list-sdks       설치된 SDK를 표시합니다.
  --version         사용 중인 .NET SDK 버전을 표시합니다.

SDK 명령:
  add               .NET 프로젝트에 패키지 또는 참조를 추가합니다.
  build             .NET 프로젝트를 빌드합니다.
  build-server      빌드에 의해 서버와 상호 작용이 시작되었습니다.
  clean             .NET 프로젝트의 빌드 출력을 정리합니다.
  format            프로젝트 또는 솔루션에 스타일 기본 설정을 적용합니다.
  help              명령줄 도움말을 표시합니다.
  list              .NET 프로젝트의 프로젝트 참조를 나열합니다.
  msbuild           Microsoft Build Engine(MSBuild) 명령을 실행합니다.
  new               새 .NET 프로젝트 또는 파일을 만듭니다.
  nuget             추가 NuGet 명령을 제공합니다.
  pack              NuGet 패키지를 만듭니다.
  publish           배포에 대해 .NET 프로젝트를 게시합니다.
  remove            .NET 프로젝트에서 패키지 또는 참조를 제거합니다.
  restore           .NET 프로젝트에 지정된 종속성을 복원합니다.
  run               .NET 프로젝트 출력을 빌드하고 실행합니다.
  sdk               .NET SDK 설치를 관리합니다.
  sln               Visual Studio 솔루션 파일을 수정합니다.
  store             지정된 어셈블리를 런타임 패키지 저장소에 저장합니다.
  test              .NET 프로젝트에 지정된 Test Runner를 사용하여 단위 테스트를 실행합니다.
  tool              .NET 환경을 확장하는 도구를 설치하거나 관리합니다.
  vstest            Microsoft Test Engine(VSTest) 명령을 실행합니다.
  workload          선택적 워크로드를 관리합니다.

번들 도구의 추가 명령:
  dev-certs         개발 인증서를 만들고 관리합니다.
  fsi               F# Interactive를 시작하고 F# 스크립트를 실행합니다.
  user-jwts         개발 중인 JSON 웹 토큰을 관리합니다.
  user-secrets      개발 사용자 비밀을 관리합니다.
  watch             파일이 변경되면 명령을 실행하는 파일 감시자를 시작합니다.

명령에 대한 자세한 정보를 보려면 'dotnet [명령] --help'를 실행합니다.
