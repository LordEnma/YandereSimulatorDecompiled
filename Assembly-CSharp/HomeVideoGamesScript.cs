// Decompiled with JetBrains decompiler
// Type: HomeVideoGamesScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeVideoGamesScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public HomeDarknessScript HomeDarkness;
  public HomeYandereScript HomeYandere;
  public HomeCameraScript HomeCamera;
  public HomeWindowScript HomeWindow;
  public PromptBarScript PromptBar;
  public Texture[] TitleScreens;
  public UITexture TitleScreen;
  public Transform Highlight;
  public UILabel[] GameTitles;
  public Transform TV;
  public int ID = 1;
  public GameObject EightiesController;
  public GameObject Controller;
  public Vector3 OriginalPosition;

  private void Start()
  {
    this.OriginalPosition = this.Controller.transform.position;
    if (GameGlobals.Eighties)
    {
      this.GameTitles[2].text = "Space Witch";
      this.GameTitles[1].text = "??????????";
      this.GameTitles[1].color = new Color(1f, 1f, 1f, 0.5f);
    }
    else if (TaskGlobals.GetTaskStatus(38) == 0)
    {
      this.TitleScreens[1] = this.TitleScreens[5];
      UILabel gameTitle = this.GameTitles[1];
      gameTitle.text = this.GameTitles[5].text;
      gameTitle.color = new Color(gameTitle.color.r, gameTitle.color.g, gameTitle.color.b, 0.5f);
    }
    this.TitleScreen.mainTexture = this.TitleScreens[1];
  }

  private void Update()
  {
    if ((Object) this.HomeCamera.Destination == (Object) this.HomeCamera.Destinations[5])
    {
      if (Input.GetKeyDown("y"))
      {
        TaskGlobals.SetTaskStatus(38, 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
      this.TV.localScale = Vector3.Lerp(this.TV.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (this.HomeYandere.CanMove)
        return;
      if (!this.HomeDarkness.FadeOut)
      {
        if (this.InputManager.TappedDown)
        {
          ++this.ID;
          if (this.ID > 5)
            this.ID = 1;
          this.TitleScreen.mainTexture = this.TitleScreens[this.ID];
          this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (150.0 - (double) this.ID * 50.0), this.Highlight.localPosition.z);
        }
        if (this.InputManager.TappedUp)
        {
          --this.ID;
          if (this.ID < 1)
            this.ID = 5;
          this.TitleScreen.mainTexture = this.TitleScreens[this.ID];
          this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (150.0 - (double) this.ID * 50.0), this.Highlight.localPosition.z);
        }
        if (Input.GetButtonDown("A") && (double) this.GameTitles[this.ID].color.a == 1.0)
        {
          Transform target = this.HomeCamera.Targets[5];
          target.localPosition = this.HomeCamera.Eighties ? new Vector3(target.localPosition.x, 0.948f, target.localPosition.z) : new Vector3(target.localPosition.x, 1.128f, target.localPosition.z);
          this.HomeDarkness.Sprite.color = new Color(this.HomeDarkness.Sprite.color.r, this.HomeDarkness.Sprite.color.g, this.HomeDarkness.Sprite.color.b, -1f);
          this.HomeDarkness.FadeOut = true;
          this.HomeWindow.Show = false;
          this.PromptBar.Show = false;
          this.HomeCamera.ID = 5;
        }
        if (!Input.GetButtonDown("B"))
          return;
        this.Quit();
      }
      else
      {
        Transform destination = this.HomeCamera.Destinations[5];
        Transform target = this.HomeCamera.Targets[5];
        destination.position = new Vector3(Mathf.Lerp(destination.position.x, target.position.x, Time.deltaTime * 0.75f), Mathf.Lerp(destination.position.y, target.position.y, Time.deltaTime * 10f), Mathf.Lerp(destination.position.z, target.position.z, Time.deltaTime * 10f));
      }
    }
    else
      this.TV.localScale = Vector3.Lerp(this.TV.localScale, Vector3.zero, Time.deltaTime * 10f);
  }

  public void Quit()
  {
    if (!this.HomeCamera.Eighties)
    {
      this.Controller.transform.position = this.OriginalPosition;
      this.Controller.transform.localEulerAngles = new Vector3(-90f, -90f, 0.0f);
    }
    else
      this.EightiesController.transform.localPosition = new Vector3(-0.08163334f, -0.1855f, -0.02433333f);
    this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
    this.HomeCamera.Target = this.HomeCamera.Targets[0];
    this.HomeYandere.CanMove = true;
    this.HomeYandere.enabled = true;
    this.HomeWindow.Show = false;
    this.HomeCamera.PlayMusic();
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
  }
}
