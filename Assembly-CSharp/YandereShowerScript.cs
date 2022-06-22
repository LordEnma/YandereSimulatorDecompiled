// Decompiled with JetBrains decompiler
// Type: YandereShowerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YandereShowerScript : MonoBehaviour
{
  public SkinnedMeshRenderer Curtain;
  public GameObject CensorSteam;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public Transform BatheSpot;
  public float OpenValue;
  public float Timer;
  public bool UpdateCurtain;
  public bool Open;
  public AudioSource MyAudio;
  public AudioClip CurtainClose;
  public AudioClip CurtainOpen;

  private void Start()
  {
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      if (this.Yandere.Schoolwear > 0 && this.Yandere.Schoolwear != 2 || this.Yandere.Chased || this.Yandere.Chasers > 0 || (double) this.Yandere.Bloodiness == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
      }
      else
      {
        AudioSource.PlayClipAtPoint(this.CurtainOpen, this.transform.position);
        this.CensorSteam.SetActive(true);
        this.MyAudio.Play();
        this.Yandere.EmptyHands();
        this.Yandere.YandereShower = this;
        this.Yandere.CanMove = false;
        this.Yandere.Bathing = true;
        this.UpdateCurtain = true;
        this.Open = true;
        this.Timer = 6f;
      }
    }
    if (!this.UpdateCurtain)
      return;
    this.Timer = Mathf.MoveTowards(this.Timer, 0.0f, Time.deltaTime);
    if ((double) this.Timer < 1.0)
    {
      if (this.Open)
        AudioSource.PlayClipAtPoint(this.CurtainClose, this.transform.position);
      this.Open = false;
      if ((double) this.Timer == 0.0)
      {
        this.CensorSteam.SetActive(false);
        this.UpdateCurtain = false;
      }
    }
    if (this.Open)
    {
      this.OpenValue = Mathf.Lerp(this.OpenValue, 0.0f, Time.deltaTime * 10f);
      this.Curtain.SetBlendShapeWeight(0, this.OpenValue);
    }
    else
    {
      this.OpenValue = Mathf.Lerp(this.OpenValue, 100f, Time.deltaTime * 10f);
      this.Curtain.SetBlendShapeWeight(0, this.OpenValue);
    }
  }
}
