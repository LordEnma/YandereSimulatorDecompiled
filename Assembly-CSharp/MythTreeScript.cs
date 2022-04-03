using System;
using UnityEngine;

// Token: 0x02000375 RID: 885
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019E3 RID: 6627 RVA: 0x0010A43A File Offset: 0x0010863A
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019E4 RID: 6628 RVA: 0x0010A454 File Offset: 0x00108654
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

	// Token: 0x040029B9 RID: 10681
	public UILabel EventSubtitle;

	// Token: 0x040029BA RID: 10682
	public JukeboxScript Jukebox;

	// Token: 0x040029BB RID: 10683
	public YandereScript Yandere;

	// Token: 0x040029BC RID: 10684
	public bool Spoken;

	// Token: 0x040029BD RID: 10685
	public AudioSource MyAudio;
}
