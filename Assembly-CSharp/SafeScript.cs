// Decompiled with JetBrains decompiler
// Type: SafeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SafeScript : MonoBehaviour
{
  public MissionModeScript MissionMode;
  public PromptScript ContentsPrompt;
  public PromptScript SafePrompt;
  public PromptScript KeyPrompt;
  public Transform Door;
  public GameObject Key;
  public float Rotation;
  public bool Open;

  private void Start()
  {
    this.ContentsPrompt.MyCollider.enabled = false;
    this.SafePrompt.enabled = false;
  }

  private void Update()
  {
    if (this.Key.activeInHierarchy && (double) this.KeyPrompt.Circle[0].fillAmount == 0.0)
    {
      this.KeyPrompt.Yandere.Inventory.SafeKey = true;
      this.SafePrompt.HideButton[0] = false;
      this.SafePrompt.enabled = true;
      this.Key.SetActive(false);
    }
    if ((double) this.SafePrompt.Circle[0].fillAmount == 0.0)
    {
      this.KeyPrompt.Yandere.Inventory.SafeKey = false;
      this.ContentsPrompt.MyCollider.enabled = true;
      this.Open = true;
      this.SafePrompt.Hide();
      this.SafePrompt.enabled = false;
    }
    if ((double) this.ContentsPrompt.Circle[0].fillAmount == 0.0)
    {
      this.MissionMode.DocumentsStolen = true;
      this.enabled = false;
      this.ContentsPrompt.Hide();
      this.ContentsPrompt.enabled = false;
      this.ContentsPrompt.gameObject.SetActive(false);
    }
    if (this.Open)
    {
      this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 10f);
      this.Door.localEulerAngles = new Vector3(this.Door.localEulerAngles.x, this.Rotation, this.Door.localEulerAngles.z);
      if ((double) this.Rotation >= 1.0)
        return;
      this.Open = false;
    }
    else if (this.SafePrompt.Yandere.Inventory.LockPick)
    {
      this.SafePrompt.HideButton[2] = false;
      this.SafePrompt.enabled = true;
      if ((double) this.SafePrompt.Circle[2].fillAmount != 0.0)
        return;
      this.KeyPrompt.Hide();
      this.KeyPrompt.enabled = false;
      this.SafePrompt.Yandere.Inventory.LockPick = false;
      this.SafePrompt.HideButton[2] = true;
      this.ContentsPrompt.MyCollider.enabled = true;
      this.Open = true;
    }
    else
    {
      if (this.SafePrompt.HideButton[2])
        return;
      this.SafePrompt.HideButton[2] = true;
    }
  }
}
