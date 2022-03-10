using System;
using UnityEngine;

// Token: 0x0200024F RID: 591
public class ClubAmbienceScript : MonoBehaviour
{
	// Token: 0x06001278 RID: 4728 RVA: 0x00090858 File Offset: 0x0008EA58
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

	// Token: 0x040017C4 RID: 6084
	public JukeboxScript Jukebox;

	// Token: 0x040017C5 RID: 6085
	public Transform Yandere;

	// Token: 0x040017C6 RID: 6086
	public bool CreateAmbience;

	// Token: 0x040017C7 RID: 6087
	public bool EffectJukebox;

	// Token: 0x040017C8 RID: 6088
	public float ClubDip;

	// Token: 0x040017C9 RID: 6089
	public float MaxVolume;
}
