using System;
using UnityEngine;

// Token: 0x02000284 RID: 644
public class DipJukeboxScript : MonoBehaviour
{
	// Token: 0x06001394 RID: 5012 RVA: 0x000B7FB8 File Offset: 0x000B61B8
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

	// Token: 0x04001D19 RID: 7449
	public JukeboxScript Jukebox;

	// Token: 0x04001D1A RID: 7450
	public AudioSource MyAudio;

	// Token: 0x04001D1B RID: 7451
	public Transform Yandere;
}
