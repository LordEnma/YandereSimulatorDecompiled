// Decompiled with JetBrains decompiler
// Type: ParticleDeathScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
