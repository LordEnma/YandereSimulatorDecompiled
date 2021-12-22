using System;
using UnityEngine;

// Token: 0x0200024F RID: 591
public class ClubAmbienceScript : MonoBehaviour
{
	// Token: 0x06001277 RID: 4727 RVA: 0x00090390 File Offset: 0x0008E590
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

	// Token: 0x040017B4 RID: 6068
	public JukeboxScript Jukebox;

	// Token: 0x040017B5 RID: 6069
	public Transform Yandere;

	// Token: 0x040017B6 RID: 6070
	public bool CreateAmbience;

	// Token: 0x040017B7 RID: 6071
	public bool EffectJukebox;

	// Token: 0x040017B8 RID: 6072
	public float ClubDip;

	// Token: 0x040017B9 RID: 6073
	public float MaxVolume;
}
