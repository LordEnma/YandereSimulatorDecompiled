using System;
using UnityEngine;

// Token: 0x02000394 RID: 916
public class PersonaSubtitleScript : MonoBehaviour
{
	// Token: 0x06001A49 RID: 6729 RVA: 0x00118934 File Offset: 0x00116B34
	public void UpdateLabel(PersonaType Persona, float Reputation, float Duration)
	{
		switch (Persona)
		{
		case PersonaType.None:
			this.SubtitleArray = this.IndifferentReactions;
			break;
		case PersonaType.Loner:
			this.SubtitleArray = this.LonerReactions;
			break;
		case PersonaType.TeachersPet:
			this.SubtitleArray = this.TeachersPetReactions;
			break;
		case PersonaType.Heroic:
			this.SubtitleArray = this.HeroicReactions;
			break;
		case PersonaType.Coward:
			this.SubtitleArray = this.CowardReactions;
			break;
		case PersonaType.Evil:
			this.SubtitleArray = this.EvilReactions;
			break;
		case PersonaType.SocialButterfly:
			this.SubtitleArray = this.SocialButterflyReactions;
			break;
		case PersonaType.Lovestruck:
			this.SubtitleArray = this.LovestruckReactions;
			break;
		case PersonaType.Dangerous:
			this.SubtitleArray = this.DangerousReactions;
			break;
		case PersonaType.Strict:
			this.SubtitleArray = this.StrictReactions;
			break;
		case PersonaType.PhoneAddict:
			this.SubtitleArray = this.PhoneAddictReactions;
			break;
		case PersonaType.Fragile:
			this.SubtitleArray = this.FragileReactions;
			break;
		case PersonaType.Spiteful:
			this.SubtitleArray = this.SpitefulReactions;
			break;
		case PersonaType.Sleuth:
			this.SubtitleArray = this.SleuthReactions;
			break;
		case PersonaType.Vengeful:
			this.SubtitleArray = this.VengefulReactions;
			break;
		case PersonaType.Protective:
			this.SubtitleArray = this.ProtectiveReactions;
			break;
		case PersonaType.Violent:
			this.SubtitleArray = this.ViolentReactions;
			break;
		default:
			if (Persona == PersonaType.Nemesis)
			{
				this.SubtitleArray = this.NemesisReactions;
			}
			break;
		}
		if (Reputation < -0.33333334f)
		{
			this.Subtitle.Label.text = this.SubtitleArray[1];
		}
		else if (Reputation > 0.33333334f)
		{
			this.Subtitle.Label.text = this.SubtitleArray[3];
		}
		else
		{
			this.Subtitle.Label.text = this.SubtitleArray[2];
		}
		this.Subtitle.Timer = Duration;
	}

	// Token: 0x04002B19 RID: 11033
	public SubtitleScript Subtitle;

	// Token: 0x04002B1A RID: 11034
	public string[] LonerReactions;

	// Token: 0x04002B1B RID: 11035
	public string[] TeachersPetReactions;

	// Token: 0x04002B1C RID: 11036
	public string[] HeroicReactions;

	// Token: 0x04002B1D RID: 11037
	public string[] CowardReactions;

	// Token: 0x04002B1E RID: 11038
	public string[] EvilReactions;

	// Token: 0x04002B1F RID: 11039
	public string[] SocialButterflyReactions;

	// Token: 0x04002B20 RID: 11040
	public string[] LovestruckReactions;

	// Token: 0x04002B21 RID: 11041
	public string[] DangerousReactions;

	// Token: 0x04002B22 RID: 11042
	public string[] StrictReactions;

	// Token: 0x04002B23 RID: 11043
	public string[] PhoneAddictReactions;

	// Token: 0x04002B24 RID: 11044
	public string[] FragileReactions;

	// Token: 0x04002B25 RID: 11045
	public string[] SpitefulReactions;

	// Token: 0x04002B26 RID: 11046
	public string[] SleuthReactions;

	// Token: 0x04002B27 RID: 11047
	public string[] VengefulReactions;

	// Token: 0x04002B28 RID: 11048
	public string[] ProtectiveReactions;

	// Token: 0x04002B29 RID: 11049
	public string[] ViolentReactions;

	// Token: 0x04002B2A RID: 11050
	public string[] NemesisReactions;

	// Token: 0x04002B2B RID: 11051
	public string[] IndifferentReactions;

	// Token: 0x04002B2C RID: 11052
	public string[] SubtitleArray;
}
