using System;
using UnityEngine;

// Token: 0x02000376 RID: 886
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019E9 RID: 6633 RVA: 0x0010A53A File Offset: 0x0010873A
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019EA RID: 6634 RVA: 0x0010A554 File Offset: 0x00108754
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

	// Token: 0x040029BC RID: 10684
	public UILabel EventSubtitle;

	// Token: 0x040029BD RID: 10685
	public JukeboxScript Jukebox;

	// Token: 0x040029BE RID: 10686
	public YandereScript Yandere;

	// Token: 0x040029BF RID: 10687
	public bool Spoken;

	// Token: 0x040029C0 RID: 10688
	public AudioSource MyAudio;
}
