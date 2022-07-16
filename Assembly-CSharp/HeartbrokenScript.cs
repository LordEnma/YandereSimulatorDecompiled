// Decompiled with JetBrains decompiler
// Type: HeartbrokenScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using XInputDotNetPure;

public class HeartbrokenScript : MonoBehaviour
{
  public ShoulderCameraScript ShoulderCamera;
  public HeartbrokenCursorScript Cursor;
  public CounselorScript Counselor;
  public YandereScript Yandere;
  public ClockScript Clock;
  public AudioListener Listener;
  public AudioClip[] NoticedClips;
  public string[] NoticedLines;
  public UILabel[] Letters;
  public UILabel[] Options;
  public Vector3[] Origins;
  public UISprite Background;
  public UISprite Ground;
  public Camera ConfessionUICamera;
  public Camera MainCamera;
  public UILabel Subtitle;
  public GameObject SNAP;
  public AudioClip EightiesGameOver;
  public AudioClip Slam;
  public bool Headmaster;
  public bool Confessed;
  public bool Arrested;
  public bool Exposed;
  public bool Noticed = true;
  public bool Freeze;
  public bool NoSnap;
  public bool Caught;
  public float VibrationTimer;
  public float AudioTimer;
  public float Timer;
  public int Phase = 1;
  public int Week;
  public int LetterID;
  public int ShakeID;
  public int GrowID;
  public int StopID;
  public int ID;
  public float[] TargetAlpha;
  public Font Arial;

