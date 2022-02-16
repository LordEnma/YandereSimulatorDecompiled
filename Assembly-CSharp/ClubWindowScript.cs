using System;
using UnityEngine;

// Token: 0x02000251 RID: 593
public class ClubWindowScript : MonoBehaviour
{
	// Token: 0x06001284 RID: 4740 RVA: 0x00092CFC File Offset: 0x00090EFC
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

	// Token: 0x06001285 RID: 4741 RVA: 0x00092D6C File Offset: 0x00090F6C
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

	// Token: 0x06001286 RID: 4742 RVA: 0x0009309C File Offset: 0x0009129C
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

	// Token: 0x04001815 RID: 6165
	public ClubManagerScript ClubManager;

	// Token: 0x04001816 RID: 6166
	public PromptBarScript PromptBar;

	// Token: 0x04001817 RID: 6167
	public YandereScript Yandere;

	// Token: 0x04001818 RID: 6168
	public Transform ActivityWindow;

	// Token: 0x04001819 RID: 6169
	public GameObject ClubInfo;

	// Token: 0x0400181A RID: 6170
	public GameObject Window;

	// Token: 0x0400181B RID: 6171
	public GameObject Warning;

	// Token: 0x0400181C RID: 6172
	public string[] ActivityDescs;

	// Token: 0x0400181D RID: 6173
	public string[] ClubNames;

	// Token: 0x0400181E RID: 6174
	public string[] ClubDescs;

	// Token: 0x0400181F RID: 6175
	public string MedAtmosphereDesc;

	// Token: 0x04001820 RID: 6176
	public string LowAtmosphereDesc;

	// Token: 0x04001821 RID: 6177
	public UILabel ActivityLabel;

	// Token: 0x04001822 RID: 6178
	public UILabel BottomLabel;

	// Token: 0x04001823 RID: 6179
	public UILabel ClubName;

	// Token: 0x04001824 RID: 6180
	public UILabel ClubDesc;

	// Token: 0x04001825 RID: 6181
	public bool PerformingActivity;

	// Token: 0x04001826 RID: 6182
	public bool Activity;

	// Token: 0x04001827 RID: 6183
	public bool Quitting;

	// Token: 0x04001828 RID: 6184
	public float Timer;

	// Token: 0x04001829 RID: 6185
	public ClubType Club;
}
