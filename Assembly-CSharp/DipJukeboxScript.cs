using System;
using UnityEngine;

// Token: 0x02000283 RID: 643
public class DipJukeboxScript : MonoBehaviour
{
	// Token: 0x0600138C RID: 5004 RVA: 0x000B7704 File Offset: 0x000B5904
	private void Update()
	{
		if (this.MyAudio.isPlaying)
		{
			float num = Vector3.Distance(this.Yandere.position, base.transform.position);
			if (num < 8f)
			{
				this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, (7f - num) * 0.25f * this.Jukebox.Volume, Time.deltaTime);
				if (this.Jukebox.ClubDip < 0f)
				{
					this.Jukebox.ClubDip = 0f;
				}
				if (this.Jukebox.ClubDip > this.Jukebox.Volume)
				{
					this.Jukebox.ClubDip = this.Jukebox.Volume;
					return;
				}
			}
		}
		else if (this.MyAudio.isPlaying)
		{
			this.Jukebox.ClubDip = 0f;
		}
	}

	// Token: 0x04001CF8 RID: 7416
	public JukeboxScript Jukebox;

	// Token: 0x04001CF9 RID: 7417
	public AudioSource MyAudio;

	// Token: 0x04001CFA RID: 7418
	public Transform Yandere;
}
