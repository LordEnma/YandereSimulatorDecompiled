using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
public class PersonaSubtitleScript : MonoBehaviour
{
	// Token: 0x06001A78 RID: 6776 RVA: 0x0011BB78 File Offset: 0x00119D78
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

	// Token: 0x04002BAF RID: 11183
	public SubtitleScript Subtitle;

	// Token: 0x04002BB0 RID: 11184
	public string[] LonerReactions;

	// Token: 0x04002BB1 RID: 11185
	public string[] TeachersPetReactions;

	// Token: 0x04002BB2 RID: 11186
	public string[] HeroicReactions;

	// Token: 0x04002BB3 RID: 11187
	public string[] CowardReactions;

	// Token: 0x04002BB4 RID: 11188
	public string[] EvilReactions;

	// Token: 0x04002BB5 RID: 11189
	public string[] SocialButterflyReactions;

	// Token: 0x04002BB6 RID: 11190
	public string[] LovestruckReactions;

	// Token: 0x04002BB7 RID: 11191
	public string[] DangerousReactions;

	// Token: 0x04002BB8 RID: 11192
	public string[] StrictReactions;

	// Token: 0x04002BB9 RID: 11193
	public string[] PhoneAddictReactions;

	// Token: 0x04002BBA RID: 11194
	public string[] FragileReactions;

	// Token: 0x04002BBB RID: 11195
	public string[] SpitefulReactions;

	// Token: 0x04002BBC RID: 11196
	public string[] SleuthReactions;

	// Token: 0x04002BBD RID: 11197
	public string[] VengefulReactions;

	// Token: 0x04002BBE RID: 11198
	public string[] ProtectiveReactions;

	// Token: 0x04002BBF RID: 11199
	public string[] ViolentReactions;

	// Token: 0x04002BC0 RID: 11200
	public string[] NemesisReactions;

	// Token: 0x04002BC1 RID: 11201
	public string[] IndifferentReactions;

	// Token: 0x04002BC2 RID: 11202
	public string[] SubtitleArray;
}
