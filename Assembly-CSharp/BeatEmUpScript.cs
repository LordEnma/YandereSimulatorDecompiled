using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x020000E1 RID: 225
public class BeatEmUpScript : MonoBehaviour
{
	// Token: 0x06000A1A RID: 2586 RVA: 0x00057FE4 File Offset: 0x000561E4
	private void Start()
	{
		this.Difficulty = GameGlobals.BeatEmUpDifficulty;
		this.MyAnimation[this.AttackAnim[1]].speed = 1f;
		this.MyAnimation[this.AttackAnim[2]].speed = 1f;
		this.MyAnimation[this.AttackAnim[3]].speed = 1f;
		this.MaxHealth -= (float)(this.Difficulty * 20);
		this.Health = this.MaxHealth;
		this.HealthLabel.text = this.Health.ToString() + " / " + this.MaxHealth.ToString();
		this.MainCamera.transform.position = new Vector3(-1f, 0.742f, 3f);
		this.MainCamera.transform.eulerAngles = new Vector3(0f, 15f, 0f);
		this.SuperLabel.text = this.SuperMeter.ToString() + " / " + this.MaxSuper.ToString();
		this.SuperBar.transform.localScale = new Vector3(0f, 1f, 1f);
		this.GrowingLabel.transform.localScale = Vector3.zero;
		this.GrowingLabel.alpha = 0f;
		this.GrowingLabel.text = this.GrowingText[1];
		this.GameplayPanel.alpha = 0f;
		this.Darkness.alpha = 1f;
		Time.timeScale = 1f;
		for (int i = 1; i < this.AllEnemies.Length; i++)
		{
			this.AllEnemies[i].DisableWeapon();
			this.AllEnemies[i].Start();
		}
		if (GameGlobals.BlondeHair)
		{
			this.PonytailRenderer.material.mainTexture = this.BlondeTexture;
		}
		if (GameGlobals.Eighties)
		{
			this.FaceTexture = this.RyobaHair.GetComponent<Renderer>().material.mainTexture;
			this.RyobaHair.transform.parent.gameObject.SetActive(true);
			this.PonytailRenderer.gameObject.SetActive(false);
			this.Music.Stop();
			this.Dialogue.clip = this.DialogueClips[this.CutsceneID];
			this.Dialogue.Play();
			this.Subtitle.text = this.DialogueText[this.CutsceneID];
			this.Cutscene = true;
			this.IncineratorScene.SetActive(false);
			this.StreetScene.SetActive(true);
			this.RightBreast.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			this.LeftBreast.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			this.Eighties = true;
		}
		else
		{
			this.RyobaHair.transform.parent.gameObject.SetActive(false);
		}
		this.ChangeSchoolwear();
		this.Profile.motionBlur.enabled = false;
		this.UpdateDOF(2f);
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x00058328 File Offset: 0x00056528
	private void ChangeSchoolwear()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[0].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[1].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		if (this.Eighties)
		{
			this.MyRenderer.materials[0].mainTexture = this.EightiesUniformTexture;
		}
	}

