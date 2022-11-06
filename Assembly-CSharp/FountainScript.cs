// Decompiled with JetBrains decompiler
// Type: FountainScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FountainScript : MonoBehaviour
{
  public ParticleSystem Splashes;
  public UILabel EventSubtitle;
  public Collider[] Colliders;
  public bool Drowning;
  public AudioSource SpraySFX;
  public AudioSource DropsSFX;
  public float StartTimer;
  public float Timer;

  private void Start()
  {
    this.SpraySFX.volume = 0.1f;
    this.DropsSFX.volume = 0.1f;
  }

  private void Update()
  {
    if ((double) this.StartTimer < 1.0)
    {
      this.StartTimer += Time.deltaTime;
      if ((double) this.StartTimer > 1.0)
      {
        this.SpraySFX.gameObject.SetActive(true);
        this.DropsSFX.gameObject.SetActive(true);
      }
    }
    if (!this.Drowning)
      return;
    if ((double) this.Timer == 0.0 && (double) this.EventSubtitle.transform.localScale.x < 1.0)
    {
      this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
      this.EventSubtitle.text = "Hey, what are you -";
      this.GetComponent<AudioSource>().Play();
    }
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > 3.0 && (double) this.EventSubtitle.transform.localScale.x > 0.0)
    {
      this.EventSubtitle.transform.localScale = Vector3.zero;
      this.EventSubtitle.text = string.Empty;
      this.Splashes.Play();
    }
    if ((double) this.Timer <= 9.0)
      return;
    this.Drowning = false;
    this.Splashes.Stop();
    this.Timer = 0.0f;
  }
}
