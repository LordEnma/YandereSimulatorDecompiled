using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FootstepScript : MonoBehaviour
{
	// Token: 0x060014B9 RID: 5305 RVA: 0x000CC246 File Offset: 0x000CA446
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014BA RID: 5306 RVA: 0x000CC25C File Offset: 0x000CA45C
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

	// Token: 0x04002089 RID: 8329
	public StudentScript Student;

	// Token: 0x0400208A RID: 8330
	public AudioSource MyAudio;

	// Token: 0x0400208B RID: 8331
	public AudioClip[] WalkFootsteps;

	// Token: 0x0400208C RID: 8332
	public AudioClip[] RunFootsteps;

	// Token: 0x0400208D RID: 8333
	public float DownThreshold = 0.02f;

	// Token: 0x0400208E RID: 8334
	public float UpThreshold = 0.025f;

	// Token: 0x0400208F RID: 8335
	public bool FootUp;
}
