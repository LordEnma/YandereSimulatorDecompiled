using System;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014BC RID: 5308 RVA: 0x000CC38F File Offset: 0x000CA58F
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014BD RID: 5309 RVA: 0x000CC3B4 File Offset: 0x000CA5B4
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

	// Token: 0x04002090 RID: 8336
	public ParticleSystem Splashes;

	// Token: 0x04002091 RID: 8337
	public UILabel EventSubtitle;

	// Token: 0x04002092 RID: 8338
	public Collider[] Colliders;

	// Token: 0x04002093 RID: 8339
	public bool Drowning;

	// Token: 0x04002094 RID: 8340
	public AudioSource SpraySFX;

	// Token: 0x04002095 RID: 8341
	public AudioSource DropsSFX;

	// Token: 0x04002096 RID: 8342
	public float StartTimer;

	// Token: 0x04002097 RID: 8343
	public float Timer;
}
