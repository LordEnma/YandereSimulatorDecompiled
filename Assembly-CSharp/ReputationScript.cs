using System;
using UnityEngine;

// Token: 0x020003D1 RID: 977
public class ReputationScript : MonoBehaviour
{
	// Token: 0x06001B68 RID: 7016 RVA: 0x0013457B File Offset: 0x0013277B
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

	// Token: 0x06001B69 RID: 7017 RVA: 0x001345BC File Offset: 0x001327BC
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
				this.PreviousRep = this.PendingRep;
				this.LerpTimer = 0f;
				if (!this.MissionMode)
				{
					this.RepUpdateLabel.enabled = true;
				}
				if (this.PendingRep > 0f)
				{
					this.PendingRepLabel.text = "+" + this.PendingRep.ToString("F1");
				}
				else if (this.PendingRep < 0f)
				{
					this.StudentManager.TutorialWindow.ShowRepMessage = true;
					this.PendingRepLabel.text = this.PendingRep.ToString("F1");
				}
				else
				{
					this.RepUpdateLabel.enabled = false;
					this.PendingRepLabel.text = string.Empty;
				}
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

	// Token: 0x06001B6A RID: 7018 RVA: 0x00134A94 File Offset: 0x00132C94
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

	// Token: 0x06001B6B RID: 7019 RVA: 0x00134B1E File Offset: 0x00132D1E
	public void BecomeEighties()
	{
		this.StudentManager.EightiesifyLabel(this.PendingRepLabel);
		this.StudentManager.EightiesifyLabel(this.RepUpdateLabel);
		this.StudentManager.EightiesifyLabel(this.RepLabel);
	}

	// Token: 0x04002ECC RID: 11980
	public StudentManagerScript StudentManager;

	// Token: 0x04002ECD RID: 11981
	public ArmDetectorScript ArmDetector;

	// Token: 0x04002ECE RID: 11982
	public PortalScript Portal;

	// Token: 0x04002ECF RID: 11983
	public Transform CurrentRepMarker;

	// Token: 0x04002ED0 RID: 11984
	public Transform PendingRepMarker;

	// Token: 0x04002ED1 RID: 11985
	public UILabel PendingRepLabel;

	// Token: 0x04002ED2 RID: 11986
	public UILabel RepUpdateLabel;

	// Token: 0x04002ED3 RID: 11987
	public UILabel RepLabel;

	// Token: 0x04002ED4 RID: 11988
	public ClockScript Clock;

	// Token: 0x04002ED5 RID: 11989
	public float Reputation;

	// Token: 0x04002ED6 RID: 11990
	public float LerpTimer;

	// Token: 0x04002ED7 RID: 11991
	public float PreviousRep;

	// Token: 0x04002ED8 RID: 11992
	public float PendingRep;

	// Token: 0x04002ED9 RID: 11993
	public int CheckedRep = 1;

	// Token: 0x04002EDA RID: 11994
	public int Phase;

	// Token: 0x04002EDB RID: 11995
	public bool MissionMode;
}
