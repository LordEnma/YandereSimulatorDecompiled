using System;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019C3 RID: 6595 RVA: 0x00108256 File Offset: 0x00106456
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019C4 RID: 6596 RVA: 0x00108270 File Offset: 0x00106470
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

	// Token: 0x04002955 RID: 10581
	public UILabel EventSubtitle;

	// Token: 0x04002956 RID: 10582
	public JukeboxScript Jukebox;

	// Token: 0x04002957 RID: 10583
	public YandereScript Yandere;

	// Token: 0x04002958 RID: 10584
	public bool Spoken;

	// Token: 0x04002959 RID: 10585
	public AudioSource MyAudio;
}
