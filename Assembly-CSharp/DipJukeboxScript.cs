using System;
using UnityEngine;

// Token: 0x02000283 RID: 643
public class DipJukeboxScript : MonoBehaviour
{
	// Token: 0x0600138D RID: 5005 RVA: 0x000B785C File Offset: 0x000B5A5C
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

	// Token: 0x04001CFB RID: 7419
	public JukeboxScript Jukebox;

	// Token: 0x04001CFC RID: 7420
	public AudioSource MyAudio;

	// Token: 0x04001CFD RID: 7421
	public Transform Yandere;
}
