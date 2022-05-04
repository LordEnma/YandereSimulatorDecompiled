using System;
using UnityEngine;

// Token: 0x02000376 RID: 886
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019F1 RID: 6641 RVA: 0x0010ACCA File Offset: 0x00108ECA
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019F2 RID: 6642 RVA: 0x0010ACE4 File Offset: 0x00108EE4
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

	// Token: 0x040029CD RID: 10701
	public UILabel EventSubtitle;

	// Token: 0x040029CE RID: 10702
	public JukeboxScript Jukebox;

	// Token: 0x040029CF RID: 10703
	public YandereScript Yandere;

	// Token: 0x040029D0 RID: 10704
	public bool Spoken;

	// Token: 0x040029D1 RID: 10705
	public AudioSource MyAudio;
}
