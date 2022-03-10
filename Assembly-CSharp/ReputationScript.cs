using System;
using UnityEngine;

// Token: 0x020003D1 RID: 977
public class ReputationScript : MonoBehaviour
{
	// Token: 0x06001B69 RID: 7017 RVA: 0x00134A93 File Offset: 0x00132C93
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

	// Token: 0x06001B6A RID: 7018 RVA: 0x00134AD4 File Offset: 0x00132CD4
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

	// Token: 0x06001B6B RID: 7019 RVA: 0x00134EF8 File Offset: 0x001330F8
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

	// Token: 0x06001B6C RID: 7020 RVA: 0x00134F82 File Offset: 0x00133182
	public void BecomeEighties()
	{
		this.StudentManager.EightiesifyLabel(this.PendingRepLabel);
		this.StudentManager.EightiesifyLabel(this.RepUpdateLabel);
		this.StudentManager.EightiesifyLabel(this.RepLabel);
	}

	// Token: 0x06001B6D RID: 7021 RVA: 0x00134FB8 File Offset: 0x001331B8
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

	// Token: 0x04002EE2 RID: 12002
	public StudentManagerScript StudentManager;

	// Token: 0x04002EE3 RID: 12003
	public ArmDetectorScript ArmDetector;

	// Token: 0x04002EE4 RID: 12004
	public PortalScript Portal;

	// Token: 0x04002EE5 RID: 12005
	public Transform CurrentRepMarker;

	// Token: 0x04002EE6 RID: 12006
	public Transform PendingRepMarker;

	// Token: 0x04002EE7 RID: 12007
	public UILabel PendingRepLabel;

	// Token: 0x04002EE8 RID: 12008
	public UILabel RepUpdateLabel;

	// Token: 0x04002EE9 RID: 12009
	public UILabel RepLabel;

	// Token: 0x04002EEA RID: 12010
	public ClockScript Clock;

	// Token: 0x04002EEB RID: 12011
	public float Reputation;

	// Token: 0x04002EEC RID: 12012
	public float LerpTimer;

	// Token: 0x04002EED RID: 12013
	public float PreviousRep;

	// Token: 0x04002EEE RID: 12014
	public float PendingRep;

	// Token: 0x04002EEF RID: 12015
	public int CheckedRep = 1;

	// Token: 0x04002EF0 RID: 12016
	public int Phase;

	// Token: 0x04002EF1 RID: 12017
	public bool MissionMode;
}
