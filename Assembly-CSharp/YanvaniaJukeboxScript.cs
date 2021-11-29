using System;
using UnityEngine;

// Token: 0x020004D6 RID: 1238
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x06002068 RID: 8296 RVA: 0x001DA468 File Offset: 0x001D8668
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

	// Token: 0x06002069 RID: 8297 RVA: 0x001DA4BE File Offset: 0x001D86BE
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x040046DF RID: 18143
	public AudioClip BossIntro;

	// Token: 0x040046E0 RID: 18144
	public AudioClip BossMain;

	// Token: 0x040046E1 RID: 18145
	public AudioClip ApproachIntro;

	// Token: 0x040046E2 RID: 18146
	public AudioClip ApproachMain;

	// Token: 0x040046E3 RID: 18147
	public bool Boss;
}
