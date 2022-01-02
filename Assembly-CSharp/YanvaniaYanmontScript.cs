using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004E1 RID: 1249
[RequireComponent(typeof(CharacterController))]
public class YanvaniaYanmontScript : MonoBehaviour
{
	// Token: 0x06002097 RID: 8343 RVA: 0x001DE3F0 File Offset: 0x001DC5F0
	private void Awake()
	{
		this.MyAnimation = this.Character.GetComponent<Animation>();
		this.MyAnimation[this.DeathAnim].speed = 0.25f;
		this.MyAnimation[this.AttackAnim].speed = 2f;
		this.MyAnimation[this.CrouchAttackAnim].speed = 2f;
		this.MyAnimation[this.WalkAnim].speed = 2.5f;
		this.MyAnimation[this.WhipNeutralAnim].speed = 0f;
		this.MyAnimation[this.WhipUpAnim].speed = 0f;
		this.MyAnimation[this.WhipRightAnim].speed = 0f;
		this.MyAnimation[this.WhipDownAnim].speed = 0f;
		this.MyAnimation[this.WhipLeftAnim].speed = 0f;
		this.MyAnimation[this.CrouchPoseAnim].layer = 1;
		this.MyAnimation.Play(this.CrouchPoseAnim);
		this.MyAnimation[this.CrouchPoseAnim].weight = 0f;
		Physics.IgnoreLayerCollision(19, 13, true);
		Physics.IgnoreLayerCollision(19, 19, true);
	}

	// Token: 0x06002098 RID: 8344 RVA: 0x001DE55C File Offset: 0x001DC75C
	private void Start()
	{
		this.WhipChain[0].transform.localScale = Vector3.zero;
		this.MyAnimation.Play(this.IdleAnim);
		this.controller = base.GetComponent<CharacterController>();
		this.myTransform = base.transform;
		this.speed = this.walkSpeed;
		this.rayDistance = this.controller.height * 0.5f + this.controller.radius;
		this.slideLimit = this.controller.slopeLimit - 0.1f;
		this.jumpTimer = this.antiBunnyHopFactor;
		this.originalThreshold = this.fallingDamageThreshold;
	}

