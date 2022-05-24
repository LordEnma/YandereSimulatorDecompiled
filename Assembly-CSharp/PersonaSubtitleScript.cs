using System;
using UnityEngine;

// Token: 0x0200039D RID: 925
public class PersonaSubtitleScript : MonoBehaviour
{
	// Token: 0x06001A94 RID: 6804 RVA: 0x0011D788 File Offset: 0x0011B988
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

	// Token: 0x04002BF1 RID: 11249
	public SubtitleScript Subtitle;

	// Token: 0x04002BF2 RID: 11250
	public string[] LonerReactions;

	// Token: 0x04002BF3 RID: 11251
	public string[] TeachersPetReactions;

	// Token: 0x04002BF4 RID: 11252
	public string[] HeroicReactions;

	// Token: 0x04002BF5 RID: 11253
	public string[] CowardReactions;

	// Token: 0x04002BF6 RID: 11254
	public string[] EvilReactions;

	// Token: 0x04002BF7 RID: 11255
	public string[] SocialButterflyReactions;

	// Token: 0x04002BF8 RID: 11256
	public string[] LovestruckReactions;

	// Token: 0x04002BF9 RID: 11257
	public string[] DangerousReactions;

	// Token: 0x04002BFA RID: 11258
	public string[] StrictReactions;

	// Token: 0x04002BFB RID: 11259
	public string[] PhoneAddictReactions;

	// Token: 0x04002BFC RID: 11260
	public string[] FragileReactions;

	// Token: 0x04002BFD RID: 11261
	public string[] SpitefulReactions;

	// Token: 0x04002BFE RID: 11262
	public string[] SleuthReactions;

	// Token: 0x04002BFF RID: 11263
	public string[] VengefulReactions;

	// Token: 0x04002C00 RID: 11264
	public string[] ProtectiveReactions;

	// Token: 0x04002C01 RID: 11265
	public string[] ViolentReactions;

	// Token: 0x04002C02 RID: 11266
	public string[] NemesisReactions;

	// Token: 0x04002C03 RID: 11267
	public string[] IndifferentReactions;

	// Token: 0x04002C04 RID: 11268
	public string[] SubtitleArray;
}
