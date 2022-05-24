using System;
using UnityEngine;

// Token: 0x02000377 RID: 887
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019F8 RID: 6648 RVA: 0x0010B74E File Offset: 0x0010994E
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019F9 RID: 6649 RVA: 0x0010B768 File Offset: 0x00109968
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

	// Token: 0x040029E6 RID: 10726
	public UILabel EventSubtitle;

	// Token: 0x040029E7 RID: 10727
	public JukeboxScript Jukebox;

	// Token: 0x040029E8 RID: 10728
	public YandereScript Yandere;

	// Token: 0x040029E9 RID: 10729
	public bool Spoken;

	// Token: 0x040029EA RID: 10730
	public AudioSource MyAudio;
}
