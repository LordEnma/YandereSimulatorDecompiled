using System;
using UnityEngine;

// Token: 0x02000285 RID: 645
public class DipJukeboxScript : MonoBehaviour
{
	// Token: 0x0600139F RID: 5023 RVA: 0x000B87AC File Offset: 0x000B69AC
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

	// Token: 0x04001D27 RID: 7463
	public JukeboxScript Jukebox;

	// Token: 0x04001D28 RID: 7464
	public AudioSource MyAudio;

	// Token: 0x04001D29 RID: 7465
	public Transform Yandere;
}
