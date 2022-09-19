// Decompiled with JetBrains decompiler
// Type: SerializedComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
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
