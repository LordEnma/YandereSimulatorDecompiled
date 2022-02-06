using System;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019C5 RID: 6597 RVA: 0x0010841E File Offset: 0x0010661E
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019C6 RID: 6598 RVA: 0x00108438 File Offset: 0x00106638
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

	// Token: 0x04002959 RID: 10585
	public UILabel EventSubtitle;

	// Token: 0x0400295A RID: 10586
	public JukeboxScript Jukebox;

	// Token: 0x0400295B RID: 10587
	public YandereScript Yandere;

	// Token: 0x0400295C RID: 10588
	public bool Spoken;

	// Token: 0x0400295D RID: 10589
	public AudioSource MyAudio;
}
