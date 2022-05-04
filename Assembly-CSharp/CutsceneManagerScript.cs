using System;
using UnityEngine;

// Token: 0x0200026D RID: 621
public class CutsceneManagerScript : MonoBehaviour
{
	// Token: 0x06001333 RID: 4915 RVA: 0x000AB960 File Offset: 0x000A9B60
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

	// Token: 0x04001B7F RID: 7039
	public StudentManagerScript StudentManager;

	// Token: 0x04001B80 RID: 7040
	public CounselorScript Counselor;

	// Token: 0x04001B81 RID: 7041
	public PromptBarScript PromptBar;

	// Token: 0x04001B82 RID: 7042
	public EndOfDayScript EndOfDay;

	// Token: 0x04001B83 RID: 7043
	public PortalScript Portal;

	// Token: 0x04001B84 RID: 7044
	public UISprite Darkness;

	// Token: 0x04001B85 RID: 7045
	public UILabel Subtitle;

	// Token: 0x04001B86 RID: 7046
	public AudioClip[] Voice;

	// Token: 0x04001B87 RID: 7047
	public string[] Text;

	// Token: 0x04001B88 RID: 7048
	public int Scheme;

	// Token: 0x04001B89 RID: 7049
	public int Phase = 1;

	// Token: 0x04001B8A RID: 7050
	public int Line = 1;
}
