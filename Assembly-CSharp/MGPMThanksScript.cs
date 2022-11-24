// Decompiled with JetBrains decompiler
// Type: MGPMThanksScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class MGPMThanksScript : MonoBehaviour
{
  public AudioClip ThanksMusic;
  public AudioSource Jukebox;
  public Renderer Black;
  public int Phase = 1;

  private void Start()
  {
    this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    if (GameGlobals.Debug)
      return;
    PlayerPrefs.SetInt("Miyuki", 1);
    PlayerPrefs.SetInt("a", 1);
  }

  private void Update()
  {
    if (this.Phase == 1)
    {
      this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Black.material.color.a, 0.0f, Time.deltaTime));
      if ((double) this.Black.material.color.a != 0.0)
        return;
      this.Jukebox.Play();
      ++this.Phase;
    }
    else if (this.Phase == 2)
    {
      if (this.Jukebox.isPlaying)
        return;
      this.Jukebox.clip = this.ThanksMusic;
      this.Jukebox.loop = true;
      this.Jukebox.Play();
      ++this.Phase;
    }
    else if (this.Phase == 3)
    {
      if (!Input.anyKeyDown)
        return;
      ++this.Phase;
    }
    else
    {
      this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
      this.Jukebox.volume = 1f - this.Black.material.color.a;
      if ((double) this.Black.material.color.a != 1.0)
        return;
      HomeGlobals.MiyukiDefeated = true;
      SceneManager.LoadScene("HomeScene");
    }
  }
}
