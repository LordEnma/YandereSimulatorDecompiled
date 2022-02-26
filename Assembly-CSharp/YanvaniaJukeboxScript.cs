using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x060020A2 RID: 8354 RVA: 0x001DF64C File Offset: 0x001DD84C
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

	// Token: 0x060020A3 RID: 8355 RVA: 0x001DF6A2 File Offset: 0x001DD8A2
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x0400476F RID: 18287
	public AudioClip BossIntro;

	// Token: 0x04004770 RID: 18288
	public AudioClip BossMain;

	// Token: 0x04004771 RID: 18289
	public AudioClip ApproachIntro;

	// Token: 0x04004772 RID: 18290
	public AudioClip ApproachMain;

	// Token: 0x04004773 RID: 18291
	public bool Boss;
}
