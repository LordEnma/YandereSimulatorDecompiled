using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartbrokenCursorScript : MonoBehaviour
{
	public SnappedYandereScript SnappedYandere;

	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public HeartbrokenScript Heartbroken;

	public VibrateScript[] Vibrations;

	public UISprite CursorSprite;

	public UISprite Darkness;

	public AudioClip SelectSound;

	public AudioClip MoveSound;

	public AudioSource MyAudio;

	public UILabel Continue;

	public UILabel MyLabel;

	public GameObject FPS;

	public bool LoveSick;

	public bool FadeOut;

	public bool Nudge;

	public int CracksSpawned;

	public int Selected = 1;

	public int Options = 5;

	public int LastRandomCrack;

	public int RandomCrack;

	public CameraFilterPack_Gradients_FireGradient HeartbrokenFilter;

	public CameraFilterPack_Gradients_FireGradient MainFilter;

	public Camera HeartbrokenCamera;

	public AudioSource GameOverMusic;

	public AudioSource SnapStatic;

	public AudioSource SnapMusic;

	public AudioClip GlassShatter;

	public AudioClip ReverseHit;

	public AudioClip[] CrackSound;

	public GameObject ShatterPrefab;

	public GameObject SNAPLetters;

	public GameObject SnapUICamera;

	public UIPanel SNAPPanel;

	public GameObject[] Background;

	public GameObject[] CrackMeshes;

	public GameObject[] Cracks;

	public AudioClip[] CracksTier1;

	public AudioClip[] CracksTier2;

	public AudioClip[] CracksTier3;

	public AudioClip[] CracksTier4;

	public Texture BlackTexture;

	public Transform SnapDestination;

	public Transform SnapFocus;

	public Transform SnapPOV;

	public bool BefriendBetrayMission;

	public bool SnapSequence;

	public bool ReloadScene;

	public bool NeverSnap;

	public float SnapTimer;

	public float Speed;

	public int TwitchID;

	private void Start()
	{
		Continue.color = new Color(Continue.color.r, Continue.color.g, Continue.color.b, 0f);
		if (StudentManager != null)
		{
			StudentManager.Yandere.Jukebox.gameObject.SetActive(value: false);
			if (StudentManager.Yandere.Weapon[1] != null && StudentManager.Yandere.Weapon[1].Type == WeaponType.Knife)
			{
				StudentManager.Yandere.Weapon[1].Drop();
			}
			if (StudentManager.Yandere.Weapon[2] != null && StudentManager.Yandere.Weapon[2].Type == WeaponType.Knife)
			{
				StudentManager.Yandere.Weapon[2].Drop();
			}
			StudentManager.Journalist.SetActive(value: false);
		}
		Debug.Log("Here, at the Heartbroken screen, GameGlobals.MostRecentSlot is: " + GameGlobals.MostRecentSlot);
	}

	private void Update()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 255f - (float)Selected * 50f, Time.deltaTime * 10f), base.transform.localPosition.z);
		if (Selected == 5)
		{
			GameOverMusic.volume = Mathf.MoveTowards(GameOverMusic.volume, 0f, Time.deltaTime * 0.5f);
		}
		else
		{
			GameOverMusic.volume = Mathf.MoveTowards(GameOverMusic.volume, 1f, Time.deltaTime * 0.5f);
		}
		if (!FadeOut)
		{
			if (MyLabel.color.a >= 1f)
			{
				if (InputManager.TappedDown)
				{
					Selected++;
					if (Selected > Options)
					{
						Selected = 1;
					}
					MyAudio.clip = MoveSound;
					MyAudio.Play();
				}
				if (InputManager.TappedUp)
				{
					Selected--;
					if (Selected < 1)
					{
						Selected = Options;
					}
					MyAudio.clip = MoveSound;
					MyAudio.Play();
				}
				Continue.color = new Color(Continue.color.r, Continue.color.g, Continue.color.b, (Selected != 5) ? 1f : 0f);
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					Nudge = true;
					if (Selected != 5)
					{
						MyAudio.clip = SelectSound;
						MyAudio.Play();
						if (Selected == 1 || (Selected == 2 && Heartbroken.Options[1].alpha == 1f) || (Selected == 3 && GameGlobals.MostRecentSlot > 0) || Selected == 4)
						{
							FadeOut = true;
						}
					}
					else
					{
						HeartbrokenCamera.nearClipPlane -= 0.1f;
						if (HeartbrokenCamera.nearClipPlane <= 0f)
						{
							HeartbrokenCamera.nearClipPlane = 0.01f;
						}
						StudentManager.Yandere.ShoulderCamera.enabled = false;
						if (CracksSpawned == 0)
						{
							GameObjectUtils.SetLayerRecursively(StudentManager.Yandere.gameObject, 5);
							Cracks[1].transform.parent.position = StudentManager.Yandere.Head.position;
							Cracks[1].transform.parent.position = Vector3.MoveTowards(Cracks[1].transform.parent.position, Heartbroken.transform.parent.position, -1f);
							VibrateScript[] vibrations = Vibrations;
							for (int i = 0; i < vibrations.Length; i++)
							{
								vibrations[i].enabled = false;
							}
							Heartbroken.Freeze = true;
						}
						if (CracksSpawned < 17)
						{
							Heartbroken.Darken();
							while (RandomCrack == LastRandomCrack)
							{
								RandomCrack = Random.Range(0, 3);
							}
							LastRandomCrack = RandomCrack;
							MyAudio.clip = CrackSound[RandomCrack];
							MyAudio.Play();
							TwitchID++;
							if (TwitchID > 5)
							{
								TwitchID = 0;
							}
							if (CracksSpawned == 0)
							{
								StudentManager.Yandere.CharacterAnimation["f02_snapTwitch_0" + TwitchID].time = 0f;
								StudentManager.Yandere.CharacterAnimation.CrossFade("f02_snapTwitch_0" + TwitchID);
							}
							else
							{
								StudentManager.Yandere.CharacterAnimation["f02_snapTwitch_0" + TwitchID].time = 0.1f;
								StudentManager.Yandere.CharacterAnimation.Play("f02_snapTwitch_0" + TwitchID);
							}
							StudentManager.MainCamera.Translate(StudentManager.MainCamera.forward * 0.1f, Space.World);
							StudentManager.MainCamera.position = new Vector3(StudentManager.MainCamera.position.x, StudentManager.MainCamera.position.y - 0.01f, StudentManager.MainCamera.position.z);
							int cracksSpawned = CracksSpawned;
							while (cracksSpawned == CracksSpawned)
							{
								int num = Random.Range(1, Cracks.Length);
								if (!Cracks[num].activeInHierarchy)
								{
									Cracks[num].SetActive(value: true);
									CracksSpawned++;
								}
							}
							if (NeverSnap && CracksSpawned == 16)
							{
								while (CracksSpawned > 0)
								{
									Cracks[CracksSpawned].SetActive(value: false);
									CracksSpawned--;
								}
							}
							StudentManager.SnapSomeStudents();
							StudentManager.OpenSomeDoors();
						}
						else
						{
							for (int j = 1; j < Cracks.Length; j++)
							{
								Cracks[j].GetComponent<UITexture>().fillAmount = 0.425f;
								Cracks[j].SetActive(value: false);
							}
							CracksSpawned = 0;
							StudentManager.SelectiveGreyscale.enabled = false;
							StudentManager.Yandere.RPGCamera.mouseSpeed = 8f;
							StudentManager.Yandere.RPGCamera.distance = 0.566666f;
							StudentManager.Yandere.RPGCamera.distanceMax = 0.666666f;
							StudentManager.Yandere.RPGCamera.distanceMin = 0.666666f;
							StudentManager.Yandere.RPGCamera.desiredDistance = 0.666666f;
							StudentManager.Yandere.RPGCamera.mouseX = StudentManager.Yandere.transform.eulerAngles.y;
							StudentManager.Yandere.RPGCamera.mouseXSmooth = StudentManager.Yandere.transform.eulerAngles.y;
							StudentManager.Yandere.RPGCamera.mouseY = 15f;
							StudentManager.Yandere.RPGCamera.mouseY = 15f;
							StudentManager.Yandere.Zoom.OverShoulder = true;
							StudentManager.Yandere.Zoom.TargetZoom = 0.4f;
							StudentManager.Yandere.Zoom.Zoom = 0.4f;
							StudentManager.Yandere.Zoom.enabled = false;
							StudentManager.Yandere.RightYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
							StudentManager.Yandere.LeftYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
							SnapPOV.localPosition = new Vector3(1.25f, 1.546664f, -0.5473595f);
							SnapFocus.parent = null;
							StudentManager.Yandere.MainCamera.enabled = true;
							Continue.color = new Color(0f, 0f, 0f, 0f);
							MyLabel.color = new Color(0f, 0f, 0f, 0f);
							CursorSprite.enabled = false;
							MainFilter.enabled = true;
							FPS.SetActive(value: false);
							SnapSequence = true;
							MyAudio.clip = GlassShatter;
							MyAudio.volume = 1f;
							MyAudio.Play();
							Background[0].SetActive(value: false);
							Background[1].SetActive(value: false);
							SNAPLetters.SetActive(value: false);
							Time.timeScale = 0.5f;
							ShatterSpawner component = Object.Instantiate(ShatterPrefab).GetComponent<ShatterSpawner>();
							component.ScreenMaterial.mainTexture = BlackTexture;
							component.ShatterOrigin = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
							StudentManager.Yandere.CharacterAnimation["f02_snapRise_00"].speed = 2f;
							StudentManager.Yandere.CharacterAnimation.CrossFade("f02_snapRise_00");
							StudentManager.Yandere.enabled = false;
							StudentManager.Students[1].Character.SetActive(value: true);
							SnapUICamera.SetActive(value: true);
							StudentManager.SnapSomeStudents();
							StudentManager.OpenSomeDoors();
							StudentManager.DarkenAllStudents();
							StudentManager.Headmaster.gameObject.SetActive(value: false);
							HeartbrokenCamera.nearClipPlane = 0.01f;
						}
					}
				}
			}
			if (SnapSequence)
			{
				SnapTimer += Time.deltaTime;
				if (SnapTimer > 9f)
				{
					GameObjectUtils.SetLayerRecursively(StudentManager.Yandere.gameObject, 13);
					StudentManager.Yandere.CharacterAnimation["f02_sadEyebrows_00"].weight = 0f;
					HeartbrokenCamera.cullingMask = StudentManager.Yandere.MainCamera.cullingMask;
					HeartbrokenCamera.clearFlags = StudentManager.Yandere.MainCamera.clearFlags;
					HeartbrokenCamera.farClipPlane = StudentManager.Yandere.MainCamera.farClipPlane;
					Heartbroken.MainCamera.enabled = false;
					StudentManager.Yandere.RPGCamera.transform.parent = StudentManager.Yandere.transform;
					SnappedYandere.enabled = true;
					SnappedYandere.CanMove = true;
					StudentManager.DisableAllLowPolyStudents();
					SnapStatic.Play();
					SnapMusic.Play();
					base.enabled = false;
					MyAudio.Stop();
					Debug.Log("The player now has control over Yandere-chan again.");
				}
				else if (SnapTimer > 2f)
				{
					if (MyAudio.clip != ReverseHit)
					{
						MyAudio.clip = ReverseHit;
						MyAudio.time = 1f;
						MyAudio.Play();
					}
					Time.timeScale = 1f;
					Speed += Time.deltaTime * 0.5f;
					SnapPOV.localPosition = Vector3.Lerp(SnapPOV.localPosition, new Vector3(0.25f, 1.546664f, -0.5473595f), Time.deltaTime * Speed);
					StudentManager.MainCamera.position = Vector3.Lerp(StudentManager.MainCamera.position, SnapPOV.position, Time.deltaTime * Speed);
					SnapFocus.position = Vector3.Lerp(SnapFocus.position, SnapDestination.position, Time.deltaTime * Speed);
					StudentManager.MainCamera.LookAt(SnapFocus);
					MainFilter.Fade = Mathf.MoveTowards(MainFilter.Fade, 0f, Time.deltaTime * (1f / 7f));
					HeartbrokenFilter.Fade = Mathf.MoveTowards(HeartbrokenFilter.Fade, 1f, Time.deltaTime * (1f / 7f));
					SnappedYandere.CompressionFX.Parasite = Mathf.MoveTowards(SnappedYandere.CompressionFX.Parasite, 1f, Time.deltaTime * (1f / 7f));
					SnappedYandere.TiltShift.Size = Mathf.MoveTowards(SnappedYandere.TiltShift.Size, 0.75f, Time.deltaTime * (1f / 7f));
					SnappedYandere.TiltShiftV.Size = Mathf.MoveTowards(SnappedYandere.TiltShiftV.Size, 0.75f, Time.deltaTime * (1f / 7f));
				}
			}
		}
		else
		{
			Heartbroken.GetComponent<AudioSource>().volume -= Time.deltaTime;
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a + Time.deltaTime);
			if (Darkness.color.a >= 1f)
			{
				if (Selected == 1)
				{
					if (ReloadScene)
					{
						GameGlobals.Debug = false;
						SceneManager.LoadScene(Application.loadedLevel);
					}
					else
					{
						for (int k = 0; k < StudentManager.NPCsTotal; k++)
						{
							if (StudentGlobals.GetStudentDying(k))
							{
								StudentGlobals.SetStudentDying(k, value: false);
							}
						}
						SceneManager.LoadScene("LoadingScene");
					}
				}
				else if (Selected == 2)
				{
					if (ReloadScene)
					{
						SceneManager.LoadScene("HomeScene");
					}
					else
					{
						ResetWeek();
					}
				}
				else if (Selected == 3)
				{
					if (BefriendBetrayMission)
					{
						SceneManager.LoadScene("NewTitleScene");
					}
					else
					{
						PlayerPrefs.SetInt("LoadingSave", 1);
						PlayerPrefs.SetInt("SaveSlot", GameGlobals.MostRecentSlot);
						for (int l = 0; l < StudentManager.NPCsTotal; l++)
						{
							if (StudentGlobals.GetStudentDying(l))
							{
								StudentGlobals.SetStudentDying(l, value: false);
							}
						}
						SceneManager.LoadScene("LoadingScene");
					}
				}
				else if (Selected == 4)
				{
					SceneManager.LoadScene("NewTitleScene");
				}
			}
		}
		if (Nudge)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x + Time.deltaTime * 250f, base.transform.localPosition.y, base.transform.localPosition.z);
			if (base.transform.localPosition.x > -225f)
			{
				base.transform.localPosition = new Vector3(-225f, base.transform.localPosition.y, base.transform.localPosition.z);
				Nudge = false;
			}
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x - Time.deltaTime * 250f, base.transform.localPosition.y, base.transform.localPosition.z);
			if (base.transform.localPosition.x < -250f)
			{
				base.transform.localPosition = new Vector3(-250f, base.transform.localPosition.y, base.transform.localPosition.z);
			}
		}
	}

	public void ResetWeek()
	{
		int profile = GameGlobals.Profile;
		int num = 11;
		int femaleUniform = StudentGlobals.FemaleUniform;
		int maleUniform = StudentGlobals.MaleUniform;
		if (File.Exists(Application.streamingAssetsPath + "/SaveFiles/Profile_" + profile + "_Slot_" + num + ".yansave"))
		{
			YanSave.LoadData("Profile_" + profile + "_Slot_" + num);
			YanSave.LoadPrefs("Profile_" + profile + "_Slot_" + num);
			Debug.Log("Successfully loaded the save in Slot #" + num);
		}
		else
		{
			Debug.Log("Attempted to load a save from Slot #" + num + ", but apparently it didn't exist.");
		}
		StudentGlobals.SetStudentDead(10 + DateGlobals.Week, value: false);
		StudentGlobals.SetStudentDying(10 + DateGlobals.Week, value: false);
		StudentGlobals.FemaleUniform = femaleUniform;
		StudentGlobals.MaleUniform = maleUniform;
		SceneManager.LoadScene("CalendarScene");
	}
}
