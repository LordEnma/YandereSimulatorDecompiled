using System;
using UnityEngine;

// Token: 0x020003C0 RID: 960
public class PromptScript : MonoBehaviour
{
	// Token: 0x06001B04 RID: 6916 RVA: 0x0012C260 File Offset: 0x0012A460
	private void Awake()
	{
		if (this.MyStudent == null)
		{
			this.MinimumDistanceSqr = this.MinimumDistance * this.MinimumDistance;
			this.MaximumDistanceSqr = this.MaximumDistance * this.MaximumDistance;
		}
		else
		{
			this.MinimumDistanceSqr = this.MinimumDistance;
			this.MaximumDistanceSqr = this.MaximumDistance;
		}
		this.CurrentPosition = base.transform.position;
		this.DistanceSqr = float.PositiveInfinity;
		this.OwnerType = this.DecideOwnerType();
		if (this.RaycastTarget == null)
		{
			this.RaycastTarget = base.transform;
		}
		if (this.OffsetZ.Length == 0)
		{
			this.OffsetZ = new float[4];
		}
		if (this.Yandere == null)
		{
			this.YandereObject = GameObject.Find("YandereChan");
			if (this.YandereObject != null)
			{
				this.Yandere = this.YandereObject.GetComponent<YandereScript>();
			}
		}
		if (this.Yandere != null)
		{
			this.PromptParent = this.Yandere.PromptParent;
			if (this.PromptParent == null)
			{
				base.enabled = false;
				return;
			}
			this.PauseScreen = this.Yandere.PauseScreen;
			this.UICamera = this.Yandere.UICamera;
			this.MainCamera = this.Yandere.MainCamera;
			if (this.Noisy)
			{
				this.Speaker = UnityEngine.Object.Instantiate<GameObject>(this.SpeakerObject, this.CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
				this.Speaker.transform.parent = this.PromptParent.transform;
				this.Speaker.transform.localScale = new Vector3(1f, 1f, 1f);
				this.Speaker.transform.localEulerAngles = Vector3.zero;
				this.Speaker.enabled = false;
			}
			this.Square = UnityEngine.Object.Instantiate<GameObject>(this.PromptParent.SquareObject, this.CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
			this.Square.transform.parent = this.PromptParent.transform;
			this.Square.transform.localScale = new Vector3(1f, 1f, 1f);
			this.Square.transform.localEulerAngles = Vector3.zero;
			this.Square.applyGradient = true;
			this.Square.gradientTop = new Color(1f, 1f, 1f, 1f);
			this.Square.gradientBottom = new Color(1f, 0.75f, 1f, 1f);
			this.Square.color = new Color(1f, 1f, 1f, 0f);
			Color color = this.Square.color;
			color.a = 0f;
			this.Square.color = color;
			this.Square.enabled = false;
			this.ID = 0;
			while (this.ID < 4)
			{
				if (this.ButtonActive[this.ID])
				{
					this.Button[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.ButtonObject[this.ID], this.CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
					UISprite uisprite = this.Button[this.ID];
					uisprite.transform.parent = this.PromptParent.transform;
					uisprite.transform.localScale = new Vector3(1f, 1f, 1f);
					uisprite.transform.localEulerAngles = Vector3.zero;
					uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
					uisprite.enabled = false;
					this.Circle[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.CircleObject, this.CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
					UISprite uisprite2 = this.Circle[this.ID];
					uisprite2.transform.parent = this.Button[this.ID].transform;
					uisprite2.transform.localScale = new Vector3(1f, 1f, 1f);
					uisprite2.transform.localEulerAngles = Vector3.zero;
					uisprite2.transform.localPosition = Vector3.zero;
					uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0f);
					uisprite2.enabled = false;
					this.Label[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.LabelObject, this.CurrentPosition, Quaternion.identity).GetComponent<UILabel>();
					UILabel uilabel = this.Label[this.ID];
					uilabel.transform.parent = this.Button[this.ID].transform;
					uilabel.transform.localScale = new Vector3(1f, 1f, 1f);
					uilabel.transform.localEulerAngles = Vector3.zero;
					uilabel.transform.localPosition = Vector3.zero;
					uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
					uilabel.enabled = false;
					if (this.Suspicious)
					{
						uilabel.color = new Color(1f, 0f, 0f, 0f);
					}
					else
					{
						uilabel.applyGradient = true;
						uilabel.gradientTop = new Color(1f, 1f, 1f, 1f);
						uilabel.gradientBottom = new Color(1f, 0.75f, 1f, 1f);
						uilabel.color = new Color(1f, 1f, 1f, 0f);
					}
					uilabel.text = "     " + this.Text[this.ID];
				}
				this.AcceptingInput[this.ID] = true;
				this.ID++;
			}
			if (this.Student && !this.Door)
			{
				this.BloodMask = 4;
				this.BloodMask |= 512;
				this.BloodMask |= 8192;
				this.BloodMask |= 16384;
				this.BloodMask |= 65536;
				this.BloodMask |= 2097152;
				this.BloodMask = ~this.BloodMask;
				return;
			}
			this.BloodMask = 2;
			this.BloodMask |= 4;
			this.BloodMask |= 512;
			this.BloodMask |= 8192;
			this.BloodMask |= 16384;
			this.BloodMask |= 65536;
			this.BloodMask |= 2097152;
			this.BloodMask = ~this.BloodMask;
		}
	}

	// Token: 0x06001B05 RID: 6917 RVA: 0x0012C9A1 File Offset: 0x0012ABA1
	private void Start()
	{
		if (this.DisableAtStart)
		{
			this.Hide();
			base.enabled = false;
		}
	}

	// Token: 0x06001B06 RID: 6918 RVA: 0x0012C9B8 File Offset: 0x0012ABB8
	private PromptOwnerType DecideOwnerType()
	{
		if (base.GetComponent<DoorScript>() != null)
		{
			return PromptOwnerType.Door;
		}
		return PromptOwnerType.Unknown;
	}

	// Token: 0x06001B07 RID: 6919 RVA: 0x0012C9CB File Offset: 0x0012ABCB
	private bool AllowedWhenCrouching(PromptOwnerType ownerType)
	{
		return ownerType == PromptOwnerType.Door;
	}

	// Token: 0x06001B08 RID: 6920 RVA: 0x0012C9D1 File Offset: 0x0012ABD1
	private bool AllowedWhenCrawling(PromptOwnerType ownerType)
	{
		return false;
	}

	// Token: 0x06001B09 RID: 6921 RVA: 0x0012C9D4 File Offset: 0x0012ABD4
	private void Update()
	{
		if (this.PauseScreen == null)
		{
			Debug.Log("My name is " + base.name + " and I am a prompt that is disabling itself because my PauseScreen reference is null.");
			base.enabled = false;
			this.Hide();
			return;
		}
		if (this.PauseScreen.Show)
		{
			this.Hide();
			return;
		}
		if (!this.InView)
		{
			this.DistanceSqr = float.PositiveInfinity;
			this.Hide();
			return;
		}
		this.CurrentPosition = base.transform.position;
		if (this.MyStudent == null)
		{
			Vector3 a = new Vector3(this.CurrentPosition.x, this.Yandere.transform.position.y, this.CurrentPosition.z);
			this.DistanceSqr = (a - this.Yandere.transform.position).sqrMagnitude;
		}
		else
		{
			this.DistanceSqr = this.MyStudent.DistanceToPlayer;
		}
		if (this.DistanceSqr >= this.MaximumDistanceSqr)
		{
			this.Hide();
			return;
		}
		this.NoCheck = true;
		bool flag = this.Yandere.Stance.Current == StanceType.Crouching;
		bool flag2 = this.Yandere.Stance.Current == StanceType.Crawling;
		if (!this.Yandere.CanMove || (flag && !this.AllowedWhenCrouching(this.OwnerType)) || (flag2 && !this.AllowedWhenCrawling(this.OwnerType)) || this.Yandere.Aiming || this.Yandere.Mopping || this.Yandere.NearSenpai)
		{
			this.Hide();
			return;
		}
		this.InSight = false;
		RaycastHit raycastHit;
		if (Physics.Linecast(this.Yandere.Eyes.position + Vector3.down * this.Height, this.RaycastTarget.position, out raycastHit, this.BloodMask))
		{
			this.InSight = (raycastHit.collider == this.MyCollider);
		}
		if (this.Carried || this.InSight)
		{
			this.SquareSet = false;
			this.Hidden = false;
			Vector2 vector = Vector2.zero;
			this.ID = 0;
			while (this.ID < 4)
			{
				if (this.ButtonActive[this.ID])
				{
					if (!this.Button[this.ID].gameObject.activeInHierarchy)
					{
						this.Button[this.ID].gameObject.SetActive(true);
					}
					if (Vector3.Angle(this.Yandere.MainCamera.transform.forward, this.Yandere.MainCamera.transform.position - this.CurrentPosition) > 90f)
					{
						if (this.Local)
						{
							Vector2 vector2 = this.MainCamera.WorldToScreenPoint(this.CurrentPosition + base.transform.right * this.OffsetX[this.ID] + base.transform.up * this.OffsetY[this.ID] + base.transform.forward * this.OffsetZ[this.ID]);
							this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
							if (!this.SquareSet)
							{
								this.Square.transform.position = this.Button[this.ID].transform.position;
								this.SquareSet = true;
							}
							this.RelativePosition = vector2.x;
						}
						else
						{
							vector = this.MainCamera.WorldToScreenPoint(this.CurrentPosition + new Vector3(this.OffsetX[this.ID], this.OffsetY[this.ID], this.OffsetZ[this.ID]));
							this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 1f));
							if (!this.SquareSet)
							{
								this.Square.transform.position = this.Button[this.ID].transform.position;
								this.SquareSet = true;
							}
							this.RelativePosition = vector.x;
						}
						if (!this.HideButton[this.ID])
						{
							this.Square.enabled = true;
							this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
						}
					}
				}
				this.ID++;
			}
			if (this.Noisy)
			{
				this.Speaker.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y + 40f, 1f));
			}
			if (this.DistanceSqr < this.MinimumDistanceSqr)
			{
				if (this.Yandere.NearestPrompt == null)
				{
					this.Yandere.NearestPrompt = this;
				}
				else if (Mathf.Abs(this.RelativePosition - (float)Screen.width * 0.5f) < Mathf.Abs(this.Yandere.NearestPrompt.RelativePosition - (float)Screen.width * 0.5f))
				{
					this.Yandere.NearestPrompt = this;
				}
				if (this.Yandere.NearestPrompt == this)
				{
					this.Square.enabled = false;
					this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 0f);
					this.ID = 0;
					while (this.ID < 4)
					{
						if (this.ButtonActive[this.ID])
						{
							if (!this.Button[this.ID].enabled)
							{
								this.Button[this.ID].enabled = true;
								this.Circle[this.ID].enabled = true;
								this.Label[this.ID].enabled = true;
							}
							this.Button[this.ID].color = new Color(1f, 1f, 1f, 1f);
							this.Circle[this.ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
							Color color = this.Label[this.ID].color;
							color.a = 1f;
							this.Label[this.ID].color = color;
							if (this.Speaker != null)
							{
								this.Speaker.enabled = true;
								Color color2 = this.Speaker.color;
								color2.a = 1f;
								this.Speaker.color = color2;
							}
						}
						this.ID++;
					}
					if (Input.GetButton("A"))
					{
						this.ButtonHeld = 1;
					}
					else if (Input.GetButton("B"))
					{
						this.ButtonHeld = 2;
					}
					else if (Input.GetButton("X"))
					{
						this.ButtonHeld = 3;
					}
					else if (Input.GetButton("Y"))
					{
						this.ButtonHeld = 4;
					}
					else
					{
						this.ButtonHeld = 0;
					}
					if (this.ButtonHeld > 0)
					{
						this.ID = 0;
						while (this.ID < 4)
						{
							if (((this.ButtonActive[this.ID] && this.ID != this.ButtonHeld - 1) || this.HideButton[this.ID]) && this.Circle[this.ID] != null)
							{
								this.Circle[this.ID].fillAmount = 1f;
							}
							this.ID++;
						}
						if (this.ButtonActive[this.ButtonHeld - 1] && !this.HideButton[this.ButtonHeld - 1] && this.AcceptingInput[this.ButtonHeld - 1] && !this.Yandere.Attacking)
						{
							this.Circle[this.ButtonHeld - 1].color = new Color(1f, 1f, 1f, 1f);
							if (!this.Attack)
							{
								this.Circle[this.ButtonHeld - 1].fillAmount -= Time.deltaTime * 2f;
							}
							else
							{
								this.Circle[this.ButtonHeld - 1].fillAmount = 0f;
							}
							this.ID = 0;
						}
					}
					else
					{
						this.ID = 0;
						while (this.ID < 4)
						{
							if (this.ButtonActive[this.ID])
							{
								this.Circle[this.ID].fillAmount = 1f;
							}
							this.ID++;
						}
					}
				}
				else
				{
					this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
					this.ID = 0;
					while (this.ID < 4)
					{
						if (this.ButtonActive[this.ID])
						{
							UISprite uisprite = this.Button[this.ID];
							UISprite uisprite2 = this.Circle[this.ID];
							UILabel uilabel = this.Label[this.ID];
							uisprite.enabled = false;
							uisprite2.enabled = false;
							uilabel.enabled = false;
							Color color3 = uisprite.color;
							Color color4 = uisprite2.color;
							Color color5 = uilabel.color;
							color3.a = 0f;
							color4.a = 0f;
							color5.a = 0f;
							uisprite.color = color3;
							uisprite2.color = color4;
							uilabel.color = color5;
						}
						this.ID++;
					}
					if (this.Speaker != null)
					{
						this.Speaker.enabled = false;
						Color color6 = this.Speaker.color;
						color6.a = 0f;
						this.Speaker.color = color6;
					}
				}
			}
			else
			{
				if (this.Yandere.NearestPrompt == this)
				{
					this.Yandere.NearestPrompt = null;
				}
				this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
				this.ID = 0;
				while (this.ID < 4)
				{
					if (this.ButtonActive[this.ID])
					{
						UISprite uisprite3 = this.Button[this.ID];
						UISprite uisprite4 = this.Circle[this.ID];
						UILabel uilabel2 = this.Label[this.ID];
						uisprite4.fillAmount = 1f;
						uisprite3.enabled = false;
						uisprite4.enabled = false;
						uilabel2.enabled = false;
						Color color7 = uisprite3.color;
						Color color8 = uisprite4.color;
						Color color9 = uilabel2.color;
						color7.a = 0f;
						color8.a = 0f;
						color9.a = 0f;
						uisprite3.color = color7;
						uisprite4.color = color8;
						uilabel2.color = color9;
					}
					this.ID++;
				}
				if (this.Speaker != null)
				{
					this.Speaker.enabled = false;
					Color color10 = this.Speaker.color;
					color10.a = 0f;
					this.Speaker.color = color10;
				}
			}
			Color color11 = this.Square.color;
			color11.a = 1f;
			this.Square.color = color11;
			this.ID = 0;
			while (this.ID < 4)
			{
				if (this.ButtonActive[this.ID] && this.HideButton[this.ID])
				{
					UISprite uisprite5 = this.Button[this.ID];
					UISprite uisprite6 = this.Circle[this.ID];
					UILabel uilabel3 = this.Label[this.ID];
					uisprite5.enabled = false;
					uisprite6.enabled = false;
					uilabel3.enabled = false;
					Color color12 = uisprite5.color;
					Color color13 = uisprite6.color;
					Color color14 = uilabel3.color;
					color12.a = 0f;
					color13.a = 0f;
					color14.a = 0f;
					uisprite5.color = color12;
					uisprite6.color = color13;
					uilabel3.color = color14;
					if (this.Speaker != null)
					{
						this.Speaker.enabled = false;
						Color color15 = this.Speaker.color;
						color15.a = 0f;
						this.Speaker.color = color15;
					}
				}
				this.ID++;
			}
			return;
		}
		this.Hide();
	}

	// Token: 0x06001B0A RID: 6922 RVA: 0x0012D786 File Offset: 0x0012B986
	private void OnBecameVisible()
	{
		this.InView = true;
	}

	// Token: 0x06001B0B RID: 6923 RVA: 0x0012D78F File Offset: 0x0012B98F
	private void OnBecameInvisible()
	{
		this.InView = false;
		this.Hide();
	}

	// Token: 0x06001B0C RID: 6924 RVA: 0x0012D7A0 File Offset: 0x0012B9A0
	public void Hide()
	{
		if (!this.Hidden)
		{
			this.NoCheck = false;
			this.Hidden = true;
			if (this.Yandere != null)
			{
				if (this.Yandere.NearestPrompt == this)
				{
					this.Yandere.NearestPrompt = null;
				}
				if (this.Square == null)
				{
					Debug.Log("An object named " + base.gameObject.name + " doesn't have a ''Square'' Sprite. The object's root is " + base.transform.root.gameObject.name);
					return;
				}
				if (this.Square.enabled)
				{
					this.Square.enabled = false;
					this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 0f);
				}
				this.ID = 0;
				while (this.ID < 4)
				{
					if (this.ButtonActive[this.ID])
					{
						UISprite uisprite = this.Button[this.ID];
						if (uisprite.enabled)
						{
							UISprite uisprite2 = this.Circle[this.ID];
							UILabel uilabel = this.Label[this.ID];
							uisprite2.fillAmount = 1f;
							uisprite.enabled = false;
							uisprite2.enabled = false;
							uilabel.enabled = false;
							uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0f);
							uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0f);
							uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
						}
					}
					if (this.Button[this.ID] != null)
					{
						this.Button[this.ID].gameObject.SetActive(false);
					}
					this.ID++;
				}
				if (this.Speaker != null)
				{
					this.Speaker.enabled = false;
					this.Speaker.color = new Color(this.Speaker.color.r, this.Speaker.color.g, this.Speaker.color.b, 0f);
				}
			}
		}
	}

	// Token: 0x04002DBE RID: 11710
	public PauseScreenScript PauseScreen;

	// Token: 0x04002DBF RID: 11711
	public StudentScript MyStudent;

	// Token: 0x04002DC0 RID: 11712
	public YandereScript Yandere;

	// Token: 0x04002DC1 RID: 11713
	public GameObject[] ButtonObject;

	// Token: 0x04002DC2 RID: 11714
	public GameObject SpeakerObject;

	// Token: 0x04002DC3 RID: 11715
	public GameObject CircleObject;

	// Token: 0x04002DC4 RID: 11716
	public GameObject LabelObject;

	// Token: 0x04002DC5 RID: 11717
	public PromptParentScript PromptParent;

	// Token: 0x04002DC6 RID: 11718
	public Collider MyCollider;

	// Token: 0x04002DC7 RID: 11719
	public Camera MainCamera;

	// Token: 0x04002DC8 RID: 11720
	public Camera UICamera;

	// Token: 0x04002DC9 RID: 11721
	public bool[] AcceptingInput;

	// Token: 0x04002DCA RID: 11722
	public bool[] ButtonActive;

	// Token: 0x04002DCB RID: 11723
	public bool[] HideButton;

	// Token: 0x04002DCC RID: 11724
	public UISprite[] Button;

	// Token: 0x04002DCD RID: 11725
	public UISprite[] Circle;

	// Token: 0x04002DCE RID: 11726
	public UILabel[] Label;

	// Token: 0x04002DCF RID: 11727
	public UISprite Speaker;

	// Token: 0x04002DD0 RID: 11728
	public UISprite Square;

	// Token: 0x04002DD1 RID: 11729
	public float[] OffsetX;

	// Token: 0x04002DD2 RID: 11730
	public float[] OffsetY;

	// Token: 0x04002DD3 RID: 11731
	public float[] OffsetZ;

	// Token: 0x04002DD4 RID: 11732
	public string[] Text;

	// Token: 0x04002DD5 RID: 11733
	public PromptOwnerType OwnerType;

	// Token: 0x04002DD6 RID: 11734
	public bool DisableAtStart;

	// Token: 0x04002DD7 RID: 11735
	public bool Suspicious;

	// Token: 0x04002DD8 RID: 11736
	public bool Debugging;

	// Token: 0x04002DD9 RID: 11737
	public bool SquareSet;

	// Token: 0x04002DDA RID: 11738
	public bool Carried;

	// Token: 0x04002DDB RID: 11739
	[Tooltip("This means that the prompt's renderer is within the camera's cone of vision.")]
	public bool InSight;

	// Token: 0x04002DDC RID: 11740
	[Tooltip("This means that a raycast can hit the prompt's collider.")]
	public bool InView;

	// Token: 0x04002DDD RID: 11741
	public bool NoCheck;

	// Token: 0x04002DDE RID: 11742
	public bool Attack;

	// Token: 0x04002DDF RID: 11743
	public bool Weapon;

	// Token: 0x04002DE0 RID: 11744
	public bool Noisy;

	// Token: 0x04002DE1 RID: 11745
	public bool Local = true;

	// Token: 0x04002DE2 RID: 11746
	public float RelativePosition;

	// Token: 0x04002DE3 RID: 11747
	public float MaximumDistance = 5f;

	// Token: 0x04002DE4 RID: 11748
	public float MinimumDistance;

	// Token: 0x04002DE5 RID: 11749
	public float DistanceSqr;

	// Token: 0x04002DE6 RID: 11750
	public float Height;

	// Token: 0x04002DE7 RID: 11751
	public int ButtonHeld;

	// Token: 0x04002DE8 RID: 11752
	public int BloodMask;

	// Token: 0x04002DE9 RID: 11753
	public int Priority;

	// Token: 0x04002DEA RID: 11754
	public int ID;

	// Token: 0x04002DEB RID: 11755
	public GameObject YandereObject;

	// Token: 0x04002DEC RID: 11756
	public Transform RaycastTarget;

	// Token: 0x04002DED RID: 11757
	public float MinimumDistanceSqr;

	// Token: 0x04002DEE RID: 11758
	public float MaximumDistanceSqr;

	// Token: 0x04002DEF RID: 11759
	public Vector3 CurrentPosition;

	// Token: 0x04002DF0 RID: 11760
	public float Timer;

	// Token: 0x04002DF1 RID: 11761
	public bool Student;

	// Token: 0x04002DF2 RID: 11762
	public bool Door;

	// Token: 0x04002DF3 RID: 11763
	public bool Hidden;
}
