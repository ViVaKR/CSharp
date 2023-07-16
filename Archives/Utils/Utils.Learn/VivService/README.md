# MicroService

- 리터널 문자열 : 큰따옴표로 묶인 문구
- 마침표 : 멤버 엑세스 연산자
- 메서드 : 괄호 집합이 있음, 메서드 호출은 항상 메서드 이름 뒤에 괄호를 사용
- 괄호 : 메서드 호출 연산자
- 세미콜론 : 문의 끝 연산자

1. 서비스 만들기 : webapi 유형의 새 어플리케이션 (REST API) 만들기

```pwsh

# -o 앱이 저장되는 디렉토리 생성
> dotnet new webapi -o VivService --no-https -f net7.0
> cd VivService
> dotnet run
> fsutil file createnew Dockerfile 0
> fsutil file createnew .dockerignore 0
```

- Dockerfile Example

```docker
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /src
COPY VivService.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT [ "dotnet", "VivService.dll"]
```

- .dockerignore
```
Dockerfile
[b|B]in
[O|o]bj

```

## Create Docker Image 

```pwsh
 docker build -t mymicroservice .
 docker images


```
