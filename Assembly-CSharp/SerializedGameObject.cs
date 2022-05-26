// Decompiled with JetBrains decompiler
// Type: SerializedGameObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
