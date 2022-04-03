using System;
using UnityEngine;

// Token: 0x020004E6 RID: 1254
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x060020CE RID: 8398 RVA: 0x001E37C8 File Offset: 0x001E19C8
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

	// Token: 0x060020CF RID: 8399 RVA: 0x001E381E File Offset: 0x001E1A1E
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x0400481C RID: 18460
	public AudioClip BossIntro;

	// Token: 0x0400481D RID: 18461
	public AudioClip BossMain;

	// Token: 0x0400481E RID: 18462
	public AudioClip ApproachIntro;

	// Token: 0x0400481F RID: 18463
	public AudioClip ApproachMain;

	// Token: 0x04004820 RID: 18464
	public bool Boss;
}
