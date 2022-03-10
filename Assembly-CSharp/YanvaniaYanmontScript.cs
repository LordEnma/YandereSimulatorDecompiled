using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004E7 RID: 1255
[RequireComponent(typeof(CharacterController))]
public class YanvaniaYanmontScript : MonoBehaviour
{
	// Token: 0x060020C3 RID: 8387 RVA: 0x001E2288 File Offset: 0x001E0488
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

	// Token: 0x060020C4 RID: 8388 RVA: 0x001E23F4 File Offset: 0x001E05F4
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

	// Token: 0x060020C5 RID: 8389 RVA: 0x001E24A0 File Offset: 0x001E06A0
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

	// Token: 0x060020C6 RID: 8390 RVA: 0x001E3298 File Offset: 0x001E1498
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

	// Token: 0x060020C7 RID: 8391 RVA: 0x001E3C5D File Offset: 0x001E1E5D
	private void LateUpdate()
	{
	}

	// Token: 0x060020C8 RID: 8392 RVA: 0x001E3C5F File Offset: 0x001E1E5F
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		this.contactPoint = this.hit.point;
	}

	// Token: 0x060020C9 RID: 8393 RVA: 0x001E3C74 File Offset: 0x001E1E74
	private void FallingDamageAlert(float fallDistance)
	{
		AudioClipPlayer.Play2D(this.LandSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
		this.Character.GetComponent<Animation>().Play(this.CrouchAnim);
		this.fallingDamageThreshold = this.originalThreshold;
	}

	// Token: 0x060020CA RID: 8394 RVA: 0x001E3CCC File Offset: 0x001E1ECC
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

	// Token: 0x060020CB RID: 8395 RVA: 0x001E3D44 File Offset: 0x001E1F44
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

	// Token: 0x060020CC RID: 8396 RVA: 0x001E3DBC File Offset: 0x001E1FBC
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

	// Token: 0x060020CD RID: 8397 RVA: 0x001E3E6C File Offset: 0x001E206C
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

	// Token: 0x060020CE RID: 8398 RVA: 0x001E3EE0 File Offset: 0x001E20E0
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

	// Token: 0x060020CF RID: 8399 RVA: 0x001E3F50 File Offset: 0x001E2150
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

	// Token: 0x040047E3 RID: 18403
	private GameObject NewBlood;

	// Token: 0x040047E4 RID: 18404
	public YanvaniaCameraScript YanvaniaCamera;

	// Token: 0x040047E5 RID: 18405
	public InputManagerScript InputManager;

	// Token: 0x040047E6 RID: 18406
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040047E7 RID: 18407
	public Animation MyAnimation;

	// Token: 0x040047E8 RID: 18408
	public CharacterController MyController;

	// Token: 0x040047E9 RID: 18409
	public GameObject BossHealthBar;

	// Token: 0x040047EA RID: 18410
	public GameObject LevelUpEffect;

	// Token: 0x040047EB RID: 18411
	public GameObject DeathBlood;

	// Token: 0x040047EC RID: 18412
	public GameObject Character;

	// Token: 0x040047ED RID: 18413
	public GameObject BlackBG;

	// Token: 0x040047EE RID: 18414
	public GameObject TextBox;

	// Token: 0x040047EF RID: 18415
	public Renderer MyRenderer;

	// Token: 0x040047F0 RID: 18416
	public Transform TryAgainWindow;

	// Token: 0x040047F1 RID: 18417
	public Transform HealthBar;

	// Token: 0x040047F2 RID: 18418
	public Transform EXPBar;

	// Token: 0x040047F3 RID: 18419
	public Transform Hips;

	// Token: 0x040047F4 RID: 18420
	public Transform TrailStart;

	// Token: 0x040047F5 RID: 18421
	public Transform TrailEnd;

	// Token: 0x040047F6 RID: 18422
	public UITexture Photograph;

	// Token: 0x040047F7 RID: 18423
	public UILabel LevelLabel;

	// Token: 0x040047F8 RID: 18424
	public UISprite Darkness;

	// Token: 0x040047F9 RID: 18425
	public Collider[] SphereCollider;

	// Token: 0x040047FA RID: 18426
	public Collider[] WhipCollider;

	// Token: 0x040047FB RID: 18427
	public Transform[] WhipChain;

	// Token: 0x040047FC RID: 18428
	public AudioClip[] Voices;

	// Token: 0x040047FD RID: 18429
	public AudioClip[] Injuries;

	// Token: 0x040047FE RID: 18430
	public AudioClip DeathSound;

	// Token: 0x040047FF RID: 18431
	public AudioClip LandSound;

	// Token: 0x04004800 RID: 18432
	public AudioClip WhipSound;

	// Token: 0x04004801 RID: 18433
	public bool Attacking;

	// Token: 0x04004802 RID: 18434
	public bool Crouching;

	// Token: 0x04004803 RID: 18435
	public bool Dangling;

	// Token: 0x04004804 RID: 18436
	public bool EnterCutscene;

	// Token: 0x04004805 RID: 18437
	public bool Cutscene;

	// Token: 0x04004806 RID: 18438
	public bool CanMove;

	// Token: 0x04004807 RID: 18439
	public bool Injured;

	// Token: 0x04004808 RID: 18440
	public bool Loose;

	// Token: 0x04004809 RID: 18441
	public bool Red;

	// Token: 0x0400480A RID: 18442
	public bool SpunUp;

	// Token: 0x0400480B RID: 18443
	public bool SpunDown;

	// Token: 0x0400480C RID: 18444
	public bool SpunRight;

	// Token: 0x0400480D RID: 18445
	public bool SpunLeft;

	// Token: 0x0400480E RID: 18446
	public float TargetRotation;

	// Token: 0x0400480F RID: 18447
	public float Rotation;

	// Token: 0x04004810 RID: 18448
	public float RecoveryTimer;

	// Token: 0x04004811 RID: 18449
	public float DeathTimer;

	// Token: 0x04004812 RID: 18450
	public float FlashTimer;

	// Token: 0x04004813 RID: 18451
	public float IdleTimer;

	// Token: 0x04004814 RID: 18452
	public float WhipTimer;

	// Token: 0x04004815 RID: 18453
	public float TapTimer;

	// Token: 0x04004816 RID: 18454
	public float PreviousY;

	// Token: 0x04004817 RID: 18455
	public float MaxHealth = 100f;

	// Token: 0x04004818 RID: 18456
	public float Health = 100f;

	// Token: 0x04004819 RID: 18457
	public float EXP;

	// Token: 0x0400481A RID: 18458
	public int Frames;

	// Token: 0x0400481B RID: 18459
	public int Level;

	// Token: 0x0400481C RID: 18460
	public int Taps;

	// Token: 0x0400481D RID: 18461
	public float walkSpeed = 6f;

	// Token: 0x0400481E RID: 18462
	public float runSpeed = 11f;

	// Token: 0x0400481F RID: 18463
	public bool limitDiagonalSpeed = true;

	// Token: 0x04004820 RID: 18464
	public bool toggleRun;

	// Token: 0x04004821 RID: 18465
	public float jumpSpeed = 8f;

	// Token: 0x04004822 RID: 18466
	public float gravity = 20f;

	// Token: 0x04004823 RID: 18467
	public float fallingDamageThreshold = 10f;

	// Token: 0x04004824 RID: 18468
	public bool slideWhenOverSlopeLimit;

	// Token: 0x04004825 RID: 18469
	public bool slideOnTaggedObjects;

	// Token: 0x04004826 RID: 18470
	public float slideSpeed = 12f;

	// Token: 0x04004827 RID: 18471
	public bool airControl;

	// Token: 0x04004828 RID: 18472
	public float antiBumpFactor = 0.75f;

	// Token: 0x04004829 RID: 18473
	public int antiBunnyHopFactor = 1;

	// Token: 0x0400482A RID: 18474
	private Vector3 moveDirection = Vector3.zero;

	// Token: 0x0400482B RID: 18475
	public bool grounded;

	// Token: 0x0400482C RID: 18476
	private CharacterController controller;

	// Token: 0x0400482D RID: 18477
	private Transform myTransform;

	// Token: 0x0400482E RID: 18478
	private float speed;

	// Token: 0x0400482F RID: 18479
	private RaycastHit hit;

	// Token: 0x04004830 RID: 18480
	private float fallStartLevel;

	// Token: 0x04004831 RID: 18481
	private bool falling;

	// Token: 0x04004832 RID: 18482
	private float slideLimit;

	// Token: 0x04004833 RID: 18483
	private float rayDistance;

	// Token: 0x04004834 RID: 18484
	private Vector3 contactPoint;

	// Token: 0x04004835 RID: 18485
	private bool playerControl;

	// Token: 0x04004836 RID: 18486
	private int jumpTimer;

	// Token: 0x04004837 RID: 18487
	private float originalThreshold;

	// Token: 0x04004838 RID: 18488
	public float inputX;

	// Token: 0x04004839 RID: 18489
	public string DeathAnim = "f02_yanvaniaDeath_00";

	// Token: 0x0400483A RID: 18490
	public string AttackAnim = "f02_yanvaniaAttack_00";

	// Token: 0x0400483B RID: 18491
	public string CrouchAttackAnim = "f02_yanvaniaCrouchAttack_00";

	// Token: 0x0400483C RID: 18492
	public string IdleAnim = "f02_yanvaniaIdle_00";

	// Token: 0x0400483D RID: 18493
	public string DramaticIdleAnim = "f02_yanvaniaDramaticIdle_00";

	// Token: 0x0400483E RID: 18494
	public string JumpAnim = "f02_yanvaniaJump_00";

	// Token: 0x0400483F RID: 18495
	public string FallAnim = "f02_yanvaniaFall_00";

	// Token: 0x04004840 RID: 18496
	public string CrouchAnim = "f02_yanvaniaCrouch_00";

	// Token: 0x04004841 RID: 18497
	public string CrouchPoseAnim = "f02_yanvaniaCrouchPose_00";

	// Token: 0x04004842 RID: 18498
	public string WalkAnim = "f02_yanvaniaWalk_00";

	// Token: 0x04004843 RID: 18499
	public string RunAnim = "f02_yanvaniaRun_00";

	// Token: 0x04004844 RID: 18500
	public string WhipNeutralAnim = "f02_yanvaniaWhip_Neutral";

	// Token: 0x04004845 RID: 18501
	public string WhipUpAnim = "f02_yanvaniaWhip_Up";

	// Token: 0x04004846 RID: 18502
	public string WhipRightAnim = "f02_yanvaniaWhip_Right";

	// Token: 0x04004847 RID: 18503
	public string WhipDownAnim = "f02_yanvaniaWhip_Down";

	// Token: 0x04004848 RID: 18504
	public string WhipLeftAnim = "f02_yanvaniaWhip_Left";
}
