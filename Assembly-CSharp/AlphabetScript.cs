// Decompiled with JetBrains decompiler
// Type: AlphabetScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public MissionModeScript MissionMode;
  public InventoryScript Inventory;
  public ClassScript Class;
  public GameObject BodyHidingLockers;
  public GameObject AlphabetTools;
  public GameObject Jukebox;
  public GameObject AmnesiaBomb;
  public GameObject SmokeBomb;
  public GameObject StinkBomb;
  public UILabel ChallengeFailed;
  public UILabel DifficultyLabel;
  public UILabel TargetLabel;
  public UILabel BombLabel;
  public AudioSource MusicPlayer;
  public UITexture BombTexture;
  public Transform LocalArrow;
  public Renderer MyRenderer;
  public Transform Yandere;
  public bool AlternateMusic;
  public bool StopMusic;
  public bool Began;
  public int RemainingBombs;
  public int CurrentTarget;
  public int CurrentTrack;
  public int Cheats;
  public int Limit;
  public float LastTime;
  public float Timer;
  public AudioClip[] MusicTracks;
  public string[] DifficultyText;
  public int[] EightiesIDs;
  public int[] IDs;

  private void Start()
  {
    if (GameGlobals.AlphabetMode)
    {
      this.TargetLabel.transform.parent.gameObject.SetActive(true);
      this.StudentManager.Yandere.NoDebug = true;
      this.BodyHidingLockers.SetActive(true);
      this.AlphabetTools.SetActive(true);
      this.Jukebox.SetActive(false);
      this.MyRenderer.enabled = true;
      this.Class.PhysicalGrade = 5;
      this.CurrentTrack = 1;
      this.Limit = 79;
      if (GameGlobals.Eighties)
      {
        this.IDs = this.EightiesIDs;
        this.Limit = 79;
      }
      this.MissionMode.RemoveBoxes();
      this.UpdateText();
      this.UpdateDifficultyLabel();
    }
    else
    {
      this.TargetLabel.transform.parent.gameObject.SetActive(false);
      this.BombLabel.transform.parent.gameObject.SetActive(false);
      this.AlphabetTools.SetActive(false);
      this.gameObject.SetActive(false);
      this.enabled = false;
    }
  }

  private void Update()
  {
    if (!this.Began && this.StudentManager.Yandere.CanMove)
    {
      this.StudentManager.TeleportEveryoneToDestination();
      this.MusicPlayer.Play();
      this.Began = true;
    }
    if (this.CurrentTarget >= this.IDs.Length)
      return;
    if (Input.GetKeyDown("m"))
    {
      if (this.MusicPlayer.isPlaying)
      {
        this.MusicPlayer.Stop();
        this.StopMusic = true;
        this.MusicPlayer.time = 0.0f;
        this.LastTime = 0.0f;
      }
      else
      {
        this.MusicPlayer.clip = this.MusicTracks[this.CurrentTrack];
        this.MusicPlayer.Play();
        this.StopMusic = false;
      }
    }
    if ((double) this.MusicPlayer.time < 600.0 && (double) this.MusicPlayer.time > (double) this.LastTime)
      this.LastTime = this.MusicPlayer.time;
    if (this.Began && !this.MusicPlayer.isPlaying && !this.StopMusic)
    {
      this.MusicPlayer.Play();
      this.MusicPlayer.time = this.LastTime;
    }
    if (this.StudentManager.Yandere.CanMove && (Input.GetButtonDown("LS") || Input.GetKeyDown(KeyCode.T)))
    {
      if (this.StudentManager.Yandere.Inventory.SmokeBomb)
      {
        Object.Instantiate<GameObject>(this.SmokeBomb, this.Yandere.position, Quaternion.identity);
        --this.RemainingBombs;
        this.BombLabel.text = this.RemainingBombs.ToString() ?? "";
        if (this.RemainingBombs == 0)
          this.StudentManager.Yandere.Inventory.SmokeBomb = false;
      }
      else if (this.StudentManager.Yandere.Inventory.StinkBomb)
      {
        Object.Instantiate<GameObject>(this.StinkBomb, this.Yandere.position, Quaternion.identity);
        --this.RemainingBombs;
        this.BombLabel.text = this.RemainingBombs.ToString() ?? "";
        if (this.RemainingBombs == 0)
          this.StudentManager.Yandere.Inventory.StinkBomb = false;
      }
      else if (this.StudentManager.Yandere.Inventory.AmnesiaBomb)
      {
        Object.Instantiate<GameObject>(this.AmnesiaBomb, this.Yandere.position, Quaternion.identity);
        --this.RemainingBombs;
        this.BombLabel.text = this.RemainingBombs.ToString() ?? "";
        if (this.RemainingBombs == 0)
          this.StudentManager.Yandere.Inventory.AmnesiaBomb = false;
      }
    }
    this.LocalArrow.LookAt(this.StudentManager.Students[this.IDs[this.CurrentTarget]].transform.position);
    this.transform.eulerAngles = this.LocalArrow.eulerAngles - new Vector3(0.0f, this.StudentManager.MainCamera.transform.eulerAngles.y, 0.0f);
    if (this.StudentManager.Yandere.Attacking && this.StudentManager.Yandere.TargetStudent.StudentID != this.IDs[this.CurrentTarget] || this.StudentManager.Yandere.Struggling && this.StudentManager.Yandere.TargetStudent.StudentID != this.IDs[this.CurrentTarget] || this.StudentManager.Police.Show || this.StudentManager.Yandere.Noticed)
      this.ChallengeFailed.enabled = true;
    for (int index = this.CurrentTarget + 1; index < this.IDs.Length; ++index)
    {
      if (!this.StudentManager.Students[this.IDs[index]].gameObject.activeInHierarchy || !this.StudentManager.Students[this.IDs[index]].Alive)
        this.ChallengeFailed.enabled = true;
    }
    if (!this.StudentManager.Students[this.IDs[this.CurrentTarget]].Alive)
    {
      ++this.CurrentTarget;
      if (this.CurrentTarget > this.Limit)
      {
        this.TargetLabel.text = "Challenge Complete!";
        SceneManager.LoadScene("OsanaJokeScene");
      }
      else
        this.UpdateText();
    }
    if (!this.ChallengeFailed.enabled)
      return;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 5.0)
      return;
    SceneManager.LoadScene("LoadingScene");
  }

  public void UpdateText()
  {
    this.TargetLabel.text = "(" + this.CurrentTarget.ToString() + "/" + this.Limit.ToString() + ") Current Target: " + this.StudentManager.JSON.Students[this.IDs[this.CurrentTarget]].Name;
    if (this.RemainingBombs <= 0)
      return;
    this.BombLabel.transform.parent.gameObject.SetActive(true);
    if ((double) this.BombTexture.color.a >= 1.0)
      return;
    if (this.Inventory.StinkBomb)
      this.BombTexture.color = new Color(0.0f, 0.5f, 0.0f, 1f);
    else if (this.Inventory.AmnesiaBomb)
      this.BombTexture.color = new Color(1f, 0.5f, 1f, 1f);
    else
      this.BombTexture.color = new Color(0.5f, 0.5f, 0.5f, 1f);
  }

  public void UpdateDifficultyLabel() => this.DifficultyLabel.text = "Difficulty: " + this.DifficultyText[this.Cheats];
}
