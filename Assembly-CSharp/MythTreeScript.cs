// Decompiled with JetBrains decompiler
// Type: MythTreeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MythTreeScript : MonoBehaviour
{
  public UILabel EventSubtitle;
  public JukeboxScript Jukebox;
  public YandereScript Yandere;
  public bool Spoken;
  public AudioSource MyAudio;

  private void Start()
  {
    if (SchemeGlobals.GetSchemeStage(2) <= 2 && !GameGlobals.Eighties)
      return;
    Object.Destroy((Object) this);
  }

  private void Update()
  {
    if (!this.Spoken)
    {
      if (!this.Yandere.Inventory.Ring || (double) Vector3.Distance(this.Yandere.transform.position, this.transform.position) >= 5.0)
        return;
      this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
      this.EventSubtitle.text = "...that...ring...";
      this.Jukebox.Dip = 0.5f;
      this.Spoken = true;
      this.MyAudio.Play();
    }
    else
    {
      if (this.MyAudio.isPlaying)
        return;
      this.EventSubtitle.transform.localScale = Vector3.zero;
      this.EventSubtitle.text = string.Empty;
      this.Jukebox.Dip = 1f;
      Object.Destroy((Object) this);
    }
  }
}
