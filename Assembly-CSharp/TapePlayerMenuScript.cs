// Decompiled with JetBrains decompiler
// Type: TapePlayerMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TapePlayerMenuScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public TapePlayerScript TapePlayer;
  public PromptBarScript PromptBar;
  public Animation TapePlayerAnim;
  public AudioSource MyAudio;
  public GameObject Jukebox;
  public Transform TapePlayerCamera;
  public Transform Highlight;
  public Transform TimeBar;
  public Transform List;
  public AudioClip[] Recordings;
  public AudioClip[] BasementRecordings;
  public AudioClip[] HeadmasterRecordings;
  public UILabel[] TapeLabels;
  public GameObject[] NewIcons;
  public AudioClip TapeStop;
  public string CurrentTime;
  public string ClipLength;
  public bool ButtonPressed;
  public bool Listening;
  public bool Show;
  public UILabel HeaderLabel;
  public UILabel Subtitle;
  public UILabel Label;
  public UISprite Bar;
  public int TotalTapes = 10;
  public int Category = 1;
  public int Selected = 1;
  public int Phase = 1;
  public float RoundedTime;
  public float ResumeTime;
  public float Timer;
  public float[] Cues1;
  public float[] Cues2;
  public float[] Cues3;
  public float[] Cues4;
  public float[] Cues5;
  public float[] Cues6;
  public float[] Cues7;
  public float[] Cues8;
  public float[] Cues9;
  public float[] Cues10;
  public string[] Subs1;
  public string[] Subs2;
  public string[] Subs3;
  public string[] Subs4;
  public string[] Subs5;
  public string[] Subs6;
  public string[] Subs7;
  public string[] Subs8;
  public string[] Subs9;
  public string[] Subs10;
  public float[] BasementCues1;
  public float[] BasementCues10;
  public string[] BasementSubs1;
  public string[] BasementSubs10;
  public float[] HeadmasterCues1;
  public float[] HeadmasterCues2;
  public float[] HeadmasterCues3;
  public float[] HeadmasterCues4;
  public float[] HeadmasterCues5;
  public float[] HeadmasterCues6;
  public float[] HeadmasterCues7;
  public float[] HeadmasterCues8;
  public float[] HeadmasterCues9;
  public float[] HeadmasterCues10;
  public string[] HeadmasterSubs1;
  public string[] HeadmasterSubs2;
  public string[] HeadmasterSubs3;
  public string[] HeadmasterSubs4;
  public string[] HeadmasterSubs5;
  public string[] HeadmasterSubs6;
  public string[] HeadmasterSubs7;
  public string[] HeadmasterSubs8;
  public string[] HeadmasterSubs9;
  public string[] HeadmasterSubs10;

  private void Start()
  {
    this.List.transform.localPosition = new Vector3(-955f, this.List.transform.localPosition.y, this.List.transform.localPosition.z);
    this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, 100f, this.TimeBar.localPosition.z);
    this.Subtitle.text = string.Empty;
    this.TapePlayerCamera.position = new Vector3(-26.15f, this.TapePlayerCamera.position.y, 5.35f);
  }

  private void Update()
  {
    float t = Time.unscaledDeltaTime * 10f;
    if (Input.GetKeyDown("="))
      ++this.MyAudio.pitch;
    if (Input.GetKeyDown("-"))
      --this.MyAudio.pitch;
    if (!this.Show)
    {
      if ((double) this.List.localPosition.x > -955.0)
      {
        this.List.localPosition = new Vector3(Mathf.Lerp(this.List.localPosition.x, -956f, t), this.List.localPosition.y, this.List.localPosition.z);
        this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 100f, t), this.TimeBar.localPosition.z);
      }
      else
      {
        this.TimeBar.gameObject.SetActive(false);
        this.List.gameObject.SetActive(false);
      }
    }
    else if (this.Listening)
    {
      this.List.localPosition = new Vector3(Mathf.Lerp(this.List.localPosition.x, -955f, t), this.List.localPosition.y, this.List.localPosition.z);
      this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 0.0f, t), this.TimeBar.localPosition.z);
      this.TapePlayerCamera.position = new Vector3(Mathf.Lerp(this.TapePlayerCamera.position.x, -26.15f, t), this.TapePlayerCamera.position.y, Mathf.Lerp(this.TapePlayerCamera.position.z, 5.35f, t));
      if (this.Phase == 1)
      {
        this.TapePlayerAnim["InsertTape"].time += Time.unscaledDeltaTime * 3.33333f;
        if ((double) this.TapePlayerAnim["InsertTape"].time >= (double) this.TapePlayerAnim["InsertTape"].length)
        {
          this.TapePlayerAnim.Play("PressPlay");
          this.MyAudio.pitch = 1f;
          this.MyAudio.Play();
          this.PromptBar.Label[0].text = "PAUSE";
          this.PromptBar.Label[1].text = "STOP";
          this.PromptBar.Label[5].text = "REWIND / FAST FORWARD";
          this.PromptBar.UpdateButtons();
          ++this.Phase;
        }
      }
      else if (this.Phase == 2)
      {
        this.Timer += Time.unscaledDeltaTime;
        this.ButtonPressed = false;
        if (this.MyAudio.isPlaying)
        {
          if ((double) this.Timer > 0.10000000149011612)
          {
            this.TapePlayerAnim["PressPlay"].time += Time.unscaledDeltaTime;
            if ((double) this.TapePlayerAnim["PressPlay"].time > (double) this.TapePlayerAnim["PressPlay"].length)
              this.TapePlayerAnim["PressPlay"].time = this.TapePlayerAnim["PressPlay"].length;
          }
        }
        else
        {
          this.TapePlayerAnim["PressPlay"].time -= Time.unscaledDeltaTime;
          if ((double) this.TapePlayerAnim["PressPlay"].time < 0.0)
            this.TapePlayerAnim["PressPlay"].time = 0.0f;
          if (Input.GetButtonDown("A"))
          {
            Debug.Log((object) "The player just pressed the ''A'' button to pause it.");
            this.PromptBar.Label[0].text = "PAUSE";
            this.TapePlayer.Spin = true;
            this.MyAudio.time = this.ResumeTime;
            this.MyAudio.Play();
            this.ButtonPressed = true;
          }
        }
        if ((double) this.TapePlayerAnim["PressPlay"].time >= (double) this.TapePlayerAnim["PressPlay"].length)
        {
          this.TapePlayer.Spin = true;
          if ((double) this.MyAudio.time >= (double) this.MyAudio.clip.length - 3.0)
          {
            this.MyAudio.pitch = 1f;
            Time.timeScale = 1f;
          }
          if ((double) this.MyAudio.time >= (double) this.MyAudio.clip.length - 1.0)
          {
            this.TapePlayerAnim.Play("PressEject");
            this.TapePlayer.Spin = false;
            if (!this.MyAudio.isPlaying)
            {
              this.MyAudio.clip = this.TapeStop;
              this.MyAudio.Play();
            }
            this.Subtitle.text = string.Empty;
            ++this.Phase;
          }
          if (!this.ButtonPressed && Input.GetButtonDown("A"))
          {
            Debug.Log((object) "The player just pressed the ''A'' button to unpause it.");
            if (this.MyAudio.isPlaying)
            {
              this.PromptBar.Label[0].text = "PLAY";
              this.TapePlayer.Spin = false;
              this.ResumeTime = this.MyAudio.time;
              this.MyAudio.Stop();
            }
          }
        }
        if (Input.GetButtonDown("B"))
        {
          this.TapePlayerAnim.Play("PressEject");
          this.TapePlayer.Spin = false;
          this.MyAudio.clip = this.TapeStop;
          this.MyAudio.time = 0.0f;
          this.MyAudio.Play();
          this.PromptBar.Label[0].text = string.Empty;
          this.PromptBar.Label[1].text = string.Empty;
          this.PromptBar.Label[5].text = string.Empty;
          this.PromptBar.UpdateButtons();
          this.Subtitle.text = string.Empty;
          ++this.Phase;
        }
      }
      else if (this.Phase == 3)
      {
        this.TapePlayerAnim["PressEject"].time += Time.unscaledDeltaTime;
        if ((double) this.TapePlayerAnim["PressEject"].time >= (double) this.TapePlayerAnim["PressEject"].length)
        {
          this.TapePlayerAnim.Play("InsertTape");
          this.TapePlayerAnim["InsertTape"].time = this.TapePlayerAnim["InsertTape"].length;
          this.TapePlayer.FastForward = false;
          ++this.Phase;
        }
      }
      else if (this.Phase == 4)
      {
        if ((double) this.TapePlayerAnim["InsertTape"].time > (double) this.TapePlayerAnim["InsertTape"].length)
          this.TapePlayerAnim["InsertTape"].time = this.TapePlayerAnim["InsertTape"].length;
        this.TapePlayerAnim["InsertTape"].time -= Time.unscaledDeltaTime * 3.33333f;
        if ((double) this.TapePlayerAnim["InsertTape"].time <= 0.0)
        {
          this.TapePlayer.Tape.SetActive(false);
          this.Jukebox.SetActive(true);
          this.Listening = false;
          this.Timer = 0.0f;
          this.PromptBar.Label[0].text = "PLAY";
          this.PromptBar.Label[1].text = "BACK";
          this.PromptBar.Label[4].text = "CHOOSE";
          this.PromptBar.Label[5].text = "CATEGORY";
          this.PromptBar.UpdateButtons();
          if (this.Category == 1)
            this.CheckJournalistCompletion();
          else if (this.Category == 2)
            this.CheckBasementCompletion();
          else if (this.Category == 3)
            this.CheckHeadmasterCompletion();
        }
      }
      if (this.Phase == 2)
      {
        if (this.InputManager.DPadRight || Input.GetKey(KeyCode.RightArrow))
        {
          this.ResumeTime += 1.66666663f;
          this.MyAudio.time += 1.66666663f;
          this.TapePlayer.FastForward = true;
        }
        else
          this.TapePlayer.FastForward = false;
        if (this.InputManager.DPadLeft || Input.GetKey(KeyCode.LeftArrow))
        {
          this.ResumeTime -= 1.66666663f;
          this.MyAudio.time -= 1.66666663f;
          this.TapePlayer.Rewind = true;
        }
        else
          this.TapePlayer.Rewind = false;
        int num1;
        int num2;
        if (this.MyAudio.isPlaying)
        {
          num1 = Mathf.FloorToInt(this.MyAudio.time / 60f);
          num2 = Mathf.FloorToInt(this.MyAudio.time - (float) num1 * 60f);
          this.Bar.fillAmount = this.MyAudio.time / this.MyAudio.clip.length;
        }
        else
        {
          num1 = Mathf.FloorToInt(this.ResumeTime / 60f);
          num2 = Mathf.FloorToInt(this.ResumeTime - (float) num1 * 60f);
          this.Bar.fillAmount = this.ResumeTime / this.MyAudio.clip.length;
        }
        this.CurrentTime = string.Format("{00:00}:{1:00}", (object) num1, (object) num2);
        this.Label.text = this.CurrentTime + " / " + this.ClipLength;
        if (this.Category == 1)
        {
          if (this.Selected == 1)
          {
            for (int index = 0; index < this.Cues1.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.Cues1[index])
                this.Subtitle.text = this.Subs1[index];
            }
          }
          else if (this.Selected == 2)
          {
            for (int index = 0; index < this.Cues2.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.Cues2[index])
                this.Subtitle.text = this.Subs2[index];
            }
          }
          else if (this.Selected == 3)
          {
            for (int index = 0; index < this.Cues3.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.Cues3[index])
                this.Subtitle.text = this.Subs3[index];
            }
          }
          else if (this.Selected == 4)
          {
            for (int index = 0; index < this.Cues4.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.Cues4[index])
                this.Subtitle.text = this.Subs4[index];
            }
          }
          else if (this.Selected == 5)
          {
            for (int index = 0; index < this.Cues5.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.Cues5[index])
                this.Subtitle.text = this.Subs5[index];
            }
          }
          else if (this.Selected == 6)
          {
            for (int index = 0; index < this.Cues6.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.Cues6[index])
                this.Subtitle.text = this.Subs6[index];
            }
          }
          else if (this.Selected == 7)
          {
            for (int index = 0; index < this.Cues7.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.Cues7[index])
                this.Subtitle.text = this.Subs7[index];
            }
          }
          else if (this.Selected == 8)
          {
            for (int index = 0; index < this.Cues8.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.Cues8[index])
                this.Subtitle.text = this.Subs8[index];
            }
          }
          else if (this.Selected == 9)
          {
            for (int index = 0; index < this.Cues9.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.Cues9[index])
                this.Subtitle.text = this.Subs9[index];
            }
          }
          else
          {
            if (this.Selected != 10)
              return;
            for (int index = 0; index < this.Cues10.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.Cues10[index])
                this.Subtitle.text = this.Subs10[index];
            }
          }
        }
        else if (this.Category == 2)
        {
          if (this.Selected == 1)
          {
            for (int index = 0; index < this.BasementCues1.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.BasementCues1[index])
                this.Subtitle.text = this.BasementSubs1[index];
            }
          }
          if (this.Selected != 10)
            return;
          for (int index = 0; index < this.BasementCues10.Length; ++index)
          {
            if ((double) this.MyAudio.time > (double) this.BasementCues10[index])
              this.Subtitle.text = this.BasementSubs10[index];
          }
        }
        else
        {
          if (this.Category != 3)
            return;
          if (this.Selected == 1)
          {
            for (int index = 0; index < this.HeadmasterCues1.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.HeadmasterCues1[index])
                this.Subtitle.text = this.HeadmasterSubs1[index];
            }
          }
          else if (this.Selected == 2)
          {
            for (int index = 0; index < this.HeadmasterCues2.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.HeadmasterCues2[index])
                this.Subtitle.text = this.HeadmasterSubs2[index];
            }
          }
          else if (this.Selected == 3)
          {
            for (int index = 0; index < this.HeadmasterCues3.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.HeadmasterCues3[index])
                this.Subtitle.text = this.HeadmasterSubs3[index];
            }
          }
          else if (this.Selected == 4)
          {
            for (int index = 0; index < this.HeadmasterCues4.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.HeadmasterCues4[index])
                this.Subtitle.text = this.HeadmasterSubs4[index];
            }
          }
          else if (this.Selected == 5)
          {
            for (int index = 0; index < this.HeadmasterCues5.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.HeadmasterCues5[index])
                this.Subtitle.text = this.HeadmasterSubs5[index];
            }
          }
          else if (this.Selected == 6)
          {
            for (int index = 0; index < this.HeadmasterCues6.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.HeadmasterCues6[index])
                this.Subtitle.text = this.HeadmasterSubs6[index];
            }
          }
          else if (this.Selected == 7)
          {
            for (int index = 0; index < this.HeadmasterCues7.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.HeadmasterCues7[index])
                this.Subtitle.text = this.HeadmasterSubs7[index];
            }
          }
          else if (this.Selected == 8)
          {
            for (int index = 0; index < this.HeadmasterCues8.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.HeadmasterCues8[index])
                this.Subtitle.text = this.HeadmasterSubs8[index];
            }
          }
          else if (this.Selected == 9)
          {
            for (int index = 0; index < this.HeadmasterCues9.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.HeadmasterCues9[index])
                this.Subtitle.text = this.HeadmasterSubs9[index];
            }
          }
          else
          {
            if (this.Selected != 10)
              return;
            for (int index = 0; index < this.HeadmasterCues10.Length; ++index)
            {
              if ((double) this.MyAudio.time > (double) this.HeadmasterCues10[index])
                this.Subtitle.text = this.HeadmasterSubs10[index];
            }
          }
        }
      }
      else
      {
        this.Label.text = "00:00 / 00:00";
        this.Bar.fillAmount = 0.0f;
      }
    }
    else
    {
      this.TapePlayerAnim.Stop();
      this.TapePlayerCamera.position = new Vector3(Mathf.Lerp(this.TapePlayerCamera.position.x, -26.2125f, t), this.TapePlayerCamera.position.y, Mathf.Lerp(this.TapePlayerCamera.position.z, 5.4125f, t));
      this.List.transform.localPosition = new Vector3(Mathf.Lerp(this.List.transform.localPosition.x, 0.0f, t), this.List.transform.localPosition.y, this.List.transform.localPosition.z);
      this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 100f, t), this.TimeBar.localPosition.z);
      if (this.InputManager.TappedRight)
      {
        ++this.Category;
        if (this.Category > 3)
          this.Category = 1;
        this.UpdateLabels();
      }
      else if (this.InputManager.TappedLeft)
      {
        --this.Category;
        if (this.Category < 1)
          this.Category = 3;
        this.UpdateLabels();
      }
      if (this.InputManager.TappedUp)
      {
        --this.Selected;
        if (this.Selected < 1)
          this.Selected = 10;
        this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (440.0 - 80.0 * (double) this.Selected), this.Highlight.localPosition.z);
        this.CheckSelection();
      }
      else if (this.InputManager.TappedDown)
      {
        ++this.Selected;
        if (this.Selected > 10)
          this.Selected = 1;
        this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (440.0 - 80.0 * (double) this.Selected), this.Highlight.localPosition.z);
        this.CheckSelection();
      }
      else if (Input.GetButtonDown("A"))
      {
        bool flag = false;
        if (this.Category == 1)
        {
          if (this.StudentManager.TapesCollected[this.Selected])
          {
            CollectibleGlobals.SetTapeListened(this.Selected, true);
            flag = true;
          }
        }
        else if (this.Category == 2)
        {
          if (CollectibleGlobals.GetBasementTapeCollected(this.Selected))
          {
            CollectibleGlobals.SetBasementTapeListened(this.Selected, true);
            flag = true;
          }
        }
        else if (this.Category == 3 && this.StudentManager.HeadmasterTapesCollected[this.Selected])
        {
          CollectibleGlobals.SetHeadmasterTapeListened(this.Selected, true);
          flag = true;
        }
        if (!flag)
          return;
        this.NewIcons[this.Selected].SetActive(false);
        this.Jukebox.SetActive(false);
        this.Listening = true;
        this.Phase = 1;
        this.PromptBar.Label[0].text = string.Empty;
        this.PromptBar.Label[1].text = string.Empty;
        this.PromptBar.Label[4].text = string.Empty;
        this.PromptBar.UpdateButtons();
        this.TapePlayerAnim["InsertTape"].time = 0.0f;
        this.TapePlayerAnim.Play("InsertTape");
        this.TapePlayer.Tape.SetActive(true);
        this.MyAudio.clip = this.Category != 1 ? (this.Category != 2 ? this.HeadmasterRecordings[this.Selected] : this.BasementRecordings[this.Selected]) : this.Recordings[this.Selected];
        this.MyAudio.time = 0.0f;
        this.RoundedTime = (float) Mathf.CeilToInt(this.MyAudio.clip.length);
        this.ClipLength = string.Format("{0:00}:{1:00}", (object) (int) ((double) this.RoundedTime / 60.0), (object) (int) ((double) this.RoundedTime % 60.0));
      }
      else
      {
        if (!Input.GetButtonDown("B"))
          return;
        this.TapePlayer.Yandere.HeartCamera.enabled = true;
        this.TapePlayer.Yandere.RPGCamera.enabled = true;
        this.TapePlayer.TapePlayerCamera.enabled = false;
        this.TapePlayer.NoteWindow.SetActive(true);
        this.TapePlayer.PromptBar.ClearButtons();
        this.TapePlayer.Yandere.CanMove = true;
        this.TapePlayer.PromptBar.Show = false;
        this.TapePlayer.Prompt.enabled = true;
        this.TapePlayer.Yandere.HUD.alpha = 1f;
        Time.timeScale = 1f;
        this.Show = false;
      }
    }
  }

  public void UpdateLabels()
  {
    int tapeID = 0;
    while (tapeID < this.TotalTapes)
    {
      ++tapeID;
      if (this.Category == 1)
      {
        this.HeaderLabel.text = "Mysterious Tapes";
        if (this.StudentManager.TapesCollected[tapeID])
        {
          this.TapeLabels[tapeID].text = "Mysterious Tape " + tapeID.ToString();
          this.NewIcons[tapeID].SetActive(!CollectibleGlobals.GetTapeListened(tapeID));
        }
        else
        {
          this.TapeLabels[tapeID].text = "?????";
          this.NewIcons[tapeID].SetActive(false);
        }
      }
      else if (this.Category == 2)
      {
        this.HeaderLabel.text = "Basement Tapes";
        if (CollectibleGlobals.GetBasementTapeCollected(tapeID))
        {
          this.TapeLabels[tapeID].text = "Basement Tape " + tapeID.ToString();
          this.NewIcons[tapeID].SetActive(!CollectibleGlobals.GetBasementTapeListened(tapeID));
        }
        else
        {
          this.TapeLabels[tapeID].text = "?????";
          this.NewIcons[tapeID].SetActive(false);
        }
      }
      else
      {
        this.HeaderLabel.text = "Headmaster Tapes";
        if (this.StudentManager.HeadmasterTapesCollected[tapeID])
        {
          this.TapeLabels[tapeID].text = "Headmaster Tape " + tapeID.ToString();
          this.NewIcons[tapeID].SetActive(!CollectibleGlobals.GetHeadmasterTapeListened(tapeID));
        }
        else
        {
          this.TapeLabels[tapeID].text = "?????";
          this.NewIcons[tapeID].SetActive(false);
        }
      }
    }
  }

  public void CheckSelection()
  {
    if (this.Category == 1)
    {
      this.TapePlayer.PromptBar.Label[0].text = this.StudentManager.TapesCollected[this.Selected] ? "PLAY" : string.Empty;
      this.TapePlayer.PromptBar.UpdateButtons();
    }
    else if (this.Category == 2)
    {
      this.TapePlayer.PromptBar.Label[0].text = CollectibleGlobals.GetBasementTapeCollected(this.Selected) ? "PLAY" : string.Empty;
      this.TapePlayer.PromptBar.UpdateButtons();
    }
    else
    {
      this.TapePlayer.PromptBar.Label[0].text = this.StudentManager.HeadmasterTapesCollected[this.Selected] ? "PLAY" : string.Empty;
      this.TapePlayer.PromptBar.UpdateButtons();
    }
  }

  public void CheckBasementCompletion()
  {
    Debug.Log((object) "Checking to see if the player has collected *and* listened to all of the basement tapes.");
    int num = 0;
    for (int tapeID = 1; tapeID < 11; ++tapeID)
    {
      if (CollectibleGlobals.GetBasementTapeCollected(tapeID) && CollectibleGlobals.GetBasementTapeListened(tapeID))
      {
        ++num;
        if (num == 2 && !GameGlobals.Debug)
        {
          PlayerPrefs.SetInt("Basement", 1);
          PlayerPrefs.SetInt("a", 1);
        }
      }
    }
  }

  public void CheckHeadmasterCompletion()
  {
    Debug.Log((object) "Checking to see if the player has collected *and* listened to all of the headmaster tapes.");
    int num = 0;
    for (int tapeID = 1; tapeID < 11; ++tapeID)
    {
      if (CollectibleGlobals.GetHeadmasterTapeCollected(tapeID) && CollectibleGlobals.GetHeadmasterTapeListened(tapeID))
      {
        ++num;
        if (num == 10 && !GameGlobals.Debug)
        {
          PlayerPrefs.SetInt("Headmaster", 1);
          PlayerPrefs.SetInt("a", 1);
        }
      }
    }
  }

  public void CheckJournalistCompletion()
  {
    Debug.Log((object) "Checking to see if the player has collected *and* listened to all of the journalist tapes.");
    int num = 0;
    for (int tapeID = 1; tapeID < 11; ++tapeID)
    {
      if (CollectibleGlobals.GetTapeCollected(tapeID) && CollectibleGlobals.GetTapeListened(tapeID))
      {
        ++num;
        if (num == 10 && !GameGlobals.Debug)
        {
          PlayerPrefs.SetInt("Journalist", 1);
          PlayerPrefs.SetInt("a", 1);
        }
      }
    }
  }
}