  private void Start()
  {
    this.Week = DateGlobals.Week;
    if (GameGlobals.MostRecentSlot == 0)
      this.TargetAlpha[2] = 0.5f;
    if (!this.Caught && !this.Noticed && (double) this.Yandere.Bloodiness > 0.0 && !this.Yandere.RedPaint && !this.Yandere.Unmasked)
      this.Arrested = true;
    if (this.Caught)
    {
      this.Letters[0].text = "";
      this.Letters[1].text = "";
      this.Letters[2].text = "C";
      this.Letters[3].text = "A";
      this.Letters[4].text = "U";
      this.Letters[5].text = "G";
      this.Letters[6].text = "H";
      this.Letters[7].text = "T";
      this.Letters[8].text = "";
      this.Letters[9].text = "";
      this.Letters[10].text = "";
      foreach (UILabel letter in this.Letters)
        letter.transform.localPosition = new Vector3(letter.transform.localPosition.x + 125f, letter.transform.localPosition.y, letter.transform.localPosition.z);
      this.LetterID = 1;
      this.StopID = 8;
      this.NoSnap = true;
      this.SNAP.SetActive(false);
      this.Cursor.Options = 3;
    }
    else if (this.Confessed)
    {
      this.Letters[0].text = "S";
      this.Letters[1].text = "E";
      this.Letters[2].text = "N";
      this.Letters[3].text = "P";
      this.Letters[4].text = "A";
      this.Letters[5].text = "I";
      this.Letters[6].text = string.Empty;
      this.Letters[7].text = "L";
      this.Letters[8].text = "O";
      this.Letters[9].text = "S";
      this.Letters[10].text = "T";
      this.LetterID = 0;
      this.StopID = 11;
      this.NoSnap = true;
    }
    else if (this.Yandere.Attacked)
    {
      if (!this.Headmaster)
      {
        this.Letters[0].text = string.Empty;
        this.Letters[1].text = "C";
        this.Letters[2].text = "O";
        this.Letters[3].text = "M";
        this.Letters[4].text = "A";
        this.Letters[5].text = "T";
        this.Letters[6].text = "O";
        this.Letters[7].text = "S";
        this.Letters[8].text = "E";
        this.Letters[9].text = string.Empty;
        this.Letters[10].text = string.Empty;
        this.Letters[3].fontSize = 250;
        this.LetterID = 1;
        this.StopID = 9;
      }
      else
      {
        this.Letters[0].text = "?";
        this.Letters[1].text = "?";
        this.Letters[2].text = "?";
        this.Letters[3].text = "?";
        this.Letters[4].text = "?";
        this.Letters[5].text = "?";
        this.Letters[6].text = "?";
        this.Letters[7].text = "?";
        this.Letters[8].text = "?";
        this.Letters[9].text = "?";
        this.Letters[10].text = string.Empty;
        this.LetterID = 0;
        this.StopID = 10;
      }
      foreach (UILabel letter in this.Letters)
        letter.transform.localPosition = new Vector3(letter.transform.localPosition.x + 100f, letter.transform.localPosition.y, letter.transform.localPosition.z);
      this.SNAP.SetActive(false);
      this.Cursor.Options = 4;
      this.NoSnap = true;
    }
    else if (this.Yandere.Lost || this.ShoulderCamera.LookDown || this.ShoulderCamera.Counter || this.ShoulderCamera.ObstacleCounter)
    {
      this.Letters[0].text = "A";
      this.Letters[1].text = "P";
      this.Letters[2].text = "P";
      this.Letters[3].text = "R";
      this.Letters[4].text = "E";
      this.Letters[5].text = "H";
      this.Letters[6].text = "E";
      this.Letters[7].text = "N";
      this.Letters[8].text = "D";
      this.Letters[9].text = "E";
      this.Letters[10].text = "D";
      this.LetterID = 0;
      this.StopID = 11;
      this.NoSnap = true;
    }
    else if (this.Exposed)
    {
      this.Letters[0].text = string.Empty;
      this.Letters[1].text = string.Empty;
      this.Letters[2].text = "E";
      this.Letters[3].text = "X";
      this.Letters[4].text = "P";
      this.Letters[5].text = "O";
      this.Letters[6].text = "S";
      this.Letters[7].text = "E";
      this.Letters[8].text = "D";
      this.Letters[9].text = string.Empty;
      this.Letters[10].text = string.Empty;
      foreach (UILabel letter in this.Letters)
        letter.transform.localPosition = new Vector3(letter.transform.localPosition.x + 100f, letter.transform.localPosition.y, letter.transform.localPosition.z);
      this.LetterID = 1;
      this.StopID = 9;
      this.NoSnap = true;
    }
    else if (this.Arrested || this.Yandere.Sprayed && (double) this.Yandere.Bloodiness > 0.0 && !this.Yandere.RedPaint || this.Yandere.SprayedByJournalist)
    {
      this.Letters[0].text = string.Empty;
      this.Letters[1].text = "A";
      this.Letters[2].text = "R";
      this.Letters[3].text = "R";
      this.Letters[4].text = "E";
      this.Letters[5].text = "S";
      this.Letters[6].text = "T";
      this.Letters[7].text = "E";
      this.Letters[8].text = "D";
      this.Letters[9].text = string.Empty;
      this.Letters[10].text = string.Empty;
      foreach (UILabel letter in this.Letters)
        letter.transform.localPosition = new Vector3(letter.transform.localPosition.x + 100f, letter.transform.localPosition.y, letter.transform.localPosition.z);
      this.LetterID = 1;
      this.StopID = 9;
      this.NoSnap = true;
    }
    else if (this.Counselor.Expelled || this.Yandere.Sprayed)
    {
      this.Letters[0].text = string.Empty;
      this.Letters[1].text = "E";
      this.Letters[2].text = "X";
      this.Letters[3].text = "P";
      this.Letters[4].text = "E";
      this.Letters[5].text = "L";
      this.Letters[6].text = "L";
      this.Letters[7].text = "E";
      this.Letters[8].text = "D";
      this.Letters[9].text = string.Empty;
      this.Letters[10].text = string.Empty;
      foreach (UILabel letter in this.Letters)
        letter.transform.localPosition = new Vector3(letter.transform.localPosition.x + 100f, letter.transform.localPosition.y, letter.transform.localPosition.z);
      this.LetterID = 1;
      this.StopID = 9;
      this.NoSnap = true;
    }
    else
    {
      this.LetterID = 0;
      this.StopID = 11;
    }
    if ((Object) this.Yandere != (Object) null && this.Yandere.Egg)
      this.NoSnap = true;
    for (this.ID = 0; this.ID < this.Letters.Length; ++this.ID)
    {
      UILabel letter = this.Letters[this.ID];
      letter.transform.localScale = new Vector3(10f, 10f, 1f);
      letter.color = new Color(letter.color.r, letter.color.g, letter.color.b, 0.0f);
      this.Origins[this.ID] = letter.transform.localPosition;
    }
    for (this.ID = 0; this.ID < this.Options.Length; ++this.ID)
    {
      UILabel option = this.Options[this.ID];
      option.color = new Color(option.color.r, option.color.g, option.color.b, 0.0f);
    }
    this.ID = 0;
    this.Subtitle.color = new Color(this.Subtitle.color.r, this.Subtitle.color.g, this.Subtitle.color.b, 0.0f);
    if (this.Noticed)
    {
      this.Background.color = new Color(this.Background.color.r, this.Background.color.g, this.Background.color.b, 0.0f);
      this.Ground.color = new Color(this.Ground.color.r, this.Ground.color.g, this.Ground.color.b, 0.0f);
    }
    else
      this.transform.parent.transform.position = new Vector3(this.transform.parent.transform.position.x, 100f, this.transform.parent.transform.position.z);
    if ((Object) this.Cursor.SnappedYandere != (Object) null)
    {
      int num = 0;
      foreach (Object weapon in this.Cursor.SnappedYandere.Weapons)
      {
        if (weapon != (Object) null)
          ++num;
      }
      if (num == 0 || this.NoSnap || this.Yandere.Police.GameOver || (double) this.Yandere.StudentManager.Clock.HourTime >= 18.0 || (double) this.Yandere.transform.position.y < -1.0)
      {
        this.SNAP.SetActive(false);
        this.Cursor.Options = 4;
      }
      this.Clock.StopTime = true;
    }
    if (!GameGlobals.Eighties)
      return;
    this.gameObject.GetComponent<AudioSource>().clip = this.EightiesGameOver;
    if (!((Object) this.Arial != (Object) null))
      return;
    this.Subtitle.trueTypeFont = this.Arial;
    this.Subtitle.applyGradient = false;
    this.Subtitle.color = new Color(1f, 1f, 0.0f, 1f);
    this.Subtitle.fontStyle = FontStyle.Bold;
  }

