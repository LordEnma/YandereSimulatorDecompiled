using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x06002092 RID: 8338 RVA: 0x001DE5B8 File Offset: 0x001DC7B8
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

	// Token: 0x06002093 RID: 8339 RVA: 0x001DE60E File Offset: 0x001DC80E
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x04004756 RID: 18262
	public AudioClip BossIntro;

	// Token: 0x04004757 RID: 18263
	public AudioClip BossMain;

	// Token: 0x04004758 RID: 18264
	public AudioClip ApproachIntro;

	// Token: 0x04004759 RID: 18265
	public AudioClip ApproachMain;

	// Token: 0x0400475A RID: 18266
	public bool Boss;
}
