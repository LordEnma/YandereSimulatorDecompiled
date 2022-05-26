// Decompiled with JetBrains decompiler
// Type: FunScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunScript : MonoBehaviour
{
  public TypewriterEffect Typewriter;
  public GameObject Controls;
  public GameObject Skip;
  public Texture[] Portraits;
  public string[] Lines;
  public UITexture Girl;
  public UILabel Label;
  public float OutroTimer;
  public float Timer;
  public int DebugNumber;
  public int ID;
  public bool VeryFun;
  public float R = 1f;
  public float G = 1f;
  public float B = 1f;
  public string Text;

  private void Start()
  {
    if (PlayerPrefs.GetInt("DebugNumber") > 0)
    {
      if (PlayerPrefs.GetInt("DebugNumber") > 10)
        PlayerPrefs.SetInt("DebugNumber", 0);
      this.DebugNumber = PlayerPrefs.GetInt("DebugNumber");
    }
    if (this.VeryFun)
    {
      this.Text = this.DebugNumber == -1 ? File.ReadAllText(Application.streamingAssetsPath + "/Fun.txt") : this.DebugNumber.ToString() ?? "";
      if (this.Text == "0")
        this.ID = 0;
      else if (this.Text == "1")
        this.ID = 1;
      else if (this.Text == "2")
        this.ID = 2;
      else if (this.Text == "3")
        this.ID = 3;
      else if (this.Text == "4")
        this.ID = 4;
      else if (this.Text == "5")
        this.ID = 5;
      else if (this.Text == "6")
        this.ID = 6;
      else if (this.Text == "7")
        this.ID = 7;
      else if (this.Text == "8")
        this.ID = 8;
      else if (this.Text == "9")
        this.ID = 9;
      else if (this.Text == "10")
        this.ID = 10;
      else if (this.Text == "69")
      {
        this.Label.text = "( ͡° ͜ʖ ͡°) ";
        this.ID = 8;
      }
      else if (this.Text == "666")
      {
        this.Label.text = "Sometimes, I lie. It's just too fun. You eat up everything I say. I wonder what else I can trick you into believing? ";
        this.Girl.color = new Color(1f, 0.0f, 0.0f, 0.0f);
        this.Label.color = new Color(1f, 0.0f, 0.0f, 1f);
        this.ID = 5;
      }
      else
      {
        Debug.Log((object) "Booting the player back to the WelcomeScene.");
        Application.LoadLevel("WelcomeScene");
      }
    }
    if (this.Text != "666" && this.Text != "69")
      this.Label.text = this.Lines[this.ID];
    if (SceneManager.GetActiveScene().name == "VeryFunScene" || this.Text == "666")
    {
      this.G = 0.0f;
      this.B = 0.0f;
      this.Label.color = new Color(this.R, this.G, this.B, 1f);
      this.Skip.SetActive(false);
    }
    this.Skip.SetActive(false);
    this.Controls.SetActive(false);
    this.Label.gameObject.SetActive(false);
    this.Girl.color = new Color(this.R, this.G, this.B, 0.0f);
  }

  private void Update()
  {
    if (Input.GetKeyDown(",") && PlayerPrefs.GetInt("DebugNumber") > 0)
    {
      PlayerPrefs.SetInt("DebugNumber", PlayerPrefs.GetInt("DebugNumber") - 1);
      Application.LoadLevel(Application.loadedLevel);
    }
    if (Input.GetKeyDown(".") && PlayerPrefs.GetInt("DebugNumber") < 10)
    {
      PlayerPrefs.SetInt("DebugNumber", PlayerPrefs.GetInt("DebugNumber") + 1);
      Application.LoadLevel(Application.loadedLevel);
    }
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > 3.0)
    {
      if (!this.Typewriter.mActive)
        this.Controls.SetActive(true);
    }
    else if ((double) this.Timer > 2.0)
    {
      this.Girl.mainTexture = this.Portraits[this.ID];
      this.Label.gameObject.SetActive(true);
    }
    else if ((double) this.Timer > 1.0)
      this.Girl.color = new Color(this.R, this.G, this.B, Mathf.MoveTowards(this.Girl.color.a, 1f, Time.deltaTime));
    if (!this.Controls.activeInHierarchy)
      return;
    if (Input.GetButtonDown("B"))
    {
      if (!this.Skip.activeInHierarchy)
        return;
      this.ID = 19;
      this.Skip.SetActive(false);
      this.Girl.mainTexture = this.Portraits[this.ID];
      this.Typewriter.ResetToBeginning();
      this.Typewriter.mFullText = this.Lines[this.ID];
    }
    else
    {
      if (!Input.GetButtonDown("A"))
        return;
      if (this.ID < this.Lines.Length - 1 && !this.VeryFun)
      {
        if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
        {
          this.Typewriter.Finish();
        }
        else
        {
          ++this.ID;
          if (this.ID == 19)
            this.Skip.SetActive(false);
          this.Girl.mainTexture = this.Portraits[this.ID];
          this.Typewriter.ResetToBeginning();
          this.Typewriter.mFullText = this.Lines[this.ID];
        }
      }
      else
        Application.Quit();
    }
  }
}
