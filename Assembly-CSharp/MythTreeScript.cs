using System;
using UnityEngine;

// Token: 0x02000374 RID: 884
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019D5 RID: 6613 RVA: 0x001093DA File Offset: 0x001075DA
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019D6 RID: 6614 RVA: 0x001093F4 File Offset: 0x001075F4
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

	// Token: 0x04002984 RID: 10628
	public UILabel EventSubtitle;

	// Token: 0x04002985 RID: 10629
	public JukeboxScript Jukebox;

	// Token: 0x04002986 RID: 10630
	public YandereScript Yandere;

	// Token: 0x04002987 RID: 10631
	public bool Spoken;

	// Token: 0x04002988 RID: 10632
	public AudioSource MyAudio;
}
