using System;
using UnityEngine;

// Token: 0x02000370 RID: 880
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019B5 RID: 6581 RVA: 0x00106D92 File Offset: 0x00104F92
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019B6 RID: 6582 RVA: 0x00106DAC File Offset: 0x00104FAC
	private void Update()
	{
		if (!this.Spoken)
		{
			if (this.Yandere.Inventory.Ring && Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 5f)
			{
				this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				this.EventSubtitle.text = "...that...ring...";
				this.Jukebox.Dip = 0.5f;
				this.Spoken = true;
				this.MyAudio.Play();
				return;
			}
		}
		else if (!this.MyAudio.isPlaying)
		{
			this.EventSubtitle.transform.localScale = Vector3.zero;
			this.EventSubtitle.text = string.Empty;
			this.Jukebox.Dip = 1f;
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x0400291D RID: 10525
	public UILabel EventSubtitle;

	// Token: 0x0400291E RID: 10526
	public JukeboxScript Jukebox;

	// Token: 0x0400291F RID: 10527
	public YandereScript Yandere;

	// Token: 0x04002920 RID: 10528
	public bool Spoken;

	// Token: 0x04002921 RID: 10529
	public AudioSource MyAudio;
}
