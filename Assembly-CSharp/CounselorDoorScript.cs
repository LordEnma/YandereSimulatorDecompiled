using System;
using UnityEngine;

// Token: 0x02000260 RID: 608
public class CounselorDoorScript : MonoBehaviour
{
	// Token: 0x060012E0 RID: 4832 RVA: 0x000A2465 File Offset: 0x000A0665
	private void Start()
	{
	}

	// Token: 0x060012E1 RID: 4833 RVA: 0x000A2468 File Offset: 0x000A0668
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			bool flag = false;
			for (int i = 1; i < this.Counselor.StudentManager.Students.Length; i++)
			{
				StudentScript studentScript = this.Counselor.StudentManager.Students[i];
				if (studentScript != null && studentScript.Hunting)
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "A murder is taking place!";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					flag = true;
				}
			}
			if (!flag && !this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0 && !this.FadeIn && this.Prompt.Yandere.Bloodiness == 0f && this.Prompt.Yandere.Sanity > 66.66666f && !this.Prompt.Yandere.Carrying && !this.Prompt.Yandere.Dragging)
			{
				if (!this.Counselor.Busy)
				{
					this.Prompt.Yandere.CharacterAnimation.CrossFade(this.Prompt.Yandere.IdleAnim);
					this.Prompt.Yandere.Police.Darkness.enabled = true;
					this.Prompt.Yandere.CanMove = false;
					this.FadeOut = true;
				}
				else
				{
					this.Counselor.CounselorSubtitle.text = this.Counselor.CounselorBusyText;
					this.Counselor.MyAudio.clip = this.Counselor.CounselorBusyClip;
					this.Counselor.MyAudio.Play();
				}
			}
		}
		if (this.FadeOut)
		{
			float a = Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime);
			this.Darkness.color = new Color(0f, 0f, 0f, a);
			if (this.Darkness.color.a == 1f)
			{
				if (!this.Exit)
				{
					this.Prompt.Yandere.CharacterAnimation.Play("f02_sit_00");
					this.Prompt.Yandere.transform.position = new Vector3(-27.51f, 0f, 12f);
					this.Prompt.Yandere.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
					this.Counselor.Talk();
					this.FadeOut = false;
					this.FadeIn = true;
				}
				else
				{
					if (this.Counselor.Yandere.VtuberID > 0)
					{
						this.Counselor.Yandere.VtuberFace();
					}
					else if (this.Counselor.Eighties)
					{
						this.Counselor.Yandere.RestoreGentleEyes();
					}
					this.Darkness.color = new Color(0f, 0f, 0f, 2f);
					this.Counselor.Quit();
					this.FadeOut = false;
					this.FadeIn = true;
					this.Exit = false;
				}
			}
		}
		if (this.FadeIn)
		{
			float a2 = Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime);
			this.Darkness.color = new Color(0f, 0f, 0f, a2);
			if (this.Darkness.color.a == 0f)
			{
				this.FadeIn = false;
			}
		}
	}

	// Token: 0x040019FC RID: 6652
	public CounselorScript Counselor;

	// Token: 0x040019FD RID: 6653
	public PromptScript Prompt;

	// Token: 0x040019FE RID: 6654
	public UISprite Darkness;

	// Token: 0x040019FF RID: 6655
	public bool FadeOut;

	// Token: 0x04001A00 RID: 6656
	public bool FadeIn;

	// Token: 0x04001A01 RID: 6657
	public bool Exit;
}
