// Decompiled with JetBrains decompiler
// Type: ClubAmbienceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ClubAmbienceScript : MonoBehaviour
{
  public JukeboxScript Jukebox;
  public Transform Yandere;
  public bool CreateAmbience;
  public bool EffectJukebox;
  public float ClubDip;
  public float MaxVolume;

  private void Update()
  {
    if ((double) this.Yandere.position.y > (double) this.transform.position.y - 0.100000001490116 && (double) this.Yandere.position.y < (double) this.transform.position.y + 0.100000001490116)
    {
      if ((double) Vector3.Distance(this.transform.position, this.Yandere.position) < 4.0)
      {
        this.CreateAmbience = true;
        this.EffectJukebox = true;
      }
      else
        this.CreateAmbience = false;
    }
    if (!this.EffectJukebox)
      return;
    AudioSource component = this.GetComponent<AudioSource>();
    if (this.CreateAmbience)
    {
      component.volume = Mathf.MoveTowards(component.volume, this.MaxVolume, Time.deltaTime * 0.1f);
      this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, this.ClubDip, Time.deltaTime * 0.1f);
    }
    else
    {
      component.volume = Mathf.MoveTowards(component.volume, 0.0f, Time.deltaTime * 0.1f);
      this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, 0.0f, Time.deltaTime * 0.1f);
      if ((double) this.Jukebox.ClubDip != 0.0)
        return;
      this.EffectJukebox = false;
    }
  }
}
