using System;
using UnityEngine;

// Token: 0x0200031E RID: 798
public class HomeMangaScript : MonoBehaviour
{
	// Token: 0x0600187A RID: 6266 RVA: 0x000EEC30 File Offset: 0x000ECE30
	private void Start()
	{
		this.UpdateCurrentLabel();
		for (int i = 0; i < this.TotalManga; i++)
		{
			if (CollectibleGlobals.GetMangaCollected(i + 1))
			{
				this.NewManga = UnityEngine.Object.Instantiate<GameObject>(this.MangaModels[i], new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z - 1f), Quaternion.identity);
			}
			else
			{
				this.NewManga = UnityEngine.Object.Instantiate<GameObject>(this.MysteryManga, new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z - 1f), Quaternion.identity);
			}
			this.NewManga.transform.parent = this.MangaParent;
			this.NewManga.GetComponent<HomeMangaBookScript>().Manga = this;
			this.NewManga.GetComponent<HomeMangaBookScript>().ID = i;
			this.NewManga.transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
			this.MangaParent.transform.localEulerAngles = new Vector3(this.MangaParent.transform.localEulerAngles.x, this.MangaParent.transform.localEulerAngles.y + 360f / (float)this.TotalManga, this.MangaParent.transform.localEulerAngles.z);
			this.MangaList[i] = this.NewManga;
		}
		this.MangaParent.transform.localEulerAngles = new Vector3(this.MangaParent.transform.localEulerAngles.x, 0f, this.MangaParent.transform.localEulerAngles.z);
		this.MangaParent.transform.localPosition = new Vector3(this.MangaParent.transform.localPosition.x, this.MangaParent.transform.localPosition.y, 1.8f);
		this.MangaParent.transform.localScale = Vector3.zero;
		this.MangaParent.gameObject.SetActive(false);
		if (GameGlobals.Eighties)
		{
			this.MangaNames[0] = "Enchanting Petals Volume 1";
			this.MangaNames[1] = "Enchanting Petals Volume 2";
			this.MangaNames[2] = "Enchanting Petals Volume 3";
			this.MangaNames[3] = "Enchanting Petals Volume 4";
			this.MangaNames[4] = "Enchanting Petals Volume 5";
			this.MangaNames[5] = "Ahmya Volume 1";
			this.MangaNames[6] = "Ahmya Volume 2";
			this.MangaNames[7] = "Ahmya Volume 3";
			this.MangaNames[8] = "Ahmya Volume 4";
			this.MangaNames[9] = "Ahmya Volume 5";
			this.MangaDescs[0] = "The long-lasting bonds of Hurrem continuously bloom throughout the seasons.";
			this.MangaDescs[1] = "The pure and noble heart of Juliet. Won't you whisper sweet nothings before drinking the wine?";
			this.MangaDescs[2] = "The fireflies bring forth the sweet Japanese summer, where a maiden waits by the riverside.";
			this.MangaDescs[3] = "The luxuries of the French court shall test her chastity. Will distance from one's love bring forth temptation?";
			this.MangaDescs[4] = "The midsummer garden envokes blissful sincerity. She dances the night away.";
			this.MangaDescs[5] = "A beautiful girl transfers into the local high school, bringing an alluring aroma that seems too sweet.";
			this.MangaDescs[6] = "A rumor has begun to spread. It seems that venomous jealousy has pierced the hearts of girls at school.";
			this.MangaDescs[7] = "A young man begins investigating the mysterious disappearances that are plaguing his small town.";
			this.MangaDescs[8] = "A large number of men have gone missing. Claw marks are found. A young man suspects the kiss of death.";
			this.MangaDescs[9] = "A dark secret is unveiled. But, will the one who uncovered it live long enough to spread the truth?";
		}
		this.UpdateMangaLabels();
	}

	// Token: 0x0600187B RID: 6267 RVA: 0x000EEF9C File Offset: 0x000ED19C
	private void Update()
	{
		if (this.HomeWindow.Show)
		{
			if (!this.AreYouSure.activeInHierarchy)
			{
				this.MangaParent.localScale = Vector3.Lerp(this.MangaParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.MangaParent.gameObject.SetActive(true);
				if (this.InputManager.TappedRight)
				{
					this.DestinationReached = false;
					this.TargetRotation += 360f / (float)this.TotalManga;
					this.Selected++;
					if (this.Selected > this.TotalManga - 1)
					{
						this.Selected = 0;
					}
					this.UpdateMangaLabels();
					this.UpdateCurrentLabel();
				}
				if (this.InputManager.TappedLeft)
				{
					this.DestinationReached = false;
					this.TargetRotation -= 360f / (float)this.TotalManga;
					this.Selected--;
					if (this.Selected < 0)
					{
						this.Selected = this.TotalManga - 1;
					}
					this.UpdateMangaLabels();
					this.UpdateCurrentLabel();
				}
				this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * 10f);
				this.MangaParent.localEulerAngles = new Vector3(this.MangaParent.localEulerAngles.x, this.Rotation, this.MangaParent.localEulerAngles.z);
				if (Input.GetButtonDown("A") && this.ReadButtonGroup.activeInHierarchy)
				{
					this.MangaGroup.SetActive(false);
					this.AreYouSure.SetActive(true);
				}
				if (Input.GetButtonDown("B"))
				{
					this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
					this.HomeCamera.Target = this.HomeCamera.Targets[0];
					this.HomeYandere.CanMove = true;
					this.HomeWindow.Show = false;
				}
				if (Input.GetKeyDown(KeyCode.Space))
				{
					for (int i = 0; i < this.TotalManga; i++)
					{
						CollectibleGlobals.SetMangaCollected(i + 1, true);
					}
					return;
				}
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					if (this.Selected < 5)
					{
						PlayerGlobals.Seduction++;
					}
					else if (this.Selected < 10)
					{
						PlayerGlobals.Numbness++;
					}
					else
					{
						PlayerGlobals.Enlightenment++;
					}
					this.AreYouSure.SetActive(false);
					this.Darkness.FadeOut = true;
				}
				if (Input.GetButtonDown("B"))
				{
					this.MangaGroup.SetActive(true);
					this.AreYouSure.SetActive(false);
					return;
				}
			}
		}
		else
		{
			this.MangaParent.localScale = Vector3.Lerp(this.MangaParent.localScale, Vector3.zero, Time.deltaTime * 10f);
			if (this.MangaParent.localScale.x < 0.01f)
			{
				this.MangaParent.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x0600187C RID: 6268 RVA: 0x000EF2B0 File Offset: 0x000ED4B0
	private void UpdateMangaLabels()
	{
		if (this.Selected < 5)
		{
			this.ReadButtonGroup.SetActive(PlayerGlobals.Seduction == this.Selected);
			if (CollectibleGlobals.GetMangaCollected(this.Selected + 1))
			{
				if (PlayerGlobals.Seduction > this.Selected)
				{
					this.RequiredLabel.text = "You have already read this manga.";
				}
				else
				{
					this.RequiredLabel.text = "Required Seduction Level: " + this.Selected.ToString();
				}
			}
			else
			{
				this.RequiredLabel.text = "You have not yet collected this manga.";
				this.ReadButtonGroup.SetActive(false);
			}
		}
		else if (this.Selected < 10)
		{
			this.ReadButtonGroup.SetActive(PlayerGlobals.Numbness == this.Selected - 5);
			if (CollectibleGlobals.GetMangaCollected(this.Selected + 1))
			{
				if (PlayerGlobals.Numbness > this.Selected - 5)
				{
					this.RequiredLabel.text = "You have already read this manga.";
				}
				else
				{
					this.RequiredLabel.text = "Required Numbness Level: " + (this.Selected - 5).ToString();
				}
			}
			else
			{
				this.RequiredLabel.text = "You have not yet collected this manga.";
				this.ReadButtonGroup.SetActive(false);
			}
		}
		else
		{
			this.ReadButtonGroup.SetActive(PlayerGlobals.Enlightenment == this.Selected - 10);
			if (CollectibleGlobals.GetMangaCollected(this.Selected + 1))
			{
				if (PlayerGlobals.Enlightenment > this.Selected - 10)
				{
					this.RequiredLabel.text = "You have already read this manga.";
				}
				else
				{
					this.RequiredLabel.text = "Required Enlightenment Level: " + (this.Selected - 10).ToString();
				}
			}
			else
			{
				this.RequiredLabel.text = "You have not yet collected this manga.";
				this.ReadButtonGroup.SetActive(false);
			}
		}
		if (CollectibleGlobals.GetMangaCollected(this.Selected + 1))
		{
			this.MangaNameLabel.text = this.MangaNames[this.Selected];
			this.MangaDescLabel.text = this.MangaDescs[this.Selected];
			this.MangaBuffLabel.text = this.MangaBuffs[this.Selected];
			return;
		}
		this.MangaNameLabel.text = "?????";
		this.MangaDescLabel.text = "?????";
		this.MangaBuffLabel.text = "?????";
	}

	// Token: 0x0600187D RID: 6269 RVA: 0x000EF518 File Offset: 0x000ED718
	private void UpdateCurrentLabel()
	{
		if (this.Selected < 5)
		{
			this.Title = HomeMangaScript.SeductionStrings[PlayerGlobals.Seduction];
			this.CurrentLabel.text = string.Concat(new string[]
			{
				"Current Seduction Level: ",
				PlayerGlobals.Seduction.ToString(),
				" (",
				this.Title,
				")"
			});
		}
		else if (this.Selected < 10)
		{
			this.Title = HomeMangaScript.NumbnessStrings[PlayerGlobals.Numbness];
			this.CurrentLabel.text = string.Concat(new string[]
			{
				"Current Numbness Level: ",
				PlayerGlobals.Numbness.ToString(),
				" (",
				this.Title,
				")"
			});
		}
		else
		{
			this.Title = HomeMangaScript.EnlightenmentStrings[PlayerGlobals.Enlightenment];
			this.CurrentLabel.text = string.Concat(new string[]
			{
				"Current Enlightenment Level: ",
				PlayerGlobals.Enlightenment.ToString(),
				" (",
				this.Title,
				")"
			});
		}
		AudioSource.PlayClipAtPoint(this.ChangeSelection, base.transform.position);
	}

	// Token: 0x040024B9 RID: 9401
	private static readonly string[] SeductionStrings = new string[]
	{
		"Innocent",
		"Flirty",
		"Charming",
		"Sensual",
		"Seductive",
		"Succubus"
	};

	// Token: 0x040024BA RID: 9402
	private static readonly string[] NumbnessStrings = new string[]
	{
		"Stoic",
		"Somber",
		"Detached",
		"Unemotional",
		"Desensitized",
		"Dead Inside"
	};

	// Token: 0x040024BB RID: 9403
	private static readonly string[] EnlightenmentStrings = new string[]
	{
		"Asleep",
		"Awoken",
		"Mindful",
		"Informed",
		"Eyes Open",
		"Omniscient"
	};

	// Token: 0x040024BC RID: 9404
	public InputManagerScript InputManager;

	// Token: 0x040024BD RID: 9405
	public HomeYandereScript HomeYandere;

	// Token: 0x040024BE RID: 9406
	public HomeCameraScript HomeCamera;

	// Token: 0x040024BF RID: 9407
	public HomeWindowScript HomeWindow;

	// Token: 0x040024C0 RID: 9408
	public HomeDarknessScript Darkness;

	// Token: 0x040024C1 RID: 9409
	private GameObject NewManga;

	// Token: 0x040024C2 RID: 9410
	public GameObject ReadButtonGroup;

	// Token: 0x040024C3 RID: 9411
	public GameObject MysteryManga;

	// Token: 0x040024C4 RID: 9412
	public GameObject AreYouSure;

	// Token: 0x040024C5 RID: 9413
	public GameObject MangaGroup;

	// Token: 0x040024C6 RID: 9414
	public GameObject[] MangaList;

	// Token: 0x040024C7 RID: 9415
	public UILabel MangaNameLabel;

	// Token: 0x040024C8 RID: 9416
	public UILabel MangaDescLabel;

	// Token: 0x040024C9 RID: 9417
	public UILabel MangaBuffLabel;

	// Token: 0x040024CA RID: 9418
	public UILabel RequiredLabel;

	// Token: 0x040024CB RID: 9419
	public UILabel CurrentLabel;

	// Token: 0x040024CC RID: 9420
	public UILabel ButtonLabel;

	// Token: 0x040024CD RID: 9421
	public Transform MangaParent;

	// Token: 0x040024CE RID: 9422
	public bool DestinationReached;

	// Token: 0x040024CF RID: 9423
	public float TargetRotation;

	// Token: 0x040024D0 RID: 9424
	public float Rotation;

	// Token: 0x040024D1 RID: 9425
	public int TotalManga;

	// Token: 0x040024D2 RID: 9426
	public int Selected;

	// Token: 0x040024D3 RID: 9427
	public string Title = string.Empty;

	// Token: 0x040024D4 RID: 9428
	public GameObject[] MangaModels;

	// Token: 0x040024D5 RID: 9429
	public string[] MangaNames;

	// Token: 0x040024D6 RID: 9430
	public string[] MangaDescs;

	// Token: 0x040024D7 RID: 9431
	public string[] MangaBuffs;

	// Token: 0x040024D8 RID: 9432
	public AudioClip ChangeSelection;
}
