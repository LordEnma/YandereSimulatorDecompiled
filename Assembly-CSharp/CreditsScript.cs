// Decompiled with JetBrains decompiler
// Type: CreditsScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
  [SerializeField]
  private JsonScript JSON;
  [SerializeField]
  private Transform SpawnPoint;
  [SerializeField]
  private Transform Panel;
  [SerializeField]
  private GameObject SmallCreditsLabel;
  [SerializeField]
  private GameObject BigCreditsLabel;
  [SerializeField]
  private UILabel SkipLabel;
  [SerializeField]
  private UISprite Darkness;
  [SerializeField]
  private int ID;
  public float SpeedUpFactor;
  public float MusicTimer;
  public float TimerLimit;
  public float FadeTimer;
  public float Speed = 1f;
  public float Timer;
  public bool Eighties;
  public bool FadeOut;
  public bool Begin;
  public bool Dark;
  private const int SmallTextSize = 1;
  private const int BigTextSize = 2;
  public AudioClip EightiesCreditsMusic;
  public AudioClip DarkCreditsMusic;
  public AudioSource Jukebox;
  public ParticleSystem Blossoms;

  private bool ShouldStopCredits => this.ID == this.JSON.Credits.Length;

  private GameObject SpawnLabel(int size) => Object.Instantiate<GameObject>(size == 1 ? this.SmallCreditsLabel : this.BigCreditsLabel, this.SpawnPoint.position, Quaternion.identity);

  private void Start()
  {
    if (GameGlobals.TransitionToPostCredits || GameGlobals.DarkEnding)
    {
      GameGlobals.DarkEnding = false;
      this.Jukebox.clip = this.DarkCreditsMusic;
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.Blossoms.startColor = new Color(0.5f, 0.0f, 0.0f, 1f);
      this.SkipLabel.color = new Color(0.5f, 0.0f, 0.0f, 1f);
      this.Dark = true;
    }
    if (!GameGlobals.Eighties)
      return;
    Camera.main.backgroundColor = new Color(0.05f, 0.05f, 0.05f, 1f);
    this.Jukebox.clip = this.EightiesCreditsMusic;
    this.Eighties = true;
  }

  private void Update()
  {
    this.MusicTimer += Time.deltaTime;
    if (!this.Begin)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0)
      {
        this.Begin = true;
        this.Jukebox.Play();
        this.Timer = 0.0f;
        this.SpawnCredit();
      }
    }
    else
    {
      if (!this.ShouldStopCredits)
      {
        this.Timer += Time.deltaTime * this.Speed;
        if ((double) this.Timer >= (double) this.TimerLimit)
        {
          this.SpawnCredit();
          this.Timer -= this.TimerLimit;
        }
      }
      if (Input.GetButtonDown("X") || (double) this.MusicTimer >= (double) this.Jukebox.clip.length)
        this.FadeOut = true;
    }
    if (this.FadeOut)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      this.Jukebox.volume -= Time.deltaTime;
      if ((double) this.Darkness.color.a == 1.0)
      {
        if (GameGlobals.TransitionToPostCredits)
          SceneManager.LoadScene("PostCreditsScene");
        else if (GameGlobals.TrueEnding)
          SceneManager.LoadScene("TrueEndingScene");
        else
          SceneManager.LoadScene("NewTitleScene");
      }
    }
    int num = Input.GetKeyDown(KeyCode.Minus) ? 1 : 0;
    bool keyDown = Input.GetKeyDown(KeyCode.Equals);
    if (num != 0)
      --Time.timeScale;
    else if (keyDown)
      ++Time.timeScale;
    if ((num | (keyDown ? 1 : 0)) == 0)
      return;
    this.Jukebox.pitch = Time.timeScale;
  }

  public void SpawnCredit()
  {
    CreditJson credit = this.JSON.Credits[this.ID];
    GameObject gameObject = this.SpawnLabel(credit.Size);
    this.TimerLimit = (float) credit.Size * this.SpeedUpFactor;
    gameObject.transform.parent = this.Panel;
    gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    gameObject.GetComponent<UILabel>().text = credit.Name;
    if (this.Eighties)
      gameObject.GetComponent<UILabel>().color = new Color(0.8235294f, 0.6431373f, 1f, 1f);
    else if (this.Dark)
      gameObject.GetComponent<UILabel>().color = new Color(0.5f, 0.0f, 0.0f, 1f);
    ++this.ID;
  }
}
