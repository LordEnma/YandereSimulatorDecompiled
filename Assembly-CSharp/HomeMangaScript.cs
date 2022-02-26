using System;
using UnityEngine;

// Token: 0x02000320 RID: 800
public class HomeMangaScript : MonoBehaviour
{
	// Token: 0x0600188C RID: 6284 RVA: 0x000EF830 File Offset: 0x000EDA30
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

	// Token: 0x0600188D RID: 6285 RVA: 0x000EFB9C File Offset: 0x000EDD9C
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

	// Token: 0x0600188E RID: 6286 RVA: 0x000EFEB0 File Offset: 0x000EE0B0
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

	// Token: 0x0600188F RID: 6287 RVA: 0x000F0118 File Offset: 0x000EE318
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

	// Token: 0x040024D2 RID: 9426
	private static readonly string[] SeductionStrings = new string[]
	{
		"Innocent",
		"Flirty",
		"Charming",
		"Sensual",
		"Seductive",
		"Succubus"
	};

	// Token: 0x040024D3 RID: 9427
	private static readonly string[] NumbnessStrings = new string[]
	{
		"Stoic",
		"Somber",
		"Detached",
		"Unemotional",
		"Desensitized",
		"Dead Inside"
	};

	// Token: 0x040024D4 RID: 9428
	private static readonly string[] EnlightenmentStrings = new string[]
	{
		"Asleep",
		"Awoken",
		"Mindful",
		"Informed",
		"Eyes Open",
		"Omniscient"
	};

	// Token: 0x040024D5 RID: 9429
	public InputManagerScript InputManager;

	// Token: 0x040024D6 RID: 9430
	public HomeYandereScript HomeYandere;

	// Token: 0x040024D7 RID: 9431
	public HomeCameraScript HomeCamera;

	// Token: 0x040024D8 RID: 9432
	public HomeWindowScript HomeWindow;

	// Token: 0x040024D9 RID: 9433
	public HomeDarknessScript Darkness;

	// Token: 0x040024DA RID: 9434
	private GameObject NewManga;

	// Token: 0x040024DB RID: 9435
	public GameObject ReadButtonGroup;

	// Token: 0x040024DC RID: 9436
	public GameObject MysteryManga;

	// Token: 0x040024DD RID: 9437
	public GameObject AreYouSure;

	// Token: 0x040024DE RID: 9438
	public GameObject MangaGroup;

	// Token: 0x040024DF RID: 9439
	public GameObject[] MangaList;

	// Token: 0x040024E0 RID: 9440
	public UILabel MangaNameLabel;

	// Token: 0x040024E1 RID: 9441
	public UILabel MangaDescLabel;

	// Token: 0x040024E2 RID: 9442
	public UILabel MangaBuffLabel;

	// Token: 0x040024E3 RID: 9443
	public UILabel RequiredLabel;

	// Token: 0x040024E4 RID: 9444
	public UILabel CurrentLabel;

	// Token: 0x040024E5 RID: 9445
	public UILabel ButtonLabel;

	// Token: 0x040024E6 RID: 9446
	public Transform MangaParent;

	// Token: 0x040024E7 RID: 9447
	public bool DestinationReached;

	// Token: 0x040024E8 RID: 9448
	public float TargetRotation;

	// Token: 0x040024E9 RID: 9449
	public float Rotation;

	// Token: 0x040024EA RID: 9450
	public int TotalManga;

	// Token: 0x040024EB RID: 9451
	public int Selected;

	// Token: 0x040024EC RID: 9452
	public string Title = string.Empty;

	// Token: 0x040024ED RID: 9453
	public GameObject[] MangaModels;

	// Token: 0x040024EE RID: 9454
	public string[] MangaNames;

	// Token: 0x040024EF RID: 9455
	public string[] MangaDescs;

	// Token: 0x040024F0 RID: 9456
	public string[] MangaBuffs;

	// Token: 0x040024F1 RID: 9457
	public AudioClip ChangeSelection;
}
