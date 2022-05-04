using System;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public class FakeStudentScript : MonoBehaviour
{
	// Token: 0x06001498 RID: 5272 RVA: 0x000C9941 File Offset: 0x000C7B41
	private void Start()
	{
		this.targetRotation = base.transform.rotation;
		this.Student.Club = this.Club;
	}

	// Token: 0x06001499 RID: 5273 RVA: 0x000C9968 File Offset: 0x000C7B68
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

	// Token: 0x04001FEF RID: 8175
	public StudentManagerScript StudentManager;

	// Token: 0x04001FF0 RID: 8176
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04001FF1 RID: 8177
	public SubtitleScript Subtitle;

	// Token: 0x04001FF2 RID: 8178
	public YandereScript Yandere;

	// Token: 0x04001FF3 RID: 8179
	public StudentScript Student;

	// Token: 0x04001FF4 RID: 8180
	public PromptScript Prompt;

	// Token: 0x04001FF5 RID: 8181
	public Quaternion targetRotation;

	// Token: 0x04001FF6 RID: 8182
	public float RotationTimer;

	// Token: 0x04001FF7 RID: 8183
	public bool Rotate;

	// Token: 0x04001FF8 RID: 8184
	public ClubType Club;

	// Token: 0x04001FF9 RID: 8185
	public string LeaderAnim;
}
