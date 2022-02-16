using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FootstepScript : MonoBehaviour
{
	// Token: 0x060014B0 RID: 5296 RVA: 0x000CB7E6 File Offset: 0x000C99E6
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014B1 RID: 5297 RVA: 0x000CB7FC File Offset: 0x000C99FC
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

	// Token: 0x04002070 RID: 8304
	public StudentScript Student;

	// Token: 0x04002071 RID: 8305
	public AudioSource MyAudio;

	// Token: 0x04002072 RID: 8306
	public AudioClip[] WalkFootsteps;

	// Token: 0x04002073 RID: 8307
	public AudioClip[] RunFootsteps;

	// Token: 0x04002074 RID: 8308
	public float DownThreshold = 0.02f;

	// Token: 0x04002075 RID: 8309
	public float UpThreshold = 0.025f;

	// Token: 0x04002076 RID: 8310
	public bool FootUp;
}
