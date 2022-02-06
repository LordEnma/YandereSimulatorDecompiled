using System;
using UnityEngine;

// Token: 0x020000FE RID: 254
public class BucketPourScript : MonoBehaviour
{
	// Token: 0x06000A85 RID: 2693 RVA: 0x0005CD62 File Offset: 0x0005AF62
	private void Start()
	{
	}

	// Token: 0x06000A86 RID: 2694 RVA: 0x0005CD64 File Offset: 0x0005AF64
	private void Update()
	{
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket != null)
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
		if (this.Prompt.Circle[0] != null && this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				if (this.Yandere.PickUp.Bucket.Dumbbells == 5)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_bucketDrop_00");
					this.Yandere.MyController.radius = 0f;
					this.Yandere.BucketDropping = true;
					this.Yandere.DropSpot = base.transform;
					this.Yandere.CanMove = false;
				}
				else
				{
					this.Yandere.Stool = base.transform;
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
			if (Input.GetButtonDown("B") && this.Prompt.DistanceSqr < 1f)
			{
				this.SplashCamera.Show = true;
				this.SplashCamera.MyCamera.enabled = true;
				if (this.ID == 1)
				{
					this.SplashCamera.transform.position = new Vector3(32.1f, 0.8f, 26.9f);
					this.SplashCamera.transform.eulerAngles = new Vector3(0f, -45f, 0f);
					return;
				}
				this.SplashCamera.transform.position = new Vector3(1.1f, 0.8f, 32.1f);
				this.SplashCamera.transform.eulerAngles = new Vector3(0f, -135f, 0f);
				return;
			}
		}
		else if (this.Yandere.BucketDropping && Input.GetButtonDown("B") && this.Prompt.DistanceSqr < 1f)
		{
			this.SplashCamera.Show = true;
			this.SplashCamera.MyCamera.enabled = true;
			if (this.ID == 1)
			{
				this.SplashCamera.transform.position = new Vector3(32.1f, 0.8f, 26.9f);
				this.SplashCamera.transform.eulerAngles = new Vector3(0f, -45f, 0f);
				return;
			}
			this.SplashCamera.transform.position = new Vector3(1.1f, 0.8f, 32.1f);
			this.SplashCamera.transform.eulerAngles = new Vector3(0f, -135f, 0f);
		}
	}

	// Token: 0x04000C37 RID: 3127
	public SplashCameraScript SplashCamera;

	// Token: 0x04000C38 RID: 3128
	public YandereScript Yandere;

	// Token: 0x04000C39 RID: 3129
	public PromptScript Prompt;

	// Token: 0x04000C3A RID: 3130
	public string PourHeight = string.Empty;

	// Token: 0x04000C3B RID: 3131
	public float PourDistance;

	// Token: 0x04000C3C RID: 3132
	public float PourTime;

	// Token: 0x04000C3D RID: 3133
	public int ID;
}
