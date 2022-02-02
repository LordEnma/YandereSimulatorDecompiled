using System;
using UnityEngine;

// Token: 0x02000254 RID: 596
public class CombatMinigameScript : MonoBehaviour
{
	// Token: 0x0600128C RID: 4748 RVA: 0x00093704 File Offset: 0x00091904
	private void Start()
	{
		this.RedVignette.color = new Color(1f, 1f, 1f, 0f);
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		this.ButtonPrompts[1].alpha = 0f;
		this.ButtonPrompts[2].alpha = 0f;
		this.ButtonPrompts[3].alpha = 0f;
		this.ButtonPrompts[4].alpha = 0f;
		this.Circle.enabled = false;
		this.BG.enabled = false;
	}

	// Token: 0x0600128D RID: 4749 RVA: 0x000937D0 File Offset: 0x000919D0
	public void StartCombat()
	{
		this.StartPoint = this.MainCamera.transform.position;
		this.Midpoint.transform.position = this.MainCamera.transform.position + this.MainCamera.transform.forward;
		this.MainCamera.transform.parent = this.CombatTarget;
		this.Yandere.RPGCamera.enabled = false;
		this.Zoom = true;
		if (this.Delinquent.Male)
		{
			this.Prefix = "";
		}
		else
		{
			this.Prefix = "Female_";
		}
		if (!this.Practice)
		{
			this.Difficulty = 1f;
			return;
		}
		this.Delinquent.MyWeapon.GetComponent<Rigidbody>().isKinematic = true;
		this.Delinquent.MyWeapon.GetComponent<Rigidbody>().useGravity = false;
	}

