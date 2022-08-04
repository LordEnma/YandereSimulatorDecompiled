// Decompiled with JetBrains decompiler
// Type: BrokenScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BrokenScript : MonoBehaviour
{
  public DynamicBone[] HairPhysics;
  public string[] MutterTexts;
  public AudioClip[] Mutters;
  public Vector3 PermanentAngleR;
  public Vector3 PermanentAngleL;
  public Transform TwintailR;
  public Transform TwintailL;
  public AudioClip KillKillKill;
  public AudioClip Stab;
  public AudioClip DoIt;
  public GameObject VoiceClip;
  public GameObject Yandere;
  public UILabel Subtitle;
  public AudioSource MyAudio;
  public bool Hunting;
  public bool Stabbed;
  public bool Began;
  public bool Done;
  public float SuicideTimer;
  public float Timer;
  public int ID = 1;

  private void Start()
  {
    this.HairPhysics[0].enabled = false;
    this.HairPhysics[1].enabled = false;
    this.PermanentAngleR = this.TwintailR.eulerAngles;
    this.PermanentAngleL = this.TwintailL.eulerAngles;
    this.Subtitle = GameObject.Find("EventSubtitle").GetComponent<UILabel>();
    this.Yandere = GameObject.Find("YandereChan");
  }

  private void Update()
  {
    if (!this.Done)
    {
      float num1 = Vector3.Distance(this.Yandere.transform.position, this.transform.root.position);
      if ((double) num1 < 6.0)
      {
        if ((double) num1 < 5.0)
        {
          if (!this.Hunting)
          {
            this.Timer += Time.deltaTime;
            if ((Object) this.VoiceClip == (Object) null)
              this.Subtitle.text = "";
            if ((double) this.Timer > 5.0)
            {
              this.Timer = 0.0f;
              this.Subtitle.text = this.MutterTexts[this.ID];
              AudioClipPlayer.PlayAttached(this.Mutters[this.ID], this.transform.position, this.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
              ++this.ID;
              if (this.ID == this.Mutters.Length)
                this.ID = 1;
            }
          }
          else if (!this.Began)
          {
            if ((Object) this.VoiceClip != (Object) null)
              Object.Destroy((Object) this.VoiceClip);
            this.Subtitle.text = "Do it.";
            AudioClipPlayer.PlayAttached(this.DoIt, this.transform.position, this.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
            this.Began = true;
          }
          else if ((Object) this.VoiceClip == (Object) null)
          {
            this.Subtitle.text = "...kill...kill...kill...";
            AudioClipPlayer.PlayAttached(this.KillKillKill, this.transform.position, this.transform, 1f, 5f, out this.VoiceClip, this.Yandere.transform.position.y);
          }
          float num2 = Mathf.Abs((float) (((double) num1 - 5.0) * 0.20000000298023224));
          float num3 = (double) num2 > 1.0 ? 1f : num2;
          this.Subtitle.transform.localScale = new Vector3(num3, num3, num3);
        }
        else
          this.Subtitle.transform.localScale = Vector3.zero;
      }
    }
    Vector3 eulerAngles1 = this.TwintailR.eulerAngles;
    Vector3 eulerAngles2 = this.TwintailL.eulerAngles;
    eulerAngles1.x = this.PermanentAngleR.x;
    eulerAngles1.z = this.PermanentAngleR.z;
    eulerAngles2.x = this.PermanentAngleL.x;
    eulerAngles2.z = this.PermanentAngleL.z;
    this.TwintailR.eulerAngles = eulerAngles1;
    this.TwintailL.eulerAngles = eulerAngles2;
  }
}
