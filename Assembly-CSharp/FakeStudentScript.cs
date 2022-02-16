using System;
using UnityEngine;

// Token: 0x020002C2 RID: 706
public class FakeStudentScript : MonoBehaviour
{
	// Token: 0x06001481 RID: 5249 RVA: 0x000C8225 File Offset: 0x000C6425
	private void Start()
	{
		this.targetRotation = base.transform.rotation;
		this.Student.Club = this.Club;
	}

	// Token: 0x06001482 RID: 5250 RVA: 0x000C824C File Offset: 0x000C644C
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

	// Token: 0x04001FB7 RID: 8119
	public StudentManagerScript StudentManager;

	// Token: 0x04001FB8 RID: 8120
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04001FB9 RID: 8121
	public SubtitleScript Subtitle;

	// Token: 0x04001FBA RID: 8122
	public YandereScript Yandere;

	// Token: 0x04001FBB RID: 8123
	public StudentScript Student;

	// Token: 0x04001FBC RID: 8124
	public PromptScript Prompt;

	// Token: 0x04001FBD RID: 8125
	public Quaternion targetRotation;

	// Token: 0x04001FBE RID: 8126
	public float RotationTimer;

	// Token: 0x04001FBF RID: 8127
	public bool Rotate;

	// Token: 0x04001FC0 RID: 8128
	public ClubType Club;

	// Token: 0x04001FC1 RID: 8129
	public string LeaderAnim;
}
