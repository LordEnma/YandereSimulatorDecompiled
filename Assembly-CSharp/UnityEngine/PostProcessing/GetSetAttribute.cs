// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.GetSetAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class GetSetAttribute : PropertyAttribute
  {
    public readonly string name;
    public bool dirty;

    public GetSetAttribute(string name) => this.name = name;
  }
}
