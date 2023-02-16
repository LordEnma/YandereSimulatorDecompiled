using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeWindowScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public DialogueWheelScript DialogueWheel;

	public InputManagerScript InputManager;

	public StudentScript SparringPartner;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public WeaponScript Baton;

	public Texture[] DelinquentDificultyIcons;

	public Texture[] AlbumCovers;

	public Transform[] KneelSpot;

	public Transform[] SparSpot;

	public string[] Difficulties;

	public UITexture[] Texture;

	public UILabel[] Label;

	public Transform Highlight;

	public GameObject Window;

	public UISprite Darkness;

	public int Selected;

	public int ClubID;

	public int ID = 1;

	public ClubType Club;

	public bool PlayedRhythmMinigame;

	public bool DefeatedSho;

	public bool ButtonUp;

	public bool FadeOut;

	public bool FadeIn;

	public float Timer;

	private void Start()
	{
		Window.SetActive(value: false);
	}

	private void Update()
	{
		if (Window.activeInHierarchy)
		{
			if (InputManager.TappedUp)
			{
				Selected--;
				UpdateHighlight();
			}
			else if (InputManager.TappedDown)
			{
				Selected++;
				UpdateHighlight();
			}
			if (ButtonUp)
			{
				if (Input.GetButtonDown("A"))
				{
					UpdateWindow();
					if (Texture[Selected].color.r == 1f)
					{
						Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
						Yandere.TargetStudent.TalkTimer = 100f;
						Yandere.TargetStudent.ClubPhase = 2;
						if (Club == ClubType.MartialArts)
						{
							StudentManager.Students[ClubID - Selected].Distracted = true;
						}
						PromptBar.ClearButtons();
						PromptBar.Show = false;
						Window.SetActive(value: false);
						ButtonUp = false;
						Time.timeScale = 1f;
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
					Yandere.TargetStudent.TalkTimer = 100f;
					Yandere.TargetStudent.ClubPhase = 3;
					PromptBar.ClearButtons();
					PromptBar.Show = false;
					Window.SetActive(value: false);
					ButtonUp = false;
					Time.timeScale = 1f;
				}
			}
			else if (Input.GetButtonUp("A"))
			{
				ButtonUp = true;
			}
		}
		if (FadeOut)
		{
			Darkness.enabled = true;
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			if (Darkness.color.a > 0.99f)
			{
				Darkness.color = new Color(0f, 0f, 0f, 1f);
				if (DialogueWheel.ClubLeader)
				{
					DialogueWheel.End();
				}
				if (Club == ClubType.LightMusic)
				{
					if (!PlayedRhythmMinigame)
					{
						for (int i = 52; i < 56; i++)
						{
							StudentManager.Students[i].transform.position = StudentManager.Clubs.List[i].position;
							StudentManager.Students[i].EmptyHands();
						}
						Physics.SyncTransforms();
						PlayerPrefs.SetFloat("TempReputation", StudentManager.Reputation.Reputation);
						PlayedRhythmMinigame = true;
						FadeOut = false;
						FadeIn = true;
						SceneManager.LoadScene("RhythmMinigameScene", LoadSceneMode.Additive);
						GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
						for (int j = 0; j < rootGameObjects.Length; j++)
						{
							rootGameObjects[j].SetActive(value: false);
						}
					}
				}
				else if (Club == ClubType.MartialArts)
				{
					if (Yandere.CanMove)
					{
						StudentManager.CombatMinigame.Practice = true;
						StudentManager.Students[46].CharacterAnimation.CrossFade(StudentManager.Students[46].IdleAnim);
						StudentManager.Students[46].transform.eulerAngles = new Vector3(0f, 0f, 0f);
						StudentManager.Students[46].transform.position = KneelSpot[0].position;
						StudentManager.Students[46].Pathfinding.canSearch = false;
						StudentManager.Students[46].Pathfinding.canMove = false;
						StudentManager.Students[46].Distracted = true;
						StudentManager.Students[46].enabled = false;
						StudentManager.Students[46].Routine = false;
						StudentManager.Students[46].Hearts.Stop();
						for (int k = 1; k < 5; k++)
						{
							if (StudentManager.Students[46 + k] != null && StudentManager.Students[46 + k].Alive && StudentManager.Students[46 + k].Routine && StudentManager.Students[46 + k].Alive && StudentManager.Students[46 + k].ClubAttire)
							{
								StudentManager.Students[46 + k].transform.position = KneelSpot[k].position;
								StudentManager.Students[46 + k].transform.eulerAngles = KneelSpot[k].eulerAngles;
								StudentManager.Students[46 + k].Pathfinding.canSearch = false;
								StudentManager.Students[46 + k].Pathfinding.canMove = false;
								StudentManager.Students[46 + k].Distracted = true;
								StudentManager.Students[46 + k].enabled = false;
								StudentManager.Students[46 + k].Routine = false;
								if (StudentManager.Students[46 + k].Male)
								{
									StudentManager.Students[46 + k].CharacterAnimation.CrossFade("sit_04");
								}
								else
								{
									StudentManager.Students[46 + k].CharacterAnimation.CrossFade("f02_sit_05");
								}
							}
						}
						Yandere.transform.eulerAngles = SparSpot[1].eulerAngles;
						Yandere.transform.position = SparSpot[1].position;
						Yandere.CanMove = false;
						SparringPartner = StudentManager.Students[ClubID - Selected];
						SparringPartner.CharacterAnimation.CrossFade(SparringPartner.IdleAnim);
						SparringPartner.transform.eulerAngles = SparSpot[2].eulerAngles;
						SparringPartner.transform.position = SparSpot[2].position;
						SparringPartner.MyWeapon = Baton;
						SparringPartner.MyWeapon.transform.parent = SparringPartner.WeaponBagParent;
						SparringPartner.MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						SparringPartner.MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
						SparringPartner.MyWeapon.GetComponent<Rigidbody>().useGravity = false;
						SparringPartner.MyWeapon.FingerprintID = SparringPartner.StudentID;
						SparringPartner.MyWeapon.MyCollider.enabled = false;
						Physics.SyncTransforms();
						FadeOut = false;
						FadeIn = true;
					}
				}
				else if (Club == ClubType.Delinquent)
				{
					GameGlobals.BeatEmUpDifficulty = Selected;
					FadeOut = false;
					FadeIn = true;
					SceneManager.LoadScene("BeatEmUpScene", LoadSceneMode.Additive);
					GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
					for (int j = 0; j < rootGameObjects.Length; j++)
					{
						rootGameObjects[j].SetActive(value: false);
					}
				}
			}
		}
		if (!FadeIn)
		{
			return;
		}
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
		if (!(Darkness.color.a < 0.01f))
		{
			return;
		}
		Darkness.color = new Color(0f, 0f, 0f, 0f);
		if (Club == ClubType.LightMusic)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				Yandere.PauseScreen.NewSettings.QualityManager.UpdateFPSIndex();
				Yandere.SetAnimationLayers();
				StudentManager.UpdateAllAnimLayers();
				StudentManager.Reputation.PendingRep += PlayerPrefs.GetFloat("TempReputation");
				PlayerPrefs.SetFloat("TempReputation", 0f);
				FadeIn = false;
				Timer = 0f;
				Debug.Log("Regenerating pathfinding grid.");
				AstarPath.active.Scan();
				if (StudentManager.Clock.HourTime < 7.9f && StudentManager.Students[7] != null)
				{
					StudentManager.Students[7].gameObject.SetActive(value: false);
				}
			}
		}
		else if (Club == ClubType.MartialArts)
		{
			SparringPartner.Pathfinding.canSearch = false;
			SparringPartner.Pathfinding.canMove = false;
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				if (Selected == 1)
				{
					StudentManager.CombatMinigame.Difficulty = 0.5f;
				}
				else if (Selected == 2)
				{
					StudentManager.CombatMinigame.Difficulty = 0.75f;
				}
				else if (Selected == 3)
				{
					StudentManager.CombatMinigame.Difficulty = 1f;
				}
				else if (Selected == 4)
				{
					StudentManager.CombatMinigame.Difficulty = 1.5f;
				}
				else if (Selected == 5)
				{
					StudentManager.CombatMinigame.Difficulty = 2f;
				}
				StudentManager.Students[ClubID - Selected].Threatened = true;
				StudentManager.Students[ClubID - Selected].Alarmed = true;
				StudentManager.Students[ClubID - Selected].enabled = true;
				FadeIn = false;
				Timer = 0f;
			}
		}
		else
		{
			if (Club != ClubType.Delinquent)
			{
				return;
			}
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				Debug.Log("We just returned from the delinquent minigame.");
				Yandere.SetAnimationLayers();
				StudentManager.UpdateAllAnimLayers();
				FadeIn = false;
				Timer = 0f;
				DialogueWheel.RestoreMusic();
				if (StudentManager.Clock.HourTime < 7.9f && StudentManager.Students[7] != null)
				{
					StudentManager.Students[7].gameObject.SetActive(value: false);
				}
			}
		}
	}

	public void Finish()
	{
		for (int i = 1; i < 6; i++)
		{
			if (StudentManager.Students[45 + i] != null && StudentManager.Students[45 + i].Alive)
			{
				StudentManager.Students[45 + i].Pathfinding.canSearch = true;
				StudentManager.Students[45 + i].Pathfinding.canMove = true;
				StudentManager.Students[45 + i].Distracted = false;
				StudentManager.Students[45 + i].enabled = true;
				StudentManager.Students[45 + i].Routine = true;
			}
		}
		Yandere.StudentManager.QualityManager.UpdateFPSIndex();
	}

	public void UpdateWindow()
	{
		PromptBar.ClearButtons();
		PromptBar.Label[0].text = "Confirm";
		PromptBar.Label[1].text = "Back";
		PromptBar.Label[4].text = "Choose";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		if (Club == ClubType.LightMusic)
		{
			Texture[1].mainTexture = AlbumCovers[1];
			Texture[2].mainTexture = AlbumCovers[2];
			Texture[3].mainTexture = AlbumCovers[3];
			Texture[4].mainTexture = AlbumCovers[4];
			Texture[5].mainTexture = AlbumCovers[5];
			Label[1].text = "Panther\n" + Difficulties[1];
			Label[2].text = "?????\n" + Difficulties[2];
			Label[3].text = "?????\n" + Difficulties[3];
			Label[4].text = "?????\n" + Difficulties[4];
			Label[5].text = "?????\n" + Difficulties[5];
			Texture[2].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			Texture[3].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			Texture[4].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			Texture[5].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			Label[2].color = new Color(0f, 0f, 0f, 0.5f);
			Label[3].color = new Color(0f, 0f, 0f, 0.5f);
			Label[4].color = new Color(0f, 0f, 0f, 0.5f);
			Label[5].color = new Color(0f, 0f, 0f, 0.5f);
		}
		else if (Club == ClubType.MartialArts)
		{
			string text = "";
			if (GameGlobals.Eighties)
			{
				text = "1989";
			}
			ClubID = 51;
			for (ID = 1; ID < 6; ID++)
			{
				WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + text + "/Student_" + (ClubID - ID) + ".png");
				Texture[ID].mainTexture = wWW.texture;
				Label[ID].text = StudentManager.JSON.Students[ClubID - ID].Name + "\n" + Difficulties[ID];
				if (StudentManager.Students[ClubID - ID] != null)
				{
					if (!StudentManager.Students[ClubID - ID].Routine || !StudentManager.Students[ClubID - ID].ClubAttire)
					{
						Debug.Log("Student #" + (ClubID - ID) + " is not doing their routine or not in their club attire.");
						Texture[ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
						Label[ID].color = new Color(0f, 0f, 0f, 0.5f);
					}
					else
					{
						Texture[ID].color = new Color(1f, 1f, 1f, 1f);
						Label[ID].color = new Color(0f, 0f, 0f, 1f);
					}
				}
				else
				{
					Texture[ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
					Label[ID].color = new Color(0f, 0f, 0f, 0.5f);
				}
			}
			Texture[5].color = new Color(1f, 1f, 1f, 1f);
			Label[5].color = new Color(0f, 0f, 0f, 1f);
		}
		else if (Club == ClubType.Delinquent)
		{
			Texture[1].mainTexture = DelinquentDificultyIcons[1];
			Texture[2].mainTexture = DelinquentDificultyIcons[2];
			Texture[3].mainTexture = DelinquentDificultyIcons[3];
			Texture[4].mainTexture = DelinquentDificultyIcons[4];
			Texture[5].mainTexture = DelinquentDificultyIcons[5];
			Label[1].text = Difficulties[1] ?? "";
			Label[2].text = Difficulties[2] ?? "";
			Label[3].text = Difficulties[3] ?? "";
			Label[4].text = Difficulties[4] ?? "";
			Label[5].text = Difficulties[5] ?? "";
		}
		Window.SetActive(value: true);
		UpdateHighlight();
		Time.timeScale = 0.0001f;
	}

	public void UpdateHighlight()
	{
		if (Selected < 1)
		{
			Selected = 5;
		}
		else if (Selected > 5)
		{
			Selected = 1;
		}
		Highlight.localPosition = new Vector3(0f, 660 - 220 * Selected, 0f);
	}
}