  private void Update()
  {
    if (Input.GetKeyDown("m"))
      this.gameObject.GetComponent<AudioSource>().Stop();
    this.VibrationTimer = Mathf.MoveTowards(this.VibrationTimer, 0.0f, Time.deltaTime);
    if ((double) this.VibrationTimer == 0.0)
      GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
    if (this.Noticed)
    {
      this.Ground.transform.eulerAngles = new Vector3(90f, 0.0f, 0.0f);
      this.Ground.transform.position = new Vector3(this.Ground.transform.position.x, this.Yandere.transform.position.y, this.Ground.transform.position.z);
    }
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > 3.0)
    {
      if (this.Phase == 1)
      {
        if (this.Noticed)
          this.UpdateSubtitle();
        this.Phase += (double) this.Subtitle.color.a > 0.0 ? 1 : 2;
      }
      else if (this.Phase == 2)
      {
        if (Input.GetButtonDown("A"))
          this.AudioTimer = 100f;
        this.AudioTimer += Time.deltaTime;
        if ((double) this.AudioTimer > (double) this.Subtitle.GetComponent<AudioSource>().clip.length)
          ++this.Phase;
      }
    }
    else if ((Object) this.Yandere != (Object) null && this.Yandere.Unmasked)
    {
      this.Yandere.ShoulderCamera.transform.position = Vector3.Lerp(this.Yandere.ShoulderCamera.transform.position, this.Yandere.ShoulderCamera.NoticedPOV.position, Time.deltaTime * 1f);
      this.Yandere.ShoulderCamera.transform.LookAt(this.Yandere.ShoulderCamera.NoticedFocus);
      if ((double) Vector3.Distance(this.Yandere.transform.position, this.Yandere.Senpai.position) < 1.25)
      {
        int num = (int) this.Yandere.MyController.Move(this.Yandere.transform.forward * (Time.deltaTime * -1f));
      }
      if ((double) this.Yandere.CharacterAnimation["f02_down_22"].time >= (double) this.Yandere.CharacterAnimation["f02_down_22"].length)
        this.Yandere.CharacterAnimation.CrossFade("f02_down_23");
    }
    if ((double) this.Background.color.a < 1.0)
    {
      this.Background.color = new Color(this.Background.color.r, this.Background.color.g, this.Background.color.b, this.Background.color.a + Time.deltaTime);
      this.Ground.color = new Color(this.Ground.color.r, this.Ground.color.g, this.Ground.color.b, this.Ground.color.a + Time.deltaTime);
      if ((double) this.Background.color.a >= 1.0)
      {
        this.ConfessionUICamera.enabled = false;
        this.MainCamera.enabled = false;
      }
    }
    AudioSource component = this.GetComponent<AudioSource>();
    if (this.LetterID < this.StopID)
    {
      UILabel letter = this.Letters[this.LetterID];
      letter.transform.localScale = Vector3.MoveTowards(letter.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 100f);
      letter.color = new Color(letter.color.r, letter.color.g, letter.color.b, letter.color.a + Time.deltaTime * 10f);
      if (letter.transform.localScale == new Vector3(1f, 1f, 1f))
      {
        component.PlayOneShot(this.Slam);
        GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
        this.VibrationTimer = 0.1f;
        ++this.LetterID;
        if (this.LetterID == this.StopID)
          this.ID = 0;
      }
    }
    else if (this.Phase == 3)
    {
      if ((double) this.Options[0].color.a == 0.0)
      {
        this.Subtitle.color = new Color(this.Subtitle.color.r, this.Subtitle.color.g, this.Subtitle.color.b, 0.0f);
        component.Play();
      }
      if (this.ID < this.Options.Length)
      {
        UILabel option = this.Options[this.ID];
        option.alpha += Time.deltaTime * 5f;
        if ((double) option.color.a >= (double) this.TargetAlpha[this.ID])
        {
          option.alpha = this.TargetAlpha[this.ID];
          ++this.ID;
        }
      }
    }
    if (!this.Freeze)
    {
      for (this.ShakeID = 0; this.ShakeID < this.Letters.Length; ++this.ShakeID)
      {
        UILabel letter = this.Letters[this.ShakeID];
        Vector3 origin = this.Origins[this.ShakeID];
        letter.transform.localPosition = new Vector3(origin.x + Random.Range(-5f, 5f), origin.y + Random.Range(-5f, 5f), letter.transform.localPosition.z);
      }
    }
    for (this.GrowID = 0; this.GrowID < 5; ++this.GrowID)
    {
      UILabel option = this.Options[this.GrowID];
      option.transform.localScale = Vector3.Lerp(option.transform.localScale, this.Cursor.Selected - 1 != this.GrowID ? new Vector3(0.5f, 0.5f, 0.5f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    }
  }

  private void UpdateSubtitle()
  {
    StudentScript component = this.Yandere.Senpai.GetComponent<StudentScript>();
    if ((Object) component != (Object) null && !component.Teacher && this.Yandere.Noticed)
    {
      this.Subtitle.color = new Color(this.Subtitle.color.r, this.Subtitle.color.g, this.Subtitle.color.b, 1f);
      GameOverType gameOverCause = component.GameOverCause;
      int index = 0;
      switch (gameOverCause)
      {
        case GameOverType.Blood:
          index = 2;
          break;
        case GameOverType.Insanity:
          index = 3;
          break;
        case GameOverType.Lewd:
          index = 6;
          break;
        case GameOverType.Murder:
          index = 5;
          break;
        case GameOverType.Stalking:
          index = 4;
          break;
        case GameOverType.Weapon:
          index = 1;
          break;
      }
      this.Subtitle.text = this.NoticedLines[index];
      this.Subtitle.GetComponent<AudioSource>().clip = this.NoticedClips[index];
      this.Subtitle.GetComponent<AudioSource>().Play();
    }
    else
    {
      if (!this.Headmaster)
        return;
      this.Subtitle.color = new Color(this.Subtitle.color.r, this.Subtitle.color.g, this.Subtitle.color.b, 1f);
      if (!this.Yandere.StudentManager.Eighties)
      {
        this.Subtitle.text = this.NoticedLines[8];
        this.Subtitle.GetComponent<AudioSource>().clip = this.NoticedClips[8];
      }
      else
      {
        this.Subtitle.text = this.NoticedLines[9];
        this.Subtitle.GetComponent<AudioSource>().clip = this.NoticedClips[9];
      }
      this.Subtitle.GetComponent<AudioSource>().Play();
    }
  }

  public void Darken()
  {
    for (int index = 0; index < this.Letters.Length; ++index)
    {
      if ((double) this.Letters[index].color.a > 1.0)
        this.Letters[index].color = new Color(1f, 0.0f, 0.0f, 1f);
      this.Letters[index].color = new Color(1f, 0.0f, 0.0f, this.Letters[index].color.a - 0.05882353f);
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((double) this.Options[index].color.a > 1.0)
        this.Options[index].color = new Color(this.Options[index].color.r, this.Options[index].color.g, this.Options[index].color.b, 1f);
      this.Options[index].color = new Color(this.Options[index].color.r, this.Options[index].color.g, this.Options[index].color.b, this.Options[index].color.a - 0.05882353f);
    }
  }
}
