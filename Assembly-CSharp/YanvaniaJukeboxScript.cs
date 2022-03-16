using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x060020C0 RID: 8384 RVA: 0x001E1F8C File Offset: 0x001E018C
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

	// Token: 0x060020C1 RID: 8385 RVA: 0x001E1FE2 File Offset: 0x001E01E2
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x040047EB RID: 18411
	public AudioClip BossIntro;

	// Token: 0x040047EC RID: 18412
	public AudioClip BossMain;

	// Token: 0x040047ED RID: 18413
	public AudioClip ApproachIntro;

	// Token: 0x040047EE RID: 18414
	public AudioClip ApproachMain;

	// Token: 0x040047EF RID: 18415
	public bool Boss;
}
