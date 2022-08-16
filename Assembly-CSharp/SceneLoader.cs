// Decompiled with JetBrains decompiler
// Type: SceneLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public PostProcessingProfile Profile;
  [SerializeField]
  private UILabel patienceText;
  [SerializeField]
  private UILabel loadingText;
  [SerializeField]
  private UILabel crashText;
  private float timer;
  public UILabel[] ControllerText;
  public UILabel[] KeyboardText;
  public GameObject LightAnimation;
  public GameObject DarkAnimation;
  public GameObject LightAnimation1989;
  public GameObject DarkAnimation1989;
  public GameObject Keyboard;
  public GameObject Gamepad;
  public UITexture ControllerLines;
  public UITexture KeyboardGraphic;
  public bool Debugging;
  public float Timer;

  private void Start()
  {
    if (OptionGlobals.DrawDistanceLimit == 0)
    {
      OptionGlobals.DrawDistance = 350;
      OptionGlobals.DrawDistanceLimit = 350;
    }
    if (PlayerPrefs.GetInt("LoadingSave") == 1)
    {
      int profile = GameGlobals.Profile;
      int num = PlayerPrefs.GetInt("SaveSlot");
      YanSave.LoadData("Profile_" + profile.ToString() + "_Slot_" + num.ToString());
    }
    Application.runInBackground = true;
    Time.timeScale = 1f;
    if (!SchoolGlobals.SchoolAtmosphereSet)
    {
      SchoolGlobals.SchoolAtmosphereSet = true;
      SchoolGlobals.PreviousSchoolAtmosphere = 1f;
      SchoolGlobals.SchoolAtmosphere = 1f;
      PlayerGlobals.SetCannotBringItem(4, true);
      PlayerGlobals.SetCannotBringItem(5, true);
      PlayerGlobals.SetCannotBringItem(6, true);
      PlayerGlobals.SetCannotBringItem(7, true);
      PlayerGlobals.Money = 10f;
    }
    if (GameGlobals.Eighties)
    {
      this.LightAnimation.SetActive(false);
      this.LightAnimation1989.SetActive(true);
    }
    if ((double) SchoolGlobals.SchoolAtmosphere < 0.5 || GameGlobals.LoveSick)
    {
      Camera.main.backgroundColor = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.patienceText.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.loadingText.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.crashText.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.KeyboardGraphic.color = new Color(1f, 0.0f, 0.0f, 1f);
      this.ControllerLines.color = new Color(1f, 0.0f, 0.0f, 1f);
      if (GameGlobals.Eighties)
      {
        this.LightAnimation1989.SetActive(false);
        this.DarkAnimation1989.SetActive(true);
      }
      else
      {
        this.LightAnimation.SetActive(false);
        this.DarkAnimation.SetActive(true);
      }
      for (int index = 1; index < this.ControllerText.Length; ++index)
        this.ControllerText[index].color = new Color(1f, 0.0f, 0.0f, 1f);
      for (int index = 1; index < this.KeyboardText.Length; ++index)
        this.KeyboardText[index].color = new Color(1f, 0.0f, 0.0f, 1f);
    }
    if (PlayerGlobals.UsingGamepad)
    {
      this.Keyboard.SetActive(false);
      this.Gamepad.SetActive(true);
    }
    else
    {
      this.Keyboard.SetActive(true);
      this.Gamepad.SetActive(false);
    }
    this.Debugging = false;
  }

  private void Update()
  {
    if ((double) this.Timer == 1.0)
      this.StartCoroutine(this.LoadNewScene());
    ++this.Timer;
    if (!Input.GetKeyDown("a"))
      return;
    SchoolGlobals.SchoolAtmosphere = (double) SchoolGlobals.SchoolAtmosphere <= 0.0 ? 1f : 0.0f;
    SceneManager.LoadScene("LoadingScene");
  }

  private IEnumerator LoadNewScene()
  {
    AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
    while (!async.isDone)
      yield return (object) null;
  }
}
