using System;
using UnityEngine;

// Token: 0x0200042D RID: 1069
public class SinkScript : MonoBehaviour
{
	// Token: 0x06001CCF RID: 7375 RVA: 0x00156201 File Offset: 0x00154401
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001CD0 RID: 7376 RVA: 0x00156218 File Offset: 0x00154418
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

	// Token: 0x040033D2 RID: 13266
	public YandereScript Yandere;

	// Token: 0x040033D3 RID: 13267
	public PromptScript Prompt;
}
