using System;
using UnityEngine;

// Token: 0x0200036A RID: 874
public class MirrorScript : MonoBehaviour
{
	// Token: 0x060019C8 RID: 6600 RVA: 0x00108350 File Offset: 0x00106550
	private void Start()
	{
		this.Started = true;
		this.Limit = this.Idles.Length - 1;
		if (this.Prompt.Yandere.Club == ClubType.Delinquent)
		{
			this.Prompt.Yandere.PersonaID = 10;
			if (this.Prompt.Yandere.Persona != YanderePersonaType.Tough)
			{
				this.UpdatePersona();
			}
		}
		if (GameGlobals.Eighties)
		{
			this.Idles[0] = "f02_ryobaIdle_00";
			this.Walks[0] = "f02_ryobaWalk_00";
		}
	}

	// Token: 0x060019C9 RID: 6601 RVA: 0x001083D8 File Offset: 0x001065D8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Prompt.Yandere.Health > 0)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Yandere.PersonaID++;
				if (this.Prompt.Yandere.PersonaID == this.Limit)
				{
					this.Prompt.Yandere.PersonaID = 0;
				}
				this.UpdatePersona();
				return;
			}
		}
		else if (this.Prompt.Circle[1].fillAmount == 0f && this.Prompt.Yandere.Health > 0)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			this.Prompt.Yandere.PersonaID--;
			if (this.Prompt.Yandere.PersonaID < 0)
			{
				this.Prompt.Yandere.PersonaID = this.Limit - 1;
			}
			this.UpdatePersona();
		}
	}

	// Token: 0x060019CA RID: 6602 RVA: 0x00108500 File Offset: 0x00106700
	public void UpdatePersona()
	{
		if (!this.Started)
		{
			this.Start();
		}
		int personaID = this.Prompt.Yandere.PersonaID;
		if (!this.Prompt.Yandere.Carrying)
		{
			if (!this.Prompt.Yandere.Resting)
			{
				this.Prompt.Yandere.NotificationManager.PersonaName = this.Personas[personaID];
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Persona);
			}
			this.Prompt.Yandere.IdleAnim = this.Idles[personaID];
			this.Prompt.Yandere.WalkAnim = this.Walks[personaID];
			this.Prompt.Yandere.UpdatePersona(personaID);
		}
		this.Prompt.Yandere.OriginalIdleAnim = this.Idles[personaID];
		this.Prompt.Yandere.OriginalWalkAnim = this.Walks[personaID];
		this.Prompt.Yandere.StudentManager.UpdatePerception();
	}

	// Token: 0x04002974 RID: 10612
	public PromptScript Prompt;

	// Token: 0x04002975 RID: 10613
	public string[] Personas;

	// Token: 0x04002976 RID: 10614
	public string[] Idles;

	// Token: 0x04002977 RID: 10615
	public string[] Walks;

	// Token: 0x04002978 RID: 10616
	public bool Started;

	// Token: 0x04002979 RID: 10617
	public int Limit;
}
