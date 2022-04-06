using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HintScript : MonoBehaviour
{
	// Token: 0x0600186A RID: 6250 RVA: 0x000EBD90 File Offset: 0x000E9F90
	private void Start()
	{
		base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
		if (DateGlobals.Week > 1 || GameGlobals.Eighties)
		{
			base.gameObject.SetActive(false);
		}
		if (OptionGlobals.HintsOff)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600186B RID: 6251 RVA: 0x000EBDE8 File Offset: 0x000E9FE8
	private void Update()
	{
		if (this.MyPanel.alpha == 1f)
		{
			if (this.Show)
			{
				if (this.Speed == 5f)
				{
					this.MyAudio.Play();
					this.Speed = 0f;
				}
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 0f, 1f), Time.deltaTime * 10f);
				this.Timer += Time.deltaTime;
				if (this.Timer > 5f)
				{
					this.Show = false;
				}
				if (Input.GetButtonDown("Start") && !this.PauseScreen.Yandere.Shutter.Snapping && !this.PauseScreen.Yandere.TimeSkipping && !this.PauseScreen.Yandere.Talking && !this.PauseScreen.Yandere.Noticed && !this.PauseScreen.Yandere.InClass && !this.PauseScreen.Yandere.Struggling && !this.PauseScreen.Yandere.Won && !this.PauseScreen.Yandere.Dismembering && !this.PauseScreen.Yandere.Attacked && this.PauseScreen.Yandere.CanMove && !this.PauseScreen.Yandere.Chased && this.PauseScreen.Yandere.Chasers == 0 && !this.PauseScreen.Yandere.YandereVision && Time.timeScale > 0.0001f && !this.PauseScreen.Schedule.gameObject.activeInHierarchy)
				{
					if (this.DisplayTutorial)
					{
						this.PauseScreen.Yandere.StudentManager.TutorialWindow.SummonWindow();
						this.DisplayTutorial = false;
					}
					else
					{
						this.PauseScreen.ShowScheduleScreen();
						this.PauseScreen.Sideways = true;
						this.PauseScreen.Schedule.JumpToEvent(this.QuickID);
					}
					base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
					this.Show = false;
					this.Speed = 5f;
					this.Timer = 0f;
					return;
				}
			}
			else if (this.Speed < 5f)
			{
				this.Timer = 0f;
				this.Speed = Mathf.MoveTowards(this.Speed, 5f, Time.deltaTime);
				base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, new Vector3(0.2043f, 0f, 1f), this.Speed * Time.deltaTime * 0.0166666f);
				if (this.Speed == 5f)
				{
					base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
					this.DisplayTutorial = false;
				}
				if (Input.GetButtonDown("Start") && !this.PauseScreen.Yandere.Shutter.Snapping && !this.PauseScreen.Yandere.TimeSkipping && !this.PauseScreen.Yandere.Talking && !this.PauseScreen.Yandere.Noticed && !this.PauseScreen.Yandere.InClass && !this.PauseScreen.Yandere.Struggling && !this.PauseScreen.Yandere.Won && !this.PauseScreen.Yandere.Dismembering && !this.PauseScreen.Yandere.Attacked && this.PauseScreen.Yandere.CanMove && !this.PauseScreen.Yandere.Chased && this.PauseScreen.Yandere.Chasers == 0 && !this.PauseScreen.Yandere.YandereVision && Time.timeScale > 0.0001f && !this.PauseScreen.Schedule.gameObject.activeInHierarchy)
				{
					if (this.DisplayTutorial)
					{
						this.PauseScreen.Yandere.StudentManager.TutorialWindow.SummonWindow();
						this.DisplayTutorial = false;
					}
					else
					{
						this.PauseScreen.ShowScheduleScreen();
						this.PauseScreen.Sideways = true;
						this.PauseScreen.Schedule.JumpToEvent(this.QuickID);
					}
					base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
					this.Speed = 5f;
				}
			}
		}
	}

	// Token: 0x0400244D RID: 9293
	public PauseScreenScript PauseScreen;

	// Token: 0x0400244E RID: 9294
	public AudioSource MyAudio;

	// Token: 0x0400244F RID: 9295
	public float Speed = 10f;

	// Token: 0x04002450 RID: 9296
	public float Timer;

	// Token: 0x04002451 RID: 9297
	public int QuickID;

	// Token: 0x04002452 RID: 9298
	public bool DisplayTutorial;

	// Token: 0x04002453 RID: 9299
	public bool Show;

	// Token: 0x04002454 RID: 9300
	public UIPanel MyPanel;
}
