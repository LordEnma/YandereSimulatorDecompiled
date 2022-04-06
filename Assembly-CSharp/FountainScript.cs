using System;
using UnityEngine;

// Token: 0x020002D6 RID: 726
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014C8 RID: 5320 RVA: 0x000CCB43 File Offset: 0x000CAD43
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014C9 RID: 5321 RVA: 0x000CCB68 File Offset: 0x000CAD68
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

	// Token: 0x040020A7 RID: 8359
	public ParticleSystem Splashes;

	// Token: 0x040020A8 RID: 8360
	public UILabel EventSubtitle;

	// Token: 0x040020A9 RID: 8361
	public Collider[] Colliders;

	// Token: 0x040020AA RID: 8362
	public bool Drowning;

	// Token: 0x040020AB RID: 8363
	public AudioSource SpraySFX;

	// Token: 0x040020AC RID: 8364
	public AudioSource DropsSFX;

	// Token: 0x040020AD RID: 8365
	public float StartTimer;

	// Token: 0x040020AE RID: 8366
	public float Timer;
}
