using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FootstepScript : MonoBehaviour
{
	// Token: 0x060014B9 RID: 5305 RVA: 0x000CC0CA File Offset: 0x000CA2CA
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014BA RID: 5306 RVA: 0x000CC0E0 File Offset: 0x000CA2E0
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

	// Token: 0x0400207F RID: 8319
	public StudentScript Student;

	// Token: 0x04002080 RID: 8320
	public AudioSource MyAudio;

	// Token: 0x04002081 RID: 8321
	public AudioClip[] WalkFootsteps;

	// Token: 0x04002082 RID: 8322
	public AudioClip[] RunFootsteps;

	// Token: 0x04002083 RID: 8323
	public float DownThreshold = 0.02f;

	// Token: 0x04002084 RID: 8324
	public float UpThreshold = 0.025f;

	// Token: 0x04002085 RID: 8325
	public bool FootUp;
}
