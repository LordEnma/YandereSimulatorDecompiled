// Decompiled with JetBrains decompiler
// Type: FeedListScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
  public string[] StudentNames;
  public int RowLimit = 23;
  public int Selected = 1;
  public int Column = 1;
  public int Row = 1;
  public int[] PositionX;
  public bool Show;

  private void Start()
  {
    this.FeedList.localPosition = new Vector3(0.0f, -1200f, 0.0f);
    for (int index = 1; index < 101; ++index)
      this.StudentNames[index] = this.JSON.Students[index].Name;
    int week = DateGlobals.Week;
    for (int index = 2; index < 11; ++index)
    {
      if (index > week)
        this.StudentNames[10 + index] = "";
    }
    this.Names[1].text = this.StudentNames[1] + "\n" + this.StudentNames[2] + "\n" + this.StudentNames[3] + "\n" + this.StudentNames[4] + "\n" + this.StudentNames[5] + "\n" + this.StudentNames[6] + "\n" + this.StudentNames[7] + "\n" + this.StudentNames[8] + "\n" + this.StudentNames[9] + "\n" + this.StudentNames[10] + "\n" + this.StudentNames[11] + "\n" + this.StudentNames[12] + "\n" + this.StudentNames[13] + "\n" + this.StudentNames[14] + "\n" + this.StudentNames[15] + "\n" + this.StudentNames[16] + "\n" + this.StudentNames[17] + "\n" + this.StudentNames[18] + "\n" + this.StudentNames[19] + "\n" + this.StudentNames[20] + "\n" + this.StudentNames[21] + "\n" + this.StudentNames[22] + "\n" + this.StudentNames[23];
    this.Names[2].text = this.StudentNames[24] + "\n" + this.StudentNames[25] + "\n" + this.StudentNames[26] + "\n" + this.StudentNames[27] + "\n" + this.StudentNames[28] + "\n" + this.StudentNames[29] + "\n" + this.StudentNames[30] + "\n" + this.StudentNames[31] + "\n" + this.StudentNames[32] + "\n" + this.StudentNames[33] + "\n" + this.StudentNames[34] + "\n" + this.StudentNames[35] + "\n" + this.StudentNames[36] + "\n" + this.StudentNames[37] + "\n" + this.StudentNames[38] + "\n" + this.StudentNames[39] + "\n" + this.StudentNames[40] + "\n" + this.StudentNames[41] + "\n" + this.StudentNames[42] + "\n" + this.StudentNames[43] + "\n" + this.StudentNames[44] + "\n" + this.StudentNames[45] + "\n" + this.StudentNames[46];
    this.Names[3].text = this.StudentNames[47] + "\n" + this.StudentNames[48] + "\n" + this.StudentNames[49] + "\n" + this.StudentNames[50] + "\n" + this.StudentNames[51] + "\n" + this.StudentNames[52] + "\n" + this.StudentNames[53] + "\n" + this.StudentNames[54] + "\n" + this.StudentNames[55] + "\n" + this.StudentNames[56] + "\n" + this.StudentNames[57] + "\n" + this.StudentNames[58] + "\n" + this.StudentNames[59] + "\n" + this.StudentNames[60] + "\n" + this.StudentNames[61] + "\n" + this.StudentNames[62] + "\n" + this.StudentNames[63] + "\n" + this.StudentNames[64] + "\n" + this.StudentNames[65] + "\n" + this.StudentNames[66] + "\n" + this.StudentNames[67] + "\n" + this.StudentNames[68] + "\n" + this.StudentNames[69];
    this.Names[4].text = this.StudentNames[70] + "\n" + this.StudentNames[71] + "\n" + this.StudentNames[72] + "\n" + this.StudentNames[73] + "\n" + this.StudentNames[74] + "\n" + this.StudentNames[75] + "\n" + this.StudentNames[76] + "\n" + this.StudentNames[77] + "\n" + this.StudentNames[78] + "\n" + this.StudentNames[79] + "\n" + this.StudentNames[80] + "\n" + this.StudentNames[81] + "\n" + this.StudentNames[82] + "\n" + this.StudentNames[83] + "\n" + this.StudentNames[84] + "\n" + this.StudentNames[85] + "\n" + this.StudentNames[86] + "\n" + this.StudentNames[87] + "\n" + this.StudentNames[88] + "\n" + this.StudentNames[89];
    int index1 = 1;
    this.Selected = 1;
    this.Column = 1;
    this.Row = 1;
    this.UpdateHighlight();
    while (index1 < 90)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.Line, this.Highlight.position, Quaternion.identity);
      gameObject.transform.parent = this.Highlight.parent;
      gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
      gameObject.SetActive(false);
      this.Lines[index1] = gameObject;
      ++index1;
      if (index1 < 90)
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
        if (this.StudentNames[this.Selected] != "")
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
