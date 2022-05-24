using System;
using UnityEngine;

// Token: 0x02000250 RID: 592
public class ClubAmbienceScript : MonoBehaviour
{
	// Token: 0x0600127D RID: 4733 RVA: 0x000912C8 File Offset: 0x0008F4C8
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

	// Token: 0x040017D4 RID: 6100
	public JukeboxScript Jukebox;

	// Token: 0x040017D5 RID: 6101
	public Transform Yandere;

	// Token: 0x040017D6 RID: 6102
	public bool CreateAmbience;

	// Token: 0x040017D7 RID: 6103
	public bool EffectJukebox;

	// Token: 0x040017D8 RID: 6104
	public float ClubDip;

	// Token: 0x040017D9 RID: 6105
	public float MaxVolume;
}
