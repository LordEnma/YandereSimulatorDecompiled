using System;
using UnityEngine;

// Token: 0x0200028C RID: 652
public class DoorGapScript : MonoBehaviour
{
	// Token: 0x060013AA RID: 5034 RVA: 0x000B8917 File Offset: 0x000B6B17
	private void Start()
	{
		this.Papers[1].gameObject.SetActive(false);
	}

	// Token: 0x060013AB RID: 5035 RVA: 0x000B892C File Offset: 0x000B6B2C
	private void Update()
	{
		if (!this.StolenPhoneDropoff)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				if (this.Phase == 1)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Prompt.Yandere.Inventory.AnswerSheet = false;
					this.Papers[1].gameObject.SetActive(true);
					SchemeGlobals.SetSchemeStage(5, 6);
					this.Schemes.UpdateInstructions();
					base.GetComponent<AudioSource>().Play();
				}
				else
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Prompt.Yandere.Inventory.AnswerSheet = true;
					this.Prompt.Yandere.Inventory.DuplicateSheet = true;
					this.Papers[2].gameObject.SetActive(false);
					this.RummageSpot.Prompt.Label[0].text = "     Return Answer Sheet";
					this.RummageSpot.Prompt.enabled = true;
					SchemeGlobals.SetSchemeStage(5, 7);
					this.Schemes.UpdateInstructions();
				}
				this.Phase++;
			}
			if (this.Phase == 2)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 4f)
				{
					this.Prompt.Label[0].text = "     Pick Up Sheets";
					this.Prompt.enabled = true;
					this.Phase = 2;
					return;
				}
				if (this.Timer > 3f)
				{
					Transform transform = this.Papers[2];
					transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, -0.166f, Time.deltaTime * 10f));
					return;
				}
				if (this.Timer > 1f)
				{
					Transform transform2 = this.Papers[1];
					transform2.localPosition = new Vector3(transform2.localPosition.x, transform2.localPosition.y, Mathf.Lerp(transform2.localPosition.z, 0.166f, Time.deltaTime * 10f));
					return;
				}
			}
		}
		else
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.Phase == 1)
				{
					if (StudentGlobals.GetStudentPhoneStolen(this.Prompt.Yandere.StudentManager.CommunalLocker.RivalPhone.StudentID))
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "Info-chan doesn't need this phone";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else
					{
						this.Prompt.Hide();
						this.Prompt.enabled = false;
						this.Prompt.Yandere.Inventory.RivalPhone = false;
						this.Prompt.Yandere.RivalPhone = false;
						this.PhoneHacked[this.Prompt.Yandere.StudentManager.CommunalLocker.RivalPhone.StudentID] = true;
						this.Prompt.Yandere.Inventory.PantyShots += 20;
						this.Prompt.Yandere.NotificationManager.CustomText = "+20 Info Points! You have " + this.Prompt.Yandere.Inventory.PantyShots.ToString() + " in total";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						this.Papers[1].gameObject.SetActive(true);
						base.GetComponent<AudioSource>().Play();
						this.Phase++;
					}
				}
				else if (this.Phase == 2)
				{
					this.Prompt.Yandere.Inventory.RivalPhone = true;
					this.Papers[1].gameObject.SetActive(false);
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Phase++;
				}
			}
			if (this.Phase == 2)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 4f)
				{
					this.Prompt.Label[0].text = "     Pick Up Phone";
					this.Prompt.enabled = true;
					return;
				}
				if (this.Timer > 3f)
				{
					this.Papers[1].localPosition = new Vector3(this.Papers[1].localPosition.x, this.Papers[1].localPosition.y, Mathf.Lerp(this.Papers[1].localPosition.z, -0.166f, Time.deltaTime * 10f));
					return;
				}
				if (this.Timer > 1f)
				{
					this.Papers[1].localPosition = new Vector3(this.Papers[1].localPosition.x, this.Papers[1].localPosition.y, Mathf.Lerp(this.Papers[1].localPosition.z, 0.166f, Time.deltaTime * 10f));
				}
			}
		}
	}

	// Token: 0x060013AC RID: 5036 RVA: 0x000B8E94 File Offset: 0x000B7094
	public void SetPhonesHacked()
	{
		for (int i = 1; i < 101; i++)
		{
			if (this.PhoneHacked[i])
			{
				StudentGlobals.SetStudentPhoneStolen(i, true);
			}
		}
	}

	// Token: 0x04001D2C RID: 7468
	public RummageSpotScript RummageSpot;

	// Token: 0x04001D2D RID: 7469
	public SchemesScript Schemes;

	// Token: 0x04001D2E RID: 7470
	public PromptScript Prompt;

	// Token: 0x04001D2F RID: 7471
	public Transform[] Papers;

	// Token: 0x04001D30 RID: 7472
	public bool[] PhoneHacked;

	// Token: 0x04001D31 RID: 7473
	public bool StolenPhoneDropoff;

	// Token: 0x04001D32 RID: 7474
	public float Timer;

	// Token: 0x04001D33 RID: 7475
	public int Phase = 1;
}
