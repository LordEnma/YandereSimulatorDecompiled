using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class BeatEmUpScript : MonoBehaviour
{
	public CharacterController MyController;

	public BeatEmUpEnemyScript[] AllEnemies;

	public PostProcessingProfile Profile;

	public BeatEmUpEnemyScript Enemy;

	public RPG_Camera RPGCamera;

	public AudioClip[] AttackVoices;

	public AudioClip[] PainVoices;

	public Transform EnemyHealthBar;

	public Transform HealthBar;

	public Transform SuperBar;

	public AudioSource MySecondAudio;

	public AudioSource MyAudio;

	public AudioSource Music;

	public AudioClip EightiesTrack;

	public UILabel EnemyNameLabel;

	public UILabel GrowingLabel;

	public UILabel VictoryLabel;

	public UILabel HealthLabel;

	public UILabel SuperLabel;

	public Animation MyAnimation;

	public UIPanel GameplayPanel;

	public UISprite SuperButton;

	public GameObject PauseLabel;

	public GameObject HitEffect;

	public GameObject Hitbox;

	public Transform MainCamera;

	public Transform Ring;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform RightFoot;

	public Transform RightHand;

	public Transform LeftHand;

	public AudioClip MusicLoop;

	public AudioClip HitSFX;

	public AudioClip Whoosh;

	public UISprite Darkness;

	public UISprite White;

	public Light LightSource;

	public int RollDirection = 1;

	public int AttackLimit;

	public int Difficulty = 1;

	public int AttackID = 1;

	public int Enemies = 2;

	public int TextID = 1;

	public bool HitboxSpawned;

	public bool HitReacting;

	public bool Attacking;

	public bool Defeated;

	public bool Eighties;

	public bool CanMove;

	public bool Rolling;

	public bool Victory;

	public bool Super;

	public bool Combo;

	public bool Heavy;

	public bool Intro;

	public string[] GrowingText;

	public string[] AttackAnim;

	public float[] Damages;

	public float CameraVibrate;

	public float MaxRollSpeed;

	public float CameraSpeed;

	public float IntroTimer;

	public float SuperTimer;

	public float RollSpeed;

	public float RollTimer;

	public float RunSpeed;

	public float MaxHealth;

	public float Health;

	public float SuperMeter;

	public float MaxSuper;

	public string HitReactAnim;

	public string DefeatAnim;

	public string SuperAnim;

	public string IdleAnim;

	public string RollAnim;

	public string RunAnim;

	public Renderer PonytailRenderer;

	public Texture EightiesUniformTexture;

	public Texture BlondeTexture;

	public AudioClip[] DialogueClips;

	public string[] DialogueText;

	public AudioSource Dialogue;

	public UILabel Subtitle;

	public int CutsceneID;

	public bool Cutscene;

	public GameObject IncineratorScene;

	public GameObject StreetScene;

	public SkinnedMeshRenderer MyRenderer;

	public Texture[] UniformTextures;

	public Texture FaceTexture;

	public Mesh[] Uniforms;

	public GameObject RyobaHair;

	private void Start()
	{
		Difficulty = GameGlobals.BeatEmUpDifficulty;
		MyAnimation[AttackAnim[1]].speed = 1f;
		MyAnimation[AttackAnim[2]].speed = 1f;
		MyAnimation[AttackAnim[3]].speed = 1f;
		MaxHealth -= Difficulty * 20;
		Health = MaxHealth;
		HealthLabel.text = Health + " / " + MaxHealth;
		MainCamera.transform.position = new Vector3(-1f, 0.742f, 3f);
		MainCamera.transform.eulerAngles = new Vector3(0f, 15f, 0f);
		SuperLabel.text = SuperMeter + " / " + MaxSuper;
		SuperBar.transform.localScale = new Vector3(0f, 1f, 1f);
		GrowingLabel.transform.localScale = Vector3.zero;
		GrowingLabel.alpha = 0f;
		GrowingLabel.text = GrowingText[1];
		GameplayPanel.alpha = 0f;
		Darkness.alpha = 1f;
		Time.timeScale = 1f;
		for (int i = 1; i < AllEnemies.Length; i++)
		{
			AllEnemies[i].DisableWeapon();
			AllEnemies[i].Start();
		}
		if (GameGlobals.BlondeHair)
		{
			PonytailRenderer.material.mainTexture = BlondeTexture;
		}
		if (GameGlobals.Eighties)
		{
			FaceTexture = RyobaHair.GetComponent<Renderer>().material.mainTexture;
			RyobaHair.transform.parent.gameObject.SetActive(value: true);
			PonytailRenderer.gameObject.SetActive(value: false);
			Music.Stop();
			Dialogue.clip = DialogueClips[CutsceneID];
			Dialogue.Play();
			Subtitle.text = DialogueText[CutsceneID];
			Cutscene = true;
			IncineratorScene.SetActive(value: false);
			StreetScene.SetActive(value: true);
			RightBreast.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			LeftBreast.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			Eighties = true;
		}
		else
		{
			RyobaHair.transform.parent.gameObject.SetActive(value: false);
		}
		ChangeSchoolwear();
		Profile.motionBlur.enabled = false;
		UpdateDOF(2f);
		if (!OptionGlobals.EnableShadows)
		{
			LightSource.shadows = LightShadows.None;
		}
		else
		{
			LightSource.shadows = LightShadows.Soft;
		}
	}

	private void ChangeSchoolwear()
	{
		MyRenderer.sharedMesh = Uniforms[StudentGlobals.FemaleUniform];
		MyRenderer.materials[0].mainTexture = UniformTextures[StudentGlobals.FemaleUniform];
		MyRenderer.materials[1].mainTexture = UniformTextures[StudentGlobals.FemaleUniform];
		MyRenderer.materials[2].mainTexture = FaceTexture;
		if (Eighties)
		{
			MyRenderer.materials[0].mainTexture = EightiesUniformTexture;
		}
	}

	private void Update()
	{
		if (!Victory)
		{
			if (!Intro)
			{
				GetNearestEnemy();
				EnemyHealthBar.localScale = new Vector3(Enemy.Health / Enemy.MaxHealth, 1f, 1f);
				EnemyNameLabel.text = Enemy.Name;
			}
			MyController.Move(Physics.gravity * Time.deltaTime);
			float axis = Input.GetAxis("Vertical");
			float axis2 = Input.GetAxis("Horizontal");
			Vector3 vector = MainCamera.TransformDirection(Vector3.forward);
			vector.y = 0f;
			vector = vector.normalized;
			Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
			Vector3 vector3 = axis2 * vector2 + axis * vector;
			Quaternion b = Quaternion.identity;
			if (vector3 != Vector3.zero)
			{
				b = Quaternion.LookRotation(vector3);
			}
			if (vector3 != Vector3.zero)
			{
				if (CanMove)
				{
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
				}
			}
			else
			{
				b = new Quaternion(0f, 0f, 0f, 0f);
			}
			if ((CanMove || (!CanMove && Attacking)) && Input.GetButtonDown(InputNames.Xbox_A))
			{
				Attacking = false;
				CanMove = false;
				Rolling = true;
				RollSpeed = MaxRollSpeed;
				if (vector3 != Vector3.zero)
				{
					base.transform.rotation = Quaternion.LookRotation(vector3);
					RollDirection = 1;
				}
				else
				{
					RollDirection = -1;
				}
				MyController.Move(base.transform.forward * RollSpeed * RollDirection * Time.deltaTime);
				MyAnimation[RollAnim].speed = 0f;
				MyAnimation[RollAnim].time = 0f;
				MyAnimation.CrossFade(RollAnim);
			}
			if (CanMove)
			{
				if (axis != 0f || axis2 != 0f)
				{
					MyAnimation.CrossFade(RunAnim);
					MyController.Move(base.transform.forward * RunSpeed * Time.deltaTime);
				}
				else
				{
					MyAnimation.CrossFade(IdleAnim);
				}
				if (Input.GetButtonDown(InputNames.Xbox_X) || Input.GetButtonDown(InputNames.Xbox_Y))
				{
					MyAudio.clip = AttackVoices[Random.Range(1, AttackVoices.Length)];
					MyAudio.Play();
					MySecondAudio.clip = Whoosh;
					MySecondAudio.pitch = Random.Range(0.9f, 1.1f);
					MySecondAudio.Play();
					HitboxSpawned = false;
					Attacking = true;
					CanMove = false;
					Heavy = false;
					b = Quaternion.LookRotation(Enemy.transform.position - base.transform.position);
					base.transform.rotation = b;
					if (Input.GetButtonDown(InputNames.Xbox_Y))
					{
						Heavy = true;
					}
					if (!Heavy)
					{
						AttackID = 1;
						AttackLimit = 7;
					}
					else
					{
						AttackID = 11;
						AttackLimit = 14;
					}
					MyAnimation[AttackAnim[AttackID]].time = 0f;
					MyAnimation.Play(AttackAnim[AttackID]);
				}
				else if (SuperMeter >= 100f && Input.GetButtonDown(InputNames.Xbox_B))
				{
					MyAudio.clip = AttackVoices[Random.Range(1, AttackVoices.Length)];
					MyAudio.Play();
					MySecondAudio.clip = Whoosh;
					MySecondAudio.pitch = Random.Range(0.9f, 1.1f);
					MySecondAudio.Play();
					MyController.enabled = false;
					HitboxSpawned = false;
					CanMove = false;
					Super = true;
					SuperMeter -= 100f;
					SuperLabel.text = SuperMeter + " / " + MaxSuper;
					SuperBar.transform.localScale = new Vector3(SuperMeter / MaxSuper, 1f, 1f);
					if (SuperMeter < 100f)
					{
						SuperButton.alpha = 0.5f;
					}
					b = Quaternion.LookRotation(Enemy.transform.position - base.transform.position);
					base.transform.rotation = b;
					MyAnimation[SuperAnim].time = 0f;
					MyAnimation.Play(SuperAnim);
				}
			}
			else if (Rolling)
			{
				RollSpeed = MaxRollSpeed * (1f - RollTimer / MyAnimation[RollAnim].length);
				MyController.Move(base.transform.forward * RollSpeed * RollDirection * Time.deltaTime);
				RollTimer += Time.deltaTime * 2f;
				if (RollDirection > 0)
				{
					MyAnimation[RollAnim].time = RollTimer;
				}
				else
				{
					MyAnimation[RollAnim].time = MyAnimation[RollAnim].length - RollTimer;
				}
				if (RollTimer >= MyAnimation[RollAnim].length)
				{
					MyAnimation.CrossFade(IdleAnim);
					MyAnimation[RollAnim].speed = 0f;
					Rolling = false;
					CanMove = true;
					RollTimer = 0f;
				}
			}
			else if (Attacking)
			{
				if (MyAnimation[AttackAnim[AttackID]].time >= MyAnimation[AttackAnim[AttackID]].length)
				{
					MyAnimation.CrossFade(IdleAnim);
					Attacking = false;
					CanMove = true;
				}
				else if (MyAnimation[AttackAnim[AttackID]].time >= MyAnimation[AttackAnim[AttackID]].length * 0.5f)
				{
					if (Combo)
					{
						base.transform.LookAt(Ring.position);
						MyAudio.clip = AttackVoices[Random.Range(1, AttackVoices.Length)];
						MyAudio.Play();
						MySecondAudio.clip = Whoosh;
						MySecondAudio.pitch = Random.Range(0.9f, 1.1f);
						MySecondAudio.Play();
						AttackID++;
						MyAnimation[AttackAnim[AttackID]].time = 0f;
						MyAnimation.Play(AttackAnim[AttackID]);
						HitboxSpawned = false;
						Combo = false;
					}
					else if (AttackID < AttackLimit)
					{
						if (!Heavy && Input.GetButtonDown(InputNames.Xbox_X))
						{
							Combo = true;
						}
						else if (Heavy && Input.GetButtonDown(InputNames.Xbox_Y))
						{
							Combo = true;
						}
					}
				}
				else if (AttackID < AttackLimit)
				{
					if (!Heavy && Input.GetButtonDown(InputNames.Xbox_X))
					{
						Combo = true;
					}
					else if (Heavy && Input.GetButtonDown(InputNames.Xbox_Y))
					{
						Combo = true;
					}
				}
				if (!HitboxSpawned)
				{
					if (AttackID < 14)
					{
						if (MyAnimation[AttackAnim[AttackID]].time >= MyAnimation[AttackAnim[AttackID]].length * 0.4f)
						{
							if (!Heavy)
							{
								BeatEmUpHitboxScript component = Object.Instantiate(Hitbox, base.transform.position + base.transform.forward * 0.45f + new Vector3(0f, 1f, 0f), base.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
								component.Damage = Damages[AttackID];
								component.AttackID = AttackID;
							}
							else
							{
								BeatEmUpHitboxScript component2 = Object.Instantiate(Hitbox, base.transform.position + base.transform.forward * 0.75f + new Vector3(0f, 1f, 0f), base.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
								component2.Damage = Damages[AttackID];
								component2.Heavy = true;
							}
							HitboxSpawned = true;
						}
					}
					else if (AttackID == 14 && MyAnimation[AttackAnim[AttackID]].time >= 0.525f)
					{
						BeatEmUpHitboxScript component3 = Object.Instantiate(Hitbox, base.transform.position + base.transform.forward * 0.75f + new Vector3(0f, 1f, 0f), base.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
						component3.Damage = Damages[AttackID];
						component3.AttackID = AttackID;
						component3.Heavy = true;
						HitboxSpawned = true;
					}
				}
			}
			else if (Super)
			{
				IntroTimer += Time.deltaTime;
				SuperTimer += Time.deltaTime;
				if (IntroTimer > 0.1f)
				{
					MyAudio.clip = AttackVoices[Random.Range(1, AttackVoices.Length)];
					MyAudio.Play();
					MySecondAudio.clip = Whoosh;
					MySecondAudio.pitch = Random.Range(0.9f, 1.1f);
					MySecondAudio.Play();
					BeatEmUpHitboxScript component4 = Object.Instantiate(Hitbox, base.transform.position + base.transform.forward * 0.45f + new Vector3(0f, 1f, 0f), base.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
					component4.Super = true;
					component4.Damage = 5f;
					IntroTimer = 0f;
				}
				if (SuperTimer > 2.1f)
				{
					MyController.enabled = true;
					CanMove = true;
					Super = false;
					IntroTimer = 0f;
					SuperTimer = 0f;
				}
			}
			else if (HitReacting)
			{
				if (MyAnimation[HitReactAnim].time >= MyAnimation[HitReactAnim].length)
				{
					MyAnimation.CrossFade(IdleAnim);
					HitReacting = false;
					CanMove = true;
				}
			}
			else if (Intro)
			{
				if (Cutscene)
				{
					if (!Dialogue.isPlaying || Input.GetButtonDown(InputNames.Xbox_A))
					{
						CutsceneID++;
						if (CutsceneID < 3)
						{
							Dialogue.clip = DialogueClips[CutsceneID];
							Dialogue.Play();
							Subtitle.text = DialogueText[CutsceneID];
						}
						else
						{
							Music.clip = EightiesTrack;
							Cutscene = false;
							Subtitle.text = "";
						}
					}
				}
				else
				{
					IntroTimer += Time.deltaTime;
					if (IntroTimer > 2.66666f)
					{
						CameraSpeed += Time.deltaTime * (0.1f + CameraSpeed);
						MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, new Vector3(0f, 1.773969f, -7.888118f), Time.deltaTime * CameraSpeed);
						MainCamera.transform.eulerAngles = Vector3.Lerp(MainCamera.transform.eulerAngles, new Vector3(15f, 0f, 0f), Time.deltaTime * CameraSpeed);
						if (IntroTimer > 5f)
						{
							GrowingLabel.transform.localScale += new Vector3(5f, 5f, 5f) * Time.deltaTime;
							if (GrowingLabel.transform.localScale.x <= 1f)
							{
								GrowingLabel.alpha = Mathf.MoveTowards(GrowingLabel.alpha, 1f, Time.deltaTime * 5f);
							}
							else if (GrowingLabel.transform.localScale.x >= 2f)
							{
								GrowingLabel.alpha = Mathf.MoveTowards(GrowingLabel.alpha, 0f, Time.deltaTime * 5f);
								if (GrowingLabel.alpha == 0f)
								{
									TextID++;
									if (TextID < GrowingText.Length)
									{
										GrowingLabel.text = GrowingText[TextID];
										GrowingLabel.transform.localScale = Vector3.zero;
									}
								}
							}
						}
						else if (IntroTimer > 4f)
						{
							GameplayPanel.alpha = Mathf.MoveTowards(GameplayPanel.alpha, 1f, Time.deltaTime);
						}
						if (!Music.isPlaying || IntroTimer > 7.5f)
						{
							GrowingLabel.transform.localScale = Vector3.zero;
							GameplayPanel.alpha = 1f;
							if (!Eighties)
							{
								Music.clip = MusicLoop;
								Music.Play();
							}
							Music.loop = true;
							RPGCamera.enabled = true;
							CanMove = true;
							Intro = false;
							int num = 1;
							while (num < AllEnemies.Length)
							{
								if (AllEnemies[num] != null)
								{
									AllEnemies[num].enabled = true;
									num++;
								}
							}
						}
					}
					else if (IntroTimer > 1f)
					{
						if (!Music.isPlaying)
						{
							CameraSpeed += Time.deltaTime;
							Music.Play();
						}
						Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
					}
				}
			}
			if (Input.GetButtonDown(InputNames.Xbox_Start))
			{
				if (Time.timeScale > 0f)
				{
					PauseLabel.SetActive(value: true);
					Time.timeScale = 0f;
				}
				else
				{
					PauseLabel.SetActive(value: false);
					Time.timeScale = 1f;
				}
			}
		}
		else if (!Cutscene)
		{
			White.alpha = Mathf.MoveTowards(White.alpha, 0f, Time.unscaledDeltaTime * 0.5f);
			if (White.alpha == 0f)
			{
				Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1f, Time.unscaledDeltaTime);
				if (Defeated)
				{
					MyAnimation.CrossFade(DefeatAnim);
					VictoryLabel.text = "DEFEAT!";
				}
				VictoryLabel.transform.localScale = Vector3.Lerp(VictoryLabel.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime);
				VictoryLabel.alpha = Mathf.Lerp(VictoryLabel.alpha, 1f, Time.deltaTime);
				IntroTimer += Time.deltaTime;
				if (IntroTimer > 5f)
				{
					Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime * 0.5f);
					Music.volume -= Time.deltaTime * 0.5f;
					if (Darkness.alpha == 1f)
					{
						if (GameGlobals.Eighties && !Defeated)
						{
							Cutscene = true;
							Dialogue.clip = DialogueClips[CutsceneID];
							Dialogue.Play();
							Subtitle.text = DialogueText[CutsceneID];
						}
						else
						{
							Quit();
						}
					}
				}
			}
			if (MyAnimation[AttackAnim[AttackID]].time >= MyAnimation[AttackAnim[AttackID]].length || MyAnimation[SuperAnim].time >= MyAnimation[SuperAnim].length)
			{
				MyAnimation.CrossFade(IdleAnim);
			}
		}
		else if (!Dialogue.isPlaying || Input.GetButtonDown(InputNames.Xbox_A))
		{
			CutsceneID++;
			if (CutsceneID < DialogueClips.Length)
			{
				Dialogue.clip = DialogueClips[CutsceneID];
				Dialogue.Play();
				Subtitle.text = DialogueText[CutsceneID];
			}
			else
			{
				GameGlobals.YakuzaPhase = 1;
				Quit();
			}
		}
	}

	public void GetNearestEnemy()
	{
		Enemy = null;
		int num = 1;
		while (num < AllEnemies.Length)
		{
			if (AllEnemies[num] != null)
			{
				if (Enemy == null && AllEnemies[num].Health > 0f)
				{
					Enemy = AllEnemies[num];
				}
				if (AllEnemies[num].Health > 0f && Vector3.Distance(base.transform.position, AllEnemies[num].transform.position) < Vector3.Distance(base.transform.position, Enemy.transform.position))
				{
					Enemy = AllEnemies[num];
				}
				num++;
			}
		}
		if (Enemy != null)
		{
			Ring.transform.position = Enemy.transform.position;
		}
	}

	public void VictoryCheck()
	{
		Enemies--;
		if (Enemies == 0)
		{
			if (Defeated)
			{
				MyAnimation.CrossFade(DefeatAnim);
			}
			Time.timeScale = 0.1f;
			Ring.gameObject.SetActive(value: false);
			HealthLabel.transform.parent.gameObject.SetActive(value: false);
			White.transform.parent.gameObject.SetActive(value: true);
			VictoryLabel.transform.localScale = Vector3.zero;
			VictoryLabel.gameObject.SetActive(value: true);
			VictoryLabel.alpha = 0f;
			IntroTimer = 0f;
			Victory = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (Rolling || other.gameObject.layer != 1)
		{
			return;
		}
		BeatEmUpHitboxScript component = other.gameObject.GetComponent<BeatEmUpHitboxScript>();
		if (component.Enemy)
		{
			AudioSource.PlayClipAtPoint(PainVoices[Random.Range(1, PainVoices.Length)], MainCamera.position);
			MyAudio.clip = HitSFX;
			MyAudio.pitch = Random.Range(0.9f, 1.1f);
			MyAudio.Play();
			Object.Instantiate(HitEffect, new Vector3(component.transform.position.x, 1.255f, component.transform.position.z), Quaternion.identity);
			Health -= component.Damage;
			HealthLabel.text = Health + " / " + MaxHealth;
			HealthBar.localScale = new Vector3(Health / MaxHealth, 1f, 1f);
			Attacking = false;
			CanMove = false;
			if (Health <= 0f)
			{
				MyAnimation.CrossFade(DefeatAnim);
				Defeated = true;
				Enemies = 1;
				VictoryCheck();
			}
			else
			{
				MyAnimation[HitReactAnim].time = 0f;
				MyAnimation.CrossFade(HitReactAnim);
				CameraVibrate = 0.1f;
				HitReacting = true;
			}
		}
	}

	private void LateUpdate()
	{
		if (HitReacting)
		{
			CameraVibrate = Mathf.MoveTowards(CameraVibrate, 0f, Time.deltaTime * 0.2f);
			MainCamera.position += new Vector3(Random.Range(CameraVibrate * -1f, CameraVibrate * 1f), Random.Range(CameraVibrate * -1f, CameraVibrate * 1f), Random.Range(CameraVibrate * -1f, CameraVibrate * 1f));
		}
	}

	public void Quit()
	{
		GameGlobals.BeatEmUpSuccess = !Defeated;
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			rootGameObjects[i].SetActive(value: true);
		}
		SceneManager.UnloadSceneAsync(41);
	}

	private void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		Profile.depthOfField.settings = settings;
	}
}
