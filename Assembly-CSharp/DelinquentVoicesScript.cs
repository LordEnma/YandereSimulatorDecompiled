using System;
using UnityEngine;

// Token: 0x0200027B RID: 635
public class DelinquentVoicesScript : MonoBehaviour
{
	// Token: 0x0600137A RID: 4986 RVA: 0x000B350E File Offset: 0x000B170E
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			base.enabled = false;
		}
		this.Timer = 5f;
	}

	// Token: 0x0600137B RID: 4987 RVA: 0x000B352C File Offset: 0x000B172C
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

	// Token: 0x04001CB5 RID: 7349
	public YandereScript Yandere;

	// Token: 0x04001CB6 RID: 7350
	public RadioScript Radio;

	// Token: 0x04001CB7 RID: 7351
	public SubtitleScript Subtitle;

	// Token: 0x04001CB8 RID: 7352
	public float Timer;

	// Token: 0x04001CB9 RID: 7353
	public int RandomID;

	// Token: 0x04001CBA RID: 7354
	public int LastID;
}
