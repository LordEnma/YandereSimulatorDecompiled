using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x06002087 RID: 8327 RVA: 0x001DCB2C File Offset: 0x001DAD2C
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

	// Token: 0x06002088 RID: 8328 RVA: 0x001DCB82 File Offset: 0x001DAD82
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x0400473B RID: 18235
	public AudioClip BossIntro;

	// Token: 0x0400473C RID: 18236
	public AudioClip BossMain;

	// Token: 0x0400473D RID: 18237
	public AudioClip ApproachIntro;

	// Token: 0x0400473E RID: 18238
	public AudioClip ApproachMain;

	// Token: 0x0400473F RID: 18239
	public bool Boss;
}
