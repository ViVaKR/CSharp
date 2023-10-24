# 하노이 노트

$\qquad$  
$\qquad$  
$\qquad$  
  
$\qquad \qquad \qquad \qquad \qquad \, | \qquad \qquad \qquad \qquad \qquad \quad | \qquad \qquad \qquad \qquad \qquad \quad |$  
$\qquad \qquad \qquad \qquad \qquad \, | \qquad \qquad \qquad \qquad \qquad \quad | \qquad \qquad \qquad \qquad \qquad \quad |$  
$\qquad \qquad \qquad \qquad \qquad \, | \qquad \qquad \qquad \qquad \qquad \quad | \qquad \qquad \qquad \qquad \qquad \quad |$  
$\qquad \qquad \qquad \qquad \qquad \, | \qquad \qquad \qquad \qquad \qquad \quad | \qquad \qquad \qquad \qquad \qquad \quad |$  
$\qquad \qquad \qquad \qquad \qquad \, | \qquad \qquad \qquad \qquad \qquad \quad | \qquad \qquad \qquad \qquad \qquad \quad |$  
$\qquad \qquad \qquad \qquad \qquad \, | \qquad \qquad \qquad \qquad \qquad \quad | \qquad \qquad \qquad \qquad \qquad \quad |$  
$\qquad \qquad \qquad \qquad \qquad \, | \qquad \qquad \qquad \qquad \qquad \quad | \qquad \qquad \qquad \qquad \qquad \quad |$  
$\qquad \qquad \qquad \qquad \qquad \, | \qquad \qquad \qquad \qquad \qquad \quad | \qquad \qquad \qquad \qquad \qquad \quad |$  
$\qquad \qquad \qquad \qquad \qquad \, | \qquad \qquad \qquad \qquad \qquad \quad | \qquad \qquad \qquad \qquad \qquad \quad |$  
$\qquad \qquad \qquad \qquad \qquad \, | \qquad \qquad \qquad \qquad \qquad \quad | \qquad \qquad \qquad \qquad \qquad \quad |$  



--- 

$\qquad \qquad \qquad \qquad \qquad A \qquad \qquad \qquad \qquad \qquad \, B \, \,\, \qquad \qquad \qquad \qquad \qquad \, C$

---

# Hanoi

> 판수가  
>> 짝수? `임시기둥` 부터  
>> 홀수? `목표지점` 부터  

## _판 2개_  $\quad n = 2$

$A \rightarrow B\Rightarrow1회\Rightarrow(n-1판)\Rightarrow Temp$  

$A \rightarrow C\Rightarrow1회\Rightarrow(n판)\Rightarrow End$  

$B \rightarrow C\Rightarrow1회\Rightarrow(임시기둥, n-1판)\Rightarrow End$  

$$\left(2^2 - 1 = 3회\right)$$

---

## _판 3개_ $\quad n = 3$

$$\left( 2^3 - 1 = 7 회\right)$$

$\bullet A \rightarrow B (n - 1 = 2ea)\Rightarrow 3회\Rightarrow 임시기둥$  
$\{A \rightarrow C\}$  
$\{A \rightarrow B\}$  
$\{C \rightarrow B\}$  

$\bullet A\rightarrow C (1ea)\Rightarrow 1회\Rightarrow 목적지기둥$  

$\bullet B\rightarrow C (n -1 = 2ea)\Rightarrow 3회\Rightarrow 목적지기둥$  
$\{B \rightarrow A\}$  
$\{B \rightarrow C\}$  
$\{A \rightarrow C\}$  

---

## _판 4개_ $\quad n = 4$

$$ \left(2^4 - 1 = 15\right)$$

$\bullet A \rightarrow B \Rightarrow (n - 1 = 3개) \Rightarrow 7회\Rightarrow임시기둥$  

$\{A \rightarrow B\}$  
$\{A \rightarrow C\}$  
$\{B \rightarrow C\}$  
$\{A \rightarrow B\}$  
$\{C \rightarrow A\}$  
$\{C \rightarrow B\}$  
$\{A \rightarrow B\}$  

$\bullet A \rightarrow C \Rightarrow (1개) \Rightarrow 1회)\Rightarrow목적지기둥$  

$\bullet B \rightarrow C \Rightarrow (n - 1 = 3개) \Rightarrow 7회\Rightarrow목적지기둥$  
$\{B \rightarrow C\}$  
$\{B \rightarrow A\}$  
$\{C \rightarrow A\}$  
$\{B \rightarrow C\}$  
$\{A \rightarrow B\}$  
$\{A \rightarrow C\}$  
$\{B \rightarrow C\}$  
