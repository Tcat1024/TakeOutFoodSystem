using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TakeOutSystem
{
  public class InterlockedQueue<T>
  {
    private class Node
    {
      public Node next;
      public T data;
    }
    private Node head = new Node();
    private Node tail;
    public InterlockedQueue()
    {
      tail = head;
    }
    public void Enqueue(T item)
    {
      Node newNode = new Node();
      newNode.data = item;
      bool end = false;
      Node oldTail = null;
      Node oldNext = null;
      while (!end)
      {
        Interlocked.Exchange(ref oldTail, tail);
        Interlocked.Exchange(ref oldNext, oldTail.next);
        if(oldTail == tail)
        {
          if (oldNext == null)
          {
            end = Interlocked.CompareExchange(ref tail.next, newNode, null) == null;
          }
          else
          {
            // another Thread already used the place so give him a hand by putting tail where it should be
            Interlocked.CompareExchange(ref tail, oldNext, oldTail);
          }
        }
      }
      // At this point we added correctly our node, now we have to update tail. If it fails then it will be done by another thread
      Interlocked.CompareExchange(ref tail, newNode, oldTail);
    }
    public bool TryDequeue(out T result)
    {
      result = default(T);
      Node oldNext = null;
      bool end = false;

      Node oldHead = null;
      Node oldTail = null;
      while (!end)
      {
        Interlocked.Exchange(ref oldHead, head);
        Interlocked.Exchange(ref oldTail, tail);
        Interlocked.Exchange(ref oldNext, oldHead.next);

        if (oldHead == head)
        {
          // Empty case ?
          if (oldHead == oldTail)
          {
            // This should be false then
            if (oldNext != null)
            {
              // If not then the linked list is mal formed, update tail
              Interlocked.CompareExchange(ref tail, oldNext, oldTail);
              continue;
            }
            result = default(T);
            return false;
          }
          else
          {
            result = oldNext.data;
            end = Interlocked.CompareExchange(ref head, oldNext, oldHead) == oldHead;
          }
        }
      }

      oldNext.data = default(T);

      return true;
    }
  }
}