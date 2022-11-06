// Decompiled with JetBrains decompiler
// Type: MusicMinigameScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicMinigameScript : MonoBehaviour
{
  public GameObject[] NoteIcons;
  public Transform[] Scales;
  public Renderer[] Stars;
  public InputManagerScript InputManager;
  public Renderer HealthBarRenderer;
  public Renderer Black;
  public Transform ReputationMarker;
  public Transform ReputationBar;
  public Transform HealthBar;
  public Transform SadMiyuji;
  public Transform SadAyano;
  public GameObject GameOverScreen;
  public AudioSource MyAudio;
  public UILabel CurrentRep;
  public UILabel RepBonus;
  public Texture EmptyStar;
  public Texture GoldStar;
  public float JumpStrength;
  public float CringeTimer;
  public float StartRep;
  public float Health;
  public float Alpha;
  public float Power;
  public float Speed;
  public float Timer;
  public float[] Phase1Times;
  public int[] Phase1Notes;
  public float[] Phase2Times;
  public int[] Phase2Notes;
  public float[] Times;
  public int[] Notes;
  public int CurrentNote;
  public int Excitement;
  public int Phase;
  public int Note;
  public int ID;
  public bool SettingNotes;
  public bool LockHealth;
  public bool GameOver;
  public bool KeyDown;
  public bool Won;
  public Texture[] ChibiCelebrate;
  public Texture[] ChibiPerform;
  public Texture[] ChibiPerformB;
  public Texture[] ChibiCringe;
  public Texture[] ChibiIdle;
  public Texture[] EightiesChibiCelebrate;
  public Texture[] EightiesChibiPerform;
  public Texture[] EightiesChibiPerformB;
  public Texture[] EightiesChibiCringe;
  public Texture[] EightiesChibiIdle;
  public ParticleSystem[] MusicNotes;
  public AudioClip[] Celebrations;
  public Renderer[] ChibiRenderer;
  public Transform[] Instruments;
  public float[] AnimTimer;
  public float[] PingPong;
  public float[] Rotation;
  public float[] Jump;
  public bool[] ChibiSway;
  public bool[] FrameB;
  public bool[] Ping;
  public Renderer Background;
  public Texture EightiesBG;
  public Texture SadLeader;
  public Texture SadRyoba;

  private void Start()
  {
    if (GameGlobals.Eighties)
    {
      this.ChibiCelebrate = this.EightiesChibiCelebrate;
      this.ChibiPerform = this.EightiesChibiPerform;
      this.ChibiPerformB = this.EightiesChibiPerformB;
      this.ChibiCringe = this.EightiesChibiCringe;
      this.ChibiIdle = this.EightiesChibiIdle;
      this.ChibiRenderer[1].material.mainTexture = this.ChibiIdle[1];
      this.ChibiRenderer[2].material.mainTexture = this.ChibiIdle[2];
      this.ChibiRenderer[3].material.mainTexture = this.ChibiIdle[3];
      this.ChibiRenderer[4].material.mainTexture = this.ChibiIdle[4];
      this.ChibiRenderer[5].material.mainTexture = this.ChibiIdle[5];
      this.ChibiRenderer[6].material.mainTexture = this.ChibiIdle[6];
      this.SadMiyuji.GetComponent<Renderer>().material.mainTexture = this.SadLeader;
      this.SadAyano.GetComponent<Renderer>().material.mainTexture = this.SadRyoba;
      this.Background.material.mainTexture = this.EightiesBG;
    }
    this.StartRep = PlayerPrefs.GetFloat("TempReputation");
    Application.targetFrameRate = 60;
    Time.timeScale = 1f;
    this.Black.gameObject.SetActive(true);
    this.GameOverScreen.SetActive(false);
    this.Scales[0].localPosition = new Vector3(-1f, 0.0f, 0.0f);
    this.Scales[1].localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    this.Scales[2].localPosition = new Vector3(1f, 0.0f, 0.0f);
    this.Scales[3].localPosition = new Vector3(2f, 0.0f, 0.0f);
    for (this.ID = 0; this.ID < this.Phase1Times.Length; ++this.ID)
    {
      this.Times[this.ID] = this.Phase1Times[this.ID];
      this.Notes[this.ID] = this.Phase1Notes[this.ID];
    }
    for (this.ID = 0; this.ID < this.Phase2Times.Length; ++this.ID)
    {
      this.Times[this.ID + 216] = this.Phase2Times[this.ID];
      this.Notes[this.ID + 216] = this.Phase2Notes[this.ID];
    }
    for (this.ID = 0; this.ID < this.Times.Length; ++this.ID)
      this.Times[this.ID] += 3f;
    this.UpdateHealthBar();
    this.ReputationBar.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, 1f);
  }

  private void Update()
  {
    for (this.ID = 0; this.ID < this.Scales.Length; ++this.ID)
    {
      this.Scales[this.ID].localPosition -= new Vector3(Time.deltaTime * this.Speed, 0.0f, 0.0f);
      if ((double) this.Scales[this.ID].localPosition.x < -2.0)
        this.Scales[this.ID].localPosition += new Vector3(4f, 0.0f, 0.0f);
    }
    if (this.GameOver)
    {
      this.MyAudio.pitch = Mathf.MoveTowards(this.MyAudio.pitch, 0.0f, Time.deltaTime * 0.33333f);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 4.0)
        return;
      if (!this.GameOverScreen.activeInHierarchy)
      {
        this.SadMiyuji.localPosition = new Vector3(-0.51f, -0.1f, -0.2f);
        this.SadAyano.localPosition = new Vector3(0.495f, -0.1f, -0.2f);
        this.GameOverScreen.SetActive(true);
      }
      this.SadMiyuji.localPosition = Vector3.Lerp(this.SadMiyuji.localPosition, new Vector3(-0.455f, -0.1f, -0.2f), Time.deltaTime);
      this.SadAyano.localPosition = Vector3.Lerp(this.SadAyano.localPosition, new Vector3(0.44f, -0.1f, -0.2f), Time.deltaTime);
      if ((double) this.Timer <= 9.0)
        return;
      this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
      this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      if ((double) this.Alpha != 1.0)
        return;
      this.Quit();
    }
    else if (!this.Won)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime);
      this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      this.Timer += Time.deltaTime;
      if (!this.MyAudio.isPlaying)
      {
        if ((double) this.Timer > 3.0)
        {
          if ((double) this.Timer < (double) this.MyAudio.clip.length)
          {
            this.MyAudio.Play();
          }
          else
          {
            this.ChibiRenderer[1].material.mainTexture = this.ChibiCelebrate[1];
            this.ChibiRenderer[2].material.mainTexture = this.ChibiCelebrate[2];
            this.ChibiRenderer[3].material.mainTexture = this.ChibiCelebrate[3];
            this.ChibiRenderer[4].material.mainTexture = this.ChibiCelebrate[4];
            this.ChibiRenderer[5].material.mainTexture = this.ChibiCelebrate[5];
            this.ChibiRenderer[6].material.mainTexture = this.ChibiCelebrate[6];
            this.Jump[1] = this.JumpStrength;
            this.Jump[2] = this.JumpStrength * 0.9f;
            this.Jump[3] = this.JumpStrength * 0.8f;
            this.Jump[4] = this.JumpStrength * 0.7f;
            this.Jump[5] = this.JumpStrength * 0.6f;
            this.Jump[6] = this.JumpStrength * 0.5f;
            this.Excitement = (double) this.Health != 200.0 ? ((double) this.Health <= 0.0 ? 1 : 2) : 3;
            this.MyAudio.clip = this.Celebrations[this.Excitement];
            this.MyAudio.loop = false;
            this.MyAudio.Play();
            this.Won = true;
            this.Timer = 0.0f;
          }
        }
      }
      else
      {
        if ((double) this.MyAudio.time > 131.0)
        {
          this.ChibiSway[2] = false;
          this.ChibiSway[6] = false;
          this.ChibiSway[3] = false;
          this.ChibiSway[5] = false;
          this.ChibiSway[4] = false;
        }
        else if ((double) this.MyAudio.time > 88.2833333)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = true;
          this.ChibiSway[3] = true;
          this.ChibiSway[5] = true;
          this.ChibiSway[4] = true;
        }
        else if ((double) this.MyAudio.time > 74.25)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = true;
          this.ChibiSway[3] = true;
          this.ChibiSway[5] = false;
          this.ChibiSway[4] = false;
        }
        else if ((double) this.MyAudio.time > 60.0)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = true;
          this.ChibiSway[3] = false;
          this.ChibiSway[5] = false;
          this.ChibiSway[4] = false;
        }
        else if ((double) this.MyAudio.time > 45.933333)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = true;
          this.ChibiSway[3] = true;
          this.ChibiSway[5] = true;
          this.ChibiSway[4] = true;
        }
        else if ((double) this.MyAudio.time > 45.08)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = true;
          this.ChibiSway[3] = false;
          this.ChibiSway[5] = true;
          this.ChibiSway[4] = true;
        }
        else if ((double) this.MyAudio.time > 35.33333)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = false;
          this.ChibiSway[3] = false;
          this.ChibiSway[5] = true;
          this.ChibiSway[4] = true;
        }
        else if ((double) this.MyAudio.time > 31.833333)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = false;
          this.ChibiSway[3] = false;
          this.ChibiSway[5] = false;
          this.ChibiSway[4] = false;
        }
        else if ((double) this.MyAudio.time > 30.33333)
        {
          this.ChibiSway[2] = false;
          this.ChibiSway[6] = false;
          this.ChibiSway[3] = false;
          this.ChibiSway[5] = false;
          this.ChibiSway[4] = false;
        }
        else if ((double) this.MyAudio.time > 28.2833333)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = true;
          this.ChibiSway[3] = false;
          this.ChibiSway[5] = false;
          this.ChibiSway[4] = false;
        }
        else if ((double) this.MyAudio.time > 7.1166666)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = true;
          this.ChibiSway[3] = true;
          this.ChibiSway[5] = true;
          this.ChibiSway[4] = false;
        }
        else if ((double) this.MyAudio.time > 3.5833333)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = true;
          this.ChibiSway[3] = false;
          this.ChibiSway[5] = false;
          this.ChibiSway[4] = false;
        }
        else if ((double) this.MyAudio.time > 0.0)
        {
          this.ChibiSway[2] = true;
          this.ChibiSway[6] = false;
          this.ChibiSway[3] = false;
          this.ChibiSway[5] = false;
          this.ChibiSway[4] = false;
        }
        this.ChibiSway[1] = (double) this.MyAudio.time > 33.0 && (double) this.MyAudio.time < 36.833332061767578 || (double) this.MyAudio.time > 39.5 && (double) this.MyAudio.time < 43.25 || (double) this.MyAudio.time > 46.833332061767578 && (double) this.MyAudio.time < 49.75 || (double) this.MyAudio.time > 50.383335113525391 && (double) this.MyAudio.time < 53.0 || (double) this.MyAudio.time > 53.916667938232422 && (double) this.MyAudio.time < 59.0 || (double) this.MyAudio.time > 59.5 && (double) this.MyAudio.time < 74.333328247070313 || (double) this.MyAudio.time > 77.0 && (double) this.MyAudio.time < 80.333328247070313 || (double) this.MyAudio.time > 84.050003051757813 && (double) this.MyAudio.time < 88.166664123535156 || (double) this.MyAudio.time > 91.0 && (double) this.MyAudio.time < 98.5 || (double) this.MyAudio.time > 101.83333587646484 && (double) this.MyAudio.time < 130.58332824707031;
        if ((double) this.CringeTimer == 0.0)
          this.MyAudio.volume = 1f;
        for (this.ID = 1; this.ID < this.ChibiSway.Length; ++this.ID)
        {
          if ((double) this.CringeTimer > 0.0)
          {
            this.ChibiRenderer[this.ID].transform.localPosition = new Vector3(Random.Range(-0.01f, 0.01f), 0.15f + Random.Range(-0.01f, 0.01f), 0.0f);
            this.CringeTimer = Mathf.MoveTowards(this.CringeTimer, 0.0f, Time.deltaTime);
            if ((double) this.CringeTimer == 0.0)
              this.ChibiRenderer[this.ID].transform.localPosition = new Vector3(0.0f, 0.15f, 0.0f);
          }
          else if (this.ChibiSway[this.ID])
          {
            if (!this.MusicNotes[this.ID].isPlaying)
              this.MusicNotes[this.ID].Play();
            this.AnimTimer[this.ID] += Time.deltaTime;
            if ((double) this.AnimTimer[this.ID] > 0.20000000298023224)
            {
              this.FrameB[this.ID] = !this.FrameB[this.ID];
              this.AnimTimer[this.ID] = 0.0f;
            }
            this.ChibiRenderer[this.ID].material.mainTexture = !this.FrameB[this.ID] ? this.ChibiPerformB[this.ID] : this.ChibiPerform[this.ID];
            if (this.ID < 6)
            {
              if (this.Ping[this.ID])
              {
                this.PingPong[this.ID] += Time.deltaTime * 5f;
                if ((double) this.PingPong[this.ID] > 1.0)
                  this.Ping[this.ID] = false;
              }
              else
              {
                this.PingPong[this.ID] -= Time.deltaTime * 5f;
                if ((double) this.PingPong[this.ID] < -1.0)
                  this.Ping[this.ID] = true;
              }
              this.Rotation[this.ID] += (float) ((double) this.PingPong[this.ID] * (double) Time.deltaTime * 10.0);
              if ((double) this.Rotation[this.ID] > 7.5)
                this.Rotation[this.ID] = 7.5f;
              else if ((double) this.Rotation[this.ID] < -7.5)
                this.Rotation[this.ID] = -7.5f;
            }
          }
          else
          {
            if (this.ID < 6)
              this.Rotation[this.ID] = Mathf.MoveTowards(this.Rotation[this.ID], 0.0f, Time.deltaTime * 100f);
            if ((Object) this.ChibiRenderer[this.ID].material.mainTexture != (Object) this.ChibiIdle[this.ID])
            {
              this.ChibiRenderer[this.ID].material.mainTexture = this.ChibiIdle[this.ID];
              this.MusicNotes[this.ID].Stop();
              this.PingPong[this.ID] = -1f;
              this.Ping[this.ID] = false;
            }
          }
          this.Instruments[this.ID].localEulerAngles = new Vector3(0.0f, 0.0f, this.Rotation[this.ID]);
        }
      }
      if (this.SettingNotes)
      {
        if (Input.GetKeyDown("up"))
        {
          if (this.Phase == 1)
          {
            this.Phase1Times[this.Note] = this.MyAudio.time;
            this.Phase1Notes[this.Note] = 1;
          }
          else
          {
            this.Phase2Times[this.Note] = this.MyAudio.time;
            this.Phase2Notes[this.Note] = 1;
          }
          ++this.Note;
        }
        else if (Input.GetKeyDown("right"))
        {
          if (this.Phase == 1)
          {
            this.Phase1Times[this.Note] = this.MyAudio.time;
            this.Phase1Notes[this.Note] = 2;
          }
          else
          {
            this.Phase2Times[this.Note] = this.MyAudio.time;
            this.Phase2Notes[this.Note] = 2;
          }
          ++this.Note;
        }
        else if (Input.GetKeyDown("left"))
        {
          if (this.Phase == 1)
          {
            this.Phase1Times[this.Note] = this.MyAudio.time;
            this.Phase1Notes[this.Note] = 3;
          }
          else
          {
            this.Phase2Times[this.Note] = this.MyAudio.time;
            this.Phase2Notes[this.Note] = 3;
          }
          ++this.Note;
        }
        else
        {
          if (!Input.GetKeyDown("down"))
            return;
          if (this.Phase == 1)
          {
            this.Phase1Times[this.Note] = this.MyAudio.time;
            this.Phase1Notes[this.Note] = 4;
          }
          else
          {
            this.Phase2Times[this.Note] = this.MyAudio.time;
            this.Phase2Notes[this.Note] = 4;
          }
          ++this.Note;
        }
      }
      else
      {
        if (Input.GetKeyUp("up") || Input.GetKeyUp("right") || Input.GetKeyUp("down") || Input.GetKeyUp("left"))
          this.KeyDown = false;
        if (!this.InputManager.TappedUp && !this.InputManager.TappedDown && !this.InputManager.TappedLeft && !this.InputManager.TappedRight)
          this.KeyDown = false;
        if (this.Note >= this.Notes.Length || this.Notes[this.Note] <= 0 || (double) this.Timer + 2.0 <= (double) this.Times[this.Note])
          return;
        GameObject gameObject = Object.Instantiate<GameObject>(this.NoteIcons[this.Notes[this.Note]], this.transform.position, Quaternion.identity);
        gameObject.GetComponent<MusicNoteScript>().InputManager = this.InputManager;
        gameObject.GetComponent<MusicNoteScript>().MusicMinigame = this;
        gameObject.GetComponent<MusicNoteScript>().ID = this.Note;
        gameObject.transform.parent = this.Scales[0].parent;
        if (this.Notes[this.Note] == 1)
          gameObject.transform.localPosition = new Vector3(1.5f, 0.15f, -0.0001f);
        else if (this.Notes[this.Note] == 2)
          gameObject.transform.localPosition = new Vector3(1.5f, 0.05f, -0.0001f);
        else if (this.Notes[this.Note] == 3)
          gameObject.transform.localPosition = new Vector3(1.5f, -0.05f, -0.0001f);
        else if (this.Notes[this.Note] == 4)
          gameObject.transform.localPosition = new Vector3(1.5f, -0.15f, -0.0001f);
        gameObject.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        ++this.Note;
      }
    }
    else
    {
      for (this.ID = 1; this.ID < this.Instruments.Length; ++this.ID)
      {
        if (this.ID != 2 && this.ID != 6)
        {
          this.ChibiRenderer[this.ID].transform.localPosition += new Vector3(0.0f, this.Jump[this.ID], 0.0f);
          this.Jump[this.ID] -= Time.deltaTime * 0.01f;
          if ((double) this.ChibiRenderer[this.ID].transform.localPosition.y < 0.15000000596046448)
          {
            this.ChibiRenderer[this.ID].transform.localPosition = new Vector3(0.0f, 0.15f, 0.0f);
            this.Jump[this.ID] = this.JumpStrength;
          }
        }
      }
      if (this.MyAudio.isPlaying)
        return;
      if ((double) this.Timer == 0.0)
      {
        this.CurrentRep.text = this.StartRep.ToString() ?? "";
        if ((double) this.Health > 100.0)
          this.RepBonus.text = "+" + (this.Health - 100f).ToString();
        this.ReputationMarker.localPosition = new Vector3(this.StartRep * 0.01f, 0.0f, 0.0f);
      }
      this.ReputationBar.localScale = Vector3.Lerp(this.ReputationBar.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0 && (double) this.Health > 100.0)
      {
        float num = this.StartRep + (this.Health - 100f);
        if ((double) num > 100.0)
          num = 100f;
        this.CurrentRep.text = num.ToString() ?? "";
        this.Power += Time.deltaTime;
        this.ReputationMarker.localPosition = Vector3.Lerp(this.ReputationMarker.localPosition, new Vector3(num * 0.01f, 0.0f, -0.0002f), this.Power);
      }
      if ((double) this.Timer <= 5.0)
        return;
      this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
      this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      if ((double) this.Alpha != 1.0)
        return;
      this.Quit();
    }
  }

  public void UpdateHealthBar()
  {
    if ((double) this.Health > 200.0)
      this.Health = 200f;
    if ((double) this.Health <= 0.0)
    {
      this.MyAudio.volume = 1f;
      this.GameOver = true;
      this.Health = 0.0f;
      this.Timer = 0.0f;
    }
    else
    {
      this.HealthBar.localScale = new Vector3(1f, this.Health / 200f, 1f);
      this.HealthBarRenderer.material.color = new Color((float) (1.0 - (double) this.Health / 200.0), this.Health / 200f, 0.0f, 1f);
    }
    this.Stars[1].material.mainTexture = (double) this.Health <= 100.0 ? this.EmptyStar : this.GoldStar;
    this.Stars[2].material.mainTexture = (double) this.Health <= 125.0 ? this.EmptyStar : this.GoldStar;
    this.Stars[3].material.mainTexture = (double) this.Health <= 150.0 ? this.EmptyStar : this.GoldStar;
    this.Stars[4].material.mainTexture = (double) this.Health <= 175.0 ? this.EmptyStar : this.GoldStar;
    if ((double) this.Health == 200.0)
      this.Stars[5].material.mainTexture = this.GoldStar;
    else
      this.Stars[5].material.mainTexture = this.EmptyStar;
  }

  public void Cringe()
  {
    for (this.ID = 1; this.ID < this.ChibiRenderer.Length; ++this.ID)
    {
      this.ChibiRenderer[this.ID].material.mainTexture = this.ChibiCringe[this.ID];
      this.MusicNotes[this.ID].Stop();
      this.Rotation[this.ID] = 0.0f;
    }
    this.MyAudio.volume = 0.0f;
    this.CringeTimer = 1f;
  }

  public void Quit()
  {
    Debug.Log((object) ("Starting reputation was: " + this.StartRep.ToString()));
    if ((double) this.Health > 100.0)
      PlayerPrefs.SetFloat("TempReputation", this.Health - 100f);
    else
      PlayerPrefs.SetFloat("TempReputation", 0.0f);
    Debug.Log((object) ("Health is: " + this.Health.ToString()));
    if ((double) this.Health > 0.0 && !GameGlobals.Debug)
    {
      Debug.Log((object) "Setting ''Panther'' achievement true.");
      PlayerPrefs.SetInt("Panther", 1);
      PlayerPrefs.SetInt("a", 1);
    }
    Debug.Log((object) ("And now, after playing the Light Music Club minigame, we should gain " + PlayerPrefs.GetFloat("TempReputation").ToString() + " reputation points."));
    foreach (GameObject rootGameObject in SceneManager.GetActiveScene().GetRootGameObjects())
      rootGameObject.SetActive(true);
    SceneManager.UnloadSceneAsync(23);
  }
}
