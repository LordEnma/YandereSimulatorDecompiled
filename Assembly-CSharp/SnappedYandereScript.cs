using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000431 RID: 1073
public class SnappedYandereScript : MonoBehaviour
{
	// Token: 0x06001CBB RID: 7355 RVA: 0x001549A4 File Offset: 0x00152BA4
	private void Start()
	{
		this.MyAnim[this.AttackAnims[1]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[2]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[3]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[4]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[5]].speed = 1.5f;
	}

	// Token: 0x06001CBC RID: 7356 RVA: 0x00154A44 File Offset: 0x00152C44
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

	// Token: 0x06001CBD RID: 7357 RVA: 0x0015618C File Offset: 0x0015438C
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

	// Token: 0x06001CBE RID: 7358 RVA: 0x00156374 File Offset: 0x00154574
	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	// Token: 0x06001CBF RID: 7359 RVA: 0x001563B0 File Offset: 0x001545B0
	private void RotateTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	// Token: 0x06001CC0 RID: 7360 RVA: 0x001563DC File Offset: 0x001545DC
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

	// Token: 0x06001CC1 RID: 7361 RVA: 0x001564A0 File Offset: 0x001546A0
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

	// Token: 0x06001CC2 RID: 7362 RVA: 0x0015676C File Offset: 0x0015496C
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

	// Token: 0x04003397 RID: 13207
	public CharacterController MyController;

	// Token: 0x04003398 RID: 13208
	public CameraFilterPack_FX_Glitch1 Glitch1;

	// Token: 0x04003399 RID: 13209
	public CameraFilterPack_FX_Glitch2 Glitch2;

	// Token: 0x0400339A RID: 13210
	public CameraFilterPack_FX_Glitch3 Glitch3;

	// Token: 0x0400339B RID: 13211
	public CameraFilterPack_Glitch_Mozaic Glitch4;

	// Token: 0x0400339C RID: 13212
	public CameraFilterPack_NewGlitch1 Glitch5;

	// Token: 0x0400339D RID: 13213
	public CameraFilterPack_NewGlitch2 Glitch6;

	// Token: 0x0400339E RID: 13214
	public CameraFilterPack_NewGlitch3 Glitch7;

	// Token: 0x0400339F RID: 13215
	public CameraFilterPack_NewGlitch4 Glitch8;

	// Token: 0x040033A0 RID: 13216
	public CameraFilterPack_NewGlitch5 Glitch9;

	// Token: 0x040033A1 RID: 13217
	public CameraFilterPack_NewGlitch6 Glitch10;

	// Token: 0x040033A2 RID: 13218
	public CameraFilterPack_NewGlitch7 Glitch11;

	// Token: 0x040033A3 RID: 13219
	public CameraFilterPack_TV_CompressionFX CompressionFX;

	// Token: 0x040033A4 RID: 13220
	public CameraFilterPack_TV_Distorted Distorted;

	// Token: 0x040033A5 RID: 13221
	public CameraFilterPack_Blur_Tilt_Shift TiltShift;

	// Token: 0x040033A6 RID: 13222
	public CameraFilterPack_Blur_Tilt_Shift_V TiltShiftV;

	// Token: 0x040033A7 RID: 13223
	public CameraFilterPack_Noise_TV Static;

	// Token: 0x040033A8 RID: 13224
	public StudentManagerScript StudentManager;

	// Token: 0x040033A9 RID: 13225
	public SnapStudentScript TargetStudent;

	// Token: 0x040033AA RID: 13226
	public InputDeviceScript InputDevice;

	// Token: 0x040033AB RID: 13227
	public GameObject StabBloodEffect;

	// Token: 0x040033AC RID: 13228
	public GameObject BloodEffect;

	// Token: 0x040033AD RID: 13229
	public GameObject NewDoIt;

	// Token: 0x040033AE RID: 13230
	public WeaponScript Knife;

	// Token: 0x040033AF RID: 13231
	public AudioListener MyListener;

	// Token: 0x040033B0 RID: 13232
	public Transform SnapAttackPivot;

	// Token: 0x040033B1 RID: 13233
	public Transform FinalSnapPOV;

	// Token: 0x040033B2 RID: 13234
	public Transform SuicidePOV;

