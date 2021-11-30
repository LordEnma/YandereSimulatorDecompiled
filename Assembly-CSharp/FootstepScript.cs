using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FootstepScript : MonoBehaviour
{
	// Token: 0x0600149F RID: 5279 RVA: 0x000CA3DA File Offset: 0x000C85DA
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014A0 RID: 5280 RVA: 0x000CA3F0 File Offset: 0x000C85F0
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

	// Token: 0x04002039 RID: 8249
	public StudentScript Student;

	// Token: 0x0400203A RID: 8250
	public AudioSource MyAudio;

	// Token: 0x0400203B RID: 8251
	public AudioClip[] WalkFootsteps;

	// Token: 0x0400203C RID: 8252
	public AudioClip[] RunFootsteps;

	// Token: 0x0400203D RID: 8253
	public float DownThreshold = 0.02f;

	// Token: 0x0400203E RID: 8254
	public float UpThreshold = 0.025f;

	// Token: 0x0400203F RID: 8255
	public bool FootUp;
}
