using System;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class MythTreeScript : MonoBehaviour
{
	// Token: 0x060019BC RID: 6588 RVA: 0x00107632 File Offset: 0x00105832
	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060019BD RID: 6589 RVA: 0x0010764C File Offset: 0x0010584C
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

	// Token: 0x04002942 RID: 10562
	public UILabel EventSubtitle;

	// Token: 0x04002943 RID: 10563
	public JukeboxScript Jukebox;

	// Token: 0x04002944 RID: 10564
	public YandereScript Yandere;

	// Token: 0x04002945 RID: 10565
	public bool Spoken;

	// Token: 0x04002946 RID: 10566
	public AudioSource MyAudio;
}
