using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200030F RID: 783
public class HeartbrokenCursorScript : MonoBehaviour
{
	// Token: 0x0600184E RID: 6222 RVA: 0x000E7AC8 File Offset: 0x000E5CC8
	private void Start()
	{
		this.Darkness.transform.localPosition = new Vector3(this.Darkness.transform.localPosition.x, this.Darkness.transform.localPosition.y, -989f);
		this.Continue.color = new Color(this.Continue.color.r, this.Continue.color.g, this.Continue.color.b, 0f);
		if (this.StudentManager != null)
		{
			this.StudentManager.Yandere.Jukebox.gameObject.SetActive(false);
			if (this.StudentManager.Yandere.Weapon[1] != null && this.StudentManager.Yandere.Weapon[1].Type == WeaponType.Knife)
			{
				this.StudentManager.Yandere.Weapon[1].Drop();
			}
			if (this.StudentManager.Yandere.Weapon[2] != null && this.StudentManager.Yandere.Weapon[2].Type == WeaponType.Knife)
			{
				this.StudentManager.Yandere.Weapon[2].Drop();
			}
			this.StudentManager.Journalist.SetActive(false);
		}
	}

	// Token: 0x0600184F RID: 6223 RVA: 0x000E7C34 File Offset: 0x000E5E34
	private void Update()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 255f - (float)this.Selected * 50f, Time.deltaTime * 10f), base.transform.localPosition.z);
		if (this.Selected == 5)
		{
			this.GameOverMusic.volume = Mathf.MoveTowards(this.GameOverMusic.volume, 0f, Time.deltaTime * 0.5f);
		}
		else
		{
			this.GameOverMusic.volume = Mathf.MoveTowards(this.GameOverMusic.volume, 1f, Time.deltaTime * 0.5f);
		}
		if (!this.FadeOut)
		{
			if (this.MyLabel.color.a >= 1f)
			{
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > this.Options)
					{
						this.Selected = 1;
					}
					this.MyAudio.clip = this.MoveSound;
					this.MyAudio.Play();
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = this.Options;
					}
					this.MyAudio.clip = this.MoveSound;
					this.MyAudio.Play();
				}
				this.Continue.color = new Color(this.Continue.color.r, this.Continue.color.g, this.Continue.color.b, (this.Selected != 5) ? 1f : 0f);
				if (Input.GetButtonDown("A"))
				{
					this.Nudge = true;
					if (this.Selected != 5)
					{
						this.MyAudio.clip = this.SelectSound;
						this.MyAudio.Play();
						if (this.Selected == 1 || (this.Selected == 2 && this.Heartbroken.Options[1].alpha == 1f) || (this.Selected == 3 && GameGlobals.MostRecentSlot > 0) || this.Selected == 4)
						{
							this.FadeOut = true;
						}
					}
					else
					{
						this.StudentManager.Yandere.ShoulderCamera.enabled = false;
						if (this.CracksSpawned == 0)
						{
							GameObjectUtils.SetLayerRecursively(this.StudentManager.Yandere.gameObject, 5);
							this.Cracks[1].transform.parent.position = this.StudentManager.Yandere.Head.position;
							this.Cracks[1].transform.parent.position = Vector3.MoveTowards(this.Cracks[1].transform.parent.position, this.Heartbroken.transform.parent.position, -1f);
							VibrateScript[] vibrations = this.Vibrations;
							for (int i = 0; i < vibrations.Length; i++)
							{
								vibrations[i].enabled = false;
							}
							this.Heartbroken.Freeze = true;
						}
						if (this.CracksSpawned < 17)
						{
							this.Heartbroken.Darken();
							while (this.RandomCrack == this.LastRandomCrack)
							{
								this.RandomCrack = UnityEngine.Random.Range(0, 3);
							}
							this.LastRandomCrack = this.RandomCrack;
							this.MyAudio.clip = this.CrackSound[this.RandomCrack];
							this.MyAudio.Play();
							this.TwitchID++;
							if (this.TwitchID > 5)
							{
								this.TwitchID = 0;
							}
							this.StudentManager.Yandere.CharacterAnimation["f02_snapTwitch_0" + this.TwitchID.ToString()].time = 0.1f;
							this.StudentManager.Yandere.CharacterAnimation.Play("f02_snapTwitch_0" + this.TwitchID.ToString());
							this.StudentManager.MainCamera.Translate(this.StudentManager.MainCamera.forward * 0.1f, Space.World);
							this.StudentManager.MainCamera.position = new Vector3(this.StudentManager.MainCamera.position.x, this.StudentManager.MainCamera.position.y - 0.01f, this.StudentManager.MainCamera.position.z);
							int cracksSpawned = this.CracksSpawned;
							while (cracksSpawned == this.CracksSpawned)
							{
								int num = UnityEngine.Random.Range(1, this.Cracks.Length);
								if (!this.Cracks[num].activeInHierarchy)
								{
									this.Cracks[num].SetActive(true);
									this.CracksSpawned++;
								}
							}
							if (this.NeverSnap && this.CracksSpawned == 16)
							{
								while (this.CracksSpawned > 0)
								{
									this.Cracks[this.CracksSpawned].SetActive(false);
									this.CracksSpawned--;
								}
							}
							this.StudentManager.SnapSomeStudents();
							this.StudentManager.OpenSomeDoors();
						}
						else
						{
							for (int j = 1; j < this.Cracks.Length; j++)
							{
								this.Cracks[j].GetComponent<UITexture>().fillAmount = 0.425f;
								this.Cracks[j].SetActive(false);
							}
							this.CracksSpawned = 0;
							this.StudentManager.SelectiveGreyscale.enabled = false;
							this.StudentManager.Yandere.RPGCamera.mouseSpeed = 8f;
							this.StudentManager.Yandere.RPGCamera.distance = 0.566666f;
							this.StudentManager.Yandere.RPGCamera.distanceMax = 0.666666f;
							this.StudentManager.Yandere.RPGCamera.distanceMin = 0.666666f;
							this.StudentManager.Yandere.RPGCamera.desiredDistance = 0.666666f;
							this.StudentManager.Yandere.RPGCamera.mouseX = this.StudentManager.Yandere.transform.eulerAngles.y;
							this.StudentManager.Yandere.RPGCamera.mouseXSmooth = this.StudentManager.Yandere.transform.eulerAngles.y;
							this.StudentManager.Yandere.RPGCamera.mouseY = 15f;
							this.StudentManager.Yandere.RPGCamera.mouseY = 15f;
							this.StudentManager.Yandere.Zoom.OverShoulder = true;
							this.StudentManager.Yandere.Zoom.TargetZoom = 0.4f;
							this.StudentManager.Yandere.Zoom.Zoom = 0.4f;
							this.StudentManager.Yandere.Zoom.enabled = false;
							this.StudentManager.Yandere.RightYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
							this.StudentManager.Yandere.LeftYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
							this.SnapPOV.localPosition = new Vector3(1.25f, 1.546664f, -0.5473595f);
							this.SnapFocus.parent = null;
							this.StudentManager.Yandere.MainCamera.enabled = true;
							this.Continue.color = new Color(0f, 0f, 0f, 0f);
							this.MyLabel.color = new Color(0f, 0f, 0f, 0f);
							this.CursorSprite.enabled = false;
							this.MainFilter.enabled = true;
							this.FPS.SetActive(false);
							this.SnapSequence = true;
							this.MyAudio.clip = this.GlassShatter;
							this.MyAudio.volume = 1f;
							this.MyAudio.Play();
							this.Background[0].SetActive(false);
							this.Background[1].SetActive(false);
							this.SNAPLetters.SetActive(false);
							Time.timeScale = 0.5f;
							ShatterSpawner component = UnityEngine.Object.Instantiate<GameObject>(this.ShatterPrefab).GetComponent<ShatterSpawner>();
							component.ScreenMaterial.mainTexture = this.BlackTexture;
							component.ShatterOrigin = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
							this.StudentManager.Yandere.CharacterAnimation["f02_snapRise_00"].speed = 2f;
							this.StudentManager.Yandere.CharacterAnimation.CrossFade("f02_snapRise_00");
							this.StudentManager.Yandere.enabled = false;
							this.StudentManager.Students[1].Character.SetActive(true);
							this.SnapUICamera.SetActive(true);
							this.StudentManager.SnapSomeStudents();
							this.StudentManager.OpenSomeDoors();
							this.StudentManager.DarkenAllStudents();
							this.StudentManager.Headmaster.gameObject.SetActive(false);
							this.HeartbrokenCamera.nearClipPlane = 0.01f;
						}
					}
				}
			}
			if (this.SnapSequence)
			{
				this.SnapTimer += Time.deltaTime;
				if (this.SnapTimer > 10f)
				{
					GameObjectUtils.SetLayerRecursively(this.StudentManager.Yandere.gameObject, 13);
					this.StudentManager.Yandere.CharacterAnimation["f02_sadEyebrows_00"].weight = 0f;
					this.HeartbrokenCamera.cullingMask = this.StudentManager.Yandere.MainCamera.cullingMask;
					this.HeartbrokenCamera.clearFlags = this.StudentManager.Yandere.MainCamera.clearFlags;
					this.HeartbrokenCamera.farClipPlane = this.StudentManager.Yandere.MainCamera.farClipPlane;
					this.Heartbroken.MainCamera.enabled = false;
					this.StudentManager.Yandere.RPGCamera.transform.parent = this.StudentManager.Yandere.transform;
					this.SnappedYandere.enabled = true;
					this.SnappedYandere.CanMove = true;
					this.SnapStatic.Play();
					this.SnapMusic.Play();
					base.enabled = false;
					this.MyAudio.Stop();
					Debug.Log("The player now has control over Yandere-chan again.");
				}
				else if (this.SnapTimer > 3f)
				{
					if (this.MyAudio.clip != this.ReverseHit)
					{
						this.MyAudio.clip = this.ReverseHit;
						this.MyAudio.time = 1f;
						this.MyAudio.Play();
					}
					Time.timeScale = 1f;
					this.Speed += Time.deltaTime * 0.5f;
					this.SnapPOV.localPosition = Vector3.Lerp(this.SnapPOV.localPosition, new Vector3(0.25f, 1.546664f, -0.5473595f), Time.deltaTime * this.Speed);
					this.StudentManager.MainCamera.position = Vector3.Lerp(this.StudentManager.MainCamera.position, this.SnapPOV.position, Time.deltaTime * this.Speed);
					this.SnapFocus.position = Vector3.Lerp(this.SnapFocus.position, this.SnapDestination.position, Time.deltaTime * this.Speed);
					this.StudentManager.MainCamera.LookAt(this.SnapFocus);
					this.MainFilter.Fade = Mathf.MoveTowards(this.MainFilter.Fade, 0f, Time.deltaTime * 0.14285715f);
					this.HeartbrokenFilter.Fade = Mathf.MoveTowards(this.HeartbrokenFilter.Fade, 1f, Time.deltaTime * 0.14285715f);
					this.SnappedYandere.CompressionFX.Parasite = Mathf.MoveTowards(this.SnappedYandere.CompressionFX.Parasite, 1f, Time.deltaTime * 0.14285715f);
					this.SnappedYandere.TiltShift.Size = Mathf.MoveTowards(this.SnappedYandere.TiltShift.Size, 0.75f, Time.deltaTime * 0.14285715f);
					this.SnappedYandere.TiltShiftV.Size = Mathf.MoveTowards(this.SnappedYandere.TiltShiftV.Size, 0.75f, Time.deltaTime * 0.14285715f);
				}
			}
		}
		else
		{
			this.Heartbroken.GetComponent<AudioSource>().volume -= Time.deltaTime;
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				if (this.Selected == 1)
				{
					if (this.ReloadScene)
					{
						GameGlobals.Debug = false;
						SceneManager.LoadScene(Application.loadedLevel);
					}
					else
					{
						for (int k = 0; k < this.StudentManager.NPCsTotal; k++)
						{
							if (StudentGlobals.GetStudentDying(k))
							{
								StudentGlobals.SetStudentDying(k, false);
							}
						}
						SceneManager.LoadScene("LoadingScene");
					}
				}
				else if (this.Selected == 2)
				{
					if (this.ReloadScene)
					{
						SceneManager.LoadScene("HomeScene");
					}
					else
					{
						int profile = GameGlobals.Profile;
						int num2 = 11;
						if (File.Exists(string.Concat(new string[]
						{
							Application.streamingAssetsPath,
							"/SaveFiles/Profile_",
							profile.ToString(),
							"_Slot_",
							num2.ToString(),
							".yansave"
						})))
						{
							YanSave.LoadData("Profile_" + profile.ToString() + "_Slot_" + num2.ToString(), false);
							YanSave.LoadPrefs("Profile_" + profile.ToString() + "_Slot_" + num2.ToString());
							Debug.Log("Successfully loaded the save in Slot #" + num2.ToString());
						}
						else
						{
							Debug.Log("Attempted to load a save from Slot #" + num2.ToString() + ", but apparently it didn't exist.");
						}
						StudentGlobals.SetStudentDead(10 + DateGlobals.Week, false);
						StudentGlobals.SetStudentDying(10 + DateGlobals.Week, false);
						SceneManager.LoadScene("CalendarScene");
					}
				}
				else if (this.Selected == 3)
				{
					if (this.BefriendBetrayMission)
					{
						SceneManager.LoadScene("NewTitleScene");
					}
					else
					{
						PlayerPrefs.SetInt("LoadingSave", 1);
						PlayerPrefs.SetInt("SaveSlot", GameGlobals.MostRecentSlot);
						for (int l = 0; l < this.StudentManager.NPCsTotal; l++)
						{
							if (StudentGlobals.GetStudentDying(l))
							{
								StudentGlobals.SetStudentDying(l, false);
							}
						}
						SceneManager.LoadScene("LoadingScene");
					}
				}
				else if (this.Selected == 4)
				{
					SceneManager.LoadScene("NewTitleScene");
				}
			}
		}
		if (this.Nudge)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x + Time.deltaTime * 250f, base.transform.localPosition.y, base.transform.localPosition.z);
			if (base.transform.localPosition.x > -225f)
			{
				base.transform.localPosition = new Vector3(-225f, base.transform.localPosition.y, base.transform.localPosition.z);
				this.Nudge = false;
				return;
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

	// Token: 0x040023B1 RID: 9137
	public SnappedYandereScript SnappedYandere;

	// Token: 0x040023B2 RID: 9138
	public StudentManagerScript StudentManager;

	// Token: 0x040023B3 RID: 9139
	public InputManagerScript InputManager;

	// Token: 0x040023B4 RID: 9140
	public HeartbrokenScript Heartbroken;

	// Token: 0x040023B5 RID: 9141
	public VibrateScript[] Vibrations;

	// Token: 0x040023B6 RID: 9142
	public UISprite CursorSprite;

	// Token: 0x040023B7 RID: 9143
	public UISprite Darkness;

	// Token: 0x040023B8 RID: 9144
	public AudioClip SelectSound;

	// Token: 0x040023B9 RID: 9145
	public AudioClip MoveSound;

	// Token: 0x040023BA RID: 9146
	public AudioSource MyAudio;

	// Token: 0x040023BB RID: 9147
	public UILabel Continue;

	// Token: 0x040023BC RID: 9148
	public UILabel MyLabel;

	// Token: 0x040023BD RID: 9149
	public GameObject FPS;

	// Token: 0x040023BE RID: 9150
	public bool LoveSick;

	// Token: 0x040023BF RID: 9151
	public bool FadeOut;

	// Token: 0x040023C0 RID: 9152
	public bool Nudge;

	// Token: 0x040023C1 RID: 9153
	public int CracksSpawned;

	// Token: 0x040023C2 RID: 9154
	public int Selected = 1;

	// Token: 0x040023C3 RID: 9155
	public int Options = 5;

	// Token: 0x040023C4 RID: 9156
	public int LastRandomCrack;

	// Token: 0x040023C5 RID: 9157
	public int RandomCrack;

	// Token: 0x040023C6 RID: 9158
	public CameraFilterPack_Gradients_FireGradient HeartbrokenFilter;

	// Token: 0x040023C7 RID: 9159
	public CameraFilterPack_Gradients_FireGradient MainFilter;

	// Token: 0x040023C8 RID: 9160
	public Camera HeartbrokenCamera;

	// Token: 0x040023C9 RID: 9161
	public AudioSource GameOverMusic;

	// Token: 0x040023CA RID: 9162
	public AudioSource SnapStatic;

	// Token: 0x040023CB RID: 9163
	public AudioSource SnapMusic;

	// Token: 0x040023CC RID: 9164
	public AudioClip GlassShatter;

	// Token: 0x040023CD RID: 9165
	public AudioClip ReverseHit;

	// Token: 0x040023CE RID: 9166
	public AudioClip[] CrackSound;

	// Token: 0x040023CF RID: 9167
	public GameObject ShatterPrefab;

	// Token: 0x040023D0 RID: 9168
	public GameObject SNAPLetters;

	// Token: 0x040023D1 RID: 9169
	public GameObject SnapUICamera;

	// Token: 0x040023D2 RID: 9170
	public UIPanel SNAPPanel;

	// Token: 0x040023D3 RID: 9171
	public GameObject[] Background;

	// Token: 0x040023D4 RID: 9172
	public GameObject[] CrackMeshes;

	// Token: 0x040023D5 RID: 9173
	public GameObject[] Cracks;

	// Token: 0x040023D6 RID: 9174
	public AudioClip[] CracksTier1;

	// Token: 0x040023D7 RID: 9175
	public AudioClip[] CracksTier2;

	// Token: 0x040023D8 RID: 9176
	public AudioClip[] CracksTier3;

	// Token: 0x040023D9 RID: 9177
	public AudioClip[] CracksTier4;

	// Token: 0x040023DA RID: 9178
	public Texture BlackTexture;

	// Token: 0x040023DB RID: 9179
	public Transform SnapDestination;

	// Token: 0x040023DC RID: 9180
	public Transform SnapFocus;

	// Token: 0x040023DD RID: 9181
	public Transform SnapPOV;

	// Token: 0x040023DE RID: 9182
	public bool BefriendBetrayMission;

	// Token: 0x040023DF RID: 9183
	public bool SnapSequence;

	// Token: 0x040023E0 RID: 9184
	public bool ReloadScene;

	// Token: 0x040023E1 RID: 9185
	public bool NeverSnap;

	// Token: 0x040023E2 RID: 9186
	public float SnapTimer;

	// Token: 0x040023E3 RID: 9187
	public float Speed;

	// Token: 0x040023E4 RID: 9188
	public int TwitchID;
}
