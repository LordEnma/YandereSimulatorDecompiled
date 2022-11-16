// Decompiled with JetBrains decompiler
// Type: ChoiceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public Transform Highlight;
  public UISprite Darkness;
  public int Selected;
  public int Phase;

  private void Start() => this.Darkness.color = new Color(1f, 1f, 1f, 1f);

  private void Update()
  {
    this.Highlight.transform.localPosition = Vector3.Lerp(this.Highlight.transform.localPosition, new Vector3((float) (720 * this.Selected - 360), this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z), Time.deltaTime * 10f);
    if (this.Phase == 0)
    {
      this.Darkness.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime * 2f));
      if ((double) this.Darkness.color.a != 0.0)
        return;
      ++this.Phase;
    }
    else if (this.Phase == 1)
    {
      if (this.InputManager.TappedLeft)
      {
        this.Darkness.color = new Color(1f, 1f, 1f, 0.0f);
        this.Selected = 0;
      }
      else if (this.InputManager.TappedRight)
      {
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        this.Selected = 1;
      }
      if (!Input.GetButtonDown("A"))
        return;
      ++this.Phase;
    }
    else
    {
      if (this.Phase != 2)
        return;
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime * 2f));
      if ((double) this.Darkness.color.a != 1.0)
        return;
      GameGlobals.LoveSick = this.Selected == 1;
      SceneManager.LoadScene("NewTitleScene");
    }
  }
}
