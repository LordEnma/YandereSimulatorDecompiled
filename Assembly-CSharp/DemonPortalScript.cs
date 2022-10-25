// Decompiled with JetBrains decompiler
// Type: DemonPortalScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DemonPortalScript : MonoBehaviour
{
  public YandereScript Yandere;
  public JukeboxScript Jukebox;
  public PromptScript Prompt;
  public ClockScript Clock;
  public AudioSource DemonRealmAudio;
  public GameObject HeartbeatCamera;
  public GameObject DarkAura;
  public GameObject FPS;
  public GameObject HUD;
  public UISprite Darkness;
  public float Timer;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
      this.Yandere.CanMove = false;
      Object.Instantiate<GameObject>(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
      this.Timer += Time.deltaTime;
    }
    this.DemonRealmAudio.volume = Mathf.MoveTowards(this.DemonRealmAudio.volume, (double) this.Yandere.transform.position.y > 1000.0 ? 0.5f : 0.0f, Time.deltaTime * 0.1f);
    if ((double) this.Timer <= 0.0)
      return;
    if ((double) this.Yandere.transform.position.y > 1000.0)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 4.0)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
        if ((double) this.Darkness.color.a != 1.0)
          return;
        this.Yandere.transform.position = new Vector3(12f, 0.0f, 28f);
        this.Yandere.Character.SetActive(true);
        this.Yandere.SetAnimationLayers();
        this.HeartbeatCamera.SetActive(true);
        this.FPS.SetActive(true);
        this.HUD.SetActive(true);
      }
      else
      {
        if ((double) this.Timer <= 1.0)
          return;
        this.Yandere.Character.SetActive(false);
      }
    }
    else
    {
      this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.5f, Time.deltaTime * 0.5f);
      if ((double) this.Jukebox.Volume != 0.5)
        return;
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
      if ((double) this.Darkness.color.a != 0.0)
        return;
      this.transform.parent.gameObject.SetActive(false);
      this.Darkness.enabled = false;
      this.Yandere.CanMove = true;
      this.Clock.StopTime = false;
      this.Timer = 0.0f;
    }
  }
}
