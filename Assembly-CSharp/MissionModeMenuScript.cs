using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x0200001C RID: 28
public class MissionModeMenuScript : MonoBehaviour
{
	// Token: 0x0600005C RID: 92 RVA: 0x00009874 File Offset: 0x00007A74
	private void Start()
	{
		base.transform.position = new Vector3(0f, 0.95f, -4.266667f);
		ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
		settings.basic.saturation = 1f;
		settings.channelMixer.red = new Vector3(1f, 0f, 0f);
		settings.channelMixer.green = new Vector3(0f, 1f, 0f);
		settings.channelMixer.blue = new Vector3(0f, 0f, 1f);
		this.Profile.colorGrading.settings = settings;
		DepthOfFieldModel.Settings settings2 = this.Profile.depthOfField.settings;
		settings2.focusDistance = 10f;
		settings2.aperture = 11.2f;
		this.Profile.depthOfField.settings = settings2;
		BloomModel.Settings settings3 = this.Profile.bloom.settings;
		settings3.bloom.intensity = 1f;
		settings3.bloom.threshold = 1f;
		settings3.bloom.softKnee = 1f;
		settings3.bloom.radius = 4f;
		this.Profile.bloom.settings = settings3;
		MissionModeGlobals.MultiMission = false;
		this.NemesisPortrait.transform.parent.localScale = Vector3.zero;
		this.CustomMissionWindow.transform.localScale = Vector3.zero;
		this.MultiMissionWindow.transform.localScale = Vector3.zero;
		this.LoadMissionWindow.transform.localScale = Vector3.zero;
		this.MissionWindow.transform.localScale = Vector3.zero;
		this.Options.transform.localPosition = new Vector3(-700f, this.Options.transform.localPosition.y, this.Options.transform.localPosition.z);
		this.Highlight.color = new Color(this.Highlight.color.r, this.Highlight.color.g, this.Highlight.color.b, 0f);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
		this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, 0f);
		Time.timeScale = 1f;
		this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
		this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
		this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
		for (int i = 1; i < 6; i++)
		{
			Transform transform = this.Option[i].transform;
			transform.localPosition = new Vector3(-800f, transform.localPosition.y, transform.localPosition.z);
		}
		for (int j = 1; j < this.Objectives.Length; j++)
		{
			this.Objectives[j].localScale = Vector3.zero;
		}
		for (int k = 1; k < this.NemesisObjectives.Length; k++)
		{
			this.NemesisObjectives[k].localScale = Vector3.zero;
		}
		for (int l = 1; l < this.CustomObjectives.Length; l++)
		{
			if (this.CustomObjectives[l] != null)
			{
				this.CustomObjectives[l].alpha = 0.5f;
			}
		}
		this.CustomPopulationLabel.text = "";
		this.PopulationLabel.text = "";
		this.ChangeFont();
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00009CD4 File Offset: 0x00007ED4
	private void Update()
	{
		if (this.Phase == 1)
		{
			this.Speed += Time.deltaTime;
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime / 3f));
			if (this.Speed > 1f)
			{
				this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, Mathf.MoveTowards(this.Header.color.a, 1f, Time.deltaTime));
				if (this.Speed > 3f)
				{
					if (!this.InfoSpoke[0])
					{
						this.MyAudio.PlayOneShot(this.InfoLines[0]);
						this.InfoSpoke[0] = true;
					}
					this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
					Transform transform = this.Option[1];
					transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, 0f, Time.deltaTime * 10f), transform.localPosition.y, transform.localPosition.z);
					if ((double)this.Speed > 3.25)
					{
						Transform transform2 = this.Option[2];
						transform2.localPosition = new Vector3(Mathf.Lerp(transform2.localPosition.x, 0f, Time.deltaTime * 10f), transform2.localPosition.y, transform2.localPosition.z);
						if (this.Speed > 3.5f)
						{
							Transform transform3 = this.Option[3];
							transform3.localPosition = new Vector3(Mathf.Lerp(transform3.localPosition.x, 0f, Time.deltaTime * 10f), transform3.localPosition.y, transform3.localPosition.z);
							if ((double)this.Speed > 3.75)
							{
								Transform transform4 = this.Option[4];
								transform4.localPosition = new Vector3(Mathf.Lerp(transform4.localPosition.x, 0f, Time.deltaTime * 10f), transform4.localPosition.y, transform4.localPosition.z);
								if (this.Speed > 4f)
								{
									Transform transform5 = this.Option[5];
									transform5.localPosition = new Vector3(Mathf.Lerp(transform5.localPosition.x, 0f, Time.deltaTime * 10f), transform5.localPosition.y, transform5.localPosition.z);
									if (this.Speed > 5f)
									{
										this.PromptBar.Label[0].text = "Accept";
										this.PromptBar.Label[4].text = "Choose";
										this.PromptBar.UpdateButtons();
										this.PromptBar.Show = true;
										this.Phase++;
									}
								}
							}
						}
					}
				}
			}
			if (Input.GetButtonDown("A"))
			{
				if (!this.InfoSpoke[0])
				{
					this.MyAudio.PlayOneShot(this.InfoLines[0]);
					this.InfoSpoke[0] = true;
				}
				this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, 180f, this.InfoChan.localEulerAngles.z);
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 2f);
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
				this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, 1f);
				this.Rotation = 0f;
				for (int i = 1; i < 6; i++)
				{
					Transform transform6 = this.Option[i];
					transform6.localPosition = new Vector3(0f, transform6.localPosition.y, transform6.localPosition.z);
				}
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 2)
		{
			this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
			this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -700f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedDown)
			{
				this.Selected++;
				this.UpdateHighlight();
			}
			this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, Mathf.Lerp(this.Highlight.transform.localPosition.y, 150f - 50f * (float)this.Selected, Time.deltaTime * 10f), this.Highlight.transform.localPosition.z);
			this.Highlight.color = new Color(this.Highlight.color.r, this.Highlight.color.g, this.Highlight.color.b, Mathf.MoveTowards(this.Highlight.color.a, 1f, Time.deltaTime));
			for (int j = 1; j < 6; j++)
			{
				if (j != this.Selected)
				{
					Transform transform7 = this.Option[j];
					transform7.localPosition = new Vector3(Mathf.Lerp(transform7.transform.localPosition.x, 0f, Time.deltaTime * 10f), transform7.localPosition.y, transform7.localPosition.z);
				}
			}
			Transform transform8 = this.Option[this.Selected];
			transform8.localPosition = new Vector3(Mathf.Lerp(transform8.transform.localPosition.x, 50f, Time.deltaTime * 10f), transform8.localPosition.y, transform8.localPosition.z);
			if (Input.GetButtonDown("A"))
			{
				if (!this.InfoSpoke[this.Selected])
				{
					this.MyAudio.PlayOneShot(this.InfoLines[this.Selected]);
					this.InfoSpoke[this.Selected] = true;
				}
				if (this.Selected == 1)
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Accept";
					this.PromptBar.Label[1].text = "Return";
					this.PromptBar.Label[2].text = "Generate";
					this.PromptBar.Label[3].text = "";
					this.PromptBar.Label[4].text = "Nemesis";
					this.PromptBar.Label[5].text = "Change Difficulty";
					this.PromptBar.UpdateButtons();
					for (int k = 1; k < this.Conditions.Length; k++)
					{
						this.Conditions[k] = 0;
					}
					if (this.TargetID == 0)
					{
						this.ChooseTarget();
					}
					this.RequiredClothingID = 0;
					this.RequiredDisposalID = 0;
					this.RequiredWeaponID = 0;
					this.NemesisDifficulty = 0;
					this.Difficulty = 1;
					this.UpdateNemesisDifficulty();
					this.UpdateDifficultyLabel();
					this.Phase++;
					return;
				}
				if (this.Selected == 2)
				{
					this.Difficulty = 1;
					this.Phase = 5;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Toggle";
					this.PromptBar.Label[1].text = "Return";
					this.PromptBar.Label[2].text = "Change";
					this.PromptBar.Label[3].text = "";
					this.PromptBar.Label[4].text = "Selection";
					this.PromptBar.Label[5].text = "Selection";
					this.PromptBar.UpdateButtons();
					this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
					this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
					this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
					this.UpdateObjectiveHighlight();
					this.UpdateDifficultyLabel();
					this.RequiredClothingID = 1;
					this.RequiredDisposalID = 1;
					this.RequiredWeaponID = 1;
					this.TargetID = 2;
					this.ChooseTarget();
					this.CalculateMissionID();
					return;
				}
				if (this.Selected == 3)
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "";
					this.PromptBar.Label[1].text = "Return";
					this.PromptBar.Label[2].text = "Adjust Up";
					this.PromptBar.Label[3].text = "Adjust Down";
					this.PromptBar.Label[4].text = "Selection";
					this.PromptBar.Label[5].text = "Selection";
					this.PromptBar.UpdateButtons();
					this.MultiMission.enabled = true;
					this.MultiMission.Column = 1;
					this.MultiMission.Row = 1;
					this.MultiMission.UpdateHighlight();
					this.Phase = 6;
					return;
				}
				if (this.Selected == 4)
				{
					Cursor.visible = true;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Confirm";
					this.PromptBar.Label[1].text = "Back";
					this.PromptBar.UpdateButtons();
					this.Phase = 7;
					return;
				}
				if (this.Selected == 5)
				{
					this.PromptBar.Show = false;
					this.Phase = 4;
					this.Speed = 0f;
					return;
				}
			}
		}
		else if (this.Phase == 3)
		{
			this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
			this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
			if (this.InputManager.TappedLeft)
			{
				this.Difficulty--;
				this.UpdateDifficulty();
			}
			if (this.InputManager.TappedRight)
			{
				this.Difficulty++;
				this.UpdateDifficulty();
			}
			if (this.InputManager.TappedUp)
			{
				this.NemesisDifficulty--;
				this.UpdateNemesisDifficulty();
			}
			if (this.InputManager.TappedDown)
			{
				this.NemesisDifficulty++;
				this.UpdateNemesisDifficulty();
			}
			for (int l = 1; l < this.Objectives.Length; l++)
			{
				Transform transform9 = this.Objectives[l];
				transform9.localScale = Vector3.Lerp(transform9.localScale, (l > this.Difficulty) ? Vector3.zero : Vector3.one, Time.deltaTime * 10f);
			}
			if (this.NemesisDifficulty == 0)
			{
				this.NemesisPortrait.transform.parent.localScale = Vector3.Lerp(this.NemesisPortrait.transform.parent.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
				this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
				this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else
			{
				this.NemesisPortrait.transform.parent.localScale = Vector3.Lerp(this.NemesisPortrait.transform.parent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			if (this.NemesisDifficulty == 1)
			{
				this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
				this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (this.NemesisDifficulty == 2)
			{
				this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (this.NemesisDifficulty == 3)
			{
				this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
				this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			else if (this.NemesisDifficulty == 4)
			{
				this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			if (Input.GetButtonDown("A"))
			{
				this.StartMission();
				return;
			}
			if (Input.GetButtonDown("B"))
			{
				Cursor.visible = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.TargetID = 0;
				this.Phase--;
				return;
			}
			if (Input.GetButtonDown("X"))
			{
				this.RequiredClothingID = 0;
				this.RequiredDisposalID = 0;
				this.RequiredWeaponID = 0;
				this.ChooseTarget();
				if (this.Difficulty > 1)
				{
					int difficulty = this.Difficulty;
					this.Difficulty = 1;
					while (this.Difficulty < difficulty)
					{
						this.Difficulty++;
						this.PickNewCondition();
					}
				}
				this.UpdateDifficultyLabel();
				return;
			}
			if (Input.GetButtonDown("Y"))
			{
				this.UpdatePopulation();
				return;
			}
		}
		else if (this.Phase == 4)
		{
			this.Speed += Time.deltaTime;
			this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 0f, Time.deltaTime * this.Speed), this.InfoChan.localEulerAngles.z);
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime * 0.5f));
			Transform parent = this.Option[1].parent;
			parent.localPosition = new Vector3(parent.localPosition.x - this.Speed * 1000f * Time.deltaTime, parent.localPosition.y, parent.localPosition.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z - this.Speed * Time.deltaTime);
			this.Jukebox.volume -= Time.deltaTime;
			this.Header.color = new Color(this.Header.color.r, this.Header.color.g, this.Header.color.b, this.Header.color.a - Time.deltaTime);
			if (this.Darkness.color.a == 1f)
			{
				if (this.TargetID == 0 && !MissionModeGlobals.MultiMission)
				{
					SceneManager.LoadScene("NewTitleScene");
					return;
				}
				this.NowLoading.SetActive(true);
				SceneManager.LoadScene("SchoolScene");
				return;
			}
		}
		else
		{
			if (this.Phase == 5)
			{
				this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
				this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
				if (this.InputManager.TappedUp)
				{
					this.Row--;
					this.UpdateObjectiveHighlight();
				}
				if (this.InputManager.TappedDown)
				{
					this.Row++;
					this.UpdateObjectiveHighlight();
				}
				if (this.InputManager.TappedRight)
				{
					this.Column++;
					this.UpdateObjectiveHighlight();
				}
				if (this.InputManager.TappedLeft)
				{
					this.Column--;
					this.UpdateObjectiveHighlight();
				}
				if (Input.GetButtonDown("A"))
				{
					if (this.CustomSelected == 1)
					{
						this.TargetID++;
						this.ChooseTarget();
					}
					else if (this.CustomSelected == 6)
					{
						for (int m = 1; m < this.Conditions.Length; m++)
						{
							this.Conditions[m] = 0;
						}
						int num = 2;
						for (int n = 2; n < this.CustomObjectives.Length; n++)
						{
							if (this.CustomObjectives[n] != null && this.CustomObjectives[n].alpha == 1f)
							{
								if (n < 6)
								{
									this.Conditions[num] = n - 1;
								}
								else if (n < 12)
								{
									this.Conditions[num] = n - 2;
								}
								else
								{
									this.Conditions[num] = n - 3;
								}
								num++;
							}
						}
						this.StartMission();
					}
					else if (this.CustomSelected == 12)
					{
						this.NemesisDifficulty++;
						this.UpdateNemesisDifficulty();
					}
					if (this.Toggling)
					{
						if (this.CustomObjectives[this.CustomSelected].alpha == 0.5f)
						{
							if (this.Difficulty < 10)
							{
								this.Difficulty++;
								this.UpdateDifficultyLabel();
								this.CustomObjectives[this.CustomSelected].alpha = 1f;
							}
						}
						else
						{
							this.Difficulty--;
							this.UpdateDifficultyLabel();
							this.CustomObjectives[this.CustomSelected].alpha = 0.5f;
						}
					}
					this.CalculateMissionID();
				}
				else if (Input.GetButtonDown("B"))
				{
					Cursor.visible = false;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Accept";
					this.PromptBar.Label[4].text = "Choose";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					for (int num2 = 1; num2 < this.CustomObjectives.Length; num2++)
					{
						if (this.CustomObjectives[num2] != null)
						{
							this.CustomObjectives[num2].alpha = 0.5f;
						}
					}
					this.NemesisDifficulty = 0;
					this.UpdateNemesisDifficulty();
					this.Difficulty = 1;
					this.TargetID = 0;
					this.Phase = 2;
				}
				else if (Input.GetButtonDown("X"))
				{
					if (this.CustomSelected == 1)
					{
						this.TargetID--;
						this.ChooseTarget();
						this.CalculateMissionID();
					}
					else if (this.CustomSelected == 2)
					{
						this.RequiredWeaponID++;
						if (this.RequiredWeaponID == 11)
						{
							this.RequiredWeaponID++;
						}
						if (this.RequiredWeaponID > this.WeaponNames.Length - 1)
						{
							this.RequiredWeaponID = 1;
						}
						this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[this.RequiredWeaponID];
					}
					else if (this.CustomSelected == 3)
					{
						this.RequiredClothingID++;
						if (this.RequiredClothingID > this.ClothingNames.Length - 1)
						{
							this.RequiredClothingID = 1;
						}
						this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[this.RequiredClothingID];
					}
					else if (this.CustomSelected == 4)
					{
						this.RequiredDisposalID++;
						if (this.RequiredDisposalID > this.DisposalNames.Length - 1)
						{
							this.RequiredDisposalID = 1;
						}
						this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[this.RequiredDisposalID];
					}
					else if (this.CustomSelected == 12)
					{
						this.NemesisDifficulty--;
						this.UpdateNemesisDifficulty();
					}
					this.CalculateMissionID();
				}
				else if (Input.GetButtonDown("Y"))
				{
					this.UpdatePopulation();
					this.CalculateMissionID();
				}
				if (this.NemesisDifficulty == 0)
				{
					this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
					this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
					this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
				}
				else if (this.NemesisDifficulty == 1)
				{
					this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
					this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
				}
				else if (this.NemesisDifficulty == 2)
				{
					this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
				}
				else if (this.NemesisDifficulty == 3)
				{
					this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
					this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
				else if (this.NemesisDifficulty == 4)
				{
					this.CustomNemesisObjectives[1].localScale = Vector3.Lerp(this.CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					this.CustomNemesisObjectives[2].localScale = Vector3.Lerp(this.CustomNemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					this.CustomNemesisObjectives[3].localScale = Vector3.Lerp(this.CustomNemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
				this.MissionIDLabel.gameObject.GetComponent<UIInput>().value = this.MissionID;
				return;
			}
			if (this.Phase == 6)
			{
				this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
				this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
				return;
			}
			if (this.Phase == 7)
			{
				this.InfoChan.localEulerAngles = new Vector3(this.InfoChan.localEulerAngles.x, Mathf.Lerp(this.InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (this.Speed - 3f)), this.InfoChan.localEulerAngles.z);
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, this.Speed * Time.deltaTime * 0.25f));
				this.CustomMissionWindow.localScale = Vector3.Lerp(this.CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.LoadMissionWindow.localScale = Vector3.Lerp(this.LoadMissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.MissionWindow.localScale = Vector3.Lerp(this.MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.MultiMissionWindow.localScale = Vector3.Lerp(this.MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
				this.Options.localPosition = new Vector3(Mathf.Lerp(this.Options.localPosition.x, -1550f, Time.deltaTime * 10f), this.Options.localPosition.y, this.Options.localPosition.z);
				if (!Input.anyKey)
				{
					this.MissionIDString = this.LoadMissionLabel.text;
					if (this.MissionIDString.Length < 19)
					{
						this.ErrorLabel.text = "A Mission ID must be 19 numbers long.";
						return;
					}
					if (this.MissionIDString[0] == '-')
					{
						this.ErrorLabel.text = "Invalid Mission ID (Cannot be negative number)";
						return;
					}
					this.GetNumbers();
					bool flag = false;
					if ((this.TargetNumber > 11 && this.TargetNumber < 21) || this.TargetNumber > 97)
					{
						flag = true;
					}
					if (this.TargetNumber == 0)
					{
						this.ErrorLabel.text = "Invalid Mission ID (No target specified)";
						return;
					}
					if (this.TargetNumber == 1)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Target cannot be Senpai)";
						return;
					}
					if (flag)
					{
						this.ErrorLabel.text = "Invalid Mission ID (That student has not been implemented yet)";
						return;
					}
					if (this.WeaponNumber == 11)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Weapon does not apply to Mission Mode)";
						return;
					}
					if (this.WeaponNumber > 14)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Weapon does not exist)";
						return;
					}
					if (this.ClothingNumber > 5)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Clothing does not exist)";
						return;
					}
					if (this.DisposalNumber > 3)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Disposal method does not exist)";
						return;
					}
					if (this.NemesisNumber > 4)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Nemesis level too high)";
						return;
					}
					if (this.PopulationNumber > 0)
					{
						this.ErrorLabel.text = "Invalid Mission ID (Final digit must be '0')";
						return;
					}
					if (this.Condition5Number > 1 || this.Condition6Number > 1 || this.Condition7Number > 1 || this.Condition8Number > 1 || this.Condition9Number > 1 || this.Condition10Number > 1 || this.Condition11Number > 1 || this.Condition12Number > 1 || this.Condition13Number > 1 || this.Condition14Number > 1 || this.Condition15Number > 1)
					{
						this.ErrorLabel.text = "Invalid Mission ID (One of those conditions should be 1 or 0)";
						return;
					}
					this.ErrorLabel.text = "Valid Mission ID!";
					return;
				}
				else if (Input.GetButtonDown("A"))
				{
					if (this.ErrorLabel.text == "Valid Mission ID!")
					{
						Debug.Log("Target ID is: " + this.TargetNumber.ToString() + " and Weapon ID is: " + this.WeaponNumber.ToString());
						this.TargetID = this.TargetNumber;
						this.Difficulty = 1;
						if (this.WeaponNumber > 0)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 2;
							this.CustomObjectives[2].alpha = 1f;
							this.RequiredWeaponID = this.WeaponNumber;
							this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[this.RequiredWeaponID];
						}
						else
						{
							this.CustomObjectives[2].alpha = 0.5f;
							this.CustomDescs[2].text = this.ConditionDescs[1] + " " + this.WeaponNames[1];
						}
						if (this.ClothingNumber > 0)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 3;
							this.CustomObjectives[3].alpha = 1f;
							this.RequiredClothingID = this.ClothingNumber;
							this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[this.RequiredClothingID];
						}
						else
						{
							this.CustomObjectives[3].alpha = 0.5f;
							this.CustomDescs[3].text = this.ConditionDescs[2] + " " + this.ClothingNames[1];
						}
						if (this.DisposalNumber > 0)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 4;
							this.CustomObjectives[4].alpha = 1f;
							this.RequiredDisposalID = this.DisposalNumber;
							this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[this.RequiredDisposalID];
						}
						else
						{
							this.CustomObjectives[4].alpha = 0.5f;
							this.CustomDescs[4].text = this.ConditionDescs[3] + " " + this.DisposalNames[1];
						}
						if (this.Difficulty < 10 && this.Condition5Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 5;
							this.CustomObjectives[5].alpha = 1f;
						}
						if (this.Difficulty < 10 && this.Condition6Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 6;
							this.CustomObjectives[7].alpha = 1f;
						}
						if (this.Difficulty < 10 && this.Condition7Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 7;
							this.CustomObjectives[8].alpha = 1f;
						}
						if (this.Difficulty < 10 && this.Condition8Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 8;
							this.CustomObjectives[9].alpha = 1f;
						}
						if (this.Difficulty < 10 && this.Condition9Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 9;
							this.CustomObjectives[10].alpha = 1f;
						}
						if (this.Difficulty < 10 && this.Condition10Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 10;
							this.CustomObjectives[11].alpha = 1f;
						}
						if (this.Difficulty < 10 && this.Condition11Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 11;
							this.CustomObjectives[13].alpha = 1f;
						}
						if (this.Difficulty < 10 && this.Condition12Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 12;
							this.CustomObjectives[14].alpha = 1f;
						}
						if (this.Difficulty < 10 && this.Condition13Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 13;
							this.CustomObjectives[15].alpha = 1f;
						}
						if (this.Difficulty < 10 && this.Condition14Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 14;
							this.CustomObjectives[16].alpha = 1f;
						}
						if (this.Difficulty < 10 && this.Condition15Number == 1)
						{
							this.Difficulty++;
							this.Conditions[this.Difficulty] = 15;
							this.CustomObjectives[17].alpha = 1f;
						}
						this.NemesisDifficulty = this.NemesisNumber;
						SchoolGlobals.Population = this.PopulationNumber;
						this.Phase = 5;
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Toggle";
						this.PromptBar.Label[1].text = "Return";
						this.PromptBar.Label[2].text = "Change";
						this.PromptBar.Label[3].text = "";
						this.PromptBar.Label[4].text = "Selection";
						this.PromptBar.Label[5].text = "Selection";
						this.PromptBar.UpdateButtons();
						this.UpdateObjectiveHighlight();
						this.UpdateNemesisDifficulty();
						this.UpdateDifficultyLabel();
						this.CalculateMissionID();
						this.ChooseTarget();
						return;
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					Cursor.visible = false;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Accept";
					this.PromptBar.Label[4].text = "Choose";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.TargetID = 0;
					this.Phase = 2;
				}
			}
		}
	}

	// Token: 0x0600005E RID: 94 RVA: 0x0000CAE4 File Offset: 0x0000ACE4
	private void GetNumbers()
	{
		this.TargetNumber = (int)char.GetNumericValue(this.MissionIDString[0]) * 10 + (int)char.GetNumericValue(this.MissionIDString[1]);
		this.WeaponNumber = (int)char.GetNumericValue(this.MissionIDString[2]) * 10 + (int)char.GetNumericValue(this.MissionIDString[3]);
		this.ClothingNumber = (int)char.GetNumericValue(this.MissionIDString[4]);
		this.DisposalNumber = (int)char.GetNumericValue(this.MissionIDString[5]);
		this.Condition5Number = (int)char.GetNumericValue(this.MissionIDString[6]);
		this.Condition6Number = (int)char.GetNumericValue(this.MissionIDString[7]);
		this.Condition7Number = (int)char.GetNumericValue(this.MissionIDString[8]);
		this.Condition8Number = (int)char.GetNumericValue(this.MissionIDString[9]);
		this.Condition9Number = (int)char.GetNumericValue(this.MissionIDString[10]);
		this.Condition10Number = (int)char.GetNumericValue(this.MissionIDString[11]);
		this.Condition11Number = (int)char.GetNumericValue(this.MissionIDString[12]);
		this.Condition12Number = (int)char.GetNumericValue(this.MissionIDString[13]);
		this.Condition13Number = (int)char.GetNumericValue(this.MissionIDString[14]);
		this.Condition14Number = (int)char.GetNumericValue(this.MissionIDString[15]);
		this.Condition15Number = (int)char.GetNumericValue(this.MissionIDString[16]);
		this.NemesisNumber = (int)char.GetNumericValue(this.MissionIDString[17]);
		this.PopulationNumber = (int)char.GetNumericValue(this.MissionIDString[18]);
	}

	// Token: 0x0600005F RID: 95 RVA: 0x0000CCC0 File Offset: 0x0000AEC0
	private void LateUpdate()
	{
		if (this.Speed > 3f)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * (this.Speed - 3f));
		}
		this.Neck.transform.localEulerAngles = new Vector3(this.Neck.transform.localEulerAngles.x + this.Rotation, this.Neck.transform.localEulerAngles.y, this.Neck.transform.localEulerAngles.z);
	}

	// Token: 0x06000060 RID: 96 RVA: 0x0000CD5D File Offset: 0x0000AF5D
	private void UpdateHighlight()
	{
		if (this.Selected == 0)
		{
			this.Selected = 5;
			return;
		}
		if (this.Selected == 6)
		{
			this.Selected = 1;
		}
	}

	// Token: 0x06000061 RID: 97 RVA: 0x0000CD80 File Offset: 0x0000AF80
	private void ChooseTarget()
	{
		Debug.Log("Calling the ChooseTarget() function.");
		if (this.Phase != 5)
		{
			this.TargetID = UnityEngine.Random.Range(2, 90);
			if (this.TargetNumber > 11 && this.TargetNumber < 21)
			{
				this.ChooseTarget();
			}
		}
		else
		{
			if (this.TargetNumber > 11 && this.TargetNumber < 21)
			{
				if (Input.GetButtonDown("A"))
				{
					this.TargetID++;
				}
				else
				{
					this.TargetID--;
				}
				this.ChooseTarget();
			}
			if (this.TargetID > 89)
			{
				this.TargetID = 2;
			}
			else if (this.TargetID < 2)
			{
				this.TargetID = 89;
			}
		}
		WWW www = new WWW(string.Concat(new string[]
		{
			"file:///",
			Application.streamingAssetsPath,
			"/Portraits/Student_",
			this.TargetID.ToString(),
			".png"
		}));
		if (this.TargetNumber > 11 && this.TargetNumber < 21)
		{
			this.TargetPortrait.mainTexture = this.BlankPortrait;
		}
		else
		{
			this.TargetPortrait.mainTexture = www.texture;
		}
		this.CustomTargetPortrait.mainTexture = this.TargetPortrait.mainTexture;
		if (this.JSON.Students[this.TargetID].Name == "Random" || this.JSON.Students[this.TargetID].Name == "Unknown")
		{
			this.TargetName = this.StudentManager.FirstNames[UnityEngine.Random.Range(0, this.StudentManager.FirstNames.Length)] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, this.StudentManager.LastNames.Length)];
		}
		else
		{
			this.TargetName = this.JSON.Students[this.TargetID].Name;
		}
		this.CustomDescs[1].text = "Kill " + this.TargetName + ".";
		this.Descs[1].text = "Kill " + this.TargetName + ".";
		if (this.TargetID > 11 && this.TargetID < 21)
		{
			if (this.Phase == 5)
			{
				this.TargetID += (Input.GetButtonDown("A") ? 1 : -1);
			}
			this.ChooseTarget();
		}
	}

	// Token: 0x06000062 RID: 98 RVA: 0x0000CFF6 File Offset: 0x0000B1F6
	private void UpdateDifficulty()
	{
		if (this.Difficulty < 1)
		{
			this.Difficulty = 1;
		}
		else if (this.Difficulty > 10)
		{
			this.Difficulty = 10;
		}
		if (this.InputManager.TappedRight)
		{
			this.PickNewCondition();
			return;
		}
		this.ErasePreviousCondition();
	}

	// Token: 0x06000063 RID: 99 RVA: 0x0000D038 File Offset: 0x0000B238
	private void UpdateDifficultyLabel()
	{
		this.CustomDifficultyLabel.text = "Difficulty Level - " + this.Difficulty.ToString();
		this.DifficultyLabel.text = "Difficulty Level - " + this.Difficulty.ToString();
		string text = "Kill " + this.TargetName + ".";
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		if (this.RequiredWeaponID == 0)
		{
			text2 = "You can kill the target with any weapon.";
		}
		else
		{
			text2 = "You must kill the target with a " + this.WeaponNames[this.RequiredWeaponID];
		}
		if (this.RequiredClothingID == 0)
		{
			text3 = "You can kill the target wearing any clothing.";
		}
		else
		{
			text3 = "You must kill the target while wearing " + this.ClothingNames[this.RequiredClothingID];
		}
		if (this.RequiredDisposalID == 0)
		{
			text4 = "It is not necessary to dispose of the target's corpse.";
		}
		else
		{
			text4 = "You must dispose of the target's corpse by " + this.DisposalNames[this.RequiredDisposalID];
		}
		this.DescriptionLabel.text = string.Concat(new string[]
		{
			text,
			"\n\n",
			text2,
			"\n\n",
			text3,
			"\n\n",
			text4
		});
	}

	// Token: 0x06000064 RID: 100 RVA: 0x0000D164 File Offset: 0x0000B364
	private void UpdateNemesisDifficulty()
	{
		if (this.NemesisDifficulty < 0)
		{
			this.NemesisDifficulty = 4;
		}
		else if (this.NemesisDifficulty > 4)
		{
			this.NemesisDifficulty = 0;
		}
		if (this.NemesisDifficulty == 0)
		{
			this.CustomNemesisLabel.text = "Nemesis: Off";
			this.NemesisLabel.text = "Nemesis: Off";
			return;
		}
		this.CustomNemesisLabel.text = "Nemesis: On";
		this.NemesisLabel.text = "Nemesis: On";
		this.NemesisPortrait.mainTexture = ((this.NemesisDifficulty > 2) ? this.BlankPortrait : this.NemesisGraphic);
	}

	// Token: 0x06000065 RID: 101 RVA: 0x0000D200 File Offset: 0x0000B400
	private void PickNewCondition()
	{
		int num = UnityEngine.Random.Range(1, this.ConditionDescs.Length);
		this.Conditions[this.Difficulty] = num;
		this.Descs[this.Difficulty].text = this.ConditionDescs[num];
		this.Icons[this.Difficulty].mainTexture = this.ConditionIcons[num];
		bool flag = false;
		for (int i = 2; i < this.Difficulty; i++)
		{
			if (num == this.Conditions[i])
			{
				flag = true;
			}
		}
		if (flag)
		{
			this.PickNewCondition();
		}
		else if (num > 3)
		{
			this.Descs[this.Difficulty].text = this.ConditionDescs[num];
		}
		else if (num == 1)
		{
			this.RequiredWeaponID = 11;
			while (this.RequiredWeaponID == 11)
			{
				this.RequiredWeaponID = UnityEngine.Random.Range(1, this.WeaponNames.Length);
			}
			this.Descs[this.Difficulty].text = this.ConditionDescs[num] + " " + this.WeaponNames[this.RequiredWeaponID];
		}
		else if (num == 2)
		{
			this.RequiredClothingID = UnityEngine.Random.Range(1, this.ClothingNames.Length);
			this.Descs[this.Difficulty].text = this.ConditionDescs[num] + " " + this.ClothingNames[this.RequiredClothingID];
		}
		else if (num == 3)
		{
			this.RequiredDisposalID = UnityEngine.Random.Range(1, this.DisposalNames.Length);
			this.Descs[this.Difficulty].text = this.ConditionDescs[num] + " " + this.DisposalNames[this.RequiredDisposalID];
		}
		this.UpdateDifficultyLabel();
	}

	// Token: 0x06000066 RID: 102 RVA: 0x0000D3AC File Offset: 0x0000B5AC
	private void ErasePreviousCondition()
	{
		if (this.Conditions[this.Difficulty + 1] == 1)
		{
			this.RequiredWeaponID = 0;
		}
		else if (this.Conditions[this.Difficulty + 1] == 2)
		{
			this.RequiredClothingID = 0;
		}
		else if (this.Conditions[this.Difficulty + 1] == 3)
		{
			this.RequiredDisposalID = 0;
		}
		this.Conditions[this.Difficulty + 1] = 0;
		this.UpdateDifficultyLabel();
	}

	// Token: 0x06000067 RID: 103 RVA: 0x0000D420 File Offset: 0x0000B620
	public void UpdateGraphics()
	{
		Debug.Log("Populating the Mission Mode criteria list!");
		this.TargetID = MissionModeGlobals.MissionTarget;
		if (this.TargetNumber > 11 && this.TargetNumber < 21)
		{
			this.TargetPortrait.mainTexture = this.BlankPortrait;
			this.TargetName = MissionModeGlobals.MissionTargetName;
		}
		else
		{
			WWW www = new WWW(string.Concat(new string[]
			{
				"file:///",
				Application.streamingAssetsPath,
				"/Portraits/Student_",
				MissionModeGlobals.MissionTarget.ToString(),
				".png"
			}));
			this.Icons[1].mainTexture = www.texture;
			this.TargetName = this.JSON.Students[MissionModeGlobals.MissionTarget].Name;
		}
		this.Descs[1].text = "Kill " + this.TargetName + ".";
		this.ChangeLabel(this.Descs[1]);
		for (int i = 2; i < this.Objectives.Length; i++)
		{
			this.Objectives[i].gameObject.SetActive(false);
		}
		if (MissionModeGlobals.MissionDifficulty > 1)
		{
			for (int j = 2; j < MissionModeGlobals.MissionDifficulty + 1; j++)
			{
				this.Objectives[j].gameObject.SetActive(true);
				this.Icons[j].mainTexture = this.ConditionIcons[MissionModeGlobals.GetMissionCondition(j)];
				this.ChangeLabel(this.Descs[j]);
				if (MissionModeGlobals.GetMissionCondition(j) > 3)
				{
					this.Descs[j].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(j)];
				}
				else if (MissionModeGlobals.GetMissionCondition(j) == 1)
				{
					this.RequiredWeaponID = 11;
					while (this.RequiredWeaponID == 11)
					{
						this.RequiredWeaponID = UnityEngine.Random.Range(1, this.WeaponNames.Length);
					}
					this.Descs[j].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(j)] + " " + this.WeaponNames[MissionModeGlobals.MissionRequiredWeapon];
				}
				else if (MissionModeGlobals.GetMissionCondition(j) == 2)
				{
					this.RequiredClothingID = UnityEngine.Random.Range(0, this.ClothingNames.Length);
					this.Descs[j].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(j)] + " " + this.ClothingNames[MissionModeGlobals.MissionRequiredClothing];
				}
				else if (MissionModeGlobals.GetMissionCondition(j) == 3)
				{
					this.RequiredDisposalID = UnityEngine.Random.Range(1, this.DisposalNames.Length);
					this.Descs[j].text = this.ConditionDescs[MissionModeGlobals.GetMissionCondition(j)] + " " + this.DisposalNames[MissionModeGlobals.MissionRequiredDisposal];
				}
			}
		}
	}

	// Token: 0x06000068 RID: 104 RVA: 0x0000D6C2 File Offset: 0x0000B8C2
	private void UpdatePopulation()
	{
		this.CustomPopulationLabel.text = "";
		this.PopulationLabel.text = "";
		OptionGlobals.HighPopulation = false;
	}

	// Token: 0x06000069 RID: 105 RVA: 0x0000D6EC File Offset: 0x0000B8EC
	private void UpdateObjectiveHighlight()
	{
		if (this.Row < 1)
		{
			this.Row = 6;
		}
		else if (this.Row > 6)
		{
			this.Row = 1;
		}
		else if (this.Column < 1)
		{
			this.Column = 3;
		}
		else if (this.Column > 3)
		{
			this.Column = 1;
		}
		if (this.Row == 6 && this.Column == 3)
		{
			this.Column = 1;
		}
		int num = 0;
		if (this.Row == 6)
		{
			num = 75;
		}
		this.PromptBar.Label[2].text = (((this.Column == 1 && this.Row < 5) || (this.Column == 2 && this.Row == 6)) ? "Change" : string.Empty);
		this.ObjectiveHighlight.localPosition = new Vector3(-1050f + 650f * (float)this.Column, 450f - 150f * (float)this.Row - (float)num, this.ObjectiveHighlight.localPosition.z);
		this.CustomSelected = this.Row + (this.Column - 1) * 6;
		this.Toggling = false;
		if (this.CustomSelected == 1 || this.CustomSelected == 12)
		{
			this.PromptBar.Label[0].text = "Forward";
		}
		else if (this.CustomSelected == 6)
		{
			this.PromptBar.Label[0].text = "Start";
		}
		else
		{
			this.PromptBar.Label[0].text = "Toggle";
			this.Toggling = true;
		}
		if (this.CustomSelected == 1 || this.CustomSelected == 12)
		{
			this.PromptBar.Label[2].text = "Backward";
		}
		else if (this.CustomSelected > 4)
		{
			this.PromptBar.Label[2].text = string.Empty;
		}
		else
		{
			this.PromptBar.Label[2].text = "Change";
		}
		this.PromptBar.UpdateButtons();
	}

	// Token: 0x0600006A RID: 106 RVA: 0x0000D8EC File Offset: 0x0000BAEC
	private void CalculateMissionID()
	{
		this.TargetString = ((this.TargetID < 10) ? "0" : "") + this.TargetID.ToString();
		if (this.CustomObjectives[2].alpha == 1f)
		{
			this.WeaponString = ((this.RequiredWeaponID < 10) ? "0" : "") + this.RequiredWeaponID.ToString();
		}
		else
		{
			this.WeaponString = "00";
		}
		this.ClothingString = ((this.CustomObjectives[3].alpha == 1f) ? this.RequiredClothingID.ToString() : "0");
		this.DisposalString = ((this.CustomObjectives[4].alpha == 1f) ? this.RequiredDisposalID.ToString() : "0");
		for (int i = 1; i < this.CustomObjectives.Length; i++)
		{
			if (this.CustomObjectives[i] != null)
			{
				this.ConditionString[i] = ((this.CustomObjectives[i].alpha == 1f) ? "1" : "0");
			}
		}
		this.MissionID = string.Concat(new string[]
		{
			this.TargetString,
			this.WeaponString,
			this.ClothingString,
			this.DisposalString,
			this.ConditionString[5],
			this.ConditionString[6],
			this.ConditionString[7],
			this.ConditionString[8],
			this.ConditionString[9],
			this.ConditionString[10],
			this.ConditionString[11],
			this.ConditionString[12],
			this.ConditionString[13],
			this.ConditionString[14],
			this.ConditionString[15],
			this.ConditionString[16],
			this.ConditionString[17],
			this.NemesisDifficulty.ToString(),
			"0"
		});
		this.MissionIDLabel.text = this.MissionID;
	}

	// Token: 0x0600006B RID: 107 RVA: 0x0000DB14 File Offset: 0x0000BD14
	private void StartMission()
	{
		this.MyAudio.PlayOneShot(this.InfoLines[6]);
		Globals.DeleteAll();
		OptionGlobals.TutorialsOff = true;
		SchoolGlobals.SchoolAtmosphere = 1f - (float)this.Difficulty * 0.1f;
		MissionModeGlobals.NemesisDifficulty = this.NemesisDifficulty;
		MissionModeGlobals.MissionTargetName = this.TargetName;
		MissionModeGlobals.MissionDifficulty = this.Difficulty;
		MissionModeGlobals.MissionTarget = this.TargetID;
		SchoolGlobals.SchoolAtmosphereSet = true;
		MissionModeGlobals.MissionMode = true;
		ClassGlobals.BiologyGrade = 1;
		ClassGlobals.ChemistryGrade = 1;
		ClassGlobals.LanguageGrade = 1;
		ClassGlobals.PhysicalGrade = 1;
		ClassGlobals.PsychologyGrade = 1;
		if (this.Difficulty > 1)
		{
			for (int i = 2; i < this.Difficulty + 1; i++)
			{
				if (this.Conditions[i] == 1)
				{
					MissionModeGlobals.MissionRequiredWeapon = this.RequiredWeaponID;
				}
				else if (this.Conditions[i] == 2)
				{
					MissionModeGlobals.MissionRequiredClothing = this.RequiredClothingID;
				}
				else if (this.Conditions[i] == 3)
				{
					MissionModeGlobals.MissionRequiredDisposal = this.RequiredDisposalID;
				}
				MissionModeGlobals.SetMissionCondition(i, this.Conditions[i]);
			}
		}
		this.PromptBar.Show = false;
		this.Speed = 0f;
		this.Phase = 4;
	}

	// Token: 0x0600006C RID: 108 RVA: 0x0000DC3C File Offset: 0x0000BE3C
	private void ChangeFont()
	{
		foreach (UILabel uilabel in UnityEngine.Object.FindObjectsOfType<UILabel>())
		{
			uilabel.trueTypeFont = this.Arial;
			uilabel.fontSize += 10;
			if (uilabel.height == 150)
			{
				uilabel.height = 100;
			}
		}
	}

	// Token: 0x0600006D RID: 109 RVA: 0x0000DC91 File Offset: 0x0000BE91
	private void ChangeLabel(UILabel Text)
	{
		Text.trueTypeFont = this.Arial;
	}

	// Token: 0x04000166 RID: 358
	public PostProcessingProfile Profile;

	// Token: 0x04000167 RID: 359
	public StudentManagerScript StudentManager;

	// Token: 0x04000168 RID: 360
	public NewMissionWindowScript MultiMission;

	// Token: 0x04000169 RID: 361
	public InputManagerScript InputManager;

	// Token: 0x0400016A RID: 362
	public PromptBarScript PromptBar;

	// Token: 0x0400016B RID: 363
	public JsonScript JSON;

	// Token: 0x0400016C RID: 364
	public UITexture CustomTargetPortrait;

	// Token: 0x0400016D RID: 365
	public UILabel CustomDifficultyLabel;

	// Token: 0x0400016E RID: 366
	public UILabel CustomPopulationLabel;

	// Token: 0x0400016F RID: 367
	public UILabel CustomNemesisLabel;

	// Token: 0x04000170 RID: 368
	public UITexture NemesisPortrait;

	// Token: 0x04000171 RID: 369
	public UITexture TargetPortrait;

	// Token: 0x04000172 RID: 370
	public UILabel LoadMissionLabel;

	// Token: 0x04000173 RID: 371
	public UILabel DescriptionLabel;

	// Token: 0x04000174 RID: 372
	public UILabel DifficultyLabel;

	// Token: 0x04000175 RID: 373
	public UILabel PopulationLabel;

	// Token: 0x04000176 RID: 374
	public UILabel NemesisLabel;

	// Token: 0x04000177 RID: 375
	public UILabel ErrorLabel;

	// Token: 0x04000178 RID: 376
	public UILabel Header;

	// Token: 0x04000179 RID: 377
	public UISprite Highlight;

	// Token: 0x0400017A RID: 378
	public UISprite Darkness;

	// Token: 0x0400017B RID: 379
	public Transform CustomMissionWindow;

	// Token: 0x0400017C RID: 380
	public Transform MultiMissionWindow;

	// Token: 0x0400017D RID: 381
	public Transform ObjectiveHighlight;

	// Token: 0x0400017E RID: 382
	public Transform LoadMissionWindow;

	// Token: 0x0400017F RID: 383
	public Transform MissionWindow;

	// Token: 0x04000180 RID: 384
	public Transform InfoChan;

	// Token: 0x04000181 RID: 385
	public Transform Options;

	// Token: 0x04000182 RID: 386
	public Transform Neck;

	// Token: 0x04000183 RID: 387
	public GameObject NowLoading;

	// Token: 0x04000184 RID: 388
	public string[] ConditionDescs;

	// Token: 0x04000185 RID: 389
	public int[] Conditions;

	// Token: 0x04000186 RID: 390
	public string[] ClothingNames;

	// Token: 0x04000187 RID: 391
	public string[] DisposalNames;

	// Token: 0x04000188 RID: 392
	public string[] WeaponNames;

	// Token: 0x04000189 RID: 393
	public int RequiredClothingID;

	// Token: 0x0400018A RID: 394
	public int RequiredDisposalID;

	// Token: 0x0400018B RID: 395
	public int RequiredWeaponID;

	// Token: 0x0400018C RID: 396
	public Transform[] CustomNemesisObjectives;

	// Token: 0x0400018D RID: 397
	public Transform[] NemesisObjectives;

	// Token: 0x0400018E RID: 398
	public UIPanel[] CustomObjectives;

	// Token: 0x0400018F RID: 399
	public Texture[] ConditionIcons;

	// Token: 0x04000190 RID: 400
	public Transform[] Objectives;

	// Token: 0x04000191 RID: 401
	public Transform[] Option;

	// Token: 0x04000192 RID: 402
	public UITexture[] Icons;

	// Token: 0x04000193 RID: 403
	public UILabel[] CustomDescs;

	// Token: 0x04000194 RID: 404
	public UILabel[] Descs;

	// Token: 0x04000195 RID: 405
	public Texture NemesisGraphic;

	// Token: 0x04000196 RID: 406
	public Texture BlankPortrait;

	// Token: 0x04000197 RID: 407
	public string MissionIDString = string.Empty;

	// Token: 0x04000198 RID: 408
	public string TargetName = string.Empty;

	// Token: 0x04000199 RID: 409
	public int NemesisDifficulty;

	// Token: 0x0400019A RID: 410
	public int CustomSelected = 1;

	// Token: 0x0400019B RID: 411
	public int Difficulty = 1;

	// Token: 0x0400019C RID: 412
	public int Selected = 1;

	// Token: 0x0400019D RID: 413
	public int TargetID;

	// Token: 0x0400019E RID: 414
	public int Phase;

	// Token: 0x0400019F RID: 415
	public int Column = 1;

	// Token: 0x040001A0 RID: 416
	public int Row = 1;

	// Token: 0x040001A1 RID: 417
	public float Rotation;

	// Token: 0x040001A2 RID: 418
	public float Speed;

	// Token: 0x040001A3 RID: 419
	public float Timer;

	// Token: 0x040001A4 RID: 420
	public AudioSource Jukebox;

	// Token: 0x040001A5 RID: 421
	public AudioSource MyAudio;

	// Token: 0x040001A6 RID: 422
	public AudioClip[] InfoLines;

	// Token: 0x040001A7 RID: 423
	public bool[] InfoSpoke;

	// Token: 0x040001A8 RID: 424
	public bool Toggling;

	// Token: 0x040001A9 RID: 425
	public int TargetNumber;

	// Token: 0x040001AA RID: 426
	public int WeaponNumber;

	// Token: 0x040001AB RID: 427
	public int ClothingNumber;

	// Token: 0x040001AC RID: 428
	public int DisposalNumber;

	// Token: 0x040001AD RID: 429
	public int NemesisNumber;

	// Token: 0x040001AE RID: 430
	public int PopulationNumber;

	// Token: 0x040001AF RID: 431
	public int Condition5Number;

	// Token: 0x040001B0 RID: 432
	public int Condition6Number;

	// Token: 0x040001B1 RID: 433
	public int Condition7Number;

	// Token: 0x040001B2 RID: 434
	public int Condition8Number;

	// Token: 0x040001B3 RID: 435
	public int Condition9Number;

	// Token: 0x040001B4 RID: 436
	public int Condition10Number;

	// Token: 0x040001B5 RID: 437
	public int Condition11Number;

	// Token: 0x040001B6 RID: 438
	public int Condition12Number;

	// Token: 0x040001B7 RID: 439
	public int Condition13Number;

	// Token: 0x040001B8 RID: 440
	public int Condition14Number;

	// Token: 0x040001B9 RID: 441
	public int Condition15Number;

	// Token: 0x040001BA RID: 442
	public string TargetString = string.Empty;

	// Token: 0x040001BB RID: 443
	public string WeaponString = string.Empty;

	// Token: 0x040001BC RID: 444
	public string ClothingString = string.Empty;

	// Token: 0x040001BD RID: 445
	public string DisposalString = string.Empty;

	// Token: 0x040001BE RID: 446
	public string MissionID = string.Empty;

	// Token: 0x040001BF RID: 447
	public string[] ConditionString;

	// Token: 0x040001C0 RID: 448
	public UILabel MissionIDLabel;

	// Token: 0x040001C1 RID: 449
	public Font Arial;
}
