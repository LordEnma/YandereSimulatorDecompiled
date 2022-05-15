using System;
using UnityEngine;

// Token: 0x02000377 RID: 887
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019F7 RID: 6647 RVA: 0x0010B54A File Offset: 0x0010974A
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019F8 RID: 6648 RVA: 0x0010B564 File Offset: 0x00109764
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

	// Token: 0x040029DF RID: 10719
	public UILabel EventSubtitle;

	// Token: 0x040029E0 RID: 10720
	public JukeboxScript Jukebox;

	// Token: 0x040029E1 RID: 10721
	public YandereScript Yandere;

	// Token: 0x040029E2 RID: 10722
	public bool Spoken;

	// Token: 0x040029E3 RID: 10723
	public AudioSource MyAudio;
}
