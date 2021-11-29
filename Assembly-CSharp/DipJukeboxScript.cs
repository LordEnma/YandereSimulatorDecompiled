using System;
using UnityEngine;

// Token: 0x02000282 RID: 642
public class DipJukeboxScript : MonoBehaviour
{
	// Token: 0x06001385 RID: 4997 RVA: 0x000B6EB8 File Offset: 0x000B50B8
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

	// Token: 0x04001CD3 RID: 7379
	public JukeboxScript Jukebox;

	// Token: 0x04001CD4 RID: 7380
	public AudioSource MyAudio;

	// Token: 0x04001CD5 RID: 7381
	public Transform Yandere;
}
