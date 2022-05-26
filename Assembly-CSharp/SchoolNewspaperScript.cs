// Decompiled with JetBrains decompiler
// Type: SchoolNewspaperScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SchoolNewspaperScript : MonoBehaviour
{
  public PromptBarScript PromptBar;
  public PromptScript Prompt;
  public UILabel NewspaperLabel;
  public GameObject[] NewspaperPages;
  public GameObject ClubPosters;
  public GameObject Newspaper;
  public string[] Article;
  public int GameplayDay;
  public bool Show;

  private void Start()
  {
    if (GameGlobals.Eighties)
    {
      this.ClubPosters.SetActive(false);
      if (!ClubGlobals.GetClubClosed(ClubType.Newspaper))
        return;
      this.NewspaperPages[1].SetActive(false);
      this.NewspaperPages[2].SetActive(false);
      this.NewspaperPages[3].SetActive(false);
      this.Prompt.enabled = false;
      this.Prompt.Hide();
    }
    else
      this.gameObject.SetActive(false);
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[1].text = "Back";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.Newspaper.SetActive(true);
      this.GameplayDay = (int) ((DateGlobals.Week - 1) * 5 + DateGlobals.Weekday);
      this.NewspaperLabel.text = this.Article[this.GameplayDay];
      this.NewspaperLabel.text = this.NewspaperLabel.text.Replace('@', '\n');
      if (this.NewspaperLabel.text == "")
        this.NewspaperLabel.text = "Whoops! Sorry, this article is coming in a future update.";
      Time.timeScale = 0.0f;
      this.Show = true;
    }
    if (!this.Show || !Input.GetButtonDown("B"))
      return;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Newspaper.SetActive(false);
    Time.timeScale = 1f;
  }
}
