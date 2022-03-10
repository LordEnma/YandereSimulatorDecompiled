using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
public class PersonaSubtitleScript : MonoBehaviour
{
	// Token: 0x06001A6E RID: 6766 RVA: 0x0011B068 File Offset: 0x00119268
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

	// Token: 0x04002B86 RID: 11142
	public SubtitleScript Subtitle;

	// Token: 0x04002B87 RID: 11143
	public string[] LonerReactions;

	// Token: 0x04002B88 RID: 11144
	public string[] TeachersPetReactions;

	// Token: 0x04002B89 RID: 11145
	public string[] HeroicReactions;

	// Token: 0x04002B8A RID: 11146
	public string[] CowardReactions;

	// Token: 0x04002B8B RID: 11147
	public string[] EvilReactions;

	// Token: 0x04002B8C RID: 11148
	public string[] SocialButterflyReactions;

	// Token: 0x04002B8D RID: 11149
	public string[] LovestruckReactions;

	// Token: 0x04002B8E RID: 11150
	public string[] DangerousReactions;

	// Token: 0x04002B8F RID: 11151
	public string[] StrictReactions;

	// Token: 0x04002B90 RID: 11152
	public string[] PhoneAddictReactions;

	// Token: 0x04002B91 RID: 11153
	public string[] FragileReactions;

	// Token: 0x04002B92 RID: 11154
	public string[] SpitefulReactions;

	// Token: 0x04002B93 RID: 11155
	public string[] SleuthReactions;

	// Token: 0x04002B94 RID: 11156
	public string[] VengefulReactions;

	// Token: 0x04002B95 RID: 11157
	public string[] ProtectiveReactions;

	// Token: 0x04002B96 RID: 11158
	public string[] ViolentReactions;

	// Token: 0x04002B97 RID: 11159
	public string[] NemesisReactions;

	// Token: 0x04002B98 RID: 11160
	public string[] IndifferentReactions;

	// Token: 0x04002B99 RID: 11161
	public string[] SubtitleArray;
}
