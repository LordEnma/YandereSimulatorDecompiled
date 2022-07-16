// Decompiled with JetBrains decompiler
// Type: RadioScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RadioScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public JukeboxScript Jukebox;
  public GameObject RadioNotes;
  public GameObject AlarmDisc;
  public AudioSource MyAudio;
  public Renderer MyRenderer;
  public Texture OffTexture;
  public Texture OnTexture;
  public StudentScript Victim;
  public PromptScript Prompt;
  public float CooldownTimer;
  public bool Delinquent;
  public bool On;
  public int Proximity;
  public int ID;
  public AudioClip EightiesMusic;

  private void Start()
  {
    if (this.Delinquent && StudentGlobals.GetStudentExpelled(76))
      Object.Destroy((Object) this.gameObject);
    if (!GameGlobals.Eighties)
      return;
    this.MyAudio.clip = this.EightiesMusic;
  }

  private void Update()
  {
    if ((Object) this.transform.parent == (Object) null)
    {
      if ((double) this.CooldownTimer > 0.0)
      {
        this.CooldownTimer = Mathf.MoveTowards(this.CooldownTimer, 0.0f, Time.deltaTime);
        if ((double) this.CooldownTimer == 0.0)
          this.Prompt.enabled = true;
      }
      else
      {
        UISprite uiSprite = this.Prompt.Circle[0];
        if ((double) uiSprite.fillAmount == 0.0)
        {
          uiSprite.fillAmount = 1f;
          if (!this.On)
          {
            this.TurnOn();
          }
          else
          {
            this.CooldownTimer = 1f;
            this.TurnOff();
          }
        }
      }
      if (this.On && (Object) this.Victim == (Object) null && (Object) this.AlarmDisc != (Object) null)
      {
        AlarmDiscScript component = Object.Instantiate<GameObject>(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>();
        component.SourceRadio = this;
        component.NoScream = true;
        component.Radio = true;
      }
    }
    else if (this.Prompt.enabled)
    {
      this.Prompt.enabled = false;
      this.Prompt.Hide();
    }
    if (!this.Delinquent)
      return;
    this.Proximity = 0;
    for (this.ID = 1; this.ID < 6; ++this.ID)
    {
      if ((Object) this.StudentManager.Students[75 + this.ID] != (Object) null && (double) Vector3.Distance(this.transform.position, this.StudentManager.Students[75 + this.ID].transform.position) < 1.10000002384186)
      {
        if (!this.StudentManager.Students[75 + this.ID].Alarmed && !this.StudentManager.Students[75 + this.ID].Threatened && this.StudentManager.Students[75 + this.ID].Alive)
        {
          ++this.Proximity;
        }
        else
        {
          this.Proximity = -100;
          this.ID = 5;
          this.MyAudio.Stop();
          this.Jukebox.ClubDip = 0.0f;
        }
      }
    }
    this.MyAudio.volume = !this.Prompt.Yandere.Talking || !this.Prompt.Yandere.StudentManager.DialogueWheel.ClubLeader ? 0.1f : 0.0f;
    if (this.Proximity > 0)
    {
      if (!this.MyAudio.isPlaying)
        this.MyAudio.Play();
      float num = Vector3.Distance(this.Prompt.Yandere.transform.position, this.transform.position);
      if ((double) num >= 11.0)
        return;
      this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, (float) ((10.0 - (double) num) * 0.200000002980232) * this.Jukebox.Volume, Time.deltaTime);
      if ((double) this.Jukebox.ClubDip < 0.0)
        this.Jukebox.ClubDip = 0.0f;
      if ((double) this.Jukebox.ClubDip <= (double) this.Jukebox.Volume)
        return;
      this.Jukebox.ClubDip = this.Jukebox.Volume;
    }
    else
    {
      if (!this.MyAudio.isPlaying)
        return;
      this.MyAudio.Stop();
      this.Jukebox.ClubDip = 0.0f;
    }
  }

  public void TurnOn()
  {
    this.Prompt.Label[0].text = "     Turn Off";
    this.MyRenderer.material.mainTexture = this.OnTexture;
    this.RadioNotes.SetActive(true);
    this.MyAudio.Play();
    this.On = true;
  }

  public void TurnOff()
  {
    this.Prompt.Label[0].text = "     Turn On";
    this.Prompt.enabled = false;
    this.Prompt.Hide();
    this.MyRenderer.material.mainTexture = this.OffTexture;
    this.RadioNotes.SetActive(false);
    this.CooldownTimer = 1f;
    this.MyAudio.Stop();
    this.Victim = (StudentScript) null;
    this.On = false;
  }
}
