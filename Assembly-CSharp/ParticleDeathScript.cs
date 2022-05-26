// Decompiled with JetBrains decompiler
// Type: ParticleDeathScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ParticleDeathScript : MonoBehaviour
{
  public ParticleSystem Particles;

  private void LateUpdate()
  {
    if (!this.Particles.isPlaying || this.Particles.particleCount != 0)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
