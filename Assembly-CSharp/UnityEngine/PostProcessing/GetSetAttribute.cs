// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.GetSetAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class GetSetAttribute : PropertyAttribute
  {
    public readonly string name;
    public bool dirty;

    public GetSetAttribute(string name) => this.name = name;
  }
}
