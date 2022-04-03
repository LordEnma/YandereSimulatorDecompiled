using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003BE RID: 958
public class PracticeWindowScript : MonoBehaviour
{
	// Token: 0x06001B11 RID: 6929 RVA: 0x0012C472 File Offset: 0x0012A672
	private void Start()
	{
		this.Window.SetActive(false);
	}

	// Token: 0x06001B12 RID: 6930 RVA: 0x0012C480 File Offset: 0x0012A680
	private void Update()
	{
		if (this.Window.activeInHierarchy)
		{
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedDown)
			{
				this.Selected++;
				this.UpdateHighlight();
			}
			if (this.ButtonUp)
			{
				if (Input.GetButtonDown("A"))
				{
					this.UpdateWindow();
					if (this.Texture[this.Selected].color.r == 1f)
					{
						this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
						this.Yandere.TargetStudent.TalkTimer = 100f;
						this.Yandere.TargetStudent.ClubPhase = 2;
						if (this.Club == ClubType.MartialArts)
						{
							this.StudentManager.Students[this.ClubID - this.Selected].Distracted = true;
						}
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
						this.Window.SetActive(false);
						this.ButtonUp = false;
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
					this.Yandere.TargetStudent.TalkTimer = 100f;
					this.Yandere.TargetStudent.ClubPhase = 3;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Window.SetActive(false);
					this.ButtonUp = false;
				}
			}
			else if (Input.GetButtonUp("A"))
			{
				this.ButtonUp = true;
			}
		}
		if (this.FadeOut)
		{
			this.Darkness.enabled = true;
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f)
			{
				if (this.DialogueWheel.ClubLeader)
				{
					this.DialogueWheel.End();
				}
				if (this.Club == ClubType.LightMusic)
				{
					if (!this.PlayedRhythmMinigame)
					{
						for (int i = 52; i < 56; i++)
						{
							this.StudentManager.Students[i].transform.position = this.StudentManager.Clubs.List[i].position;
							this.StudentManager.Students[i].EmptyHands();
						}
						Physics.SyncTransforms();
						PlayerPrefs.SetFloat("TempReputation", this.StudentManager.Reputation.Reputation);
						this.PlayedRhythmMinigame = true;
						this.FadeOut = false;
						this.FadeIn = true;
						SceneManager.LoadScene("RhythmMinigameScene", LoadSceneMode.Additive);
						GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
						for (int j = 0; j < rootGameObjects.Length; j++)
						{
							rootGameObjects[j].SetActive(false);
						}
					}
				}
				else if (this.Club == ClubType.MartialArts)
				{
					if (this.Yandere.CanMove)
					{
						this.StudentManager.CombatMinigame.Practice = true;
						this.StudentManager.Students[46].CharacterAnimation.CrossFade(this.StudentManager.Students[46].IdleAnim);
						this.StudentManager.Students[46].transform.eulerAngles = new Vector3(0f, 0f, 0f);
						this.StudentManager.Students[46].transform.position = this.KneelSpot[0].position;
						this.StudentManager.Students[46].Pathfinding.canSearch = false;
						this.StudentManager.Students[46].Pathfinding.canMove = false;
						this.StudentManager.Students[46].Distracted = true;
						this.StudentManager.Students[46].enabled = false;
						this.StudentManager.Students[46].Routine = false;
						this.StudentManager.Students[46].Hearts.Stop();
						for (int k = 1; k < 5; k++)
						{
							if (this.StudentManager.Students[46 + k] != null && this.StudentManager.Students[46 + k].Alive && this.StudentManager.Students[46 + k].Routine && this.StudentManager.Students[46 + k].Alive && this.StudentManager.Students[46 + k].ClubAttire)
							{
								this.StudentManager.Students[46 + k].transform.position = this.KneelSpot[k].position;
								this.StudentManager.Students[46 + k].transform.eulerAngles = this.KneelSpot[k].eulerAngles;
								this.StudentManager.Students[46 + k].Pathfinding.canSearch = false;
								this.StudentManager.Students[46 + k].Pathfinding.canMove = false;
								this.StudentManager.Students[46 + k].Distracted = true;
								this.StudentManager.Students[46 + k].enabled = false;
								this.StudentManager.Students[46 + k].Routine = false;
								if (this.StudentManager.Students[46 + k].Male)
								{
									this.StudentManager.Students[46 + k].CharacterAnimation.CrossFade("sit_04");
								}
								else
								{
									this.StudentManager.Students[46 + k].CharacterAnimation.CrossFade("f02_sit_05");
								}
							}
						}
						this.Yandere.transform.eulerAngles = this.SparSpot[1].eulerAngles;
						this.Yandere.transform.position = this.SparSpot[1].position;
						this.Yandere.CanMove = false;
						this.SparringPartner = this.StudentManager.Students[this.ClubID - this.Selected];
						this.SparringPartner.CharacterAnimation.CrossFade(this.SparringPartner.IdleAnim);
						this.SparringPartner.transform.eulerAngles = this.SparSpot[2].eulerAngles;
						this.SparringPartner.transform.position = this.SparSpot[2].position;
						this.SparringPartner.MyWeapon = this.Baton;
						this.SparringPartner.MyWeapon.transform.parent = this.SparringPartner.WeaponBagParent;
						this.SparringPartner.MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						this.SparringPartner.MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
						this.SparringPartner.MyWeapon.GetComponent<Rigidbody>().useGravity = false;
						this.SparringPartner.MyWeapon.FingerprintID = this.SparringPartner.StudentID;
						this.SparringPartner.MyWeapon.MyCollider.enabled = false;
						Physics.SyncTransforms();
						this.FadeOut = false;
						this.FadeIn = true;
					}
				}
				else if (this.Club == ClubType.Delinquent)
				{
					GameGlobals.BeatEmUpDifficulty = this.Selected;
					this.FadeOut = false;
					this.FadeIn = true;
					SceneManager.LoadScene("BeatEmUpScene", LoadSceneMode.Additive);
					GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
					for (int j = 0; j < rootGameObjects.Length; j++)
					{
						rootGameObjects[j].SetActive(false);
					}
				}
			}
		}
		if (this.FadeIn)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			if (this.Darkness.color.a == 0f)
			{
				if (this.Club == ClubType.LightMusic)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						this.Yandere.SetAnimationLayers();
						this.StudentManager.UpdateAllAnimLayers();
						this.StudentManager.Reputation.PendingRep += PlayerPrefs.GetFloat("TempReputation");
						PlayerPrefs.SetFloat("TempReputation", 0f);
						this.FadeIn = false;
						this.Timer = 0f;
						return;
					}
				}
				else if (this.Club == ClubType.MartialArts)
				{
					this.SparringPartner.Pathfinding.canSearch = false;
					this.SparringPartner.Pathfinding.canMove = false;
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						if (this.Selected == 1)
						{
							this.StudentManager.CombatMinigame.Difficulty = 0.5f;
						}
						else if (this.Selected == 2)
						{
							this.StudentManager.CombatMinigame.Difficulty = 0.75f;
						}
						else if (this.Selected == 3)
						{
							this.StudentManager.CombatMinigame.Difficulty = 1f;
						}
						else if (this.Selected == 4)
						{
							this.StudentManager.CombatMinigame.Difficulty = 1.5f;
						}
						else if (this.Selected == 5)
						{
							this.StudentManager.CombatMinigame.Difficulty = 2f;
						}
						this.StudentManager.Students[this.ClubID - this.Selected].Threatened = true;
						this.StudentManager.Students[this.ClubID - this.Selected].Alarmed = true;
						this.StudentManager.Students[this.ClubID - this.Selected].enabled = true;
						this.FadeIn = false;
						this.Timer = 0f;
						return;
					}
				}
				else if (this.Club == ClubType.Delinquent)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						Debug.Log("We just returned from the delinquent minigame.");
						this.Yandere.SetAnimationLayers();
						this.StudentManager.UpdateAllAnimLayers();
						this.FadeIn = false;
						this.Timer = 0f;
					}
				}
			}
		}
	}

	// Token: 0x06001B13 RID: 6931 RVA: 0x0012CF50 File Offset: 0x0012B150
	public void Finish()
	{
		if (this.Selected == 4)
		{
			this.DefeatedSho = true;
			this.StudentManager.TaskManager.UpdateTaskStatus();
		}
		for (int i = 1; i < 6; i++)
		{
			if (this.StudentManager.Students[45 + i] != null)
			{
				this.StudentManager.Students[45 + i].Pathfinding.canSearch = true;
				this.StudentManager.Students[45 + i].Pathfinding.canMove = true;
				this.StudentManager.Students[45 + i].Distracted = false;
				this.StudentManager.Students[45 + i].enabled = true;
				this.StudentManager.Students[45 + i].Routine = true;
			}
		}
	}

	// Token: 0x06001B14 RID: 6932 RVA: 0x0012D020 File Offset: 0x0012B220
	public void UpdateWindow()
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[0].text = "Confirm";
		this.PromptBar.Label[1].text = "Back";
		this.PromptBar.Label[4].text = "Choose";
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
		if (this.Club == ClubType.LightMusic)
		{
			this.Texture[1].mainTexture = this.AlbumCovers[1];
			this.Texture[2].mainTexture = this.AlbumCovers[2];
			this.Texture[3].mainTexture = this.AlbumCovers[3];
			this.Texture[4].mainTexture = this.AlbumCovers[4];
			this.Texture[5].mainTexture = this.AlbumCovers[5];
			this.Label[1].text = "Panther\n" + this.Difficulties[1];
			this.Label[2].text = "?????\n" + this.Difficulties[2];
			this.Label[3].text = "?????\n" + this.Difficulties[3];
			this.Label[4].text = "?????\n" + this.Difficulties[4];
			this.Label[5].text = "?????\n" + this.Difficulties[5];
			this.Texture[2].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			this.Texture[3].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			this.Texture[4].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			this.Texture[5].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			this.Label[2].color = new Color(0f, 0f, 0f, 0.5f);
			this.Label[3].color = new Color(0f, 0f, 0f, 0.5f);
			this.Label[4].color = new Color(0f, 0f, 0f, 0.5f);
			this.Label[5].color = new Color(0f, 0f, 0f, 0.5f);
		}
		else if (this.Club == ClubType.MartialArts)
		{
			string text = "";
			if (GameGlobals.Eighties)
			{
				text = "1989";
			}
			this.ClubID = 51;
			this.ID = 1;
			while (this.ID < 6)
			{
				WWW www = new WWW(string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Portraits",
					text,
					"/Student_",
					(this.ClubID - this.ID).ToString(),
					".png"
				}));
				this.Texture[this.ID].mainTexture = www.texture;
				this.Label[this.ID].text = this.StudentManager.JSON.Students[this.ClubID - this.ID].Name + "\n" + this.Difficulties[this.ID];
				if (this.StudentManager.Students[this.ClubID - this.ID] != null)
				{
					if (!this.StudentManager.Students[this.ClubID - this.ID].Routine || !this.StudentManager.Students[this.ClubID - this.ID].ClubAttire)
					{
						Debug.Log("Student #" + (this.ClubID - this.ID).ToString() + " is not doing their routine or not in their club attire.");
						this.Texture[this.ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
						this.Label[this.ID].color = new Color(0f, 0f, 0f, 0.5f);
					}
					else
					{
						this.Texture[this.ID].color = new Color(1f, 1f, 1f, 1f);
						this.Label[this.ID].color = new Color(0f, 0f, 0f, 1f);
					}
				}
				else
				{
					this.Texture[this.ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
					this.Label[this.ID].color = new Color(0f, 0f, 0f, 0.5f);
				}
				this.ID++;
			}
			this.Texture[5].color = new Color(1f, 1f, 1f, 1f);
			this.Label[5].color = new Color(0f, 0f, 0f, 1f);
		}
		else if (this.Club == ClubType.Delinquent)
		{
			this.Texture[1].mainTexture = this.DelinquentDificultyIcons[1];
			this.Texture[2].mainTexture = this.DelinquentDificultyIcons[2];
			this.Texture[3].mainTexture = this.DelinquentDificultyIcons[3];
			this.Texture[4].mainTexture = this.DelinquentDificultyIcons[4];
			this.Texture[5].mainTexture = this.DelinquentDificultyIcons[5];
			this.Label[1].text = (this.Difficulties[1] ?? "");
			this.Label[2].text = (this.Difficulties[2] ?? "");
			this.Label[3].text = (this.Difficulties[3] ?? "");
			this.Label[4].text = (this.Difficulties[4] ?? "");
			this.Label[5].text = (this.Difficulties[5] ?? "");
		}
		this.Window.SetActive(true);
		this.UpdateHighlight();
	}

	// Token: 0x06001B15 RID: 6933 RVA: 0x0012D6E8 File Offset: 0x0012B8E8
	public void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 5;
		}
		else if (this.Selected > 5)
		{
			this.Selected = 1;
		}
		this.Highlight.localPosition = new Vector3(0f, (float)(660 - 220 * this.Selected), 0f);
	}

	// Token: 0x04002DE2 RID: 11746
	public StudentManagerScript StudentManager;

	// Token: 0x04002DE3 RID: 11747
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04002DE4 RID: 11748
	public InputManagerScript InputManager;

	// Token: 0x04002DE5 RID: 11749
	public StudentScript SparringPartner;

	// Token: 0x04002DE6 RID: 11750
	public PromptBarScript PromptBar;

	// Token: 0x04002DE7 RID: 11751
	public YandereScript Yandere;

	// Token: 0x04002DE8 RID: 11752
	public WeaponScript Baton;

	// Token: 0x04002DE9 RID: 11753
	public Texture[] DelinquentDificultyIcons;

	// Token: 0x04002DEA RID: 11754
	public Texture[] AlbumCovers;

	// Token: 0x04002DEB RID: 11755
	public Transform[] KneelSpot;

	// Token: 0x04002DEC RID: 11756
	public Transform[] SparSpot;

	// Token: 0x04002DED RID: 11757
	public string[] Difficulties;

	// Token: 0x04002DEE RID: 11758
	public UITexture[] Texture;

	// Token: 0x04002DEF RID: 11759
	public UILabel[] Label;

	// Token: 0x04002DF0 RID: 11760
	public Transform Highlight;

	// Token: 0x04002DF1 RID: 11761
	public GameObject Window;

	// Token: 0x04002DF2 RID: 11762
	public UISprite Darkness;

	// Token: 0x04002DF3 RID: 11763
	public int Selected;

	// Token: 0x04002DF4 RID: 11764
	public int ClubID;

	// Token: 0x04002DF5 RID: 11765
	public int ID = 1;

	// Token: 0x04002DF6 RID: 11766
	public ClubType Club;

	// Token: 0x04002DF7 RID: 11767
	public bool PlayedRhythmMinigame;

	// Token: 0x04002DF8 RID: 11768
	public bool DefeatedSho;

	// Token: 0x04002DF9 RID: 11769
	public bool ButtonUp;

	// Token: 0x04002DFA RID: 11770
	public bool FadeOut;

	// Token: 0x04002DFB RID: 11771
	public bool FadeIn;

	// Token: 0x04002DFC RID: 11772
	public float Timer;
}
