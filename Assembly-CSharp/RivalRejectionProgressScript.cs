// Decompiled with JetBrains decompiler
// Type: RivalRejectionProgressScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class RivalRejectionProgressScript : MonoBehaviour
{
  public UILabel PercentLabel;
  public UILabel Label;
  public Texture[] RivalHeads;
  public UITexture RivalHead;
  public UISprite Darkness;
  public float Timer;
  public int Phase = 1;

  private void Start()
  {
    this.Label.text = "You have sabotaged " + DatingGlobals.RivalSabotaged.ToString() + " of your rival's interactions with Senpai. You must sabotage " + (5 - DatingGlobals.RivalSabotaged).ToString() + " more of their interactions in order to foil your rival's love confession on Friday.";
    this.PercentLabel.text = (DatingGlobals.RivalSabotaged * 20).ToString() + "%";
    this.RivalHead.transform.localPosition = new Vector3((float) (DatingGlobals.RivalSabotaged * 200 - 700), 0.0f, 0.0f);
    this.Darkness.alpha = 1f;
    Time.timeScale = 1f;
    if (!GameGlobals.Eighties)
      return;
    this.RivalHead.mainTexture = this.RivalHeads[DateGlobals.Week];
  }

  private void Update()
  {
    if (this.Phase == 1)
    {
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime);
      if ((double) this.Darkness.alpha == 0.0)
        ++this.Phase;
    }
    else if (this.Phase == 2)
    {
      if (Input.GetButtonDown("A"))
        ++this.Phase;
    }
    else if (this.Phase == 3)
    {
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime);
      if ((double) this.Darkness.alpha == 1.0)
      {
        if (!GameGlobals.JustKidnapped)
        {
          SceneManager.LoadScene("HomeScene");
        }
        else
        {
          GameGlobals.JustKidnapped = false;
          SceneManager.LoadScene("CalendarScene");
        }
      }
    }
    if (this.Phase <= 1)
      return;
    this.RivalHead.transform.localPosition = Vector3.Lerp(this.RivalHead.transform.localPosition, new Vector3((float) (DatingGlobals.RivalSabotaged * 200 - 500), 0.0f, 0.0f), Time.deltaTime * 10f);
  }
}
