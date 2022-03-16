using System;
using UnityEngine;

// Token: 0x02000255 RID: 597
public class ComputerGamesScript : MonoBehaviour
{
	// Token: 0x0600129A RID: 4762 RVA: 0x000966F4 File Offset: 0x000948F4
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

	// Token: 0x0600129B RID: 4763 RVA: 0x0009674C File Offset: 0x0009494C
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

	// Token: 0x0600129C RID: 4764 RVA: 0x00096D4C File Offset: 0x00094F4C
	public void EnableGames()
	{
		for (int i = 1; i < this.ComputerGames.Length; i++)
		{
			this.ComputerGames[i].enabled = true;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x0600129D RID: 4765 RVA: 0x00096D88 File Offset: 0x00094F88
	private void PlayGames()
	{
		this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_playingGames_00");
		this.Yandere.MyController.radius = 0.1f;
		this.Yandere.CanMove = false;
		this.Gaming = true;
		this.DisableGames();
		this.UpdateImage();
	}

	// Token: 0x0600129E RID: 4766 RVA: 0x00096DE3 File Offset: 0x00094FE3
	private void UpdateImage()
	{
		this.MyTexture.mainTexture = this.Textures[this.Subject];
	}

	// Token: 0x0600129F RID: 4767 RVA: 0x00096E00 File Offset: 0x00095000
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

	// Token: 0x060012A0 RID: 4768 RVA: 0x00096E50 File Offset: 0x00095050
	private void EnableChairs()
	{
		for (int i = 1; i < this.Chairs.Length; i++)
		{
			this.Chairs[i].enabled = true;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x060012A1 RID: 4769 RVA: 0x00096E8C File Offset: 0x0009508C
	private void DisableChairs()
	{
		for (int i = 1; i < this.Chairs.Length; i++)
		{
			this.Chairs[i].enabled = false;
		}
	}

	// Token: 0x060012A2 RID: 4770 RVA: 0x00096EBC File Offset: 0x000950BC
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

	// Token: 0x060012A3 RID: 4771 RVA: 0x0009704C File Offset: 0x0009524C
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

	// Token: 0x060012A4 RID: 4772 RVA: 0x000971DC File Offset: 0x000953DC
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

	// Token: 0x060012A5 RID: 4773 RVA: 0x000972C0 File Offset: 0x000954C0
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

	// Token: 0x04001869 RID: 6249
	public PromptScript[] ComputerGames;

	// Token: 0x0400186A RID: 6250
	public Collider[] Chairs;

	// Token: 0x0400186B RID: 6251
	public StudentManagerScript StudentManager;

	// Token: 0x0400186C RID: 6252
	public InputManagerScript InputManager;

	// Token: 0x0400186D RID: 6253
	public PromptBarScript PromptBar;

	// Token: 0x0400186E RID: 6254
	public YandereScript Yandere;

	// Token: 0x0400186F RID: 6255
	public PoliceScript Police;

	// Token: 0x04001870 RID: 6256
	public PoisonScript Poison;

	// Token: 0x04001871 RID: 6257
	public Quaternion targetRotation;

	// Token: 0x04001872 RID: 6258
	public Transform GameWindow;

	// Token: 0x04001873 RID: 6259
	public Transform MainCamera;

	// Token: 0x04001874 RID: 6260
	public Transform Highlight;

	// Token: 0x04001875 RID: 6261
	public bool ShowWindow;

	// Token: 0x04001876 RID: 6262
	public bool Gaming;

	// Token: 0x04001877 RID: 6263
	public float Timer;

	// Token: 0x04001878 RID: 6264
	public int Subject = 1;

	// Token: 0x04001879 RID: 6265
	public int GameID;

	// Token: 0x0400187A RID: 6266
	public int ID = 1;

	// Token: 0x0400187B RID: 6267
	public Color OriginalColor;

	// Token: 0x0400187C RID: 6268
	public string[] Descriptions;

	// Token: 0x0400187D RID: 6269
	public UITexture MyTexture;

	// Token: 0x0400187E RID: 6270
	public Texture[] Textures;

	// Token: 0x0400187F RID: 6271
	public UILabel DescLabel;
}
