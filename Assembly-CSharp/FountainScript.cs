using System;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014BF RID: 5311 RVA: 0x000CC7FF File Offset: 0x000CA9FF
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014C0 RID: 5312 RVA: 0x000CC824 File Offset: 0x000CAA24
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

	// Token: 0x040020A0 RID: 8352
	public ParticleSystem Splashes;

	// Token: 0x040020A1 RID: 8353
	public UILabel EventSubtitle;

	// Token: 0x040020A2 RID: 8354
	public Collider[] Colliders;

	// Token: 0x040020A3 RID: 8355
	public bool Drowning;

	// Token: 0x040020A4 RID: 8356
	public AudioSource SpraySFX;

	// Token: 0x040020A5 RID: 8357
	public AudioSource DropsSFX;

	// Token: 0x040020A6 RID: 8358
	public float StartTimer;

	// Token: 0x040020A7 RID: 8359
	public float Timer;
}
