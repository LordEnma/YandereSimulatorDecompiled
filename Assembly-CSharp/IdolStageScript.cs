using System;
using UnityEngine;

// Token: 0x0200032D RID: 813
public class IdolStageScript : MonoBehaviour
{
	// Token: 0x060018B7 RID: 6327 RVA: 0x000F2E3C File Offset: 0x000F103C
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

	// Token: 0x040025B3 RID: 9651
	public StudentManagerScript StudentManager;

	// Token: 0x040025B4 RID: 9652
	public JukeboxScript Jukebox;

	// Token: 0x040025B5 RID: 9653
	public AudioSource[] Music;

	// Token: 0x040025B6 RID: 9654
	public Transform[] Spot;

	// Token: 0x040025B7 RID: 9655
	public Transform Yandere;

	// Token: 0x040025B8 RID: 9656
	public bool RestoreVolume;
}
