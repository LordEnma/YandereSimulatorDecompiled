// Decompiled with JetBrains decompiler
// Type: SerializablePair`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
