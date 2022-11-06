// Decompiled with JetBrains decompiler
// Type: DipJukeboxScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DipJukeboxScript : MonoBehaviour
{
  public JukeboxScript Jukebox;
  public AudioSource MyAudio;
  public Transform Yandere;

  private void Update()
  {
    if ((double) this.Yandere.transform.position.y < (double) this.transform.position.y - 1.0 || (double) this.Yandere.transform.position.y > (double) this.transform.position.y + 1.0)
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
