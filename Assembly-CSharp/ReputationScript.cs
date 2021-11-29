using System;
using UnityEngine;

// Token: 0x020003CC RID: 972
public class ReputationScript : MonoBehaviour
{
	// Token: 0x06001B44 RID: 6980 RVA: 0x00131EFB File Offset: 0x001300FB
	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			this.MissionMode = true;
		}
		if (GameGlobals.Eighties)
		{
			this.BecomeEighties();
		}
		this.Reputation = PlayerGlobals.Reputation;
		this.RepUpdateLabel.enabled = true;
	}

	// Token: 0x06001B45 RID: 6981 RVA: 0x00131F30 File Offset: 0x00130130
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
				if (this.PendingRep > 0f)
				{
					this.PendingRepLabel.text = "+" + this.PendingRep.ToString("F1");
					this.RepUpdateLabel.enabled = true;
				}
				else if (this.PendingRep < 0f)
				{
					this.StudentManager.TutorialWindow.ShowRepMessage = true;
					this.PendingRepLabel.text = this.PendingRep.ToString("F1");
					this.RepUpdateLabel.enabled = true;
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

	// Token: 0x06001B46 RID: 6982 RVA: 0x0013240C File Offset: 0x0013060C
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

	// Token: 0x06001B47 RID: 6983 RVA: 0x00132496 File Offset: 0x00130696
	public void BecomeEighties()
	{
		this.StudentManager.EightiesifyLabel(this.PendingRepLabel);
		this.StudentManager.EightiesifyLabel(this.RepUpdateLabel);
		this.StudentManager.EightiesifyLabel(this.RepLabel);
	}

	// Token: 0x04002E71 RID: 11889
	public StudentManagerScript StudentManager;

	// Token: 0x04002E72 RID: 11890
	public ArmDetectorScript ArmDetector;

	// Token: 0x04002E73 RID: 11891
	public PortalScript Portal;

	// Token: 0x04002E74 RID: 11892
	public Transform CurrentRepMarker;

	// Token: 0x04002E75 RID: 11893
	public Transform PendingRepMarker;

	// Token: 0x04002E76 RID: 11894
	public UILabel PendingRepLabel;

	// Token: 0x04002E77 RID: 11895
	public UILabel RepUpdateLabel;

	// Token: 0x04002E78 RID: 11896
	public UILabel RepLabel;

	// Token: 0x04002E79 RID: 11897
	public ClockScript Clock;

	// Token: 0x04002E7A RID: 11898
	public float Reputation;

	// Token: 0x04002E7B RID: 11899
	public float LerpTimer;

	// Token: 0x04002E7C RID: 11900
	public float PreviousRep;

	// Token: 0x04002E7D RID: 11901
	public float PendingRep;

	// Token: 0x04002E7E RID: 11902
	public int CheckedRep = 1;

	// Token: 0x04002E7F RID: 11903
	public int Phase;

	// Token: 0x04002E80 RID: 11904
	public bool MissionMode;
}
