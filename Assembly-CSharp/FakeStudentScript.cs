using System;
using UnityEngine;

// Token: 0x020002BF RID: 703
public class FakeStudentScript : MonoBehaviour
{
	// Token: 0x06001470 RID: 5232 RVA: 0x000C7051 File Offset: 0x000C5251
	private void Start()
	{
		this.targetRotation = base.transform.rotation;
		this.Student.Club = this.Club;
	}

	// Token: 0x06001471 RID: 5233 RVA: 0x000C7078 File Offset: 0x000C5278
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

	// Token: 0x04001F81 RID: 8065
	public StudentManagerScript StudentManager;

	// Token: 0x04001F82 RID: 8066
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04001F83 RID: 8067
	public SubtitleScript Subtitle;

	// Token: 0x04001F84 RID: 8068
	public YandereScript Yandere;

	// Token: 0x04001F85 RID: 8069
	public StudentScript Student;

	// Token: 0x04001F86 RID: 8070
	public PromptScript Prompt;

	// Token: 0x04001F87 RID: 8071
	public Quaternion targetRotation;

	// Token: 0x04001F88 RID: 8072
	public float RotationTimer;

	// Token: 0x04001F89 RID: 8073
	public bool Rotate;

	// Token: 0x04001F8A RID: 8074
	public ClubType Club;

	// Token: 0x04001F8B RID: 8075
	public string LeaderAnim;
}
