// Decompiled with JetBrains decompiler
// Type: PracticeWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeWindowScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public DialogueWheelScript DialogueWheel;
  public InputManagerScript InputManager;
  public StudentScript SparringPartner;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public WeaponScript Baton;
  public UnityEngine.Texture[] DelinquentDificultyIcons;
  public UnityEngine.Texture[] AlbumCovers;
  public Transform[] KneelSpot;
  public Transform[] SparSpot;
  public string[] Difficulties;
  public UITexture[] Texture;
  public UILabel[] Label;
  public Transform Highlight;
  public GameObject Window;
  public UISprite Darkness;
  public int Selected;
  public int ClubID;
  public int ID = 1;
  public ClubType Club;
  public bool PlayedRhythmMinigame;
  public bool DefeatedSho;
  public bool ButtonUp;
  public bool FadeOut;
  public bool FadeIn;
  public float Timer;

  private void Start() => this.Window.SetActive(false);

  private void Update()
  {
    if (this.Window.activeInHierarchy)
    {
      if (this.InputManager.TappedUp)
      {
        --this.Selected;
        this.UpdateHighlight();
      }
      else if (this.InputManager.TappedDown)
      {
        ++this.Selected;
        this.UpdateHighlight();
      }
      if (this.ButtonUp)
      {
        if (Input.GetButtonDown("A"))
        {
          this.UpdateWindow();
          if ((double) this.Texture[this.Selected].color.r == 1.0)
          {
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
            this.Yandere.TargetStudent.TalkTimer = 100f;
            this.Yandere.TargetStudent.ClubPhase = 2;
            if (this.Club == ClubType.MartialArts)
              this.StudentManager.Students[this.ClubID - this.Selected].Distracted = true;
            this.PromptBar.ClearButtons();
            this.PromptBar.Show = false;
            this.Window.SetActive(false);
            this.ButtonUp = false;
          }
        }
        else if (Input.GetButtonDown("B"))
        {
          this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
          this.Yandere.TargetStudent.TalkTimer = 100f;
          this.Yandere.TargetStudent.ClubPhase = 3;
          this.PromptBar.ClearButtons();
          this.PromptBar.Show = false;
          this.Window.SetActive(false);
          this.ButtonUp = false;
        }
      }
      else if (Input.GetButtonUp("A"))
        this.ButtonUp = true;
    }
    if (this.FadeOut)
    {
      this.Darkness.enabled = true;
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a == 1.0)
      {
        if (this.DialogueWheel.ClubLeader)
          this.DialogueWheel.End();
        if (this.Club == ClubType.LightMusic)
        {
          if (!this.PlayedRhythmMinigame)
          {
            for (int index = 52; index < 56; ++index)
            {
              this.StudentManager.Students[index].transform.position = this.StudentManager.Clubs.List[index].position;
              this.StudentManager.Students[index].EmptyHands();
            }
            Physics.SyncTransforms();
            PlayerPrefs.SetFloat("TempReputation", this.StudentManager.Reputation.Reputation);
            this.PlayedRhythmMinigame = true;
            this.FadeOut = false;
            this.FadeIn = true;
            SceneManager.LoadScene("RhythmMinigameScene", LoadSceneMode.Additive);
            foreach (GameObject rootGameObject in SceneManager.GetActiveScene().GetRootGameObjects())
              rootGameObject.SetActive(false);
          }
        }
        else if (this.Club == ClubType.MartialArts)
        {
          if (this.Yandere.CanMove)
          {
            this.StudentManager.CombatMinigame.Practice = true;
            this.StudentManager.Students[46].CharacterAnimation.CrossFade(this.StudentManager.Students[46].IdleAnim);
            this.StudentManager.Students[46].transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.StudentManager.Students[46].transform.position = this.KneelSpot[0].position;
            this.StudentManager.Students[46].Pathfinding.canSearch = false;
            this.StudentManager.Students[46].Pathfinding.canMove = false;
            this.StudentManager.Students[46].Distracted = true;
            this.StudentManager.Students[46].enabled = false;
            this.StudentManager.Students[46].Routine = false;
            this.StudentManager.Students[46].Hearts.Stop();
            for (int index = 1; index < 5; ++index)
            {
              if ((Object) this.StudentManager.Students[46 + index] != (Object) null && this.StudentManager.Students[46 + index].Alive && this.StudentManager.Students[46 + index].Routine && this.StudentManager.Students[46 + index].Alive && this.StudentManager.Students[46 + index].ClubAttire)
              {
                this.StudentManager.Students[46 + index].transform.position = this.KneelSpot[index].position;
                this.StudentManager.Students[46 + index].transform.eulerAngles = this.KneelSpot[index].eulerAngles;
                this.StudentManager.Students[46 + index].Pathfinding.canSearch = false;
                this.StudentManager.Students[46 + index].Pathfinding.canMove = false;
                this.StudentManager.Students[46 + index].Distracted = true;
                this.StudentManager.Students[46 + index].enabled = false;
                this.StudentManager.Students[46 + index].Routine = false;
                if (this.StudentManager.Students[46 + index].Male)
                  this.StudentManager.Students[46 + index].CharacterAnimation.CrossFade("sit_04");
                else
                  this.StudentManager.Students[46 + index].CharacterAnimation.CrossFade("f02_sit_05");
              }
            }
            this.Yandere.transform.eulerAngles = this.SparSpot[1].eulerAngles;
            this.Yandere.transform.position = this.SparSpot[1].position;
            this.Yandere.CanMove = false;
            this.SparringPartner = this.StudentManager.Students[this.ClubID - this.Selected];
            this.SparringPartner.CharacterAnimation.CrossFade(this.SparringPartner.IdleAnim);
            this.SparringPartner.transform.eulerAngles = this.SparSpot[2].eulerAngles;
            this.SparringPartner.transform.position = this.SparSpot[2].position;
            this.SparringPartner.MyWeapon = this.Baton;
            this.SparringPartner.MyWeapon.transform.parent = this.SparringPartner.WeaponBagParent;
            this.SparringPartner.MyWeapon.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.SparringPartner.MyWeapon.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            this.SparringPartner.MyWeapon.GetComponent<Rigidbody>().useGravity = false;
            this.SparringPartner.MyWeapon.FingerprintID = this.SparringPartner.StudentID;
            this.SparringPartner.MyWeapon.MyCollider.enabled = false;
            Physics.SyncTransforms();
            this.FadeOut = false;
            this.FadeIn = true;
          }
        }
        else if (this.Club == ClubType.Delinquent)
        {
          GameGlobals.BeatEmUpDifficulty = this.Selected;
          this.FadeOut = false;
          this.FadeIn = true;
          SceneManager.LoadScene("BeatEmUpScene", LoadSceneMode.Additive);
          foreach (GameObject rootGameObject in SceneManager.GetActiveScene().GetRootGameObjects())
            rootGameObject.SetActive(false);
        }
      }
    }
    if (!this.FadeIn)
      return;
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
    if ((double) this.Darkness.color.a != 0.0)
      return;
    if (this.Club == ClubType.LightMusic)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      this.Yandere.SetAnimationLayers();
      this.StudentManager.UpdateAllAnimLayers();
      this.StudentManager.Reputation.PendingRep += PlayerPrefs.GetFloat("TempReputation");
      PlayerPrefs.SetFloat("TempReputation", 0.0f);
      this.FadeIn = false;
      this.Timer = 0.0f;
    }
    else if (this.Club == ClubType.MartialArts)
    {
      this.SparringPartner.Pathfinding.canSearch = false;
      this.SparringPartner.Pathfinding.canMove = false;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      if (this.Selected == 1)
        this.StudentManager.CombatMinigame.Difficulty = 0.5f;
      else if (this.Selected == 2)
        this.StudentManager.CombatMinigame.Difficulty = 0.75f;
      else if (this.Selected == 3)
        this.StudentManager.CombatMinigame.Difficulty = 1f;
      else if (this.Selected == 4)
        this.StudentManager.CombatMinigame.Difficulty = 1.5f;
      else if (this.Selected == 5)
        this.StudentManager.CombatMinigame.Difficulty = 2f;
      this.StudentManager.Students[this.ClubID - this.Selected].Threatened = true;
      this.StudentManager.Students[this.ClubID - this.Selected].Alarmed = true;
      this.StudentManager.Students[this.ClubID - this.Selected].enabled = true;
      this.FadeIn = false;
      this.Timer = 0.0f;
    }
    else
    {
      if (this.Club != ClubType.Delinquent)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      Debug.Log((object) "We just returned from the delinquent minigame.");
      this.Yandere.SetAnimationLayers();
      this.StudentManager.UpdateAllAnimLayers();
      this.FadeIn = false;
      this.Timer = 0.0f;
    }
  }

  public void Finish()
  {
    for (int index = 1; index < 6; ++index)
    {
      if ((Object) this.StudentManager.Students[45 + index] != (Object) null && this.StudentManager.Students[45 + index].Alive)
      {
        this.StudentManager.Students[45 + index].Pathfinding.canSearch = true;
        this.StudentManager.Students[45 + index].Pathfinding.canMove = true;
        this.StudentManager.Students[45 + index].Distracted = false;
        this.StudentManager.Students[45 + index].enabled = true;
        this.StudentManager.Students[45 + index].Routine = true;
      }
    }
    this.Yandere.StudentManager.QualityManager.UpdateFPSIndex();
  }

  public void UpdateWindow()
  {
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Confirm";
    this.PromptBar.Label[1].text = "Back";
    this.PromptBar.Label[4].text = "Choose";
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
    if (this.Club == ClubType.LightMusic)
    {
      this.Texture[1].mainTexture = this.AlbumCovers[1];
      this.Texture[2].mainTexture = this.AlbumCovers[2];
      this.Texture[3].mainTexture = this.AlbumCovers[3];
      this.Texture[4].mainTexture = this.AlbumCovers[4];
      this.Texture[5].mainTexture = this.AlbumCovers[5];
      this.Label[1].text = "Panther\n" + this.Difficulties[1];
      this.Label[2].text = "?????\n" + this.Difficulties[2];
      this.Label[3].text = "?????\n" + this.Difficulties[3];
      this.Label[4].text = "?????\n" + this.Difficulties[4];
      this.Label[5].text = "?????\n" + this.Difficulties[5];
      this.Texture[2].color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.Texture[3].color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.Texture[4].color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.Texture[5].color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.Label[2].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
      this.Label[3].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
      this.Label[4].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
      this.Label[5].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
    }
    else if (this.Club == ClubType.MartialArts)
    {
      string str = "";
      if (GameGlobals.Eighties)
        str = "1989";
      this.ClubID = 51;
      for (this.ID = 1; this.ID < 6; ++this.ID)
      {
        string[] strArray = new string[7]
        {
          "file:///",
          Application.streamingAssetsPath,
          "/Portraits",
          str,
          "/Student_",
          null,
          null
        };
        int num = this.ClubID - this.ID;
        strArray[5] = num.ToString();
        strArray[6] = ".png";
        this.Texture[this.ID].mainTexture = (UnityEngine.Texture) new WWW(string.Concat(strArray)).texture;
        this.Label[this.ID].text = this.StudentManager.JSON.Students[this.ClubID - this.ID].Name + "\n" + this.Difficulties[this.ID];
        if ((Object) this.StudentManager.Students[this.ClubID - this.ID] != (Object) null)
        {
          if (!this.StudentManager.Students[this.ClubID - this.ID].Routine || !this.StudentManager.Students[this.ClubID - this.ID].ClubAttire)
          {
            num = this.ClubID - this.ID;
            Debug.Log((object) ("Student #" + num.ToString() + " is not doing their routine or not in their club attire."));
            this.Texture[this.ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
            this.Label[this.ID].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
          }
          else
          {
            this.Texture[this.ID].color = new Color(1f, 1f, 1f, 1f);
            this.Label[this.ID].color = new Color(0.0f, 0.0f, 0.0f, 1f);
          }
        }
        else
        {
          this.Texture[this.ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
          this.Label[this.ID].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
        }
      }
      this.Texture[5].color = new Color(1f, 1f, 1f, 1f);
      this.Label[5].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    }
    else if (this.Club == ClubType.Delinquent)
    {
      this.Texture[1].mainTexture = this.DelinquentDificultyIcons[1];
      this.Texture[2].mainTexture = this.DelinquentDificultyIcons[2];
      this.Texture[3].mainTexture = this.DelinquentDificultyIcons[3];
      this.Texture[4].mainTexture = this.DelinquentDificultyIcons[4];
      this.Texture[5].mainTexture = this.DelinquentDificultyIcons[5];
      this.Label[1].text = this.Difficulties[1] ?? "";
      this.Label[2].text = this.Difficulties[2] ?? "";
      this.Label[3].text = this.Difficulties[3] ?? "";
      this.Label[4].text = this.Difficulties[4] ?? "";
      this.Label[5].text = this.Difficulties[5] ?? "";
    }
    this.Window.SetActive(true);
    this.UpdateHighlight();
  }

  public void UpdateHighlight()
  {
    if (this.Selected < 1)
      this.Selected = 5;
    else if (this.Selected > 5)
      this.Selected = 1;
    this.Highlight.localPosition = new Vector3(0.0f, (float) (660 - 220 * this.Selected), 0.0f);
  }
}
