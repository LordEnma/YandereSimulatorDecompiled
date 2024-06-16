using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class YanvaniaYanmontScript : MonoBehaviour
{
	private GameObject NewBlood;

	public YanvaniaCameraScript YanvaniaCamera;

	public InputManagerScript InputManager;

	public YanvaniaDraculaScript Dracula;

	public Animation MyAnimation;

	public CharacterController MyController;

	public GameObject BossHealthBar;

	public GameObject LevelUpEffect;

	public GameObject DeathBlood;

	public GameObject Character;

	public GameObject BlackBG;

	public GameObject TextBox;

	public Renderer MyRenderer;

	public Transform TryAgainWindow;

	public Transform HealthBar;

	public Transform EXPBar;

	public Transform Hips;

	public Transform TrailStart;

	public Transform TrailEnd;

	public UITexture Photograph;

	public UILabel LevelLabel;

	public UISprite Darkness;

	public Collider[] SphereCollider;

	public Collider[] WhipCollider;

	public Transform[] WhipChain;

	public AudioClip[] Voices;

	public AudioClip[] Injuries;

	public AudioClip DeathSound;

	public AudioClip LandSound;

	public AudioClip WhipSound;

	public bool Attacking;

	public bool Crouching;

	public bool Dangling;

	public bool EnterCutscene;

	public bool Cutscene;

	public bool CanMove;

	public bool Injured;

	public bool Loose;

	public bool Red;

	public bool SpunUp;

	public bool SpunDown;

	public bool SpunRight;

	public bool SpunLeft;

	public float TargetRotation;

	public float Rotation;

	public float RecoveryTimer;

	public float DeathTimer;

	public float FlashTimer;

	public float IdleTimer;

	public float WhipTimer;

	public float TapTimer;

	public float PreviousY;

	public float MaxHealth = 100f;

	public float Health = 100f;

	public float EXP;

	public int Frames;

	public int Level;

	public int Taps;

	public float walkSpeed = 6f;

	public float runSpeed = 11f;

	public bool limitDiagonalSpeed = true;

	public bool toggleRun;

	public float jumpSpeed = 8f;

	public float gravity = 20f;

	public float fallingDamageThreshold = 10f;

	public bool slideWhenOverSlopeLimit;

	public bool slideOnTaggedObjects;

	public float slideSpeed = 12f;

	public bool airControl;

	public float antiBumpFactor = 0.75f;

	public int antiBunnyHopFactor = 1;

	private Vector3 moveDirection = Vector3.zero;

	public bool grounded;

	private CharacterController controller;

	private Transform myTransform;

	private float speed;

	private RaycastHit hit;

	private float fallStartLevel;

	private bool falling;

	private float slideLimit;

	private float rayDistance;

	private Vector3 contactPoint;

	private bool playerControl;

	private int jumpTimer;

	private float originalThreshold;

	public float inputX;

	public string DeathAnim = "f02_yanvaniaDeath_00";

	public string AttackAnim = "f02_yanvaniaAttack_00";

	public string CrouchAttackAnim = "f02_yanvaniaCrouchAttack_00";

	public string IdleAnim = "f02_yanvaniaIdle_00";

	public string DramaticIdleAnim = "f02_yanvaniaDramaticIdle_00";

	public string JumpAnim = "f02_yanvaniaJump_00";

	public string FallAnim = "f02_yanvaniaFall_00";

	public string CrouchAnim = "f02_yanvaniaCrouch_00";

	public string CrouchPoseAnim = "f02_yanvaniaCrouchPose_00";

	public string WalkAnim = "f02_yanvaniaWalk_00";

	public string RunAnim = "f02_yanvaniaRun_00";

	public string WhipNeutralAnim = "f02_yanvaniaWhip_Neutral";

	public string WhipUpAnim = "f02_yanvaniaWhip_Up";

	public string WhipRightAnim = "f02_yanvaniaWhip_Right";

	public string WhipDownAnim = "f02_yanvaniaWhip_Down";

	public string WhipLeftAnim = "f02_yanvaniaWhip_Left";

	private void Awake()
	{
		MyAnimation = Character.GetComponent<Animation>();
		MyAnimation[DeathAnim].speed = 0.25f;
		MyAnimation[AttackAnim].speed = 2f;
		MyAnimation[CrouchAttackAnim].speed = 2f;
		MyAnimation[WalkAnim].speed = 2.5f;
		MyAnimation[WhipNeutralAnim].speed = 0f;
		MyAnimation[WhipUpAnim].speed = 0f;
		MyAnimation[WhipRightAnim].speed = 0f;
		MyAnimation[WhipDownAnim].speed = 0f;
		MyAnimation[WhipLeftAnim].speed = 0f;
		MyAnimation[CrouchPoseAnim].layer = 1;
		MyAnimation.Play(CrouchPoseAnim);
		MyAnimation[CrouchPoseAnim].weight = 0f;
		Physics.IgnoreLayerCollision(19, 13, ignore: true);
		Physics.IgnoreLayerCollision(19, 19, ignore: true);
	}

	private void Start()
	{
		WhipChain[0].transform.localScale = Vector3.zero;
		MyAnimation.Play(IdleAnim);
		controller = GetComponent<CharacterController>();
		myTransform = base.transform;
		speed = walkSpeed;
		rayDistance = controller.height * 0.5f + controller.radius;
		slideLimit = controller.slopeLimit - 0.1f;
		jumpTimer = antiBunnyHopFactor;
		originalThreshold = fallingDamageThreshold;
	}

	private void FixedUpdate()
	{
		if (CanMove)
		{
			if (!Injured)
			{
				if (!Cutscene)
				{
					if (grounded)
					{
						if (!Attacking)
						{
							if (!Crouching)
							{
								if (Input.GetAxis(InputNames.Yanvania_Horizontal) > 0f)
								{
									inputX = 1f;
								}
								else if (Input.GetAxis(InputNames.Yanvania_Horizontal) < 0f)
								{
									inputX = -1f;
								}
								else
								{
									inputX = 0f;
								}
							}
						}
						else if (grounded)
						{
							fallingDamageThreshold = 100f;
							moveDirection.x = 0f;
							inputX = 0f;
							speed = 0f;
						}
					}
					else if (Input.GetAxis(InputNames.Yanvania_Horizontal) != 0f)
					{
						if (Input.GetAxis(InputNames.Yanvania_Horizontal) > 0f)
						{
							inputX = 1f;
						}
						else if (Input.GetAxis(InputNames.Yanvania_Horizontal) < 0f)
						{
							inputX = -1f;
						}
						else
						{
							inputX = 0f;
						}
					}
					else
					{
						inputX = Mathf.MoveTowards(inputX, 0f, Time.deltaTime * 10f);
					}
					float num = 0f;
					float num2 = ((inputX != 0f && num != 0f && limitDiagonalSpeed) ? 0.70710677f : 1f);
					if (!Attacking)
					{
						if (Input.GetAxis(InputNames.Yanvania_Horizontal) < 0f)
						{
							Character.transform.localEulerAngles = new Vector3(Character.transform.localEulerAngles.x, -90f, Character.transform.localEulerAngles.z);
							Character.transform.localScale = new Vector3(-1f, Character.transform.localScale.y, Character.transform.localScale.z);
						}
						else if (Input.GetAxis(InputNames.Yanvania_Horizontal) > 0f)
						{
							Character.transform.localEulerAngles = new Vector3(Character.transform.localEulerAngles.x, 90f, Character.transform.localEulerAngles.z);
							Character.transform.localScale = new Vector3(1f, Character.transform.localScale.y, Character.transform.localScale.z);
						}
					}
					if (grounded)
					{
						if (!Attacking && !Dangling)
						{
							if (Input.GetAxis(InputNames.Yanvania_Vertical) < -0.5f)
							{
								MyController.center = new Vector3(MyController.center.x, 0.5f, MyController.center.z);
								MyController.height = 1f;
								Crouching = true;
								IdleTimer = 10f;
								inputX = 0f;
							}
							if (Crouching)
							{
								MyAnimation.CrossFade(CrouchAnim, 0.1f);
								if (!Attacking)
								{
									if (!Dangling)
									{
										if (Input.GetAxis(InputNames.Yanvania_Vertical) > -0.5f)
										{
											MyAnimation[CrouchPoseAnim].weight = 0f;
											MyController.center = new Vector3(MyController.center.x, 0.75f, MyController.center.z);
											MyController.height = 1.5f;
											Crouching = false;
										}
									}
									else if (Input.GetAxis(InputNames.Yanvania_Vertical) > -0.5f && Input.GetButton(InputNames.Xbox_X))
									{
										MyAnimation[CrouchPoseAnim].weight = 0f;
										MyController.center = new Vector3(MyController.center.x, 0.75f, MyController.center.z);
										MyController.height = 1.5f;
										Crouching = false;
									}
								}
							}
							else if (inputX == 0f)
							{
								if (IdleTimer > 0f)
								{
									MyAnimation.CrossFade(IdleAnim, 0.1f);
									MyAnimation[IdleAnim].speed = IdleTimer / 10f;
								}
								else
								{
									MyAnimation.CrossFade(DramaticIdleAnim, 1f);
								}
								IdleTimer -= Time.deltaTime;
							}
							else
							{
								IdleTimer = 10f;
								MyAnimation.CrossFade((speed == walkSpeed) ? WalkAnim : RunAnim, 0.1f);
							}
						}
						bool flag = false;
						if (Physics.Raycast(myTransform.position, -Vector3.up, out hit, rayDistance))
						{
							if (Vector3.Angle(hit.normal, Vector3.up) > slideLimit)
							{
								flag = true;
							}
						}
						else
						{
							Physics.Raycast(contactPoint + Vector3.up, -Vector3.up, out hit);
							if (Vector3.Angle(hit.normal, Vector3.up) > slideLimit)
							{
								flag = true;
							}
						}
						if (falling)
						{
							falling = false;
							if (myTransform.position.y < fallStartLevel - fallingDamageThreshold)
							{
								FallingDamageAlert(fallStartLevel - myTransform.position.y);
							}
							fallingDamageThreshold = originalThreshold;
						}
						if (!toggleRun)
						{
							speed = (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);
						}
						if ((flag && slideWhenOverSlopeLimit) || (slideOnTaggedObjects && hit.collider.tag == "Slide"))
						{
							Vector3 normal = hit.normal;
							moveDirection = new Vector3(normal.x, 0f - normal.y, normal.z);
							Vector3.OrthoNormalize(ref normal, ref moveDirection);
							moveDirection *= slideSpeed;
							playerControl = false;
						}
						else
						{
							moveDirection = new Vector3(inputX * num2, 0f - antiBumpFactor, num * num2);
							moveDirection = myTransform.TransformDirection(moveDirection) * speed;
							playerControl = true;
						}
						if (!Input.GetButton(InputNames.Yanvania_Jump))
						{
							jumpTimer++;
						}
						else if (jumpTimer >= antiBunnyHopFactor && !Attacking)
						{
							Crouching = false;
							fallingDamageThreshold = 0f;
							moveDirection.y = jumpSpeed;
							IdleTimer = 10f;
							jumpTimer = 0;
							AudioSource component = GetComponent<AudioSource>();
							component.clip = Voices[Random.Range(0, Voices.Length)];
							component.Play();
						}
					}
					else
					{
						if (!Attacking)
						{
							MyAnimation.CrossFade((base.transform.position.y > PreviousY) ? JumpAnim : FallAnim, 0.4f);
						}
						PreviousY = base.transform.position.y;
						if (!falling)
						{
							falling = true;
							fallStartLevel = myTransform.position.y;
						}
						if (airControl && playerControl)
						{
							moveDirection.x = inputX * speed * num2;
							moveDirection.z = num * speed * num2;
							moveDirection = myTransform.TransformDirection(moveDirection);
						}
					}
				}
				else
				{
					moveDirection.x = 0f;
					if (grounded)
					{
						if (base.transform.position.x > -33.9f)
						{
							Character.transform.localEulerAngles = new Vector3(Character.transform.localEulerAngles.x, -90f, Character.transform.localEulerAngles.z);
							Character.transform.localScale = new Vector3(1f, Character.transform.localScale.y, Character.transform.localScale.z);
							base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34f, Time.deltaTime * walkSpeed), base.transform.position.y, base.transform.position.z);
							MyAnimation.CrossFade(WalkAnim);
						}
						else if (base.transform.position.x < -34.1f)
						{
							Character.transform.localEulerAngles = new Vector3(Character.transform.localEulerAngles.x, 90f, Character.transform.localEulerAngles.z);
							Character.transform.localScale = new Vector3(-1f, Character.transform.localScale.y, Character.transform.localScale.z);
							base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34f, Time.deltaTime * walkSpeed), base.transform.position.y, base.transform.position.z);
							MyAnimation.CrossFade(WalkAnim);
						}
						else
						{
							MyAnimation.CrossFade(DramaticIdleAnim, 1f);
							Character.transform.localEulerAngles = new Vector3(Character.transform.localEulerAngles.x, -90f, Character.transform.localEulerAngles.z);
							Character.transform.localScale = new Vector3(1f, Character.transform.localScale.y, Character.transform.localScale.z);
							WhipChain[0].transform.localScale = Vector3.zero;
							fallingDamageThreshold = 100f;
							TextBox.SetActive(value: true);
							Attacking = false;
							base.enabled = false;
						}
					}
					Physics.SyncTransforms();
				}
			}
			else
			{
				MyAnimation.CrossFade("f02_damage_25");
				RecoveryTimer += Time.deltaTime;
				if (RecoveryTimer > 1f)
				{
					RecoveryTimer = 0f;
					Injured = false;
				}
			}
			moveDirection.y -= gravity * Time.deltaTime;
			grounded = (controller.Move(moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
			if (grounded && EnterCutscene)
			{
				YanvaniaCamera.Cutscene = true;
				Cutscene = true;
			}
			if ((controller.collisionFlags & CollisionFlags.Above) != 0 && moveDirection.y > 0f)
			{
				moveDirection.y = 0f;
			}
		}
		else if (Health == 0f)
		{
			DeathTimer += Time.deltaTime;
			if (DeathTimer > 5f)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a + Time.deltaTime * 0.2f);
				if (Darkness.color.a >= 1f)
				{
					if (Darkness.gameObject.activeInHierarchy)
					{
						HealthBar.parent.gameObject.SetActive(value: false);
						EXPBar.parent.gameObject.SetActive(value: false);
						Darkness.gameObject.SetActive(value: false);
						BossHealthBar.SetActive(value: false);
						BlackBG.SetActive(value: true);
					}
					TryAgainWindow.transform.localScale = Vector3.Lerp(TryAgainWindow.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
		}
		if (base.transform.position.x < -30f && base.transform.position.y < 6.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, 6.5f, 0f);
		}
	}

	private void Update()
	{
		Animation component = Character.GetComponent<Animation>();
		if (!Injured && CanMove && !Cutscene)
		{
			if (grounded)
			{
				if (InputManager.TappedRight || InputManager.TappedLeft)
				{
					TapTimer = 0.25f;
					Taps++;
				}
				if (Taps > 1)
				{
					speed = runSpeed;
				}
			}
			if (inputX == 0f)
			{
				speed = walkSpeed;
			}
			TapTimer -= Time.deltaTime;
			if (TapTimer < 0f)
			{
				Taps = 0;
			}
			if (Input.GetButtonDown(InputNames.Yanvania_Attack) && !Attacking)
			{
				AudioSource.PlayClipAtPoint(WhipSound, base.transform.position);
				AudioSource component2 = GetComponent<AudioSource>();
				component2.clip = Voices[Random.Range(0, Voices.Length)];
				component2.Play();
				WhipChain[0].transform.localScale = Vector3.zero;
				Attacking = true;
				IdleTimer = 10f;
				if (Crouching)
				{
					component[CrouchAttackAnim].time = 0f;
					component.Play(CrouchAttackAnim);
				}
				else
				{
					component[AttackAnim].time = 0f;
					component.Play(AttackAnim);
				}
				if (grounded)
				{
					moveDirection.x = 0f;
					inputX = 0f;
					speed = 0f;
				}
			}
			if (Attacking)
			{
				if (!Dangling)
				{
					WhipChain[0].transform.localScale = Vector3.MoveTowards(WhipChain[0].transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f);
					StraightenWhip();
				}
				else
				{
					LoosenWhip();
					if (Input.GetAxis(InputNames.Yanvania_Horizontal) > -0.5f && Input.GetAxis(InputNames.Yanvania_Horizontal) < 0.5f && Input.GetAxis(InputNames.Yanvania_Vertical) > -0.5f && Input.GetAxis(InputNames.Yanvania_Vertical) < 0.5f)
					{
						component.CrossFade(WhipNeutralAnim);
						if (Crouching)
						{
							component[CrouchPoseAnim].weight = 1f;
						}
						SpunUp = false;
						SpunDown = false;
						SpunRight = false;
						SpunLeft = false;
					}
					else
					{
						if (Input.GetAxis(InputNames.Yanvania_Vertical) > 0.5f)
						{
							if (!SpunUp)
							{
								AudioClipPlayer.Play2D(WhipSound, base.transform.position, Random.Range(0.9f, 1.1f));
								StraightenWhip();
								TargetRotation = -360f;
								Rotation = 0f;
								SpunUp = true;
							}
							component.CrossFade(WhipUpAnim, 0.1f);
						}
						else
						{
							SpunUp = false;
						}
						if (Input.GetAxis(InputNames.Yanvania_Vertical) < -0.5f)
						{
							if (!SpunDown)
							{
								AudioClipPlayer.Play2D(WhipSound, base.transform.position, Random.Range(0.9f, 1.1f));
								StraightenWhip();
								TargetRotation = 360f;
								Rotation = 0f;
								SpunDown = true;
							}
							component.CrossFade(WhipDownAnim, 0.1f);
						}
						else
						{
							SpunDown = false;
						}
						if (Input.GetAxis(InputNames.Yanvania_Horizontal) > 0.5f)
						{
							if (Character.transform.localScale.x == 1f)
							{
								SpinLeft();
							}
							else
							{
								SpinRight();
							}
						}
						else if (Character.transform.localScale.x == 1f)
						{
							SpunLeft = false;
						}
						else
						{
							SpunRight = false;
						}
						if (Input.GetAxis(InputNames.Yanvania_Horizontal) < -0.5f)
						{
							if (Character.transform.localScale.x == 1f)
							{
								SpinRight();
							}
							else
							{
								SpinLeft();
							}
						}
						else if (Character.transform.localScale.x == 1f)
						{
							SpunRight = false;
						}
						else
						{
							SpunLeft = false;
						}
					}
					Rotation = Mathf.MoveTowards(Rotation, TargetRotation, Time.deltaTime * 3600f * 0.5f);
					WhipChain[1].transform.localEulerAngles = new Vector3(0f, 0f, Rotation);
					if (!Input.GetButton(InputNames.Yanvania_Attack))
					{
						StopAttacking();
					}
				}
			}
			else
			{
				if (WhipCollider[1].enabled)
				{
					for (int i = 1; i < WhipChain.Length; i++)
					{
						SphereCollider[i].enabled = false;
						WhipCollider[i].enabled = false;
					}
				}
				WhipChain[0].transform.localScale = Vector3.MoveTowards(WhipChain[0].transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			if ((!Crouching && component[AttackAnim].time >= component[AttackAnim].length) || (Crouching && component[CrouchAttackAnim].time >= component[CrouchAttackAnim].length))
			{
				if (Input.GetButton(InputNames.Yanvania_Attack))
				{
					if (Crouching)
					{
						component[CrouchPoseAnim].weight = 1f;
					}
					Dangling = true;
				}
				else
				{
					StopAttacking();
				}
			}
		}
		if (FlashTimer > 0f)
		{
			FlashTimer -= Time.deltaTime;
			if (!Red)
			{
				Material[] materials = MyRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].color = new Color(1f, 0f, 0f, 1f);
				}
				Frames++;
				if (Frames == 5)
				{
					Frames = 0;
					Red = true;
				}
			}
			else
			{
				Material[] materials = MyRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].color = new Color(1f, 1f, 1f, 1f);
				}
				Frames++;
				if (Frames == 5)
				{
					Frames = 0;
					Red = false;
				}
			}
		}
		else
		{
			FlashTimer = 0f;
			if (MyRenderer.materials[0].color != new Color(1f, 1f, 1f, 1f))
			{
				Material[] materials = MyRenderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].color = new Color(1f, 1f, 1f, 1f);
				}
			}
		}
		HealthBar.localScale = new Vector3(HealthBar.localScale.x, Mathf.Lerp(HealthBar.localScale.y, Health / MaxHealth, Time.deltaTime * 10f), HealthBar.localScale.z);
		if (Health > 0f)
		{
			if (EXP >= 100f)
			{
				Level++;
				if (Level >= 99)
				{
					Level = 99;
				}
				else
				{
					Object.Instantiate(LevelUpEffect, LevelLabel.transform.position, Quaternion.identity).transform.parent = LevelLabel.transform;
					MaxHealth += 20f;
					Health = MaxHealth;
					EXP -= 100f;
				}
				LevelLabel.text = Level.ToString();
			}
			EXPBar.localScale = new Vector3(EXPBar.localScale.x, Mathf.Lerp(EXPBar.localScale.y, EXP / 100f, Time.deltaTime * 10f), EXPBar.localScale.z);
		}
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 0f);
	}

	private void LateUpdate()
	{
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		contactPoint = this.hit.point;
	}

	private void FallingDamageAlert(float fallDistance)
	{
		AudioClipPlayer.Play2D(LandSound, base.transform.position, Random.Range(0.9f, 1.1f));
		Character.GetComponent<Animation>().Play(CrouchAnim);
		fallingDamageThreshold = originalThreshold;
	}

	private void SpinRight()
	{
		if (!SpunRight)
		{
			AudioClipPlayer.Play2D(WhipSound, base.transform.position, Random.Range(0.9f, 1.1f));
			StraightenWhip();
			TargetRotation = 360f;
			Rotation = 0f;
			SpunRight = true;
		}
		Character.GetComponent<Animation>().CrossFade(WhipRightAnim, 0.1f);
	}

	private void SpinLeft()
	{
		if (!SpunLeft)
		{
			AudioClipPlayer.Play2D(WhipSound, base.transform.position, Random.Range(0.9f, 1.1f));
			StraightenWhip();
			TargetRotation = -360f;
			Rotation = 0f;
			SpunLeft = true;
		}
		Character.GetComponent<Animation>().CrossFade(WhipLeftAnim, 0.1f);
	}

	private void StraightenWhip()
	{
		for (int i = 1; i < WhipChain.Length; i++)
		{
			WhipCollider[i].enabled = true;
			WhipChain[i].gameObject.GetComponent<Rigidbody>().isKinematic = true;
			Transform obj = WhipChain[i].transform;
			obj.localPosition = new Vector3(0f, -0.03f, 0f);
			obj.localEulerAngles = Vector3.zero;
		}
		WhipChain[1].transform.localPosition = new Vector3(0f, -0.1f, 0f);
		WhipTimer = 0f;
		Loose = false;
	}

	private void LoosenWhip()
	{
		if (Loose)
		{
			return;
		}
		WhipTimer += Time.deltaTime;
		if (WhipTimer > 0.25f)
		{
			for (int i = 1; i < WhipChain.Length; i++)
			{
				WhipChain[i].gameObject.GetComponent<Rigidbody>().isKinematic = false;
				SphereCollider[i].enabled = true;
			}
			Loose = true;
		}
	}

	private void StopAttacking()
	{
		Character.GetComponent<Animation>()[CrouchPoseAnim].weight = 0f;
		TargetRotation = 0f;
		Rotation = 0f;
		Attacking = false;
		Dangling = false;
		SpunUp = false;
		SpunDown = false;
		SpunRight = false;
		SpunLeft = false;
	}

	public void TakeDamage(int Damage)
	{
		if (WhipCollider[1].enabled)
		{
			for (int i = 1; i < WhipChain.Length; i++)
			{
				SphereCollider[i].enabled = false;
				WhipCollider[i].enabled = false;
			}
		}
		AudioSource component = GetComponent<AudioSource>();
		component.clip = Injuries[Random.Range(0, Injuries.Length)];
		component.Play();
		WhipChain[0].transform.localScale = Vector3.zero;
		Animation component2 = Character.GetComponent<Animation>();
		component2["f02_damage_25"].time = 0f;
		fallingDamageThreshold = 100f;
		moveDirection.x = 0f;
		RecoveryTimer = 0f;
		FlashTimer = 2f;
		Injured = true;
		StopAttacking();
		Health -= Damage;
		if (Dracula.Health <= 0f)
		{
			Health = 1f;
		}
		if (Dracula.Health > 0f && Health <= 0f)
		{
			if (NewBlood == null)
			{
				MyController.enabled = false;
				YanvaniaCamera.StopMusic = true;
				component.clip = DeathSound;
				component.Play();
				NewBlood = Object.Instantiate(DeathBlood, base.transform.position, Quaternion.identity);
				NewBlood.transform.parent = Hips;
				NewBlood.transform.localPosition = Vector3.zero;
				component2.CrossFade(DeathAnim);
				CanMove = false;
			}
			Health = 0f;
		}
	}
}
