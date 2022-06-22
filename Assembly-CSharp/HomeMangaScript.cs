// Decompiled with JetBrains decompiler
// Type: HomeMangaScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeMangaScript : MonoBehaviour
{
  private static readonly string[] SeductionStrings = new string[6]
  {
    "Innocent",
    "Flirty",
    "Charming",
    "Sensual",
    "Seductive",
    "Succubus"
  };
  private static readonly string[] NumbnessStrings = new string[6]
  {
    "Stoic",
    "Somber",
    "Detached",
    "Unemotional",
    "Desensitized",
    "Dead Inside"
  };
  private static readonly string[] EnlightenmentStrings = new string[6]
  {
    "Asleep",
    "Awoken",
    "Mindful",
    "Informed",
    "Eyes Open",
    "Omniscient"
  };
  public InputManagerScript InputManager;
  public HomeYandereScript HomeYandere;
  public HomeCameraScript HomeCamera;
  public HomeWindowScript HomeWindow;
  public HomeDarknessScript Darkness;
  private GameObject NewManga;
  public GameObject ReadButtonGroup;
  public GameObject MysteryManga;
  public GameObject AreYouSure;
  public GameObject MangaGroup;
  public GameObject[] MangaList;
  public UILabel MangaNameLabel;
  public UILabel MangaDescLabel;
  public UILabel MangaBuffLabel;
  public UILabel RequiredLabel;
  public UILabel CurrentLabel;
  public UILabel ButtonLabel;
  public Transform MangaParent;
  public bool DestinationReached;
  public float TargetRotation;
  public float Rotation;
  public int TotalManga;
  public int Selected;
  public string Title = string.Empty;
  public GameObject[] MangaModels;
  public string[] MangaNames;
  public string[] MangaDescs;
  public string[] MangaBuffs;
  public AudioClip ChangeSelection;

  private void Start()
  {
    this.UpdateCurrentLabel();
    for (int index = 0; index < this.TotalManga; ++index)
    {
      this.NewManga = !CollectibleGlobals.GetMangaCollected(index + 1) ? Object.Instantiate<GameObject>(this.MysteryManga, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f), Quaternion.identity) : Object.Instantiate<GameObject>(this.MangaModels[index], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f), Quaternion.identity);
      this.NewManga.transform.parent = this.MangaParent;
      this.NewManga.GetComponent<HomeMangaBookScript>().Manga = this;
      this.NewManga.GetComponent<HomeMangaBookScript>().ID = index;
      this.NewManga.transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
      this.MangaParent.transform.localEulerAngles = new Vector3(this.MangaParent.transform.localEulerAngles.x, this.MangaParent.transform.localEulerAngles.y + 360f / (float) this.TotalManga, this.MangaParent.transform.localEulerAngles.z);
      this.MangaList[index] = this.NewManga;
    }
    this.MangaParent.transform.localEulerAngles = new Vector3(this.MangaParent.transform.localEulerAngles.x, 0.0f, this.MangaParent.transform.localEulerAngles.z);
    this.MangaParent.transform.localPosition = new Vector3(this.MangaParent.transform.localPosition.x, this.MangaParent.transform.localPosition.y, 1.8f);
    this.MangaParent.transform.localScale = Vector3.zero;
    this.MangaParent.gameObject.SetActive(false);
    if (GameGlobals.Eighties)
    {
      this.MangaNames[0] = "Enchanting Petals Volume 1";
      this.MangaNames[1] = "Enchanting Petals Volume 2";
      this.MangaNames[2] = "Enchanting Petals Volume 3";
      this.MangaNames[3] = "Enchanting Petals Volume 4";
      this.MangaNames[4] = "Enchanting Petals Volume 5";
      this.MangaNames[5] = "Ahmya Volume 1";
      this.MangaNames[6] = "Ahmya Volume 2";
      this.MangaNames[7] = "Ahmya Volume 3";
      this.MangaNames[8] = "Ahmya Volume 4";
      this.MangaNames[9] = "Ahmya Volume 5";
      this.MangaDescs[0] = "The long-lasting bonds of Hurrem continuously bloom throughout the seasons.";
      this.MangaDescs[1] = "The pure and noble heart of Juliet. Won't you whisper sweet nothings before drinking the wine?";
      this.MangaDescs[2] = "The fireflies bring forth the sweet Japanese summer, where a maiden waits by the riverside.";
      this.MangaDescs[3] = "The luxuries of the French court shall test her chastity. Will distance from one's love bring forth temptation?";
      this.MangaDescs[4] = "The midsummer garden envokes blissful sincerity. She dances the night away.";
      this.MangaDescs[5] = "A beautiful girl transfers into the local high school, bringing an alluring aroma that seems too sweet.";
      this.MangaDescs[6] = "A rumor has begun to spread. It seems that venomous jealousy has pierced the hearts of girls at school.";
      this.MangaDescs[7] = "A young man begins investigating the mysterious disappearances that are plaguing his small town.";
      this.MangaDescs[8] = "A large number of men have gone missing. Claw marks are found. A young man suspects the kiss of death.";
      this.MangaDescs[9] = "A dark secret is unveiled. But, will the one who uncovered it live long enough to spread the truth?";
    }
    this.UpdateMangaLabels();
  }

  private void Update()
  {
    if (this.HomeWindow.Show)
    {
      if (!this.AreYouSure.activeInHierarchy)
      {
        this.MangaParent.localScale = Vector3.Lerp(this.MangaParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.MangaParent.gameObject.SetActive(true);
        if (this.InputManager.TappedRight)
        {
          this.DestinationReached = false;
          this.TargetRotation += 360f / (float) this.TotalManga;
          ++this.Selected;
          if (this.Selected > this.TotalManga - 1)
            this.Selected = 0;
          this.UpdateMangaLabels();
          this.UpdateCurrentLabel();
        }
        if (this.InputManager.TappedLeft)
        {
          this.DestinationReached = false;
          this.TargetRotation -= 360f / (float) this.TotalManga;
          --this.Selected;
          if (this.Selected < 0)
            this.Selected = this.TotalManga - 1;
          this.UpdateMangaLabels();
          this.UpdateCurrentLabel();
        }
        this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * 10f);
        this.MangaParent.localEulerAngles = new Vector3(this.MangaParent.localEulerAngles.x, this.Rotation, this.MangaParent.localEulerAngles.z);
        if (Input.GetButtonDown("A") && this.ReadButtonGroup.activeInHierarchy)
        {
          this.MangaGroup.SetActive(false);
          this.AreYouSure.SetActive(true);
        }
        if (Input.GetButtonDown("B"))
        {
          this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
          this.HomeCamera.Target = this.HomeCamera.Targets[0];
          this.HomeYandere.CanMove = true;
          this.HomeWindow.Show = false;
        }
        if (!Input.GetKeyDown(KeyCode.Space))
          return;
        for (int index = 0; index < this.TotalManga; ++index)
          CollectibleGlobals.SetMangaCollected(index + 1, true);
      }
      else
      {
        if (Input.GetButtonDown("A"))
        {
          if (this.Selected < 5)
            ++PlayerGlobals.Seduction;
          else if (this.Selected < 10)
            ++PlayerGlobals.Numbness;
          else
            ++PlayerGlobals.Enlightenment;
          this.AreYouSure.SetActive(false);
          this.Darkness.FadeOut = true;
        }
        if (!Input.GetButtonDown("B"))
          return;
        this.MangaGroup.SetActive(true);
        this.AreYouSure.SetActive(false);
      }
    }
    else
    {
      this.MangaParent.localScale = Vector3.Lerp(this.MangaParent.localScale, Vector3.zero, Time.deltaTime * 10f);
      if ((double) this.MangaParent.localScale.x >= 0.00999999977648258)
        return;
      this.MangaParent.gameObject.SetActive(false);
    }
  }

  private void UpdateMangaLabels()
  {
    if (this.Selected < 5)
    {
      this.ReadButtonGroup.SetActive(PlayerGlobals.Seduction == this.Selected);
      if (CollectibleGlobals.GetMangaCollected(this.Selected + 1))
      {
        this.RequiredLabel.text = PlayerGlobals.Seduction <= this.Selected ? "Required Seduction Level: " + this.Selected.ToString() : "You have already read this manga.";
      }
      else
      {
        this.RequiredLabel.text = "You have not yet collected this manga.";
        this.ReadButtonGroup.SetActive(false);
      }
    }
    else if (this.Selected < 10)
    {
      this.ReadButtonGroup.SetActive(PlayerGlobals.Numbness == this.Selected - 5);
      if (CollectibleGlobals.GetMangaCollected(this.Selected + 1))
      {
        this.RequiredLabel.text = PlayerGlobals.Numbness <= this.Selected - 5 ? "Required Numbness Level: " + (this.Selected - 5).ToString() : "You have already read this manga.";
      }
      else
      {
        this.RequiredLabel.text = "You have not yet collected this manga.";
        this.ReadButtonGroup.SetActive(false);
      }
    }
    else
    {
      this.ReadButtonGroup.SetActive(PlayerGlobals.Enlightenment == this.Selected - 10);
      if (CollectibleGlobals.GetMangaCollected(this.Selected + 1))
      {
        this.RequiredLabel.text = PlayerGlobals.Enlightenment <= this.Selected - 10 ? "Required Enlightenment Level: " + (this.Selected - 10).ToString() : "You have already read this manga.";
      }
      else
      {
        this.RequiredLabel.text = "You have not yet collected this manga.";
        this.ReadButtonGroup.SetActive(false);
      }
    }
    if (CollectibleGlobals.GetMangaCollected(this.Selected + 1))
    {
      this.MangaNameLabel.text = this.MangaNames[this.Selected];
      this.MangaDescLabel.text = this.MangaDescs[this.Selected];
      this.MangaBuffLabel.text = this.MangaBuffs[this.Selected];
    }
    else
    {
      this.MangaNameLabel.text = "?????";
      this.MangaDescLabel.text = "?????";
      this.MangaBuffLabel.text = "?????";
    }
  }

  private void UpdateCurrentLabel()
  {
    if (this.Selected < 5)
    {
      this.Title = HomeMangaScript.SeductionStrings[PlayerGlobals.Seduction];
      this.CurrentLabel.text = "Current Seduction Level: " + PlayerGlobals.Seduction.ToString() + " (" + this.Title + ")";
    }
    else if (this.Selected < 10)
    {
      this.Title = HomeMangaScript.NumbnessStrings[PlayerGlobals.Numbness];
      this.CurrentLabel.text = "Current Numbness Level: " + PlayerGlobals.Numbness.ToString() + " (" + this.Title + ")";
    }
    else
    {
      this.Title = HomeMangaScript.EnlightenmentStrings[PlayerGlobals.Enlightenment];
      this.CurrentLabel.text = "Current Enlightenment Level: " + PlayerGlobals.Enlightenment.ToString() + " (" + this.Title + ")";
    }
    AudioSource.PlayClipAtPoint(this.ChangeSelection, this.transform.position);
  }
}
