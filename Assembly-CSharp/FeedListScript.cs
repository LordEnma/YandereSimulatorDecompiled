// Decompiled with JetBrains decompiler
// Type: FeedListScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FeedListScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public Transform Highlight;
  public Transform FeedList;
  public PromptScript Prompt;
  public GameObject Line;
  public JsonScript JSON;
  public GameObject[] Lines;
  public UILabel[] Names;
  public int RowLimit = 23;
  public int Selected = 1;
  public int Column = 1;
  public int Row = 1;
  public int[] PositionX;
  public bool Show;

  private void Start()
  {
    this.FeedList.localPosition = new Vector3(0.0f, -1200f, 0.0f);
    this.Names[1].text = this.JSON.Students[1].Name + "\n" + this.JSON.Students[2].Name + "\n" + this.JSON.Students[3].Name + "\n" + this.JSON.Students[4].Name + "\n" + this.JSON.Students[5].Name + "\n" + this.JSON.Students[6].Name + "\n" + this.JSON.Students[7].Name + "\n" + this.JSON.Students[8].Name + "\n" + this.JSON.Students[9].Name + "\n" + this.JSON.Students[10].Name + "\n" + this.JSON.Students[11].Name + "\n" + this.JSON.Students[12].Name + "\n" + this.JSON.Students[13].Name + "\n" + this.JSON.Students[14].Name + "\n" + this.JSON.Students[15].Name + "\n" + this.JSON.Students[16].Name + "\n" + this.JSON.Students[17].Name + "\n" + this.JSON.Students[18].Name + "\n" + this.JSON.Students[19].Name + "\n" + this.JSON.Students[20].Name + "\n" + this.JSON.Students[21].Name + "\n" + this.JSON.Students[22].Name + "\n" + this.JSON.Students[23].Name;
    this.Names[2].text = this.JSON.Students[24].Name + "\n" + this.JSON.Students[25].Name + "\n" + this.JSON.Students[26].Name + "\n" + this.JSON.Students[27].Name + "\n" + this.JSON.Students[28].Name + "\n" + this.JSON.Students[29].Name + "\n" + this.JSON.Students[30].Name + "\n" + this.JSON.Students[31].Name + "\n" + this.JSON.Students[32].Name + "\n" + this.JSON.Students[33].Name + "\n" + this.JSON.Students[34].Name + "\n" + this.JSON.Students[35].Name + "\n" + this.JSON.Students[36].Name + "\n" + this.JSON.Students[37].Name + "\n" + this.JSON.Students[38].Name + "\n" + this.JSON.Students[39].Name + "\n" + this.JSON.Students[40].Name + "\n" + this.JSON.Students[41].Name + "\n" + this.JSON.Students[42].Name + "\n" + this.JSON.Students[43].Name + "\n" + this.JSON.Students[44].Name + "\n" + this.JSON.Students[45].Name + "\n" + this.JSON.Students[46].Name;
    this.Names[3].text = this.JSON.Students[47].Name + "\n" + this.JSON.Students[48].Name + "\n" + this.JSON.Students[49].Name + "\n" + this.JSON.Students[50].Name + "\n" + this.JSON.Students[51].Name + "\n" + this.JSON.Students[52].Name + "\n" + this.JSON.Students[53].Name + "\n" + this.JSON.Students[54].Name + "\n" + this.JSON.Students[55].Name + "\n" + this.JSON.Students[56].Name + "\n" + this.JSON.Students[57].Name + "\n" + this.JSON.Students[58].Name + "\n" + this.JSON.Students[59].Name + "\n" + this.JSON.Students[60].Name + "\n" + this.JSON.Students[61].Name + "\n" + this.JSON.Students[62].Name + "\n" + this.JSON.Students[63].Name + "\n" + this.JSON.Students[64].Name + "\n" + this.JSON.Students[65].Name + "\n" + this.JSON.Students[66].Name + "\n" + this.JSON.Students[67].Name + "\n" + this.JSON.Students[68].Name + "\n" + this.JSON.Students[69].Name;
    this.Names[4].text = this.JSON.Students[70].Name + "\n" + this.JSON.Students[71].Name + "\n" + this.JSON.Students[72].Name + "\n" + this.JSON.Students[73].Name + "\n" + this.JSON.Students[74].Name + "\n" + this.JSON.Students[75].Name + "\n" + this.JSON.Students[76].Name + "\n" + this.JSON.Students[77].Name + "\n" + this.JSON.Students[78].Name + "\n" + this.JSON.Students[79].Name + "\n" + this.JSON.Students[80].Name + "\n" + this.JSON.Students[81].Name + "\n" + this.JSON.Students[82].Name + "\n" + this.JSON.Students[83].Name + "\n" + this.JSON.Students[84].Name + "\n" + this.JSON.Students[85].Name + "\n" + this.JSON.Students[86].Name + "\n" + this.JSON.Students[87].Name + "\n" + this.JSON.Students[88].Name + "\n" + this.JSON.Students[89].Name;
    int index = 1;
    this.Selected = 1;
    this.Column = 1;
    this.Row = 1;
    this.UpdateHighlight();
    while (index < 90)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.Line, this.Highlight.position, Quaternion.identity);
      gameObject.transform.parent = this.Highlight.parent;
      gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
      gameObject.SetActive(false);
      this.Lines[index] = gameObject;
      ++index;
      if (index < 90)
      {
        ++this.Row;
        if (this.Row > this.RowLimit)
        {
          if (this.Row > this.RowLimit)
            this.Row = 1;
          ++this.Column;
        }
      }
      else
      {
        this.Column = 1;
        this.Row = 1;
      }
      this.UpdateHighlight();
    }
    this.CrossOutStudents();
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.PromptBar.Show = true;
      this.PromptBar.Label[0].text = "Cross Out";
      this.PromptBar.Label[1].text = "Exit";
      this.PromptBar.Label[4].text = "Select";
      this.PromptBar.Label[5].text = "Select";
      this.PromptBar.UpdateButtons();
      this.Prompt.Circle[0].fillAmount = 1f;
      Time.timeScale = 0.0001f;
      this.Show = true;
    }
    if (this.Show)
    {
      this.FeedList.localPosition = Vector3.Lerp(this.FeedList.localPosition, new Vector3(0.0f, 0.0f, 0.0f), Time.unscaledDeltaTime * 10f);
      if (this.InputManager.TappedDown)
      {
        ++this.Row;
        if (this.Row > this.RowLimit)
          this.Row = 1;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedUp)
      {
        --this.Row;
        if (this.Row == 0)
          this.Row = this.RowLimit;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedRight)
      {
        ++this.Column;
        if (this.Column > 4)
          this.Column = 1;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedLeft)
      {
        --this.Column;
        if (this.Column == 0)
          this.Column = 4;
        this.UpdateHighlight();
      }
      if (Input.GetButtonDown("A"))
      {
        this.Lines[this.Selected].SetActive(!this.Lines[this.Selected].activeInHierarchy);
        this.CrossOutStudents();
      }
      if (!Input.GetButtonDown("B"))
        return;
      for (int index = 1; index < 90; ++index)
      {
        if ((Object) this.Prompt.Yandere.StudentManager.Students[index] != (Object) null)
        {
          this.Prompt.Yandere.StudentManager.Students[index].DoNotFeed = this.Lines[index].activeInHierarchy;
          if (this.Lines[index].activeInHierarchy)
          {
            Debug.Log((object) ("Line #" + index.ToString() + " was active."));
            Debug.Log((object) ("Student #" + index.ToString() + "'s DoNotFeed variable is now: " + this.Prompt.Yandere.StudentManager.Students[index].DoNotFeed.ToString()));
          }
        }
      }
      this.PromptBar.Show = false;
      this.PromptBar.ClearButtons();
      Time.timeScale = 1f;
      this.Show = false;
    }
    else
    {
      if ((double) this.FeedList.localPosition.y <= -1199.0)
        return;
      this.FeedList.localPosition = Vector3.Lerp(this.FeedList.localPosition, new Vector3(0.0f, -1200f, 0.0f), Time.deltaTime * 10f);
    }
  }

  private void UpdateHighlight()
  {
    this.RowLimit = this.Column >= 4 ? 20 : 23;
    if (this.Row > this.RowLimit)
      this.Row = this.RowLimit;
    this.Selected = (this.Column - 1) * 23 + this.Row;
    this.Highlight.localPosition = new Vector3((float) this.PositionX[this.Column], (float) (475.0 - 36.799999237060547 * (double) this.Row), 0.0f);
  }

  private void CrossOutStudents()
  {
    this.Lines[21].SetActive(true);
    this.Lines[22].SetActive(true);
    this.Lines[23].SetActive(true);
    this.Lines[24].SetActive(true);
    this.Lines[25].SetActive(true);
    this.Lines[66].SetActive(true);
    this.Lines[67].SetActive(true);
    this.Lines[68].SetActive(true);
    this.Lines[69].SetActive(true);
    this.Lines[70].SetActive(true);
    this.Lines[76].SetActive(true);
    this.Lines[77].SetActive(true);
    this.Lines[78].SetActive(true);
    this.Lines[79].SetActive(true);
    this.Lines[80].SetActive(true);
    if (!this.Prompt.Yandere.StudentManager.Eighties)
      return;
    this.Lines[81].SetActive(true);
    this.Lines[82].SetActive(true);
    this.Lines[83].SetActive(true);
    this.Lines[84].SetActive(true);
    this.Lines[85].SetActive(true);
  }
}
