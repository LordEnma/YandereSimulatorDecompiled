using System;
using UnityEngine;

// Token: 0x020002C3 RID: 707
public class FakeStudentScript : MonoBehaviour
{
	// Token: 0x0600148A RID: 5258 RVA: 0x000C8B09 File Offset: 0x000C6D09
	private void Start()
	{
		this.targetRotation = base.transform.rotation;
		this.Student.Club = this.Club;
	}

	// Token: 0x0600148B RID: 5259 RVA: 0x000C8B30 File Offset: 0x000C6D30
	private void Update()
	{
		if (!this.Student.Talking)
		{
			if (this.LeaderAnim != "")
			{
				base.GetComponent<Animation>().CrossFade(this.LeaderAnim);
			}
			if (this.Rotate)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				this.RotationTimer += Time.deltaTime;
				if (this.RotationTimer > 1f)
				{
					this.RotationTimer = 0f;
					this.Rotate = false;
				}
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f && !this.Yandere.Chased && this.Yandere.Chasers == 0)
		{
			this.Yandere.TargetStudent = this.Student;
			this.Subtitle.UpdateLabel(SubtitleType.ClubGreeting, (int)this.Student.Club, 4f);
			this.DialogueWheel.ClubLeader = true;
			this.StudentManager.DisablePrompts();
			this.DialogueWheel.HideShadows();
			this.DialogueWheel.Show = true;
			this.DialogueWheel.Panel.enabled = true;
			this.Student.Talking = true;
			this.Student.TalkTimer = 0f;
			this.Yandere.ShoulderCamera.OverShoulder = true;
			this.Yandere.WeaponMenu.KeyboardShow = false;
			this.Yandere.WeaponMenu.Show = false;
			this.Yandere.YandereVision = false;
			this.Yandere.CanMove = false;
			this.Yandere.Talking = true;
			this.RotationTimer = 0f;
			this.Rotate = true;
		}
	}

	// Token: 0x04001FC6 RID: 8134
	public StudentManagerScript StudentManager;

	// Token: 0x04001FC7 RID: 8135
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04001FC8 RID: 8136
	public SubtitleScript Subtitle;

	// Token: 0x04001FC9 RID: 8137
	public YandereScript Yandere;

	// Token: 0x04001FCA RID: 8138
	public StudentScript Student;

	// Token: 0x04001FCB RID: 8139
	public PromptScript Prompt;

	// Token: 0x04001FCC RID: 8140
	public Quaternion targetRotation;

	// Token: 0x04001FCD RID: 8141
	public float RotationTimer;

	// Token: 0x04001FCE RID: 8142
	public bool Rotate;

	// Token: 0x04001FCF RID: 8143
	public ClubType Club;

	// Token: 0x04001FD0 RID: 8144
	public string LeaderAnim;
}
