// Decompiled with JetBrains decompiler
// Type: BetterList`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BetterList<T>
{
  public T[] buffer;
  public int size;

  [DebuggerHidden]
  [DebuggerStepThrough]
  public IEnumerator<T> GetEnumerator()
  {
    if (this.buffer != null)
    {
      for (int i = 0; i < this.size; ++i)
        yield return this.buffer[i];
    }
  }

  [DebuggerHidden]
  [Obsolete("Access the list.buffer[index] instead -- direct array access avoids a copy, so it can be much faster")]
  public T this[int i]
  {
    get => this.buffer[i];
    set => this.buffer[i] = value;
  }

  private void AllocateMore()
  {
    T[] objArray = this.buffer != null ? new T[Mathf.Max(this.buffer.Length << 1, 32)] : new T[32];
    if (this.buffer != null && this.size > 0)
      this.buffer.CopyTo((Array) objArray, 0);
    this.buffer = objArray;
  }

  private void Trim()
  {
    if (this.size > 0)
    {
      if (this.size >= this.buffer.Length)
        return;
      T[] objArray = new T[this.size];
      for (int index = 0; index < this.size; ++index)
        objArray[index] = this.buffer[index];
      this.buffer = objArray;
    }
    else
      this.buffer = (T[]) null;
  }

  public void Clear() => this.size = 0;

  public void Release()
  {
    this.size = 0;
    this.buffer = (T[]) null;
  }

  public void Add(T item)
  {
    if (this.buffer == null || this.size == this.buffer.Length)
      this.AllocateMore();
    this.buffer[this.size++] = item;
  }

  public void Insert(int index, T item)
  {
    if (this.buffer == null || this.size == this.buffer.Length)
      this.AllocateMore();
    if (index > -1 && index < this.size)
    {
      for (int size = this.size; size > index; --size)
        this.buffer[size] = this.buffer[size - 1];
      this.buffer[index] = item;
      ++this.size;
    }
    else
      this.Add(item);
  }

  public bool Contains(T item)
  {
    if (this.buffer == null)
      return false;
    for (int index = 0; index < this.size; ++index)
    {
      if (this.buffer[index].Equals((object) item))
        return true;
    }
    return false;
  }

  public int IndexOf(T item)
  {
    if (this.buffer == null)
      return -1;
    for (int index = 0; index < this.size; ++index)
    {
      if (this.buffer[index].Equals((object) item))
        return index;
    }
    return -1;
  }

  public bool Remove(T item)
  {
    if (this.buffer != null)
    {
      EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
      for (int index1 = 0; index1 < this.size; ++index1)
      {
        if (equalityComparer.Equals(this.buffer[index1], item))
        {
          --this.size;
          this.buffer[index1] = default (T);
          for (int index2 = index1; index2 < this.size; ++index2)
            this.buffer[index2] = this.buffer[index2 + 1];
          this.buffer[this.size] = default (T);
          return true;
        }
      }
    }
    return false;
  }

  public void RemoveAt(int index)
  {
    if (this.buffer == null || index <= -1 || index >= this.size)
      return;
    --this.size;
    this.buffer[index] = default (T);
    for (int index1 = index; index1 < this.size; ++index1)
      this.buffer[index1] = this.buffer[index1 + 1];
    this.buffer[this.size] = default (T);
  }

  public T Pop()
  {
    if (this.buffer == null || this.size == 0)
      return default (T);
    T obj = this.buffer[--this.size];
    this.buffer[this.size] = default (T);
    return obj;
  }

  public T[] ToArray()
  {
    this.Trim();
    return this.buffer;
  }

  [DebuggerHidden]
  [DebuggerStepThrough]
  public void Sort(BetterList<T>.CompareFunc comparer)
  {
    int num1 = 0;
    int num2 = this.size - 1;
    bool flag = true;
    while (flag)
    {
      flag = false;
      for (int index = num1; index < num2; ++index)
      {
        if (comparer(this.buffer[index], this.buffer[index + 1]) > 0)
        {
          T obj = this.buffer[index];
          this.buffer[index] = this.buffer[index + 1];
          this.buffer[index + 1] = obj;
          flag = true;
        }
        else if (!flag)
          num1 = index == 0 ? 0 : index - 1;
      }
    }
  }

  public delegate int CompareFunc(T left, T right);
}
