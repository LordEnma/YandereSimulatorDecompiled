using System;
using UnityEngine;

// Token: 0x020004E9 RID: 1257
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x060020F2 RID: 8434 RVA: 0x001E7894 File Offset: 0x001E5A94
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

	// Token: 0x060020F3 RID: 8435 RVA: 0x001E78EA File Offset: 0x001E5AEA
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x04004878 RID: 18552
	public AudioClip BossIntro;

	// Token: 0x04004879 RID: 18553
	public AudioClip BossMain;

	// Token: 0x0400487A RID: 18554
	public AudioClip ApproachIntro;

	// Token: 0x0400487B RID: 18555
	public AudioClip ApproachMain;

	// Token: 0x0400487C RID: 18556
	public bool Boss;
}
