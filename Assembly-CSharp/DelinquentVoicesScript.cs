using System;
using UnityEngine;

// Token: 0x0200027A RID: 634
public class DelinquentVoicesScript : MonoBehaviour
{
	// Token: 0x0600136D RID: 4973 RVA: 0x000B25EA File Offset: 0x000B07EA
	private void Start()
	{
		this.Timer = 5f;
	}

	// Token: 0x0600136E RID: 4974 RVA: 0x000B25F8 File Offset: 0x000B07F8
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

	// Token: 0x04001C88 RID: 7304
	public YandereScript Yandere;

	// Token: 0x04001C89 RID: 7305
	public RadioScript Radio;

	// Token: 0x04001C8A RID: 7306
	public SubtitleScript Subtitle;

	// Token: 0x04001C8B RID: 7307
	public float Timer;

	// Token: 0x04001C8C RID: 7308
	public int RandomID;

	// Token: 0x04001C8D RID: 7309
	public int LastID;
}
