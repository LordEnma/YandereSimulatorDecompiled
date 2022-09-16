// Decompiled with JetBrains decompiler
// Type: YanvaniaTextBoxScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaTextBoxScript : MonoBehaviour
{
  private TypewriterEffect NewTypewriter;
  private UILabel NewLabelScript;
  private GameObject NewLabel;
  public YanvaniaJukeboxScript Jukebox;
  public YanvaniaDraculaScript Dracula;
  public YanvaniaYanmontScript Yanmont;
  public Transform NewLabelSpawnPoint;
  public GameObject Glass;
  public GameObject Label;
  public UILabel SpeakerLabel;
  public UITexture BloodWipe;
  public UITexture Portrait;
  public UITexture Border;
  public UITexture BG;
  public bool UpdatePortrait;
  public bool Display;
  public bool Leave;
  public bool Grow;
  public string[] SpeakerNames;
  public Texture[] Portraits;
  public AudioClip[] Voices;
  public string[] Lines;
  public int PortraitID = 1;
  public int LineID;
  public float NewLineTimer;
  public float AnimTimer;
  public float Timer;

  private void Start()
  {
    this.Portrait.transform.localScale = Vector3.zero;
    this.BloodWipe.transform.localScale = new Vector3(0.0f, this.BloodWipe.transform.localScale.y, this.BloodWipe.transform.localScale.z);
    this.SpeakerLabel.text = string.Empty;
    this.Border.color = new Color(this.Border.color.r, this.Border.color.g, this.Border.color.b, 0.0f);
    this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0.0f);
    this.gameObject.SetActive(false);
  }

  private void Update()
  {
    if (!this.Leave)
    {
      if ((double) this.BloodWipe.transform.localScale.x == 0.0)
        this.BloodWipe.transform.localScale = new Vector3(this.BloodWipe.transform.localScale.x + Time.deltaTime, this.BloodWipe.transform.localScale.y, this.BloodWipe.transform.localScale.z);
      if ((double) this.BloodWipe.transform.localScale.x > 50.0)
      {
        this.BloodWipe.color = new Color(this.BloodWipe.color.r, this.BloodWipe.color.g, this.BloodWipe.color.b, this.BloodWipe.color.a - Time.deltaTime);
        this.Border.color = new Color(this.Border.color.r, this.Border.color.g, this.Border.color.b, this.Border.color.a + Time.deltaTime);
        this.BG.color = new Color(this.BG.color.r, this.BG.color.g, this.BG.color.b, 0.5f);
      }
      else
        this.BloodWipe.transform.localScale = new Vector3(this.BloodWipe.transform.localScale.x + this.BloodWipe.transform.localScale.x * 0.1f, this.BloodWipe.transform.localScale.y, this.BloodWipe.transform.localScale.z);
      if ((double) this.BloodWipe.color.a <= 0.0)
      {
        if (!this.Display)
        {
          if (this.LineID < this.Lines.Length - 1)
          {
            if ((Object) this.NewLabel != (Object) null)
              Object.Destroy((Object) this.NewLabel);
            this.UpdatePortrait = true;
            this.Display = true;
            this.PortraitID = this.PortraitID == 1 ? 2 : 1;
            this.SpeakerLabel.text = string.Empty;
          }
        }
        else if ((Object) this.NewLabelScript != (Object) null)
        {
          AudioSource component = this.GetComponent<AudioSource>();
          if (!this.NewLabelScript.enabled)
          {
            this.NewLabelScript.enabled = true;
            component.clip = this.Voices[this.LineID];
            this.NewLineTimer = 0.0f;
            component.Play();
          }
          else
          {
            this.NewLineTimer += Time.deltaTime;
            if ((double) this.NewLineTimer > (double) component.clip.length + 0.5 || Input.GetButtonDown("A") || Input.GetKeyDown("z") || Input.GetKeyDown("x"))
              this.Display = false;
          }
        }
      }
      if (this.UpdatePortrait)
      {
        if (!this.Grow)
        {
          this.Portrait.transform.localScale = Vector3.MoveTowards(this.Portrait.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
          if ((double) this.Portrait.transform.localScale.x == 0.0)
          {
            this.Portrait.mainTexture = this.Portraits[this.PortraitID];
            this.Grow = true;
          }
        }
        else
        {
          this.Portrait.transform.localScale = Vector3.MoveTowards(this.Portrait.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
          if ((double) this.Portrait.transform.localScale.x == 1.0)
          {
            this.SpeakerLabel.text = this.SpeakerNames[this.PortraitID];
            this.UpdatePortrait = false;
            this.AnimTimer = 0.0f;
            this.Grow = false;
            ++this.LineID;
            this.SpawnLabel();
          }
        }
      }
      this.AnimTimer += Time.deltaTime;
      if (this.LineID == 2)
      {
        this.NewTypewriter.charsPerSecond = 15;
        this.NewTypewriter.delayOnPeriod = 1.5f;
        if ((double) this.AnimTimer < 0.5)
          this.NewTypewriter.delayOnComma = true;
      }
      Animation component1 = this.Yanmont.Character.GetComponent<Animation>();
      if (this.LineID == 3)
      {
        this.NewTypewriter.delayOnComma = true;
        this.NewTypewriter.delayOnPeriod = 0.75f;
        if ((double) this.AnimTimer < 1.0)
          component1.CrossFade("f02_yanvaniaCutsceneAction1_00");
        if ((double) component1["f02_yanvaniaCutsceneAction1_00"].time >= (double) component1["f02_yanvaniaCutsceneAction1_00"].length)
          component1.CrossFade("f02_yanvaniaDramaticIdle_00");
      }
      Animation component2 = this.Dracula.Character.GetComponent<Animation>();
      if (this.LineID == 5)
      {
        this.NewTypewriter.charsPerSecond = 15;
        component1.CrossFade("f02_yanvaniaCutsceneAction2_00");
        if ((double) component1["f02_yanvaniaCutsceneAction2_00"].time >= (double) component1["f02_yanvaniaCutsceneAction2_00"].length)
          component1.CrossFade("f02_yanvaniaDramaticIdle_00");
        if ((double) this.AnimTimer > 4.0)
          component2.CrossFade("DraculaDrink");
        if ((double) this.AnimTimer > 4.5)
          this.Glass.GetComponent<Renderer>().materials[0].color = new Color(1f, 1f, 1f, 0.5f);
        if ((double) this.AnimTimer > 5.0 && (double) component2["DraculaDrink"].time >= (double) component2["DraculaDrink"].length)
          component2.CrossFade("DraculaIdle");
      }
      if (this.LineID == 6)
      {
        component1.CrossFade("f02_yanvaniaDramaticIdle_00");
        if ((double) this.AnimTimer < 1.0)
          this.NewTypewriter.delayOnPeriod = 2.25f;
        if ((double) this.AnimTimer > 1.0 && (double) this.AnimTimer < 2.0)
          component2.CrossFade("DraculaToss");
        if ((Object) this.Glass != (Object) null)
        {
          Rigidbody component3 = this.Glass.GetComponent<Rigidbody>();
          if ((double) this.AnimTimer > 1.3999999761581421 && !component3.useGravity)
          {
            component3.useGravity = true;
            this.Glass.transform.parent = (Transform) null;
            component3.AddForce(-100f, 100f, -100f);
          }
        }
        if ((double) this.AnimTimer > 2.0 + (double) component2["DraculaToss"].length && (double) this.AnimTimer < 6.0)
          component2.CrossFade("DraculaIdle");
        if ((double) this.AnimTimer > 4.0)
        {
          this.NewTypewriter.delayOnPeriod = 1f;
          this.NewTypewriter.charsPerSecond = 15;
        }
        if ((double) this.AnimTimer > 6.0 && (double) this.AnimTimer < 9.5)
        {
          this.Dracula.transform.position = Vector3.Lerp(this.Dracula.transform.position, new Vector3(-34.675f, 7.5f, 2.8f), Time.deltaTime * 10f);
          component2.CrossFade("succubus_a_idle_01");
        }
        if ((double) this.AnimTimer > 9.5)
        {
          this.NewLabelScript.text = string.Empty;
          this.SpeakerLabel.text = string.Empty;
          this.Dracula.SpawnTeleportEffect();
          this.Dracula.enabled = true;
          this.Jukebox.BossBattle();
          this.Leave = true;
        }
      }
      if (!Input.GetKeyDown(KeyCode.Alpha3))
        return;
      if ((Object) this.NewLabel != (Object) null)
        Object.Destroy((Object) this.NewLabel);
      if ((Object) this.NewLabelScript != (Object) null)
        this.NewLabelScript.text = string.Empty;
      this.SpeakerLabel.text = string.Empty;
      this.Dracula.SpawnTeleportEffect();
      this.Dracula.enabled = true;
      this.Jukebox.BossBattle();
      Object.Destroy((Object) this.BloodWipe);
      Object.Destroy((Object) this.Glass);
      this.Leave = true;
    }
    else
    {
      this.Portrait.transform.localScale = Vector3.MoveTowards(this.Portrait.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
      if ((double) this.Portrait.transform.localScale.x != 0.0)
        return;
      this.Border.transform.position = new Vector3(this.Border.transform.position.x, this.Border.transform.position.y + Time.deltaTime, this.Border.transform.position.z);
      this.BG.transform.position = new Vector3(this.BG.transform.position.x, this.BG.transform.position.y + Time.deltaTime, this.BG.transform.position.z);
      if (this.Yanmont.enabled)
        return;
      this.Yanmont.YanvaniaCamera.TargetZoom = 0.0f;
      this.Yanmont.Character.transform.localScale = new Vector3(-1f, 1f, 1f);
      this.Yanmont.EnterCutscene = false;
      this.Yanmont.Cutscene = false;
      this.Yanmont.enabled = true;
    }
  }

  private void SpawnLabel()
  {
    this.NewLabel = Object.Instantiate<GameObject>(this.Label, this.transform.position, Quaternion.identity);
    this.NewLabel.transform.parent = this.NewLabelSpawnPoint;
    this.NewLabel.transform.localEulerAngles = Vector3.zero;
    this.NewLabel.transform.localPosition = Vector3.zero;
    this.NewLabel.transform.localScale = new Vector3(1f, 1f, 1f);
    this.NewTypewriter = this.NewLabel.GetComponent<TypewriterEffect>();
    this.NewLabelScript = this.NewLabel.GetComponent<UILabel>();
    this.NewLabelScript.text = this.Lines[this.LineID];
    this.NewLabelScript.enabled = false;
  }
}
