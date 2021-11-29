using System;
using UnityEngine;

// Token: 0x02000017 RID: 23
public class MusicAudienceScript : MonoBehaviour
{
	// Token: 0x0600004C RID: 76 RVA: 0x00007518 File Offset: 0x00005718
	private void Start()
	{
		this.JumpStrength += UnityEngine.Random.Range(-0.0001f, 0.0001f);
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00007538 File Offset: 0x00005738
	private void Update()
	{
		if (this.MusicMinigame.Health >= this.Threshold)
		{
			this.Minimum = Mathf.MoveTowards(this.Minimum, 0.2f, Time.deltaTime * 0.1f);
		}
		else
		{
			this.Minimum = Mathf.MoveTowards(this.Minimum, 0f, Time.deltaTime * 0.1f);
		}
		base.transform.localPosition += new Vector3(0f, this.Jump, 0f);
		this.Jump -= Time.deltaTime * 0.01f;
		if (base.transform.localPosition.y < this.Minimum)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, this.Minimum, 0f);
			this.Jump = this.JumpStrength;
		}
	}

	// Token: 0x0400010F RID: 271
	public MusicMinigameScript MusicMinigame;

	// Token: 0x04000110 RID: 272
	public float JumpStrength;

	// Token: 0x04000111 RID: 273
	public float Threshold;

	// Token: 0x04000112 RID: 274
	public float Minimum;

	// Token: 0x04000113 RID: 275
	public float Jump;
}
