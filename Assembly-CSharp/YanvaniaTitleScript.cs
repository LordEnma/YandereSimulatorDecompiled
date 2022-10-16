// Decompiled with JetBrains decompiler
// Type: YanvaniaTitleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class YanvaniaTitleScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public GameObject ButtonEffect;
  public GameObject ErrorWindow;
  public GameObject SkipButton;
  public Transform Highlight;
  public Transform Prologue;
  public UIPanel Controls;
  public UIPanel Credits;
  public UIPanel Buttons;
  public UISprite Darkness;
  public UITexture Midori;
  public UITexture Logo;
  public AudioClip SelectSound;
  public AudioClip ExitSound;
  public AudioClip BGM;
  public Transform[] BackButtons;
  public Texture SadMidori;
  public bool FadeButtons;
  public bool ErrorLeave;
  public bool FadeOut;
  public float ScrollSpeed;
  public int Selected = 1;

  private void Start()
  {
    this.Midori.transform.localPosition = new Vector3(1540f, 0.0f, 0.0f);
    this.Midori.transform.localEulerAngles = Vector3.zero;
    this.Midori.gameObject.SetActive(false);
    if (YanvaniaGlobals.DraculaDefeated)
    {
      TaskGlobals.SetTaskStatus(38, 2);
      this.SkipButton.SetActive(true);
      this.Logo.gameObject.SetActive(false);
    }
    else
      this.SkipButton.SetActive(false);
    this.Prologue.gameObject.SetActive(false);
    this.Prologue.localPosition = new Vector3(this.Prologue.localPosition.x, -2665f, this.Prologue.localPosition.z);
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
    this.Buttons.alpha = 0.0f;
    this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 0.0f);
  }

  private void Update()
  {
    if (!this.Logo.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.M))
    {
      YanvaniaGlobals.DraculaDefeated = true;
      YanvaniaGlobals.MidoriEasterEgg = true;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    Scene activeScene;
    if (Input.GetKeyDown(KeyCode.End))
    {
      YanvaniaGlobals.DraculaDefeated = true;
      activeScene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(activeScene.name);
    }
    if (Input.GetKeyDown(KeyCode.BackQuote))
    {
      YanvaniaGlobals.DraculaDefeated = false;
      activeScene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(activeScene.name);
    }
    AudioSource component1 = this.GetComponent<AudioSource>();
    if (!this.FadeOut)
    {
      if ((double) this.Darkness.color.a > 0.0)
      {
        if (Input.GetButtonDown("A"))
          this.Skip();
        if (this.ErrorWindow.activeInHierarchy)
          return;
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
      }
      else
      {
        if ((double) this.Darkness.color.a > 0.0)
          return;
        if (!YanvaniaGlobals.MidoriEasterEgg)
        {
          if (YanvaniaGlobals.DraculaDefeated)
          {
            if (!this.Prologue.gameObject.activeInHierarchy)
            {
              this.Prologue.gameObject.SetActive(true);
              component1.volume = 0.5f;
              component1.loop = true;
              component1.clip = this.BGM;
              component1.Play();
            }
            if (Input.GetButtonDown("B"))
            {
              this.Prologue.localPosition = new Vector3(this.Prologue.localPosition.x, 2501f, this.Prologue.localPosition.z);
              this.Prologue.GetComponent<AudioSource>().Stop();
            }
            if ((double) this.Prologue.localPosition.y > 2500.0)
            {
              if (component1.isPlaying)
              {
                this.Midori.mainTexture = this.SadMidori;
                Time.timeScale = 1f;
                this.Midori.gameObject.GetComponent<AudioSource>().Stop();
                component1.Stop();
              }
              if (!this.ErrorLeave)
              {
                this.ErrorWindow.SetActive(true);
                this.ErrorWindow.transform.localScale = Vector3.Lerp(this.ErrorWindow.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
                if ((double) this.ErrorWindow.transform.localScale.x <= 0.89999997615814209 || !Input.anyKeyDown)
                  return;
                AudioSource component2 = this.ErrorWindow.GetComponent<AudioSource>();
                component2.clip = this.ExitSound;
                component2.Play();
                this.ErrorLeave = true;
              }
              else
                this.FadeOut = true;
            }
            else
            {
              this.Prologue.localPosition = new Vector3(this.Prologue.localPosition.x, this.Prologue.localPosition.y + Time.deltaTime * this.ScrollSpeed, this.Prologue.localPosition.z);
              if (Input.GetKeyDown(KeyCode.Equals))
                Time.timeScale = 100f;
              if (!Input.GetKeyDown(KeyCode.Minus))
                return;
              Time.timeScale = 1f;
            }
          }
          else if (!component1.isPlaying)
          {
            if ((double) this.Logo.color.a == 0.0)
            {
              component1.Play();
            }
            else
            {
              component1.loop = true;
              component1.clip = this.BGM;
              component1.Play();
            }
          }
          else if ((Object) component1.clip != (Object) this.BGM)
          {
            this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, this.Logo.color.a + Time.deltaTime);
            if (!Input.GetButtonDown("A"))
              return;
            this.Skip();
          }
          else if (!this.FadeButtons)
          {
            this.Controls.alpha = Mathf.MoveTowards(this.Controls.alpha, 0.0f, Time.deltaTime);
            this.Credits.alpha = Mathf.MoveTowards(this.Credits.alpha, 0.0f, Time.deltaTime);
            if ((double) this.Controls.alpha != 0.0 || (double) this.Credits.alpha != 0.0)
              return;
            this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (-100.0 - 100.0 * (double) this.Selected), this.Highlight.localPosition.z);
            this.Buttons.alpha += Time.deltaTime;
            if ((double) this.Buttons.alpha < 1.0)
              return;
            if (Input.GetButtonDown("A"))
            {
              Object.Instantiate<GameObject>(this.ButtonEffect, this.Highlight.position, Quaternion.identity);
              if (this.Selected == 1 || this.Selected == 4)
                this.FadeOut = true;
              if (this.Selected == 2 || this.Selected == 3)
                this.FadeButtons = true;
            }
            AudioSource component3 = this.Highlight.gameObject.GetComponent<AudioSource>();
            if (this.InputManager.TappedUp)
            {
              component3.Play();
              --this.Selected;
              if (this.Selected < 1)
                this.Selected = 4;
            }
            if (!this.InputManager.TappedDown)
              return;
            component3.Play();
            ++this.Selected;
            if (this.Selected <= 4)
              return;
            this.Selected = 1;
          }
          else
          {
            this.Buttons.alpha -= Time.deltaTime;
            if ((double) this.Buttons.alpha == 0.0)
            {
              if (this.Selected == 2)
                this.Controls.alpha = Mathf.MoveTowards(this.Controls.alpha, 1f, Time.deltaTime);
              else
                this.Credits.alpha = Mathf.MoveTowards(this.Credits.alpha, 1f, Time.deltaTime);
            }
            if ((double) this.Controls.alpha != 1.0 && (double) this.Credits.alpha != 1.0 || !Input.GetButtonDown("B"))
              return;
            Object.Instantiate<GameObject>(this.ButtonEffect, this.BackButtons[this.Selected].position, Quaternion.identity);
            this.FadeButtons = false;
          }
        }
        else
        {
          this.Prologue.GetComponent<AudioSource>().enabled = false;
          this.Midori.gameObject.SetActive(true);
          this.ScrollSpeed = 60f;
          this.Midori.transform.localPosition = new Vector3(Mathf.Lerp(this.Midori.transform.localPosition.x, 875f, Time.deltaTime * 2f), this.Midori.transform.localPosition.y, this.Midori.transform.localPosition.z);
          this.Midori.transform.localEulerAngles = new Vector3(this.Midori.transform.localEulerAngles.x, this.Midori.transform.localEulerAngles.y, Mathf.Lerp(this.Midori.transform.localEulerAngles.z, 45f, Time.deltaTime * 2f));
          if ((double) this.Midori.gameObject.GetComponent<AudioSource>().time <= 3.0)
            return;
          YanvaniaGlobals.MidoriEasterEgg = false;
        }
      }
    }
    else
    {
      this.ErrorWindow.transform.localScale = Vector3.Lerp(this.ErrorWindow.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
      component1.volume -= Time.deltaTime;
      if ((double) this.Darkness.color.a < 1.0)
        return;
      if (YanvaniaGlobals.DraculaDefeated)
        SceneManager.LoadScene("HomeScene");
      else if (this.Selected == 1)
        SceneManager.LoadScene("YanvaniaScene");
      else
        SceneManager.LoadScene("HomeScene");
    }
  }

  private void Skip()
  {
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0.0f);
    this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 1f);
    AudioSource component = this.GetComponent<AudioSource>();
    component.loop = true;
    component.clip = this.BGM;
    component.Play();
  }
}
