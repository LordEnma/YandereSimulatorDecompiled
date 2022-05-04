using System;
using UnityEngine;

// Token: 0x020002D5 RID: 725
public class FootstepScript : MonoBehaviour
{
	// Token: 0x060014CB RID: 5323 RVA: 0x000CD074 File Offset: 0x000CB274
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014CC RID: 5324 RVA: 0x000CD08C File Offset: 0x000CB28C
	private void Update()
	{
		if (!this.FootUp)
		{
			if (base.transform.position.y > this.Student.transform.position.y + this.UpThreshold)
			{
				this.FootUp = true;
				return;
			}
		}
		else if (base.transform.position.y < this.Student.transform.position.y + this.DownThreshold)
		{
			if (this.FootUp)
			{
				if (this.Student.Pathfinding.speed > 1f)
				{
					this.MyAudio.clip = this.RunFootsteps[UnityEngine.Random.Range(0, this.RunFootsteps.Length)];
					this.MyAudio.volume = 0.2f;
				}
				else
				{
					this.MyAudio.clip = this.WalkFootsteps[UnityEngine.Random.Range(0, this.WalkFootsteps.Length)];
					this.MyAudio.volume = 0.1f;
				}
				this.MyAudio.Play();
			}
			this.FootUp = false;
		}
	}

	// Token: 0x040020AB RID: 8363
	public StudentScript Student;

	// Token: 0x040020AC RID: 8364
	public AudioSource MyAudio;

	// Token: 0x040020AD RID: 8365
	public AudioClip[] WalkFootsteps;

	// Token: 0x040020AE RID: 8366
	public AudioClip[] RunFootsteps;

	// Token: 0x040020AF RID: 8367
	public float DownThreshold = 0.02f;

	// Token: 0x040020B0 RID: 8368
	public float UpThreshold = 0.025f;

	// Token: 0x040020B1 RID: 8369
	public bool FootUp;
}
