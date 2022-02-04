using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FootstepScript : MonoBehaviour
{
	// Token: 0x060014AB RID: 5291 RVA: 0x000CB662 File Offset: 0x000C9862
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014AC RID: 5292 RVA: 0x000CB678 File Offset: 0x000C9878
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

	// Token: 0x04002069 RID: 8297
	public StudentScript Student;

	// Token: 0x0400206A RID: 8298
	public AudioSource MyAudio;

	// Token: 0x0400206B RID: 8299
	public AudioClip[] WalkFootsteps;

	// Token: 0x0400206C RID: 8300
	public AudioClip[] RunFootsteps;

	// Token: 0x0400206D RID: 8301
	public float DownThreshold = 0.02f;

	// Token: 0x0400206E RID: 8302
	public float UpThreshold = 0.025f;

	// Token: 0x0400206F RID: 8303
	public bool FootUp;
}
