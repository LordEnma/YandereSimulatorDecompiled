using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x06002089 RID: 8329 RVA: 0x001DD7FC File Offset: 0x001DB9FC
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

	// Token: 0x0600208A RID: 8330 RVA: 0x001DD852 File Offset: 0x001DBA52
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x04004742 RID: 18242
	public AudioClip BossIntro;

	// Token: 0x04004743 RID: 18243
	public AudioClip BossMain;

	// Token: 0x04004744 RID: 18244
	public AudioClip ApproachIntro;

	// Token: 0x04004745 RID: 18245
	public AudioClip ApproachMain;

	// Token: 0x04004746 RID: 18246
	public bool Boss;
}
