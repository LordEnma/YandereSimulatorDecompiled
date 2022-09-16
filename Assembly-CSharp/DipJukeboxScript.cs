// Decompiled with JetBrains decompiler
// Type: DipJukeboxScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DipJukeboxScript : MonoBehaviour
{
  public JukeboxScript Jukebox;
  public AudioSource MyAudio;
  public Transform Yandere;

  private void Update()
  {
    if ((double) this.Yandere.transform.position.y < (double) this.transform.position.y - 0.10000000149011612)
      this.MyAudio.volume = 0.0f;
    else if (this.MyAudio.isPlaying)
    {
      this.MyAudio.volume = 1f;
      float num = Vector3.Distance(this.Yandere.position, this.transform.position);
      if ((double) num >= 8.0)
        return;
      this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, (float) ((7.0 - (double) num) * 0.25) * this.Jukebox.Volume, Time.deltaTime);
      if ((double) this.Jukebox.ClubDip < 0.0)
        this.Jukebox.ClubDip = 0.0f;
      if ((double) this.Jukebox.ClubDip <= (double) this.Jukebox.Volume)
        return;
      this.Jukebox.ClubDip = this.Jukebox.Volume;
    }
    else
    {
      if (!this.MyAudio.isPlaying)
        return;
      this.Jukebox.ClubDip = 0.0f;
    }
  }
}
