using System;
using UnityEngine;

// Token: 0x0200024E RID: 590
public class ClubAmbienceScript : MonoBehaviour
{
	// Token: 0x06001272 RID: 4722 RVA: 0x00090198 File Offset: 0x0008E398
	private void Update()
	{
		if (this.Yandere.position.y > base.transform.position.y - 0.1f && this.Yandere.position.y < base.transform.position.y + 0.1f)
		{
			if (Vector3.Distance(base.transform.position, this.Yandere.position) < 4f)
			{
				this.CreateAmbience = true;
				this.EffectJukebox = true;
			}
			else
			{
				this.CreateAmbience = false;
			}
		}
		if (this.EffectJukebox)
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.CreateAmbience)
			{
				component.volume = Mathf.MoveTowards(component.volume, this.MaxVolume, Time.deltaTime * 0.1f);
				this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, this.ClubDip, Time.deltaTime * 0.1f);
				return;
			}
			component.volume = Mathf.MoveTowards(component.volume, 0f, Time.deltaTime * 0.1f);
			this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, 0f, Time.deltaTime * 0.1f);
			if (this.Jukebox.ClubDip == 0f)
			{
				this.EffectJukebox = false;
			}
		}
	}

	// Token: 0x040017B0 RID: 6064
	public JukeboxScript Jukebox;

	// Token: 0x040017B1 RID: 6065
	public Transform Yandere;

	// Token: 0x040017B2 RID: 6066
	public bool CreateAmbience;

	// Token: 0x040017B3 RID: 6067
	public bool EffectJukebox;

	// Token: 0x040017B4 RID: 6068
	public float ClubDip;

	// Token: 0x040017B5 RID: 6069
	public float MaxVolume;
}
