// Decompiled with JetBrains decompiler
// Type: ParticleDeathScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
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
