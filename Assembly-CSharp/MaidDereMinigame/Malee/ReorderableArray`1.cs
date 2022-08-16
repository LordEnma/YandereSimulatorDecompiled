// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Malee.ReorderableArray`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
  [Serializable]
  public abstract class ReorderableArray<T> : 
    ICloneable,
    IList<T>,
    ICollection<T>,
    IEnumerable<T>,
    IEnumerable
  {
    [SerializeField]
    private List<T> array = new List<T>();

    public ReorderableArray()
      : this(0)
    {
    }

    public ReorderableArray(int length) => this.array = new List<T>(length);

    public T this[int index]
    {
      get => this.array[index];
      set => this.array[index] = value;
    }

    public int Length => this.array.Count;

    public bool IsReadOnly => false;

    public int Count => this.array.Count;

    public object Clone() => (object) new List<T>((IEnumerable<T>) this.array);

    public void CopyFrom(IEnumerable<T> value)
    {
      this.array.Clear();
      this.array.AddRange(value);
    }

    public bool Contains(T value) => this.array.Contains(value);

    public int IndexOf(T value) => this.array.IndexOf(value);

    public void Insert(int index, T item) => this.array.Insert(index, item);

    public void RemoveAt(int index) => this.array.RemoveAt(index);

    public void Add(T item) => this.array.Add(item);

    public void Clear() => this.array.Clear();

    public void CopyTo(T[] array, int arrayIndex) => this.array.CopyTo(array, arrayIndex);

    public bool Remove(T item) => this.array.Remove(item);

    public T[] ToArray() => this.array.ToArray();

    public IEnumerator<T> GetEnumerator() => (IEnumerator<T>) this.array.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.array.GetEnumerator();
  }
}
