using System;
using UnityEngine;

// Token: 0x02000251 RID: 593
public class ClubWindowScript : MonoBehaviour
{
	// Token: 0x06001287 RID: 4743 RVA: 0x000937BC File Offset: 0x000919BC
	private void Start()
	{
		this.Window.SetActive(false);
		if (GameGlobals.Eighties)
		{
			this.ActivityDescs[7] = "The Photography Club review each others' photographs and share advice on how to improve.";
			this.ClubDescs[8] = "If you join the Science Club, you will have easy access to an emergency shower that can be used for changing out of a bloody outfit, and a vat of acid that can be used for disposing of corpses.";
		}
		if (SchoolGlobals.SchoolAtmosphere <= 0.9f)
		{
			this.ActivityDescs[7] = this.LowAtmosphereDesc;
			return;
		}
		if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
		{
			this.ActivityDescs[7] = this.MedAtmosphereDesc;
		}
	}

	// Token: 0x06001288 RID: 4744 RVA: 0x0009382C File Offset: 0x00091A2C
	private void Update()
	{
		if (this.Window.activeInHierarchy)
		{
			if (this.Timer > 0.5f)
			{
				if (Input.GetButtonDown("A"))
				{
					if (!this.Quitting && !this.Activity)
					{
						this.Yandere.Club = this.Club;
						this.Yandere.ClubAccessory();
						this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
						this.ClubManager.ActivateClubBenefit();
					}
					else if (this.Quitting)
					{
						this.ClubManager.DeactivateClubBenefit();
						this.ClubManager.QuitClub[(int)this.Club] = true;
						this.Yandere.Club = ClubType.None;
						this.Yandere.ClubAccessory();
						this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
						this.Quitting = false;
						this.Yandere.StudentManager.UpdateBooths();
					}
					else if (this.Activity)
					{
						this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
					}
					this.Yandere.TargetStudent.TalkTimer = 100f;
					this.Yandere.TargetStudent.ClubPhase = 2;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Window.SetActive(false);
				}
				if (Input.GetButtonDown("B"))
				{
					if (!this.Quitting && !this.Activity)
					{
						this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
					}
					else if (this.Quitting)
					{
						this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
						this.Quitting = false;
					}
					else if (this.Activity)
					{
						this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
						this.Activity = false;
					}
					this.Yandere.TargetStudent.TalkTimer = 100f;
					this.Yandere.TargetStudent.ClubPhase = 3;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Window.SetActive(false);
				}
				if (Input.GetButtonDown("X") && !this.Quitting && !this.Activity)
				{
					if (!this.Warning.activeInHierarchy)
					{
						this.ClubInfo.SetActive(false);
						this.Warning.SetActive(true);
					}
					else
					{
						this.ClubInfo.SetActive(true);
						this.Warning.SetActive(false);
					}
				}
			}
			this.Timer += Time.deltaTime;
		}
		if (this.PerformingActivity)
		{
			this.ActivityWindow.localScale = Vector3.Lerp(this.ActivityWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			return;
		}
		if (this.ActivityWindow.localScale.x > 0.1f)
		{
			this.ActivityWindow.localScale = Vector3.Lerp(this.ActivityWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			return;
		}
		if (this.ActivityWindow.localScale.x != 0f)
		{
			this.ActivityWindow.localScale = Vector3.zero;
		}
	}

	// Token: 0x06001289 RID: 4745 RVA: 0x00093B5C File Offset: 0x00091D5C
	public void UpdateWindow()
	{
		this.ClubName.text = this.ClubNames[(int)this.Club];
		if (!this.Quitting && !this.Activity)
		{
			this.ClubDesc.text = this.ClubDescs[(int)this.Club];
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Refuse";
			this.PromptBar.Label[2].text = "More Info";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.BottomLabel.text = "Will you join the " + this.ClubNames[(int)this.Club] + "?";
		}
		else if (this.Activity)
		{
			this.ClubDesc.text = "Club activities last until 6:00 PM. If you choose to participate in club activities now, the day will end.\n\nIf you don't join by 5:30 PM, you won't be able to participate in club activities today.\n\nIf you don't participate in club activities at least once a week, you will be removed from the club.";
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Yes";
			this.PromptBar.Label[1].text = "No";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.BottomLabel.text = "Will you participate in club activities?";
		}
		else if (this.Quitting)
		{
			this.ClubDesc.text = "Are you sure you want to quit this club? If you quit, you will never be allowed to return.";
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Confirm";
			this.PromptBar.Label[1].text = "Deny";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.BottomLabel.text = "Will you quit the " + this.ClubNames[(int)this.Club] + "?";
		}
		this.ClubInfo.SetActive(true);
		this.Warning.SetActive(false);
		this.Window.SetActive(true);
		this.Timer = 0f;
	}

	// Token: 0x04001829 RID: 6185
	public ClubManagerScript ClubManager;

	// Token: 0x0400182A RID: 6186
	public PromptBarScript PromptBar;

	// Token: 0x0400182B RID: 6187
	public YandereScript Yandere;

	// Token: 0x0400182C RID: 6188
	public Transform ActivityWindow;

	// Token: 0x0400182D RID: 6189
	public GameObject ClubInfo;

	// Token: 0x0400182E RID: 6190
	public GameObject Window;

	// Token: 0x0400182F RID: 6191
	public GameObject Warning;

	// Token: 0x04001830 RID: 6192
	public string[] ActivityDescs;

	// Token: 0x04001831 RID: 6193
	public string[] ClubNames;

	// Token: 0x04001832 RID: 6194
	public string[] ClubDescs;

	// Token: 0x04001833 RID: 6195
	public string MedAtmosphereDesc;

	// Token: 0x04001834 RID: 6196
	public string LowAtmosphereDesc;

	// Token: 0x04001835 RID: 6197
	public UILabel ActivityLabel;

	// Token: 0x04001836 RID: 6198
	public UILabel BottomLabel;

	// Token: 0x04001837 RID: 6199
	public UILabel ClubName;

	// Token: 0x04001838 RID: 6200
	public UILabel ClubDesc;

	// Token: 0x04001839 RID: 6201
	public bool PerformingActivity;

	// Token: 0x0400183A RID: 6202
	public bool Activity;

	// Token: 0x0400183B RID: 6203
	public bool Quitting;

	// Token: 0x0400183C RID: 6204
	public float Timer;

	// Token: 0x0400183D RID: 6205
	public ClubType Club;
}
