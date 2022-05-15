using System;
using UnityEngine;

// Token: 0x020002C5 RID: 709
public class FakeStudentScript : MonoBehaviour
{
	// Token: 0x0600149A RID: 5274 RVA: 0x000C9C3D File Offset: 0x000C7E3D
	private void Start()
	{
		this.targetRotation = base.transform.rotation;
		this.Student.Club = this.Club;
	}

	// Token: 0x0600149B RID: 5275 RVA: 0x000C9C64 File Offset: 0x000C7E64
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

	// Token: 0x04001FF6 RID: 8182
	public StudentManagerScript StudentManager;

	// Token: 0x04001FF7 RID: 8183
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04001FF8 RID: 8184
	public SubtitleScript Subtitle;

	// Token: 0x04001FF9 RID: 8185
	public YandereScript Yandere;

	// Token: 0x04001FFA RID: 8186
	public StudentScript Student;

	// Token: 0x04001FFB RID: 8187
	public PromptScript Prompt;

	// Token: 0x04001FFC RID: 8188
	public Quaternion targetRotation;

	// Token: 0x04001FFD RID: 8189
	public float RotationTimer;

	// Token: 0x04001FFE RID: 8190
	public bool Rotate;

	// Token: 0x04001FFF RID: 8191
	public ClubType Club;

	// Token: 0x04002000 RID: 8192
	public string LeaderAnim;
}
