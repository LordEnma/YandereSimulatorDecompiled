using System;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019C2 RID: 6594 RVA: 0x00107E1E File Offset: 0x0010601E
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019C3 RID: 6595 RVA: 0x00107E38 File Offset: 0x00106038
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

	// Token: 0x0400294F RID: 10575
	public UILabel EventSubtitle;

	// Token: 0x04002950 RID: 10576
	public JukeboxScript Jukebox;

	// Token: 0x04002951 RID: 10577
	public YandereScript Yandere;

	// Token: 0x04002952 RID: 10578
	public bool Spoken;

	// Token: 0x04002953 RID: 10579
	public AudioSource MyAudio;
}
