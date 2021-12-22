using System;
using UnityEngine;

// Token: 0x02000395 RID: 917
public class PersonaSubtitleScript : MonoBehaviour
{
	// Token: 0x06001A51 RID: 6737 RVA: 0x00119174 File Offset: 0x00117374
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

	// Token: 0x04002B43 RID: 11075
	public SubtitleScript Subtitle;

	// Token: 0x04002B44 RID: 11076
	public string[] LonerReactions;

	// Token: 0x04002B45 RID: 11077
	public string[] TeachersPetReactions;

	// Token: 0x04002B46 RID: 11078
	public string[] HeroicReactions;

	// Token: 0x04002B47 RID: 11079
	public string[] CowardReactions;

	// Token: 0x04002B48 RID: 11080
	public string[] EvilReactions;

	// Token: 0x04002B49 RID: 11081
	public string[] SocialButterflyReactions;

	// Token: 0x04002B4A RID: 11082
	public string[] LovestruckReactions;

	// Token: 0x04002B4B RID: 11083
	public string[] DangerousReactions;

	// Token: 0x04002B4C RID: 11084
	public string[] StrictReactions;

	// Token: 0x04002B4D RID: 11085
	public string[] PhoneAddictReactions;

	// Token: 0x04002B4E RID: 11086
	public string[] FragileReactions;

	// Token: 0x04002B4F RID: 11087
	public string[] SpitefulReactions;

	// Token: 0x04002B50 RID: 11088
	public string[] SleuthReactions;

	// Token: 0x04002B51 RID: 11089
	public string[] VengefulReactions;

	// Token: 0x04002B52 RID: 11090
	public string[] ProtectiveReactions;

	// Token: 0x04002B53 RID: 11091
	public string[] ViolentReactions;

	// Token: 0x04002B54 RID: 11092
	public string[] NemesisReactions;

	// Token: 0x04002B55 RID: 11093
	public string[] IndifferentReactions;

	// Token: 0x04002B56 RID: 11094
	public string[] SubtitleArray;
}
