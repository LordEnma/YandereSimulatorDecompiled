using System;
using UnityEngine;

// Token: 0x020004E7 RID: 1255
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x060020D6 RID: 8406 RVA: 0x001E3CF8 File Offset: 0x001E1EF8
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

	// Token: 0x060020D7 RID: 8407 RVA: 0x001E3D4E File Offset: 0x001E1F4E
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x04004820 RID: 18464
	public AudioClip BossIntro;

	// Token: 0x04004821 RID: 18465
	public AudioClip BossMain;

	// Token: 0x04004822 RID: 18466
	public AudioClip ApproachIntro;

	// Token: 0x04004823 RID: 18467
	public AudioClip ApproachMain;

	// Token: 0x04004824 RID: 18468
	public bool Boss;
}
