// Decompiled with JetBrains decompiler
// Type: MGPMManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MGPMManagerScript : MonoBehaviour
{
  public MGPMSpawnerScript[] EnemySpawner;
  public MGPMWaterScript[] Water;
  public MGPMMiyukiScript Miyuki;
  public GameObject StageClearGraphic;
  public GameObject GameOverGraphic;
  public GameObject StartGraphic;
  public Renderer[] WaterRenderer;
  public AudioClip HardModeVoice;
  public AudioClip GameOverMusic;
  public AudioClip VictoryMusic;
  public AudioClip FinalBoss;
  public AudioClip BGM;
  public AudioClip EightiesGameOverMusic;
  public AudioClip EightiesGameplayLoop;
  public AudioClip EightiesVictoryMusic;
  public AudioClip EightiesIntroJingle;
  public AudioClip EightiesFinalBoss;
  public Renderer RightArtwork;
  public Renderer LeftArtwork;
  public Renderer Border;
  public AudioSource Jukebox;
  public Texture WhiteBorder;
  public Texture RightBloody;
  public Texture LeftBloody;
  public Transform Canvas;
  public Texture[] Stars;
  public Text ScoreLabel;
  public Renderer Black;
  public float GameOverTimer;
  public float Timer;
  public bool StageClear;
  public bool Eighties;
  public bool GameOver;
  public bool FadeOut;
  public bool FadeIn;
  public bool Intro;
  public int Score;
  public int ID;
  public Font VCR;

  private void Start()
  {
    if (GameGlobals.HardMode)
    {
      this.Jukebox.clip = this.HardModeVoice;
      this.WaterRenderer[0].material.color = Color.red;
      this.WaterRenderer[1].material.color = Color.red;
      this.RightArtwork.material.mainTexture = this.RightBloody;
      this.LeftArtwork.material.mainTexture = this.LeftBloody;
    }
    if (GameGlobals.Eighties)
    {
      this.Canvas.localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
      this.Canvas.localScale = new Vector3(0.0332f, 0.0332f, 0.0332f);
      this.StageClearGraphic.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90f);
      this.GameOverGraphic.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90f);
      this.StartGraphic.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90f);
      this.GameOverGraphic.transform.GetChild(0).gameObject.SetActive(false);
      this.RightArtwork.material.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.LeftArtwork.material.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.Miyuki.Hearts[1].transform.localPosition = new Vector3(145f, -260f, -4f);
      this.Miyuki.Hearts[1].transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.Miyuki.Hearts[1].transform.localScale = new Vector3(16f, 16f, 1f);
      this.Miyuki.Hearts[2].transform.localPosition = new Vector3(145f, -245f, -4f);
      this.Miyuki.Hearts[2].transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.Miyuki.Hearts[2].transform.localScale = new Vector3(16f, 16f, 1f);
      this.Miyuki.Hearts[3].transform.localPosition = new Vector3(145f, -230f, -4f);
      this.Miyuki.Hearts[3].transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.Miyuki.Hearts[3].transform.localScale = new Vector3(16f, 16f, 1f);
      this.Miyuki.MagicBar.transform.parent.localPosition = new Vector3(145f, 0.0f, -1.1f);
      this.Miyuki.MagicBar.transform.parent.localEulerAngles = new Vector3(0.0f, 0.0f, 90f);
      this.Miyuki.MagicBar.transform.parent.localScale = new Vector3(132f, 10f, 1f);
      this.Border.material.mainTexture = this.WhiteBorder;
      this.ScoreLabel.color = new Color(1f, 1f, 1f, 1f);
      this.ScoreLabel.font = this.VCR;
      this.GameOverMusic = this.EightiesGameOverMusic;
      this.VictoryMusic = this.EightiesVictoryMusic;
      this.Jukebox.clip = this.EightiesIntroJingle;
      this.FinalBoss = this.EightiesFinalBoss;
      this.BGM = this.EightiesGameplayLoop;
      this.Water[1].Sprite = this.Stars;
      this.Water[2].Sprite = this.Stars;
      this.Eighties = true;
    }
    this.Miyuki.transform.localPosition = new Vector3(0.0f, -300f, 0.0f);
    this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.StartGraphic.SetActive(false);
    this.Miyuki.Gameplay = false;
    for (this.ID = 1; this.ID < this.EnemySpawner.Length; ++this.ID)
      this.EnemySpawner[this.ID].enabled = false;
    Time.timeScale = 1f;
  }

  private void Update()
  {
    this.ScoreLabel.text = "Score: " + (this.Score * this.Miyuki.Health).ToString();
    if (this.StageClear)
    {
      this.GameOverTimer += Time.deltaTime;
      if ((double) this.GameOverTimer > 1.0)
      {
        this.Miyuki.transform.localPosition = new Vector3(this.Miyuki.transform.localPosition.x, this.Miyuki.transform.localPosition.y + Time.deltaTime * 10f, this.Miyuki.transform.localPosition.z);
        if (!this.StageClearGraphic.activeInHierarchy)
        {
          this.StageClearGraphic.SetActive(true);
          this.Jukebox.clip = this.VictoryMusic;
          this.Jukebox.loop = false;
          this.Jukebox.volume = 1f;
          this.Jukebox.Play();
        }
        if ((double) this.GameOverTimer > 9.0)
          this.FadeOut = true;
      }
      if (!this.FadeOut)
        return;
      this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
      this.Jukebox.volume = 1f - this.Black.material.color.a;
      if ((double) this.Black.material.color.a != 1.0)
        return;
      if (!this.Eighties)
        SceneManager.LoadScene("MiyukiThanksScene");
      else
        SceneManager.LoadScene("HomeScene");
    }
    else if (!this.GameOver)
    {
      if (!this.Intro)
        return;
      if (this.FadeIn)
      {
        this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Black.material.color.a, 0.0f, Time.deltaTime));
        if ((double) this.Black.material.color.a == 0.0)
        {
          this.Jukebox.Play();
          this.FadeIn = false;
        }
      }
      else
      {
        this.Miyuki.transform.localPosition = new Vector3(0.0f, Mathf.MoveTowards(this.Miyuki.transform.localPosition.y, -120f, Time.deltaTime * 60f), 0.0f);
        if ((double) this.Miyuki.transform.localPosition.y == -120.0)
        {
          if (!this.Jukebox.isPlaying)
          {
            this.Jukebox.loop = true;
            this.Jukebox.clip = this.BGM;
            this.Jukebox.Play();
            if (GameGlobals.HardMode)
              this.Jukebox.pitch = 0.2f;
          }
          this.StartGraphic.SetActive(true);
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 3.5)
          {
            this.StartGraphic.SetActive(false);
            for (this.ID = 1; this.ID < this.EnemySpawner.Length; ++this.ID)
              this.EnemySpawner[this.ID].enabled = true;
            this.Miyuki.Gameplay = true;
            this.Intro = false;
          }
        }
      }
      if (!Input.GetKeyDown("space"))
        return;
      this.StartGraphic.SetActive(false);
      for (this.ID = 1; this.ID < this.EnemySpawner.Length; ++this.ID)
        this.EnemySpawner[this.ID].enabled = true;
      this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.Miyuki.Gameplay = true;
      this.Intro = false;
      this.Jukebox.loop = true;
      this.Jukebox.clip = this.BGM;
      this.Jukebox.Play();
      if (!GameGlobals.HardMode)
        return;
      this.Jukebox.pitch = 0.2f;
    }
    else
    {
      this.GameOverTimer += Time.deltaTime;
      if ((double) this.GameOverTimer > 3.0)
      {
        if (!this.GameOverGraphic.activeInHierarchy)
        {
          this.GameOverGraphic.SetActive(true);
          this.Jukebox.clip = this.GameOverMusic;
          this.Jukebox.loop = false;
          this.Jukebox.Play();
        }
        else if (Input.anyKeyDown)
          this.FadeOut = true;
      }
      if (!this.FadeOut)
        return;
      this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
      this.Jukebox.volume = 1f - this.Black.material.color.a;
      if ((double) this.Black.material.color.a != 1.0)
        return;
      SceneManager.LoadScene("MiyukiTitleScene");
    }
  }

  public void BeginGameOver()
  {
    this.Jukebox.Stop();
    this.GameOver = true;
    this.Miyuki.enabled = false;
  }
}
