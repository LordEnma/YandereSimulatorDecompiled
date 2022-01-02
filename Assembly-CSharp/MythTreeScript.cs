using System;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019BE RID: 6590 RVA: 0x0010790E File Offset: 0x00105B0E
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019BF RID: 6591 RVA: 0x00107928 File Offset: 0x00105B28
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

	// Token: 0x04002946 RID: 10566
	public UILabel EventSubtitle;

	// Token: 0x04002947 RID: 10567
	public JukeboxScript Jukebox;

	// Token: 0x04002948 RID: 10568
	public YandereScript Yandere;

	// Token: 0x04002949 RID: 10569
	public bool Spoken;

	// Token: 0x0400294A RID: 10570
	public AudioSource MyAudio;
}
