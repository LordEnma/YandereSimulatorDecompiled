using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FountainScript : MonoBehaviour
{
	// Token: 0x060014AD RID: 5293 RVA: 0x000CB2DB File Offset: 0x000C94DB
	private void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x060014AE RID: 5294 RVA: 0x000CB300 File Offset: 0x000C9500
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

	// Token: 0x0400206A RID: 8298
	public ParticleSystem Splashes;

	// Token: 0x0400206B RID: 8299
	public UILabel EventSubtitle;

	// Token: 0x0400206C RID: 8300
	public Collider[] Colliders;

	// Token: 0x0400206D RID: 8301
	public bool Drowning;

	// Token: 0x0400206E RID: 8302
	public AudioSource SpraySFX;

	// Token: 0x0400206F RID: 8303
	public AudioSource DropsSFX;

	// Token: 0x04002070 RID: 8304
	public float StartTimer;

	// Token: 0x04002071 RID: 8305
	public float Timer;
}
