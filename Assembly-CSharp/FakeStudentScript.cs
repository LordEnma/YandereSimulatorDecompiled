using System;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public class FakeStudentScript : MonoBehaviour
{
	// Token: 0x06001494 RID: 5268 RVA: 0x000C94AD File Offset: 0x000C76AD
	private void Start()
	{
		this.targetRotation = base.transform.rotation;
		this.Student.Club = this.Club;
	}

	// Token: 0x06001495 RID: 5269 RVA: 0x000C94D4 File Offset: 0x000C76D4
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

	// Token: 0x04001FE6 RID: 8166
	public StudentManagerScript StudentManager;

	// Token: 0x04001FE7 RID: 8167
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04001FE8 RID: 8168
	public SubtitleScript Subtitle;

	// Token: 0x04001FE9 RID: 8169
	public YandereScript Yandere;

	// Token: 0x04001FEA RID: 8170
	public StudentScript Student;

	// Token: 0x04001FEB RID: 8171
	public PromptScript Prompt;

	// Token: 0x04001FEC RID: 8172
	public Quaternion targetRotation;

	// Token: 0x04001FED RID: 8173
	public float RotationTimer;

	// Token: 0x04001FEE RID: 8174
	public bool Rotate;

	// Token: 0x04001FEF RID: 8175
	public ClubType Club;

	// Token: 0x04001FF0 RID: 8176
	public string LeaderAnim;
}
