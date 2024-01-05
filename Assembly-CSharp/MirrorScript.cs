using UnityEngine;

public class MirrorScript : MonoBehaviour
{
	public PromptScript Prompt;

	public string[] Personas;

	public string[] Idles;

	public string[] Walks;

	public bool Started;

	public int Limit;

	private void Start()
	{
		Started = true;
		Limit = Idles.Length - 1;
		if (GameGlobals.Eighties)
		{
			Prompt.Yandere.PersonaID = 1;
		}
		if (Prompt.Yandere.Club == ClubType.Delinquent)
		{
			Prompt.Yandere.PersonaID = 13;
			if (Prompt.Yandere.Persona != YanderePersonaType.Tough)
			{
				UpdatePersona();
			}
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (Prompt.Yandere.Health > 0)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.PersonaID++;
				if (Prompt.Yandere.PersonaID == Limit)
				{
					Prompt.Yandere.PersonaID = 0;
				}
				UpdatePersona();
			}
		}
		else if (Prompt.Circle[1].fillAmount == 0f && Prompt.Yandere.Health > 0)
		{
			Prompt.Circle[1].fillAmount = 1f;
			Prompt.Yandere.PersonaID--;
			if (Prompt.Yandere.PersonaID < 0)
			{
				Prompt.Yandere.PersonaID = Limit - 1;
			}
			UpdatePersona();
		}
		if (Prompt.InSight)
		{
			Prompt.Yandere.StudentManager.TutorialWindow.ShowPersonaMessage = true;
		}
	}

	public void UpdatePersona()
	{
		if (!Started)
		{
			Start();
		}
		int personaID = Prompt.Yandere.PersonaID;
		if (!Prompt.Yandere.Carrying)
		{
			if (!Prompt.Yandere.Resting)
			{
				Prompt.Yandere.NotificationManager.PersonaName = Personas[personaID];
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Persona);
			}
			Prompt.Yandere.IdleAnim = Idles[personaID];
			Prompt.Yandere.WalkAnim = Walks[personaID];
			Prompt.Yandere.UpdatePersona(personaID);
		}
		Prompt.Yandere.OriginalIdleAnim = Idles[personaID];
		Prompt.Yandere.OriginalWalkAnim = Walks[personaID];
		Prompt.Yandere.StudentManager.UpdatePerception();
	}
}
