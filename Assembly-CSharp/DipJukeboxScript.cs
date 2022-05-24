using System;
using UnityEngine;

// Token: 0x02000286 RID: 646
public class DipJukeboxScript : MonoBehaviour
{
	// Token: 0x060013A1 RID: 5025 RVA: 0x000B8AC0 File Offset: 0x000B6CC0
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

	// Token: 0x04001D2E RID: 7470
	public JukeboxScript Jukebox;

	// Token: 0x04001D2F RID: 7471
	public AudioSource MyAudio;

	// Token: 0x04001D30 RID: 7472
	public Transform Yandere;
}
