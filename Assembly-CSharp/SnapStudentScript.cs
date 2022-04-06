using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SnapStudentScript : MonoBehaviour
{
	// Token: 0x06001CEA RID: 7402 RVA: 0x001578C0 File Offset: 0x00155AC0
	private void Start()
	{
		this.MyAnim.enabled = false;
		this.MyAnim[this.FearAnim].time = UnityEngine.Random.Range(0f, this.MyAnim[this.FearAnim].length);
		this.MyAnim.enabled = true;
	}

	// Token: 0x06001CEB RID: 7403 RVA: 0x0015791C File Offset: 0x00155B1C
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

	// Token: 0x04003412 RID: 13330
	public SnappedYandereScript Yandere;

	// Token: 0x04003413 RID: 13331
	public Quaternion targetRotation;

	// Token: 0x04003414 RID: 13332
	public StudentScript Student;

	// Token: 0x04003415 RID: 13333
	public Animation MyAnim;

	// Token: 0x04003416 RID: 13334
	public string FearAnim;

	// Token: 0x04003417 RID: 13335
	public string[] AttackAnims;

	// Token: 0x04003418 RID: 13336
	public bool VoicedConcern;

	// Token: 0x04003419 RID: 13337
	public AudioClip[] StudentFear;

	// Token: 0x0400341A RID: 13338
	public AudioClip SenpaiFear;
}
