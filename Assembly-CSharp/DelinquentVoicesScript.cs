using System;
using UnityEngine;

// Token: 0x0200027C RID: 636
public class DelinquentVoicesScript : MonoBehaviour
{
	// Token: 0x0600137C RID: 4988 RVA: 0x000B3822 File Offset: 0x000B1A22
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			base.enabled = false;
		}
		this.Timer = 5f;
	}

	// Token: 0x0600137D RID: 4989 RVA: 0x000B3840 File Offset: 0x000B1A40
	private void Update()
	{
		if (this.Radio != null)
		{
			if (this.Radio.MyAudio.isPlaying && this.Yandere.CanMove && Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 5f)
			{
				this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
				if (this.Timer == 0f && this.Yandere.Club != ClubType.Delinquent)
				{
					if (this.Yandere.Container != null && this.Yandere.Container.CelloCase)
					{
						while (this.RandomID == this.LastID)
						{
							this.RandomID = UnityEngine.Random.Range(0, this.Subtitle.DelinquentCaseClips.Length);
						}
						this.LastID = this.RandomID;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentCase, this.RandomID, 3f);
					}
					else
					{
						while (this.RandomID == this.LastID)
						{
							this.RandomID = UnityEngine.Random.Range(0, this.Subtitle.DelinquentAnnoyClips.Length);
						}
						this.LastID = this.RandomID;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentAnnoy, this.RandomID, 3f);
					}
					this.Timer = 5f;
					return;
				}
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001CBC RID: 7356
	public YandereScript Yandere;

	// Token: 0x04001CBD RID: 7357
	public RadioScript Radio;

	// Token: 0x04001CBE RID: 7358
	public SubtitleScript Subtitle;

	// Token: 0x04001CBF RID: 7359
	public float Timer;

	// Token: 0x04001CC0 RID: 7360
	public int RandomID;

	// Token: 0x04001CC1 RID: 7361
	public int LastID;
}
