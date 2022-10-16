// Decompiled with JetBrains decompiler
// Type: MGPMMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class MGPMMenuScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public AudioSource Jukebox;
  public AudioClip HardModeClip;
  public bool WindowDisplaying;
  public Transform Highlight;
  public Transform Background;
  public GameObject Controls;
  public GameObject Credits;
  public GameObject DifficultySelect;
  public GameObject MainMenu;
  public GameObject[] EightiesObjects;
  public GameObject[] ModernObjects;
  public Renderer Black;
  public Renderer Logo;
  public Renderer BG;
  public Texture BloodyLogo;
  public AudioClip BGM;
  public float Rotation;
  public float Vibrate;
  public bool Eighties;
  public bool HardMode;
  public bool FadeOut;
  public bool FadeIn;
  public int MenuLimit = 4;
  public int ID;

  private void Start()
  {
    this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    Time.timeScale = 1f;
    if (!GameGlobals.Eighties)
      return;
    this.Eighties = true;
    foreach (GameObject modernObject in this.ModernObjects)
      modernObject.SetActive(false);
    foreach (GameObject eightiesObject in this.EightiesObjects)
      eightiesObject.SetActive(true);
    this.MenuLimit = 2;
    this.Jukebox.volume = 0.0f;
  }

  private void Update()
  {
    this.Rotation -= Time.deltaTime * 3f;
    this.Background.localEulerAngles = new Vector3(0.0f, 0.0f, this.Rotation);
    if (this.FadeIn)
    {
      this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Black.material.color.a, 0.0f, Time.deltaTime));
      if ((double) this.Black.material.color.a == 0.0)
      {
        this.Jukebox.Play();
        this.FadeIn = false;
      }
    }
    if (this.FadeOut)
    {
      this.Black.material.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
      this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.0f, Time.deltaTime);
      if ((double) this.Black.material.color.a == 1.0)
      {
        if (this.ID == 4)
        {
          SceneManager.LoadScene("HomeScene");
        }
        else
        {
          GameGlobals.HardMode = this.HardMode;
          SceneManager.LoadScene("MiyukiGameplayScene");
        }
      }
    }
    if (this.FadeOut || this.FadeIn)
      return;
    if (!this.HardMode && Input.GetKeyDown("h"))
    {
      AudioSource.PlayClipAtPoint(this.HardModeClip, this.transform.position);
      this.Logo.material.mainTexture = this.BloodyLogo;
      this.HardMode = true;
      this.Vibrate = 0.1f;
    }
    if (this.HardMode)
    {
      this.Jukebox.pitch = Mathf.MoveTowards(this.Jukebox.pitch, 0.1f, Time.deltaTime);
      this.BG.material.color = new Color(Mathf.MoveTowards(this.BG.material.color.r, 0.5f, Time.deltaTime * 0.5f), Mathf.MoveTowards(this.BG.material.color.g, 0.0f, Time.deltaTime), Mathf.MoveTowards(this.BG.material.color.b, 0.0f, Time.deltaTime), 1f);
      this.Logo.transform.localPosition = new Vector3(0.0f, 0.5f, 2f) + new Vector3(Random.Range(this.Vibrate * -1f, this.Vibrate), Random.Range(this.Vibrate * -1f, this.Vibrate), 0.0f);
      this.Vibrate = Mathf.MoveTowards(this.Vibrate, 0.0f, Time.deltaTime * 0.1f);
    }
    if ((Object) this.Jukebox.clip != (Object) this.BGM && !this.Jukebox.isPlaying)
    {
      this.Jukebox.loop = true;
      this.Jukebox.clip = this.BGM;
      this.Jukebox.Play();
    }
    if (!this.WindowDisplaying)
    {
      if (this.InputManager.TappedDown)
      {
        ++this.ID;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedUp)
      {
        --this.ID;
        this.UpdateHighlight();
      }
      if (!Input.GetButtonDown("A") && !Input.GetKeyDown("z") && !(Input.GetKeyDown("return") | Input.GetKeyDown("space")))
        return;
      if (this.MainMenu.activeInHierarchy)
      {
        if (this.ID == 1)
        {
          if (!this.Eighties)
          {
            this.DifficultySelect.SetActive(true);
            this.MainMenu.SetActive(false);
            this.ID = 2;
            this.UpdateHighlight();
          }
          else
            this.FadeOut = true;
        }
        else if (this.ID == 2)
        {
          if (!this.Eighties)
          {
            this.Highlight.gameObject.SetActive(false);
            this.Controls.SetActive(true);
            this.WindowDisplaying = true;
          }
          else
          {
            this.ID = 4;
            this.FadeOut = true;
          }
        }
        else if (this.ID == 3)
        {
          this.Highlight.gameObject.SetActive(false);
          this.Credits.SetActive(true);
          this.WindowDisplaying = true;
        }
        else
        {
          if (this.ID != 4)
            return;
          this.FadeOut = true;
        }
      }
      else
      {
        GameGlobals.EasyMode = this.ID != 2;
        this.FadeOut = true;
      }
    }
    else
    {
      if (!Input.GetButtonDown("B"))
        return;
      this.Highlight.gameObject.SetActive(true);
      this.Controls.SetActive(false);
      this.Credits.SetActive(false);
      this.WindowDisplaying = false;
    }
  }

  private void UpdateHighlight()
  {
    if (this.MainMenu.activeInHierarchy)
    {
      if (this.ID == 0)
        this.ID = this.MenuLimit;
      else if (this.ID == this.MenuLimit + 1)
        this.ID = 1;
    }
    else if (this.ID == 1)
      this.ID = 3;
    else if (this.ID == 4)
      this.ID = 2;
    this.Highlight.transform.position = new Vector3(0.0f, -0.2f * (float) this.ID, this.Highlight.transform.position.z);
  }
}
