using System;
using UnityEngine;

// Token: 0x02000374 RID: 884
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019D5 RID: 6613 RVA: 0x00109072 File Offset: 0x00107272
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019D6 RID: 6614 RVA: 0x0010908C File Offset: 0x0010728C
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

	// Token: 0x0400296E RID: 10606
	public UILabel EventSubtitle;

	// Token: 0x0400296F RID: 10607
	public JukeboxScript Jukebox;

	// Token: 0x04002970 RID: 10608
	public YandereScript Yandere;

	// Token: 0x04002971 RID: 10609
	public bool Spoken;

	// Token: 0x04002972 RID: 10610
	public AudioSource MyAudio;
}
