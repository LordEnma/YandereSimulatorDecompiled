// Decompiled with JetBrains decompiler
// Type: BucketPourScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BucketPourScript : MonoBehaviour
{
  public SplashCameraScript SplashCamera;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public string PourHeight = string.Empty;
  public float PourDistance;
  public float PourTime;
  public int ID;

  private void Start()
  {
  }

  private void Update()
  {
    if ((Object) this.Yandere.PickUp != (Object) null)
    {
      if ((Object) this.Yandere.PickUp.Bucket != (Object) null)
      {
        if (this.Yandere.PickUp.Bucket.Full)
        {
          if (!this.Prompt.enabled)
          {
            this.Prompt.Label[0].text = "     Pour";
            this.Prompt.enabled = true;
          }
        }
        else if (this.Yandere.PickUp.Bucket.Dumbbells == 5)
        {
          if (!this.Prompt.enabled)
          {
            this.Prompt.Label[0].text = "     Drop";
            this.Prompt.enabled = true;
          }
        }
        else if (this.Prompt.enabled)
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      }
      else if (this.Prompt.enabled)
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else if (this.Prompt.enabled)
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if ((Object) this.Prompt.Circle[0] != (Object) null && (double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
      {
        if (this.Yandere.PickUp.Bucket.Dumbbells == 5)
        {
          this.Yandere.CharacterAnimation.CrossFade("f02_bucketDrop_00");
          this.Yandere.MyController.radius = 0.0f;
          this.Yandere.BucketDropping = true;
          this.Yandere.DropSpot = this.transform;
          this.Yandere.CanMove = false;
        }
        else
        {
          this.Yandere.Stool = this.transform;
          this.Yandere.CanMove = false;
          this.Yandere.Pouring = true;
          this.Yandere.PourDistance = this.PourDistance;
          this.Yandere.PourHeight = this.PourHeight;
          this.Yandere.PourTime = this.PourTime;
        }
      }
    }
    if (this.Yandere.Pouring)
    {
      if (!Input.GetButtonDown("B") || (double) this.Prompt.DistanceSqr >= 1.0)
        return;
      this.SplashCamera.Show = true;
      this.SplashCamera.MyCamera.enabled = true;
      if (this.ID == 1)
      {
        this.SplashCamera.transform.position = new Vector3(32.1f, 0.8f, 26.9f);
        this.SplashCamera.transform.eulerAngles = new Vector3(0.0f, -45f, 0.0f);
      }
      else
      {
        this.SplashCamera.transform.position = new Vector3(1.1f, 0.8f, 32.1f);
        this.SplashCamera.transform.eulerAngles = new Vector3(0.0f, -135f, 0.0f);
      }
    }
    else
    {
      if (!this.Yandere.BucketDropping || !Input.GetButtonDown("B") || (double) this.Prompt.DistanceSqr >= 1.0)
        return;
      this.SplashCamera.Show = true;
      this.SplashCamera.MyCamera.enabled = true;
      if (this.ID == 1)
      {
        this.SplashCamera.transform.position = new Vector3(32.1f, 0.8f, 26.9f);
        this.SplashCamera.transform.eulerAngles = new Vector3(0.0f, -45f, 0.0f);
      }
      else
      {
        this.SplashCamera.transform.position = new Vector3(1.1f, 0.8f, 32.1f);
        this.SplashCamera.transform.eulerAngles = new Vector3(0.0f, -135f, 0.0f);
      }
    }
  }
}
