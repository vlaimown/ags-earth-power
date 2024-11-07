using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandQueue 
{
    // ��������� �� ��������� ���������� ��������� ���� ������� (������ ����� - ������ �����)
    private readonly Queue<IUICommand> queue = new();

    // ����� ��� ���������� ������ � �������
    public bool TryEnqueueCommand(IUICommand �ommand)
    {
        queue.Enqueue(�ommand);
        return true;
    }

    // ����� ��� ��������� ������ �� �������
    public bool TryDequeueCommand(out IUICommand �ommand)
    {
        if (queue.Count > 0)
        {
            �ommand = queue.Dequeue();
            return true;
        }

        �ommand = default;
        return false;
    }
}

