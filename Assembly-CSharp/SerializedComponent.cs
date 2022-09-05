// Decompiled with JetBrains decompiler
// Type: SerializedComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public struct SerializedComponent
{
  public string OwnerID;
  public string TypePath;
  public ValueDict PropertyValues;
  public ReferenceDict PropertyReferences;
  public ValueDict FieldValues;
  public ReferenceDict FieldReferences;
  public ReferenceArrayDict PropertyReferenceArrays;
  public ReferenceArrayDict FieldReferenceArrays;
  public bool IsEnabled;
  public bool IsMonoBehaviour;
}
