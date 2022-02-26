using System;
using UnityEngine;

// Token: 0x0200027B RID: 635
public class DelinquentVoicesScript : MonoBehaviour
{
	// Token: 0x06001372 RID: 4978 RVA: 0x000B293E File Offset: 0x000B0B3E
	private void Start()
	{
		this.Timer = 5f;
	}

	// Token: 0x06001373 RID: 4979 RVA: 0x000B294C File Offset: 0x000B0B4C
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

	// Token: 0x04001C92 RID: 7314
	public YandereScript Yandere;

	// Token: 0x04001C93 RID: 7315
	public RadioScript Radio;

	// Token: 0x04001C94 RID: 7316
	public SubtitleScript Subtitle;

	// Token: 0x04001C95 RID: 7317
	public float Timer;

	// Token: 0x04001C96 RID: 7318
	public int RandomID;

	// Token: 0x04001C97 RID: 7319
	public int LastID;
}
