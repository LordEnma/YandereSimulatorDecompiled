using System;
using UnityEngine;

// Token: 0x02000374 RID: 884
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019DD RID: 6621 RVA: 0x00109D7E File Offset: 0x00107F7E
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019DE RID: 6622 RVA: 0x00109D98 File Offset: 0x00107F98
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

	// Token: 0x040029A6 RID: 10662
	public UILabel EventSubtitle;

	// Token: 0x040029A7 RID: 10663
	public JukeboxScript Jukebox;

	// Token: 0x040029A8 RID: 10664
	public YandereScript Yandere;

	// Token: 0x040029A9 RID: 10665
	public bool Spoken;

	// Token: 0x040029AA RID: 10666
	public AudioSource MyAudio;
}
