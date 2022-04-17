using System;
using UnityEngine;

// Token: 0x02000376 RID: 886
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019ED RID: 6637 RVA: 0x0010A7FE File Offset: 0x001089FE
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019EE RID: 6638 RVA: 0x0010A818 File Offset: 0x00108A18
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

	// Token: 0x040029C4 RID: 10692
	public UILabel EventSubtitle;

	// Token: 0x040029C5 RID: 10693
	public JukeboxScript Jukebox;

	// Token: 0x040029C6 RID: 10694
	public YandereScript Yandere;

	// Token: 0x040029C7 RID: 10695
	public bool Spoken;

	// Token: 0x040029C8 RID: 10696
	public AudioSource MyAudio;
}
