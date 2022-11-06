// Decompiled with JetBrains decompiler
// Type: SpyScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpyScript : MonoBehaviour
{
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public GameObject SpyCamera;
  public Transform SpyTarget;
  public Transform SpySpot;
  public float Timer;
  public bool RecordEvent;
  public bool CanRecord;
  public bool Recording;
  public int Phase;

  private void Start()
  {
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Yandere.CharacterAnimation.CrossFade("f02_spying_00");
      this.Yandere.CanMove = false;
      ++this.Phase;
    }
    if (this.Phase == 1)
    {
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, Quaternion.LookRotation(this.SpyTarget.transform.position - this.Yandere.transform.position), Time.deltaTime * 10f);
      this.Yandere.MoveTowardsTarget(this.SpySpot.position);
      if (!this.Recording && this.RecordEvent && this.Yandere.Inventory.DirectionalMic)
      {
        this.Yandere.CharacterAnimation.CrossFade("f02_spyRecord_00");
        this.Yandere.Microphone.SetActive(true);
        this.Recording = true;
      }
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      this.PromptBar.Label[1].text = "Stop";
      this.PromptBar.Label[2].text = "";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.Yandere.MainCamera.enabled = false;
      this.SpyCamera.SetActive(true);
      ++this.Phase;
    }
    else
    {
      if (this.Phase != 2 || !Input.GetButtonDown("B"))
        return;
      this.End();
    }
  }

  public void End()
  {
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Yandere.Microphone.SetActive(false);
    this.Yandere.MainCamera.enabled = true;
    this.Yandere.CanMove = true;
    this.SpyCamera.SetActive(false);
    this.Timer = 0.0f;
    this.Phase = 0;
  }
}
