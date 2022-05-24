using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class ShoulderCameraScript : MonoBehaviour
{
	// Token: 0x06001CCB RID: 7371 RVA: 0x001533EC File Offset: 0x001515EC
	private void LateUpdate()
	{
		if (!this.PauseScreen.Show)
		{
			if (this.OverShoulder)
			{
				if (this.RPGCamera.enabled)
				{
					this.ShoulderFocus.position = this.RPGCamera.cameraPivot.position;
					this.LastPosition = base.transform.position;
					this.RPGCamera.enabled = false;
				}
				if (this.Yandere.TargetStudent.Counselor)
				{
					base.transform.position = Vector3.Lerp(base.transform.position, this.ShoulderPOV.position + new Vector3(0f, -0.49f, 0f), Time.deltaTime * 10f);
				}
				else
				{
					base.transform.position = Vector3.Lerp(base.transform.position, this.ShoulderPOV.position, Time.deltaTime * 10f);
				}
				this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.Yandere.TargetStudent.transform.position + Vector3.up * this.Height, Time.deltaTime * 10f);
				base.transform.LookAt(this.ShoulderFocus);
				return;
			}
			if (this.AimingCamera)
			{
				if (!this.Yandere.StudentManager.Eighties)
				{
					base.transform.position = this.CameraPOV.position;
					base.transform.LookAt(this.CameraFocus);
					return;
				}
				this.EightiesSpineFollower.localEulerAngles = new Vector3(this.Yandere.Spine[3].localEulerAngles.x, 0f, 0f);
				this.EightiesSpineFollower.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.Spine[3].position.y, this.Yandere.transform.position.z);
				if (this.Yandere.Stance.Current == StanceType.Standing)
				{
					base.transform.position = this.EightiesCameraPOV.position;
					base.transform.LookAt(this.EightiesCameraFocus);
					return;
				}
				if (this.Yandere.Stance.Current == StanceType.Crouching)
				{
					base.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 1f, this.Yandere.transform.position.z);
					return;
				}
				if (this.Yandere.Stance.Current == StanceType.Crawling)
				{
					base.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 0.5f, this.Yandere.transform.position.z);
					return;
				}
			}
			else if (this.Noticed)
			{
				if (!this.Yandere.Drown)
				{
					if (this.NoticedTimer == 0f)
					{
						this.Yandere.CameraEffects.UpdateDOF(1f);
						base.GetComponent<Camera>().cullingMask &= -8193;
						StudentScript component = this.Yandere.Senpai.GetComponent<StudentScript>();
						if (component.Teacher)
						{
							this.GoingToCounselor = true;
							this.NoticedHeight = 1.6f;
							this.NoticedLimit = 6;
						}
						if (component.Club == ClubType.Council)
						{
							this.GoingToCounselor = true;
							this.NoticedHeight = 1.375f;
							this.NoticedLimit = 6;
						}
						else if (component.Witnessed == StudentWitnessType.Stalking)
						{
							this.NoticedHeight = 1.481275f;
							this.NoticedLimit = 7;
						}
						else
						{
							this.NoticedHeight = 1.375f;
							this.NoticedLimit = 6;
						}
						this.NoticedPOV.position = this.Yandere.Senpai.position + this.Yandere.Senpai.forward + Vector3.up * this.NoticedHeight;
						this.NoticedPOV.LookAt(this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight);
						this.NoticedFocus.position = base.transform.position + base.transform.forward;
						this.NoticedSpeed = 10f;
					}
					this.NoticedTimer += Time.deltaTime;
					if (this.Phase == 1)
					{
						if (Input.GetButtonDown("A") && !this.Yandere.Attacking)
						{
							this.Yandere.transform.rotation = Quaternion.LookRotation(this.Yandere.Senpai.position - this.Yandere.transform.position);
							this.NoticedTimer += 10f;
						}
						this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight, Time.deltaTime * 10f);
						this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * -0.075f);
						if (this.NoticedTimer > 1f && !this.Spoken && !this.Yandere.Senpai.GetComponent<StudentScript>().Teacher)
						{
							this.Yandere.Senpai.GetComponent<StudentScript>().DetermineSenpaiReaction();
							this.Spoken = true;
						}
						if (this.NoticedTimer > (float)this.NoticedLimit || this.Skip)
						{
							this.Yandere.Senpai.GetComponent<StudentScript>().Character.SetActive(false);
							base.GetComponent<Camera>().cullingMask |= 8192;
							this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward + Vector3.up * 1.375f;
							this.NoticedPOV.LookAt(this.Yandere.transform.position + Vector3.up * 1.375f);
							this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 1.375f;
							base.transform.position = this.NoticedPOV.position;
							this.NoticedTimer = (float)this.NoticedLimit;
							this.Phase = 2;
							if (this.GoingToCounselor)
							{
								this.Yandere.CharacterAnimation.CrossFade("f02_disappointed_00");
							}
							else
							{
								this.Yandere.CharacterAnimation["f02_sadEyebrows_00"].weight = 1f;
								this.Yandere.CharacterAnimation.CrossFade("f02_whimper_00");
								this.Yandere.Subtitle.UpdateLabel(SubtitleType.YandereWhimper, 1, 3.5f);
								Debug.Log("Yandere-chan shoulder be whimpering now.");
								if (this.Yandere.StudentManager.Eighties)
								{
									this.Yandere.LoseGentleEyes();
								}
								this.Yandere.CameraEffects.UpdateDOF(1f);
							}
						}
					}
					else if (this.Phase == 2)
					{
						if (Input.GetButtonDown("A"))
						{
							this.NoticedTimer += 10f;
						}
						if (!this.GoingToCounselor)
						{
							this.Yandere.EyeShrink = Mathf.MoveTowards(this.Yandere.EyeShrink, 0.5f, Time.deltaTime * 0.125f);
						}
						this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.075f);
						this.Yandere.CameraEffects.UpdateDOF(0.75f);
						if (this.GoingToCounselor)
						{
							this.Yandere.CharacterAnimation.CrossFade("f02_disappointed_00");
						}
						else
						{
							this.Yandere.CharacterAnimation.CrossFade("f02_whimper_00");
							if (this.Yandere.CharacterAnimation["f02_whimper_00"].time > 3.5f)
							{
								this.Yandere.CharacterAnimation["f02_whimper_00"].speed -= Time.deltaTime;
							}
						}
						if (this.NoticedTimer > (float)(this.NoticedLimit + 4))
						{
							if (!this.GoingToCounselor)
							{
								this.NoticedPOV.Translate(Vector3.back * 2f);
								this.NoticedPOV.transform.position = new Vector3(this.NoticedPOV.transform.position.x, this.Yandere.transform.position.y + 1f, this.NoticedPOV.transform.position.z);
								this.NoticedSpeed = 1f;
								this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_down_22");
								this.HeartbrokenCamera.SetActive(true);
								this.Yandere.Police.Invalid = true;
								this.Yandere.Collapse = true;
								this.Phase = 3;
							}
							else
							{
								this.Yandere.Police.Darkness.enabled = true;
								this.Yandere.HUD.enabled = true;
								this.Yandere.HUD.alpha = 1f;
								if (this.Yandere.Police.Timer == 300f && this.Yandere.Police.Corpses - this.Yandere.Police.HiddenCorpses <= 0)
								{
									this.HUD.SetActive(false);
								}
								this.Phase = 4;
							}
						}
					}
					else if (this.Phase == 3)
					{
						this.NoticedFocus.transform.position = new Vector3(this.NoticedFocus.transform.position.x, Mathf.Lerp(this.NoticedFocus.transform.position.y, this.Yandere.transform.position.y + 1f, Time.deltaTime), this.NoticedFocus.transform.position.z);
					}
					else if (this.Phase == 4)
					{
						this.Yandere.Police.Darkness.color += new Color(0f, 0f, 0f, Time.deltaTime);
						this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.075f);
						if (this.Yandere.Police.Darkness.color.a >= 1f)
						{
							if (this.Yandere.Police.Timer != 300f || this.Yandere.Police.Corpses - this.Yandere.Police.HiddenCorpses > 0)
							{
								Debug.Log("Ending day instead of going to counselor.");
								this.HUD.SetActive(true);
								this.Portal.EndDay();
								base.enabled = false;
							}
							else
							{
								if (this.Yandere.Mask != null)
								{
									this.Yandere.Mask.Drop();
								}
								this.Yandere.StudentManager.PreventAlarm();
								this.Counselor.Crime = this.Yandere.Senpai.GetComponent<StudentScript>().Witnessed;
								this.Counselor.MyAnimation.Play("CounselorArmsCrossed");
								this.Counselor.Laptop.SetActive(false);
								this.Counselor.Interrogating = true;
								this.Counselor.LookAtPlayer = true;
								this.Counselor.Stern = true;
								this.Counselor.Timer = 0f;
								this.Counselor.transform.position = new Vector3(-28.93333f, 0f, 12f);
								this.Counselor.RedPen.SetActive(false);
								base.transform.Translate(Vector3.forward * -1f);
								this.Yandere.Senpai.GetComponent<StudentScript>().Character.SetActive(true);
								this.Yandere.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
								this.Yandere.transform.position = new Vector3(-27.51f, 0f, 12f);
								this.Yandere.Police.Darkness.color = new Color(0f, 0f, 0f, 1f);
								this.Yandere.CharacterAnimation.Play("f02_sit_00");
								this.Yandere.Noticed = false;
								this.Yandere.Sanity = 100f;
								Physics.SyncTransforms();
								this.GoingToCounselor = false;
								base.enabled = false;
								this.NoticedTimer = 0f;
								this.Phase = 1;
							}
						}
					}
					if (this.Phase < 5)
					{
						base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
						base.transform.LookAt(this.NoticedFocus);
						return;
					}
				}
			}
			else if (this.Scolding)
			{
				if (this.Timer == 0f)
				{
					this.NoticedHeight = 1.6f;
					this.NoticedPOV.position = this.Teacher.position + this.Teacher.forward + Vector3.up * this.NoticedHeight;
					this.NoticedPOV.LookAt(this.Teacher.position + Vector3.up * this.NoticedHeight);
					this.NoticedFocus.position = this.Teacher.position + Vector3.up * this.NoticedHeight;
					this.NoticedSpeed = 10f;
				}
				base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
				base.transform.LookAt(this.NoticedFocus);
				this.Timer += Time.deltaTime;
				if (this.Timer > 6f)
				{
					this.Portal.ClassDarkness.enabled = true;
					this.Portal.Transition = true;
					this.Portal.FadeOut = true;
				}
				if (this.Timer > 7f)
				{
					this.Scolding = false;
					this.Timer = 0f;
					return;
				}
			}
			else if (this.Counter)
			{
				if (this.Timer == 0f)
				{
					this.StruggleFocus.position = base.transform.position + base.transform.forward;
					this.StrugglePOV.position = base.transform.position;
				}
				base.transform.position = Vector3.Lerp(base.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
				base.transform.LookAt(this.StruggleFocus);
				this.Timer += Time.deltaTime;
				if (this.Timer > 0.5f && this.Phase < 2)
				{
					this.Yandere.CameraEffects.MurderWitnessed();
					this.Yandere.Jukebox.GameOver();
					this.Phase++;
				}
				if (this.Timer > 1.4f && this.Phase < 3)
				{
					this.Yandere.Subtitle.UpdateLabel(SubtitleType.TeacherAttackReaction, 1, 4f);
					this.Phase++;
				}
				if (this.Timer > 6f && this.Yandere.Armed)
				{
					this.Yandere.EquippedWeapon.Drop();
				}
				if (this.Timer > 6.66666f && this.Phase < 4)
				{
					base.GetComponent<AudioSource>().PlayOneShot(this.Slam);
					this.Phase++;
				}
				if (this.Timer > 10f && this.Phase < 5)
				{
					this.HeartbrokenCamera.SetActive(true);
					this.Phase++;
				}
				if (this.Timer < 5f)
				{
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0f, 1.4f, 0.7f), Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.5f, 1.4f, 0.3f), Time.deltaTime);
					return;
				}
				if (this.Timer < 10f)
				{
					if (this.Timer < 6.5f)
					{
						this.PullBackTimer = Mathf.MoveTowards(this.PullBackTimer, 1.5f, Time.deltaTime);
					}
					else
					{
						this.PullBackTimer = Mathf.MoveTowards(this.PullBackTimer, 0f, Time.deltaTime * 0.42857143f);
					}
					base.transform.Translate(Vector3.back * Time.deltaTime * 10f * this.PullBackTimer);
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0f, 0.3f, -0.766666f), Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.75f, 0.3f, -0.966666f), Time.deltaTime);
					return;
				}
				this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0f, 0.3f, -0.766666f), Time.deltaTime);
				this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.75f, 0.3f, -0.966666f), Time.deltaTime);
				return;
			}
			else
			{
				if (this.ObstacleCounter)
				{
					this.StruggleFocus.position += new Vector3(this.Shake * UnityEngine.Random.Range(-1f, 1f), this.Shake * UnityEngine.Random.Range(-0.5f, 0.5f), this.Shake * UnityEngine.Random.Range(-1f, 1f));
					this.Shake = Mathf.Lerp(this.Shake, 0f, Time.deltaTime * 5f);
					if (this.Yandere.Armed)
					{
						this.Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
					}
					if (this.Timer == 0f)
					{
						this.StruggleFocus.position = base.transform.position + base.transform.forward;
						this.StrugglePOV.position = base.transform.position;
					}
					base.transform.position = Vector3.Lerp(base.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
					base.transform.LookAt(this.StruggleFocus);
					this.Timer += Time.deltaTime;
					if (this.Timer > 0.5f && this.Phase < 2)
					{
						this.Yandere.CameraEffects.MurderWitnessed();
						this.Yandere.Jukebox.GameOver();
						this.Phase++;
					}
					if (this.Timer > 7.6f && this.Phase < 3)
					{
						if (this.Yandere.Armed)
						{
							this.Yandere.EquippedWeapon.Drop();
						}
						this.Shake += 0.2f;
						this.Phase++;
					}
					if (this.Timer > 10f && this.Phase < 4)
					{
						this.Shake += 0.2f;
						this.Phase++;
					}
					if (this.Timer > 12f && this.Phase < 5)
					{
						this.HeartbrokenCamera.GetComponent<Camera>().cullingMask |= 512;
						this.HeartbrokenCamera.SetActive(true);
						this.Phase++;
					}
					if (this.Timer < 6f)
					{
						this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.166666f, 1.2f, 0.82f), Time.deltaTime);
						this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.66666f, 1.2f, 0.82f), Time.deltaTime);
						this.StruggleDOF = Mathf.MoveTowards(this.StruggleDOF, 0.66666f, Time.deltaTime);
					}
					else if (this.Timer < 8.5f)
					{
						this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.166666f, 1.2f, 0.82f), Time.deltaTime);
						this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(2f, 1.2f, 0.82f), Time.deltaTime);
						this.StruggleDOF = Mathf.MoveTowards(this.StruggleDOF, 1f, Time.deltaTime);
					}
					else if (this.Timer < 12f)
					{
						this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.85f, 0.5f, 1.75f), Time.deltaTime * 2f);
						this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(-0.85f, 0.5f, 3f), Time.deltaTime * 2f);
					}
					else
					{
						this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.85f, 1.1f, 1.75f), Time.deltaTime * 2f);
						this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(-0.85f, 1f, 4f), Time.deltaTime * 2f);
					}
					this.Yandere.CameraEffects.UpdateDOF(this.StruggleDOF);
					return;
				}
				if (this.Struggle)
				{
					base.transform.position = Vector3.Lerp(base.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
					base.transform.LookAt(this.StruggleFocus);
					if (this.Yandere.Lost)
					{
						this.StruggleFocus.localPosition = Vector3.MoveTowards(this.StruggleFocus.localPosition, this.LossFocus, Time.deltaTime);
						this.StrugglePOV.localPosition = Vector3.MoveTowards(this.StrugglePOV.localPosition, this.LossPOV, Time.deltaTime);
						if (this.Timer == 0f)
						{
							AudioSource component2 = base.GetComponent<AudioSource>();
							component2.clip = this.StruggleLose;
							component2.Play();
						}
						this.Timer += Time.deltaTime;
						if (this.Timer < 3f)
						{
							base.transform.Translate(Vector3.back * (Time.deltaTime * 10f * this.Timer * (3f - this.Timer)));
							return;
						}
						if (!this.HeartbrokenCamera.activeInHierarchy)
						{
							this.HeartbrokenCamera.SetActive(true);
							this.Yandere.Jukebox.GameOver();
							base.enabled = false;
							return;
						}
					}
				}
				else
				{
					if (this.Yandere.Attacked)
					{
						this.Focus.transform.parent = null;
						this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime);
						base.transform.LookAt(this.Focus);
						return;
					}
					if (this.LookDown)
					{
						this.Timer += Time.deltaTime;
						if (this.Timer < 5f)
						{
							base.transform.position = Vector3.Lerp(base.transform.position, this.Yandere.Hips.position + Vector3.up * 3f + Vector3.right * 0.1f, Time.deltaTime * this.Timer);
							this.Focus.transform.parent = null;
							this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime * this.Timer);
							base.transform.LookAt(this.Focus);
							return;
						}
						if (!this.HeartbrokenCamera.activeInHierarchy)
						{
							this.HeartbrokenCamera.SetActive(true);
							this.Yandere.Jukebox.GameOver();
							base.enabled = false;
							return;
						}
					}
					else
					{
						if (this.Summoning)
						{
							if (this.Phase == 1)
							{
								this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * 1.7f + this.Yandere.transform.right * 0.15f + Vector3.up * 1.375f;
								this.NoticedFocus.position = base.transform.position + base.transform.forward;
								this.NoticedSpeed = 10f;
								this.Phase++;
							}
							else if (this.Phase == 2)
							{
								this.NoticedPOV.Translate(this.NoticedPOV.forward * (Time.deltaTime * -0.1f));
								this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.transform.position + this.Yandere.transform.right * 0.15f + Vector3.up * 1.375f, Time.deltaTime * 10f);
								this.Timer += Time.deltaTime;
								if (this.Timer > 2f)
								{
									this.Yandere.Stand.Spawn();
									this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * 2f + Vector3.up * 2.4f;
									this.Timer = 0f;
									this.Phase++;
								}
							}
							else if (this.Phase == 3)
							{
								this.NoticedPOV.Translate(this.NoticedPOV.forward * (Time.deltaTime * -0.1f));
								this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 2.4f;
								this.Yandere.Stand.Stand.SetActive(true);
								this.Timer += Time.deltaTime;
								if (this.Timer > 5f)
								{
									this.Phase++;
								}
							}
							else if (this.Phase == 4)
							{
								this.Yandere.Stand.transform.localPosition = new Vector3(this.Yandere.Stand.transform.localPosition.x, 0f, this.Yandere.Stand.transform.localPosition.z);
								this.Yandere.Jukebox.PlayJojo();
								this.Yandere.Talking = true;
								this.Summoning = false;
								this.Timer = 0f;
								this.Phase = 1;
							}
							base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
							base.transform.LookAt(this.NoticedFocus);
							return;
						}
						if ((this.Yandere.Talking || this.Yandere.Won) && !this.RPGCamera.enabled)
						{
							this.Timer += Time.deltaTime;
							if (this.Timer < 0.5f)
							{
								base.transform.position = Vector3.Lerp(base.transform.position, this.LastPosition, Time.deltaTime * this.ReturnSpeed);
								if (this.Yandere.Talking)
								{
									this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * this.ReturnSpeed);
									base.transform.LookAt(this.ShoulderFocus);
									return;
								}
								this.StruggleFocus.position = Vector3.Lerp(this.StruggleFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * this.ReturnSpeed);
								base.transform.LookAt(this.StruggleFocus);
								return;
							}
							else
							{
								this.RPGCamera.enabled = true;
								this.Yandere.MyController.enabled = true;
								this.Yandere.Talking = false;
								if (!this.Yandere.Sprayed)
								{
									this.Yandere.CanMove = true;
								}
								this.Yandere.Pursuer = null;
								this.Yandere.Chased = false;
								this.Yandere.Won = false;
								this.Timer = 0f;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06001CCC RID: 7372 RVA: 0x0015538E File Offset: 0x0015358E
	public void YandereNo()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.StruggleLose;
		component.Play();
	}

	// Token: 0x06001CCD RID: 7373 RVA: 0x001553A8 File Offset: 0x001535A8
	public void GameOver()
	{
		this.NoticedPOV.parent = this.Yandere.transform;
		this.NoticedFocus.parent = this.Yandere.transform;
		this.NoticedFocus.localPosition = new Vector3(0f, 1f, 0f);
		this.NoticedPOV.localPosition = new Vector3(0f, 1f, 2f);
		this.NoticedPOV.LookAt(this.NoticedFocus.position);
		this.Yandere.CharacterAnimation.CrossFade("f02_down_22");
		this.Yandere.HeartCamera.gameObject.SetActive(false);
		this.HeartbrokenCamera.SetActive(true);
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.Collapse = true;
		this.Yandere.HUD.alpha = 0f;
		this.Yandere.StudentManager.Students[1].Pathfinding.canSearch = false;
		this.Yandere.StudentManager.Students[1].Pathfinding.canMove = false;
		this.Yandere.StudentManager.Students[1].Fleeing = false;
	}

	// Token: 0x04003385 RID: 13189
	public PauseScreenScript PauseScreen;

	// Token: 0x04003386 RID: 13190
	public CounselorScript Counselor;

	// Token: 0x04003387 RID: 13191
	public YandereScript Yandere;

	// Token: 0x04003388 RID: 13192
	public RPG_Camera RPGCamera;

	// Token: 0x04003389 RID: 13193
	public PortalScript Portal;

	// Token: 0x0400338A RID: 13194
	public GameObject HeartbrokenCamera;

	// Token: 0x0400338B RID: 13195
	public GameObject HUD;

	// Token: 0x0400338C RID: 13196
	public Transform Smartphone;

	// Token: 0x0400338D RID: 13197
	public Transform Teacher;

	// Token: 0x0400338E RID: 13198
	public Transform ShoulderFocus;

	// Token: 0x0400338F RID: 13199
	public Transform ShoulderPOV;

	// Token: 0x04003390 RID: 13200
	public Transform EightiesSpineFollower;

	// Token: 0x04003391 RID: 13201
	public Transform EightiesCameraFocus;

	// Token: 0x04003392 RID: 13202
	public Transform EightiesCameraPOV;

	// Token: 0x04003393 RID: 13203
	public Transform CameraFocus;

	// Token: 0x04003394 RID: 13204
	public Transform CameraPOV;

	// Token: 0x04003395 RID: 13205
	public Transform NoticedFocus;

	// Token: 0x04003396 RID: 13206
	public Transform NoticedPOV;

	// Token: 0x04003397 RID: 13207
	public Transform StruggleFocus;

	// Token: 0x04003398 RID: 13208
	public Transform StrugglePOV;

	// Token: 0x04003399 RID: 13209
	public Transform Focus;

	// Token: 0x0400339A RID: 13210
	public Vector3 LastPosition;

	// Token: 0x0400339B RID: 13211
	public Vector3 TeacherLossFocus;

	// Token: 0x0400339C RID: 13212
	public Vector3 TeacherLossPOV;

	// Token: 0x0400339D RID: 13213
	public Vector3 LossFocus;

	// Token: 0x0400339E RID: 13214
	public Vector3 LossPOV;

	// Token: 0x0400339F RID: 13215
	public bool GoingToCounselor;

	// Token: 0x040033A0 RID: 13216
	public bool ObstacleCounter;

	// Token: 0x040033A1 RID: 13217
	public bool AimingCamera;

	// Token: 0x040033A2 RID: 13218
	public bool OverShoulder;

	// Token: 0x040033A3 RID: 13219
	public bool Summoning;

	// Token: 0x040033A4 RID: 13220
	public bool LookDown;

	// Token: 0x040033A5 RID: 13221
	public bool Scolding;

	// Token: 0x040033A6 RID: 13222
	public bool Struggle;

	// Token: 0x040033A7 RID: 13223
	public bool Counter;

	// Token: 0x040033A8 RID: 13224
	public bool Noticed;

	// Token: 0x040033A9 RID: 13225
	public bool Spoken;

	// Token: 0x040033AA RID: 13226
	public bool Skip;

	// Token: 0x040033AB RID: 13227
	public AudioClip StruggleLose;

	// Token: 0x040033AC RID: 13228
	public AudioClip Slam;

	// Token: 0x040033AD RID: 13229
	public float NoticedHeight;

	// Token: 0x040033AE RID: 13230
	public float NoticedTimer;

	// Token: 0x040033AF RID: 13231
	public float NoticedSpeed;

	// Token: 0x040033B0 RID: 13232
	public float ReturnSpeed = 10f;

	// Token: 0x040033B1 RID: 13233
	public float StruggleDOF = 2f;

	// Token: 0x040033B2 RID: 13234
	public float Height;

	// Token: 0x040033B3 RID: 13235
	public float Shake;

	// Token: 0x040033B4 RID: 13236
	public float PullBackTimer;

	// Token: 0x040033B5 RID: 13237
	public float Timer;

	// Token: 0x040033B6 RID: 13238
	public int NoticedLimit;

	// Token: 0x040033B7 RID: 13239
	public int Phase;
}
