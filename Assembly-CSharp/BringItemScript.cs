// Decompiled with JetBrains decompiler
// Type: BringItemScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BringItemScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public HomeWindowScript HomeWindow;
  public HomeExitScript HomeExit;
  public string[] Descriptions;
  public GameObject Checkmark;
  public Transform Highlight;
  public UILabel DescLabel;
  public UILabel[] Labels;
  public int Limit = 12;
  public int ID = 1;
  public bool Initialized;

  private void Initialize()
  {
    for (int ID = 1; ID < 8; ++ID)
    {
      if (PlayerGlobals.GetCannotBringItem(ID))
        this.Labels[ID].color = new Color(1f, 1f, 1f, 0.5f);
      else
        this.Labels[ID].color = new Color(1f, 1f, 1f, 1f);
    }
    if (PlayerGlobals.BringingItem != 0)
    {
      this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (50.0 - (double) PlayerGlobals.BringingItem * 50.0), this.Highlight.localPosition.z);
      this.Checkmark.transform.localPosition = new Vector3(300f, this.Highlight.localPosition.y, 0.0f);
      this.Checkmark.SetActive(true);
    }
    if (PlayerGlobals.BoughtLockpick)
      this.Labels[8].alpha = 1f;
    if (PlayerGlobals.BoughtSedative)
      this.Labels[9].alpha = 1f;
    if (PlayerGlobals.BoughtNarcotics)
      this.Labels[10].alpha = 1f;
    if (PlayerGlobals.BoughtPoison)
      this.Labels[11].alpha = 1f;
    if (PlayerGlobals.BoughtExplosive)
      this.Labels[12].alpha = 1f;
    this.DescLabel.text = this.Descriptions[this.ID];
  }

  private void Update()
  {
    if (!this.Initialized)
    {
      this.Initialize();
      this.Initialized = true;
    }
    if ((double) this.HomeWindow.Sprite.color.a <= 0.89999997615814209)
      return;
    if (this.InputManager.TappedDown)
    {
      ++this.ID;
      if (this.ID > this.Limit)
        this.ID = 1;
      this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (50.0 - (double) this.ID * 50.0), this.Highlight.localPosition.z);
      this.DescLabel.text = this.Descriptions[this.ID];
    }
    if (this.InputManager.TappedUp)
    {
      --this.ID;
      if (this.ID < 1)
        this.ID = this.Limit;
      this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (50.0 - (double) this.ID * 50.0), this.Highlight.localPosition.z);
      this.DescLabel.text = this.Descriptions[this.ID];
    }
    if (Input.GetButtonDown("A") && (double) this.Labels[this.ID].color.a == 1.0)
    {
      if (PlayerGlobals.BringingItem != this.ID)
      {
        this.Checkmark.transform.localPosition = new Vector3(300f, this.Highlight.localPosition.y, 0.0f);
        this.Checkmark.SetActive(true);
        PlayerGlobals.BringingItem = this.ID;
      }
      else
      {
        this.Checkmark.SetActive(false);
        PlayerGlobals.BringingItem = 0;
      }
    }
    if (Input.GetButtonDown("B"))
    {
      this.HomeExit.HomeWindow.Show = true;
      this.HomeWindow.Show = false;
    }
    if (!Input.GetButtonDown("X"))
      return;
    this.HomeExit.HomeWindow.Show = true;
    this.HomeWindow.Show = false;
    this.HomeExit.GoToSchool();
  }
}