	// Token: 0x040033B3 RID: 13235
	public Transform RightFoot;

	// Token: 0x040033B4 RID: 13236
	public Transform RightHand;

	// Token: 0x040033B5 RID: 13237
	public Transform LeftHand;

	// Token: 0x040033B6 RID: 13238
	public Transform Spine;

	// Token: 0x040033B7 RID: 13239
	public AudioSource StaticNoise;

	// Token: 0x040033B8 RID: 13240
	public AudioSource AttackAudio;

	// Token: 0x040033B9 RID: 13241
	public AudioSource SnapStatic;

	// Token: 0x040033BA RID: 13242
	public AudioSource SnapVoice;

	// Token: 0x040033BB RID: 13243
	public AudioSource Jukebox;

	// Token: 0x040033BC RID: 13244
	public AudioSource MyAudio;

	// Token: 0x040033BD RID: 13245
	public AudioSource Rumble;

	// Token: 0x040033BE RID: 13246
	public AudioClip EndSNAP;

	// Token: 0x040033BF RID: 13247
	public UILabel SNAPLabel;

	// Token: 0x040033C0 RID: 13248
	public Camera MainCamera;

	// Token: 0x040033C1 RID: 13249
	public Animation MyAnim;

	// Token: 0x040033C2 RID: 13250
	public AudioClip Buzz;

	// Token: 0x040033C3 RID: 13251
	public AudioClip[] Whispers;

	// Token: 0x040033C4 RID: 13252
	public AudioClip[] FemaleDeathScreams;

	// Token: 0x040033C5 RID: 13253
	public AudioClip[] MaleDeathScreams;

	// Token: 0x040033C6 RID: 13254
	public AudioClip[] AttackSFX;

	// Token: 0x040033C7 RID: 13255
	public GameObject DoIt;

	// Token: 0x040033C8 RID: 13256
	public UISprite SuicideSprite;

	// Token: 0x040033C9 RID: 13257
	public UILabel SuicidePrompt;

	// Token: 0x040033CA RID: 13258
	public bool KillingSenpai;

	// Token: 0x040033CB RID: 13259
	public bool Attacking;

	// Token: 0x040033CC RID: 13260
	public bool CanMove;

	// Token: 0x040033CD RID: 13261
	public bool SpeedUp;

	// Token: 0x040033CE RID: 13262
	public bool Whisper;

	// Token: 0x040033CF RID: 13263
	public bool Armed;

	// Token: 0x040033D0 RID: 13264
	public string IdleAnim;

	// Token: 0x040033D1 RID: 13265
	public string WalkAnim;

	// Token: 0x040033D2 RID: 13266
	public float ImpatienceLimit;

	// Token: 0x040033D3 RID: 13267
	public float GlitchTimeLimit;

	// Token: 0x040033D4 RID: 13268
	public float WhisperTimer;

	// Token: 0x040033D5 RID: 13269
	public float AttackTimer;

	// Token: 0x040033D6 RID: 13270
	public float GlitchTimer;

	// Token: 0x040033D7 RID: 13271
	public float ImpatienceTimer;

	// Token: 0x040033D8 RID: 13272
	public float ListenTimer;

	// Token: 0x040033D9 RID: 13273
	public float HurryTimer;

	// Token: 0x040033DA RID: 13274
	public float AnimSpeed;

	// Token: 0x040033DB RID: 13275
	public float Target;

	// Token: 0x040033DC RID: 13276
	public float Speed;

	// Token: 0x040033DD RID: 13277
	public int BloodSpawned;

	// Token: 0x040033DE RID: 13278
	public int AttackPhase;

	// Token: 0x040033DF RID: 13279
	public int Teleports;

	// Token: 0x040033E0 RID: 13280
	public int AttackID;

	// Token: 0x040033E1 RID: 13281
	public int VoiceID;

	// Token: 0x040033E2 RID: 13282
	public int Attacks;

	// Token: 0x040033E3 RID: 13283
	public int Taps;

	// Token: 0x040033E4 RID: 13284
	public string[] AttackAnims;

	// Token: 0x040033E5 RID: 13285
	public WeaponScript[] Weapons;

	// Token: 0x040033E6 RID: 13286
	public bool[] AttacksUsed;
}
