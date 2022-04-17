using System;
using UnityEngine;

// Token: 0x020003D6 RID: 982
public class ReputationScript : MonoBehaviour
{
	// Token: 0x06001B8A RID: 7050 RVA: 0x001369CF File Offset: 0x00134BCF
	private void Start()
	{
		this.RepUpdateLabel.enabled = true;
		if (MissionModeGlobals.MissionMode)
		{
			this.RepUpdateLabel.enabled = false;
			this.MissionMode = true;
		}
		if (GameGlobals.Eighties)
		{
			this.BecomeEighties();
		}
		this.Reputation = PlayerGlobals.Reputation;
	}

	// Token: 0x06001B8B RID: 7051 RVA: 0x00136A10 File Offset: 0x00134C10
	private void Update()
	{
		switch (this.Phase)
		{
		case 1:
			if (this.Clock.PresentTime / 60f > 8.5f)
			{
				this.Phase++;
			}
			break;
		case 2:
			if (this.Clock.PresentTime / 60f > 13.5f)
			{
				this.Phase++;
			}
			break;
		case 3:
			if (this.Clock.PresentTime / 60f > 18f)
			{
				this.RepUpdateLabel.text = "REP WILL UPDATE AFTER SCHOOL";
				this.Phase++;
			}
			break;
		}
		if (this.CheckedRep < this.Phase && !this.StudentManager.Yandere.Struggling && !this.StudentManager.Yandere.DelinquentFighting && !this.StudentManager.Yandere.Pickpocketing && !this.StudentManager.Yandere.Noticed && !this.ArmDetector.SummonDemon)
		{
			this.UpdateRep();
			if (this.Reputation <= -100f)
			{
				this.Portal.EndDay();
			}
		}
		if (!this.MissionMode)
		{
			if (this.LerpTimer < 1f)
			{
				this.CurrentRepMarker.localPosition = new Vector3(Mathf.Lerp(this.CurrentRepMarker.localPosition.x, -830f + this.Reputation * 1.5f, Time.deltaTime * 10f), this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
				this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, this.CurrentRepMarker.transform.localPosition.x + this.PendingRep * 1.5f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
				this.LerpTimer += Time.deltaTime;
			}
			if (this.PendingRep != this.PreviousRep)
			{
				this.UpdatePendingRepLabel();
			}
		}
		else
		{
			this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, -980f + this.PendingRep * -3f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
			if (this.PendingRep < 0f)
			{
				this.PendingRepLabel.text = (-this.PendingRep).ToString("F1");
			}
			else
			{
				this.PendingRepLabel.text = string.Empty;
			}
		}
		if (this.CurrentRepMarker.localPosition.x < -980f)
		{
			this.CurrentRepMarker.localPosition = new Vector3(-980f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
		}
		if (this.PendingRepMarker.localPosition.x < -980f)
		{
			this.PendingRepMarker.localPosition = new Vector3(-980f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		if (this.CurrentRepMarker.localPosition.x > -680f)
		{
			this.CurrentRepMarker.localPosition = new Vector3(-680f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
		}
		if (this.PendingRepMarker.localPosition.x > -680f)
		{
			this.PendingRepMarker.localPosition = new Vector3(-680f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
	}

	// Token: 0x06001B8C RID: 7052 RVA: 0x00136E34 File Offset: 0x00135034
	public void UpdateRep()
	{
		this.Reputation += this.PendingRep;
		this.PendingRep = 0f;
		this.CheckedRep++;
		if (this.StudentManager.Yandere.Club == ClubType.Delinquent)
		{
			if (this.Reputation > -33.33333f)
			{
				this.Reputation = -33.33333f;
			}
		}
		else if (this.Reputation > 100f)
		{
			this.Reputation = 100f;
		}
		this.StudentManager.WipePendingRep();
	}

	// Token: 0x06001B8D RID: 7053 RVA: 0x00136EBE File Offset: 0x001350BE
	public void BecomeEighties()
	{
		this.StudentManager.EightiesifyLabel(this.PendingRepLabel);
		this.StudentManager.EightiesifyLabel(this.RepUpdateLabel);
		this.StudentManager.EightiesifyLabel(this.RepLabel);
	}

	// Token: 0x06001B8E RID: 7054 RVA: 0x00136EF4 File Offset: 0x001350F4
	public void UpdatePendingRepLabel()
	{
		this.PreviousRep = this.PendingRep;
		this.LerpTimer = 0f;
		if (!this.MissionMode)
		{
			this.RepUpdateLabel.enabled = true;
		}
		if (this.PendingRep > 0f)
		{
			this.PendingRepLabel.text = "+" + this.PendingRep.ToString("F1");
			return;
		}
		if (this.PendingRep < 0f)
		{
			this.StudentManager.TutorialWindow.ShowRepMessage = true;
			this.PendingRepLabel.text = this.PendingRep.ToString("F1");
			return;
		}
		this.RepUpdateLabel.enabled = false;
		this.PendingRepLabel.text = string.Empty;
	}

	// Token: 0x04002F3D RID: 12093
	public StudentManagerScript StudentManager;

	// Token: 0x04002F3E RID: 12094
	public ArmDetectorScript ArmDetector;

	// Token: 0x04002F3F RID: 12095
	public PortalScript Portal;

	// Token: 0x04002F40 RID: 12096
	public Transform CurrentRepMarker;

	// Token: 0x04002F41 RID: 12097
	public Transform PendingRepMarker;

	// Token: 0x04002F42 RID: 12098
	public UILabel PendingRepLabel;

	// Token: 0x04002F43 RID: 12099
	public UILabel RepUpdateLabel;

	// Token: 0x04002F44 RID: 12100
	public UILabel RepLabel;

	// Token: 0x04002F45 RID: 12101
	public ClockScript Clock;

	// Token: 0x04002F46 RID: 12102
	public float Reputation;

	// Token: 0x04002F47 RID: 12103
	public float LerpTimer;

	// Token: 0x04002F48 RID: 12104
	public float PreviousRep;

	// Token: 0x04002F49 RID: 12105
	public float PendingRep;

	// Token: 0x04002F4A RID: 12106
	public int CheckedRep = 1;

	// Token: 0x04002F4B RID: 12107
	public int Phase;

	// Token: 0x04002F4C RID: 12108
	public bool MissionMode;
}
