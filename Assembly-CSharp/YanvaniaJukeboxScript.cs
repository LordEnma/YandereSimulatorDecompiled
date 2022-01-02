using System;
using UnityEngine;

// Token: 0x020004D8 RID: 1240
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x0600207C RID: 8316 RVA: 0x001DC18C File Offset: 0x001DA38C
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

	// Token: 0x0600207D RID: 8317 RVA: 0x001DC1E2 File Offset: 0x001DA3E2
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x04004727 RID: 18215
	public AudioClip BossIntro;

	// Token: 0x04004728 RID: 18216
	public AudioClip BossMain;

	// Token: 0x04004729 RID: 18217
	public AudioClip ApproachIntro;

	// Token: 0x0400472A RID: 18218
	public AudioClip ApproachMain;

	// Token: 0x0400472B RID: 18219
	public bool Boss;
}
