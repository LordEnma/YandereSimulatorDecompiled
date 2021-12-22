using System;
using UnityEngine;

// Token: 0x020004D8 RID: 1240
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x06002079 RID: 8313 RVA: 0x001DBB9C File Offset: 0x001D9D9C
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

	// Token: 0x0600207A RID: 8314 RVA: 0x001DBBF2 File Offset: 0x001D9DF2
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x0400471E RID: 18206
	public AudioClip BossIntro;

	// Token: 0x0400471F RID: 18207
	public AudioClip BossMain;

	// Token: 0x04004720 RID: 18208
	public AudioClip ApproachIntro;

	// Token: 0x04004721 RID: 18209
	public AudioClip ApproachMain;

	// Token: 0x04004722 RID: 18210
	public bool Boss;
}
