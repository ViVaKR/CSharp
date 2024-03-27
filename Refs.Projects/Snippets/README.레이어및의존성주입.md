# Enterprise Architecture

- �ڵ� �� ��뼺
- ���� �ַ�� ���α׷� ���� ����ϴ� ������Ʈ ���� ���
- �پ��� �÷����� �����ϴ� �� ��뼺�� ���� �ڵ带 �ۼ��ϴ� ���

1. ������ ������ ���̾� :
2. ����Ͻ� ���� ���̾� : �����˻�, Ŭ���� ���̺귯��(�ܵ������� ����� �� ����, API, SDK ��)
3. ���������̼� ���̾�  : �����, ������Ʈ, ������, �ܺ� ������, Ŭ���� ����ũž, �ڸ��� ��

## Ŭ���� ���̺귯�� ���� (DLL ����, ���ȭ �����ִ� ���)

1. dotnet Framework  (app.net)
2. dotnet core
3. dotnet Framework(Portable) - Xamarin
4. dotnet Standard : �Բ� ������� ���ϴ� ���̺귯���� �������� �ذ��ϱ� ���� ���̺귯��, Ȯ�强�� Ŀ��

## ������������ �ַ�� ���� �׸�

1. Common
2. BusinessLogiLayer (BLL)
3. DataAccessLayer (DAL)
4. PresentationLayer

## �� Tier ���� ���� ����

Ŭ���̾�Ʈ ��ư Ŭ�� -> asp.net mvc ����Ʈ ��� ȣ�� -> BLL -> IDAL -> DAL

## ������ ���� (Dependency Injection)

�ڵ� ����뼺�� �ٽ�

- ���α׷��ֿ��� ������Ұ��� ���� ���谡 �ҽ��ڵ� ����(new ��ü����)�� �ƴ� �ܺ��� �������� ���� ���� ���ǵǰ� �ϴ� ������ ����
- new ��ü ������ ���� ���� �ٶ������� �ʴ�.

1. ������ ����
2. ���͸� ���� ����
3. �������̽��� ���� ����

% ���������� ����ٸ� ����ϵ��� ������ %

## IoC ( ) : ������ ���� (����)

- new ��ü ������ ���� �ʵ��� ��
- IoC Container : ��ü�� �����ӿ�ũ���� �������� ���� �Ҹ� �����ִ� �����̳�

## Mvc ������ ������ ������ 3����

1. AddSingleton<`T`>()     : Static�� �����, ���� ��ü, ���α׷�(������Ʈ)�� ����� �� ���� �޸𸮿� �����Ǵ� ���
2. AddScoped<`T`>()        : ���α׷�(������Ʈ)�� ���۵Ǿ� 1���� ��û�� ���� �� �޸𸮿� �����Ǵ� ���
3. AddTransient <`T`>()    : ������ ��û���� ���ο� ��ü�� ���� �Ҹ�Ǵ� ���, Ư���� ��찡 �ƴϸ� ���������� ����ϸ��

## appsettings

- "ConnectionStrings": { "MysqlWspCon": "server=vivakr.com;userid=wsp;password=B9037!m8947#;database=wsp;" }
- "ConnectionStrings": { "LocalMSSQLCon": "Server=(localdb)\\mssqllocaldb;Database=bm;- Trusted_Connection=True;MultipleActiveResultSets=true" }

## startup.cs

- services.AddDbContext<`DbContext`>(options => options.UseMySql(Configuration.GetConnectionString("MysqlWspCon"), b=>b.MigrationsAssembly("wsp.co.kr")));

## ������

1. UI Thread
2. Background Thread

- ��ư�� Ŭ���Ͽ� for ������ ������ ���� for ������ ���� �� ���� UI �� ���� ���·� �ִ�.

## ������ ���α׷��� : �޼ҵ尡 ���� ����Ǿ� ���� �� ���

Method() : 3sec
Method() : 7sec
Method() : 5sec
Total 15sec

## �� ������ ���α׷��� : �޼ҵ尡 ��� �������� �� ���

Method() : 3sec
Method() : 7sec
Method() : 5sec
Total 7sec (���� �����ҿ�Ǵ� ���� �� �ҿ�ð�)

�� �������� ���α׷����� ���� Ű����
async, await, Task, Task<`T`>

## �ҿ�ð� �׽�Ʈ (����)

            Stopwatch watch = new Stopwatch();
            watch.Start();
            Test1();
            Test2();
            Test3();
            watch.Stop();

## �ҿ�ð� �׽�Ʈ(�񵿱�)

            Stopwatch watch = new Stopwatch();
            watch.Start();
            var test1 = Test1Async();
            var test2 = Test2Async();
            var test3 = Test3Async();

            var rs1 = await test1;
            var rs2 = await test2;
            var rs3 = await test3;
            watch.Stop();

## ����Ʈ�� ����ӵ��� ������, �˻��������� ���� ���� ������ ��ħ

## �񵿱������� ó���Ͽ��ٰ� �Ͽ��� ������ ���� ������ �ƴ�

## asp.net core identity

- �α���, �α׾ƿ�, ��������(������, �Ϲ� �����),
- �Ϲ� ����� (���̰� 19�� �̻�)
- ���̺� ����
- AspNetUsers => ApplicationUser (���� Ŭ����)
- SecurityStamp : �Է��� ��й�ȣ�� �Բ� PasswordHash �ڵ带 ��ȣȭ�ϴ� ���
- TwofactorEnabled : �ΰ��� ����� ���� ����
- AspNetRoles => ApplicationRole (�� Ŭ����)
- �� ������Ʈ ȸ�� �з� - ������, ���۰�����, ������, Ư�������, �Ϲݻ����
- AspNetUserRoles => 1�� 2�� ���������
- AspNetUserClaims => ���� ��� 5���� ����ڰ� �Ϲ� ������ε� �� �� 2���� ���̰� 20�� �̸� �϶� Ư�� �Խ��ǿ� ���Ա������� ��Ű�� ���� ��ɵ��� ����
- AspNetRoleClaims => Ư�� ������ ����ȭ �ϴ� ���̺�
- AspNetUserLogins => �ܺ� �α��� Oauth, ��ü ������ ���̵� �����̳� ���̽� �� �������� �ڵ����� �α��� �� �� �ִ� ���
- AspNetUserLoginsTokens => �ܺ� �α����� ��ū ����
