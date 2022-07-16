// Decompiled with JetBrains decompiler
// Type: OsanaJokeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class OsanaJokeScript : MonoBehaviour
{
  public ConstantRandomRotation[] Rotation;
  public GameObject BloodSplatterEffect;
  public AudioClip BloodSplatterSFX;
  public AudioClip VictoryMusic;
  public AudioSource Jukebox;
  public Transform Head;
  public UILabel Label;
  public bool Advance;
  public float Timer;
  public int ID;

  private void Update()
  {
    if (this.Advance)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 14.0)
      {
        Application.Quit();
      }
      else
      {
        if ((double) this.Timer <= 3.0)
          return;
        this.Label.text = "Congratulations! You have beaten Yandere Simulator!";
        if (this.Jukebox.isPlaying)
          return;
        this.Jukebox.clip = this.VictoryMusic;
        this.Jukebox.Play();
      }
    }
    else
    {
      if (!Input.GetKeyDown("f"))
        return;
      this.Rotation[0].enabled = false;
      this.Rotation[1].enabled = false;
      this.Rotation[2].enabled = false;
      this.Rotation[3].enabled = false;
      this.Rotation[4].enabled = false;
      this.Rotation[5].enabled = false;
      this.Rotation[6].enabled = false;
      this.Rotation[7].enabled = false;
      Object.Instantiate<GameObject>(this.BloodSplatterEffect, this.Head.position, Quaternion.identity);
      this.Head.localScale = new Vector3(0.0f, 0.0f, 0.0f);
      this.Jukebox.clip = this.BloodSplatterSFX;
      this.Jukebox.Play();
      this.Label.text = "";
      this.Advance = true;
    }
  }
}
