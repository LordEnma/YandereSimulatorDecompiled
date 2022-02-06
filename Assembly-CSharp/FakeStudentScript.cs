using System;
using UnityEngine;

// Token: 0x020002C1 RID: 705
public class FakeStudentScript : MonoBehaviour
{
	// Token: 0x0600147C RID: 5244 RVA: 0x000C8131 File Offset: 0x000C6331
	private void Start()
	{
		this.targetRotation = base.transform.rotation;
		this.Student.Club = this.Club;
	}

	// Token: 0x0600147D RID: 5245 RVA: 0x000C8158 File Offset: 0x000C6358
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

	// Token: 0x04001FB2 RID: 8114
	public StudentManagerScript StudentManager;

	// Token: 0x04001FB3 RID: 8115
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04001FB4 RID: 8116
	public SubtitleScript Subtitle;

	// Token: 0x04001FB5 RID: 8117
	public YandereScript Yandere;

	// Token: 0x04001FB6 RID: 8118
	public StudentScript Student;

	// Token: 0x04001FB7 RID: 8119
	public PromptScript Prompt;

	// Token: 0x04001FB8 RID: 8120
	public Quaternion targetRotation;

	// Token: 0x04001FB9 RID: 8121
	public float RotationTimer;

	// Token: 0x04001FBA RID: 8122
	public bool Rotate;

	// Token: 0x04001FBB RID: 8123
	public ClubType Club;

	// Token: 0x04001FBC RID: 8124
	public string LeaderAnim;
}
