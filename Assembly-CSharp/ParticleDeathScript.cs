// Decompiled with JetBrains decompiler
// Type: ParticleDeathScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
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
