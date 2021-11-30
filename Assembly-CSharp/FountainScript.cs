using System;
using UnityEngine;

// Token: 0x020002D0 RID: 720
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014A2 RID: 5282 RVA: 0x000CA523 File Offset: 0x000C8723
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014A3 RID: 5283 RVA: 0x000CA548 File Offset: 0x000C8748
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

	// Token: 0x04002040 RID: 8256
	public ParticleSystem Splashes;

	// Token: 0x04002041 RID: 8257
	public UILabel EventSubtitle;

	// Token: 0x04002042 RID: 8258
	public Collider[] Colliders;

	// Token: 0x04002043 RID: 8259
	public bool Drowning;

	// Token: 0x04002044 RID: 8260
	public AudioSource SpraySFX;

	// Token: 0x04002045 RID: 8261
	public AudioSource DropsSFX;

	// Token: 0x04002046 RID: 8262
	public float StartTimer;

	// Token: 0x04002047 RID: 8263
	public float Timer;
}
