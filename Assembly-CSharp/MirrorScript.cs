using System;
using UnityEngine;

// Token: 0x02000368 RID: 872
public class MirrorScript : MonoBehaviour
{
	// Token: 0x060019B8 RID: 6584 RVA: 0x001078D0 File Offset: 0x00105AD0
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

	// Token: 0x060019B9 RID: 6585 RVA: 0x00107958 File Offset: 0x00105B58
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

	// Token: 0x060019BA RID: 6586 RVA: 0x00107A80 File Offset: 0x00105C80
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

	// Token: 0x04002956 RID: 10582
	public PromptScript Prompt;

	// Token: 0x04002957 RID: 10583
	public string[] Personas;

	// Token: 0x04002958 RID: 10584
	public string[] Idles;

	// Token: 0x04002959 RID: 10585
	public string[] Walks;

	// Token: 0x0400295A RID: 10586
	public bool Started;

	// Token: 0x0400295B RID: 10587
	public int Limit;
}
