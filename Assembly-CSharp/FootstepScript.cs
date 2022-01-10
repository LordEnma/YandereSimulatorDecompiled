using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FootstepScript : MonoBehaviour
{
	// Token: 0x060014AA RID: 5290 RVA: 0x000CB0A6 File Offset: 0x000C92A6
	private void Start()
	{
		if (!this.Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060014AB RID: 5291 RVA: 0x000CB0BC File Offset: 0x000C92BC
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

	// Token: 0x04002060 RID: 8288
	public StudentScript Student;

	// Token: 0x04002061 RID: 8289
	public AudioSource MyAudio;

	// Token: 0x04002062 RID: 8290
	public AudioClip[] WalkFootsteps;

	// Token: 0x04002063 RID: 8291
	public AudioClip[] RunFootsteps;

	// Token: 0x04002064 RID: 8292
	public float DownThreshold = 0.02f;

	// Token: 0x04002065 RID: 8293
	public float UpThreshold = 0.025f;

	// Token: 0x04002066 RID: 8294
	public bool FootUp;
}
