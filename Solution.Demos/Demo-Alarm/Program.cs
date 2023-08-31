using Demo_Alarm;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

TimeSpan a1 = DateTime.Now.TimeOfDay;  //-> 14:34:45.3057919

// Case 1 : 의도적으로 현재 시간 보다 소(작다 소) 시간
TimeSpan a2 = TimeSpan.Parse("12:10"); //-> 12:10:00
string gtlt = (a1 > a2) ? ">" : "<";
Console.WriteLine($"Result ({a1:hh\\:mm} {gtlt} {a2:hh\\:mm}) ∴ `if(a1 > a2) == {a1 > a2}`"); //-> (14:37 > 12:10) => True

// Case 2 : 의도적으로 현재 시간 보다 대(크다 대) 시간
a2 = TimeSpan.Parse("19:45"); //-> 19:45:00
gtlt = (a1 > a2) ? ">" : "<";
Console.WriteLine($"Result ({a1:hh\\:mm} {gtlt} {a2:hh\\:mm}) ∴ `if(a1 > a2) == {a1 > a2}`"); //-> (14:37 > 19:45) => False
