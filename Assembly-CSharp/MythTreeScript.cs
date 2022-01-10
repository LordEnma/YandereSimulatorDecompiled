using System;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019C2 RID: 6594 RVA: 0x00107CB6 File Offset: 0x00105EB6
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019C3 RID: 6595 RVA: 0x00107CD0 File Offset: 0x00105ED0
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

	// Token: 0x0400294C RID: 10572
	public UILabel EventSubtitle;

	// Token: 0x0400294D RID: 10573
	public JukeboxScript Jukebox;

	// Token: 0x0400294E RID: 10574
	public YandereScript Yandere;

	// Token: 0x0400294F RID: 10575
	public bool Spoken;

	// Token: 0x04002950 RID: 10576
	public AudioSource MyAudio;
}
