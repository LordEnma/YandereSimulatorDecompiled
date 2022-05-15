using System;
using UnityEngine;

// Token: 0x020004E9 RID: 1257
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x060020F1 RID: 8433 RVA: 0x001E732C File Offset: 0x001E552C
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

	// Token: 0x060020F2 RID: 8434 RVA: 0x001E7382 File Offset: 0x001E5582
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x0400486F RID: 18543
	public AudioClip BossIntro;

	// Token: 0x04004870 RID: 18544
	public AudioClip BossMain;

	// Token: 0x04004871 RID: 18545
	public AudioClip ApproachIntro;

	// Token: 0x04004872 RID: 18546
	public AudioClip ApproachMain;

	// Token: 0x04004873 RID: 18547
	public bool Boss;
}
