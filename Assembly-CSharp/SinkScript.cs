using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class SinkScript : MonoBehaviour
{
	// Token: 0x06001CAB RID: 7339 RVA: 0x00153AE5 File Offset: 0x00151CE5
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001CAC RID: 7340 RVA: 0x00153AFC File Offset: 0x00151CFC
	private void Update()
	{
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket != null)
			{
				if (this.Yandere.PickUp.Bucket.Dumbbells == 0)
				{
					this.Prompt.enabled = true;
					if (!this.Yandere.PickUp.Bucket.Full)
					{
						this.Prompt.Label[0].text = "     Fill Bucket";
					}
					else
					{
						this.Prompt.Label[0].text = "     Empty Bucket";
					}
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.Yandere.PickUp.BloodCleaner != null)
			{
				if (this.Yandere.PickUp.BloodCleaner.Blood > 0f)
				{
					this.Prompt.Label[0].text = "     Empty Robot";
					this.Prompt.enabled = true;
				}
				else
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
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Yandere.PickUp.Bucket != null)
			{
				if (!this.Yandere.PickUp.Bucket.Full)
				{
					this.Yandere.PickUp.Bucket.Fill();
				}
				else
				{
					this.Yandere.PickUp.Bucket.Empty();
				}
				if (!this.Yandere.PickUp.Bucket.Full)
				{
					this.Prompt.Label[0].text = "     Fill Bucket";
				}
				else
				{
					this.Prompt.Label[0].text = "     Empty Bucket";
				}
			}
			else if (this.Yandere.PickUp.BloodCleaner != null)
			{
				this.Yandere.PickUp.BloodCleaner.Blood = 0f;
				this.Yandere.PickUp.BloodCleaner.Lens.SetActive(false);
			}
			this.Prompt.Circle[0].fillAmount = 1f;
		}
	}

	// Token: 0x0400335D RID: 13149
	public YandereScript Yandere;

	// Token: 0x0400335E RID: 13150
	public PromptScript Prompt;
}
