using System;
using UnityEngine;

// Token: 0x020002D6 RID: 726
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014CE RID: 5326 RVA: 0x000CD1BF File Offset: 0x000CB3BF
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014CF RID: 5327 RVA: 0x000CD1E4 File Offset: 0x000CB3E4
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

	// Token: 0x040020B2 RID: 8370
	public ParticleSystem Splashes;

	// Token: 0x040020B3 RID: 8371
	public UILabel EventSubtitle;

	// Token: 0x040020B4 RID: 8372
	public Collider[] Colliders;

	// Token: 0x040020B5 RID: 8373
	public bool Drowning;

	// Token: 0x040020B6 RID: 8374
	public AudioSource SpraySFX;

	// Token: 0x040020B7 RID: 8375
	public AudioSource DropsSFX;

	// Token: 0x040020B8 RID: 8376
	public float StartTimer;

	// Token: 0x040020B9 RID: 8377
	public float Timer;
}
