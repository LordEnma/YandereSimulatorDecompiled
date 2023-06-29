using UnityEngine;

public class PromptScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public StudentScript MyStudent;

	public YandereScript Yandere;

	public GameObject[] ButtonObject;

	public GameObject SpeakerObject;

	public GameObject CircleObject;

	public GameObject LabelObject;

	public PromptParentScript PromptParent;

	public Collider MyCollider;

	public Camera MainCamera;

	public Camera UICamera;

	public bool[] AcceptingInput;

	public bool[] ButtonActive;

	public bool[] HideButton;

	public UISprite[] Button;

	public UISprite[] Circle;

	public UILabel[] Label;

	public UISprite Speaker;

	public UISprite Square;

	public float[] OffsetX;

	public float[] OffsetY;

	public float[] OffsetZ;

	public string[] Text;

	public PromptOwnerType OwnerType;

	public bool DisableAtStart;

	public bool Suspicious;

	public bool Debugging;

	public bool SquareSet;

	public bool Carried;

	[Tooltip("This means that the prompt's renderer is within the camera's cone of vision.")]
	public bool InSight;

	[Tooltip("This means that a raycast can hit the prompt's collider.")]
	public bool InView;

	public bool NoCheck;

	public bool Attack;

	public bool Weapon;

	public bool Noisy;

	public bool Local = true;

	public float RelativePosition;

	public float MaximumDistance = 5f;

	public float MinimumDistance;

	public float DistanceSqr;

	public float Height;

	public int ButtonHeld;

	public int BloodMask;

	public int Priority;

	public int ID;

	public GameObject YandereObject;

	public Transform RaycastTarget;

	public float MinimumDistanceSqr;

	public float MaximumDistanceSqr;

	public Vector3 CurrentPosition;

	public float Timer;

	public bool Student;

	public bool Door;

	public bool Hidden;

	private void Awake()
	{
		if (MyStudent == null)
		{
			MinimumDistanceSqr = MinimumDistance * MinimumDistance;
			MaximumDistanceSqr = MaximumDistance * MaximumDistance;
		}
		else
		{
			MinimumDistanceSqr = MinimumDistance;
			MaximumDistanceSqr = MaximumDistance;
		}
		CurrentPosition = base.transform.position;
		DistanceSqr = float.PositiveInfinity;
		OwnerType = DecideOwnerType();
		if (RaycastTarget == null)
		{
			RaycastTarget = base.transform;
		}
		if (OffsetZ.Length == 0)
		{
			OffsetZ = new float[4];
		}
		if (Yandere == null)
		{
			YandereObject = GameObject.Find("YandereChan");
			if (YandereObject != null)
			{
				Yandere = YandereObject.GetComponent<YandereScript>();
			}
		}
		if (Yandere != null)
		{
			PromptParent = Yandere.PromptParent;
			if (PromptParent == null)
			{
				base.enabled = false;
				return;
			}
			PauseScreen = Yandere.PauseScreen;
			UICamera = Yandere.UICamera;
			MainCamera = Yandere.MainCamera;
			if (Noisy)
			{
				Speaker = Object.Instantiate(SpeakerObject, CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
				Speaker.transform.parent = PromptParent.transform;
				Speaker.transform.localScale = new Vector3(1f, 1f, 1f);
				Speaker.transform.localEulerAngles = Vector3.zero;
				Speaker.enabled = false;
			}
			Square = Object.Instantiate(PromptParent.SquareObject, CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
			Square.transform.parent = PromptParent.transform;
			Square.transform.localScale = new Vector3(1f, 1f, 1f);
			Square.transform.localEulerAngles = Vector3.zero;
			Square.applyGradient = true;
			Square.gradientTop = new Color(1f, 1f, 1f, 1f);
			Square.gradientBottom = new Color(1f, 0.75f, 1f, 1f);
			Square.color = new Color(1f, 1f, 1f, 0f);
			Color color = Square.color;
			color.a = 0f;
			Square.color = color;
			Square.enabled = false;
			for (ID = 0; ID < 4; ID++)
			{
				if (ButtonActive[ID])
				{
					Button[ID] = Object.Instantiate(ButtonObject[ID], CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
					UISprite uISprite = Button[ID];
					uISprite.transform.parent = PromptParent.transform;
					uISprite.transform.localScale = new Vector3(1f, 1f, 1f);
					uISprite.transform.localEulerAngles = Vector3.zero;
					uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, 0f);
					uISprite.enabled = false;
					Circle[ID] = Object.Instantiate(CircleObject, CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
					UISprite uISprite2 = Circle[ID];
					uISprite2.transform.parent = Button[ID].transform;
					uISprite2.transform.localScale = new Vector3(1f, 1f, 1f);
					uISprite2.transform.localEulerAngles = Vector3.zero;
					uISprite2.transform.localPosition = Vector3.zero;
					uISprite2.color = new Color(uISprite2.color.r, uISprite2.color.g, uISprite2.color.b, 0f);
					uISprite2.enabled = false;
					Label[ID] = Object.Instantiate(LabelObject, CurrentPosition, Quaternion.identity).GetComponent<UILabel>();
					UILabel uILabel = Label[ID];
					uILabel.transform.parent = Button[ID].transform;
					uILabel.transform.localScale = new Vector3(1f, 1f, 1f);
					uILabel.transform.localEulerAngles = Vector3.zero;
					uILabel.transform.localPosition = Vector3.zero;
					uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0f);
					uILabel.enabled = false;
					if (Suspicious)
					{
						uILabel.color = new Color(1f, 0f, 0f, 0f);
					}
					else
					{
						uILabel.applyGradient = true;
						uILabel.gradientTop = new Color(1f, 1f, 1f, 1f);
						uILabel.gradientBottom = new Color(1f, 0.75f, 1f, 1f);
						uILabel.color = new Color(1f, 1f, 1f, 0f);
					}
					uILabel.text = "     " + Text[ID];
				}
				AcceptingInput[ID] = true;
			}
			if (Student && !Door)
			{
				BloodMask = 4;
				BloodMask |= 512;
				BloodMask |= 8192;
				BloodMask |= 16384;
				BloodMask |= 65536;
				BloodMask |= 2097152;
				BloodMask = ~BloodMask;
			}
			else
			{
				BloodMask = 2;
				BloodMask |= 4;
				BloodMask |= 512;
				BloodMask |= 8192;
				BloodMask |= 16384;
				BloodMask |= 65536;
				BloodMask |= 2097152;
				BloodMask |= 67108864;
				BloodMask = ~BloodMask;
			}
		}
		if (PauseScreen == null)
		{
			Debug.Log("My name is " + base.name + " and I am a prompt that is disabling itself because my PauseScreen reference is null.");
			base.enabled = false;
			Hide();
		}
	}

	private void Start()
	{
		if (DisableAtStart)
		{
			Hide();
			base.enabled = false;
		}
	}

	private PromptOwnerType DecideOwnerType()
	{
		if (GetComponent<DoorScript>() != null)
		{
			return PromptOwnerType.Door;
		}
		return PromptOwnerType.Unknown;
	}

	private bool AllowedWhenCrouching(PromptOwnerType ownerType)
	{
		return ownerType == PromptOwnerType.Door;
	}

	private bool AllowedWhenCrawling(PromptOwnerType ownerType)
	{
		return false;
	}

	private void Update()
	{
		if (!PauseScreen.Show)
		{
			if (InView)
			{
				CurrentPosition = base.transform.position;
				if (MyStudent == null)
				{
					Vector3 vector = new Vector3(CurrentPosition.x, Yandere.transform.position.y, CurrentPosition.z);
					DistanceSqr = (vector - Yandere.transform.position).sqrMagnitude;
				}
				else
				{
					DistanceSqr = MyStudent.DistanceToPlayer;
				}
				if (DistanceSqr < MaximumDistanceSqr)
				{
					NoCheck = true;
					bool flag = Yandere.Stance.Current == StanceType.Crouching;
					bool flag2 = Yandere.Stance.Current == StanceType.Crawling;
					if (Yandere.CanMove && (!flag || AllowedWhenCrouching(OwnerType)) && (!flag2 || AllowedWhenCrawling(OwnerType)) && !Yandere.Aiming && !Yandere.Mopping && !Yandere.NearSenpai)
					{
						InSight = false;
						if (Physics.Linecast(Yandere.Eyes.position + Vector3.down * Height, RaycastTarget.position, out var hitInfo, BloodMask))
						{
							InSight = hitInfo.collider == MyCollider;
						}
						if (Carried || InSight)
						{
							SquareSet = false;
							Hidden = false;
							Vector2 vector2 = Vector2.zero;
							for (ID = 0; ID < 4; ID++)
							{
								if (ButtonActive[ID])
								{
									if (!Button[ID].gameObject.activeInHierarchy)
									{
										Button[ID].gameObject.SetActive(value: true);
									}
									if (Vector3.Angle(Yandere.MainCamera.transform.forward, Yandere.MainCamera.transform.position - CurrentPosition) > 90f)
									{
										if (Local)
										{
											Vector2 vector3 = MainCamera.WorldToScreenPoint(CurrentPosition + base.transform.right * OffsetX[ID] + base.transform.up * OffsetY[ID] + base.transform.forward * OffsetZ[ID]);
											Button[ID].transform.position = UICamera.ScreenToWorldPoint(new Vector3(vector3.x, vector3.y, 1f));
											if (!SquareSet)
											{
												Square.transform.position = Button[ID].transform.position;
												SquareSet = true;
											}
											RelativePosition = vector3.x;
										}
										else
										{
											vector2 = MainCamera.WorldToScreenPoint(CurrentPosition + new Vector3(OffsetX[ID], OffsetY[ID], OffsetZ[ID]));
											Button[ID].transform.position = UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
											if (!SquareSet)
											{
												Square.transform.position = Button[ID].transform.position;
												SquareSet = true;
											}
											RelativePosition = vector2.x;
										}
										if (!HideButton[ID])
										{
											Square.enabled = true;
											Square.color = new Color(Square.color.r, Square.color.g, Square.color.b, 1f);
										}
									}
								}
							}
							if (Noisy)
							{
								Speaker.transform.position = UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y + 40f, 1f));
							}
							if (DistanceSqr < MinimumDistanceSqr)
							{
								if (Yandere.NearestPrompt == null)
								{
									Yandere.NearestPrompt = this;
								}
								else if (Mathf.Abs(RelativePosition - (float)Screen.width * 0.5f) < Mathf.Abs(Yandere.NearestPrompt.RelativePosition - (float)Screen.width * 0.5f))
								{
									Yandere.NearestPrompt = this;
								}
								if (Yandere.NearestPrompt == this)
								{
									Square.enabled = false;
									Square.color = new Color(Square.color.r, Square.color.g, Square.color.b, 0f);
									for (ID = 0; ID < 4; ID++)
									{
										if (ButtonActive[ID])
										{
											if (!Button[ID].enabled)
											{
												Button[ID].enabled = true;
												Circle[ID].enabled = true;
												Label[ID].enabled = true;
											}
											Button[ID].color = new Color(1f, 1f, 1f, 1f);
											Circle[ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
											Color color = Label[ID].color;
											color.a = 1f;
											Label[ID].color = color;
											if (Speaker != null)
											{
												Speaker.enabled = true;
												Color color2 = Speaker.color;
												color2.a = 1f;
												Speaker.color = color2;
											}
										}
									}
									if (Input.GetButton(InputNames.Xbox_A))
									{
										ButtonHeld = 1;
									}
									else if (Input.GetButton(InputNames.Xbox_B))
									{
										ButtonHeld = 2;
									}
									else if (Input.GetButton(InputNames.Xbox_X))
									{
										ButtonHeld = 3;
									}
									else if (Input.GetButton(InputNames.Xbox_Y))
									{
										ButtonHeld = 4;
									}
									else
									{
										ButtonHeld = 0;
									}
									if (ButtonHeld > 0)
									{
										for (ID = 0; ID < 4; ID++)
										{
											if (((ButtonActive[ID] && ID != ButtonHeld - 1) || HideButton[ID]) && Circle[ID] != null)
											{
												Circle[ID].fillAmount = 1f;
											}
										}
										if (ButtonActive[ButtonHeld - 1] && !HideButton[ButtonHeld - 1] && AcceptingInput[ButtonHeld - 1] && !Yandere.Attacking && Yandere.NearestPrompt == this)
										{
											Circle[ButtonHeld - 1].color = new Color(1f, 1f, 1f, 1f);
											if (!Attack)
											{
												Circle[ButtonHeld - 1].fillAmount -= Time.deltaTime * 2f;
											}
											else
											{
												Circle[ButtonHeld - 1].fillAmount = 0f;
											}
											ID = 0;
										}
									}
									else
									{
										for (ID = 0; ID < 4; ID++)
										{
											if (ButtonActive[ID])
											{
												Circle[ID].fillAmount = 1f;
											}
										}
									}
								}
								else
								{
									Square.color = new Color(Square.color.r, Square.color.g, Square.color.b, 1f);
									for (ID = 0; ID < 4; ID++)
									{
										if (ButtonActive[ID])
										{
											UISprite uISprite = Button[ID];
											UISprite uISprite2 = Circle[ID];
											UILabel obj = Label[ID];
											uISprite.enabled = false;
											uISprite2.enabled = false;
											obj.enabled = false;
											Color color3 = uISprite.color;
											Color color4 = uISprite2.color;
											Color color5 = obj.color;
											color3.a = 0f;
											color4.a = 0f;
											color5.a = 0f;
											uISprite.color = color3;
											uISprite2.color = color4;
											obj.color = color5;
										}
									}
									if (Speaker != null)
									{
										Speaker.enabled = false;
										Color color6 = Speaker.color;
										color6.a = 0f;
										Speaker.color = color6;
									}
								}
							}
							else
							{
								if (Yandere.NearestPrompt == this)
								{
									Yandere.NearestPrompt = null;
								}
								Square.color = new Color(Square.color.r, Square.color.g, Square.color.b, 1f);
								for (ID = 0; ID < 4; ID++)
								{
									if (ButtonActive[ID])
									{
										UISprite uISprite3 = Button[ID];
										UISprite obj2 = Circle[ID];
										UILabel uILabel = Label[ID];
										obj2.fillAmount = 1f;
										uISprite3.enabled = false;
										obj2.enabled = false;
										uILabel.enabled = false;
										Color color7 = uISprite3.color;
										Color color8 = obj2.color;
										Color color9 = uILabel.color;
										color7.a = 0f;
										color8.a = 0f;
										color9.a = 0f;
										uISprite3.color = color7;
										obj2.color = color8;
										uILabel.color = color9;
									}
								}
								if (Speaker != null)
								{
									Speaker.enabled = false;
									Color color10 = Speaker.color;
									color10.a = 0f;
									Speaker.color = color10;
								}
							}
							Color color11 = Square.color;
							color11.a = 1f;
							Square.color = color11;
							for (ID = 0; ID < 4; ID++)
							{
								if (ButtonActive[ID] && HideButton[ID])
								{
									UISprite uISprite4 = Button[ID];
									UISprite uISprite5 = Circle[ID];
									UILabel obj3 = Label[ID];
									uISprite4.enabled = false;
									uISprite5.enabled = false;
									obj3.enabled = false;
									Color color12 = uISprite4.color;
									Color color13 = uISprite5.color;
									Color color14 = obj3.color;
									color12.a = 0f;
									color13.a = 0f;
									color14.a = 0f;
									uISprite4.color = color12;
									uISprite5.color = color13;
									obj3.color = color14;
									if (Speaker != null)
									{
										Speaker.enabled = false;
										Color color15 = Speaker.color;
										color15.a = 0f;
										Speaker.color = color15;
									}
								}
							}
						}
						else
						{
							Hide();
						}
					}
					else
					{
						Hide();
					}
				}
				else
				{
					Hide();
				}
			}
			else
			{
				DistanceSqr = float.PositiveInfinity;
				Hide();
			}
		}
		else
		{
			Hide();
		}
	}

	private void OnBecameVisible()
	{
		InView = true;
	}

	private void OnBecameInvisible()
	{
		InView = false;
		Hide();
	}

	public void Hide()
	{
		if (Hidden)
		{
			return;
		}
		NoCheck = false;
		Hidden = true;
		if (!(Yandere != null))
		{
			return;
		}
		if (Yandere.NearestPrompt == this)
		{
			Yandere.NearestPrompt = null;
		}
		if (Square == null)
		{
			return;
		}
		if (Square.enabled)
		{
			Square.enabled = false;
			Square.color = new Color(Square.color.r, Square.color.g, Square.color.b, 0f);
		}
		for (ID = 0; ID < 4; ID++)
		{
			if (ButtonActive[ID])
			{
				UISprite uISprite = Button[ID];
				if (uISprite.enabled)
				{
					UISprite uISprite2 = Circle[ID];
					UILabel uILabel = Label[ID];
					uISprite2.fillAmount = 1f;
					uISprite.enabled = false;
					uISprite2.enabled = false;
					uILabel.enabled = false;
					uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, 0f);
					uISprite2.color = new Color(uISprite2.color.r, uISprite2.color.g, uISprite2.color.b, 0f);
					uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0f);
				}
			}
			if (Button[ID] != null)
			{
				Button[ID].gameObject.SetActive(value: false);
			}
		}
		if (Speaker != null)
		{
			Speaker.enabled = false;
			Speaker.color = new Color(Speaker.color.r, Speaker.color.g, Speaker.color.b, 0f);
		}
	}
}
