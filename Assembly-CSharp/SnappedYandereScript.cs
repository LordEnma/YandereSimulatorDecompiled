using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000434 RID: 1076
public class SnappedYandereScript : MonoBehaviour
{
	// Token: 0x06001CDC RID: 7388 RVA: 0x00156E84 File Offset: 0x00155084
	private void Start()
	{
		this.MyAnim[this.AttackAnims[1]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[2]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[3]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[4]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[5]].speed = 1.5f;
	}

	// Token: 0x06001CDD RID: 7389 RVA: 0x00156F24 File Offset: 0x00155124
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
		if (this.Glitch1.enabled)
		{
			if (this.Attacking)
			{
				this.GlitchTimer += Time.deltaTime * this.MyAnim[this.AttackAnims[this.AttackID]].speed;
			}
			else
			{
				this.GlitchTimer += Time.deltaTime;
			}
			if (this.GlitchTimer > this.GlitchTimeLimit)
			{
				this.SetGlitches(false);
				if (this.MyAudio.clip != this.EndSNAP)
				{
					this.MyAudio.Stop();
				}
				if (this.Attacking)
				{
					this.SnapAttackPivot.position = this.TargetStudent.Student.Head.position;
					this.SnapAttackPivot.localEulerAngles = new Vector3(0f, 0f, 0f);
					this.MainCamera.transform.parent = this.SnapAttackPivot;
					this.MainCamera.transform.localPosition = new Vector3(0f, 0f, -1f);
					this.MainCamera.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					this.SnapAttackPivot.localEulerAngles = new Vector3(UnityEngine.Random.Range(-45f, 45f), UnityEngine.Random.Range(0f, 360f), 0f);
					while (this.MainCamera.transform.position.y < base.transform.position.y + 0.1f)
					{
						this.SnapAttackPivot.localEulerAngles = new Vector3(UnityEngine.Random.Range(-45f, 45f), UnityEngine.Random.Range(0f, 360f), 0f);
					}
					this.MyAnim[this.AttackAnims[this.AttackID]].time = 0f;
					this.MyAnim.Play(this.AttackAnims[this.AttackID]);
					this.MyAnim[this.AttackAnims[this.AttackID]].time = 0f;
					this.MyAnim[this.AttackAnims[this.AttackID]].speed += 0.1f;
					this.TargetStudent.MyAnim[this.TargetStudent.AttackAnims[this.AttackID]].time = 0f;
					this.TargetStudent.MyAnim.Play(this.TargetStudent.AttackAnims[this.AttackID]);
					this.TargetStudent.MyAnim[this.TargetStudent.AttackAnims[this.AttackID]].time = 0f;
					this.TargetStudent.MyAnim[this.TargetStudent.AttackAnims[this.AttackID]].speed = this.MyAnim[this.AttackAnims[this.AttackID]].speed;
					if (this.TargetStudent.Student.Male)
					{
						this.MyAudio.clip = this.MaleDeathScreams[UnityEngine.Random.Range(0, this.MaleDeathScreams.Length)];
						this.MyAudio.pitch = 1f;
						this.MyAudio.Play();
					}
					else
					{
						this.MyAudio.clip = this.FemaleDeathScreams[UnityEngine.Random.Range(0, this.FemaleDeathScreams.Length)];
						this.MyAudio.pitch = 1f;
						this.MyAudio.Play();
					}
					this.AttackAudio.clip = this.AttackSFX[this.AttackID];
					this.AttackAudio.pitch = this.MyAnim[this.AttackAnims[this.AttackID]].speed;
					this.AttackAudio.Play();
				}
			}
		}
		if (!this.Armed)
		{
			foreach (WeaponScript weaponScript in this.Weapons)
			{
				if (weaponScript != null && weaponScript.gameObject.activeInHierarchy && weaponScript.gameObject.name != "RoofKnife" && Vector3.Distance(base.transform.position, weaponScript.transform.position) < 1.5f)
				{
					weaponScript.Prompt.Circle[3].fillAmount = 0f;
					this.SNAPLabel.text = "Kill him.";
					this.StaticNoise.volume = 0f;
					this.Static.Fade = 0f;
					this.HurryTimer = 0f;
					this.Knife = weaponScript;
					this.Armed = true;
				}
			}
		}
		else
		{
			this.Knife.gameObject.SetActive(true);
		}
		if (this.CanMove)
		{
			this.SNAPLabel.alpha = Mathf.MoveTowards(this.SNAPLabel.alpha, 1f, Time.deltaTime * 0.2f);
			this.HurryTimer += Time.deltaTime;
			if (this.HurryTimer > 40f || base.transform.position.y < -0.1f || this.StudentManager.MaleLockerRoomArea.bounds.Contains(base.transform.position))
			{
				this.Teleport();
				this.HurryTimer = 0f;
				this.Static.Fade = 0f;
				this.StaticNoise.volume = 0f;
			}
			else if (this.HurryTimer > 30f)
			{
				this.StaticNoise.volume += Time.deltaTime * 0.1f;
				this.Static.Fade += Time.deltaTime * 0.1f;
			}
			this.UpdateMovement();
		}
		else if (this.Attacking)
		{
			this.SNAPLabel.alpha = 0f;
			if (this.MyAnim[this.AttackAnims[this.AttackID]].speed == 0f)
			{
				this.MyAnim[this.AttackAnims[this.AttackID]].speed = 1f;
			}
			if (this.MyAnim[this.AttackAnims[this.AttackID]].time >= this.MyAnim[this.AttackAnims[this.AttackID]].length)
			{
				if (this.Attacks < 5)
				{
					this.ChooseAttack();
				}
				else
				{
					this.MainCamera.transform.parent = base.transform;
					this.MainCamera.transform.localPosition = new Vector3(0.25f, 1.546664f, -0.5473595f);
					this.MainCamera.transform.localEulerAngles = new Vector3(15f, 0f, 0f);
					this.SetGlitches(true);
					this.GlitchTimeLimit = 0.5f;
					this.TargetStudent.Student.BecomeRagdoll();
					this.AttacksUsed[1] = false;
					this.AttacksUsed[2] = false;
					this.AttacksUsed[3] = false;
					this.AttacksUsed[4] = false;
					this.AttacksUsed[5] = false;
					this.Attacking = false;
					this.CanMove = true;
					this.Attacks = 0;
				}
			}
			else if (!this.Glitch1.enabled && this.BloodSpawned < 2)
			{
				if (this.AttackID == 1)
				{
					if (this.BloodSpawned == 0)
					{
						if (this.MyAnim[this.AttackAnims[this.AttackID]].time > 0.25f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.RightHand.position, Quaternion.identity);
							this.MyAudio.Stop();
							this.BloodSpawned++;
						}
					}
					else if (this.MyAnim[this.AttackAnims[this.AttackID]].time > 1f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.LeftHand.position, Quaternion.identity);
						this.BloodSpawned++;
					}
				}
				else if (this.AttackID == 2)
				{
					if (this.MyAnim[this.AttackAnims[this.AttackID]].time > 1f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.RightHand.position, Quaternion.identity);
						this.BloodSpawned += 2;
						this.MyAudio.Stop();
					}
				}
				else if (this.AttackID == 3)
				{
					if (this.MyAnim[this.AttackAnims[this.AttackID]].time > 0.5f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.RightHand.position, Quaternion.identity);
						this.BloodSpawned += 2;
						this.MyAudio.Stop();
					}
				}
				else if (this.AttackID == 4)
				{
					if (this.MyAnim[this.AttackAnims[this.AttackID]].time > 0.5f)
					{
						this.MyAudio.Stop();
					}
				}
				else if (this.AttackID == 5)
				{
					if (this.BloodSpawned == 0)
					{
						if (this.MyAnim[this.AttackAnims[this.AttackID]].time > 0.25f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.RightFoot.position, Quaternion.identity);
							this.MyAudio.Stop();
							this.BloodSpawned++;
						}
					}
					else if (this.MyAnim[this.AttackAnims[this.AttackID]].time > 0.9f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.RightFoot.position, Quaternion.identity);
						this.BloodSpawned++;
					}
				}
			}
		}
		else if (this.KillingSenpai)
		{
			this.CompressionFX.Parasite = Mathf.MoveTowards(this.CompressionFX.Parasite, 0f, Time.deltaTime);
			this.Distorted.Distortion = Mathf.MoveTowards(this.Distorted.Distortion, 0f, Time.deltaTime);
			this.StaticNoise.volume -= Time.deltaTime * 0.5f;
			this.Static.Fade = Mathf.MoveTowards(this.Static.Fade, 0f, Time.deltaTime * 0.5f);
			this.Jukebox.volume -= Time.deltaTime * 0.5f;
			this.SnapStatic.volume -= Time.deltaTime * 0.5f * 0.2f;
			this.SNAPLabel.alpha = Mathf.MoveTowards(this.SNAPLabel.alpha, 0f, Time.deltaTime * 0.5f);
			this.SnapVoice.volume -= Time.deltaTime;
			Quaternion b = Quaternion.LookRotation(this.TargetStudent.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime);
			base.transform.position = Vector3.MoveTowards(base.transform.position, this.TargetStudent.transform.position + this.TargetStudent.transform.forward * 1f, Time.deltaTime);
			this.Speed += Time.deltaTime;
			if (this.AttackPhase < 3)
			{
				this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, this.FinalSnapPOV.position, Time.deltaTime * this.Speed * 0.33333f);
				this.MainCamera.transform.rotation = Quaternion.Slerp(this.MainCamera.transform.rotation, this.FinalSnapPOV.rotation, Time.deltaTime * this.Speed * 0.33333f);
			}
			else
			{
				this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, this.SuicidePOV.position, Time.deltaTime * this.Speed * 0.1f);
				this.MainCamera.transform.rotation = Quaternion.Slerp(this.MainCamera.transform.rotation, this.SuicidePOV.rotation, Time.deltaTime * this.Speed * 0.1f);
				if (this.Whisper)
				{
					this.Rumble.volume = Mathf.MoveTowards(this.Rumble.volume, 0.5f, Time.deltaTime * 0.05f);
					this.WhisperTimer += Time.deltaTime;
					if (this.WhisperTimer > 0.5f)
					{
						this.WhisperTimer = 0f;
						int num = UnityEngine.Random.Range(1, this.Whispers.Length);
						AudioSource.PlayClipAtPoint(this.Whispers[num], this.MainCamera.transform.position + new Vector3(11f - 10f * this.Rumble.volume * 2f, 11f - 10f * this.Rumble.volume * 2f, 11f - 10f * this.Rumble.volume * 2f));
						this.NewDoIt = UnityEngine.Object.Instantiate<GameObject>(this.DoIt, this.SNAPLabel.parent.transform.position, Quaternion.identity);
						this.NewDoIt.transform.parent = this.SNAPLabel.parent.transform;
						this.NewDoIt.transform.localScale = new Vector3(1f, 1f, 1f);
						this.NewDoIt.transform.localPosition = new Vector3(UnityEngine.Random.Range(-700f, 700f), UnityEngine.Random.Range(-450f, 450f), 0f);
						this.NewDoIt.transform.localEulerAngles = new Vector3(UnityEngine.Random.Range(-15f, 15f), UnityEngine.Random.Range(-15f, 15f), UnityEngine.Random.Range(-15f, 15f));
					}
				}
			}
			if (this.AttackPhase == 0)
			{
				if (this.MyAnim["f02_snapKill_00"].time > this.MyAnim["f02_snapKill_00"].length * 0.2f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Knife.transform.position, Quaternion.identity);
					this.AttackPhase++;
				}
			}
			else if (this.AttackPhase == 1)
			{
				if (this.MyAnim["f02_snapKill_00"].time > this.MyAnim["f02_snapKill_00"].length * 0.36f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.Knife.transform.position, Quaternion.identity);
					this.AttackPhase++;
				}
			}
			else if (this.AttackPhase == 2)
			{
				if (this.MyAnim["f02_snapKill_00"].time > 13f)
				{
					this.MyAnim["f02_stareAtKnife_00"].layer = 100;
					this.MyAnim.Play("f02_stareAtKnife_00");
					this.MyAnim["f02_stareAtKnife_00"].weight = 0f;
					this.Whisper = true;
					this.Rumble.Play();
					this.Speed = 0f;
					this.AttackPhase++;
				}
			}
			else if (this.AttackPhase == 3)
			{
				this.Knife.transform.localEulerAngles = Vector3.Lerp(this.Knife.transform.localEulerAngles, new Vector3(0f, 0f, 0f), Time.deltaTime * this.Speed);
				this.MyAnim["f02_stareAtKnife_00"].weight = Mathf.Lerp(this.MyAnim["f02_stareAtKnife_00"].weight, 1f, Time.deltaTime * this.Speed);
				if (this.MyAnim["f02_stareAtKnife_00"].weight > 0.999f)
				{
					this.SuicidePrompt.alpha += Time.deltaTime;
					this.ImpatienceTimer += Time.deltaTime;
					if (Input.GetButtonDown("X") || this.ImpatienceTimer > this.ImpatienceLimit)
					{
						this.MyAnim["f02_suicide_00"].layer = 101;
						this.MyAnim.Play("f02_suicide_00");
						this.MyAnim["f02_suicide_00"].weight = 0f;
						this.MyAnim["f02_suicide_00"].time = 2f;
						this.MyAnim["f02_suicide_00"].speed = 0f;
						this.AttackPhase++;
						if (this.ImpatienceTimer > this.ImpatienceLimit)
						{
							this.ImpatienceLimit = 2f;
							this.ImpatienceTimer = 0f;
						}
						this.Taps++;
					}
				}
			}
			else if (this.AttackPhase == 4)
			{
				this.SuicidePrompt.alpha += Time.deltaTime;
				this.ImpatienceTimer += Time.deltaTime;
				if (Input.GetButtonDown("X") || this.ImpatienceTimer > this.ImpatienceLimit)
				{
					this.Target += 0.1f;
					this.SpeedUp = true;
					if (this.ImpatienceTimer > this.ImpatienceLimit)
					{
						this.ImpatienceLimit = 2f;
						this.ImpatienceTimer = 0f;
					}
					this.Taps++;
				}
				if (this.SpeedUp)
				{
					this.AnimSpeed += Time.deltaTime;
					if (this.AnimSpeed > 1f)
					{
						this.SpeedUp = false;
					}
				}
				else
				{
					this.AnimSpeed = Mathf.MoveTowards(this.AnimSpeed, 0f, Time.deltaTime);
				}
				this.MyAnim["f02_suicide_00"].weight = Mathf.Lerp(this.MyAnim["f02_suicide_00"].weight, this.Target, this.AnimSpeed * Time.deltaTime);
				if (this.MyAnim["f02_suicide_00"].weight >= 1f)
				{
					this.SpeedUp = false;
					this.AnimSpeed = 0f;
					this.Target = 2f;
					this.AttackPhase++;
				}
			}
			else if (this.AttackPhase == 5)
			{
				this.ImpatienceTimer += Time.deltaTime;
				if (Input.GetButtonDown("X") || this.ImpatienceTimer > this.ImpatienceLimit)
				{
					this.Target += 0.1f;
					this.SpeedUp = true;
					if (this.ImpatienceTimer > this.ImpatienceLimit)
					{
						this.ImpatienceLimit = 2f;
						this.ImpatienceTimer = 0f;
					}
					this.Taps++;
				}
				if (this.SpeedUp)
				{
					this.AnimSpeed += Time.deltaTime;
					if (this.AnimSpeed > 1f)
					{
						this.SpeedUp = false;
					}
				}
				else
				{
					this.AnimSpeed = Mathf.MoveTowards(this.AnimSpeed, 0f, Time.deltaTime);
				}
				this.MyAnim["f02_suicide_00"].time = Mathf.Lerp(this.MyAnim["f02_suicide_00"].time, this.Target, this.AnimSpeed * Time.deltaTime);
				if (this.MyAnim["f02_suicide_00"].time >= 3.66666f)
				{
					this.MyAnim["f02_suicide_00"].speed = 1f;
					this.SuicidePrompt.alpha = 0f;
					this.Rumble.volume = 0f;
					UnityEngine.Object.Destroy(this.NewDoIt);
					this.Whisper = false;
					this.AttackPhase++;
				}
			}
			else if (this.AttackPhase == 6)
			{
				if (this.MyAnim["f02_suicide_00"].time >= this.MyAnim["f02_suicide_00"].length * 0.355f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.StabBloodEffect, this.Knife.transform.position, Quaternion.identity);
					this.AttackPhase++;
				}
			}
			else if (this.MyAnim["f02_suicide_00"].time >= this.MyAnim["f02_suicide_00"].length * 0.475f)
			{
				this.MyListener.enabled = false;
				this.MainCamera.transform.parent = null;
				this.MainCamera.transform.position = new Vector3(0f, 2025f, -11f);
				this.MainCamera.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				if (this.MyAnim["f02_suicide_00"].time >= this.MyAnim["f02_suicide_00"].length)
				{
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
		if (this.InputDevice.Type == InputDeviceType.MouseAndKeyboard)
		{
			this.SuicidePrompt.text = "F";
			this.SuicideSprite.enabled = false;
		}
		else
		{
			this.SuicidePrompt.text = "";
			this.SuicideSprite.enabled = true;
		}
		if (this.ListenTimer > 0f)
		{
			this.ListenTimer = Mathf.MoveTowards(this.ListenTimer, 0f, Time.deltaTime);
		}
	}

	// Token: 0x06001CDE RID: 7390 RVA: 0x0015866C File Offset: 0x0015686C
	private void UpdateMovement()
	{
		this.MyController.Move(Physics.gravity * Time.deltaTime);
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		Vector3 vector = base.transform.TransformDirection(Vector3.forward);
		vector.y = 0f;
		vector = vector.normalized;
		Vector3 a = new Vector3(vector.z, 0f, -vector.x);
		Vector3 a2 = axis2 * a + axis * vector;
		if (Mathf.Abs(axis) > 0.5f || Mathf.Abs(axis2) > 0.5f)
		{
			this.MyAnim[this.WalkAnim].speed = Mathf.Abs(axis) + Mathf.Abs(axis2);
			if (this.MyAnim[this.WalkAnim].speed > 1f)
			{
				this.MyAnim[this.WalkAnim].speed = 1f;
			}
			this.MyAnim.CrossFade(this.WalkAnim);
			this.MyController.Move(a2 * Time.deltaTime);
		}
		else
		{
			this.MyAnim.CrossFade(this.IdleAnim);
		}
		float num = Input.GetAxis("Mouse X") * (float)OptionGlobals.Sensitivity;
		if (num != 0f)
		{
			base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y + num * 36f * Time.deltaTime, base.transform.eulerAngles.z);
		}
		if (Input.GetButtonDown("LB"))
		{
			this.MyController.Move(a2 * 4f);
			this.SetGlitches(true);
			this.GlitchTimeLimit = 0.1f;
		}
	}

	// Token: 0x06001CDF RID: 7391 RVA: 0x00158854 File Offset: 0x00156A54
	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	// Token: 0x06001CE0 RID: 7392 RVA: 0x00158890 File Offset: 0x00156A90
	private void RotateTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	// Token: 0x06001CE1 RID: 7393 RVA: 0x001588BC File Offset: 0x00156ABC
	private void SetGlitches(bool State)
	{
		this.GlitchTimer = 0f;
		this.Glitch1.enabled = State;
		this.Glitch2.enabled = State;
		this.Glitch4.enabled = State;
		this.Glitch5.enabled = State;
		this.Glitch6.enabled = State;
		this.Glitch7.enabled = State;
		this.Glitch10.enabled = State;
		this.Glitch11.enabled = State;
		if (State)
		{
			this.MyAudio.clip = this.Buzz;
			this.MyAudio.volume = 0.5f;
			this.MyAudio.pitch = UnityEngine.Random.Range(0.5f, 2f);
			this.MyAudio.Play();
		}
	}

	// Token: 0x06001CE2 RID: 7394 RVA: 0x00158980 File Offset: 0x00156B80
	public void ChooseAttack()
	{
		this.BloodSpawned = 0;
		this.SetGlitches(true);
		this.GlitchTimeLimit = 0.5f;
		this.AttackID = UnityEngine.Random.Range(1, 6);
		while (this.AttacksUsed[this.AttackID])
		{
			this.AttackID = UnityEngine.Random.Range(1, 6);
		}
		this.AttacksUsed[this.AttackID] = true;
		this.Attacks++;
		if (this.AttackID == 1)
		{
			this.TargetStudent.transform.position = base.transform.position + base.transform.forward * 0.0001f;
			this.TargetStudent.transform.LookAt(base.transform.position);
		}
		else if (this.AttackID == 2)
		{
			this.TargetStudent.transform.position = base.transform.position + base.transform.forward * 0.5f;
			this.TargetStudent.transform.LookAt(base.transform.position);
		}
		else if (this.AttackID == 3)
		{
			this.TargetStudent.transform.position = base.transform.position + base.transform.forward * 0.3f;
			this.TargetStudent.transform.LookAt(base.transform.position);
		}
		else if (this.AttackID == 4)
		{
			this.TargetStudent.transform.position = base.transform.position + base.transform.forward * 0.3f;
			this.TargetStudent.transform.rotation = base.transform.rotation;
		}
		else if (this.AttackID == 5)
		{
			this.TargetStudent.transform.position = base.transform.position + base.transform.forward * 0.66666f;
			this.TargetStudent.transform.rotation = base.transform.rotation;
		}
		Physics.SyncTransforms();
		this.MyAnim.Play(this.AttackAnims[this.AttackID]);
		this.MyAnim[this.AttackAnims[this.AttackID]].time = 0f;
		this.TargetStudent.MyAnim.Play(this.TargetStudent.AttackAnims[this.AttackID]);
		this.TargetStudent.MyAnim[this.TargetStudent.AttackAnims[this.AttackID]].time = 0f;
	}

	// Token: 0x06001CE3 RID: 7395 RVA: 0x00158C4C File Offset: 0x00156E4C
	public void Teleport()
	{
		if (!this.Armed)
		{
			bool flag = false;
			while (!flag)
			{
				foreach (WeaponScript weaponScript in this.Weapons)
				{
					if (weaponScript != null && weaponScript.gameObject.name != "RoofKnife")
					{
						this.SetGlitches(true);
						this.GlitchTimeLimit = 1f;
						base.transform.position = weaponScript.transform.position;
						flag = true;
					}
				}
			}
		}
		else
		{
			this.Teleports++;
			this.SetGlitches(true);
			this.GlitchTimeLimit = 1f;
			if (this.Teleports == 1)
			{
				base.transform.position = this.StudentManager.Students[1].transform.position + this.StudentManager.Students[1].transform.forward * 2f;
				base.transform.LookAt(this.StudentManager.Students[1].transform.position);
			}
			else
			{
				base.transform.position = this.StudentManager.Students[1].transform.position + this.StudentManager.Students[1].transform.forward * 0.9f;
				base.transform.LookAt(this.StudentManager.Students[1].transform.position);
			}
		}
		Physics.SyncTransforms();
	}

	// Token: 0x040033FC RID: 13308
	public CharacterController MyController;

	// Token: 0x040033FD RID: 13309
	public CameraFilterPack_FX_Glitch1 Glitch1;

	// Token: 0x040033FE RID: 13310
	public CameraFilterPack_FX_Glitch2 Glitch2;

	// Token: 0x040033FF RID: 13311
	public CameraFilterPack_FX_Glitch3 Glitch3;

	// Token: 0x04003400 RID: 13312
	public CameraFilterPack_Glitch_Mozaic Glitch4;

	// Token: 0x04003401 RID: 13313
	public CameraFilterPack_NewGlitch1 Glitch5;

	// Token: 0x04003402 RID: 13314
	public CameraFilterPack_NewGlitch2 Glitch6;

	// Token: 0x04003403 RID: 13315
	public CameraFilterPack_NewGlitch3 Glitch7;

	// Token: 0x04003404 RID: 13316
	public CameraFilterPack_NewGlitch4 Glitch8;

	// Token: 0x04003405 RID: 13317
	public CameraFilterPack_NewGlitch5 Glitch9;

	// Token: 0x04003406 RID: 13318
	public CameraFilterPack_NewGlitch6 Glitch10;

	// Token: 0x04003407 RID: 13319
	public CameraFilterPack_NewGlitch7 Glitch11;

	// Token: 0x04003408 RID: 13320
	public CameraFilterPack_TV_CompressionFX CompressionFX;

	// Token: 0x04003409 RID: 13321
	public CameraFilterPack_TV_Distorted Distorted;

	// Token: 0x0400340A RID: 13322
	public CameraFilterPack_Blur_Tilt_Shift TiltShift;

	// Token: 0x0400340B RID: 13323
	public CameraFilterPack_Blur_Tilt_Shift_V TiltShiftV;

	// Token: 0x0400340C RID: 13324
	public CameraFilterPack_Noise_TV Static;

	// Token: 0x0400340D RID: 13325
	public StudentManagerScript StudentManager;

	// Token: 0x0400340E RID: 13326
	public SnapStudentScript TargetStudent;

	// Token: 0x0400340F RID: 13327
	public InputDeviceScript InputDevice;

	// Token: 0x04003410 RID: 13328
	public GameObject StabBloodEffect;

	// Token: 0x04003411 RID: 13329
	public GameObject BloodEffect;

	// Token: 0x04003412 RID: 13330
	public GameObject NewDoIt;

	// Token: 0x04003413 RID: 13331
	public WeaponScript Knife;

	// Token: 0x04003414 RID: 13332
	public AudioListener MyListener;

	// Token: 0x04003415 RID: 13333
	public Transform SnapAttackPivot;

	// Token: 0x04003416 RID: 13334
	public Transform FinalSnapPOV;

	// Token: 0x04003417 RID: 13335
	public Transform SuicidePOV;

	// Token: 0x04003418 RID: 13336
	public Transform RightFoot;

	// Token: 0x04003419 RID: 13337
	public Transform RightHand;

	// Token: 0x0400341A RID: 13338
	public Transform LeftHand;

	// Token: 0x0400341B RID: 13339
	public Transform Spine;

	// Token: 0x0400341C RID: 13340
	public AudioSource StaticNoise;

	// Token: 0x0400341D RID: 13341
	public AudioSource AttackAudio;

	// Token: 0x0400341E RID: 13342
	public AudioSource SnapStatic;

	// Token: 0x0400341F RID: 13343
	public AudioSource SnapVoice;

	// Token: 0x04003420 RID: 13344
	public AudioSource Jukebox;

	// Token: 0x04003421 RID: 13345
	public AudioSource MyAudio;

	// Token: 0x04003422 RID: 13346
	public AudioSource Rumble;

	// Token: 0x04003423 RID: 13347
	public AudioClip EndSNAP;

	// Token: 0x04003424 RID: 13348
	public UILabel SNAPLabel;

	// Token: 0x04003425 RID: 13349
	public Camera MainCamera;

	// Token: 0x04003426 RID: 13350
	public Animation MyAnim;

	// Token: 0x04003427 RID: 13351
	public AudioClip Buzz;

	// Token: 0x04003428 RID: 13352
	public AudioClip[] Whispers;

	// Token: 0x04003429 RID: 13353
	public AudioClip[] FemaleDeathScreams;

	// Token: 0x0400342A RID: 13354
	public AudioClip[] MaleDeathScreams;

	// Token: 0x0400342B RID: 13355
	public AudioClip[] AttackSFX;

	// Token: 0x0400342C RID: 13356
	public GameObject DoIt;

	// Token: 0x0400342D RID: 13357
	public UISprite SuicideSprite;

	// Token: 0x0400342E RID: 13358
	public UILabel SuicidePrompt;

	// Token: 0x0400342F RID: 13359
	public bool KillingSenpai;

	// Token: 0x04003430 RID: 13360
	public bool Attacking;

	// Token: 0x04003431 RID: 13361
	public bool CanMove;

	// Token: 0x04003432 RID: 13362
	public bool SpeedUp;

	// Token: 0x04003433 RID: 13363
	public bool Whisper;

	// Token: 0x04003434 RID: 13364
	public bool Armed;

	// Token: 0x04003435 RID: 13365
	public string IdleAnim;

	// Token: 0x04003436 RID: 13366
	public string WalkAnim;

	// Token: 0x04003437 RID: 13367
	public float ImpatienceLimit;

	// Token: 0x04003438 RID: 13368
	public float GlitchTimeLimit;

	// Token: 0x04003439 RID: 13369
	public float WhisperTimer;

	// Token: 0x0400343A RID: 13370
	public float AttackTimer;

	// Token: 0x0400343B RID: 13371
	public float GlitchTimer;

	// Token: 0x0400343C RID: 13372
	public float ImpatienceTimer;

	// Token: 0x0400343D RID: 13373
	public float ListenTimer;

	// Token: 0x0400343E RID: 13374
	public float HurryTimer;

	// Token: 0x0400343F RID: 13375
	public float AnimSpeed;

	// Token: 0x04003440 RID: 13376
	public float Target;

	// Token: 0x04003441 RID: 13377
	public float Speed;

	// Token: 0x04003442 RID: 13378
	public int BloodSpawned;

	// Token: 0x04003443 RID: 13379
	public int AttackPhase;

	// Token: 0x04003444 RID: 13380
	public int Teleports;

	// Token: 0x04003445 RID: 13381
	public int AttackID;

	// Token: 0x04003446 RID: 13382
	public int VoiceID;

	// Token: 0x04003447 RID: 13383
	public int Attacks;

	// Token: 0x04003448 RID: 13384
	public int Taps;

	// Token: 0x04003449 RID: 13385
	public string[] AttackAnims;

	// Token: 0x0400344A RID: 13386
	public WeaponScript[] Weapons;

	// Token: 0x0400344B RID: 13387
	public bool[] AttacksUsed;
}
