// Decompiled with JetBrains decompiler
// Type: AmplifyMotionPostProcess
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("")]
[RequireComponent(typeof (Camera))]
public sealed class AmplifyMotionPostProcess : MonoBehaviour
{
  private AmplifyMotionEffectBase m_instance;

  public AmplifyMotionEffectBase Instance
  {
    get => this.m_instance;
    set => this.m_instance = value;
  }

  private void OnRenderImage(RenderTexture source, RenderTexture destination)
  {
    if (!((Object) this.m_instance != (Object) null))
      return;
    this.m_instance.PostProcess(source, destination);
  }
}
