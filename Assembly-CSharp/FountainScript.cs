using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014A9 RID: 5289 RVA: 0x000CACC7 File Offset: 0x000C8EC7
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014AA RID: 5290 RVA: 0x000CACEC File Offset: 0x000C8EEC
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

	// Token: 0x04002060 RID: 8288
	public ParticleSystem Splashes;

	// Token: 0x04002061 RID: 8289
	public UILabel EventSubtitle;

	// Token: 0x04002062 RID: 8290
	public Collider[] Colliders;

	// Token: 0x04002063 RID: 8291
	public bool Drowning;

	// Token: 0x04002064 RID: 8292
	public AudioSource SpraySFX;

	// Token: 0x04002065 RID: 8293
	public AudioSource DropsSFX;

	// Token: 0x04002066 RID: 8294
	public float StartTimer;

	// Token: 0x04002067 RID: 8295
	public float Timer;
}
