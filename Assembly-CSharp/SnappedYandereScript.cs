using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000438 RID: 1080
public class SnappedYandereScript : MonoBehaviour
{
	// Token: 0x06001CED RID: 7405 RVA: 0x00157D00 File Offset: 0x00155F00
	private void Start()
	{
		this.MyAnim[this.AttackAnims[1]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[2]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[3]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[4]].speed = 1.5f;
		this.MyAnim[this.AttackAnims[5]].speed = 1.5f;
	}

	// Token: 0x06001CEE RID: 7406 RVA: 0x00157DA0 File Offset: 0x00155FA0
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

	// Token: 0x06001CEF RID: 7407 RVA: 0x001594E8 File Offset: 0x001576E8
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

	// Token: 0x06001CF0 RID: 7408 RVA: 0x001596D0 File Offset: 0x001578D0
	private void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	// Token: 0x06001CF1 RID: 7409 RVA: 0x0015970C File Offset: 0x0015790C
	private void RotateTowardsTarget(Quaternion target)
	{
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, target, Time.deltaTime * 10f);
	}

	// Token: 0x06001CF2 RID: 7410 RVA: 0x00159738 File Offset: 0x00157938
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

	// Token: 0x06001CF3 RID: 7411 RVA: 0x001597FC File Offset: 0x001579FC
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

	// Token: 0x06001CF4 RID: 7412 RVA: 0x00159AC8 File Offset: 0x00157CC8
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

	// Token: 0x0400341B RID: 13339
	public CharacterController MyController;

	// Token: 0x0400341C RID: 13340
	public CameraFilterPack_FX_Glitch1 Glitch1;

	// Token: 0x0400341D RID: 13341
	public CameraFilterPack_FX_Glitch2 Glitch2;

	// Token: 0x0400341E RID: 13342
	public CameraFilterPack_FX_Glitch3 Glitch3;

	// Token: 0x0400341F RID: 13343
	public CameraFilterPack_Glitch_Mozaic Glitch4;

	// Token: 0x04003420 RID: 13344
	public CameraFilterPack_NewGlitch1 Glitch5;

	// Token: 0x04003421 RID: 13345
	public CameraFilterPack_NewGlitch2 Glitch6;

	// Token: 0x04003422 RID: 13346
	public CameraFilterPack_NewGlitch3 Glitch7;

	// Token: 0x04003423 RID: 13347
	public CameraFilterPack_NewGlitch4 Glitch8;

	// Token: 0x04003424 RID: 13348
	public CameraFilterPack_NewGlitch5 Glitch9;

	// Token: 0x04003425 RID: 13349
	public CameraFilterPack_NewGlitch6 Glitch10;

	// Token: 0x04003426 RID: 13350
	public CameraFilterPack_NewGlitch7 Glitch11;

	// Token: 0x04003427 RID: 13351
	public CameraFilterPack_TV_CompressionFX CompressionFX;

	// Token: 0x04003428 RID: 13352
	public CameraFilterPack_TV_Distorted Distorted;

	// Token: 0x04003429 RID: 13353
	public CameraFilterPack_Blur_Tilt_Shift TiltShift;

	// Token: 0x0400342A RID: 13354
	public CameraFilterPack_Blur_Tilt_Shift_V TiltShiftV;

	// Token: 0x0400342B RID: 13355
	public CameraFilterPack_Noise_TV Static;

	// Token: 0x0400342C RID: 13356
	public StudentManagerScript StudentManager;

	// Token: 0x0400342D RID: 13357
	public SnapStudentScript TargetStudent;

	// Token: 0x0400342E RID: 13358
	public InputDeviceScript InputDevice;

	// Token: 0x0400342F RID: 13359
	public GameObject StabBloodEffect;

	// Token: 0x04003430 RID: 13360
	public GameObject BloodEffect;

	// Token: 0x04003431 RID: 13361
	public GameObject NewDoIt;

	// Token: 0x04003432 RID: 13362
	public WeaponScript Knife;

	// Token: 0x04003433 RID: 13363
	public AudioListener MyListener;

	// Token: 0x04003434 RID: 13364
	public Transform SnapAttackPivot;

	// Token: 0x04003435 RID: 13365
	public Transform FinalSnapPOV;

	// Token: 0x04003436 RID: 13366
	public Transform SuicidePOV;

	// Token: 0x04003437 RID: 13367
	public Transform RightFoot;

	// Token: 0x04003438 RID: 13368
	public Transform RightHand;

	// Token: 0x04003439 RID: 13369
	public Transform LeftHand;

	// Token: 0x0400343A RID: 13370
	public Transform Spine;

	// Token: 0x0400343B RID: 13371
	public AudioSource StaticNoise;

	// Token: 0x0400343C RID: 13372
	public AudioSource AttackAudio;

	// Token: 0x0400343D RID: 13373
	public AudioSource SnapStatic;

	// Token: 0x0400343E RID: 13374
	public AudioSource SnapVoice;

	// Token: 0x0400343F RID: 13375
	public AudioSource Jukebox;

	// Token: 0x04003440 RID: 13376
	public AudioSource MyAudio;

	// Token: 0x04003441 RID: 13377
	public AudioSource Rumble;

	// Token: 0x04003442 RID: 13378
	public AudioClip EndSNAP;

	// Token: 0x04003443 RID: 13379
	public UILabel SNAPLabel;

	// Token: 0x04003444 RID: 13380
	public Camera MainCamera;

	// Token: 0x04003445 RID: 13381
	public Animation MyAnim;

	// Token: 0x04003446 RID: 13382
	public AudioClip Buzz;

	// Token: 0x04003447 RID: 13383
	public AudioClip[] Whispers;

	// Token: 0x04003448 RID: 13384
	public AudioClip[] FemaleDeathScreams;

	// Token: 0x04003449 RID: 13385
	public AudioClip[] MaleDeathScreams;

	// Token: 0x0400344A RID: 13386
	public AudioClip[] AttackSFX;

	// Token: 0x0400344B RID: 13387
	public GameObject DoIt;

	// Token: 0x0400344C RID: 13388
	public UISprite SuicideSprite;

	// Token: 0x0400344D RID: 13389
	public UILabel SuicidePrompt;

	// Token: 0x0400344E RID: 13390
	public bool KillingSenpai;

	// Token: 0x0400344F RID: 13391
	public bool Attacking;

	// Token: 0x04003450 RID: 13392
	public bool CanMove;

	// Token: 0x04003451 RID: 13393
	public bool SpeedUp;

	// Token: 0x04003452 RID: 13394
	public bool Whisper;

	// Token: 0x04003453 RID: 13395
	public bool Armed;

	// Token: 0x04003454 RID: 13396
	public string IdleAnim;

	// Token: 0x04003455 RID: 13397
	public string WalkAnim;

	// Token: 0x04003456 RID: 13398
	public float ImpatienceLimit;

	// Token: 0x04003457 RID: 13399
	public float GlitchTimeLimit;

	// Token: 0x04003458 RID: 13400
	public float WhisperTimer;

	// Token: 0x04003459 RID: 13401
	public float AttackTimer;

	// Token: 0x0400345A RID: 13402
	public float GlitchTimer;

	// Token: 0x0400345B RID: 13403
	public float ImpatienceTimer;

	// Token: 0x0400345C RID: 13404
	public float ListenTimer;

	// Token: 0x0400345D RID: 13405
	public float HurryTimer;

	// Token: 0x0400345E RID: 13406
	public float AnimSpeed;

	// Token: 0x0400345F RID: 13407
	public float Target;

	// Token: 0x04003460 RID: 13408
	public float Speed;

	// Token: 0x04003461 RID: 13409
	public int BloodSpawned;

	// Token: 0x04003462 RID: 13410
	public int AttackPhase;

	// Token: 0x04003463 RID: 13411
	public int Teleports;

	// Token: 0x04003464 RID: 13412
	public int AttackID;

	// Token: 0x04003465 RID: 13413
	public int VoiceID;

	// Token: 0x04003466 RID: 13414
	public int Attacks;

	// Token: 0x04003467 RID: 13415
	public int Taps;

	// Token: 0x04003468 RID: 13416
	public string[] AttackAnims;

	// Token: 0x04003469 RID: 13417
	public WeaponScript[] Weapons;

	// Token: 0x0400346A RID: 13418
	public bool[] AttacksUsed;
}
