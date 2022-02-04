using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x0600208F RID: 8335 RVA: 0x001DE3B4 File Offset: 0x001DC5B4
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

	// Token: 0x06002090 RID: 8336 RVA: 0x001DE40A File Offset: 0x001DC60A
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x04004753 RID: 18259
	public AudioClip BossIntro;

	// Token: 0x04004754 RID: 18260
	public AudioClip BossMain;

	// Token: 0x04004755 RID: 18261
	public AudioClip ApproachIntro;

	// Token: 0x04004756 RID: 18262
	public AudioClip ApproachMain;

	// Token: 0x04004757 RID: 18263
	public bool Boss;
}
