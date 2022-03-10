using System;
using UnityEngine;

// Token: 0x020002C3 RID: 707
public class FakeStudentScript : MonoBehaviour
{
	// Token: 0x0600148A RID: 5258 RVA: 0x000C8C55 File Offset: 0x000C6E55
	private void Start()
	{
		this.targetRotation = base.transform.rotation;
		this.Student.Club = this.Club;
	}

	// Token: 0x0600148B RID: 5259 RVA: 0x000C8C7C File Offset: 0x000C6E7C
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

	// Token: 0x04001FCF RID: 8143
	public StudentManagerScript StudentManager;

	// Token: 0x04001FD0 RID: 8144
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04001FD1 RID: 8145
	public SubtitleScript Subtitle;

	// Token: 0x04001FD2 RID: 8146
	public YandereScript Yandere;

	// Token: 0x04001FD3 RID: 8147
	public StudentScript Student;

	// Token: 0x04001FD4 RID: 8148
	public PromptScript Prompt;

	// Token: 0x04001FD5 RID: 8149
	public Quaternion targetRotation;

	// Token: 0x04001FD6 RID: 8150
	public float RotationTimer;

	// Token: 0x04001FD7 RID: 8151
	public bool Rotate;

	// Token: 0x04001FD8 RID: 8152
	public ClubType Club;

	// Token: 0x04001FD9 RID: 8153
	public string LeaderAnim;
}
