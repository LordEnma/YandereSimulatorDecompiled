using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014B3 RID: 5299 RVA: 0x000CB92F File Offset: 0x000C9B2F
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014B4 RID: 5300 RVA: 0x000CB954 File Offset: 0x000C9B54
	private void Update()
	{
		if (this.StartTimer < 1f)
		{
			this.StartTimer += Time.deltaTime;
			if (this.StartTimer > 1f)
			{
				this.SpraySFX.gameObject.SetActive(true);
				this.DropsSFX.gameObject.SetActive(true);
			}
		}
		if (this.Drowning)
		{
			if (this.Timer == 0f && this.EventSubtitle.transform.localScale.x < 1f)
			{
				this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				this.EventSubtitle.text = "Hey, what are you -";
				base.GetComponent<AudioSource>().Play();
			}
			this.Timer += Time.deltaTime;
			if (this.Timer > 3f && this.EventSubtitle.transform.localScale.x > 0f)
			{
				this.EventSubtitle.transform.localScale = Vector3.zero;
				this.EventSubtitle.text = string.Empty;
				this.Splashes.Play();
			}
			if (this.Timer > 9f)
			{
				this.Drowning = false;
				this.Splashes.Stop();
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x04002077 RID: 8311
	public ParticleSystem Splashes;

	// Token: 0x04002078 RID: 8312
	public UILabel EventSubtitle;

	// Token: 0x04002079 RID: 8313
	public Collider[] Colliders;

	// Token: 0x0400207A RID: 8314
	public bool Drowning;

	// Token: 0x0400207B RID: 8315
	public AudioSource SpraySFX;

	// Token: 0x0400207C RID: 8316
	public AudioSource DropsSFX;

	// Token: 0x0400207D RID: 8317
	public float StartTimer;

	// Token: 0x0400207E RID: 8318
	public float Timer;
}
