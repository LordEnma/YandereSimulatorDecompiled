using System;
using UnityEngine;

// Token: 0x0200036A RID: 874
public class MirrorScript : MonoBehaviour
{
	// Token: 0x060019CC RID: 6604 RVA: 0x0010881C File Offset: 0x00106A1C
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

	// Token: 0x060019CD RID: 6605 RVA: 0x001088A4 File Offset: 0x00106AA4
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

	// Token: 0x060019CE RID: 6606 RVA: 0x001089CC File Offset: 0x00106BCC
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

	// Token: 0x0400297D RID: 10621
	public PromptScript Prompt;

	// Token: 0x0400297E RID: 10622
	public string[] Personas;

	// Token: 0x0400297F RID: 10623
	public string[] Idles;

	// Token: 0x04002980 RID: 10624
	public string[] Walks;

	// Token: 0x04002981 RID: 10625
	public bool Started;

	// Token: 0x04002982 RID: 10626
	public int Limit;
}
