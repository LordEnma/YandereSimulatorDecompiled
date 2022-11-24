// Decompiled with JetBrains decompiler
// Type: WalkToSchoolManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkToSchoolManagerScript : MonoBehaviour
{
  public PromptBarScript PromptBar;
  public CosmeticScript Yandere;
  public CosmeticScript Senpai;
  public CosmeticScript Rival;
  public UISprite Darkness;
  public Transform[] Neighborhood;
  public Transform Window;
  public Transform RivalNeck;
  public Transform RivalHead;
  public Transform RivalEyeR;
  public Transform RivalEyeL;
  public Transform RivalJaw;
  public Transform RivalLipL;
  public Transform RivalLipR;
  public Transform SenpaiNeck;
  public Transform SenpaiHead;
  public Transform SenpaiEyeR;
  public Transform SenpaiEyeL;
  public Transform SenpaiJaw;
  public Transform SenpaiLipL;
  public Transform SenpaiLipR;
  public Transform YandereNeck;
  public Transform YandereHead;
  public Transform YandereEyeR;
  public Transform YandereEyeL;
  public AudioSource MyAudio;
  public float ScrollSpeed = 1f;
  public float LipStrength = 0.0001f;
  public float TimerLimit = 0.1f;
  public float TalkSpeed = 10f;
  public float AutoTimer;
  public float Timer;
  public float MouthExtent = 5f;
  public float MouthTarget;
  public float MouthTimer;
  public float RivalNeckTarget;
  public float RivalHeadTarget;
  public float RivalEyeRTarget;
  public float RivalEyeLTarget;
  public float SenpaiNeckTarget;
  public float SenpaiHeadTarget;
  public float SenpaiEyeRTarget;
  public float SenpaiEyeLTarget;
  public float YandereNeckTarget;
  public float YandereHeadTarget;
  public bool ShowWindow;
  public bool Debugging;
  public bool FadeOut;
  public bool Ending;
  public bool Auto;
  public bool Talk;
  public TypewriterEffect Typewriter;
  public UILabel NameLabel;
  public AudioClip[] Speech;
  public string[] Lines;
  public bool[] Speakers;
  public int Frame;
  public int ID;
  public Renderer PonytailRenderer;
  public Texture BlondePony;

  private void Start()
  {
    Application.targetFrameRate = 60;
    if ((double) SchoolGlobals.SchoolAtmosphere < 0.5 || GameGlobals.LoveSick)
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    else
      this.Darkness.color = new Color(1f, 1f, 1f, 1f);
    this.Window.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    this.Yandere.Character.GetComponent<Animation>()["f02_newWalk_00"].time = Random.Range(0.0f, this.Yandere.Character.GetComponent<Animation>()["f02_newWalk_00"].length);
    this.Yandere.WearOutdoorShoes();
    this.Senpai.WearOutdoorShoes();
    this.Rival.WearOutdoorShoes();
    if (!GameGlobals.BlondeHair)
      return;
    this.PonytailRenderer.material.mainTexture = this.BlondePony;
  }

  private void Update()
  {
    for (int index = 1; index < 3; ++index)
    {
      Transform transform = this.Neighborhood[index];
      transform.position = new Vector3(transform.position.x - Time.deltaTime * this.ScrollSpeed, transform.position.y, transform.position.z);
      if ((double) transform.position.x < -160.0)
        transform.position = new Vector3(transform.position.x + 320f, transform.position.y, transform.position.z);
    }
    if (!this.FadeOut)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
      if ((double) this.Darkness.color.a == 0.0)
      {
        if (!this.ShowWindow)
        {
          if (!this.Ending)
          {
            if (Input.GetButtonDown("A"))
              this.Timer = 1f;
            this.Timer += Time.deltaTime;
            if ((double) this.Timer > 1.0)
            {
              this.RivalEyeRTarget = this.RivalEyeR.localEulerAngles.y;
              this.RivalEyeLTarget = this.RivalEyeL.localEulerAngles.y;
              this.SenpaiEyeRTarget = this.SenpaiEyeR.localEulerAngles.y;
              this.SenpaiEyeLTarget = this.SenpaiEyeL.localEulerAngles.y;
              this.ShowWindow = true;
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Continue";
              this.PromptBar.Label[2].text = "Skip";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
            }
          }
          else
          {
            this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * 10f);
            if ((double) this.Window.localScale.x < 0.01)
            {
              this.Timer += Time.deltaTime;
              if ((double) this.Timer > 1.0)
                this.FadeOut = true;
            }
          }
        }
        else
        {
          this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
          if ((double) this.Window.localScale.x > 0.99)
          {
            if (this.Frame > 3)
              this.Typewriter.mLabel.color = new Color(1f, 1f, 1f, 1f);
            ++this.Frame;
          }
          if (!this.Talk)
          {
            if ((double) this.Window.localScale.x > 0.99)
            {
              this.Talk = true;
              this.UpdateNameLabel();
              this.Typewriter.enabled = true;
              this.Typewriter.ResetToBeginning();
              this.Typewriter.mFullText = this.Lines[this.ID];
              this.Typewriter.mLabel.text = this.Lines[this.ID];
              this.Typewriter.mLabel.color = new Color(1f, 1f, 1f, 0.0f);
              this.MyAudio.clip = this.Speech[this.ID];
              this.MyAudio.Play();
            }
          }
          else
          {
            if (this.Auto && !this.MyAudio.isPlaying)
              this.AutoTimer += Time.deltaTime;
            if (Input.GetButtonDown("A") || (double) this.AutoTimer > 1.0)
            {
              Debug.Log((object) "Detected button press.");
              this.AutoTimer = 0.0f;
              if (this.ID < this.Lines.Length - 1)
              {
                if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
                {
                  Debug.Log((object) "Line not finished yet.");
                  this.Typewriter.Finish();
                  this.Typewriter.mCurrentOffset = this.Typewriter.mFullText.Length;
                }
                else
                {
                  Debug.Log((object) "Line finished.");
                  ++this.ID;
                  this.Frame = 0;
                  this.Typewriter.ResetToBeginning();
                  this.Typewriter.mFullText = this.Lines[this.ID];
                  this.Typewriter.mLabel.text = this.Lines[this.ID];
                  this.Typewriter.mLabel.color = new Color(1f, 1f, 1f, 0.0f);
                  this.MyAudio.clip = this.Speech[this.ID];
                  this.MyAudio.Play();
                  this.UpdateNameLabel();
                }
              }
              else if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
                this.Typewriter.Finish();
              else
                this.End();
            }
            if (Input.GetButtonDown("X"))
              this.End();
          }
        }
      }
    }
    else
    {
      this.MyAudio.volume -= Time.deltaTime;
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a == 1.0 && !this.Debugging)
        SceneManager.LoadScene("LoadingScene");
    }
    if (Input.GetKeyDown(KeyCode.Equals))
      Time.timeScale += 10f;
    if (!Input.GetKeyDown(KeyCode.Minus))
      return;
    Time.timeScale -= 10f;
  }

  private void LateUpdate()
  {
    if (!this.Talk)
      return;
    if (!this.Ending)
    {
      this.RivalNeckTarget = Mathf.Lerp(this.RivalNeckTarget, 15f, Time.deltaTime * 3.6f);
      this.RivalHeadTarget = Mathf.Lerp(this.RivalHeadTarget, 15f, Time.deltaTime * 3.6f);
      this.RivalEyeRTarget = Mathf.Lerp(this.RivalEyeRTarget, 95f, Time.deltaTime * 3.6f);
      this.RivalEyeLTarget = Mathf.Lerp(this.RivalEyeLTarget, 275f, Time.deltaTime * 3.6f);
      this.SenpaiNeckTarget = Mathf.Lerp(this.SenpaiNeckTarget, -15f, Time.deltaTime * 3.6f);
      this.SenpaiHeadTarget = Mathf.Lerp(this.SenpaiHeadTarget, -15f, Time.deltaTime * 3.6f);
      this.SenpaiEyeRTarget = Mathf.Lerp(this.SenpaiEyeRTarget, 85f, Time.deltaTime * 3.6f);
      this.SenpaiEyeLTarget = Mathf.Lerp(this.SenpaiEyeLTarget, 265f, Time.deltaTime * 3.6f);
      this.YandereNeckTarget = Mathf.Lerp(this.YandereNeckTarget, 7.5f, Time.deltaTime * 3.6f);
      this.YandereHeadTarget = Mathf.Lerp(this.YandereHeadTarget, 7.5f, Time.deltaTime * 3.6f);
    }
    else
    {
      this.RivalNeckTarget = Mathf.Lerp(this.RivalNeckTarget, 0.0f, Time.deltaTime * 3.6f);
      this.RivalHeadTarget = Mathf.Lerp(this.RivalHeadTarget, 0.0f, Time.deltaTime * 3.6f);
      this.RivalEyeRTarget = Mathf.Lerp(this.RivalEyeRTarget, 90f, Time.deltaTime * 3.6f);
      this.RivalEyeLTarget = Mathf.Lerp(this.RivalEyeLTarget, 270f, Time.deltaTime * 3.6f);
      this.SenpaiNeckTarget = Mathf.Lerp(this.SenpaiNeckTarget, 0.0f, Time.deltaTime * 3.6f);
      this.SenpaiHeadTarget = Mathf.Lerp(this.SenpaiHeadTarget, 0.0f, Time.deltaTime * 3.6f);
      this.SenpaiEyeRTarget = Mathf.Lerp(this.SenpaiEyeRTarget, 90f, Time.deltaTime * 3.6f);
      this.SenpaiEyeLTarget = Mathf.Lerp(this.SenpaiEyeLTarget, 270f, Time.deltaTime * 3.6f);
      this.YandereNeckTarget = Mathf.Lerp(this.YandereNeckTarget, 0.0f, Time.deltaTime * 3.6f);
      this.YandereHeadTarget = Mathf.Lerp(this.YandereHeadTarget, 0.0f, Time.deltaTime * 3.6f);
    }
    this.RivalNeck.localEulerAngles = new Vector3(this.RivalNeck.localEulerAngles.x, this.RivalNeckTarget, this.RivalNeck.localEulerAngles.z);
    this.RivalHead.localEulerAngles = new Vector3(this.RivalHead.localEulerAngles.x, this.RivalHeadTarget, this.RivalHead.localEulerAngles.z);
    this.RivalEyeR.localEulerAngles = new Vector3(this.RivalEyeR.localEulerAngles.x, this.RivalEyeRTarget, this.RivalEyeR.localEulerAngles.z);
    this.RivalEyeL.localEulerAngles = new Vector3(this.RivalEyeL.localEulerAngles.x, this.RivalEyeLTarget, this.RivalEyeL.localEulerAngles.z);
    this.SenpaiNeck.localEulerAngles = new Vector3(this.SenpaiNeck.localEulerAngles.x, this.SenpaiNeckTarget, this.SenpaiNeck.localEulerAngles.z);
    this.SenpaiHead.localEulerAngles = new Vector3(this.SenpaiHead.localEulerAngles.x, this.SenpaiHeadTarget, this.SenpaiHead.localEulerAngles.z);
    this.SenpaiEyeR.localEulerAngles = new Vector3(this.SenpaiEyeR.localEulerAngles.x, this.SenpaiEyeRTarget, this.SenpaiEyeR.localEulerAngles.z);
    this.SenpaiEyeL.localEulerAngles = new Vector3(this.SenpaiEyeL.localEulerAngles.x, this.SenpaiEyeLTarget, this.SenpaiEyeL.localEulerAngles.z);
    this.YandereNeck.localEulerAngles = new Vector3(this.YandereNeck.localEulerAngles.x, this.YandereNeckTarget, this.YandereNeck.localEulerAngles.z);
    this.YandereHead.localEulerAngles = new Vector3(this.YandereHead.localEulerAngles.x, this.YandereHeadTarget, this.YandereHead.localEulerAngles.z);
    if (!this.MyAudio.isPlaying)
      return;
    this.MouthTimer += Time.deltaTime;
    if ((double) this.MouthTimer > (double) this.TimerLimit)
    {
      this.MouthTarget = Random.Range(40f, 40f + this.MouthExtent);
      this.MouthTimer = 0.0f;
    }
    if (this.Speakers[this.ID])
    {
      this.RivalJaw.localEulerAngles = new Vector3(this.RivalJaw.localEulerAngles.x, this.RivalJaw.localEulerAngles.y, Mathf.Lerp(this.RivalJaw.localEulerAngles.z, this.MouthTarget, Time.deltaTime * this.TalkSpeed));
      this.RivalLipL.localPosition = new Vector3(this.RivalLipL.localPosition.x, Mathf.Lerp(this.RivalLipL.localPosition.y, (float) (0.02632812038064003 + (double) this.MouthTarget * (double) this.LipStrength), Time.deltaTime * this.TalkSpeed), this.RivalLipL.localPosition.z);
      this.RivalLipR.localPosition = new Vector3(this.RivalLipR.localPosition.x, Mathf.Lerp(this.RivalLipR.localPosition.y, (float) (0.02632812038064003 + (double) this.MouthTarget * (double) this.LipStrength), Time.deltaTime * this.TalkSpeed), this.RivalLipR.localPosition.z);
    }
    else
    {
      this.SenpaiJaw.localEulerAngles = new Vector3(this.SenpaiJaw.localEulerAngles.x, this.SenpaiJaw.localEulerAngles.y, Mathf.Lerp(this.SenpaiJaw.localEulerAngles.z, this.MouthTarget, Time.deltaTime * this.TalkSpeed));
      this.SenpaiLipL.localPosition = new Vector3(this.SenpaiLipL.localPosition.x, Mathf.Lerp(this.SenpaiLipL.localPosition.y, (float) (0.02632812038064003 + (double) this.MouthTarget * (double) this.LipStrength), Time.deltaTime * this.TalkSpeed), this.SenpaiLipL.localPosition.z);
      this.SenpaiLipR.localPosition = new Vector3(this.SenpaiLipR.localPosition.x, Mathf.Lerp(this.SenpaiLipR.localPosition.y, (float) (0.02632812038064003 + (double) this.MouthTarget * (double) this.LipStrength), Time.deltaTime * this.TalkSpeed), this.SenpaiLipR.localPosition.z);
    }
  }

  public void UpdateNameLabel()
  {
    if (this.Speakers[this.ID])
      this.NameLabel.text = "Osana-chan";
    else
      this.NameLabel.text = "Senpai-kun";
  }

  public void End()
  {
    this.PromptBar.Show = false;
    this.ShowWindow = false;
    this.Ending = true;
    this.Timer = 0.0f;
  }
}
