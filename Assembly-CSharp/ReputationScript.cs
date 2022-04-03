using System;
using UnityEngine;

// Token: 0x020003D5 RID: 981
public class ReputationScript : MonoBehaviour
{
	// Token: 0x06001B80 RID: 7040 RVA: 0x001363A7 File Offset: 0x001345A7
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

	// Token: 0x06001B81 RID: 7041 RVA: 0x001363E8 File Offset: 0x001345E8
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

	// Token: 0x06001B82 RID: 7042 RVA: 0x0013680C File Offset: 0x00134A0C
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

	// Token: 0x06001B83 RID: 7043 RVA: 0x00136896 File Offset: 0x00134A96
	public void BecomeEighties()
	{
		this.StudentManager.EightiesifyLabel(this.PendingRepLabel);
		this.StudentManager.EightiesifyLabel(this.RepUpdateLabel);
		this.StudentManager.EightiesifyLabel(this.RepLabel);
	}

	// Token: 0x06001B84 RID: 7044 RVA: 0x001368CC File Offset: 0x00134ACC
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

	// Token: 0x04002F2F RID: 12079
	public StudentManagerScript StudentManager;

	// Token: 0x04002F30 RID: 12080
	public ArmDetectorScript ArmDetector;

	// Token: 0x04002F31 RID: 12081
	public PortalScript Portal;

	// Token: 0x04002F32 RID: 12082
	public Transform CurrentRepMarker;

	// Token: 0x04002F33 RID: 12083
	public Transform PendingRepMarker;

	// Token: 0x04002F34 RID: 12084
	public UILabel PendingRepLabel;

	// Token: 0x04002F35 RID: 12085
	public UILabel RepUpdateLabel;

	// Token: 0x04002F36 RID: 12086
	public UILabel RepLabel;

	// Token: 0x04002F37 RID: 12087
	public ClockScript Clock;

	// Token: 0x04002F38 RID: 12088
	public float Reputation;

	// Token: 0x04002F39 RID: 12089
	public float LerpTimer;

	// Token: 0x04002F3A RID: 12090
	public float PreviousRep;

	// Token: 0x04002F3B RID: 12091
	public float PendingRep;

	// Token: 0x04002F3C RID: 12092
	public int CheckedRep = 1;

	// Token: 0x04002F3D RID: 12093
	public int Phase;

	// Token: 0x04002F3E RID: 12094
	public bool MissionMode;
}
