using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x06002099 RID: 8345 RVA: 0x001DEA6C File Offset: 0x001DCC6C
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

	// Token: 0x0600209A RID: 8346 RVA: 0x001DEAC2 File Offset: 0x001DCCC2
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x0400475F RID: 18271
	public AudioClip BossIntro;

	// Token: 0x04004760 RID: 18272
	public AudioClip BossMain;

	// Token: 0x04004761 RID: 18273
	public AudioClip ApproachIntro;

	// Token: 0x04004762 RID: 18274
	public AudioClip ApproachMain;

	// Token: 0x04004763 RID: 18275
	public bool Boss;
}
