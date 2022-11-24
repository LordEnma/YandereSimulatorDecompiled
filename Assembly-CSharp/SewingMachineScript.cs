// Decompiled with JetBrains decompiler
// Type: SewingMachineScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SewingMachineScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public Quaternion targetRotation;
  public PickUpScript Uniform;
  public Collider Chair;
  public bool MoveAway;
  public bool Sewing;
  public bool Check;
  public float Timer;

  private void Start()
  {
    if (this.StudentManager.TaskManager.TaskStatus[30] == 1)
    {
      this.Check = true;
    }
    else
    {
      if (this.StudentManager.TaskManager.TaskStatus[30] <= 2)
        return;
      this.enabled = false;
    }
  }

  private void Update()
  {
    if (this.Check)
    {
      if ((Object) this.Yandere.PickUp != (Object) null)
      {
        if (this.Yandere.PickUp.Clothing && this.Yandere.PickUp.GetComponent<FoldedUniformScript>().Clean && this.Yandere.PickUp.GetComponent<FoldedUniformScript>().Type == 1 && this.Yandere.PickUp.gameObject.GetComponent<FoldedUniformScript>().Type == 1)
          this.Prompt.enabled = true;
      }
      else
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
      {
        this.Yandere.CharacterAnimation.CrossFade("f02_sewing_00");
        this.Yandere.MyController.radius = 0.1f;
        this.Yandere.CanMove = false;
        this.Chair.enabled = false;
        this.Sewing = true;
        this.GetComponent<AudioSource>().Play();
        this.Uniform = this.Yandere.PickUp;
        this.Yandere.EmptyHands();
        this.Uniform.transform.parent = this.Yandere.RightHand;
        this.Uniform.transform.localPosition = new Vector3(0.0f, 0.0f, 0.09f);
        this.Uniform.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.Uniform.MyRigidbody.useGravity = false;
        this.Uniform.MyCollider.enabled = false;
      }
    }
    if (!this.Sewing)
      return;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer < 5.0)
    {
      this.targetRotation = Quaternion.LookRotation(this.transform.parent.transform.parent.position - this.Yandere.transform.position);
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
      this.Yandere.MoveTowardsTarget(this.Chair.transform.position);
    }
    else if (!this.MoveAway)
    {
      this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
      this.Yandere.Inventory.ModifiedUniform = true;
      this.StudentManager.Students[30].TaskPhase = 5;
      this.StudentManager.TaskManager.TaskStatus[30] = 2;
      Object.Destroy((Object) this.Uniform.gameObject);
      this.MoveAway = true;
      this.Check = false;
    }
    else
    {
      this.Yandere.MoveTowardsTarget(this.Chair.gameObject.transform.position + new Vector3(-0.5f, 0.0f, 0.0f));
      if ((double) this.Timer <= 6.0)
        return;
      this.Yandere.MyController.radius = 0.2f;
      this.Yandere.CanMove = true;
      this.Chair.enabled = true;
      this.enabled = false;
      this.Sewing = false;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
  }
}
