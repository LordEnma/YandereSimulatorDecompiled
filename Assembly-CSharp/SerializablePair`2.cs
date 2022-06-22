// Decompiled with JetBrains decompiler
// Type: SerializablePair`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public class SerializablePair<T, U>
{
  public T first;
  public U second;

  public SerializablePair(T first, U second)
  {
    this.first = first;
    this.second = second;
  }

  public SerializablePair()
    : this(default (T), default (U))
  {
  }
}
