using System;
using UnityEngine;

// Token: 0x0200026B RID: 619
public class CutsceneManagerScript : MonoBehaviour
{
	// Token: 0x0600131F RID: 4895 RVA: 0x000AA1E4 File Offset: 0x000A83E4
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

	// Token: 0x04001B35 RID: 6965
	public StudentManagerScript StudentManager;

	// Token: 0x04001B36 RID: 6966
	public CounselorScript Counselor;

	// Token: 0x04001B37 RID: 6967
	public PromptBarScript PromptBar;

	// Token: 0x04001B38 RID: 6968
	public EndOfDayScript EndOfDay;

	// Token: 0x04001B39 RID: 6969
	public PortalScript Portal;

	// Token: 0x04001B3A RID: 6970
	public UISprite Darkness;

	// Token: 0x04001B3B RID: 6971
	public UILabel Subtitle;

	// Token: 0x04001B3C RID: 6972
	public AudioClip[] Voice;

	// Token: 0x04001B3D RID: 6973
	public string[] Text;

	// Token: 0x04001B3E RID: 6974
	public int Scheme;

	// Token: 0x04001B3F RID: 6975
	public int Phase = 1;

	// Token: 0x04001B40 RID: 6976
	public int Line = 1;
}
