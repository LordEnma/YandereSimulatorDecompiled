using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
public class PersonaSubtitleScript : MonoBehaviour
{
	// Token: 0x06001A7F RID: 6783 RVA: 0x0011C1D8 File Offset: 0x0011A3D8
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

	// Token: 0x04002BC4 RID: 11204
	public SubtitleScript Subtitle;

	// Token: 0x04002BC5 RID: 11205
	public string[] LonerReactions;

	// Token: 0x04002BC6 RID: 11206
	public string[] TeachersPetReactions;

	// Token: 0x04002BC7 RID: 11207
	public string[] HeroicReactions;

	// Token: 0x04002BC8 RID: 11208
	public string[] CowardReactions;

	// Token: 0x04002BC9 RID: 11209
	public string[] EvilReactions;

	// Token: 0x04002BCA RID: 11210
	public string[] SocialButterflyReactions;

	// Token: 0x04002BCB RID: 11211
	public string[] LovestruckReactions;

	// Token: 0x04002BCC RID: 11212
	public string[] DangerousReactions;

	// Token: 0x04002BCD RID: 11213
	public string[] StrictReactions;

	// Token: 0x04002BCE RID: 11214
	public string[] PhoneAddictReactions;

	// Token: 0x04002BCF RID: 11215
	public string[] FragileReactions;

	// Token: 0x04002BD0 RID: 11216
	public string[] SpitefulReactions;

	// Token: 0x04002BD1 RID: 11217
	public string[] SleuthReactions;

	// Token: 0x04002BD2 RID: 11218
	public string[] VengefulReactions;

	// Token: 0x04002BD3 RID: 11219
	public string[] ProtectiveReactions;

	// Token: 0x04002BD4 RID: 11220
	public string[] ViolentReactions;

	// Token: 0x04002BD5 RID: 11221
	public string[] NemesisReactions;

	// Token: 0x04002BD6 RID: 11222
	public string[] IndifferentReactions;

	// Token: 0x04002BD7 RID: 11223
	public string[] SubtitleArray;
}
