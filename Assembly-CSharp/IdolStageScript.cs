using System;
using UnityEngine;

// Token: 0x02000330 RID: 816
public class IdolStageScript : MonoBehaviour
{
	// Token: 0x060018CE RID: 6350 RVA: 0x000F4338 File Offset: 0x000F2538
	private void Update()
	{
		for (int i = 1; i < 5; i++)
		{
			if (this.StudentManager.Students[51 + i] != null)
			{
				if (Vector3.Distance(this.StudentManager.Students[51 + i].transform.position, this.Spot[i].position) < 1f && this.StudentManager.Students[51 + i].Routine && !this.StudentManager.Students[51 + i].Alarmed)
				{
					Debug.Log("LMC Member #" + i.ToString() + " is at their spot on the stage.");
					this.Music[i].volume = Mathf.MoveTowards(this.Music[i].volume, 1f, Time.deltaTime);
				}
				else
				{
					this.Music[i].volume = Mathf.MoveTowards(this.Music[i].volume, 0f, Time.deltaTime);
				}
			}
		}
		if (this.StudentManager.Students[16] != null)
		{
			if (Vector3.Distance(this.StudentManager.Students[16].transform.position, this.Spot[5].position) < 1f && this.StudentManager.Students[16].Routine && !this.StudentManager.Students[16].Alarmed)
			{
				this.Music[5].volume = Mathf.MoveTowards(this.Music[5].volume, 1f, Time.deltaTime);
			}
			else
			{
				this.Music[5].volume = Mathf.MoveTowards(this.Music[5].volume, 0f, Time.deltaTime);
			}
		}
		if (Vector3.Distance(this.Yandere.position, base.transform.position) < 10f)
		{
			this.Jukebox.Dip = Mathf.MoveTowards(this.Jukebox.Dip, 0f, Time.deltaTime);
			this.RestoreVolume = true;
			return;
		}
		if (this.RestoreVolume)
		{
			this.Jukebox.Dip = Mathf.MoveTowards(this.Jukebox.Dip, 1f, Time.deltaTime);
			if (this.Jukebox.Dip == 0f)
			{
				this.RestoreVolume = false;
			}
		}
	}

	// Token: 0x040025D9 RID: 9689
	public StudentManagerScript StudentManager;

	// Token: 0x040025DA RID: 9690
	public JukeboxScript Jukebox;

	// Token: 0x040025DB RID: 9691
	public AudioSource[] Music;

	// Token: 0x040025DC RID: 9692
	public Transform[] Spot;

	// Token: 0x040025DD RID: 9693
	public Transform Yandere;

	// Token: 0x040025DE RID: 9694
	public bool RestoreVolume;
}
