using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
public class PersonaSubtitleScript : MonoBehaviour
{
	// Token: 0x06001A6D RID: 6765 RVA: 0x0011AC90 File Offset: 0x00118E90
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

	// Token: 0x04002B70 RID: 11120
	public SubtitleScript Subtitle;

	// Token: 0x04002B71 RID: 11121
	public string[] LonerReactions;

	// Token: 0x04002B72 RID: 11122
	public string[] TeachersPetReactions;

	// Token: 0x04002B73 RID: 11123
	public string[] HeroicReactions;

	// Token: 0x04002B74 RID: 11124
	public string[] CowardReactions;

	// Token: 0x04002B75 RID: 11125
	public string[] EvilReactions;

	// Token: 0x04002B76 RID: 11126
	public string[] SocialButterflyReactions;

	// Token: 0x04002B77 RID: 11127
	public string[] LovestruckReactions;

	// Token: 0x04002B78 RID: 11128
	public string[] DangerousReactions;

	// Token: 0x04002B79 RID: 11129
	public string[] StrictReactions;

	// Token: 0x04002B7A RID: 11130
	public string[] PhoneAddictReactions;

	// Token: 0x04002B7B RID: 11131
	public string[] FragileReactions;

	// Token: 0x04002B7C RID: 11132
	public string[] SpitefulReactions;

	// Token: 0x04002B7D RID: 11133
	public string[] SleuthReactions;

	// Token: 0x04002B7E RID: 11134
	public string[] VengefulReactions;

	// Token: 0x04002B7F RID: 11135
	public string[] ProtectiveReactions;

	// Token: 0x04002B80 RID: 11136
	public string[] ViolentReactions;

	// Token: 0x04002B81 RID: 11137
	public string[] NemesisReactions;

	// Token: 0x04002B82 RID: 11138
	public string[] IndifferentReactions;

	// Token: 0x04002B83 RID: 11139
	public string[] SubtitleArray;
}
