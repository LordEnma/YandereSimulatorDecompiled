// Decompiled with JetBrains decompiler
// Type: KatanaCaseScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class KatanaCaseScript : MonoBehaviour
{
  public PromptScript CasePrompt;
  public PromptScript KeyPrompt;
  public Transform Door;
  public GameObject Key;
  public float Rotation;
  public bool Open;

  private void Start() => this.CasePrompt.enabled = false;

  private void Update()
  {
    if (this.Key.activeInHierarchy && (double) this.KeyPrompt.Circle[0].fillAmount == 0.0)
    {
      this.KeyPrompt.Yandere.Inventory.CaseKey = true;
      this.CasePrompt.HideButton[0] = false;
      this.CasePrompt.enabled = true;
      this.Key.SetActive(false);
    }
    if ((double) this.CasePrompt.Circle[0].fillAmount == 0.0)
    {
      this.KeyPrompt.Yandere.Inventory.CaseKey = false;
      this.Open = true;
      this.CasePrompt.Hide();
      this.CasePrompt.enabled = false;
    }
    if (this.CasePrompt.Yandere.Inventory.LockPick)
    {
      this.CasePrompt.HideButton[2] = false;
      this.CasePrompt.enabled = true;
      if ((double) this.CasePrompt.Circle[2].fillAmount == 0.0)
      {
        this.KeyPrompt.Hide();
        this.KeyPrompt.enabled = false;
        this.CasePrompt.Yandere.Inventory.LockPick = false;
        this.CasePrompt.Label[0].text = "     Open";
        this.CasePrompt.HideButton[2] = true;
        this.CasePrompt.HideButton[0] = true;
        this.Open = true;
      }
    }
    else if (!this.CasePrompt.HideButton[2])
      this.CasePrompt.HideButton[2] = true;
    if (!this.Open)
      return;
    this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * 10f);
    this.Door.eulerAngles = new Vector3(this.Door.eulerAngles.x, this.Door.eulerAngles.y, this.Rotation);
    if ((double) this.Rotation >= -179.89999389648438)
      return;
    this.enabled = false;
  }
}
