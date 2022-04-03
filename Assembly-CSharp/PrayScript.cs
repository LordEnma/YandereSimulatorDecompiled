using System;
using UnityEngine;

// Token: 0x020003BF RID: 959
public class PrayScript : MonoBehaviour
{
	// Token: 0x06001B17 RID: 6935 RVA: 0x0012D754 File Offset: 0x0012B954
	private void Start()
	{
		if (StudentGlobals.GetStudentDead(39))
		{
			this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, 0.5f);
		}
		this.GenderPrompt.gameObject.SetActive(true);
		this.PrayWindow.localScale = Vector3.zero;
		this.Prompt.enabled = true;
	}

	// Token: 0x06001B18 RID: 6936 RVA: 0x0012D7DC File Offset: 0x0012B9DC
	private void Update()
	{
		if (!this.FemaleVictimChecked)
		{
			if (this.StudentManager.Students[39] != null && !this.StudentManager.Students[39].Alive)
			{
				this.FemaleVictimChecked = true;
				this.Victims++;
			}
		}
		else if (this.StudentManager.Students[39] == null)
		{
			this.FemaleVictimChecked = false;
			this.Victims--;
		}
		if (!this.MaleVictimChecked)
		{
			if (this.StudentManager.Students[37] != null && !this.StudentManager.Students[37].Alive)
			{
				this.MaleVictimChecked = true;
				this.Victims++;
			}
		}
		else if (this.StudentManager.Students[37] == null)
		{
			this.MaleVictimChecked = false;
			this.Victims--;
		}
		if (this.JustSummoned)
		{
			this.StudentManager.UpdateMe(this.StudentID);
			this.JustSummoned = false;
		}
		if (this.GenderPrompt.Circle[0].fillAmount == 0f)
		{
			this.GenderPrompt.Circle[0].fillAmount = 1f;
			if (!this.SpawnMale)
			{
				this.GenderPrompt.Label[0].text = "     Male Victim";
				this.SpawnMale = true;
			}
			else
			{
				this.GenderPrompt.Label[0].text = "     Female Victim";
				this.SpawnMale = false;
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				this.Yandere.TargetStudent = this.Student;
				this.StudentManager.DisablePrompts();
				this.PrayWindow.gameObject.SetActive(true);
				this.Show = true;
				this.Yandere.ShoulderCamera.OverShoulder = true;
				this.Yandere.WeaponMenu.KeyboardShow = false;
				this.Yandere.WeaponMenu.Show = false;
				this.Yandere.YandereVision = false;
				this.Yandere.CanMove = false;
				this.Yandere.Talking = true;
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.StudentNumber = (this.SpawnMale ? 37 : 39);
				this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, 1f);
			}
		}
		if (!this.Show)
		{
			if (this.PrayWindow.gameObject.activeInHierarchy)
			{
				if (this.PrayWindow.localScale.x > 0.1f)
				{
					this.PrayWindow.localScale = Vector3.Lerp(this.PrayWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
					return;
				}
				this.PrayWindow.localScale = Vector3.zero;
				this.PrayWindow.gameObject.SetActive(false);
				return;
			}
		}
		else
		{
			this.PrayWindow.localScale = Vector3.Lerp(this.PrayWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				if (this.Selected == 7)
				{
					this.Selected = 6;
				}
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedDown)
			{
				this.Selected++;
				if (this.Selected == 7)
				{
					this.Selected = 8;
				}
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.Selected == 1)
				{
					if (!this.Yandere.SanityBased)
					{
						this.SanityLabel.text = "Disable Sanity Anims";
						this.Yandere.SanityBased = true;
					}
					else
					{
						this.SanityLabel.text = "Enable Sanity Anims";
						this.Yandere.SanityBased = false;
					}
					this.Exit();
				}
				else if (this.Selected == 2)
				{
					this.Yandere.Sanity -= 50f;
					this.Exit();
				}
				else if (this.Selected == 3)
				{
					if (this.VictimLabel.color.a == 1f && this.StudentManager.NPCsSpawned >= this.StudentManager.NPCsTotal)
					{
						if (this.SpawnMale)
						{
							this.MaleVictimChecked = false;
							this.StudentID = 37;
						}
						else
						{
							this.FemaleVictimChecked = false;
							this.StudentID = 39;
						}
						if (this.SpawnOsana)
						{
							this.StudentID = 11;
						}
						if (this.StudentManager.Students[this.StudentID] != null)
						{
							UnityEngine.Object.Destroy(this.StudentManager.Students[this.StudentID].gameObject);
						}
						this.StudentManager.Students[this.StudentID] = null;
						this.StudentManager.ForceSpawn = true;
						this.StudentManager.SpawnPositions[this.StudentID] = this.SummonSpot;
						this.StudentManager.SpawnID = this.StudentID;
						this.StudentManager.SpawnStudent(this.StudentManager.SpawnID);
						this.StudentManager.SpawnID = 0;
						this.Police.Corpses -= this.Victims;
						this.Victims = 0;
						this.JustSummoned = true;
						this.Exit();
					}
				}
				else if (this.Selected == 4)
				{
					this.SpawnWeapons();
					this.Exit();
				}
				else if (this.Selected == 5)
				{
					if (this.Yandere.Gloved)
					{
						this.Yandere.Gloves.Blood.enabled = false;
					}
					if (this.Yandere.CurrentUniformOrigin == 1)
					{
						this.StudentManager.OriginalUniforms++;
					}
					else
					{
						this.StudentManager.NewUniforms++;
					}
					this.Police.BloodyClothing = 0;
					this.Yandere.Bloodiness = 0f;
					this.Yandere.Sanity = 100f;
					this.Exit();
				}
				else if (this.Selected == 6)
				{
					this.WeaponManager.CleanWeapons();
					this.Exit();
				}
				else if (this.Selected == 8)
				{
					this.DebugEnabler.EnableDebug();
					this.Exit();
				}
			}
			if (Input.GetKeyDown("b"))
			{
				foreach (object obj in this.Police.BloodParent.transform)
				{
					UnityEngine.Object.Destroy(((Transform)obj).gameObject);
				}
			}
			if (Input.GetKeyDown("o"))
			{
				this.SpawnOsana = true;
			}
		}
	}

	// Token: 0x06001B19 RID: 6937 RVA: 0x0012DF50 File Offset: 0x0012C150
	private void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 8;
		}
		else if (this.Selected > 8)
		{
			this.Selected = 1;
		}
		this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, 225f - 50f * (float)this.Selected, this.Highlight.transform.localPosition.z);
	}

	// Token: 0x06001B1A RID: 6938 RVA: 0x0012DFD4 File Offset: 0x0012C1D4
	private void Exit()
	{
		this.Yandere.CameraEffects.UpdateDOF(2f);
		this.Selected = 1;
		this.UpdateHighlight();
		this.Yandere.ShoulderCamera.OverShoulder = false;
		this.StudentManager.EnablePrompts();
		this.Yandere.TargetStudent = null;
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Show = false;
		this.Uses++;
		if (this.Uses > 9)
		{
			this.FemaleTurtle.SetActive(true);
		}
	}

	// Token: 0x06001B1B RID: 6939 RVA: 0x0012E070 File Offset: 0x0012C270
	public void SpawnWeapons()
	{
		for (int i = 1; i < 6; i++)
		{
			if (this.Weapon[i] != null)
			{
				this.Weapon[i].transform.position = this.WeaponSpot[i].position;
			}
		}
	}

	// Token: 0x04002DFD RID: 11773
	public StudentManagerScript StudentManager;

	// Token: 0x04002DFE RID: 11774
	public WeaponManagerScript WeaponManager;

	// Token: 0x04002DFF RID: 11775
	public DebugEnablerScript DebugEnabler;

	// Token: 0x04002E00 RID: 11776
	public InputManagerScript InputManager;

	// Token: 0x04002E01 RID: 11777
	public PromptBarScript PromptBar;

	// Token: 0x04002E02 RID: 11778
	public StudentScript Student;

	// Token: 0x04002E03 RID: 11779
	public YandereScript Yandere;

	// Token: 0x04002E04 RID: 11780
	public PoliceScript Police;

	// Token: 0x04002E05 RID: 11781
	public UILabel SanityLabel;

	// Token: 0x04002E06 RID: 11782
	public UILabel VictimLabel;

	// Token: 0x04002E07 RID: 11783
	public PromptScript GenderPrompt;

	// Token: 0x04002E08 RID: 11784
	public PromptScript Prompt;

	// Token: 0x04002E09 RID: 11785
	public Transform PrayWindow;

	// Token: 0x04002E0A RID: 11786
	public Transform SummonSpot;

	// Token: 0x04002E0B RID: 11787
	public Transform Highlight;

	// Token: 0x04002E0C RID: 11788
	public Transform[] WeaponSpot;

	// Token: 0x04002E0D RID: 11789
	public GameObject[] Weapon;

	// Token: 0x04002E0E RID: 11790
	public GameObject FemaleTurtle;

	// Token: 0x04002E0F RID: 11791
	public int StudentNumber;

	// Token: 0x04002E10 RID: 11792
	public int StudentID;

	// Token: 0x04002E11 RID: 11793
	public int Selected;

	// Token: 0x04002E12 RID: 11794
	public int Victims;

	// Token: 0x04002E13 RID: 11795
	public int Uses;

	// Token: 0x04002E14 RID: 11796
	public bool FemaleVictimChecked;

	// Token: 0x04002E15 RID: 11797
	public bool MaleVictimChecked;

	// Token: 0x04002E16 RID: 11798
	public bool JustSummoned;

	// Token: 0x04002E17 RID: 11799
	public bool SpawnOsana;

	// Token: 0x04002E18 RID: 11800
	public bool SpawnMale;

	// Token: 0x04002E19 RID: 11801
	public bool Show;
}
