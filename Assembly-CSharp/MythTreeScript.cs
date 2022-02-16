using System;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019CC RID: 6604 RVA: 0x00108742 File Offset: 0x00106942
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019CD RID: 6605 RVA: 0x0010875C File Offset: 0x0010695C
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

	// Token: 0x0400295F RID: 10591
	public UILabel EventSubtitle;

	// Token: 0x04002960 RID: 10592
	public JukeboxScript Jukebox;

	// Token: 0x04002961 RID: 10593
	public YandereScript Yandere;

	// Token: 0x04002962 RID: 10594
	public bool Spoken;

	// Token: 0x04002963 RID: 10595
	public AudioSource MyAudio;
}
