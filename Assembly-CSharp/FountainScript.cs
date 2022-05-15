using System;
using UnityEngine;

// Token: 0x020002D7 RID: 727
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014D0 RID: 5328 RVA: 0x000CD4BF File Offset: 0x000CB6BF
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014D1 RID: 5329 RVA: 0x000CD4E4 File Offset: 0x000CB6E4
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

	// Token: 0x040020BB RID: 8379
	public ParticleSystem Splashes;

	// Token: 0x040020BC RID: 8380
	public UILabel EventSubtitle;

	// Token: 0x040020BD RID: 8381
	public Collider[] Colliders;

	// Token: 0x040020BE RID: 8382
	public bool Drowning;

	// Token: 0x040020BF RID: 8383
	public AudioSource SpraySFX;

	// Token: 0x040020C0 RID: 8384
	public AudioSource DropsSFX;

	// Token: 0x040020C1 RID: 8385
	public float StartTimer;

	// Token: 0x040020C2 RID: 8386
	public float Timer;
}
