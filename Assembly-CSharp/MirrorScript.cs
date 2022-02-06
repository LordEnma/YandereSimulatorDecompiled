using System;
using UnityEngine;

// Token: 0x02000366 RID: 870
public class MirrorScript : MonoBehaviour
{
	// Token: 0x060019A0 RID: 6560 RVA: 0x00105F9C File Offset: 0x0010419C
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

	// Token: 0x060019A1 RID: 6561 RVA: 0x00106024 File Offset: 0x00104224
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

	// Token: 0x060019A2 RID: 6562 RVA: 0x0010614C File Offset: 0x0010434C
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

	// Token: 0x04002909 RID: 10505
	public PromptScript Prompt;

	// Token: 0x0400290A RID: 10506
	public string[] Personas;

	// Token: 0x0400290B RID: 10507
	public string[] Idles;

	// Token: 0x0400290C RID: 10508
	public string[] Walks;

	// Token: 0x0400290D RID: 10509
	public bool Started;

	// Token: 0x0400290E RID: 10510
	public int Limit;
}
