// Decompiled with JetBrains decompiler
// Type: CabinetDoorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CabinetDoorScript : MonoBehaviour
{
  public PromptScript Prompt;
  public bool Eighties;
  public bool Locked;
  public bool Open;
  public float Timer;

  private void Start() => this.Eighties = GameGlobals.Eighties;

  private void Update()
  {
    if (this.Locked)
    {
      if ((double) this.Prompt.Circle[0].fillAmount < 1.0)
      {
        this.Prompt.Label[0].text = "     Locked";
        this.Prompt.Circle[0].fillAmount = 1f;
      }
      if (this.Prompt.Yandere.Inventory.LockPick)
      {
        this.Prompt.HideButton[2] = false;
        if ((double) this.Prompt.Circle[2].fillAmount == 0.0)
        {
          this.Prompt.Circle[2].fillAmount = 1f;
          if (this.Eighties)
          {
            this.Prompt.Yandere.Inventory.LockPick = false;
            this.Prompt.Label[0].text = "     Open";
            this.Prompt.HideButton[2] = true;
            this.Locked = false;
          }
          else
          {
            this.Prompt.Yandere.NotificationManager.CustomText = "Cannot be lockpicked!";
            this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
        }
      }
      else if (!this.Prompt.HideButton[2])
        this.Prompt.HideButton[2] = true;
    }
    else if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Yandere.TheftTimer = 0.1f;
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Open = !this.Open;
      this.UpdateLabel();
      this.Timer = 0.0f;
    }
    if (this.Open)
      this.transform.localPosition = new Vector3(Mathf.Lerp(this.transform.localPosition.x, 0.41775f, Time.deltaTime * 10f), this.transform.localPosition.y, this.transform.localPosition.z);
    else
      this.transform.localPosition = new Vector3(Mathf.Lerp(this.transform.localPosition.x, 0.0f, Time.deltaTime * 10f), this.transform.localPosition.y, this.transform.localPosition.z);
    if ((double) this.Timer >= 2.0)
      return;
    this.Timer += Time.deltaTime;
    if (this.Open)
      this.transform.localPosition = new Vector3(Mathf.Lerp(this.transform.localPosition.x, 0.41775f, Time.deltaTime * 10f), this.transform.localPosition.y, this.transform.localPosition.z);
    else
      this.transform.localPosition = new Vector3(Mathf.Lerp(this.transform.localPosition.x, 0.0f, Time.deltaTime * 10f), this.transform.localPosition.y, this.transform.localPosition.z);
  }

  public void UpdateLabel()
  {
    if (this.Open)
      this.Prompt.Label[0].text = "     Close";
    else
      this.Prompt.Label[0].text = "     Open";
  }
}
