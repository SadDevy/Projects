﻿using System;

namespace BinarySearch
{
    public class Node<TItem> : IEquatable<Node<TItem>>
        where TItem : IComparable<TItem>
    {
        public TItem Data { get; private set; }
        public Node<TItem> Right { get; set; }
        public Node<TItem> Left { get; set; }

        public bool HasRight => Right != null;
        public bool HasLeft => Left != null;

        public Node(TItem data, Node<TItem> right = null, Node<TItem> left = null)
        {
            Data = data;
            Right = right;
            Left = left;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Node<TItem>))
                return false;

            Node<TItem> a = (Node<TItem>)obj;
            return Equals(a);
        }

        public bool Equals(Node<TItem> a)
        {
            if (a == null)
                return false;

            if (Data.CompareTo(a.Data) == 0)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }
    }
}
