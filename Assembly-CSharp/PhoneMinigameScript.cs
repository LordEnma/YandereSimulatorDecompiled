// Decompiled with JetBrains decompiler
// Type: PhoneMinigameScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PhoneMinigameScript : MonoBehaviour
{
  public PickpocketMinigameScript PickpocketMinigame;
  public OsanaThursdayAfterClassEventScript Event;
  public Renderer SmartPhoneScreen;
  public Transform Smartphone;
  public PromptScript Prompt;
  public Texture AlarmOff;
  public bool Tampering;
  public float Timer;
  public Vector3 OriginalPosition;
  public Vector3 OriginalRotation;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Yandere.CameraEffects.UpdateDOF(0.23f);
      this.Prompt.Yandere.MainCamera.GetComponent<AudioListener>().enabled = true;
      this.Prompt.Yandere.Pickpocketing = true;
      this.Prompt.Yandere.CanMove = false;
      this.Prompt.Yandere.MainCamera.transform.eulerAngles = new Vector3(45f, 180f, 0.0f);
      this.Prompt.Yandere.MainCamera.transform.position = new Vector3(0.4f, 12.66666f, -29.2f);
      this.Prompt.Yandere.RPGCamera.enabled = false;
      this.SmartPhoneScreen = this.Event.Rival.SmartPhoneScreen;
      this.Smartphone = this.Event.Rival.SmartPhone.transform;
      this.PickpocketMinigame.StartingAlerts = this.Prompt.Yandere.Alerts;
      this.PickpocketMinigame.PickpocketSpot = (Transform) null;
      this.PickpocketMinigame.Sabotage = true;
      this.PickpocketMinigame.Show = true;
      this.OriginalRotation = this.Smartphone.eulerAngles;
      this.OriginalPosition = this.Smartphone.position;
      this.Tampering = true;
    }
    if (!this.Tampering)
      return;
    this.Prompt.Yandere.MoveTowardsTarget(new Vector3(0.0f, 12f, -28.66666f));
    if (!this.PickpocketMinigame.Failure)
    {
      if (this.PickpocketMinigame.Progress == 1)
        this.Smartphone.position = Vector3.Lerp(this.Smartphone.position, new Vector3(0.4f, this.Smartphone.position.y, this.Smartphone.position.z), Time.deltaTime * 10f);
      else if (this.PickpocketMinigame.Progress == 2)
        this.Smartphone.eulerAngles = Vector3.Lerp(this.Smartphone.eulerAngles, new Vector3(0.0f, 180f, 0.0f), Time.deltaTime * 10f);
      else if (this.PickpocketMinigame.Progress == 3)
        this.SmartPhoneScreen.material.mainTexture = this.AlarmOff;
      else if (this.PickpocketMinigame.Progress == 4)
      {
        this.Smartphone.eulerAngles = Vector3.Lerp(this.Smartphone.eulerAngles, new Vector3(this.OriginalRotation.x, this.OriginalRotation.y, this.OriginalRotation.z), Time.deltaTime * 10f);
      }
      else
      {
        if (this.PickpocketMinigame.Show)
          return;
        this.Smartphone.position = Vector3.Lerp(this.Smartphone.position, new Vector3(this.OriginalPosition.x, this.OriginalPosition.y, this.OriginalPosition.z), Time.deltaTime * 10f);
        this.Timer += Time.deltaTime;
        if ((double) this.Timer <= 1.0)
          return;
        this.Event.Sabotaged = true;
        this.End();
      }
    }
    else
    {
      this.Prompt.Yandere.transform.position = new Vector3(0.0f, 12f, -28.5f);
      this.Prompt.Yandere.TheftTimer = 1f;
      this.Event.EndEvent();
      this.Event.Rival.transform.position = new Vector3(0.0f, 12f, -29.2f);
      this.Event.Rival.YandereVisible = true;
      this.Event.Rival.Distracted = false;
      this.Event.Rival.Alarm = 200f;
      this.End();
    }
  }

  private void End()
  {
    this.Prompt.Yandere.CameraEffects.UpdateDOF(2f);
    this.Prompt.Yandere.MainCamera.GetComponent<AudioListener>().enabled = false;
    this.Prompt.Yandere.RPGCamera.enabled = true;
    this.Prompt.Yandere.gameObject.SetActive(true);
    this.Prompt.Yandere.Pickpocketing = false;
    this.Prompt.Yandere.CanMove = true;
    this.Prompt.Yandere.Caught = false;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.Tampering = false;
    this.gameObject.SetActive(false);
  }
}
