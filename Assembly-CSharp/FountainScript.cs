using System;
using UnityEngine;

// Token: 0x020002D5 RID: 725
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014C2 RID: 5314 RVA: 0x000CCA3B File Offset: 0x000CAC3B
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014C3 RID: 5315 RVA: 0x000CCA60 File Offset: 0x000CAC60
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

	// Token: 0x040020A5 RID: 8357
	public ParticleSystem Splashes;

	// Token: 0x040020A6 RID: 8358
	public UILabel EventSubtitle;

	// Token: 0x040020A7 RID: 8359
	public Collider[] Colliders;

	// Token: 0x040020A8 RID: 8360
	public bool Drowning;

	// Token: 0x040020A9 RID: 8361
	public AudioSource SpraySFX;

	// Token: 0x040020AA RID: 8362
	public AudioSource DropsSFX;

	// Token: 0x040020AB RID: 8363
	public float StartTimer;

	// Token: 0x040020AC RID: 8364
	public float Timer;
}
