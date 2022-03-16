using System;
using UnityEngine;

// Token: 0x0200026D RID: 621
public class CutsceneManagerScript : MonoBehaviour
{
	// Token: 0x0600132E RID: 4910 RVA: 0x000AB2D4 File Offset: 0x000A94D4
	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.Phase == 1)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f)
			{
				if (this.Scheme == 5)
				{
					this.Phase++;
					return;
				}
				this.Phase = 4;
				return;
			}
		}
		else
		{
			if (this.Phase == 2)
			{
				this.Subtitle.text = this.Text[this.Line];
				component.clip = this.Voice[this.Line];
				component.Play();
				this.Phase++;
				return;
			}
			if (this.Phase == 3)
			{
				if (!component.isPlaying || Input.GetButtonDown("A"))
				{
					if (this.Line < 2)
					{
						this.Phase--;
						this.Line++;
						return;
					}
					this.Subtitle.text = string.Empty;
					this.Phase++;
					return;
				}
			}
			else
			{
				if (this.Phase == 4)
				{
					Debug.Log("We're activating EndOfDay from CutsceneManager.");
					this.EndOfDay.gameObject.SetActive(true);
					this.EndOfDay.Phase = 14;
					if (this.Scheme == 5)
					{
						this.Counselor.LecturePhase = 5;
					}
					else
					{
						this.Counselor.LecturePhase = 1;
					}
					this.Phase++;
					return;
				}
				if (this.Phase == 6)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
					if (this.Darkness.color.a == 0f)
					{
						this.Phase++;
						return;
					}
				}
				else if (this.Phase == 7)
				{
					if (this.Scheme == 5)
					{
						this.StudentManager.Students[this.StudentManager.RivalID] != null;
					}
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Portal.Proceed = true;
					base.gameObject.SetActive(false);
					this.Scheme = 0;
				}
			}
		}
	}

	// Token: 0x04001B73 RID: 7027
	public StudentManagerScript StudentManager;

	// Token: 0x04001B74 RID: 7028
	public CounselorScript Counselor;

	// Token: 0x04001B75 RID: 7029
	public PromptBarScript PromptBar;

	// Token: 0x04001B76 RID: 7030
	public EndOfDayScript EndOfDay;

	// Token: 0x04001B77 RID: 7031
	public PortalScript Portal;

	// Token: 0x04001B78 RID: 7032
	public UISprite Darkness;

	// Token: 0x04001B79 RID: 7033
	public UILabel Subtitle;

	// Token: 0x04001B7A RID: 7034
	public AudioClip[] Voice;

	// Token: 0x04001B7B RID: 7035
	public string[] Text;

	// Token: 0x04001B7C RID: 7036
	public int Scheme;

	// Token: 0x04001B7D RID: 7037
	public int Phase = 1;

	// Token: 0x04001B7E RID: 7038
	public int Line = 1;
}
