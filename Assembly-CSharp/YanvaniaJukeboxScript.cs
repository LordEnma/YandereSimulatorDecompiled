using System;
using UnityEngine;

// Token: 0x020004E7 RID: 1255
public class YanvaniaJukeboxScript : MonoBehaviour
{
	// Token: 0x060020DD RID: 8413 RVA: 0x001E4754 File Offset: 0x001E2954
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

	// Token: 0x060020DE RID: 8414 RVA: 0x001E47AA File Offset: 0x001E29AA
	public void BossBattle()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		this.Boss = true;
	}

	// Token: 0x04004832 RID: 18482
	public AudioClip BossIntro;

	// Token: 0x04004833 RID: 18483
	public AudioClip BossMain;

	// Token: 0x04004834 RID: 18484
	public AudioClip ApproachIntro;

	// Token: 0x04004835 RID: 18485
	public AudioClip ApproachMain;

	// Token: 0x04004836 RID: 18486
	public bool Boss;
}
