// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.MinAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class MinAttribute : PropertyAttribute
  {
    public readonly float min;

    public MinAttribute(float min) => this.min = min;
  }
}
