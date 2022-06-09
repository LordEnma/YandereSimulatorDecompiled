// Decompiled with JetBrains decompiler
// Type: ResolutionScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class ResolutionScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public PostProcessingProfile Profile;
  public UILabel ResolutionLabel;
  public UILabel FullScreenLabel;
  public UILabel QualityLabel;
  public Transform Highlight;
  public UISprite Darkness;
  public float Alpha = 1f;
  public bool FullScreen;
  public bool FadeOut;
  public string[] Qualities;
  public int[] Widths;
  public int[] Heights;
  public int QualityID;
  public int ResID = 1;
  public int ID = 1;

  private void Start()
  {
    if (Screen.width < 1280 || Screen.height < 720)
      Screen.SetResolution(1280, 720, false);
    this.Darkness.color = new Color(1f, 1f, 1f, 1f);
    Cursor.visible = false;
    Screen.fullScreen = false;
    Screen.SetResolution(Screen.width, Screen.height, false);
    this.ResolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString();
    this.QualityLabel.text = this.Qualities[QualitySettings.GetQualityLevel()] ?? "";
    this.FullScreenLabel.text = "No";
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
    this.ResetGraphicsToDefault();
  }

  private void Update()
  {
    if (Screen.width < 1280 || Screen.height < 720)
    {
      Screen.SetResolution(1280, 720, false);
      this.ResolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString();
    }
    if (this.FadeOut)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
      if ((double) this.Alpha == 1.0)
        SceneManager.LoadScene("WelcomeScene");
    }
    else
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime);
    this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
    if ((double) this.Alpha == 0.0)
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
      if (this.ID == 1)
      {
        if (this.InputManager.TappedRight)
        {
          ++this.ResID;
          if (this.ResID == this.Widths.Length)
            this.ResID = 0;
          this.UpdateRes();
        }
        else if (this.InputManager.TappedLeft)
        {
          --this.ResID;
          if (this.ResID < 0)
            this.ResID = this.Widths.Length - 1;
          this.UpdateRes();
        }
      }
      else if (this.ID == 2)
      {
        if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
        {
          this.FullScreen = !this.FullScreen;
          this.FullScreenLabel.text = !this.FullScreen ? "No" : "Yes";
          Screen.SetResolution(Screen.width, Screen.height, this.FullScreen);
        }
      }
      else if (this.ID == 3)
      {
        if (this.InputManager.TappedRight)
        {
          ++this.QualityID;
          if (this.QualityID == this.Qualities.Length)
            this.QualityID = 0;
          this.UpdateQuality();
        }
        else if (this.InputManager.TappedLeft)
        {
          --this.QualityID;
          if (this.QualityID < 0)
            this.QualityID = this.Qualities.Length - 1;
          this.UpdateQuality();
        }
      }
      else if (this.ID == 4 && Input.GetButtonUp("A"))
        this.FadeOut = true;
    }
    this.Highlight.localPosition = Vector3.Lerp(this.Highlight.localPosition, new Vector3(-307.5f, (float) (250 - this.ID * 100), 0.0f), Time.deltaTime * 10f);
    if (!Input.GetKeyDown(KeyCode.KeypadEnter))
      return;
    SceneManager.LoadScene("NewTitleScene");
  }

  private void UpdateRes()
  {
    Screen.SetResolution(this.Widths[this.ResID], this.Heights[this.ResID], Screen.fullScreen);
    this.ResolutionLabel.text = this.Widths[this.ResID].ToString() + " x " + this.Heights[this.ResID].ToString();
  }

  private void UpdateQuality()
  {
    QualitySettings.SetQualityLevel(this.QualityID, true);
    this.QualityLabel.text = this.Qualities[this.QualityID] ?? "";
    Debug.Log((object) ("The quality level is set to: " + QualitySettings.GetQualityLevel().ToString()));
  }

  private void UpdateHighlight()
  {
    if (this.ID < 1)
    {
      this.ID = 4;
    }
    else
    {
      if (this.ID <= 4)
        return;
      this.ID = 1;
    }
  }

  private void ResetGraphicsToDefault()
  {
    OptionGlobals.DrawDistance = 350;
    OptionGlobals.DrawDistanceLimit = 350;
    OptionGlobals.DisableStatic = false;
    OptionGlobals.DisableDisplacement = false;
    OptionGlobals.DisableAbberation = false;
    OptionGlobals.DisableVignette = false;
    OptionGlobals.DisableDistortion = false;
    OptionGlobals.DisableNoise = false;
    OptionGlobals.DisableScanlines = true;
    OptionGlobals.OpaqueWindows = false;
    OptionGlobals.MotionBlur = false;
    OptionGlobals.Fog = false;
    GameGlobals.VtuberID = 0;
  }
}
