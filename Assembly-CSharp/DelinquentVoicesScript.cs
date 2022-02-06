using System;
using UnityEngine;

// Token: 0x0200027A RID: 634
public class DelinquentVoicesScript : MonoBehaviour
{
	// Token: 0x0600136E RID: 4974 RVA: 0x000B2802 File Offset: 0x000B0A02
	private void Start()
	{
		this.Timer = 5f;
	}

	// Token: 0x0600136F RID: 4975 RVA: 0x000B2810 File Offset: 0x000B0A10
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

	// Token: 0x04001C8E RID: 7310
	public YandereScript Yandere;

	// Token: 0x04001C8F RID: 7311
	public RadioScript Radio;

	// Token: 0x04001C90 RID: 7312
	public SubtitleScript Subtitle;

	// Token: 0x04001C91 RID: 7313
	public float Timer;

	// Token: 0x04001C92 RID: 7314
	public int RandomID;

	// Token: 0x04001C93 RID: 7315
	public int LastID;
}
