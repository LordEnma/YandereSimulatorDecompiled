using UnityEngine;

public class PersonaSubtitleScript : MonoBehaviour
{
	public SubtitleScript Subtitle;

	public string[] LonerReactions;

	public string[] TeachersPetReactions;

	public string[] HeroicReactions;

	public string[] CowardReactions;

	public string[] EvilReactions;

	public string[] SocialButterflyReactions;

	public string[] LovestruckReactions;

	public string[] DangerousReactions;

	public string[] StrictReactions;

	public string[] PhoneAddictReactions;

	public string[] FragileReactions;

	public string[] SpitefulReactions;

	public string[] SleuthReactions;

	public string[] VengefulReactions;

	public string[] ProtectiveReactions;

	public string[] ViolentReactions;

	public string[] NemesisReactions;

	public string[] IndifferentReactions;

	public string[] SubtitleArray;

	public void UpdateLabel(PersonaType Persona, float Reputation, float Duration)
	{
		switch (Persona)
		{
		case PersonaType.None:
			SubtitleArray = IndifferentReactions;
			break;
		case PersonaType.Loner:
			SubtitleArray = LonerReactions;
			break;
		case PersonaType.TeachersPet:
			SubtitleArray = TeachersPetReactions;
			break;
		case PersonaType.Heroic:
			SubtitleArray = HeroicReactions;
			break;
		case PersonaType.Coward:
			SubtitleArray = CowardReactions;
			break;
		case PersonaType.Evil:
			SubtitleArray = EvilReactions;
			break;
		case PersonaType.SocialButterfly:
			SubtitleArray = SocialButterflyReactions;
			break;
		case PersonaType.Lovestruck:
			SubtitleArray = LovestruckReactions;
			break;
		case PersonaType.Dangerous:
			SubtitleArray = DangerousReactions;
			break;
		case PersonaType.Strict:
			SubtitleArray = StrictReactions;
			break;
		case PersonaType.PhoneAddict:
			SubtitleArray = PhoneAddictReactions;
			break;
		case PersonaType.Fragile:
			SubtitleArray = FragileReactions;
			break;
		case PersonaType.Spiteful:
			SubtitleArray = SpitefulReactions;
			break;
		case PersonaType.Sleuth:
			SubtitleArray = SleuthReactions;
			break;
		case PersonaType.Vengeful:
			SubtitleArray = VengefulReactions;
			break;
		case PersonaType.Protective:
			SubtitleArray = ProtectiveReactions;
			break;
		case PersonaType.Violent:
			SubtitleArray = ViolentReactions;
			break;
		case PersonaType.Nemesis:
			SubtitleArray = NemesisReactions;
			break;
		}
		if (Reputation < -1f / 3f)
		{
			Subtitle.Label.text = SubtitleArray[1];
		}
		else if (Reputation > 1f / 3f)
		{
			Subtitle.Label.text = SubtitleArray[3];
		}
		else
		{
			Subtitle.Label.text = SubtitleArray[2];
		}
		Subtitle.Timer = Duration;
	}
}
