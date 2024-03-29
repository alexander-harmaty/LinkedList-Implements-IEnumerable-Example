﻿using System.Collections;
using System.Collections.Generic;

namespace Wrox.ProCSharp.Generics
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> First { get; private set; }
        public LinkedListNode<T> Last { get; private set; }

        public LinkedListNode<T> AddLast(T node)
        {
            var newNode = new LinkedListNode<T>(node);
            if (First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                newNode.Prev = Last;
                Last.Next = newNode;
                Last = newNode;
            }
            return newNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = First;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public LinkedListNode<T> AddFirst(T node)
        {
            var newNode = new LinkedListNode<T>(node);
            if (Last == null)
            {
                Last = newNode;
                First = Last;
            }
            else
            {
                First.Prev = newNode;
                newNode.Next = First;
                First = newNode;
            }
            return newNode;
        }
    }
}