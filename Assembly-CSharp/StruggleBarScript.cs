// Decompiled with JetBrains decompiler
// Type: StruggleBarScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StruggleBarScript : MonoBehaviour
{
  public ShoulderCameraScript ShoulderCamera;
  public PromptSwapScript ButtonPrompt;
  public UISprite[] ButtonPrompts;
  public YandereScript Yandere;
  public StudentScript Student;
  public Transform Spikes;
  public string CurrentButton = string.Empty;
  public bool Struggling;
  public bool Invincible;
  public float AttackTimer;
  public float ButtonTimer;
  public float Intensity;
  public float Strength = 1f;
  public float Struggle;
  public float Victory;
  public int ButtonID;

  private void Start()
  {
    this.transform.localScale = Vector3.zero;
    this.ChooseButton();
  }

  private void Update()
  {
    if (this.Struggling)
    {
      this.Intensity = Mathf.MoveTowards(this.Intensity, 1f, Time.deltaTime);
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.Spikes.localEulerAngles = new Vector3(this.Spikes.localEulerAngles.x, this.Spikes.localEulerAngles.y, this.Spikes.localEulerAngles.z - Time.deltaTime * 360f);
      this.Victory -= Time.deltaTime * 5f * this.Strength;
      if (this.Yandere.Club == ClubType.MartialArts)
        this.Victory = 100f;
      if (Input.GetButtonDown(this.CurrentButton))
      {
        if (this.Invincible)
          this.Victory += 100f;
        this.Victory += Time.deltaTime * (float) (500.0 + (double) (this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus) * 150.0);
      }
      if ((double) this.Victory >= 100.0)
        this.Victory = 100f;
      if ((double) this.Victory <= -100.0)
        this.Victory = -100f;
      UISprite buttonPrompt = this.ButtonPrompts[this.ButtonID];
      buttonPrompt.transform.localPosition = new Vector3(Mathf.Lerp(buttonPrompt.transform.localPosition.x, this.Victory * 6.5f, Time.deltaTime * 10f), buttonPrompt.transform.localPosition.y, buttonPrompt.transform.localPosition.z);
      this.Spikes.localPosition = new Vector3(buttonPrompt.transform.localPosition.x, this.Spikes.localPosition.y, this.Spikes.localPosition.z);
      if ((double) this.Victory == 100.0)
      {
        Debug.Log((object) ("Yandere-chan just won a struggle against " + this.Student.Name + "."));
        this.Yandere.Won = true;
        this.Student.Lost = true;
        this.Struggling = false;
        this.Victory = 0.0f;
      }
      else if ((double) this.Victory == -100.0)
      {
        if (this.Invincible)
          return;
        this.HeroWins();
      }
      else
      {
        this.ButtonTimer += Time.deltaTime;
        if ((double) this.ButtonTimer < 2.0)
          return;
        this.ChooseButton();
        this.ButtonTimer = 0.0f;
        this.Intensity = 0.0f;
      }
    }
    else if ((double) this.transform.localScale.x > 0.10000000149011612)
    {
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
    }
    else
    {
      this.transform.localScale = Vector3.zero;
      if (!this.Yandere.AttackManager.Censor)
      {
        this.gameObject.SetActive(false);
      }
      else
      {
        if ((double) this.AttackTimer == 0.0)
        {
          this.Yandere.Blur.enabled = true;
          this.Yandere.Blur.Size = 1f;
        }
        this.AttackTimer += Time.deltaTime;
        if ((double) this.AttackTimer < 2.5)
        {
          this.Yandere.Blur.Size = Mathf.MoveTowards(this.Yandere.Blur.Size, 16f, Time.deltaTime * 10f);
        }
        else
        {
          this.Yandere.Blur.Size = Mathf.Lerp(this.Yandere.Blur.Size, 1f, Time.deltaTime * 32f);
          if ((double) this.AttackTimer < 3.0)
            return;
          this.gameObject.SetActive(false);
          this.Yandere.Blur.enabled = false;
          this.Yandere.Blur.Size = 1f;
          this.AttackTimer = 0.0f;
        }
      }
    }
  }

  public void HeroWins()
  {
    if (this.Yandere.enabled && this.Yandere.Armed)
      this.Yandere.EquippedWeapon.Drop();
    this.Yandere.Lost = true;
    this.Student.Won = true;
    this.Struggling = false;
    this.Victory = 0.0f;
    if (!this.Yandere.StudentManager.enabled)
      return;
    this.Yandere.StudentManager.StopMoving();
  }

  private void ChooseButton()
  {
    int buttonId = this.ButtonID;
    for (int index = 1; index < 5; ++index)
    {
      this.ButtonPrompts[index].enabled = false;
      this.ButtonPrompts[index].transform.localPosition = this.ButtonPrompts[buttonId].transform.localPosition;
    }
    while (this.ButtonID == buttonId)
      this.ButtonID = Random.Range(1, 5);
    if (this.ButtonID == 1)
      this.CurrentButton = "A";
    else if (this.ButtonID == 2)
      this.CurrentButton = "B";
    else if (this.ButtonID == 3)
      this.CurrentButton = "X";
    else if (this.ButtonID == 4)
      this.CurrentButton = "Y";
    this.ButtonPrompts[this.ButtonID].enabled = true;
  }
}
