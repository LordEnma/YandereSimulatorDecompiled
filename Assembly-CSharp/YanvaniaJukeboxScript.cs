using System;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x060020E7 RID: 8423 RVA: 0x001E5CDC File Offset: 0x001E3EDC
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

	// Token: 0x060020E8 RID: 8424 RVA: 0x001E5D32 File Offset: 0x001E3F32
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x04004848 RID: 18504
	public AudioClip BossIntro;

	// Token: 0x04004849 RID: 18505
	public AudioClip BossMain;

	// Token: 0x0400484A RID: 18506
	public AudioClip ApproachIntro;

	// Token: 0x0400484B RID: 18507
	public AudioClip ApproachMain;

	// Token: 0x0400484C RID: 18508
	public bool Boss;
}
