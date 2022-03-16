using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FootstepScript : MonoBehaviour
{
	// Token: 0x060014BC RID: 5308 RVA: 0x000CC6B6 File Offset: 0x000CA8B6
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014BD RID: 5309 RVA: 0x000CC6CC File Offset: 0x000CA8CC
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

	// Token: 0x04002099 RID: 8345
	public StudentScript Student;

	// Token: 0x0400209A RID: 8346
	public AudioSource MyAudio;

	// Token: 0x0400209B RID: 8347
	public AudioClip[] WalkFootsteps;

	// Token: 0x0400209C RID: 8348
	public AudioClip[] RunFootsteps;

	// Token: 0x0400209D RID: 8349
	public float DownThreshold = 0.02f;

	// Token: 0x0400209E RID: 8350
	public float UpThreshold = 0.025f;

	// Token: 0x0400209F RID: 8351
	public bool FootUp;
}
