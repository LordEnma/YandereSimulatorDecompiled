// Decompiled with JetBrains decompiler
// Type: CheerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CheerScript : MonoBehaviour
{
  public AudioSource MyAudio;
  public AudioClip[] Cheers;
  public float Timer;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 5.0)
      return;
    this.MyAudio.clip = this.Cheers[Random.Range(1, this.Cheers.Length)];
    this.MyAudio.Play();
    this.Timer = 0.0f;
  }
}