	// Token: 0x0600128E RID: 4750 RVA: 0x000938BC File Offset: 0x00091ABC
	private void Update()
	{
		if (this.Zoom)
		{
			this.MainCamera.transform.localPosition = Vector3.Lerp(this.MainCamera.transform.localPosition, new Vector3(1.5f, 0.25f, -0.5f), Time.deltaTime * 2f);
			this.RedVignette.color = Vector4.Lerp(this.RedVignette.color, new Color(1f, 1f, 1f, 1f - (float)this.Yandere.Health * 1f / 10f), Time.deltaTime);
			if (this.Timer < 1f)
			{
				this.Delinquent.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
			}
			this.Timer += Time.deltaTime;
			this.AdjustMidpoint();
			if (this.Timer > 1.5f)
			{
				Debug.Log(base.name + " is being instructed to perform the first combat animation of the combat minigame.");
				this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatA");
				this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
				this.CameraStart = this.MainCamera.localPosition;
				this.Label.text = "State: A";
				this.Zoom = false;
				this.Timer = 0f;
				this.Phase = 1;
				this.Path = 1;
				this.MyAudio.clip = this.CombatSFX[this.Phase];
				this.MyAudio.Play();
				this.MyVocals.clip = this.Vocals[this.Phase];
				this.MyVocals.Play();
			}
		}
		if (this.Phase > 0)
		{
			this.MainCamera.position += new Vector3(this.Shake * UnityEngine.Random.Range(-1f, 1f), this.Shake * UnityEngine.Random.Range(-1f, 1f), this.Shake * UnityEngine.Random.Range(-1f, 1f));
			this.Shake = Mathf.Lerp(this.Shake, 0f, Time.deltaTime * 10f);
			this.AdjustMidpoint();
		}
		if (this.ButtonID > 0)
		{
			this.Timer += Time.deltaTime;
			this.Circle.fillAmount = 1f - this.Timer / 0.33333f;
			if ((Input.GetButtonDown("A") && this.CurrentButton != "A") || (Input.GetButtonDown("B") && this.CurrentButton != "B") || (Input.GetButtonDown("X") && this.CurrentButton != "X") || (Input.GetButtonDown("Y") && this.CurrentButton != "Y"))
			{
				Time.timeScale = 1f;
				this.MyVocals.pitch = 1f;
				this.MyAudio.pitch = 1f;
				this.DisablePrompts();
				this.Phase++;
			}
			else if (Input.GetButtonDown(this.CurrentButton))
			{
				this.Success = true;
			}
		}
		if (this.Path == 1)
		{
			if (!this.Delinquent.CharacterAnimation.IsPlaying(this.Prefix + "Delinquent_CombatA"))
			{
				this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatA");
				this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatA"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
			}
			this.MainCamera.localPosition = Vector3.Lerp(this.MainCamera.localPosition, this.CameraStart, Time.deltaTime);
			if (this.Phase == 1)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 1f)
				{
					this.StartTime = this.Yandere.CharacterAnimation["Yandere_CombatA"].time - 1f;
					this.ChooseButton();
					this.Slowdown();
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 1.33333f)
				{
					Time.timeScale = 1f;
					this.MyVocals.pitch = 1f;
					this.MyAudio.pitch = 1f;
					this.DisablePrompts();
					this.Phase++;
					return;
				}
				if (this.Success)
				{
					this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatB"].time = this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatA"].time;
					this.Yandere.CharacterAnimation["Yandere_CombatB"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.Delinquent.CharacterAnimation.Play(this.Prefix + "Delinquent_CombatB");
					this.Yandere.CharacterAnimation.Play("Yandere_CombatB");
					this.Label.text = "State: B";
					Time.timeScale = 1f;
					this.MyAudio.pitch = 1f;
					this.DisablePrompts();
					this.Strike = 0;
					this.Path = 2;
					this.Phase++;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatB"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatB"].time + 0.5f;
					this.MyVocals.Play();
					return;
				}
			}
			else if (this.Phase == 3)
			{
				if (this.Strike < 1)
				{
					if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 1.66666f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.LeftArmRoll.position, Quaternion.identity);
						this.Shake += this.ShakeFactor;
						this.Strike++;
						this.Yandere.Health--;
						this.RedVignette.color = new Color(1f, 1f, 1f, 1f - (float)this.Yandere.Health * 1f / 10f);
					}
				}
				else if (this.Strike < 2 && this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 2.5f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightArmRoll.position, Quaternion.identity);
					this.Shake += this.ShakeFactor;
					this.Strike++;
					this.Yandere.Health--;
					if (this.Yandere.Health < 0)
					{
						this.Yandere.Health = 0;
					}
					this.RedVignette.color = new Color(1f, 1f, 1f, 1f - (float)this.Yandere.Health * 1f / 10f);
					if (!this.Practice)
					{
						this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 1f - (float)this.Yandere.Health * 1f / 10f);
					}
					if (this.Yandere.Health < 1)
					{
						if (!this.Delinquent.WitnessedMurder && !this.Delinquent.WitnessedCorpse)
						{
							this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatF"].time = this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatA"].time;
							this.Yandere.CharacterAnimation["Yandere_CombatF"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
							this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatF");
							this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatF");
							this.Shake += this.ShakeFactor;
							this.Label.text = "State: F";
							Time.timeScale = 1f;
							this.MyVocals.pitch = 1f;
							this.MyAudio.pitch = 1f;
							this.DisablePrompts();
							this.Timer = 0f;
							this.Path = 6;
							this.Phase++;
							this.MyAudio.clip = this.CombatSFX[this.Path];
							this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatF"].time;
							this.MyAudio.Play();
							this.MyVocals.clip = this.Vocals[this.Path];
							this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatF"].time;
							this.MyVocals.Play();
						}
						else
						{
							this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatE"].time = this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatA"].time;
							this.Yandere.CharacterAnimation["Yandere_CombatE"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
							this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatE");
							this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatE");
							this.CameraTarget = this.MainCamera.position + new Vector3(0f, 1f, 0f);
							this.MainCamera.parent = null;
							this.Shake += this.ShakeFactor;
							this.KnockedOut = true;
							this.Label.text = "State: E";
							Time.timeScale = 1f;
							this.MyVocals.pitch = 1f;
							this.MyAudio.pitch = 1f;
							this.DisablePrompts();
							this.Timer = 0f;
							this.Path = 5;
							this.Phase++;
							this.MyAudio.clip = this.CombatSFX[this.Path];
							this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatE"].time;
							this.MyAudio.Play();
							this.MyVocals.clip = this.Vocals[this.Path];
							this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatE"].time;
							this.MyVocals.Play();
						}
					}
				}
				if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > this.Yandere.CharacterAnimation["Yandere_CombatA"].length)
				{
					this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatA"].time = 0f;
					this.Yandere.CharacterAnimation["Yandere_CombatA"].time = 0f;
					this.Label.text = "State: A";
					this.Strike = 0;
					this.Phase = 1;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.MyVocals.Play();
					return;
				}
			}
		}
		else if (this.Path == 2)
		{
			if (this.Phase == 3)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 1.833333f)
				{
					this.StartTime = this.Yandere.CharacterAnimation["Yandere_CombatB"].time - 1.833333f;
					this.ChooseButton();
					this.Slowdown();
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 2.166666f)
				{
					Time.timeScale = 1f;
					this.MyVocals.pitch = 1f;
					this.MyAudio.pitch = 1f;
					this.DisablePrompts();
					this.Phase++;
					return;
				}
				if (this.Success)
				{
					this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatC"].time = this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatB"].time;
					this.Yandere.CharacterAnimation["Yandere_CombatC"].time = this.Yandere.CharacterAnimation["Yandere_CombatB"].time;
					this.Delinquent.CharacterAnimation.Play(this.Prefix + "Delinquent_CombatC");
					this.Yandere.CharacterAnimation.Play("Yandere_CombatC");
					this.Label.text = "State: C";
					Time.timeScale = 1f;
					this.MyVocals.pitch = 1f;
					this.MyAudio.pitch = 1f;
					this.DisablePrompts();
					this.Strike = 0;
					this.Path = 3;
					this.Phase++;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatC"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatC"].time;
					this.MyVocals.Play();
					return;
				}
			}
			else if (this.Phase == 5)
			{
				if (this.Strike < 1 && this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 2.66666f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Delinquent.LeftHand.position, Quaternion.identity);
					this.Shake += this.ShakeFactor;
					this.Strike++;
				}
				if (this.Yandere.CharacterAnimation["Yandere_CombatB"].time > this.Yandere.CharacterAnimation["Yandere_CombatB"].length)
				{
					this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatA");
					this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
					this.Label.text = "State: A";
					this.Strike = 0;
					this.Phase = 1;
					this.Path = 1;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.MyVocals.Play();
					return;
				}
			}
		}
		else if (this.Path == 3)
		{
			if (this.Phase == 5)
			{
				if (this.Strike < 1 && this.Yandere.CharacterAnimation["Yandere_CombatC"].time > 2.5f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightHand.position, Quaternion.identity);
					this.Shake += this.ShakeFactor;
					this.Strike++;
				}
				if (this.Yandere.CharacterAnimation["Yandere_CombatC"].time > 3.166666f)
				{
					this.StartTime = this.Yandere.CharacterAnimation["Yandere_CombatC"].time - 3.166666f;
					this.ChooseButton();
					this.Slowdown();
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 6)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatC"].time > 3.5f)
				{
					this.DisablePrompts();
					Time.timeScale = 1f;
					this.MyVocals.pitch = 1f;
					this.MyAudio.pitch = 1f;
					this.Phase++;
					return;
				}
				if (this.Success)
				{
					this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatD"].time = this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatC"].time;
					this.Yandere.CharacterAnimation["Yandere_CombatD"].time = this.Yandere.CharacterAnimation["Yandere_CombatC"].time;
					this.Delinquent.CharacterAnimation.Play(this.Prefix + "Delinquent_CombatD");
					this.Yandere.CharacterAnimation.Play("Yandere_CombatD");
					this.Label.text = "State: D";
					Time.timeScale = 1f;
					this.MyVocals.pitch = 1f;
					this.MyAudio.pitch = 1f;
					this.DisablePrompts();
					this.Strike = 0;
					this.Path = 4;
					this.Phase++;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatD"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatD"].time;
					this.MyVocals.Play();
					return;
				}
			}
			else if (this.Phase == 7 && this.Yandere.CharacterAnimation["Yandere_CombatC"].time > this.Yandere.CharacterAnimation["Yandere_CombatC"].length)
			{
				this.Delinquent.CharacterAnimation.CrossFade(this.Prefix + "Delinquent_CombatA");
				this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
				this.Label.text = "State: A";
				this.Strike = 0;
				this.Phase = 1;
				this.Path = 1;
				this.MyAudio.clip = this.CombatSFX[this.Path];
				this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
				this.MyAudio.Play();
				this.MyVocals.clip = this.Vocals[this.Path];
				this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
				this.MyVocals.Play();
				return;
			}
		}
		else if (this.Path == 4)
		{
			if (this.Phase == 7)
			{
				if (this.Strike < 1)
				{
					if (this.Yandere.CharacterAnimation["Yandere_CombatD"].time > 4f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightKnee.position, Quaternion.identity);
						if (!this.Delinquent.WitnessedMurder && !this.Delinquent.WitnessedCorpse)
						{
							this.Delinquent.MyWeapon.transform.parent = null;
							this.Delinquent.MyWeapon.MyCollider.enabled = true;
							this.Delinquent.MyWeapon.MyCollider.isTrigger = false;
							this.Delinquent.MyWeapon.Prompt.enabled = true;
							this.Delinquent.IgnoreBlood = true;
							Rigidbody component = this.Delinquent.MyWeapon.GetComponent<Rigidbody>();
							component.constraints = RigidbodyConstraints.None;
							component.isKinematic = false;
							component.useGravity = true;
							if (!this.Practice)
							{
								this.Delinquent.MyWeapon.DelinquentOwned = false;
								this.Delinquent.MyWeapon = null;
							}
						}
						this.Shake += this.ShakeFactor;
						this.Strike++;
					}
				}
				else if (this.Yandere.CharacterAnimation["Yandere_CombatD"].time > 5.5f)
				{
					this.MainCamera.transform.parent = null;
					this.Strength += Time.deltaTime;
					this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, this.StartPoint, Time.deltaTime * this.Strength);
					this.RedVignette.color = Vector4.Lerp(this.RedVignette.color, new Vector4(1f, 0f, 0f, 0f), Time.deltaTime * this.Strength);
					this.Zoom = false;
				}
				if (this.Yandere.CharacterAnimation["Yandere_CombatD"].time > this.Yandere.CharacterAnimation["Yandere_CombatD"].length)
				{
					if (this.Delinquent.WitnessedMurder || this.Delinquent.WitnessedCorpse)
					{
						this.Yandere.Subtitle.UpdateLabel(SubtitleType.DelinquentNoSurrender, 0, 5f);
						if (!this.Delinquent.WillChase)
						{
							this.Delinquent.WillChase = true;
							this.Yandere.Chasers++;
						}
					}
					else if (!this.Practice)
					{
						this.Yandere.Subtitle.UpdateLabel(SubtitleType.DelinquentSurrender, 0, 5f);
						this.Delinquent.Persona = PersonaType.Loner;
					}
					if (!this.Practice)
					{
						ScheduleBlock scheduleBlock = this.Delinquent.ScheduleBlocks[2];
						scheduleBlock.destination = "Sulk";
						scheduleBlock.action = "Sulk";
						ScheduleBlock scheduleBlock2 = this.Delinquent.ScheduleBlocks[4];
						scheduleBlock2.destination = "Sulk";
						scheduleBlock2.action = "Sulk";
						ScheduleBlock scheduleBlock3 = this.Delinquent.ScheduleBlocks[6];
						scheduleBlock3.destination = "Sulk";
						scheduleBlock3.action = "Sulk";
						ScheduleBlock scheduleBlock4 = this.Delinquent.ScheduleBlocks[7];
						scheduleBlock4.destination = "Sulk";
						scheduleBlock4.action = "Sulk";
						if (this.Delinquent.Phase == 0)
						{
							this.Delinquent.Phase++;
						}
						this.Delinquent.GetDestinations();
						this.Delinquent.CurrentDestination = this.Delinquent.Destinations[this.Delinquent.Phase];
						this.Delinquent.Pathfinding.target = this.Delinquent.Destinations[this.Delinquent.Phase];
						if (this.Delinquent.CurrentDestination == null)
						{
							Debug.Log("Manually setting Delinquent's destination to locker, to fix a saving/loading bug.");
							this.Delinquent.CurrentDestination = this.Delinquent.Destinations[1];
							this.Delinquent.Pathfinding.target = this.Delinquent.Destinations[1];
						}
						if (this.Delinquent.Male)
						{
							this.Delinquent.IdleAnim = "idleInjured_00";
							this.Delinquent.WalkAnim = "walkInjured_00";
						}
						else
						{
							this.Delinquent.IdleAnim = "f02_delinquentIdleInjured_00";
							this.Delinquent.WalkAnim = "f02_delinquentWalkInjured_00";
						}
						this.Delinquent.OriginalIdleAnim = this.Delinquent.IdleAnim;
						this.Delinquent.OriginalWalkAnim = this.Delinquent.WalkAnim;
						this.Delinquent.LeanAnim = this.Delinquent.IdleAnim;
						this.Delinquent.CharacterAnimation.CrossFade(this.Delinquent.IdleAnim);
						this.Delinquent.Threatened = true;
						this.Delinquent.Alarmed = true;
						this.Delinquent.Injured = true;
						this.Delinquent.Strength = 0;
						this.Delinquent.Defeats++;
					}
					else
					{
						this.Delinquent.Threatened = false;
						this.Delinquent.Alarmed = false;
						this.PracticeWindow.Finish();
						this.Yandere.Health = 10;
						this.Practice = false;
					}
					this.Delinquent.Fighting = false;
					this.Delinquent.enabled = true;
					this.Delinquent.Distracted = false;
					this.Delinquent.Shoving = false;
					this.Delinquent.Paired = false;
					this.Delinquent = null;
					this.ReleaseYandere();
					this.ResetValues();
					this.Yandere.StudentManager.UpdateStudents(0);
					return;
				}
			}
		}
		else if (this.Path == 5)
		{
			if (this.Phase == 4)
			{
				this.MainCamera.position = Vector3.Lerp(this.MainCamera.position, this.CameraTarget, Time.deltaTime);
				if (this.Yandere.CharacterAnimation["Yandere_CombatE"].time > this.Yandere.CharacterAnimation["Yandere_CombatE"].length)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						this.Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(true);
						this.Yandere.ShoulderCamera.enabled = false;
						this.Yandere.RPGCamera.enabled = false;
						this.Yandere.Jukebox.GameOver();
						this.Yandere.enabled = false;
						this.Yandere.EmptyHands();
						this.Yandere.Lost = true;
						this.Phase++;
						return;
					}
				}
			}
		}
		else if (this.Path == 6)
		{
			if (this.Phase == 4)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatF"].time > 6.33333f)
				{
					this.MainCamera.transform.parent = null;
					this.Strength += Time.deltaTime;
					this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, this.StartPoint, Time.deltaTime * this.Strength);
					this.RedVignette.color = Vector4.Lerp(this.RedVignette.color, new Vector4(1f, 0f, 0f, 0f), Time.deltaTime * this.Strength);
					this.Zoom = false;
				}
				if (this.Delinquent.CharacterAnimation[this.Prefix + "Delinquent_CombatF"].time > 7.83333f)
				{
					this.Delinquent.MyWeapon.transform.parent = this.Delinquent.WeaponBagParent;
					this.Delinquent.MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					this.Delinquent.MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
				}
				if (this.Yandere.CharacterAnimation["Yandere_CombatF"].time > this.Yandere.CharacterAnimation["Yandere_CombatF"].length)
				{
					if (!this.Practice)
					{
						this.Yandere.Subtitle.UpdateLabel(SubtitleType.DelinquentWin, 0, 5f);
						this.Yandere.IdleAnim = "f02_idleInjured_00";
						this.Yandere.WalkAnim = "f02_walkInjured_00";
						this.Yandere.OriginalIdleAnim = this.Yandere.IdleAnim;
						this.Yandere.OriginalWalkAnim = this.Yandere.WalkAnim;
						this.Yandere.StudentManager.Rest.Prompt.enabled = true;
					}
					else
					{
						this.PracticeWindow.Finish();
						this.Yandere.Health = 10;
						this.Practice = false;
					}
					this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
					this.Yandere.DelinquentFighting = false;
					this.Yandere.RPGCamera.enabled = true;
					this.Yandere.CannotRecover = false;
					this.Yandere.CanMove = true;
					this.Yandere.Chased = false;
					this.Delinquent.Threatened = false;
					this.Delinquent.Fighting = false;
					this.Delinquent.Injured = false;
					this.Delinquent.Alarmed = false;
					this.Delinquent.Routine = true;
					this.Delinquent.enabled = true;
					this.Delinquent.Distracted = false;
					this.Delinquent.Shoving = false;
					this.Delinquent.Paired = false;
					this.Delinquent.Patience = 5;
					this.ResetValues();
					this.Yandere.StudentManager.UpdateStudents(0);
					return;
				}
			}
		}
		else if (this.Path == 7)
		{
			if (this.Yandere.CharacterAnimation["f02_stopFighting_00"].time > 1f)
			{
				this.MainCamera.transform.parent = null;
				this.Strength += Time.deltaTime;
				this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, this.StartPoint, Time.deltaTime * this.Strength);
				this.RedVignette.color = Vector4.Lerp(this.RedVignette.color, new Vector4(1f, 0f, 0f, 0f), Time.deltaTime * this.Strength);
				this.Zoom = false;
			}
			if (this.Delinquent.CharacterAnimation["stopFighting_00"].time > 3.83333f)
			{
				this.Delinquent.MyWeapon.transform.parent = this.Delinquent.WeaponBagParent;
				this.Delinquent.MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				this.Delinquent.MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			if (this.Yandere.CharacterAnimation["f02_stopFighting_00"].time > this.Yandere.CharacterAnimation["f02_stopFighting_00"].length)
			{
				if (this.Delinquent.Phase == 0)
				{
					this.Delinquent.Phase++;
				}
				this.Delinquent.GetDestinations();
				this.Delinquent.CurrentDestination = this.Delinquent.Destinations[this.Delinquent.Phase];
				this.Delinquent.Pathfinding.target = this.Delinquent.Destinations[this.Delinquent.Phase];
				if (this.Delinquent.CurrentDestination == null)
				{
					Debug.Log("Manually setting Delinquent's destination to locker, to fix a saving/loading bug.");
					this.Delinquent.CurrentDestination = this.Delinquent.Destinations[1];
					this.Delinquent.Pathfinding.target = this.Delinquent.Destinations[1];
				}
				this.ReleaseYandere();
				this.Delinquent.Threatened = false;
				this.Delinquent.Fighting = false;
				this.Delinquent.Alarmed = false;
				this.Delinquent.enabled = true;
				this.Delinquent.Distracted = false;
				this.Delinquent.Shoving = false;
				this.Delinquent.Paired = false;
				this.Delinquent.Routine = true;
				this.Delinquent.Patience = 5;
				this.Delinquent = null;
				this.DisablePrompts();
				this.ResetValues();
				this.Yandere.StudentManager.UpdateStudents(0);
			}
		}
	}

	// Token: 0x0600128F RID: 4751 RVA: 0x00095C18 File Offset: 0x00093E18
	private void Slowdown()
	{
		Time.timeScale = this.SlowdownFactor * this.Difficulty;
		this.MyVocals.pitch = this.SlowdownFactor * this.Difficulty;
		this.MyAudio.pitch = this.SlowdownFactor * this.Difficulty;
	}

	// Token: 0x06001290 RID: 4752 RVA: 0x00095C68 File Offset: 0x00093E68
	private void ChooseButton()
	{
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		this.ButtonPrompts[1].alpha = 0f;
		this.ButtonPrompts[2].alpha = 0f;
		this.ButtonPrompts[3].alpha = 0f;
		this.ButtonPrompts[4].alpha = 0f;
		int buttonID = this.ButtonID;
		while (this.ButtonID == buttonID)
		{
			this.ButtonID = UnityEngine.Random.Range(1, 5);
		}
		if (this.ButtonID == 1)
		{
			this.CurrentButton = "A";
		}
		else if (this.ButtonID == 2)
		{
			this.CurrentButton = "B";
		}
		else if (this.ButtonID == 3)
		{
			this.CurrentButton = "X";
		}
		else if (this.ButtonID == 4)
		{
			this.CurrentButton = "Y";
		}
		this.ButtonPrompts[this.ButtonID].enabled = true;
		this.ButtonPrompts[this.ButtonID].alpha = 1f;
		this.Circle.enabled = true;
		this.BG.enabled = true;
		this.Timer = this.StartTime;
	}

	// Token: 0x06001291 RID: 4753 RVA: 0x00095DB8 File Offset: 0x00093FB8
	public void DisablePrompts()
	{
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		this.ButtonPrompts[1].alpha = 0f;
		this.ButtonPrompts[2].alpha = 0f;
		this.ButtonPrompts[3].alpha = 0f;
		this.ButtonPrompts[4].alpha = 0f;
		this.Circle.fillAmount = 1f;
		this.Circle.enabled = false;
		this.BG.enabled = false;
		this.Success = false;
		this.ButtonID = 0;
	}

	// Token: 0x06001292 RID: 4754 RVA: 0x00095E7C File Offset: 0x0009407C
	private void AdjustMidpoint()
	{
		if (this.Strength == 0f)
		{
			if (!this.KnockedOut)
			{
				this.Midpoint.position = (this.Delinquent.Hips.position - this.Yandere.Hips.position) * 0.5f + this.Yandere.Hips.position;
				this.Midpoint.position += new Vector3(0f, 0.25f, 0f);
			}
			else
			{
				this.Midpoint.position = Vector3.Lerp(this.Midpoint.position, this.Yandere.Hips.position + new Vector3(0f, 0.5f, 0f), Time.deltaTime);
			}
		}
		else
		{
			this.Midpoint.position = Vector3.Lerp(this.Midpoint.position, this.Yandere.RPGCamera.cameraPivot.position, Time.deltaTime * this.Strength);
		}
		this.MainCamera.LookAt(this.Midpoint.position);
	}

	// Token: 0x06001293 RID: 4755 RVA: 0x00095FBC File Offset: 0x000941BC
	public void Stop()
	{
		if (this.Delinquent != null)
		{
			this.Delinquent.CharacterAnimation.CrossFade("delinquentCombatIdle_00");
			this.ResetValues();
			base.enabled = false;
		}
	}

	// Token: 0x06001294 RID: 4756 RVA: 0x00095FF0 File Offset: 0x000941F0
	public void ResetValues()
	{
		this.Label.text = "State: A";
		this.Strength = 0f;
		this.Strike = 0;
		this.Phase = 0;
		this.Path = 0;
		this.MyAudio.clip = this.CombatSFX[this.Path];
		this.MyAudio.time = 0f;
		this.MyAudio.Stop();
		this.MyVocals.clip = this.Vocals[this.Path];
		this.MyVocals.time = 0f;
		this.MyVocals.Stop();
		this.Delinquent = null;
	}

	// Token: 0x06001295 RID: 4757 RVA: 0x0009609C File Offset: 0x0009429C
	public void ReleaseYandere()
	{
		Debug.Log("Yandere-chan has been released from combat.");
		this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
		this.Yandere.DelinquentFighting = false;
		this.Yandere.RPGCamera.enabled = true;
		this.Yandere.CannotRecover = false;
		this.Yandere.CanMove = true;
		this.Yandere.Chased = false;
	}

	// Token: 0x04001831 RID: 6193
	public UISprite[] ButtonPrompts;

	// Token: 0x04001832 RID: 6194
	public UISprite Circle;

	// Token: 0x04001833 RID: 6195
	public UISprite BG;

	// Token: 0x04001834 RID: 6196
	public GameObject HitEffect;

	// Token: 0x04001835 RID: 6197
	public PracticeWindowScript PracticeWindow;

	// Token: 0x04001836 RID: 6198
	public StudentScript Delinquent;

	// Token: 0x04001837 RID: 6199
	public YandereScript Yandere;

	// Token: 0x04001838 RID: 6200
	public Transform CombatTarget;

	// Token: 0x04001839 RID: 6201
	public Transform MainCamera;

	// Token: 0x0400183A RID: 6202
	public Transform Midpoint;

	// Token: 0x0400183B RID: 6203
	public Vector3 CameraTarget;

	// Token: 0x0400183C RID: 6204
	public Vector3 CameraStart;

	// Token: 0x0400183D RID: 6205
	public Vector3 StartPoint;

	// Token: 0x0400183E RID: 6206
	public UITexture RedVignette;

	// Token: 0x0400183F RID: 6207
	public UILabel Label;

	// Token: 0x04001840 RID: 6208
	public string CurrentButton;

	// Token: 0x04001841 RID: 6209
	public float SlowdownFactor;

	// Token: 0x04001842 RID: 6210
	public float ShakeFactor;

	// Token: 0x04001843 RID: 6211
	public float Difficulty;

	// Token: 0x04001844 RID: 6212
	public float StartTime;

	// Token: 0x04001845 RID: 6213
	public float Strength;

	// Token: 0x04001846 RID: 6214
	public float Shake;

	// Token: 0x04001847 RID: 6215
	public float Timer;

	// Token: 0x04001848 RID: 6216
	public bool KnockedOut;

	// Token: 0x04001849 RID: 6217
	public bool Practice;

	// Token: 0x0400184A RID: 6218
	public bool Success;

	// Token: 0x0400184B RID: 6219
	public bool Zoom;

	// Token: 0x0400184C RID: 6220
	public string Prefix;

	// Token: 0x0400184D RID: 6221
	public int ButtonID;

	// Token: 0x0400184E RID: 6222
	public int Strike;

	// Token: 0x0400184F RID: 6223
	public int Phase;

	// Token: 0x04001850 RID: 6224
	public int Path;

	// Token: 0x04001851 RID: 6225
	public AudioSource MyVocals;

	// Token: 0x04001852 RID: 6226
	public AudioSource MyAudio;

	// Token: 0x04001853 RID: 6227
	public AudioClip[] CombatSFX;

	// Token: 0x04001854 RID: 6228
	public AudioClip[] Vocals;
}
