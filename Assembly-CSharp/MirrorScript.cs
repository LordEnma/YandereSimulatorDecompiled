using System;
using UnityEngine;

// Token: 0x02000366 RID: 870
public class MirrorScript : MonoBehaviour
{
	// Token: 0x0600199D RID: 6557 RVA: 0x00105834 File Offset: 0x00103A34
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

	// Token: 0x0600199E RID: 6558 RVA: 0x001058BC File Offset: 0x00103ABC
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

	// Token: 0x0600199F RID: 6559 RVA: 0x001059E4 File Offset: 0x00103BE4
	public void UpdatePersona()
	{
		if (!this.Started)
		{
			this.Start();
		}
		int personaID = this.Prompt.Yandere.PersonaID;
		if (!this.Prompt.Yandere.Carrying)
		{
			this.Prompt.Yandere.NotificationManager.PersonaName = this.Personas[personaID];
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Persona);
			this.Prompt.Yandere.IdleAnim = this.Idles[personaID];
			this.Prompt.Yandere.WalkAnim = this.Walks[personaID];
			this.Prompt.Yandere.UpdatePersona(personaID);
		}
		this.Prompt.Yandere.OriginalIdleAnim = this.Idles[personaID];
		this.Prompt.Yandere.OriginalWalkAnim = this.Walks[personaID];
		this.Prompt.Yandere.StudentManager.UpdatePerception();
	}

	// Token: 0x040028FC RID: 10492
	public PromptScript Prompt;

	// Token: 0x040028FD RID: 10493
	public string[] Personas;

	// Token: 0x040028FE RID: 10494
	public string[] Idles;

	// Token: 0x040028FF RID: 10495
	public string[] Walks;

	// Token: 0x04002900 RID: 10496
	public bool Started;

	// Token: 0x04002901 RID: 10497
	public int Limit;
}
