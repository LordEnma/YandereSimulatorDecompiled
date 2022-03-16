using System;
using UnityEngine;

// Token: 0x020003D2 RID: 978
public class ReputationScript : MonoBehaviour
{
	// Token: 0x06001B76 RID: 7030 RVA: 0x00135933 File Offset: 0x00133B33
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

	// Token: 0x06001B77 RID: 7031 RVA: 0x00135974 File Offset: 0x00133B74
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

	// Token: 0x06001B78 RID: 7032 RVA: 0x00135D98 File Offset: 0x00133F98
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

	// Token: 0x06001B79 RID: 7033 RVA: 0x00135E22 File Offset: 0x00134022
	public void BecomeEighties()
	{
		this.StudentManager.EightiesifyLabel(this.PendingRepLabel);
		this.StudentManager.EightiesifyLabel(this.RepUpdateLabel);
		this.StudentManager.EightiesifyLabel(this.RepLabel);
	}

	// Token: 0x06001B7A RID: 7034 RVA: 0x00135E58 File Offset: 0x00134058
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

	// Token: 0x04002F16 RID: 12054
	public StudentManagerScript StudentManager;

	// Token: 0x04002F17 RID: 12055
	public ArmDetectorScript ArmDetector;

	// Token: 0x04002F18 RID: 12056
	public PortalScript Portal;

	// Token: 0x04002F19 RID: 12057
	public Transform CurrentRepMarker;

	// Token: 0x04002F1A RID: 12058
	public Transform PendingRepMarker;

	// Token: 0x04002F1B RID: 12059
	public UILabel PendingRepLabel;

	// Token: 0x04002F1C RID: 12060
	public UILabel RepUpdateLabel;

	// Token: 0x04002F1D RID: 12061
	public UILabel RepLabel;

	// Token: 0x04002F1E RID: 12062
	public ClockScript Clock;

	// Token: 0x04002F1F RID: 12063
	public float Reputation;

	// Token: 0x04002F20 RID: 12064
	public float LerpTimer;

	// Token: 0x04002F21 RID: 12065
	public float PreviousRep;

	// Token: 0x04002F22 RID: 12066
	public float PendingRep;

	// Token: 0x04002F23 RID: 12067
	public int CheckedRep = 1;

	// Token: 0x04002F24 RID: 12068
	public int Phase;

	// Token: 0x04002F25 RID: 12069
	public bool MissionMode;
}