	// Token: 0x06000A1C RID: 2588 RVA: 0x000583C0 File Offset: 0x000565C0
	private void Update()
	{
		if (!this.Victory)
		{
			if (!this.Intro)
			{
				this.GetNearestEnemy();
				this.EnemyHealthBar.localScale = new Vector3(this.Enemy.Health / this.Enemy.MaxHealth, 1f, 1f);
				this.EnemyNameLabel.text = this.Enemy.Name;
			}
			this.MyController.Move(Physics.gravity * Time.deltaTime);
			float axis = Input.GetAxis("Vertical");
			float axis2 = Input.GetAxis("Horizontal");
			Vector3 vector = this.MainCamera.TransformDirection(Vector3.forward);
			vector.y = 0f;
			vector = vector.normalized;
			Vector3 a = new Vector3(vector.z, 0f, -vector.x);
			Vector3 vector2 = axis2 * a + axis * vector;
			Quaternion quaternion = Quaternion.identity;
			if (vector2 != Vector3.zero)
			{
				quaternion = Quaternion.LookRotation(vector2);
			}
			if (vector2 != Vector3.zero)
			{
				if (this.CanMove)
				{
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, quaternion, Time.deltaTime * 10f);
				}
			}
			else
			{
				quaternion = new Quaternion(0f, 0f, 0f, 0f);
			}
			if ((this.CanMove || (!this.CanMove && this.Attacking)) && Input.GetButtonDown("A"))
			{
				this.Attacking = false;
				this.CanMove = false;
				this.Rolling = true;
				this.RollSpeed = this.MaxRollSpeed;
				if (vector2 != Vector3.zero)
				{
					base.transform.rotation = Quaternion.LookRotation(vector2);
					this.RollDirection = 1;
				}
				else
				{
					this.RollDirection = -1;
				}
				this.MyController.Move(base.transform.forward * this.RollSpeed * (float)this.RollDirection * Time.deltaTime);
				this.MyAnimation[this.RollAnim].speed = 0f;
				this.MyAnimation[this.RollAnim].time = 0f;
				this.MyAnimation.CrossFade(this.RollAnim);
			}
			if (this.CanMove)
			{
				if (axis != 0f || axis2 != 0f)
				{
					this.MyAnimation.CrossFade(this.RunAnim);
					this.MyController.Move(base.transform.forward * this.RunSpeed * Time.deltaTime);
				}
				else
				{
					this.MyAnimation.CrossFade(this.IdleAnim);
				}
				if (Input.GetButtonDown("X") || Input.GetButtonDown("Y"))
				{
					this.MyAudio.clip = this.AttackVoices[UnityEngine.Random.Range(1, this.AttackVoices.Length)];
					this.MyAudio.Play();
					this.MySecondAudio.clip = this.Whoosh;
					this.MySecondAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
					this.MySecondAudio.Play();
					this.HitboxSpawned = false;
					this.Attacking = true;
					this.CanMove = false;
					this.Heavy = false;
					quaternion = Quaternion.LookRotation(this.Enemy.transform.position - base.transform.position);
					base.transform.rotation = quaternion;
					if (Input.GetButtonDown("Y"))
					{
						this.Heavy = true;
					}
					if (!this.Heavy)
					{
						this.AttackID = 1;
						this.AttackLimit = 7;
					}
					else
					{
						this.AttackID = 11;
						this.AttackLimit = 14;
					}
					this.MyAnimation[this.AttackAnim[this.AttackID]].time = 0f;
					this.MyAnimation.Play(this.AttackAnim[this.AttackID]);
				}
				else if (this.SuperMeter >= 100f && Input.GetButtonDown("B"))
				{
					this.MyAudio.clip = this.AttackVoices[UnityEngine.Random.Range(1, this.AttackVoices.Length)];
					this.MyAudio.Play();
					this.MySecondAudio.clip = this.Whoosh;
					this.MySecondAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
					this.MySecondAudio.Play();
					this.MyController.enabled = false;
					this.HitboxSpawned = false;
					this.CanMove = false;
					this.Super = true;
					this.SuperMeter -= 100f;
					this.SuperLabel.text = this.SuperMeter.ToString() + " / " + this.MaxSuper.ToString();
					this.SuperBar.transform.localScale = new Vector3(this.SuperMeter / this.MaxSuper, 1f, 1f);
					if (this.SuperMeter < 100f)
					{
						this.SuperButton.alpha = 0.5f;
					}
					quaternion = Quaternion.LookRotation(this.Enemy.transform.position - base.transform.position);
					base.transform.rotation = quaternion;
					this.MyAnimation[this.SuperAnim].time = 0f;
					this.MyAnimation.Play(this.SuperAnim);
				}
			}
			else if (this.Rolling)
			{
				this.RollSpeed = this.MaxRollSpeed * (1f - this.RollTimer / this.MyAnimation[this.RollAnim].length);
				this.MyController.Move(base.transform.forward * this.RollSpeed * (float)this.RollDirection * Time.deltaTime);
				this.RollTimer += Time.deltaTime * 2f;
				if (this.RollDirection > 0)
				{
					this.MyAnimation[this.RollAnim].time = this.RollTimer;
				}
				else
				{
					this.MyAnimation[this.RollAnim].time = this.MyAnimation[this.RollAnim].length - this.RollTimer;
				}
				if (this.RollTimer >= this.MyAnimation[this.RollAnim].length)
				{
					this.MyAnimation.CrossFade(this.IdleAnim);
					this.MyAnimation[this.RollAnim].speed = 0f;
					this.Rolling = false;
					this.CanMove = true;
					this.RollTimer = 0f;
				}
			}
			else if (this.Attacking)
			{
				if (this.MyAnimation[this.AttackAnim[this.AttackID]].time >= this.MyAnimation[this.AttackAnim[this.AttackID]].length)
				{
					this.MyAnimation.CrossFade(this.IdleAnim);
					this.Attacking = false;
					this.CanMove = true;
				}
				else if (this.MyAnimation[this.AttackAnim[this.AttackID]].time >= this.MyAnimation[this.AttackAnim[this.AttackID]].length * 0.5f)
				{
					if (this.Combo)
					{
						base.transform.LookAt(this.Ring.position);
						this.MyAudio.clip = this.AttackVoices[UnityEngine.Random.Range(1, this.AttackVoices.Length)];
						this.MyAudio.Play();
						this.MySecondAudio.clip = this.Whoosh;
						this.MySecondAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
						this.MySecondAudio.Play();
						this.AttackID++;
						this.MyAnimation[this.AttackAnim[this.AttackID]].time = 0f;
						this.MyAnimation.Play(this.AttackAnim[this.AttackID]);
						this.HitboxSpawned = false;
						this.Combo = false;
					}
					else if (this.AttackID < this.AttackLimit)
					{
						if (!this.Heavy && Input.GetButtonDown("X"))
						{
							this.Combo = true;
						}
						else if (this.Heavy && Input.GetButtonDown("Y"))
						{
							this.Combo = true;
						}
					}
				}
				else if (this.AttackID < this.AttackLimit)
				{
					if (!this.Heavy && Input.GetButtonDown("X"))
					{
						this.Combo = true;
					}
					else if (this.Heavy && Input.GetButtonDown("Y"))
					{
						this.Combo = true;
					}
				}
				if (!this.HitboxSpawned)
				{
					if (this.AttackID < 14)
					{
						if (this.MyAnimation[this.AttackAnim[this.AttackID]].time >= this.MyAnimation[this.AttackAnim[this.AttackID]].length * 0.4f)
						{
							if (!this.Heavy)
							{
								BeatEmUpHitboxScript component = UnityEngine.Object.Instantiate<GameObject>(this.Hitbox, base.transform.position + base.transform.forward * 0.45f + new Vector3(0f, 1f, 0f), base.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
								component.Damage = this.Damages[this.AttackID];
								component.AttackID = this.AttackID;
							}
							else
							{
								BeatEmUpHitboxScript component2 = UnityEngine.Object.Instantiate<GameObject>(this.Hitbox, base.transform.position + base.transform.forward * 0.75f + new Vector3(0f, 1f, 0f), base.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
								component2.Damage = this.Damages[this.AttackID];
								component2.Heavy = true;
							}
							this.HitboxSpawned = true;
						}
					}
					else if (this.AttackID == 14 && this.MyAnimation[this.AttackAnim[this.AttackID]].time >= 0.525f)
					{
						BeatEmUpHitboxScript component3 = UnityEngine.Object.Instantiate<GameObject>(this.Hitbox, base.transform.position + base.transform.forward * 0.75f + new Vector3(0f, 1f, 0f), base.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
						component3.Damage = this.Damages[this.AttackID];
						component3.AttackID = this.AttackID;
						component3.Heavy = true;
						this.HitboxSpawned = true;
					}
				}
			}
			else if (this.Super)
			{
				this.IntroTimer += Time.deltaTime;
				this.SuperTimer += Time.deltaTime;
				if (this.IntroTimer > 0.1f)
				{
					this.MyAudio.clip = this.AttackVoices[UnityEngine.Random.Range(1, this.AttackVoices.Length)];
					this.MyAudio.Play();
					this.MySecondAudio.clip = this.Whoosh;
					this.MySecondAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
					this.MySecondAudio.Play();
					BeatEmUpHitboxScript component4 = UnityEngine.Object.Instantiate<GameObject>(this.Hitbox, base.transform.position + base.transform.forward * 0.45f + new Vector3(0f, 1f, 0f), base.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
					component4.Super = true;
					component4.Damage = 5f;
					this.IntroTimer = 0f;
				}
				if (this.SuperTimer > 2.1f)
				{
					this.MyController.enabled = true;
					this.CanMove = true;
					this.Super = false;
					this.IntroTimer = 0f;
					this.SuperTimer = 0f;
				}
			}
			else if (this.HitReacting)
			{
				if (this.MyAnimation[this.HitReactAnim].time >= this.MyAnimation[this.HitReactAnim].length)
				{
					this.MyAnimation.CrossFade(this.IdleAnim);
					this.HitReacting = false;
					this.CanMove = true;
				}
			}
			else if (this.Intro)
			{
				if (this.Cutscene)
				{
					if (!this.Dialogue.isPlaying || Input.GetButtonDown("A"))
					{
						this.CutsceneID++;
						if (this.CutsceneID < 3)
						{
							this.Dialogue.clip = this.DialogueClips[this.CutsceneID];
							this.Dialogue.Play();
							this.Subtitle.text = this.DialogueText[this.CutsceneID];
						}
						else
						{
							this.Music.clip = this.EightiesTrack;
							this.Cutscene = false;
							this.Subtitle.text = "";
						}
					}
				}
				else
				{
					this.IntroTimer += Time.deltaTime;
					if (this.IntroTimer > 2.66666f)
					{
						this.CameraSpeed += Time.deltaTime * (0.1f + this.CameraSpeed);
						this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, new Vector3(0f, 1.773969f, -7.888118f), Time.deltaTime * this.CameraSpeed);
						this.MainCamera.transform.eulerAngles = Vector3.Lerp(this.MainCamera.transform.eulerAngles, new Vector3(15f, 0f, 0f), Time.deltaTime * this.CameraSpeed);
						if (this.IntroTimer > 5f)
						{
							this.GrowingLabel.transform.localScale += new Vector3(5f, 5f, 5f) * Time.deltaTime;
							if (this.GrowingLabel.transform.localScale.x <= 1f)
							{
								this.GrowingLabel.alpha = Mathf.MoveTowards(this.GrowingLabel.alpha, 1f, Time.deltaTime * 5f);
							}
							else if (this.GrowingLabel.transform.localScale.x >= 2f)
							{
								this.GrowingLabel.alpha = Mathf.MoveTowards(this.GrowingLabel.alpha, 0f, Time.deltaTime * 5f);
								if (this.GrowingLabel.alpha == 0f)
								{
									this.TextID++;
									if (this.TextID < this.GrowingText.Length)
									{
										this.GrowingLabel.text = this.GrowingText[this.TextID];
										this.GrowingLabel.transform.localScale = Vector3.zero;
									}
								}
							}
						}
						else if (this.IntroTimer > 4f)
						{
							this.GameplayPanel.alpha = Mathf.MoveTowards(this.GameplayPanel.alpha, 1f, Time.deltaTime);
						}
						if (!this.Music.isPlaying || this.IntroTimer > 7.5f)
						{
							this.GrowingLabel.transform.localScale = Vector3.zero;
							this.GameplayPanel.alpha = 1f;
							if (!this.Eighties)
							{
								this.Music.clip = this.MusicLoop;
								this.Music.Play();
							}
							this.Music.loop = true;
							this.RPGCamera.enabled = true;
							this.CanMove = true;
							this.Intro = false;
							int i = 1;
							while (i < this.AllEnemies.Length)
							{
								if (this.AllEnemies[i] != null)
								{
									this.AllEnemies[i].enabled = true;
									i++;
								}
							}
						}
					}
					else if (this.IntroTimer > 1f)
					{
						if (!this.Music.isPlaying)
						{
							this.CameraSpeed += Time.deltaTime;
							this.Music.Play();
						}
						this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime);
					}
				}
			}
			if (Input.GetButtonDown("Start"))
			{
				if (Time.timeScale > 0f)
				{
					this.PauseLabel.SetActive(true);
					Time.timeScale = 0f;
					return;
				}
				this.PauseLabel.SetActive(false);
				Time.timeScale = 1f;
				return;
			}
		}
		else if (!this.Cutscene)
		{
			this.White.alpha = Mathf.MoveTowards(this.White.alpha, 0f, Time.unscaledDeltaTime * 0.5f);
			if (this.White.alpha == 0f)
			{
				Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1f, Time.unscaledDeltaTime);
				if (this.Defeated)
				{
					this.MyAnimation.CrossFade(this.DefeatAnim);
					this.VictoryLabel.text = "DEFEAT!";
				}
				this.VictoryLabel.transform.localScale = Vector3.Lerp(this.VictoryLabel.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime);
				this.VictoryLabel.alpha = Mathf.Lerp(this.VictoryLabel.alpha, 1f, Time.deltaTime);
				this.IntroTimer += Time.deltaTime;
				if (this.IntroTimer > 5f)
				{
					this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime * 0.5f);
					this.Music.volume -= Time.deltaTime * 0.5f;
					if (this.Darkness.alpha == 1f)
					{
						if (GameGlobals.Eighties && !this.Defeated)
						{
							this.Cutscene = true;
							this.Dialogue.clip = this.DialogueClips[this.CutsceneID];
							this.Dialogue.Play();
							this.Subtitle.text = this.DialogueText[this.CutsceneID];
						}
						else
						{
							this.Quit();
						}
					}
				}
			}
			if (this.MyAnimation[this.AttackAnim[this.AttackID]].time >= this.MyAnimation[this.AttackAnim[this.AttackID]].length || this.MyAnimation[this.SuperAnim].time >= this.MyAnimation[this.SuperAnim].length)
			{
				this.MyAnimation.CrossFade(this.IdleAnim);
				return;
			}
		}
		else if (!this.Dialogue.isPlaying || Input.GetButtonDown("A"))
		{
			this.CutsceneID++;
			if (this.CutsceneID < this.DialogueClips.Length)
			{
				this.Dialogue.clip = this.DialogueClips[this.CutsceneID];
				this.Dialogue.Play();
				this.Subtitle.text = this.DialogueText[this.CutsceneID];
				return;
			}
			GameGlobals.YakuzaPhase = 1;
			this.Quit();
		}
	}

	// Token: 0x06000A1D RID: 2589 RVA: 0x000597C4 File Offset: 0x000579C4
	public void GetNearestEnemy()
	{
		this.Enemy = null;
		int i = 1;
		while (i < this.AllEnemies.Length)
		{
			if (this.AllEnemies[i] != null)
			{
				if (this.Enemy == null && this.AllEnemies[i].Health > 0f)
				{
					this.Enemy = this.AllEnemies[i];
				}
				if (this.AllEnemies[i].Health > 0f && Vector3.Distance(base.transform.position, this.AllEnemies[i].transform.position) < Vector3.Distance(base.transform.position, this.Enemy.transform.position))
				{
					this.Enemy = this.AllEnemies[i];
				}
				i++;
			}
		}
		if (this.Enemy != null)
		{
			this.Ring.transform.position = this.Enemy.transform.position;
		}
	}

	// Token: 0x06000A1E RID: 2590 RVA: 0x000598C8 File Offset: 0x00057AC8
	public void VictoryCheck()
	{
		this.Enemies--;
		if (this.Enemies == 0)
		{
			if (this.Defeated)
			{
				this.MyAnimation.CrossFade(this.DefeatAnim);
			}
			Time.timeScale = 0.1f;
			this.Ring.gameObject.SetActive(false);
			this.HealthLabel.transform.parent.gameObject.SetActive(false);
			this.White.transform.parent.gameObject.SetActive(true);
			this.VictoryLabel.transform.localScale = Vector3.zero;
			this.VictoryLabel.gameObject.SetActive(true);
			this.VictoryLabel.alpha = 0f;
			this.IntroTimer = 0f;
			this.Victory = true;
		}
	}

	// Token: 0x06000A1F RID: 2591 RVA: 0x000599A0 File Offset: 0x00057BA0
	private void OnTriggerEnter(Collider other)
	{
		if (!this.Rolling && other.gameObject.layer == 1)
		{
			BeatEmUpHitboxScript component = other.gameObject.GetComponent<BeatEmUpHitboxScript>();
			if (component.Enemy)
			{
				AudioSource.PlayClipAtPoint(this.PainVoices[UnityEngine.Random.Range(1, this.PainVoices.Length)], this.MainCamera.position);
				this.MyAudio.clip = this.HitSFX;
				this.MyAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				this.MyAudio.Play();
				UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, new Vector3(component.transform.position.x, 1.255f, component.transform.position.z), Quaternion.identity);
				this.Health -= component.Damage;
				this.HealthLabel.text = this.Health.ToString() + " / " + this.MaxHealth.ToString();
				this.HealthBar.localScale = new Vector3(this.Health / this.MaxHealth, 1f, 1f);
				this.Attacking = false;
				this.CanMove = false;
				if (this.Health <= 0f)
				{
					this.MyAnimation.CrossFade(this.DefeatAnim);
					this.Defeated = true;
					this.Enemies = 1;
					this.VictoryCheck();
					return;
				}
				this.MyAnimation[this.HitReactAnim].time = 0f;
				this.MyAnimation.CrossFade(this.HitReactAnim);
				this.CameraVibrate = 0.1f;
				this.HitReacting = true;
			}
		}
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x00059B5C File Offset: 0x00057D5C
	private void LateUpdate()
	{
		if (this.HitReacting)
		{
			this.CameraVibrate = Mathf.MoveTowards(this.CameraVibrate, 0f, Time.deltaTime * 0.2f);
			this.MainCamera.position += new Vector3(UnityEngine.Random.Range(this.CameraVibrate * -1f, this.CameraVibrate * 1f), UnityEngine.Random.Range(this.CameraVibrate * -1f, this.CameraVibrate * 1f), UnityEngine.Random.Range(this.CameraVibrate * -1f, this.CameraVibrate * 1f));
		}
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x00059C08 File Offset: 0x00057E08
	public void Quit()
	{
		GameGlobals.BeatEmUpSuccess = !this.Defeated;
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			rootGameObjects[i].SetActive(true);
		}
		SceneManager.UnloadSceneAsync(41);
	}

	// Token: 0x06000A22 RID: 2594 RVA: 0x00059C50 File Offset: 0x00057E50
	private void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x04000B19 RID: 2841
	public CharacterController MyController;

	// Token: 0x04000B1A RID: 2842
	public BeatEmUpEnemyScript[] AllEnemies;

	// Token: 0x04000B1B RID: 2843
	public PostProcessingProfile Profile;

	// Token: 0x04000B1C RID: 2844
	public BeatEmUpEnemyScript Enemy;

	// Token: 0x04000B1D RID: 2845
	public RPG_Camera RPGCamera;

	// Token: 0x04000B1E RID: 2846
	public AudioClip[] AttackVoices;

	// Token: 0x04000B1F RID: 2847
	public AudioClip[] PainVoices;

	// Token: 0x04000B20 RID: 2848
	public Transform EnemyHealthBar;

	// Token: 0x04000B21 RID: 2849
	public Transform HealthBar;

	// Token: 0x04000B22 RID: 2850
	public Transform SuperBar;

	// Token: 0x04000B23 RID: 2851
	public AudioSource MySecondAudio;

	// Token: 0x04000B24 RID: 2852
	public AudioSource MyAudio;

	// Token: 0x04000B25 RID: 2853
	public AudioSource Music;

	// Token: 0x04000B26 RID: 2854
	public AudioClip EightiesTrack;

	// Token: 0x04000B27 RID: 2855
	public UILabel EnemyNameLabel;

	// Token: 0x04000B28 RID: 2856
	public UILabel GrowingLabel;

	// Token: 0x04000B29 RID: 2857
	public UILabel VictoryLabel;

	// Token: 0x04000B2A RID: 2858
	public UILabel HealthLabel;

	// Token: 0x04000B2B RID: 2859
	public UILabel SuperLabel;

	// Token: 0x04000B2C RID: 2860
	public Animation MyAnimation;

	// Token: 0x04000B2D RID: 2861
	public UIPanel GameplayPanel;

	// Token: 0x04000B2E RID: 2862
	public UISprite SuperButton;

	// Token: 0x04000B2F RID: 2863
	public GameObject PauseLabel;

	// Token: 0x04000B30 RID: 2864
	public GameObject HitEffect;

	// Token: 0x04000B31 RID: 2865
	public GameObject Hitbox;

	// Token: 0x04000B32 RID: 2866
	public Transform MainCamera;

	// Token: 0x04000B33 RID: 2867
	public Transform Ring;

	// Token: 0x04000B34 RID: 2868
	public Transform RightBreast;

	// Token: 0x04000B35 RID: 2869
	public Transform LeftBreast;

	// Token: 0x04000B36 RID: 2870
	public Transform RightFoot;

	// Token: 0x04000B37 RID: 2871
	public Transform RightHand;

	// Token: 0x04000B38 RID: 2872
	public Transform LeftHand;

	// Token: 0x04000B39 RID: 2873
	public AudioClip MusicLoop;

	// Token: 0x04000B3A RID: 2874
	public AudioClip HitSFX;

	// Token: 0x04000B3B RID: 2875
	public AudioClip Whoosh;

	// Token: 0x04000B3C RID: 2876
	public UISprite Darkness;

	// Token: 0x04000B3D RID: 2877
	public UISprite White;

	// Token: 0x04000B3E RID: 2878
	public int RollDirection = 1;

	// Token: 0x04000B3F RID: 2879
	public int AttackLimit;

	// Token: 0x04000B40 RID: 2880
	public int Difficulty = 1;

	// Token: 0x04000B41 RID: 2881
	public int AttackID = 1;

	// Token: 0x04000B42 RID: 2882
	public int Enemies = 2;

	// Token: 0x04000B43 RID: 2883
	public int TextID = 1;

	// Token: 0x04000B44 RID: 2884
	public bool HitboxSpawned;

	// Token: 0x04000B45 RID: 2885
	public bool HitReacting;

	// Token: 0x04000B46 RID: 2886
	public bool Attacking;

	// Token: 0x04000B47 RID: 2887
	public bool Defeated;

	// Token: 0x04000B48 RID: 2888
	public bool Eighties;

	// Token: 0x04000B49 RID: 2889
	public bool CanMove;

	// Token: 0x04000B4A RID: 2890
	public bool Rolling;

	// Token: 0x04000B4B RID: 2891
	public bool Victory;

	// Token: 0x04000B4C RID: 2892
	public bool Super;

	// Token: 0x04000B4D RID: 2893
	public bool Combo;

	// Token: 0x04000B4E RID: 2894
	public bool Heavy;

	// Token: 0x04000B4F RID: 2895
	public bool Intro;

	// Token: 0x04000B50 RID: 2896
	public string[] GrowingText;

	// Token: 0x04000B51 RID: 2897
	public string[] AttackAnim;

	// Token: 0x04000B52 RID: 2898
	public float[] Damages;

	// Token: 0x04000B53 RID: 2899
	public float CameraVibrate;

	// Token: 0x04000B54 RID: 2900
	public float MaxRollSpeed;

	// Token: 0x04000B55 RID: 2901
	public float CameraSpeed;

	// Token: 0x04000B56 RID: 2902
	public float IntroTimer;

	// Token: 0x04000B57 RID: 2903
	public float SuperTimer;

	// Token: 0x04000B58 RID: 2904
	public float RollSpeed;

	// Token: 0x04000B59 RID: 2905
	public float RollTimer;

	// Token: 0x04000B5A RID: 2906
	public float RunSpeed;

	// Token: 0x04000B5B RID: 2907
	public float MaxHealth;

	// Token: 0x04000B5C RID: 2908
	public float Health;

	// Token: 0x04000B5D RID: 2909
	public float SuperMeter;

	// Token: 0x04000B5E RID: 2910
	public float MaxSuper;

	// Token: 0x04000B5F RID: 2911
	public string HitReactAnim;

	// Token: 0x04000B60 RID: 2912
	public string DefeatAnim;

	// Token: 0x04000B61 RID: 2913
	public string SuperAnim;

	// Token: 0x04000B62 RID: 2914
	public string IdleAnim;

	// Token: 0x04000B63 RID: 2915
	public string RollAnim;

	// Token: 0x04000B64 RID: 2916
	public string RunAnim;

	// Token: 0x04000B65 RID: 2917
	public Renderer PonytailRenderer;

	// Token: 0x04000B66 RID: 2918
	public Texture EightiesUniformTexture;

	// Token: 0x04000B67 RID: 2919
	public Texture BlondeTexture;

	// Token: 0x04000B68 RID: 2920
	public AudioClip[] DialogueClips;

	// Token: 0x04000B69 RID: 2921
	public string[] DialogueText;

	// Token: 0x04000B6A RID: 2922
	public AudioSource Dialogue;

	// Token: 0x04000B6B RID: 2923
	public UILabel Subtitle;

	// Token: 0x04000B6C RID: 2924
	public int CutsceneID;

	// Token: 0x04000B6D RID: 2925
	public bool Cutscene;

	// Token: 0x04000B6E RID: 2926
	public GameObject IncineratorScene;

	// Token: 0x04000B6F RID: 2927
	public GameObject StreetScene;

	// Token: 0x04000B70 RID: 2928
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04000B71 RID: 2929
	public Texture[] UniformTextures;

	// Token: 0x04000B72 RID: 2930
	public Texture FaceTexture;

	// Token: 0x04000B73 RID: 2931
	public Mesh[] Uniforms;

	// Token: 0x04000B74 RID: 2932
	public GameObject RyobaHair;
}
