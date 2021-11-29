using System;
using UnityEngine;

// Token: 0x02000254 RID: 596
public class ComputerGamesScript : MonoBehaviour
{
	// Token: 0x06001291 RID: 4753 RVA: 0x00095D78 File Offset: 0x00093F78
	private void Start()
	{
		this.GameWindow.gameObject.SetActive(false);
		this.UpdateHighlight();
		this.DeactivateAllBenefits();
		this.OriginalColor = this.Yandere.PowerUp.color;
		if (ClubGlobals.Club == ClubType.Gaming)
		{
			this.EnableGames();
			return;
		}
		this.DisableGames();
	}

	// Token: 0x06001292 RID: 4754 RVA: 0x00095DD0 File Offset: 0x00093FD0
	private void Update()
	{
		if (this.ShowWindow)
		{
			this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (this.InputManager.TappedUp)
			{
				this.Subject--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedDown)
			{
				this.Subject++;
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				this.ShowWindow = false;
				this.PlayGames();
				this.PromptBar.ClearButtons();
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = false;
			}
			if (Input.GetButtonDown("B"))
			{
				this.Yandere.CanMove = true;
				this.ShowWindow = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = false;
			}
		}
		else if (this.GameWindow.localScale.x > 0.1f)
		{
			this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else
		{
			this.GameWindow.localScale = Vector3.zero;
			this.GameWindow.gameObject.SetActive(false);
		}
		if (this.Gaming)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.ComputerGames[this.GameID].transform.position.x, this.Yandere.transform.position.y, this.ComputerGames[this.GameID].transform.position.z) - this.Yandere.transform.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
			this.Yandere.MoveTowardsTarget(new Vector3(24.32233f, 4f, 12.58998f));
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				this.Yandere.PowerUp.transform.parent.gameObject.SetActive(true);
				this.Yandere.MyController.radius = 0.2f;
				this.Yandere.CanMove = true;
				this.Yandere.EmptyHands();
				this.Gaming = false;
				this.ActivateBenefit();
			}
		}
		else if (this.Timer < 5f)
		{
			this.ID = 1;
			while (this.ID < this.ComputerGames.Length)
			{
				PromptScript promptScript = this.ComputerGames[this.ID];
				if (promptScript.Circle[0].fillAmount == 0f)
				{
					promptScript.Circle[0].fillAmount = 1f;
					if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
					{
						this.GameID = this.ID;
						if (this.ID == 1)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Confirm";
							this.PromptBar.Label[1].text = "Back";
							this.PromptBar.Label[4].text = "Select";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							this.Yandere.Character.GetComponent<Animation>().Play(this.Yandere.IdleAnim);
							this.Yandere.CanMove = false;
							this.GameWindow.gameObject.SetActive(true);
							this.ShowWindow = true;
						}
						else
						{
							this.PlayGames();
						}
					}
				}
				this.ID++;
			}
		}
		if (this.Yandere.PowerUp.gameObject.activeInHierarchy)
		{
			this.Timer += Time.deltaTime;
			this.Yandere.PowerUp.transform.localPosition = new Vector3(this.Yandere.PowerUp.transform.localPosition.x, this.Yandere.PowerUp.transform.localPosition.y + Time.deltaTime, this.Yandere.PowerUp.transform.localPosition.z);
			this.Yandere.PowerUp.transform.LookAt(this.MainCamera.position);
			this.Yandere.PowerUp.transform.localEulerAngles = new Vector3(this.Yandere.PowerUp.transform.localEulerAngles.x, this.Yandere.PowerUp.transform.localEulerAngles.y + 180f, this.Yandere.PowerUp.transform.localEulerAngles.z);
			if (this.Yandere.PowerUp.color != new Color(1f, 1f, 1f, 1f))
			{
				this.Yandere.PowerUp.color = this.OriginalColor;
			}
			else
			{
				this.Yandere.PowerUp.color = new Color(1f, 1f, 1f, 1f);
			}
			if (this.Timer > 6f)
			{
				this.Yandere.PowerUp.transform.parent.gameObject.SetActive(false);
				base.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001293 RID: 4755 RVA: 0x000963D0 File Offset: 0x000945D0
	public void EnableGames()
	{
		for (int i = 1; i < this.ComputerGames.Length; i++)
		{
			this.ComputerGames[i].enabled = true;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001294 RID: 4756 RVA: 0x0009640C File Offset: 0x0009460C
	private void PlayGames()
	{
		this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_playingGames_00");
		this.Yandere.MyController.radius = 0.1f;
		this.Yandere.CanMove = false;
		this.Gaming = true;
		this.DisableGames();
		this.UpdateImage();
	}

	// Token: 0x06001295 RID: 4757 RVA: 0x00096467 File Offset: 0x00094667
	private void UpdateImage()
	{
		this.MyTexture.mainTexture = this.Textures[this.Subject];
	}

	// Token: 0x06001296 RID: 4758 RVA: 0x00096484 File Offset: 0x00094684
	public void DisableGames()
	{
		for (int i = 1; i < this.ComputerGames.Length; i++)
		{
			this.ComputerGames[i].enabled = false;
			this.ComputerGames[i].Hide();
		}
		if (!this.Gaming)
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001297 RID: 4759 RVA: 0x000964D4 File Offset: 0x000946D4
	private void EnableChairs()
	{
		for (int i = 1; i < this.Chairs.Length; i++)
		{
			this.Chairs[i].enabled = true;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001298 RID: 4760 RVA: 0x00096510 File Offset: 0x00094710
	private void DisableChairs()
	{
		for (int i = 1; i < this.Chairs.Length; i++)
		{
			this.Chairs[i].enabled = false;
		}
	}

	// Token: 0x06001299 RID: 4761 RVA: 0x00096540 File Offset: 0x00094740
	private void ActivateBenefit()
	{
		if (this.Subject == 1)
		{
			this.Yandere.Class.BiologyBonus = 1;
		}
		else if (this.Subject == 2)
		{
			this.Yandere.Class.ChemistryBonus = 1;
		}
		else if (this.Subject == 3)
		{
			this.Yandere.Class.LanguageBonus = 1;
		}
		else if (this.Subject == 4)
		{
			this.Yandere.Class.PsychologyBonus = 1;
		}
		else if (this.Subject == 5)
		{
			this.Yandere.Class.PhysicalBonus = 1;
		}
		else if (this.Subject == 6)
		{
			this.Yandere.Class.SeductionBonus = 1;
		}
		else if (this.Subject == 7)
		{
			this.Yandere.Class.NumbnessBonus = 1;
		}
		else if (this.Subject == 8)
		{
			this.Yandere.Class.SocialBonus = 1;
		}
		else if (this.Subject == 9)
		{
			this.Yandere.Class.StealthBonus = 1;
		}
		else if (this.Subject == 10)
		{
			this.Yandere.Class.SpeedBonus = 1;
		}
		else if (this.Subject == 11)
		{
			this.Yandere.Class.EnlightenmentBonus = 1;
		}
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
		this.StudentManager.UpdatePerception();
		this.Yandere.UpdateNumbness();
		this.Police.UpdateCorpses();
	}

	// Token: 0x0600129A RID: 4762 RVA: 0x000966D0 File Offset: 0x000948D0
	private void DeactivateBenefit()
	{
		if (this.Subject == 1)
		{
			this.Yandere.Class.BiologyBonus = 0;
		}
		else if (this.Subject == 2)
		{
			this.Yandere.Class.ChemistryBonus = 0;
		}
		else if (this.Subject == 3)
		{
			this.Yandere.Class.LanguageBonus = 0;
		}
		else if (this.Subject == 4)
		{
			this.Yandere.Class.PsychologyBonus = 0;
		}
		else if (this.Subject == 5)
		{
			this.Yandere.Class.PhysicalBonus = 0;
		}
		else if (this.Subject == 6)
		{
			this.Yandere.Class.SeductionBonus = 0;
		}
		else if (this.Subject == 7)
		{
			this.Yandere.Class.NumbnessBonus = 0;
		}
		else if (this.Subject == 8)
		{
			this.Yandere.Class.SocialBonus = 0;
		}
		else if (this.Subject == 9)
		{
			this.Yandere.Class.StealthBonus = 0;
		}
		else if (this.Subject == 10)
		{
			this.Yandere.Class.SpeedBonus = 0;
		}
		else if (this.Subject == 11)
		{
			this.Yandere.Class.EnlightenmentBonus = 0;
		}
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
		this.StudentManager.UpdatePerception();
		this.Yandere.UpdateNumbness();
		this.Police.UpdateCorpses();
	}

	// Token: 0x0600129B RID: 4763 RVA: 0x00096860 File Offset: 0x00094A60
	public void DeactivateAllBenefits()
	{
		this.Yandere.Class.BiologyBonus = 0;
		this.Yandere.Class.ChemistryBonus = 0;
		this.Yandere.Class.LanguageBonus = 0;
		this.Yandere.Class.PsychologyBonus = 0;
		this.Yandere.Class.PhysicalBonus = 0;
		this.Yandere.Class.SeductionBonus = 0;
		this.Yandere.Class.NumbnessBonus = 0;
		this.Yandere.Class.SocialBonus = 0;
		this.Yandere.Class.StealthBonus = 0;
		this.Yandere.Class.SpeedBonus = 0;
		this.Yandere.Class.EnlightenmentBonus = 0;
		if (this.Poison != null)
		{
			this.Poison.Start();
		}
	}

	// Token: 0x0600129C RID: 4764 RVA: 0x00096944 File Offset: 0x00094B44
	private void UpdateHighlight()
	{
		if (this.Subject < 1)
		{
			this.Subject = 11;
		}
		else if (this.Subject > 11)
		{
			this.Subject = 1;
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 250f - (float)this.Subject * 50f, this.Highlight.localPosition.z);
		this.DescLabel.text = this.Descriptions[this.Subject];
	}

	// Token: 0x0400184D RID: 6221
	public PromptScript[] ComputerGames;

	// Token: 0x0400184E RID: 6222
	public Collider[] Chairs;

	// Token: 0x0400184F RID: 6223
	public StudentManagerScript StudentManager;

	// Token: 0x04001850 RID: 6224
	public InputManagerScript InputManager;

	// Token: 0x04001851 RID: 6225
	public PromptBarScript PromptBar;

	// Token: 0x04001852 RID: 6226
	public YandereScript Yandere;

	// Token: 0x04001853 RID: 6227
	public PoliceScript Police;

	// Token: 0x04001854 RID: 6228
	public PoisonScript Poison;

	// Token: 0x04001855 RID: 6229
	public Quaternion targetRotation;

	// Token: 0x04001856 RID: 6230
	public Transform GameWindow;

	// Token: 0x04001857 RID: 6231
	public Transform MainCamera;

	// Token: 0x04001858 RID: 6232
	public Transform Highlight;

	// Token: 0x04001859 RID: 6233
	public bool ShowWindow;

	// Token: 0x0400185A RID: 6234
	public bool Gaming;

	// Token: 0x0400185B RID: 6235
	public float Timer;

	// Token: 0x0400185C RID: 6236
	public int Subject = 1;

	// Token: 0x0400185D RID: 6237
	public int GameID;

	// Token: 0x0400185E RID: 6238
	public int ID = 1;

	// Token: 0x0400185F RID: 6239
	public Color OriginalColor;

	// Token: 0x04001860 RID: 6240
	public string[] Descriptions;

	// Token: 0x04001861 RID: 6241
	public UITexture MyTexture;

	// Token: 0x04001862 RID: 6242
	public Texture[] Textures;

	// Token: 0x04001863 RID: 6243
	public UILabel DescLabel;
}
