using System;
using UnityEngine;

// Token: 0x020002D5 RID: 725
public class FootstepScript : MonoBehaviour
{
	// Token: 0x060014C5 RID: 5317 RVA: 0x000CC9FA File Offset: 0x000CABFA
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014C6 RID: 5318 RVA: 0x000CCA10 File Offset: 0x000CAC10
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

	// Token: 0x040020A0 RID: 8352
	public StudentScript Student;

	// Token: 0x040020A1 RID: 8353
	public AudioSource MyAudio;

	// Token: 0x040020A2 RID: 8354
	public AudioClip[] WalkFootsteps;

	// Token: 0x040020A3 RID: 8355
	public AudioClip[] RunFootsteps;

	// Token: 0x040020A4 RID: 8356
	public float DownThreshold = 0.02f;

	// Token: 0x040020A5 RID: 8357
	public float UpThreshold = 0.025f;

	// Token: 0x040020A6 RID: 8358
	public bool FootUp;
}
