using System;
using UnityEngine;

// Token: 0x020002D0 RID: 720
public class FootstepScript : MonoBehaviour
{
	// Token: 0x060014A6 RID: 5286 RVA: 0x000CADC6 File Offset: 0x000C8FC6
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014A7 RID: 5287 RVA: 0x000CADDC File Offset: 0x000C8FDC
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

	// Token: 0x0400205C RID: 8284
	public StudentScript Student;

	// Token: 0x0400205D RID: 8285
	public AudioSource MyAudio;

	// Token: 0x0400205E RID: 8286
	public AudioClip[] WalkFootsteps;

	// Token: 0x0400205F RID: 8287
	public AudioClip[] RunFootsteps;

	// Token: 0x04002060 RID: 8288
	public float DownThreshold = 0.02f;

	// Token: 0x04002061 RID: 8289
	public float UpThreshold = 0.025f;

	// Token: 0x04002062 RID: 8290
	public bool FootUp;
}
