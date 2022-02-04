using System;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class SnapStudentScript : MonoBehaviour
{
	// Token: 0x06001CB8 RID: 7352 RVA: 0x00154668 File Offset: 0x00152868
	private void Start()
	{
		this.MyAnim.enabled = false;
		this.MyAnim[this.FearAnim].time = UnityEngine.Random.Range(0f, this.MyAnim[this.FearAnim].length);
		this.MyAnim.enabled = true;
	}

	// Token: 0x06001CB9 RID: 7353 RVA: 0x001546C4 File Offset: 0x001528C4
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 1f)
		{
			if (this.Yandere.CanMove)
			{
				if (this.Student.StudentID == 1)
				{
					if (this.Yandere.Armed && !this.Yandere.KillingSenpai)
					{
						this.Yandere.Knife.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.Yandere.MyAudio.clip = this.Yandere.EndSNAP;
						this.Yandere.MyAudio.loop = false;
						this.Yandere.MyAudio.volume = 1f;
						this.Yandere.MyAudio.pitch = 1f;
						this.Yandere.MyAudio.Play();
						this.Yandere.Speed = 0f;
						this.Yandere.MyAnim.CrossFade("f02_snapKill_00");
						this.MyAnim.CrossFade("snapDie_00");
						this.Yandere.TargetStudent = this;
						this.Yandere.KillingSenpai = true;
						this.Yandere.CanMove = false;
						base.enabled = false;
					}
				}
				else if (!this.Yandere.Attacking)
				{
					this.Yandere.transform.position = base.transform.position + base.transform.forward;
					this.Yandere.transform.LookAt(base.transform.position);
					this.Yandere.TargetStudent = this;
					this.Yandere.Attacking = true;
					this.Yandere.CanMove = false;
					this.Yandere.StaticNoise.volume = 0f;
					this.Yandere.Static.Fade = 0f;
					this.Yandere.HurryTimer = 0f;
					this.Yandere.ChooseAttack();
					this.Student.Pathfinding.enabled = false;
					base.enabled = false;
				}
			}
		}
		else if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 5f)
		{
			if (!this.VoicedConcern && this.Yandere.CanMove && !this.Yandere.SnapVoice.isPlaying)
			{
				if (this.Student.StudentID == 1)
				{
					this.Yandere.SnapVoice.clip = this.SenpaiFear;
					this.Yandere.SnapVoice.Play();
					this.Yandere.ListenTimer = 10f;
				}
				else
				{
					int voiceID = this.Yandere.VoiceID;
					while (this.Yandere.VoiceID == voiceID)
					{
						this.Yandere.VoiceID = UnityEngine.Random.Range(0, 5);
					}
					this.Yandere.SnapVoice.clip = this.StudentFear[this.Yandere.VoiceID];
					this.Yandere.SnapVoice.Play();
					this.Yandere.ListenTimer = 1f;
				}
				this.VoicedConcern = true;
			}
			this.MyAnim.Play(this.FearAnim);
		}
		else
		{
			this.MyAnim.Play(this.FearAnim);
		}
		if (!this.Yandere.Attacking)
		{
			base.transform.LookAt(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z));
		}
	}

	// Token: 0x0400338F RID: 13199
	public SnappedYandereScript Yandere;

	// Token: 0x04003390 RID: 13200
	public Quaternion targetRotation;

	// Token: 0x04003391 RID: 13201
	public StudentScript Student;

	// Token: 0x04003392 RID: 13202
	public Animation MyAnim;

	// Token: 0x04003393 RID: 13203
	public string FearAnim;

	// Token: 0x04003394 RID: 13204
	public string[] AttackAnims;

	// Token: 0x04003395 RID: 13205
	public bool VoicedConcern;

	// Token: 0x04003396 RID: 13206
	public AudioClip[] StudentFear;

	// Token: 0x04003397 RID: 13207
	public AudioClip SenpaiFear;
}
