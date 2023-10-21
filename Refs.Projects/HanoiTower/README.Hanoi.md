# Hanoi

if n is equal to 1:
* We move 1 disk from source to destination
else:
* We move n-1 disks from source to auxiliary
* We move 1 disk from source to destination
* We move n-1 disks from auxiliary to destination

- Base cases
- Recursive call

> 판 수가 짝수면 `임시기둥`  
>  
> 홀수이면 `목표지점` 부터 이동  

## _판 2개_  

$n = 2$

$A \rightarrow B\Rightarrow1회\Rightarrow(n-1판)\Rightarrow임시기둥$  
$A \rightarrow C\Rightarrow1회\Rightarrow(n판)\Rightarrow목적지기둥$  
$B \rightarrow C\Rightarrow1회\Rightarrow(임시기둥, n-1판)\Rightarrow목적지기둥$  

$$\left(2^2 - 1 = 3회\right)$$

---

## _판 3개_

$$\left( 2^3 - 1 = 7 회\right)$$

$\bullet A \rightarrow B (n - 1 = 2ea)\Rightarrow 3회\Rightarrow 임시기둥$  
$\{A \rightarrow C\}$  
$\{A \rightarrow B\}$  
$\{C \rightarrow B\}$  
$\bullet A\rightarrow C (n - (n - 1) = 1ea)\Rightarrow 1회\Rightarrow 목적지기둥$  
$\bullet B\rightarrow C (n -1 = 2ea)\Rightarrow 3회\Rightarrow 목적지기둥$  
$\{B \rightarrow A\}$  
$\{B \rightarrow C\}$  
$\{A \rightarrow C\}$  

---

## _판 4개_

$$ \left(2^4 - 1 = 15\right)$$

$\bullet A \rightarrow B \Rightarrow (n - 1 = 3개) \Rightarrow 7회\Rightarrow임시기둥$  

$\{A \rightarrow B\}$  
$\{A \rightarrow C\}$  
$\{B \rightarrow C\}$  
$\{A \rightarrow B\}$  
$\{C \rightarrow A\}$  
$\{C \rightarrow B\}$  
$\{A \rightarrow B\}$  
$\bullet A \rightarrow C \Rightarrow (n - (n - 1개) \Rightarrow 1회)\Rightarrow목적지기둥$  
$\bullet B \rightarrow C \Rightarrow (n - 1 = 3개) \Rightarrow 7회\Rightarrow목적지기둥$  
$\{B \rightarrow C\}$  
$\{B \rightarrow A\}$  
$\{C \rightarrow A\}$  
$\{B \rightarrow C\}$  
$\{A \rightarrow B\}$  
$\{A \rightarrow C\}$  
$\{B \rightarrow C\}$  