	// Token: 0x06002099 RID: 8345 RVA: 0x001DE608 File Offset: 0x001DC808
	private void FixedUpdate()
	{
		if (this.CanMove)
		{
			if (!this.Injured)
			{
				if (!this.Cutscene)
				{
					if (this.grounded)
					{
						if (!this.Attacking)
						{
							if (!this.Crouching)
							{
								if (Input.GetAxis("VaniaHorizontal") > 0f)
								{
									this.inputX = 1f;
								}
								else if (Input.GetAxis("VaniaHorizontal") < 0f)
								{
									this.inputX = -1f;
								}
								else
								{
									this.inputX = 0f;
								}
							}
						}
						else if (this.grounded)
						{
							this.fallingDamageThreshold = 100f;
							this.moveDirection.x = 0f;
							this.inputX = 0f;
							this.speed = 0f;
						}
					}
					else if (Input.GetAxis("VaniaHorizontal") != 0f)
					{
						if (Input.GetAxis("VaniaHorizontal") > 0f)
						{
							this.inputX = 1f;
						}
						else if (Input.GetAxis("VaniaHorizontal") < 0f)
						{
							this.inputX = -1f;
						}
						else
						{
							this.inputX = 0f;
						}
					}
					else
					{
						this.inputX = Mathf.MoveTowards(this.inputX, 0f, Time.deltaTime * 10f);
					}
					float num = 0f;
					float num2 = (this.inputX != 0f && num != 0f && this.limitDiagonalSpeed) ? 0.70710677f : 1f;
					if (!this.Attacking)
					{
						if (Input.GetAxis("VaniaHorizontal") < 0f)
						{
							this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
							this.Character.transform.localScale = new Vector3(-1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
						}
						else if (Input.GetAxis("VaniaHorizontal") > 0f)
						{
							this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, 90f, this.Character.transform.localEulerAngles.z);
							this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
						}
					}
					if (this.grounded)
					{
						if (!this.Attacking && !this.Dangling)
						{
							if (Input.GetAxis("VaniaVertical") < -0.5f)
							{
								this.MyController.center = new Vector3(this.MyController.center.x, 0.5f, this.MyController.center.z);
								this.MyController.height = 1f;
								this.Crouching = true;
								this.IdleTimer = 10f;
								this.inputX = 0f;
							}
							if (this.Crouching)
							{
								this.MyAnimation.CrossFade(this.CrouchAnim, 0.1f);
								if (!this.Attacking)
								{
									if (!this.Dangling)
									{
										if (Input.GetAxis("VaniaVertical") > -0.5f)
										{
											this.MyAnimation[this.CrouchPoseAnim].weight = 0f;
											this.MyController.center = new Vector3(this.MyController.center.x, 0.75f, this.MyController.center.z);
											this.MyController.height = 1.5f;
											this.Crouching = false;
										}
									}
									else if (Input.GetAxis("VaniaVertical") > -0.5f && Input.GetButton("X"))
									{
										this.MyAnimation[this.CrouchPoseAnim].weight = 0f;
										this.MyController.center = new Vector3(this.MyController.center.x, 0.75f, this.MyController.center.z);
										this.MyController.height = 1.5f;
										this.Crouching = false;
									}
								}
							}
							else if (this.inputX == 0f)
							{
								if (this.IdleTimer > 0f)
								{
									this.MyAnimation.CrossFade(this.IdleAnim, 0.1f);
									this.MyAnimation[this.IdleAnim].speed = this.IdleTimer / 10f;
								}
								else
								{
									this.MyAnimation.CrossFade(this.DramaticIdleAnim, 1f);
								}
								this.IdleTimer -= Time.deltaTime;
							}
							else
							{
								this.IdleTimer = 10f;
								this.MyAnimation.CrossFade((this.speed == this.walkSpeed) ? this.WalkAnim : this.RunAnim, 0.1f);
							}
						}
						bool flag = false;
						if (Physics.Raycast(this.myTransform.position, -Vector3.up, out this.hit, this.rayDistance))
						{
							if (Vector3.Angle(this.hit.normal, Vector3.up) > this.slideLimit)
							{
								flag = true;
							}
						}
						else
						{
							Physics.Raycast(this.contactPoint + Vector3.up, -Vector3.up, out this.hit);
							if (Vector3.Angle(this.hit.normal, Vector3.up) > this.slideLimit)
							{
								flag = true;
							}
						}
						if (this.falling)
						{
							this.falling = false;
							if (this.myTransform.position.y < this.fallStartLevel - this.fallingDamageThreshold)
							{
								this.FallingDamageAlert(this.fallStartLevel - this.myTransform.position.y);
							}
							this.fallingDamageThreshold = this.originalThreshold;
						}
						if (!this.toggleRun)
						{
							this.speed = (Input.GetKey(KeyCode.LeftShift) ? this.runSpeed : this.walkSpeed);
						}
						if ((flag && this.slideWhenOverSlopeLimit) || (this.slideOnTaggedObjects && this.hit.collider.tag == "Slide"))
						{
							Vector3 normal = this.hit.normal;
							this.moveDirection = new Vector3(normal.x, -normal.y, normal.z);
							Vector3.OrthoNormalize(ref normal, ref this.moveDirection);
							this.moveDirection *= this.slideSpeed;
							this.playerControl = false;
						}
						else
						{
							this.moveDirection = new Vector3(this.inputX * num2, -this.antiBumpFactor, num * num2);
							this.moveDirection = this.myTransform.TransformDirection(this.moveDirection) * this.speed;
							this.playerControl = true;
						}
						if (!Input.GetButton("VaniaJump"))
						{
							this.jumpTimer++;
						}
						else if (this.jumpTimer >= this.antiBunnyHopFactor && !this.Attacking)
						{
							this.Crouching = false;
							this.fallingDamageThreshold = 0f;
							this.moveDirection.y = this.jumpSpeed;
							this.IdleTimer = 10f;
							this.jumpTimer = 0;
							AudioSource component = base.GetComponent<AudioSource>();
							component.clip = this.Voices[UnityEngine.Random.Range(0, this.Voices.Length)];
							component.Play();
						}
					}
					else
					{
						if (!this.Attacking)
						{
							this.MyAnimation.CrossFade((base.transform.position.y > this.PreviousY) ? this.JumpAnim : this.FallAnim, 0.4f);
						}
						this.PreviousY = base.transform.position.y;
						if (!this.falling)
						{
							this.falling = true;
							this.fallStartLevel = this.myTransform.position.y;
						}
						if (this.airControl && this.playerControl)
						{
							this.moveDirection.x = this.inputX * this.speed * num2;
							this.moveDirection.z = num * this.speed * num2;
							this.moveDirection = this.myTransform.TransformDirection(this.moveDirection);
						}
					}
				}
				else
				{
					this.moveDirection.x = 0f;
					if (this.grounded)
					{
						if (base.transform.position.x > -34f)
						{
							this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
							this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
							base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34f, Time.deltaTime * this.walkSpeed), base.transform.position.y, base.transform.position.z);
							this.MyAnimation.CrossFade(this.WalkAnim);
						}
						else if (base.transform.position.x < -34f)
						{
							this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, 90f, this.Character.transform.localEulerAngles.z);
							this.Character.transform.localScale = new Vector3(-1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
							base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34f, Time.deltaTime * this.walkSpeed), base.transform.position.y, base.transform.position.z);
							this.MyAnimation.CrossFade(this.WalkAnim);
						}
						else
						{
							this.MyAnimation.CrossFade(this.DramaticIdleAnim, 1f);
							this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
							this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
							this.WhipChain[0].transform.localScale = Vector3.zero;
							this.fallingDamageThreshold = 100f;
							this.TextBox.SetActive(true);
							this.Attacking = false;
							base.enabled = false;
						}
					}
					Physics.SyncTransforms();
				}
			}
			else
			{
				this.MyAnimation.CrossFade("f02_damage_25");
				this.RecoveryTimer += Time.deltaTime;
				if (this.RecoveryTimer > 1f)
				{
					this.RecoveryTimer = 0f;
					this.Injured = false;
				}
			}
			this.moveDirection.y = this.moveDirection.y - this.gravity * Time.deltaTime;
			this.grounded = ((this.controller.Move(this.moveDirection * Time.deltaTime) & CollisionFlags.Below) > CollisionFlags.None);
			if (this.grounded && this.EnterCutscene)
			{
				this.YanvaniaCamera.Cutscene = true;
				this.Cutscene = true;
			}
			if ((this.controller.collisionFlags & CollisionFlags.Above) != CollisionFlags.None && this.moveDirection.y > 0f)
			{
				this.moveDirection.y = 0f;
				return;
			}
		}
		else if (this.Health == 0f)
		{
			this.DeathTimer += Time.deltaTime;
			if (this.DeathTimer > 5f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime * 0.2f);
				if (this.Darkness.color.a >= 1f)
				{
					if (this.Darkness.gameObject.activeInHierarchy)
					{
						this.HealthBar.parent.gameObject.SetActive(false);
						this.EXPBar.parent.gameObject.SetActive(false);
						this.Darkness.gameObject.SetActive(false);
						this.BossHealthBar.SetActive(false);
						this.BlackBG.SetActive(true);
					}
					this.TryAgainWindow.transform.localScale = Vector3.Lerp(this.TryAgainWindow.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
		}
	}

	// Token: 0x0600209A RID: 8346 RVA: 0x001DF400 File Offset: 0x001DD600
	private void Update()
	{
		Animation component = this.Character.GetComponent<Animation>();
		if (!this.Injured && this.CanMove && !this.Cutscene)
		{
			if (this.grounded)
			{
				if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
				{
					this.TapTimer = 0.25f;
					this.Taps++;
				}
				if (this.Taps > 1)
				{
					this.speed = this.runSpeed;
				}
			}
			if (this.inputX == 0f)
			{
				this.speed = this.walkSpeed;
			}
			this.TapTimer -= Time.deltaTime;
			if (this.TapTimer < 0f)
			{
				this.Taps = 0;
			}
			if (Input.GetButtonDown("VaniaAttack") && !this.Attacking)
			{
				AudioSource.PlayClipAtPoint(this.WhipSound, base.transform.position);
				AudioSource component2 = base.GetComponent<AudioSource>();
				component2.clip = this.Voices[UnityEngine.Random.Range(0, this.Voices.Length)];
				component2.Play();
				this.WhipChain[0].transform.localScale = Vector3.zero;
				this.Attacking = true;
				this.IdleTimer = 10f;
				if (this.Crouching)
				{
					component[this.CrouchAttackAnim].time = 0f;
					component.Play(this.CrouchAttackAnim);
				}
				else
				{
					component[this.AttackAnim].time = 0f;
					component.Play(this.AttackAnim);
				}
				if (this.grounded)
				{
					this.moveDirection.x = 0f;
					this.inputX = 0f;
					this.speed = 0f;
				}
			}
			if (this.Attacking)
			{
				if (!this.Dangling)
				{
					this.WhipChain[0].transform.localScale = Vector3.MoveTowards(this.WhipChain[0].transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f);
					this.StraightenWhip();
				}
				else
				{
					this.LoosenWhip();
					if (Input.GetAxis("VaniaHorizontal") > -0.5f && Input.GetAxis("VaniaHorizontal") < 0.5f && Input.GetAxis("VaniaVertical") > -0.5f && Input.GetAxis("VaniaVertical") < 0.5f)
					{
						component.CrossFade(this.WhipNeutralAnim);
						if (this.Crouching)
						{
							component[this.CrouchPoseAnim].weight = 1f;
						}
						this.SpunUp = false;
						this.SpunDown = false;
						this.SpunRight = false;
						this.SpunLeft = false;
					}
					else
					{
						if (Input.GetAxis("VaniaVertical") > 0.5f)
						{
							if (!this.SpunUp)
							{
								AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
								this.StraightenWhip();
								this.TargetRotation = -360f;
								this.Rotation = 0f;
								this.SpunUp = true;
							}
							component.CrossFade(this.WhipUpAnim, 0.1f);
						}
						else
						{
							this.SpunUp = false;
						}
						if (Input.GetAxis("VaniaVertical") < -0.5f)
						{
							if (!this.SpunDown)
							{
								AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
								this.StraightenWhip();
								this.TargetRotation = 360f;
								this.Rotation = 0f;
								this.SpunDown = true;
							}
							component.CrossFade(this.WhipDownAnim, 0.1f);
						}
						else
						{
							this.SpunDown = false;
						}
						if (Input.GetAxis("VaniaHorizontal") > 0.5f)
						{
							if (this.Character.transform.localScale.x == 1f)
							{
								this.SpinLeft();
							}
							else
							{
								this.SpinRight();
							}
						}
						else if (this.Character.transform.localScale.x == 1f)
						{
							this.SpunLeft = false;
						}
						else
						{
							this.SpunRight = false;
						}
						if (Input.GetAxis("VaniaHorizontal") < -0.5f)
						{
							if (this.Character.transform.localScale.x == 1f)
							{
								this.SpinRight();
							}
							else
							{
								this.SpinLeft();
							}
						}
						else if (this.Character.transform.localScale.x == 1f)
						{
							this.SpunRight = false;
						}
						else
						{
							this.SpunLeft = false;
						}
					}
					this.Rotation = Mathf.MoveTowards(this.Rotation, this.TargetRotation, Time.deltaTime * 3600f * 0.5f);
					this.WhipChain[1].transform.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
					if (!Input.GetButton("VaniaAttack"))
					{
						this.StopAttacking();
					}
				}
			}
			else
			{
				if (this.WhipCollider[1].enabled)
				{
					for (int i = 1; i < this.WhipChain.Length; i++)
					{
						this.SphereCollider[i].enabled = false;
						this.WhipCollider[i].enabled = false;
					}
				}
				this.WhipChain[0].transform.localScale = Vector3.MoveTowards(this.WhipChain[0].transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			if ((!this.Crouching && component[this.AttackAnim].time >= component[this.AttackAnim].length) || (this.Crouching && component[this.CrouchAttackAnim].time >= component[this.CrouchAttackAnim].length))
			{
				if (Input.GetButton("VaniaAttack"))
				{
					if (this.Crouching)
					{
						component[this.CrouchPoseAnim].weight = 1f;
					}
					this.Dangling = true;
				}
				else
				{
					this.StopAttacking();
				}
			}
		}
		if (this.FlashTimer > 0f)
		{
			this.FlashTimer -= Time.deltaTime;
			if (!this.Red)
			{
				Material[] materials = this.MyRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].color = new Color(1f, 0f, 0f, 1f);
				}
				this.Frames++;
				if (this.Frames == 5)
				{
					this.Frames = 0;
					this.Red = true;
				}
			}
			else
			{
				Material[] materials = this.MyRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].color = new Color(1f, 1f, 1f, 1f);
				}
				this.Frames++;
				if (this.Frames == 5)
				{
					this.Frames = 0;
					this.Red = false;
				}
			}
		}
		else
		{
			this.FlashTimer = 0f;
			if (this.MyRenderer.materials[0].color != new Color(1f, 1f, 1f, 1f))
			{
				Material[] materials = this.MyRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].color = new Color(1f, 1f, 1f, 1f);
				}
			}
		}
		this.HealthBar.localScale = new Vector3(this.HealthBar.localScale.x, Mathf.Lerp(this.HealthBar.localScale.y, this.Health / this.MaxHealth, Time.deltaTime * 10f), this.HealthBar.localScale.z);
		if (this.Health > 0f)
		{
			if (this.EXP >= 100f)
			{
				this.Level++;
				if (this.Level >= 99)
				{
					this.Level = 99;
				}
				else
				{
					UnityEngine.Object.Instantiate<GameObject>(this.LevelUpEffect, this.LevelLabel.transform.position, Quaternion.identity).transform.parent = this.LevelLabel.transform;
					this.MaxHealth += 20f;
					this.Health = this.MaxHealth;
					this.EXP -= 100f;
				}
				this.LevelLabel.text = this.Level.ToString();
			}
			this.EXPBar.localScale = new Vector3(this.EXPBar.localScale.x, Mathf.Lerp(this.EXPBar.localScale.y, this.EXP / 100f, Time.deltaTime * 10f), this.EXPBar.localScale.z);
		}
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 0f);
		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			base.transform.position = new Vector3(-31.75f, 6.51f, 0f);
			Physics.SyncTransforms();
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			this.Level = 5;
			this.LevelLabel.text = this.Level.ToString();
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Time.timeScale += 10f;
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			Time.timeScale -= 10f;
			if (Time.timeScale < 0f)
			{
				Time.timeScale = 1f;
			}
		}
	}

	// Token: 0x0600209B RID: 8347 RVA: 0x001DFDC5 File Offset: 0x001DDFC5
	private void LateUpdate()
	{
	}

	// Token: 0x0600209C RID: 8348 RVA: 0x001DFDC7 File Offset: 0x001DDFC7
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		this.contactPoint = this.hit.point;
	}

	// Token: 0x0600209D RID: 8349 RVA: 0x001DFDDC File Offset: 0x001DDFDC
	private void FallingDamageAlert(float fallDistance)
	{
		AudioClipPlayer.Play2D(this.LandSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
		this.Character.GetComponent<Animation>().Play(this.CrouchAnim);
		this.fallingDamageThreshold = this.originalThreshold;
	}

	// Token: 0x0600209E RID: 8350 RVA: 0x001DFE34 File Offset: 0x001DE034
	private void SpinRight()
	{
		if (!this.SpunRight)
		{
			AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
			this.StraightenWhip();
			this.TargetRotation = 360f;
			this.Rotation = 0f;
			this.SpunRight = true;
		}
		this.Character.GetComponent<Animation>().CrossFade(this.WhipRightAnim, 0.1f);
	}

	// Token: 0x0600209F RID: 8351 RVA: 0x001DFEAC File Offset: 0x001DE0AC
	private void SpinLeft()
	{
		if (!this.SpunLeft)
		{
			AudioClipPlayer.Play2D(this.WhipSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
			this.StraightenWhip();
			this.TargetRotation = -360f;
			this.Rotation = 0f;
			this.SpunLeft = true;
		}
		this.Character.GetComponent<Animation>().CrossFade(this.WhipLeftAnim, 0.1f);
	}

	// Token: 0x060020A0 RID: 8352 RVA: 0x001DFF24 File Offset: 0x001DE124
	private void StraightenWhip()
	{
		for (int i = 1; i < this.WhipChain.Length; i++)
		{
			this.WhipCollider[i].enabled = true;
			this.WhipChain[i].gameObject.GetComponent<Rigidbody>().isKinematic = true;
			Transform transform = this.WhipChain[i].transform;
			transform.localPosition = new Vector3(0f, -0.03f, 0f);
			transform.localEulerAngles = Vector3.zero;
		}
		this.WhipChain[1].transform.localPosition = new Vector3(0f, -0.1f, 0f);
		this.WhipTimer = 0f;
		this.Loose = false;
	}

	// Token: 0x060020A1 RID: 8353 RVA: 0x001DFFD4 File Offset: 0x001DE1D4
	private void LoosenWhip()
	{
		if (!this.Loose)
		{
			this.WhipTimer += Time.deltaTime;
			if (this.WhipTimer > 0.25f)
			{
				for (int i = 1; i < this.WhipChain.Length; i++)
				{
					this.WhipChain[i].gameObject.GetComponent<Rigidbody>().isKinematic = false;
					this.SphereCollider[i].enabled = true;
				}
				this.Loose = true;
			}
		}
	}

	// Token: 0x060020A2 RID: 8354 RVA: 0x001E0048 File Offset: 0x001DE248
	private void StopAttacking()
	{
		this.Character.GetComponent<Animation>()[this.CrouchPoseAnim].weight = 0f;
		this.TargetRotation = 0f;
		this.Rotation = 0f;
		this.Attacking = false;
		this.Dangling = false;
		this.SpunUp = false;
		this.SpunDown = false;
		this.SpunRight = false;
		this.SpunLeft = false;
	}

	// Token: 0x060020A3 RID: 8355 RVA: 0x001E00B8 File Offset: 0x001DE2B8
	public void TakeDamage(int Damage)
	{
		if (this.WhipCollider[1].enabled)
		{
			for (int i = 1; i < this.WhipChain.Length; i++)
			{
				this.SphereCollider[i].enabled = false;
				this.WhipCollider[i].enabled = false;
			}
		}
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.Injuries[UnityEngine.Random.Range(0, this.Injuries.Length)];
		component.Play();
		this.WhipChain[0].transform.localScale = Vector3.zero;
		Animation component2 = this.Character.GetComponent<Animation>();
		component2["f02_damage_25"].time = 0f;
		this.fallingDamageThreshold = 100f;
		this.moveDirection.x = 0f;
		this.RecoveryTimer = 0f;
		this.FlashTimer = 2f;
		this.Injured = true;
		this.StopAttacking();
		this.Health -= (float)Damage;
		if (this.Dracula.Health <= 0f)
		{
			this.Health = 1f;
		}
		if (this.Dracula.Health > 0f && this.Health <= 0f)
		{
			if (this.NewBlood == null)
			{
				this.MyController.enabled = false;
				this.YanvaniaCamera.StopMusic = true;
				component.clip = this.DeathSound;
				component.Play();
				this.NewBlood = UnityEngine.Object.Instantiate<GameObject>(this.DeathBlood, base.transform.position, Quaternion.identity);
				this.NewBlood.transform.parent = this.Hips;
				this.NewBlood.transform.localPosition = Vector3.zero;
				component2.CrossFade(this.DeathAnim);
				this.CanMove = false;
			}
			this.Health = 0f;
		}
	}

	// Token: 0x0400477E RID: 18302
	private GameObject NewBlood;

	// Token: 0x0400477F RID: 18303
	public YanvaniaCameraScript YanvaniaCamera;

	// Token: 0x04004780 RID: 18304
	public InputManagerScript InputManager;

	// Token: 0x04004781 RID: 18305
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004782 RID: 18306
	public Animation MyAnimation;

	// Token: 0x04004783 RID: 18307
	public CharacterController MyController;

	// Token: 0x04004784 RID: 18308
	public GameObject BossHealthBar;

	// Token: 0x04004785 RID: 18309
	public GameObject LevelUpEffect;

	// Token: 0x04004786 RID: 18310
	public GameObject DeathBlood;

	// Token: 0x04004787 RID: 18311
	public GameObject Character;

	// Token: 0x04004788 RID: 18312
	public GameObject BlackBG;

	// Token: 0x04004789 RID: 18313
	public GameObject TextBox;

	// Token: 0x0400478A RID: 18314
	public Renderer MyRenderer;

	// Token: 0x0400478B RID: 18315
	public Transform TryAgainWindow;

	// Token: 0x0400478C RID: 18316
	public Transform HealthBar;

	// Token: 0x0400478D RID: 18317
	public Transform EXPBar;

	// Token: 0x0400478E RID: 18318
	public Transform Hips;

	// Token: 0x0400478F RID: 18319
	public Transform TrailStart;

	// Token: 0x04004790 RID: 18320
	public Transform TrailEnd;

	// Token: 0x04004791 RID: 18321
	public UITexture Photograph;

	// Token: 0x04004792 RID: 18322
	public UILabel LevelLabel;

	// Token: 0x04004793 RID: 18323
	public UISprite Darkness;

	// Token: 0x04004794 RID: 18324
	public Collider[] SphereCollider;

	// Token: 0x04004795 RID: 18325
	public Collider[] WhipCollider;

	// Token: 0x04004796 RID: 18326
	public Transform[] WhipChain;

	// Token: 0x04004797 RID: 18327
	public AudioClip[] Voices;

	// Token: 0x04004798 RID: 18328
	public AudioClip[] Injuries;

	// Token: 0x04004799 RID: 18329
	public AudioClip DeathSound;

	// Token: 0x0400479A RID: 18330
	public AudioClip LandSound;

	// Token: 0x0400479B RID: 18331
	public AudioClip WhipSound;

	// Token: 0x0400479C RID: 18332
	public bool Attacking;

	// Token: 0x0400479D RID: 18333
	public bool Crouching;

	// Token: 0x0400479E RID: 18334
	public bool Dangling;

	// Token: 0x0400479F RID: 18335
	public bool EnterCutscene;

	// Token: 0x040047A0 RID: 18336
	public bool Cutscene;

	// Token: 0x040047A1 RID: 18337
	public bool CanMove;

	// Token: 0x040047A2 RID: 18338
	public bool Injured;

	// Token: 0x040047A3 RID: 18339
	public bool Loose;

	// Token: 0x040047A4 RID: 18340
	public bool Red;

	// Token: 0x040047A5 RID: 18341
	public bool SpunUp;

	// Token: 0x040047A6 RID: 18342
	public bool SpunDown;

	// Token: 0x040047A7 RID: 18343
	public bool SpunRight;

	// Token: 0x040047A8 RID: 18344
	public bool SpunLeft;

	// Token: 0x040047A9 RID: 18345
	public float TargetRotation;

	// Token: 0x040047AA RID: 18346
	public float Rotation;

	// Token: 0x040047AB RID: 18347
	public float RecoveryTimer;

	// Token: 0x040047AC RID: 18348
	public float DeathTimer;

	// Token: 0x040047AD RID: 18349
	public float FlashTimer;

	// Token: 0x040047AE RID: 18350
	public float IdleTimer;

	// Token: 0x040047AF RID: 18351
	public float WhipTimer;

	// Token: 0x040047B0 RID: 18352
	public float TapTimer;

	// Token: 0x040047B1 RID: 18353
	public float PreviousY;

	// Token: 0x040047B2 RID: 18354
	public float MaxHealth = 100f;

	// Token: 0x040047B3 RID: 18355
	public float Health = 100f;

	// Token: 0x040047B4 RID: 18356
	public float EXP;

	// Token: 0x040047B5 RID: 18357
	public int Frames;

	// Token: 0x040047B6 RID: 18358
	public int Level;

	// Token: 0x040047B7 RID: 18359
	public int Taps;

	// Token: 0x040047B8 RID: 18360
	public float walkSpeed = 6f;

	// Token: 0x040047B9 RID: 18361
	public float runSpeed = 11f;

	// Token: 0x040047BA RID: 18362
	public bool limitDiagonalSpeed = true;

	// Token: 0x040047BB RID: 18363
	public bool toggleRun;

	// Token: 0x040047BC RID: 18364
	public float jumpSpeed = 8f;

	// Token: 0x040047BD RID: 18365
	public float gravity = 20f;

	// Token: 0x040047BE RID: 18366
	public float fallingDamageThreshold = 10f;

	// Token: 0x040047BF RID: 18367
	public bool slideWhenOverSlopeLimit;

	// Token: 0x040047C0 RID: 18368
	public bool slideOnTaggedObjects;

	// Token: 0x040047C1 RID: 18369
	public float slideSpeed = 12f;

	// Token: 0x040047C2 RID: 18370
	public bool airControl;

	// Token: 0x040047C3 RID: 18371
	public float antiBumpFactor = 0.75f;

	// Token: 0x040047C4 RID: 18372
	public int antiBunnyHopFactor = 1;

	// Token: 0x040047C5 RID: 18373
	private Vector3 moveDirection = Vector3.zero;

	// Token: 0x040047C6 RID: 18374
	public bool grounded;

	// Token: 0x040047C7 RID: 18375
	private CharacterController controller;

	// Token: 0x040047C8 RID: 18376
	private Transform myTransform;

	// Token: 0x040047C9 RID: 18377
	private float speed;

	// Token: 0x040047CA RID: 18378
	private RaycastHit hit;

	// Token: 0x040047CB RID: 18379
	private float fallStartLevel;

	// Token: 0x040047CC RID: 18380
	private bool falling;

	// Token: 0x040047CD RID: 18381
	private float slideLimit;

	// Token: 0x040047CE RID: 18382
	private float rayDistance;

	// Token: 0x040047CF RID: 18383
	private Vector3 contactPoint;

	// Token: 0x040047D0 RID: 18384
	private bool playerControl;

	// Token: 0x040047D1 RID: 18385
	private int jumpTimer;

	// Token: 0x040047D2 RID: 18386
	private float originalThreshold;

	// Token: 0x040047D3 RID: 18387
	public float inputX;

	// Token: 0x040047D4 RID: 18388
	public string DeathAnim = "f02_yanvaniaDeath_00";

	// Token: 0x040047D5 RID: 18389
	public string AttackAnim = "f02_yanvaniaAttack_00";

	// Token: 0x040047D6 RID: 18390
	public string CrouchAttackAnim = "f02_yanvaniaCrouchAttack_00";

	// Token: 0x040047D7 RID: 18391
	public string IdleAnim = "f02_yanvaniaIdle_00";

	// Token: 0x040047D8 RID: 18392
	public string DramaticIdleAnim = "f02_yanvaniaDramaticIdle_00";

	// Token: 0x040047D9 RID: 18393
	public string JumpAnim = "f02_yanvaniaJump_00";

	// Token: 0x040047DA RID: 18394
	public string FallAnim = "f02_yanvaniaFall_00";

	// Token: 0x040047DB RID: 18395
	public string CrouchAnim = "f02_yanvaniaCrouch_00";

	// Token: 0x040047DC RID: 18396
	public string CrouchPoseAnim = "f02_yanvaniaCrouchPose_00";

	// Token: 0x040047DD RID: 18397
	public string WalkAnim = "f02_yanvaniaWalk_00";

	// Token: 0x040047DE RID: 18398
	public string RunAnim = "f02_yanvaniaRun_00";

	// Token: 0x040047DF RID: 18399
	public string WhipNeutralAnim = "f02_yanvaniaWhip_Neutral";

	// Token: 0x040047E0 RID: 18400
	public string WhipUpAnim = "f02_yanvaniaWhip_Up";

	// Token: 0x040047E1 RID: 18401
	public string WhipRightAnim = "f02_yanvaniaWhip_Right";

	// Token: 0x040047E2 RID: 18402
	public string WhipDownAnim = "f02_yanvaniaWhip_Down";

	// Token: 0x040047E3 RID: 18403
	public string WhipLeftAnim = "f02_yanvaniaWhip_Left";
}
