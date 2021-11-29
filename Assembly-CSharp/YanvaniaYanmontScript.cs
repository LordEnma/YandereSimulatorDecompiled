using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004DF RID: 1247
[RequireComponent(typeof(CharacterController))]
public class YanvaniaYanmontScript : MonoBehaviour
{
	// Token: 0x06002083 RID: 8323 RVA: 0x001DC6CC File Offset: 0x001DA8CC
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

	// Token: 0x06002084 RID: 8324 RVA: 0x001DC838 File Offset: 0x001DAA38
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

	// Token: 0x06002085 RID: 8325 RVA: 0x001DC8E4 File Offset: 0x001DAAE4
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

	// Token: 0x06002086 RID: 8326 RVA: 0x001DD6DC File Offset: 0x001DB8DC
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

	// Token: 0x06002087 RID: 8327 RVA: 0x001DE0A1 File Offset: 0x001DC2A1
	private void LateUpdate()
	{
	}

	// Token: 0x06002088 RID: 8328 RVA: 0x001DE0A3 File Offset: 0x001DC2A3
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		this.contactPoint = this.hit.point;
	}

	// Token: 0x06002089 RID: 8329 RVA: 0x001DE0B8 File Offset: 0x001DC2B8
	private void FallingDamageAlert(float fallDistance)
	{
		AudioClipPlayer.Play2D(this.LandSound, base.transform.position, UnityEngine.Random.Range(0.9f, 1.1f));
		this.Character.GetComponent<Animation>().Play(this.CrouchAnim);
		this.fallingDamageThreshold = this.originalThreshold;
	}

	// Token: 0x0600208A RID: 8330 RVA: 0x001DE110 File Offset: 0x001DC310
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

	// Token: 0x0600208B RID: 8331 RVA: 0x001DE188 File Offset: 0x001DC388
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

	// Token: 0x0600208C RID: 8332 RVA: 0x001DE200 File Offset: 0x001DC400
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

	// Token: 0x0600208D RID: 8333 RVA: 0x001DE2B0 File Offset: 0x001DC4B0
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

	// Token: 0x0600208E RID: 8334 RVA: 0x001DE324 File Offset: 0x001DC524
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

	// Token: 0x0600208F RID: 8335 RVA: 0x001DE394 File Offset: 0x001DC594
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

	// Token: 0x04004736 RID: 18230
	private GameObject NewBlood;

	// Token: 0x04004737 RID: 18231
	public YanvaniaCameraScript YanvaniaCamera;

	// Token: 0x04004738 RID: 18232
	public InputManagerScript InputManager;

	// Token: 0x04004739 RID: 18233
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400473A RID: 18234
	public Animation MyAnimation;

	// Token: 0x0400473B RID: 18235
	public CharacterController MyController;

	// Token: 0x0400473C RID: 18236
	public GameObject BossHealthBar;

	// Token: 0x0400473D RID: 18237
	public GameObject LevelUpEffect;

	// Token: 0x0400473E RID: 18238
	public GameObject DeathBlood;

	// Token: 0x0400473F RID: 18239
	public GameObject Character;

	// Token: 0x04004740 RID: 18240
	public GameObject BlackBG;

	// Token: 0x04004741 RID: 18241
	public GameObject TextBox;

	// Token: 0x04004742 RID: 18242
	public Renderer MyRenderer;

	// Token: 0x04004743 RID: 18243
	public Transform TryAgainWindow;

	// Token: 0x04004744 RID: 18244
	public Transform HealthBar;

	// Token: 0x04004745 RID: 18245
	public Transform EXPBar;

	// Token: 0x04004746 RID: 18246
	public Transform Hips;

	// Token: 0x04004747 RID: 18247
	public Transform TrailStart;

	// Token: 0x04004748 RID: 18248
	public Transform TrailEnd;

	// Token: 0x04004749 RID: 18249
	public UITexture Photograph;

	// Token: 0x0400474A RID: 18250
	public UILabel LevelLabel;

	// Token: 0x0400474B RID: 18251
	public UISprite Darkness;

	// Token: 0x0400474C RID: 18252
	public Collider[] SphereCollider;

	// Token: 0x0400474D RID: 18253
	public Collider[] WhipCollider;

	// Token: 0x0400474E RID: 18254
	public Transform[] WhipChain;

	// Token: 0x0400474F RID: 18255
	public AudioClip[] Voices;

	// Token: 0x04004750 RID: 18256
	public AudioClip[] Injuries;

	// Token: 0x04004751 RID: 18257
	public AudioClip DeathSound;

	// Token: 0x04004752 RID: 18258
	public AudioClip LandSound;

	// Token: 0x04004753 RID: 18259
	public AudioClip WhipSound;

	// Token: 0x04004754 RID: 18260
	public bool Attacking;

	// Token: 0x04004755 RID: 18261
	public bool Crouching;

	// Token: 0x04004756 RID: 18262
	public bool Dangling;

	// Token: 0x04004757 RID: 18263
	public bool EnterCutscene;

	// Token: 0x04004758 RID: 18264
	public bool Cutscene;

	// Token: 0x04004759 RID: 18265
	public bool CanMove;

	// Token: 0x0400475A RID: 18266
	public bool Injured;

	// Token: 0x0400475B RID: 18267
	public bool Loose;

	// Token: 0x0400475C RID: 18268
	public bool Red;

	// Token: 0x0400475D RID: 18269
	public bool SpunUp;

	// Token: 0x0400475E RID: 18270
	public bool SpunDown;

	// Token: 0x0400475F RID: 18271
	public bool SpunRight;

	// Token: 0x04004760 RID: 18272
	public bool SpunLeft;

	// Token: 0x04004761 RID: 18273
	public float TargetRotation;

	// Token: 0x04004762 RID: 18274
	public float Rotation;

	// Token: 0x04004763 RID: 18275
	public float RecoveryTimer;

	// Token: 0x04004764 RID: 18276
	public float DeathTimer;

	// Token: 0x04004765 RID: 18277
	public float FlashTimer;

	// Token: 0x04004766 RID: 18278
	public float IdleTimer;

	// Token: 0x04004767 RID: 18279
	public float WhipTimer;

	// Token: 0x04004768 RID: 18280
	public float TapTimer;

	// Token: 0x04004769 RID: 18281
	public float PreviousY;

	// Token: 0x0400476A RID: 18282
	public float MaxHealth = 100f;

	// Token: 0x0400476B RID: 18283
	public float Health = 100f;

	// Token: 0x0400476C RID: 18284
	public float EXP;

	// Token: 0x0400476D RID: 18285
	public int Frames;

	// Token: 0x0400476E RID: 18286
	public int Level;

	// Token: 0x0400476F RID: 18287
	public int Taps;

	// Token: 0x04004770 RID: 18288
	public float walkSpeed = 6f;

	// Token: 0x04004771 RID: 18289
	public float runSpeed = 11f;

	// Token: 0x04004772 RID: 18290
	public bool limitDiagonalSpeed = true;

	// Token: 0x04004773 RID: 18291
	public bool toggleRun;

	// Token: 0x04004774 RID: 18292
	public float jumpSpeed = 8f;

	// Token: 0x04004775 RID: 18293
	public float gravity = 20f;

	// Token: 0x04004776 RID: 18294
	public float fallingDamageThreshold = 10f;

	// Token: 0x04004777 RID: 18295
	public bool slideWhenOverSlopeLimit;

	// Token: 0x04004778 RID: 18296
	public bool slideOnTaggedObjects;

	// Token: 0x04004779 RID: 18297
	public float slideSpeed = 12f;

	// Token: 0x0400477A RID: 18298
	public bool airControl;

	// Token: 0x0400477B RID: 18299
	public float antiBumpFactor = 0.75f;

	// Token: 0x0400477C RID: 18300
	public int antiBunnyHopFactor = 1;

	// Token: 0x0400477D RID: 18301
	private Vector3 moveDirection = Vector3.zero;

	// Token: 0x0400477E RID: 18302
	public bool grounded;

	// Token: 0x0400477F RID: 18303
	private CharacterController controller;

	// Token: 0x04004780 RID: 18304
	private Transform myTransform;

	// Token: 0x04004781 RID: 18305
	private float speed;

	// Token: 0x04004782 RID: 18306
	private RaycastHit hit;

	// Token: 0x04004783 RID: 18307
	private float fallStartLevel;

	// Token: 0x04004784 RID: 18308
	private bool falling;

	// Token: 0x04004785 RID: 18309
	private float slideLimit;

	// Token: 0x04004786 RID: 18310
	private float rayDistance;

	// Token: 0x04004787 RID: 18311
	private Vector3 contactPoint;

	// Token: 0x04004788 RID: 18312
	private bool playerControl;

	// Token: 0x04004789 RID: 18313
	private int jumpTimer;

	// Token: 0x0400478A RID: 18314
	private float originalThreshold;

	// Token: 0x0400478B RID: 18315
	public float inputX;

	// Token: 0x0400478C RID: 18316
	public string DeathAnim = "f02_yanvaniaDeath_00";

	// Token: 0x0400478D RID: 18317
	public string AttackAnim = "f02_yanvaniaAttack_00";

	// Token: 0x0400478E RID: 18318
	public string CrouchAttackAnim = "f02_yanvaniaCrouchAttack_00";

	// Token: 0x0400478F RID: 18319
	public string IdleAnim = "f02_yanvaniaIdle_00";

	// Token: 0x04004790 RID: 18320
	public string DramaticIdleAnim = "f02_yanvaniaDramaticIdle_00";

	// Token: 0x04004791 RID: 18321
	public string JumpAnim = "f02_yanvaniaJump_00";

	// Token: 0x04004792 RID: 18322
	public string FallAnim = "f02_yanvaniaFall_00";

	// Token: 0x04004793 RID: 18323
	public string CrouchAnim = "f02_yanvaniaCrouch_00";

	// Token: 0x04004794 RID: 18324
	public string CrouchPoseAnim = "f02_yanvaniaCrouchPose_00";

	// Token: 0x04004795 RID: 18325
	public string WalkAnim = "f02_yanvaniaWalk_00";

	// Token: 0x04004796 RID: 18326
	public string RunAnim = "f02_yanvaniaRun_00";

	// Token: 0x04004797 RID: 18327
	public string WhipNeutralAnim = "f02_yanvaniaWhip_Neutral";

	// Token: 0x04004798 RID: 18328
	public string WhipUpAnim = "f02_yanvaniaWhip_Up";

	// Token: 0x04004799 RID: 18329
	public string WhipRightAnim = "f02_yanvaniaWhip_Right";

	// Token: 0x0400479A RID: 18330
	public string WhipDownAnim = "f02_yanvaniaWhip_Down";

	// Token: 0x0400479B RID: 18331
	public string WhipLeftAnim = "f02_yanvaniaWhip_Left";
}
