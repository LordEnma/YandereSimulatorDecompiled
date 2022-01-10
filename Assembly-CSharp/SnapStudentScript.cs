using System;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public class SnapStudentScript : MonoBehaviour
{
	// Token: 0x06001CB5 RID: 7349 RVA: 0x00152A1C File Offset: 0x00150C1C
	private void Start()
	{
		this.MyAnim.enabled = false;
		this.MyAnim[this.FearAnim].time = UnityEngine.Random.Range(0f, this.MyAnim[this.FearAnim].length);
		this.MyAnim.enabled = true;
	}

	// Token: 0x06001CB6 RID: 7350 RVA: 0x00152A78 File Offset: 0x00150C78
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

	// Token: 0x04003383 RID: 13187
	public SnappedYandereScript Yandere;

	// Token: 0x04003384 RID: 13188
	public Quaternion targetRotation;

	// Token: 0x04003385 RID: 13189
	public StudentScript Student;

	// Token: 0x04003386 RID: 13190
	public Animation MyAnim;

	// Token: 0x04003387 RID: 13191
	public string FearAnim;

	// Token: 0x04003388 RID: 13192
	public string[] AttackAnims;

	// Token: 0x04003389 RID: 13193
	public bool VoicedConcern;

	// Token: 0x0400338A RID: 13194
	public AudioClip[] StudentFear;

	// Token: 0x0400338B RID: 13195
	public AudioClip SenpaiFear;
}
