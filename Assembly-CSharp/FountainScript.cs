using System;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014BC RID: 5308 RVA: 0x000CC213 File Offset: 0x000CA413
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014BD RID: 5309 RVA: 0x000CC238 File Offset: 0x000CA438
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

	// Token: 0x04002086 RID: 8326
	public ParticleSystem Splashes;

	// Token: 0x04002087 RID: 8327
	public UILabel EventSubtitle;

	// Token: 0x04002088 RID: 8328
	public Collider[] Colliders;

	// Token: 0x04002089 RID: 8329
	public bool Drowning;

	// Token: 0x0400208A RID: 8330
	public AudioSource SpraySFX;

	// Token: 0x0400208B RID: 8331
	public AudioSource DropsSFX;

	// Token: 0x0400208C RID: 8332
	public float StartTimer;

	// Token: 0x0400208D RID: 8333
	public float Timer;
}
