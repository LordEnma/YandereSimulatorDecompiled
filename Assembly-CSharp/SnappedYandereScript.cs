using UnityEngine;
using UnityEngine.SceneManagement;

public class SnappedYandereScript : MonoBehaviour
{
	public CharacterController MyController;

	public CameraFilterPack_FX_Glitch1 Glitch1;

	public CameraFilterPack_FX_Glitch2 Glitch2;

	public CameraFilterPack_FX_Glitch3 Glitch3;

	public CameraFilterPack_Glitch_Mozaic Glitch4;

	public CameraFilterPack_NewGlitch1 Glitch5;

	public CameraFilterPack_NewGlitch2 Glitch6;

	public CameraFilterPack_NewGlitch3 Glitch7;

	public CameraFilterPack_NewGlitch4 Glitch8;

	public CameraFilterPack_NewGlitch5 Glitch9;

	public CameraFilterPack_NewGlitch6 Glitch10;

	public CameraFilterPack_NewGlitch7 Glitch11;

	public CameraFilterPack_TV_CompressionFX CompressionFX;

	public CameraFilterPack_TV_Distorted Distorted;

	public CameraFilterPack_Blur_Tilt_Shift TiltShift;

	public CameraFilterPack_Blur_Tilt_Shift_V TiltShiftV;

	public CameraFilterPack_Noise_TV Static;

	public StudentManagerScript StudentManager;

	public SnapStudentScript TargetStudent;

	public InputDeviceScript InputDevice;

	public GameObject StabBloodEffect;

	public GameObject BloodEffect;

	public GameObject NewDoIt;

	public WeaponScript Knife;

	public AudioListener MyListener;

	public Transform SnapAttackPivot;

	public Transform FinalSnapPOV;

	public Transform SuicidePOV;

	public Transform RightFoot;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform Spine;

	public AudioSource StaticNoise;

	public AudioSource AttackAudio;

	public AudioSource SnapStatic;

	public AudioSource SnapVoice;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public AudioSource Rumble;

	public AudioClip EndSNAP;

	public UILabel SNAPLabel;

	public Camera MainCamera;

	public Animation MyAnim;

	public AudioClip Buzz;

	public AudioClip[] Whispers;

	public AudioClip[] FemaleDeathScreams;

	public AudioClip[] MaleDeathScreams;

	public AudioClip[] AttackSFX;

	public GameObject DoIt;

	public UISprite SuicideSprite;

	public UILabel SuicidePrompt;

	public bool KillingSenpai;

	public bool Attacking;

	public bool CanMove;

	public bool SpeedUp;

	public bool Whisper;

	public bool Armed;

	public string IdleAnim;

	public string WalkAnim;

	public float ImpatienceLimit;

	public float GlitchTimeLimit;

	public float WhisperTimer;

	public float AttackTimer;

	public float GlitchTimer;

	public float ImpatienceTimer;

	public float ListenTimer;

	public float HurryTimer;

	public float AnimSpeed;

	public float Target;

	public float Speed;

	public int BloodSpawned;

	public int AttackPhase;

	public int Teleports;

	public int AttackID;

	public int VoiceID;

	public int Attacks;

	public int Taps;

	public string[] AttackAnims;

	public WeaponScript[] Weapons;

	public bool[] AttacksUsed;

	private void Start()
	{
		MyAnim[AttackAnims[1]].speed = 1.5f;
		MyAnim[AttackAnims[2]].speed = 1.5f;
		MyAnim[AttackAnims[3]].speed = 1.5f;
		MyAnim[AttackAnims[4]].speed = 1.5f;
		MyAnim[AttackAnims[5]].speed = 1.5f;
		if (ClubGlobals.GetClubClosed(ClubType.Cooking))
		{
			Weapons[0] = null;
			Weapons[5] = null;
		}
		if (ClubGlobals.GetClubClosed(ClubType.Art))
		{
			Weapons[3] = null;
		}
		if (ClubGlobals.GetClubClosed(ClubType.Occult))
		{
			Weapons[6] = null;
		}
	}

