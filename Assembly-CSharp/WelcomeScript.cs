// Decompiled with JetBrains decompiler
// Type: WelcomeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScript : MonoBehaviour
{
  public JsonScript JSON;
  public GameObject WelcomePanel;
  public UILabel[] FlashingLabels;
  public UILabel AltBeginLabel;
  public UILabel BeginLabel;
  public UILabel[] Labels;
  public UISprite Darkness;
  public bool Continue;
  public bool FlashRed;
  public float VersionNumber;
  public float Timer;
  public float Speed = 1f;
  public string Text;
  public int CurrentLabel = 1;
  public int ID;

  private void Start()
  {
    Time.timeScale = 1f;
    for (this.ID = 0; this.ID < this.Labels.Length; ++this.ID)
      this.Labels[this.ID].color = new Color(this.Labels[this.ID].color.r, this.Labels[this.ID].color.g, this.Labels[this.ID].color.b, 0.0f);
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    if ((double) ApplicationGlobals.VersionNumber != (double) this.VersionNumber)
      ApplicationGlobals.VersionNumber = this.VersionNumber;
    if (!Application.CanStreamedLevelBeLoaded("FunScene"))
      Application.Quit();
    if (File.Exists(Application.streamingAssetsPath + "/Fun.txt"))
      this.Text = File.ReadAllText(Application.streamingAssetsPath + "/Fun.txt");
    if (!(this.Text == "0") && !(this.Text == "1") && !(this.Text == "2") && !(this.Text == "3") && !(this.Text == "4") && !(this.Text == "5") && !(this.Text == "6") && !(this.Text == "7") && !(this.Text == "8") && !(this.Text == "9") && !(this.Text == "10") && !(this.Text == "69") && !(this.Text == "666"))
      return;
    SceneManager.LoadScene("VeryFunScene");
  }

  private void Update()
  {
    Input.GetKeyDown(KeyCode.S);
    Input.GetKeyDown(KeyCode.Y);
    if (!this.Continue)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
      if ((double) this.Darkness.color.a > 0.0)
        return;
      Input.GetKeyDown(KeyCode.W);
      if (Input.anyKeyDown)
        ++this.Speed;
      if (this.CurrentLabel < this.Labels.Length)
      {
        this.Labels[this.CurrentLabel].color = new Color(this.Labels[this.CurrentLabel].color.r, this.Labels[this.CurrentLabel].color.g, this.Labels[this.CurrentLabel].color.b, this.Labels[this.CurrentLabel].color.a + Time.deltaTime * this.Speed);
        if ((double) this.Labels[this.CurrentLabel].color.a < 1.0)
          return;
        ++this.CurrentLabel;
      }
      else
      {
        if (!Input.anyKeyDown)
          return;
        this.Darkness.color = new Color(1f, 1f, 1f, 0.0f);
        this.Continue = true;
      }
    }
    else
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
      if ((double) this.Darkness.color.a < 1.0)
        return;
      SceneManager.LoadScene("SponsorScene");
    }
  }
}
