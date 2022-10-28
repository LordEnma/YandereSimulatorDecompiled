// Decompiled with JetBrains decompiler
// Type: SerializedGameObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public struct SerializedGameObject
{
  public bool ActiveInHierarchy;
  public bool ActiveSelf;
  public bool IsStatic;
  public int Layer;
  public string Tag;
  public string Name;
  public string ObjectID;
  public SerializedComponent[] SerializedComponents;
}