	private void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (Input.GetKeyDown("=") && Time.timeScale < 10f)
		{
			Time.timeScale += 1f;
		}
		if (Input.GetKeyDown("-") && Time.timeScale > 1f)
		{
			Time.timeScale -= 1f;
		}
		if (Glitch1.enabled)
		{
			if (Attacking)
			{
				GlitchTimer += Time.deltaTime * MyAnim[AttackAnims[AttackID]].speed;
			}
			else
			{
				GlitchTimer += Time.deltaTime;
			}
			if (GlitchTimer > GlitchTimeLimit)
			{
				SetGlitches(State: false);
				if (MyAudio.clip != EndSNAP)
				{
					MyAudio.Stop();
				}
				if (Attacking)
				{
					SnapAttackPivot.position = TargetStudent.Student.Head.position;
					SnapAttackPivot.localEulerAngles = new Vector3(0f, 0f, 0f);
					MainCamera.transform.parent = SnapAttackPivot;
					MainCamera.transform.localPosition = new Vector3(0f, 0f, -1f);
					MainCamera.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					SnapAttackPivot.localEulerAngles = new Vector3(Random.Range(-45f, 45f), Random.Range(0f, 360f), 0f);
					while (MainCamera.transform.position.y < base.transform.position.y + 0.1f)
					{
						SnapAttackPivot.localEulerAngles = new Vector3(Random.Range(-45f, 45f), Random.Range(0f, 360f), 0f);
					}
					MyAnim[AttackAnims[AttackID]].time = 0f;
					MyAnim.Play(AttackAnims[AttackID]);
					MyAnim[AttackAnims[AttackID]].time = 0f;
					MyAnim[AttackAnims[AttackID]].speed += 0.1f;
					TargetStudent.MyAnim[TargetStudent.AttackAnims[AttackID]].time = 0f;
					TargetStudent.MyAnim.Play(TargetStudent.AttackAnims[AttackID]);
					TargetStudent.MyAnim[TargetStudent.AttackAnims[AttackID]].time = 0f;
					TargetStudent.MyAnim[TargetStudent.AttackAnims[AttackID]].speed = MyAnim[AttackAnims[AttackID]].speed;
					if (TargetStudent.Student.Male)
					{
						MyAudio.clip = MaleDeathScreams[Random.Range(0, MaleDeathScreams.Length)];
						MyAudio.pitch = 1f;
						MyAudio.Play();
					}
					else
					{
						MyAudio.clip = FemaleDeathScreams[Random.Range(0, FemaleDeathScreams.Length)];
						MyAudio.pitch = 1f;
						MyAudio.Play();
					}
					AttackAudio.clip = AttackSFX[AttackID];
					AttackAudio.pitch = MyAnim[AttackAnims[AttackID]].speed;
					AttackAudio.Play();
				}
			}
		}
		if (!Armed)
		{
			WeaponScript[] weapons = Weapons;
			foreach (WeaponScript weaponScript in weapons)
			{
				if (weaponScript != null && weaponScript.gameObject.activeInHierarchy && Vector3.Distance(base.transform.position, weaponScript.transform.position) < 1.5f)
				{
					weaponScript.Prompt.Circle[3].fillAmount = 0f;
					SNAPLabel.text = "Kill him.";
					StaticNoise.volume = 0f;
					Static.Fade = 0f;
					HurryTimer = 0f;
					Knife = weaponScript;
					Armed = true;
				}
			}
		}
		else
		{
			Knife.gameObject.SetActive(value: true);
		}
		if (CanMove)
		{
			SNAPLabel.alpha = Mathf.MoveTowards(SNAPLabel.alpha, 1f, Time.deltaTime * 0.2f);
			HurryTimer += Time.deltaTime;
			if (HurryTimer > 40f || base.transform.position.y < -0.1f || StudentManager.MaleLockerRoomArea.bounds.Contains(base.transform.position))
			{
				Teleport();
				HurryTimer = 0f;
				Static.Fade = 0f;
				StaticNoise.volume = 0f;
			}
			else if (HurryTimer > 30f)
			{
				StaticNoise.volume += Time.deltaTime * 0.1f;
				Static.Fade += Time.deltaTime * 0.1f;
			}
			UpdateMovement();
		}
		else if (Attacking)
		{
			SNAPLabel.alpha = 0f;
			if (MyAnim[AttackAnims[AttackID]].speed == 0f)
			{
				MyAnim[AttackAnims[AttackID]].speed = 1f;
			}
			if (MyAnim[AttackAnims[AttackID]].time >= MyAnim[AttackAnims[AttackID]].length)
			{
				if (Attacks < 5)
				{
					ChooseAttack();
				}
				else
				{
					MainCamera.transform.parent = base.transform;
					MainCamera.transform.localPosition = new Vector3(0.25f, 1.546664f, -0.5473595f);
					MainCamera.transform.localEulerAngles = new Vector3(15f, 0f, 0f);
					SetGlitches(State: true);
					GlitchTimeLimit = 0.5f;
					TargetStudent.Student.BecomeRagdoll();
					AttacksUsed[1] = false;
					AttacksUsed[2] = false;
					AttacksUsed[3] = false;
					AttacksUsed[4] = false;
					AttacksUsed[5] = false;
					Attacking = false;
					CanMove = true;
					Attacks = 0;
				}
			}
			else if (!Glitch1.enabled && BloodSpawned < 2)
			{
				if (AttackID == 1)
				{
					if (BloodSpawned == 0)
					{
						if (MyAnim[AttackAnims[AttackID]].time > 0.25f)
						{
							Object.Instantiate(BloodEffect, RightHand.position, Quaternion.identity);
							MyAudio.Stop();
							BloodSpawned++;
						}
					}
					else if (MyAnim[AttackAnims[AttackID]].time > 1f)
					{
						Object.Instantiate(BloodEffect, LeftHand.position, Quaternion.identity);
						BloodSpawned++;
					}
				}
				else if (AttackID == 2)
				{
					if (MyAnim[AttackAnims[AttackID]].time > 1f)
					{
						Object.Instantiate(BloodEffect, RightHand.position, Quaternion.identity);
						BloodSpawned += 2;
						MyAudio.Stop();
					}
				}
				else if (AttackID == 3)
				{
					if (MyAnim[AttackAnims[AttackID]].time > 0.5f)
					{
						Object.Instantiate(BloodEffect, RightHand.position, Quaternion.identity);
						BloodSpawned += 2;
						MyAudio.Stop();
					}
				}
				else if (AttackID == 4)
				{
					if (MyAnim[AttackAnims[AttackID]].time > 0.5f)
					{
						MyAudio.Stop();
					}
				}
				else if (AttackID == 5)
				{
					if (BloodSpawned == 0)
					{
						if (MyAnim[AttackAnims[AttackID]].time > 0.25f)
						{
							Object.Instantiate(BloodEffect, RightFoot.position, Quaternion.identity);
							MyAudio.Stop();
							BloodSpawned++;
						}
					}
					else if (MyAnim[AttackAnims[AttackID]].time > 0.9f)
					{
						Object.Instantiate(BloodEffect, RightFoot.position, Quaternion.identity);
						BloodSpawned++;
					}
				}
			}
		}
		else if (KillingSenpai)
		{
			CompressionFX.Parasite = Mathf.MoveTowards(CompressionFX.Parasite, 0f, Time.deltaTime);
			Distorted.Distortion = Mathf.MoveTowards(Distorted.Distortion, 0f, Time.deltaTime);
			StaticNoise.volume -= Time.deltaTime * 0.5f;
			Static.Fade = Mathf.MoveTowards(Static.Fade, 0f, Time.deltaTime * 0.5f);
			Jukebox.volume -= Time.deltaTime * 0.5f;
			SnapStatic.volume -= Time.deltaTime * 0.5f * 0.2f;
			SNAPLabel.alpha = Mathf.MoveTowards(SNAPLabel.alpha, 0f, Time.deltaTime * 0.5f);
			SnapVoice.volume -= Time.deltaTime;
			Quaternion b = Quaternion.LookRotation(TargetStudent.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime);
			base.transform.position = Vector3.MoveTowards(base.transform.position, TargetStudent.transform.position + TargetStudent.transform.forward * 1f, Time.deltaTime);
			Speed += Time.deltaTime;
			if (AttackPhase < 3)
			{
				MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, FinalSnapPOV.position, Time.deltaTime * Speed * 0.33333f);
				MainCamera.transform.rotation = Quaternion.Slerp(MainCamera.transform.rotation, FinalSnapPOV.rotation, Time.deltaTime * Speed * 0.33333f);
			}
			else
			{
				MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, SuicidePOV.position, Time.deltaTime * Speed * 0.1f);
				MainCamera.transform.rotation = Quaternion.Slerp(MainCamera.transform.rotation, SuicidePOV.rotation, Time.deltaTime * Speed * 0.1f);
				if (Whisper)
				{
					Rumble.volume = Mathf.MoveTowards(Rumble.volume, 0.5f, Time.deltaTime * 0.05f);
					WhisperTimer += Time.deltaTime;
					if (WhisperTimer > 0.5f)
					{
						WhisperTimer = 0f;
						int num = Random.Range(1, Whispers.Length);
						AudioSource.PlayClipAtPoint(Whispers[num], MainCamera.transform.position + new Vector3(11f - 10f * Rumble.volume * 2f, 11f - 10f * Rumble.volume * 2f, 11f - 10f * Rumble.volume * 2f));
						NewDoIt = Object.Instantiate(DoIt, SNAPLabel.parent.transform.position, Quaternion.identity);
						NewDoIt.transform.parent = SNAPLabel.parent.transform;
						NewDoIt.transform.localScale = new Vector3(1f, 1f, 1f);
						NewDoIt.transform.localPosition = new Vector3(Random.Range(-700f, 700f), Random.Range(-450f, 450f), 0f);
						NewDoIt.transform.localEulerAngles = new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), Random.Range(-15f, 15f));
					}
				}
			}
			if (AttackPhase == 0)
			{
				if (MyAnim["f02_snapKill_00"].time > MyAnim["f02_snapKill_00"].length * 0.2f)
				{
					Object.Instantiate(BloodEffect, Knife.transform.position, Quaternion.identity);
					AttackPhase++;
				}
			}
			else if (AttackPhase == 1)
			{
				if (MyAnim["f02_snapKill_00"].time > MyAnim["f02_snapKill_00"].length * 0.36f)
				{
					Object.Instantiate(BloodEffect, Knife.transform.position, Quaternion.identity);
					AttackPhase++;
				}
			}
			else if (AttackPhase == 2)
			{
				if (MyAnim["f02_snapKill_00"].time > 13f)
				{
					MyAnim["f02_stareAtKnife_00"].layer = 100;
					MyAnim.Play("f02_stareAtKnife_00");
					MyAnim["f02_stareAtKnife_00"].weight = 0f;
					Whisper = true;
					Rumble.Play();
					Speed = 0f;
					AttackPhase++;
				}
			}
			else if (AttackPhase == 3)
			{
				Knife.transform.localEulerAngles = Vector3.Lerp(Knife.transform.localEulerAngles, new Vector3(0f, 0f, 0f), Time.deltaTime * Speed);
				MyAnim["f02_stareAtKnife_00"].weight = Mathf.Lerp(MyAnim["f02_stareAtKnife_00"].weight, 1f, Time.deltaTime * Speed);
				if (MyAnim["f02_stareAtKnife_00"].weight > 0.999f)
				{
					SuicidePrompt.alpha += Time.deltaTime;
					ImpatienceTimer += Time.deltaTime;
					if (Input.GetButtonDown(InputNames.Xbox_X) || ImpatienceTimer > ImpatienceLimit)
					{
						MyAnim["f02_suicide_00"].layer = 101;
						MyAnim.Play("f02_suicide_00");
						MyAnim["f02_suicide_00"].weight = 0f;
						MyAnim["f02_suicide_00"].time = 2f;
						MyAnim["f02_suicide_00"].speed = 0f;
						AttackPhase++;
						if (ImpatienceTimer > ImpatienceLimit)
						{
							ImpatienceLimit = 2f;
							ImpatienceTimer = 0f;
						}
						Taps++;
					}
				}
			}
			else if (AttackPhase == 4)
			{
				SuicidePrompt.alpha += Time.deltaTime;
				ImpatienceTimer += Time.deltaTime;
				if (Input.GetButtonDown(InputNames.Xbox_X) || ImpatienceTimer > ImpatienceLimit)
				{
					Target += 0.1f;
					SpeedUp = true;
					if (ImpatienceTimer > ImpatienceLimit)
					{
						ImpatienceLimit = 2f;
						ImpatienceTimer = 0f;
					}
					Taps++;
				}
				if (SpeedUp)
				{
					AnimSpeed += Time.deltaTime;
					if (AnimSpeed > 1f)
					{
						SpeedUp = false;
					}
				}
				else
				{
					AnimSpeed = Mathf.MoveTowards(AnimSpeed, 0f, Time.deltaTime);
				}
				MyAnim["f02_suicide_00"].weight = Mathf.Lerp(MyAnim["f02_suicide_00"].weight, Target, AnimSpeed * Time.deltaTime);
				if (MyAnim["f02_suicide_00"].weight >= 1f)
				{
					SpeedUp = false;
					AnimSpeed = 0f;
					Target = 2f;
					AttackPhase++;
				}
			}
			else if (AttackPhase == 5)
			{
				ImpatienceTimer += Time.deltaTime;
				if (Input.GetButtonDown(InputNames.Xbox_X) || ImpatienceTimer > ImpatienceLimit)
				{
					Target += 0.1f;
					SpeedUp = true;
					if (ImpatienceTimer > ImpatienceLimit)
					{
						ImpatienceLimit = 2f;
						ImpatienceTimer = 0f;
					}
					Taps++;
				}
				if (SpeedUp)
				{
					AnimSpeed += Time.deltaTime;
					if (AnimSpeed > 1f)
					{
						SpeedUp = false;
					}
				}
				else
				{
					AnimSpeed = Mathf.MoveTowards(AnimSpeed, 0f, Time.deltaTime);
				}
				MyAnim["f02_suicide_00"].time = Mathf.Lerp(MyAnim["f02_suicide_00"].time, Target, AnimSpeed * Time.deltaTime);
				if (MyAnim["f02_suicide_00"].time >= 3.66666f)
				{
					MyAnim["f02_suicide_00"].speed = 1f;
					SuicidePrompt.alpha = 0f;
					Rumble.volume = 0f;
					Object.Destroy(NewDoIt);
					Whisper = false;
					AttackPhase++;
				}
			}
			else if (AttackPhase == 6)
			{
				if (MyAnim["f02_suicide_00"].time >= MyAnim["f02_suicide_00"].length * 0.355f)
				{
					Object.Instantiate(StabBloodEffect, Knife.transform.position, Quaternion.identity);
					AttackPhase++;
				}
			}
			else if (MyAnim["f02_suicide_00"].time >= MyAnim["f02_suicide_00"].length * 0.475f)
			{
				MyListener.enabled = false;
				MainCamera.transform.parent = null;
				MainCamera.transform.position = new Vector3(0f, 2025f, -11f);
				MainCamera.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				if (MyAnim["f02_suicide_00"].time >= MyAnim["f02_suicide_00"].length)
				{
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("SNAP", 1);
						PlayerPrefs.SetInt("a", 1);
					}
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
		if (InputDevice.Type == InputDeviceType.MouseAndKeyboard)
		{
			SuicidePrompt.text = "F";
			SuicideSprite.enabled = false;
		}
		else
		{
			SuicidePrompt.text = "";
			SuicideSprite.enabled = true;
		}
		if (ListenTimer > 0f)
		{
			ListenTimer = Mathf.MoveTowards(ListenTimer, 0f, Time.deltaTime);
		}
	}

	private void UpdateMovement()
	{
		MyController.Move(Physics.gravity * Time.deltaTime);
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		Vector3 vector = base.transform.TransformDirection(Vector3.forward);
		vector.y = 0f;
		vector = vector.normalized;
		Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
		Vector3 vector3 = axis2 * vector2 + axis * vector;
		if (Mathf.Abs(axis) > 0.5f || Mathf.Abs(axis2) > 0.5f)
		{
			MyAnim[WalkAnim].speed = Mathf.Abs(axis) + Mathf.Abs(axis2);
			if (MyAnim[WalkAnim].speed > 1f)
			{
				MyAnim[WalkAnim].speed = 1f;
			}
			MyAnim.CrossFade(WalkAnim);
			MyController.Move(vector3 * Time.deltaTime);
		}
		else
		{
			MyAnim.CrossFade(IdleAnim);
		}
		string axisName = "Mouse X";
		if (InputDevice.Type == InputDeviceType.Gamepad)
		{
			axisName = InputNames.Xbox_JoyX;
		}
		float num = Input.GetAxis(axisName) * (float)OptionGlobals.Sensitivity;
		if (num != 0f)
		{
			base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y + num * 36f * Time.deltaTime, base.transform.eulerAngles.z);
		}
		if (Input.GetButtonDown(InputNames.Xbox_LB))
		{
			MyController.Move(vector3 * 4f);
			SetGlitches(State: true);
			GlitchTimeLimit = 0.1f;
		}
	}

	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 vector = target - base.transform.position;
		MyController.Move(vector * (Time.deltaTime * 10f));
	}

	private void RotateTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	private void SetGlitches(bool State)
	{
		GlitchTimer = 0f;
		Glitch1.enabled = State;
		Glitch2.enabled = State;
		Glitch4.enabled = State;
		Glitch5.enabled = State;
		Glitch6.enabled = State;
		Glitch7.enabled = State;
		Glitch10.enabled = State;
		Glitch11.enabled = State;
		if (State)
		{
			MyAudio.clip = Buzz;
			MyAudio.volume = 0.5f;
			MyAudio.pitch = Random.Range(0.5f, 2f);
			MyAudio.Play();
		}
	}

	public void ChooseAttack()
	{
		BloodSpawned = 0;
		SetGlitches(State: true);
		GlitchTimeLimit = 0.5f;
		AttackID = Random.Range(1, 6);
		while (AttacksUsed[AttackID])
		{
			AttackID = Random.Range(1, 6);
		}
		AttacksUsed[AttackID] = true;
		Attacks++;
		if (AttackID == 1)
		{
			TargetStudent.transform.position = base.transform.position + base.transform.forward * 0.0001f;
			TargetStudent.transform.LookAt(base.transform.position);
		}
		else if (AttackID == 2)
		{
			TargetStudent.transform.position = base.transform.position + base.transform.forward * 0.5f;
			TargetStudent.transform.LookAt(base.transform.position);
		}
		else if (AttackID == 3)
		{
			TargetStudent.transform.position = base.transform.position + base.transform.forward * 0.3f;
			TargetStudent.transform.LookAt(base.transform.position);
		}
		else if (AttackID == 4)
		{
			TargetStudent.transform.position = base.transform.position + base.transform.forward * 0.3f;
			TargetStudent.transform.rotation = base.transform.rotation;
		}
		else if (AttackID == 5)
		{
			TargetStudent.transform.position = base.transform.position + base.transform.forward * 0.66666f;
			TargetStudent.transform.rotation = base.transform.rotation;
		}
		Physics.SyncTransforms();
		MyAnim.Play(AttackAnims[AttackID]);
		MyAnim[AttackAnims[AttackID]].time = 0f;
		TargetStudent.MyAnim.Play(TargetStudent.AttackAnims[AttackID]);
		TargetStudent.MyAnim[TargetStudent.AttackAnims[AttackID]].time = 0f;
	}

	public void Teleport()
	{
		if (!Armed)
		{
			bool flag = false;
			while (!flag)
			{
				WeaponScript[] weapons = Weapons;
				foreach (WeaponScript weaponScript in weapons)
				{
					if (weaponScript != null)
					{
						SetGlitches(State: true);
						GlitchTimeLimit = 1f;
						base.transform.position = weaponScript.transform.position;
						flag = true;
					}
				}
			}
		}
		else
		{
			Teleports++;
			SetGlitches(State: true);
			GlitchTimeLimit = 1f;
			if (Teleports == 1)
			{
				base.transform.position = StudentManager.Students[1].transform.position + StudentManager.Students[1].transform.forward * 2f;
				base.transform.LookAt(StudentManager.Students[1].transform.position);
			}
			else
			{
				base.transform.position = StudentManager.Students[1].transform.position + StudentManager.Students[1].transform.forward * 0.9f;
				base.transform.LookAt(StudentManager.Students[1].transform.position);
			}
		}
		Physics.SyncTransforms();
	}
}
