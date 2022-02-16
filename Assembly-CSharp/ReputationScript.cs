using System;
using UnityEngine;

// Token: 0x020003D0 RID: 976
public class ReputationScript : MonoBehaviour
{
	// Token: 0x06001B5F RID: 7007 RVA: 0x00133B33 File Offset: 0x00131D33
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

	// Token: 0x06001B60 RID: 7008 RVA: 0x00133B74 File Offset: 0x00131D74
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

	// Token: 0x06001B61 RID: 7009 RVA: 0x0013404C File Offset: 0x0013224C
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

	// Token: 0x06001B62 RID: 7010 RVA: 0x001340D6 File Offset: 0x001322D6
	public void BecomeEighties()
	{
		this.StudentManager.EightiesifyLabel(this.PendingRepLabel);
		this.StudentManager.EightiesifyLabel(this.RepUpdateLabel);
		this.StudentManager.EightiesifyLabel(this.RepLabel);
	}

	// Token: 0x04002EBC RID: 11964
	public StudentManagerScript StudentManager;

	// Token: 0x04002EBD RID: 11965
	public ArmDetectorScript ArmDetector;

	// Token: 0x04002EBE RID: 11966
	public PortalScript Portal;

	// Token: 0x04002EBF RID: 11967
	public Transform CurrentRepMarker;

	// Token: 0x04002EC0 RID: 11968
	public Transform PendingRepMarker;

	// Token: 0x04002EC1 RID: 11969
	public UILabel PendingRepLabel;

	// Token: 0x04002EC2 RID: 11970
	public UILabel RepUpdateLabel;

	// Token: 0x04002EC3 RID: 11971
	public UILabel RepLabel;

	// Token: 0x04002EC4 RID: 11972
	public ClockScript Clock;

	// Token: 0x04002EC5 RID: 11973
	public float Reputation;

	// Token: 0x04002EC6 RID: 11974
	public float LerpTimer;

	// Token: 0x04002EC7 RID: 11975
	public float PreviousRep;

	// Token: 0x04002EC8 RID: 11976
	public float PendingRep;

	// Token: 0x04002EC9 RID: 11977
	public int CheckedRep = 1;

	// Token: 0x04002ECA RID: 11978
	public int Phase;

	// Token: 0x04002ECB RID: 11979
	public bool MissionMode;
}
