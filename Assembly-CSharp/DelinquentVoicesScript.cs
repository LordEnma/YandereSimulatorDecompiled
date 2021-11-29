using System;
using UnityEngine;

// Token: 0x02000279 RID: 633
public class DelinquentVoicesScript : MonoBehaviour
{
	// Token: 0x06001366 RID: 4966 RVA: 0x000B1DC2 File Offset: 0x000AFFC2
	private void Start()
	{
		this.Timer = 5f;
	}

	// Token: 0x06001367 RID: 4967 RVA: 0x000B1DD0 File Offset: 0x000AFFD0
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

	// Token: 0x04001C63 RID: 7267
	public YandereScript Yandere;

	// Token: 0x04001C64 RID: 7268
	public RadioScript Radio;

	// Token: 0x04001C65 RID: 7269
	public SubtitleScript Subtitle;

	// Token: 0x04001C66 RID: 7270
	public float Timer;

	// Token: 0x04001C67 RID: 7271
	public int RandomID;

	// Token: 0x04001C68 RID: 7272
	public int LastID;
}
