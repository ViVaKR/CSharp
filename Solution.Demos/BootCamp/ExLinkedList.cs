using System.Collections.Generic;

namespace BootCamp;
public class ExLinkedList
{
    // 연속적으로 저장되지 않는 데이터 구조

    public void MakeNode()
    {
        Node n1 = new(1);
        Node n2 = new(2);
        Node n3 = new(3);
        Node n4 = new(4);
        Node n5 = new(5);

        n1.Next = n2;
        n2.Next = n3;
        n3.Next = n4;
        n4.Next = n5;
        n5.Next = null;

        WriteLine();
        WriteLine("ASC");
        WriteLine();
        PrintLinkedList(n1);
        WriteLine();
        WriteLine("DESC");
        WriteLine();
        Node reversed = ReverseList(n1);
        PrintLinkedList(reversed);
    }

    public Node ReverseList(Node head)
    {
        if (head == null || head.Next == null)
            return head!;

        Node node = ReverseList(head.Next);
        head.Next.Next = head;
        head.Next = null!;
        return node;
    }

    public void PrintLinkedList(Node node)
    {
        Node? temp = node;
        while (temp != null)
        {
            WriteLine($"{temp.Val} ");
            temp = temp.Next;
        }
    }
}

public class Node
{
    public int Val { get; set; }
    public Node? Next { get; set; }

    public Node(int val)
    {
        Val = val;
    }
}
