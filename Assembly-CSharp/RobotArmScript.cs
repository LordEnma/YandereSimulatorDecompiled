// Decompiled with JetBrains decompiler
// Type: RobotArmScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RobotArmScript : MonoBehaviour
{
  public SkinnedMeshRenderer RobotArms;
  public AudioSource MyAudio;
  public PromptScript Prompt;
  public Transform TerminalTarget;
  public ParticleSystem[] Sparks;
  public AudioClip ArmsOff;
  public AudioClip ArmsOn;
  public float StartWorkTimer;
  public float StopWorkTimer;
  public float[] ArmValue;
  public float[] Timer;
  public bool UpdateArms;
  public bool Work;
  public bool[] On;
  public int ID;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      this.ActivateArms();
    if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
      this.ToggleWork();
    if (this.UpdateArms)
    {
      if (this.On[0])
      {
        this.ArmValue[0] = Mathf.Lerp(this.ArmValue[0], 0.0f, Time.deltaTime * 5f);
        this.RobotArms.SetBlendShapeWeight(0, this.ArmValue[0]);
        if ((double) this.ArmValue[0] < 0.10000000149011612)
        {
          this.RobotArms.SetBlendShapeWeight(0, 0.0f);
          this.UpdateArms = false;
          this.ArmValue[0] = 0.0f;
        }
      }
      else
      {
        this.ArmValue[0] = Mathf.Lerp(this.ArmValue[0], 100f, Time.deltaTime * 5f);
        this.RobotArms.SetBlendShapeWeight(0, this.ArmValue[0]);
        if ((double) this.ArmValue[0] > 99.9000015258789)
        {
          this.RobotArms.SetBlendShapeWeight(0, 100f);
          this.UpdateArms = false;
          this.ArmValue[0] = 100f;
        }
      }
    }
    if (this.Work)
    {
      if ((double) this.StartWorkTimer > 0.0)
      {
        for (this.ID = 1; this.ID < 9; this.ID += 2)
        {
          this.ArmValue[this.ID] = Mathf.Lerp(this.ArmValue[this.ID], 100f, Time.deltaTime * 5f);
          this.RobotArms.SetBlendShapeWeight(this.ID, this.ArmValue[this.ID]);
        }
        this.StartWorkTimer -= Time.deltaTime;
        if ((double) this.StartWorkTimer >= 0.0)
          return;
        for (this.ID = 1; this.ID < 9; this.ID += 2)
          this.RobotArms.SetBlendShapeWeight(this.ID, 100f);
      }
      else
      {
        for (this.ID = 1; this.ID < 9; this.ID += 2)
        {
          this.Timer[this.ID] -= Time.deltaTime;
          if ((double) this.Timer[this.ID] < 0.0)
          {
            this.Sparks[this.ID].Stop();
            this.Sparks[this.ID + 1].Stop();
            this.On[this.ID] = Random.Range(0, 2) == 1;
            this.Timer[this.ID] = Random.Range(1f, 2f);
          }
          if (this.On[this.ID])
          {
            this.ArmValue[this.ID] = Mathf.Lerp(this.ArmValue[this.ID], 0.0f, Time.deltaTime * 5f);
            this.ArmValue[this.ID + 1] = Mathf.Lerp(this.ArmValue[this.ID + 1], 100f, Time.deltaTime * 5f);
            this.RobotArms.SetBlendShapeWeight(this.ID, this.ArmValue[this.ID]);
            this.RobotArms.SetBlendShapeWeight(this.ID + 1, this.ArmValue[this.ID + 1]);
            if ((double) this.ArmValue[this.ID] < 1.0)
            {
              this.Sparks[this.ID].Play();
              this.RobotArms.SetBlendShapeWeight(this.ID, 0.0f);
              this.RobotArms.SetBlendShapeWeight(this.ID + 1, 100f);
              this.ArmValue[this.ID] = 0.0f;
              this.ArmValue[this.ID + 1] = 100f;
            }
          }
          else
          {
            this.ArmValue[this.ID] = Mathf.Lerp(this.ArmValue[this.ID], 100f, Time.deltaTime * 5f);
            this.ArmValue[this.ID + 1] = Mathf.Lerp(this.ArmValue[this.ID + 1], 0.0f, Time.deltaTime * 5f);
            this.RobotArms.SetBlendShapeWeight(this.ID, this.ArmValue[this.ID]);
            this.RobotArms.SetBlendShapeWeight(this.ID + 1, this.ArmValue[this.ID + 1]);
            if ((double) this.ArmValue[this.ID] > 99.0)
            {
              this.Sparks[this.ID + 1].Play();
              this.RobotArms.SetBlendShapeWeight(this.ID, 100f);
              this.RobotArms.SetBlendShapeWeight(this.ID + 1, 0.0f);
              this.ArmValue[this.ID] = 100f;
              this.ArmValue[this.ID + 1] = 0.0f;
            }
          }
        }
      }
    }
    else
    {
      if ((double) this.StopWorkTimer <= 0.0)
        return;
      for (this.ID = 1; this.ID < 9; ++this.ID)
      {
        this.ArmValue[this.ID] = Mathf.Lerp(this.ArmValue[this.ID], 0.0f, Time.deltaTime * 5f);
        this.RobotArms.SetBlendShapeWeight(this.ID, this.ArmValue[this.ID]);
        this.Sparks[this.ID].Stop();
      }
      this.StopWorkTimer -= Time.deltaTime;
      if ((double) this.StopWorkTimer >= 0.0)
        return;
      for (this.ID = 1; this.ID < 9; ++this.ID)
      {
        this.RobotArms.SetBlendShapeWeight(this.ID, 0.0f);
        this.On[this.ID] = false;
      }
    }
  }

  public void ActivateArms()
  {
    this.Prompt.Circle[0].fillAmount = 1f;
    this.UpdateArms = true;
    this.On[0] = !this.On[0];
    if (this.On[0])
    {
      this.Prompt.HideButton[1] = false;
      this.MyAudio.clip = this.ArmsOn;
    }
    else
    {
      this.Prompt.HideButton[1] = true;
      this.MyAudio.clip = this.ArmsOff;
      this.StopWorkTimer = 5f;
      this.Work = false;
    }
    this.MyAudio.Play();
  }

  public void ToggleWork()
  {
    this.Prompt.Circle[1].fillAmount = 1f;
    this.StartWorkTimer = 1f;
    this.StopWorkTimer = 5f;
    this.Work = !this.Work;
  }
}
