using System;
using UnityEngine;

// Token: 0x02000398 RID: 920
public class PersonaSubtitleScript : MonoBehaviour
{
	// Token: 0x06001A64 RID: 6756 RVA: 0x0011A27C File Offset: 0x0011847C
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

	// Token: 0x04002B60 RID: 11104
	public SubtitleScript Subtitle;

	// Token: 0x04002B61 RID: 11105
	public string[] LonerReactions;

	// Token: 0x04002B62 RID: 11106
	public string[] TeachersPetReactions;

	// Token: 0x04002B63 RID: 11107
	public string[] HeroicReactions;

	// Token: 0x04002B64 RID: 11108
	public string[] CowardReactions;

	// Token: 0x04002B65 RID: 11109
	public string[] EvilReactions;

	// Token: 0x04002B66 RID: 11110
	public string[] SocialButterflyReactions;

	// Token: 0x04002B67 RID: 11111
	public string[] LovestruckReactions;

	// Token: 0x04002B68 RID: 11112
	public string[] DangerousReactions;

	// Token: 0x04002B69 RID: 11113
	public string[] StrictReactions;

	// Token: 0x04002B6A RID: 11114
	public string[] PhoneAddictReactions;

	// Token: 0x04002B6B RID: 11115
	public string[] FragileReactions;

	// Token: 0x04002B6C RID: 11116
	public string[] SpitefulReactions;

	// Token: 0x04002B6D RID: 11117
	public string[] SleuthReactions;

	// Token: 0x04002B6E RID: 11118
	public string[] VengefulReactions;

	// Token: 0x04002B6F RID: 11119
	public string[] ProtectiveReactions;

	// Token: 0x04002B70 RID: 11120
	public string[] ViolentReactions;

	// Token: 0x04002B71 RID: 11121
	public string[] NemesisReactions;

	// Token: 0x04002B72 RID: 11122
	public string[] IndifferentReactions;

	// Token: 0x04002B73 RID: 11123
	public string[] SubtitleArray;
}
