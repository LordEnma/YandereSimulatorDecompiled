// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.TrackballAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class TrackballAttribute : PropertyAttribute
  {
    public readonly string method;

    public TrackballAttribute(string method) => this.method = method;
  }
}
