using System;
using UnityEngine;

// Token: 0x02000284 RID: 644
public class DipJukeboxScript : MonoBehaviour
{
	// Token: 0x06001391 RID: 5009 RVA: 0x000B7BDC File Offset: 0x000B5DDC
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

	// Token: 0x04001D0B RID: 7435
	public JukeboxScript Jukebox;

	// Token: 0x04001D0C RID: 7436
	public AudioSource MyAudio;

	// Token: 0x04001D0D RID: 7437
	public Transform Yandere;
}
