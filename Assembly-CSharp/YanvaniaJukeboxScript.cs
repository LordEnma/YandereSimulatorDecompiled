using System;
using UnityEngine;

// Token: 0x020004DE RID: 1246
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x060020A8 RID: 8360 RVA: 0x001E0024 File Offset: 0x001DE224
	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (component.time + Time.deltaTime > component.clip.length)
		{
			component.clip = (this.Boss ? this.BossMain : this.ApproachMain);
			component.loop = true;
			component.Play();
		}
	}

	// Token: 0x060020A9 RID: 8361 RVA: 0x001E007A File Offset: 0x001DE27A
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x0400478C RID: 18316
	public AudioClip BossIntro;

	// Token: 0x0400478D RID: 18317
	public AudioClip BossMain;

	// Token: 0x0400478E RID: 18318
	public AudioClip ApproachIntro;

	// Token: 0x0400478F RID: 18319
	public AudioClip ApproachMain;

	// Token: 0x04004790 RID: 18320
	public bool Boss;
}
