// Decompiled with JetBrains decompiler
// Type: SharpRaven.Utilities.CircularBuffer`1
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;


namespace SharpRaven.Utilities
{
  public class CircularBuffer<T>
  {
    private readonly int size;
    private ConcurrentQueue<T> queue;

    public CircularBuffer(int size = 100)
    {
      this.size = size;
      this.queue = new ConcurrentQueue<T>();
    }

    public List<T> ToList()
    {
      List<T> list = this.queue.ToList<T>();
      return list.Skip<T>(Math.Max(0, list.Count - this.size)).ToList<T>();
    }

    public void Clear() => this.queue = new ConcurrentQueue<T>();

    public void Add(T item)
    {
      if (this.queue.Count >= this.size)
        this.queue.TryDequeue(out T _);
      this.queue.Enqueue(item);
    }

    public bool IsEmpty() => this.queue.IsEmpty;
  }
}
