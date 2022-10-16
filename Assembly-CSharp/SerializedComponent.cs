// Decompiled with JetBrains decompiler
// Type: SerializedComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
