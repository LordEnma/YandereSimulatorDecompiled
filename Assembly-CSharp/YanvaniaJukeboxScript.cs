using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x0600208D RID: 8333 RVA: 0x001DE09C File Offset: 0x001DC29C
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

	// Token: 0x0600208E RID: 8334 RVA: 0x001DE0F2 File Offset: 0x001DC2F2
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x0400474D RID: 18253
	public AudioClip BossIntro;

	// Token: 0x0400474E RID: 18254
	public AudioClip BossMain;

	// Token: 0x0400474F RID: 18255
	public AudioClip ApproachIntro;

	// Token: 0x04004750 RID: 18256
	public AudioClip ApproachMain;

	// Token: 0x04004751 RID: 18257
	public bool Boss;
}
