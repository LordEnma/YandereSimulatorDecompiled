using System;
using UnityEngine;

// Token: 0x0200027B RID: 635
public class DelinquentVoicesScript : MonoBehaviour
{
	// Token: 0x06001376 RID: 4982 RVA: 0x000B2F4A File Offset: 0x000B114A
	private void Start()
	{
		this.Timer = 5f;
	}

	// Token: 0x06001377 RID: 4983 RVA: 0x000B2F58 File Offset: 0x000B1158
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

	// Token: 0x04001CAC RID: 7340
	public YandereScript Yandere;

	// Token: 0x04001CAD RID: 7341
	public RadioScript Radio;

	// Token: 0x04001CAE RID: 7342
	public SubtitleScript Subtitle;

	// Token: 0x04001CAF RID: 7343
	public float Timer;

	// Token: 0x04001CB0 RID: 7344
	public int RandomID;

	// Token: 0x04001CB1 RID: 7345
	public int LastID;
}
