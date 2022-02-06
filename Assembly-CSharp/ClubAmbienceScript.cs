using System;
using UnityEngine;

// Token: 0x0200024F RID: 591
public class ClubAmbienceScript : MonoBehaviour
{
	// Token: 0x06001277 RID: 4727 RVA: 0x0009053C File Offset: 0x0008E73C
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

	// Token: 0x040017BA RID: 6074
	public JukeboxScript Jukebox;

	// Token: 0x040017BB RID: 6075
	public Transform Yandere;

	// Token: 0x040017BC RID: 6076
	public bool CreateAmbience;

	// Token: 0x040017BD RID: 6077
	public bool EffectJukebox;

	// Token: 0x040017BE RID: 6078
	public float ClubDip;

	// Token: 0x040017BF RID: 6079
	public float MaxVolume;
}
