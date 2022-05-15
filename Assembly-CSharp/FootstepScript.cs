using System;
using UnityEngine;

// Token: 0x020002D6 RID: 726
public class FootstepScript : MonoBehaviour
{
	// Token: 0x060014CD RID: 5325 RVA: 0x000CD374 File Offset: 0x000CB574
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014CE RID: 5326 RVA: 0x000CD38C File Offset: 0x000CB58C
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

	// Token: 0x040020B4 RID: 8372
	public StudentScript Student;

	// Token: 0x040020B5 RID: 8373
	public AudioSource MyAudio;

	// Token: 0x040020B6 RID: 8374
	public AudioClip[] WalkFootsteps;

	// Token: 0x040020B7 RID: 8375
	public AudioClip[] RunFootsteps;

	// Token: 0x040020B8 RID: 8376
	public float DownThreshold = 0.02f;

	// Token: 0x040020B9 RID: 8377
	public float UpThreshold = 0.025f;

	// Token: 0x040020BA RID: 8378
	public bool FootUp;
}
