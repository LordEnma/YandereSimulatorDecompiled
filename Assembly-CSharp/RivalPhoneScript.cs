// Decompiled with JetBrains decompiler
// Type: RivalPhoneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RivalPhoneScript : MonoBehaviour
{
  public DoorGapScript StolenPhoneDropoff;
  public Renderer MyRenderer;
  public PromptScript Prompt;
  public bool LewdPhotos;
  public bool Stolen;
  public int StudentID;
  public Vector3 OriginalPosition;
  public Quaternion OriginalRotation;
  public Transform OriginalParent;

  private void Start()
  {
    this.OriginalParent = this.transform.parent;
    this.OriginalPosition = this.transform.localPosition;
    this.OriginalRotation = this.transform.localRotation;
    this.gameObject.SetActive(false);
    this.Prompt.Hide();
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
    if (!this.Prompt.Yandere.StudentManager.YandereVisible)
    {
      if (this.StudentID == this.Prompt.Yandere.StudentManager.RivalID && SchemeGlobals.GetSchemeStage(1) == 4)
      {
        SchemeGlobals.SetSchemeStage(1, 5);
        this.Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
      }
      this.Prompt.Yandere.RivalPhoneTexture = this.MyRenderer.material.mainTexture;
      this.Prompt.Yandere.Inventory.RivalPhone = true;
      this.Prompt.Yandere.Inventory.RivalPhoneID = this.StudentID;
      this.Prompt.enabled = false;
      this.enabled = false;
      this.StolenPhoneDropoff.Prompt.enabled = true;
      this.StolenPhoneDropoff.Phase = 1;
      this.StolenPhoneDropoff.Timer = 0.0f;
      this.StolenPhoneDropoff.Prompt.Label[0].text = "     Provide Stolen Phone";
      this.gameObject.SetActive(false);
      this.Stolen = true;
    }
    else
    {
      this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
      this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
  }

  public void ReturnToOrigin()
  {
    this.transform.parent = this.OriginalParent;
    this.transform.localPosition = this.OriginalPosition;
    this.transform.localRotation = this.OriginalRotation;
    this.gameObject.SetActive(false);
    this.Prompt.enabled = true;
    this.LewdPhotos = false;
    this.Stolen = false;
    this.enabled = true;
  }
}
