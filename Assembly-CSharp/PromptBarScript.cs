// Decompiled with JetBrains decompiler
// Type: PromptBarScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PromptBarScript : MonoBehaviour
{
  public UISprite[] Button;
  public UILabel[] Label;
  public UILabel[] ButtonLabel;
  public UIPanel Panel;
  public bool Show;
  public int ID;

  private void Awake()
  {
    this.transform.localPosition = new Vector3(this.transform.localPosition.x, -627f, this.transform.localPosition.z);
    for (this.ID = 0; this.ID < this.Label.Length; ++this.ID)
      this.Label[this.ID].text = string.Empty;
  }

  private void Start() => this.UpdateButtons();

  private void Update()
  {
    float t = Time.unscaledDeltaTime * 10f;
    if (!this.Show)
    {
      if (!this.Panel.enabled)
        return;
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Lerp(this.transform.localPosition.y, -628f, t), this.transform.localPosition.z);
      if ((double) this.transform.localPosition.y >= -627.0)
        return;
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, -628f, this.transform.localPosition.z);
      if (!((Object) this.Panel != (Object) null))
        return;
      this.Panel.enabled = false;
    }
    else
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Lerp(this.transform.localPosition.y, -528.5f, t), this.transform.localPosition.z);
  }

  public void UpdateButtons()
  {
    if ((Object) this.Panel != (Object) null)
      this.Panel.enabled = true;
    for (this.ID = 0; this.ID < this.Label.Length; ++this.ID)
    {
      this.Button[this.ID].enabled = this.Label[this.ID].text.Length > 0;
      this.ButtonLabel[this.ID].enabled = this.Label[this.ID].text.Length > 0;
    }
  }

  public void ClearButtons()
  {
    for (this.ID = 0; this.ID < this.Label.Length; ++this.ID)
    {
      this.ButtonLabel[this.ID].enabled = false;
      this.Label[this.ID].text = string.Empty;
      this.Button[this.ID].enabled = false;
    }
  }
}
