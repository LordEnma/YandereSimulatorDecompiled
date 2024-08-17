using UnityEngine;

public class DoorScript : MonoBehaviour
{
	[SerializeField]
	private Transform RelativeCharacter;

	[SerializeField]
	private YanSaveIdentifier Identifier;

	[SerializeField]
	private HideColliderScript HideCollider;

	public StudentScript Student;

	[SerializeField]
	private YandereScript Yandere;

	[SerializeField]
	private BucketScript Bucket;

	public PromptScript Prompt;

	public Collider[] DoorColliders;

	[SerializeField]
	private float[] ClosedPositions;

	[SerializeField]
	private float[] OpenPositions;

	[SerializeField]
	private Transform[] Doors;

	[SerializeField]
	private Texture[] Plates;

	[SerializeField]
	private UILabel[] Labels;

	[SerializeField]
	private float[] OriginX;

	[SerializeField]
	private bool CanSetBucket;

	[SerializeField]
	private bool OneWayDoor;

	[SerializeField]
	private bool HidingSpot;

	[SerializeField]
	private bool BucketSet;

	[SerializeField]
	private bool Swinging;

	public bool Locked;

	[SerializeField]
	private bool NoTrap;

	[SerializeField]
	private bool North;

	public bool Open;

	[SerializeField]
	private bool Near;

	[SerializeField]
	private float ShiftNorth = -0.1f;

	[SerializeField]
	private float ShiftSouth = 0.1f;

	[SerializeField]
	private float Rotation;

	public float TimeLimit = 2f;

	public float Timer;

	[SerializeField]
	private float TrapSwing = 12.15f;

	[SerializeField]
	private float Swing = 150f;

	[SerializeField]
	private Renderer Sign;

	[SerializeField]
	private string RoomName = string.Empty;

	[SerializeField]
	private string Facing = string.Empty;

	[SerializeField]
	private int RoomID;

	[SerializeField]
	private ClubType Club;

	[SerializeField]
	private bool DisableSelf;

	private StudentManagerScript StudentManager;

	public OcclusionPortal Portal;

	public int DoorID;

	public bool CannotLockpick;

	public bool Initialized;

	public string LockPickAnim = "f02_lockPick_00";

	public float DoorHeight = 2.25f;

	private bool Double => Doors.Length == 2;

	public void Start()
	{
		if (Initialized)
		{
			return;
		}
		Initialized = true;
		Identifier = GetComponent<YanSaveIdentifier>();
		TrapSwing = 12.15f;
		Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		StudentManager = Yandere.StudentManager;
		if (DoorID == 0)
		{
			StudentManager.Doors[StudentManager.DoorID] = this;
			StudentManager.DoorID++;
			DoorID = StudentManager.DoorID;
		}
		if (Identifier != null)
		{
			Identifier.ObjectID = "Door_" + DoorID;
		}
		else
		{
			Debug.Log(base.gameObject.name + " doesn't have an identifier.");
		}
		if (StudentManager.EastBathroomArea.bounds.Contains(base.transform.position) || StudentManager.WestBathroomArea.bounds.Contains(base.transform.position))
		{
			RoomName = "Toilet Stall";
		}
		if (Swinging)
		{
			OriginX[0] = Doors[0].transform.localPosition.z;
			if (OriginX.Length > 1)
			{
				OriginX[1] = Doors[1].transform.localPosition.z;
			}
			TimeLimit = 1f;
		}
		if (Labels.Length != 0)
		{
			Labels[0].text = RoomName;
			Labels[1].text = RoomName;
			UpdatePlate();
		}
		if (Club != 0 && ClubGlobals.GetClubClosed(Club))
		{
			Locked = true;
			Prompt.Label[0].text = "     Locked";
			Prompt.Label[2].text = "     Pick Lock";
			Prompt.OffsetY[2] = 1.2f;
		}
		else
		{
			Prompt.HideButton[2] = true;
		}
		if (DisableSelf)
		{
			base.enabled = false;
		}
		Prompt.Student = false;
		Prompt.Door = true;
		DoorColliders = new Collider[2];
		DoorColliders[0] = Doors[0].gameObject.GetComponent<BoxCollider>();
		if (DoorColliders[0] == null)
		{
			DoorColliders[0] = Doors[0].GetChild(0).gameObject.GetComponent<BoxCollider>();
		}
		Doors[0].gameObject.layer = 26;
		if (Doors[0].transform.childCount > 0)
		{
			Doors[0].transform.SetChildLayer(26);
		}
		if (Doors.Length > 1)
		{
			Doors[1].gameObject.layer = 26;
			DoorColliders[1] = Doors[1].GetComponent<BoxCollider>();
			if (Doors[1].transform.childCount > 0)
			{
				Doors[1].transform.SetChildLayer(26);
			}
			if (DoorColliders[1] == null)
			{
				DoorColliders[1] = Doors[1].GetChild(0).gameObject.GetComponent<BoxCollider>();
			}
		}
		if (!StudentManager.Eighties && RoomID == 22)
		{
			Club = ClubType.None;
		}
		if (base.transform.position.z < 55f && Mathf.Abs(base.transform.position.x) < 62f)
		{
			GetComponent<BoxCollider>().size = new Vector3(0.2f, 0.01f, 0.2f);
			return;
		}
		GetComponent<BoxCollider>().size = new Vector3(0.2f, 0.1f, 0.2f);
		if (base.transform.position.x < -64f)
		{
			GetComponent<BoxCollider>().size = new Vector3(0.2f, 0.2f, 0.2f);
		}
	}

	private void Update()
	{
		if (Prompt.DistanceSqr <= 1f)
		{
			if (Vector3.Distance(Yandere.transform.position, base.transform.position) < 2f)
			{
				if (!Near)
				{
					TopicCheck();
					Yandere.Location.Label.text = RoomName;
					Yandere.Location.Show = true;
					Near = true;
				}
				if (Prompt.Circle[0].fillAmount < 1f && Prompt.Circle[0].fillAmount > 0f)
				{
					Prompt.Circle[0].fillAmount = 0f;
					if (Prompt.Yandere.PickUp == null && !Prompt.Yandere.Carrying && Prompt.Yandere.Stance.Current == StanceType.Standing)
					{
						Prompt.Yandere.CharacterAnimation["f02_genericInteraction_00"].time = 0f;
						Prompt.Yandere.InteractWeight = 1f;
					}
					if (!Locked)
					{
						if (!Open)
						{
							OpenDoor();
						}
						else
						{
							CloseDoor();
						}
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "It's locked!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				if (Double && Swinging && Prompt.Circle[1].fillAmount == 0f)
				{
					Prompt.Circle[1].fillAmount = 1f;
					if (!BucketSet)
					{
						bool flag = false;
						if (DifficultyGlobals.MudRequired && Yandere.PickUp.Bucket.Bloodiness < 50f && !Yandere.PickUp.Bucket.Gasoline && !Yandere.PickUp.Bucket.DyedBrown)
						{
							Yandere.NotificationManager.CustomText = "Put blood, gasoline, or brown paint in the bucket.";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
							flag = true;
						}
						if (!flag)
						{
							if (SchemeGlobals.GetSchemeStage(1) == 2)
							{
								SchemeGlobals.SetSchemeStage(1, 3);
								Yandere.PauseScreen.Schemes.UpdateInstructions();
							}
							Bucket = Yandere.PickUp.Bucket;
							Yandere.EmptyHands();
							Bucket.transform.parent = base.transform;
							Bucket.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							Bucket.Trap = true;
							Bucket.Prompt.Hide();
							Bucket.Prompt.enabled = false;
							CheckDirection();
							float doorHeight = DoorHeight;
							if (North)
							{
								Bucket.transform.localPosition = new Vector3(0f, doorHeight, 0.2975f);
							}
							else
							{
								Bucket.transform.localPosition = new Vector3(0f, doorHeight, -0.2975f);
							}
							Bucket.GetComponent<Rigidbody>().isKinematic = true;
							Bucket.GetComponent<Rigidbody>().useGravity = false;
							if (Open)
							{
								DoorColliders[0].isTrigger = true;
								DoorColliders[1].isTrigger = true;
							}
							Prompt.Label[1].text = "     Remove Bucket";
							Prompt.Label[1].color = Color.white;
							Prompt.HideButton[0] = true;
							CanSetBucket = false;
							BucketSet = true;
							Open = false;
							Timer = 0f;
							Debug.Log("CreatingBucketTrap should be true for the next second...");
							Yandere.SuspiciousActionTimer = 1f;
							Yandere.CreatingBucketTrap = true;
						}
					}
					else
					{
						Yandere.EmptyHands();
						Bucket.PickUp.BePickedUp();
						Prompt.HideButton[0] = false;
						Prompt.Label[1].text = "     Set Trap";
						Prompt.Label[1].color = Color.red;
						BucketSet = false;
						Bucket = null;
						Timer = 0f;
					}
				}
			}
		}
		else if (Near)
		{
			Yandere.Location.Show = false;
			Near = false;
		}
		if (Timer < TimeLimit)
		{
			Timer += Time.deltaTime;
			if (!Open && Timer >= TimeLimit)
			{
				if (DoorColliders.Length != 0 && DoorColliders[0] == null)
				{
					Initialized = false;
				}
				if (!Initialized)
				{
					Start();
				}
				if (DoorColliders.Length != 0)
				{
					DoorColliders[0].isTrigger = false;
				}
				if (DoorColliders.Length > 1 && DoorColliders[1] != null)
				{
					DoorColliders[1].isTrigger = false;
				}
				if (Portal != null)
				{
					Portal.open = Open;
				}
			}
			if (BucketSet)
			{
				for (int i = 0; i < Doors.Length; i++)
				{
					Transform transform = Doors[i];
					transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, OriginX[i] + (North ? ShiftSouth : ShiftNorth), Time.deltaTime * 3.6f));
					Rotation = Mathf.Lerp(Rotation, North ? (0f - TrapSwing) : TrapSwing, Time.deltaTime * 3.6f);
					transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (i == 0) ? Rotation : (0f - Rotation), transform.localEulerAngles.z);
				}
			}
			else if (!Open)
			{
				for (int j = 0; j < Doors.Length; j++)
				{
					Transform transform2 = Doors[j];
					if (!Swinging)
					{
						transform2.localPosition = new Vector3(Mathf.Lerp(transform2.localPosition.x, ClosedPositions[j], Time.deltaTime * 3.6f), transform2.localPosition.y, transform2.localPosition.z);
						continue;
					}
					Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 3.6f);
					transform2.localPosition = new Vector3(transform2.localPosition.x, transform2.localPosition.y, Mathf.Lerp(transform2.localPosition.z, OriginX[j], Time.deltaTime * 3.6f));
					transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, (j == 0) ? Rotation : (0f - Rotation), transform2.localEulerAngles.z);
				}
			}
			else
			{
				for (int k = 0; k < Doors.Length; k++)
				{
					Transform transform3 = Doors[k];
					if (!Swinging)
					{
						transform3.localPosition = new Vector3(Mathf.Lerp(transform3.localPosition.x, OpenPositions[k], Time.deltaTime * 3.6f), transform3.localPosition.y, transform3.localPosition.z);
						continue;
					}
					transform3.localPosition = new Vector3(transform3.localPosition.x, transform3.localPosition.y, Mathf.Lerp(transform3.localPosition.z, OriginX[k] + (North ? ShiftNorth : ShiftSouth), Time.deltaTime * 3.6f));
					Rotation = Mathf.Lerp(Rotation, North ? Swing : (0f - Swing), Time.deltaTime * 3.6f);
					transform3.localEulerAngles = new Vector3(transform3.localEulerAngles.x, (k == 0) ? Rotation : (0f - Rotation), transform3.localEulerAngles.z);
				}
			}
		}
		else if (Locked)
		{
			if (Prompt.Circle[0].fillAmount < 1f)
			{
				Prompt.Label[0].text = "     Locked";
			}
			if (Yandere.Inventory.LockPicks > 0)
			{
				Prompt.HideButton[2] = false;
				if (Prompt.Circle[2] == null)
				{
					Debug.Log("Perhaps an error occured when loading the game that caused this door to mistake itself for another door.");
					Locked = false;
				}
				else if (Prompt.Circle[2].fillAmount == 0f)
				{
					Prompt.Circle[2].fillAmount = 1f;
					if (CannotLockpick)
					{
						Yandere.NotificationManager.CustomText = "Cannot lockpick this door";
						Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else
					{
						Prompt.Yandere.EmptyHands();
						Debug.Log("Commence lockpicking.");
						Prompt.Yandere.Inventory.LockPicks--;
						Prompt.Label[0].text = "     Open";
						Prompt.HideButton[2] = true;
						Locked = false;
						Prompt.Yandere.LockPickAnim = LockPickAnim;
						Prompt.Yandere.CharacterAnimation.CrossFade(LockPickAnim);
						Prompt.Yandere.LockpickTarget = base.transform;
						Prompt.Yandere.Lockpicking = true;
						Prompt.Yandere.CanMove = false;
					}
				}
			}
			else if (!Prompt.HideButton[2])
			{
				Prompt.HideButton[2] = true;
			}
		}
		if (!NoTrap && Swinging && Double)
		{
			if (Yandere.PickUp != null)
			{
				if (Yandere.PickUp.Bucket != null)
				{
					if (Yandere.PickUp.GetComponent<BucketScript>().Full)
					{
						if (Bucket == null)
						{
							Prompt.Label[1].color = Color.red;
							Prompt.HideButton[1] = false;
							CanSetBucket = true;
						}
					}
					else if (CanSetBucket)
					{
						Prompt.HideButton[1] = true;
						CanSetBucket = false;
					}
				}
				else if (CanSetBucket)
				{
					Prompt.HideButton[1] = true;
					CanSetBucket = false;
				}
			}
			else if (CanSetBucket)
			{
				Prompt.HideButton[1] = true;
				CanSetBucket = false;
			}
		}
		if (!BucketSet || !Bucket.Gasoline || !(StudentManager.Students[StudentManager.RivalID] != null) || StudentManager.Students[StudentManager.RivalID].GasWarned)
		{
			return;
		}
		StudentScript follower = StudentManager.Students[StudentManager.RivalID].Follower;
		if (follower != null && follower.Alive && follower.CurrentAction == StudentActionType.Follow && !follower.ReturningMisplacedWeapon && Vector3.Distance(StudentManager.Students[StudentManager.RivalID].transform.position, follower.transform.position) < 10f)
		{
			Debug.Log("The rival has a follower who is currently following her and is not busy doing anything else.");
			if (Vector3.Distance(base.transform.position, StudentManager.Students[StudentManager.RivalID].transform.position) < 10f)
			{
				Debug.Log("The follower has warned the rival.");
				Yandere.Subtitle.UpdateLabel(SubtitleType.GasWarning, 1, 5f);
				StudentManager.Students[StudentManager.RivalID].GasWarned = true;
			}
		}
	}

	public void OpenDoor()
	{
		if (DoorColliders.Length == 0 || DoorColliders[0] == null)
		{
			Initialized = false;
		}
		if (!Initialized)
		{
			Start();
		}
		DoorColliders[0].isTrigger = true;
		if (DoorColliders[1] != null)
		{
			DoorColliders[1].isTrigger = true;
		}
		if (Portal != null)
		{
			Portal.open = true;
		}
		Open = true;
		Timer = 0f;
		UpdateLabel();
		if (HidingSpot)
		{
			Object.Destroy(HideCollider.GetComponent<BoxCollider>());
		}
		CheckDirection();
		if (BucketSet)
		{
			if (Student.WillRemoveBucket)
			{
				Yandere.NotificationManager.CustomText = Student.Name + " removed bucket trap.";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Yandere.Subtitle.CustomText = "Let's set this on the ground...";
				Yandere.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
				Bucket.transform.position = base.transform.position;
				Student.WillRemoveBucket = false;
			}
			else
			{
				Bucket.GetComponent<Rigidbody>().isKinematic = false;
				Bucket.GetComponent<Rigidbody>().useGravity = true;
				Bucket.UpdateAppearance = true;
				Bucket.Fly = true;
			}
			Bucket.Prompt.enabled = true;
			Prompt.HideButton[0] = false;
			Prompt.HideButton[1] = true;
			Prompt.Label[1].text = "     Set Trap";
			Prompt.Label[1].color = Color.red;
			Prompt.enabled = true;
			BucketSet = false;
			Bucket = null;
		}
		if (Swinging)
		{
			AudioSource.PlayClipAtPoint(StudentManager.SwingingDoorOpen, base.transform.position);
		}
		else
		{
			AudioSource.PlayClipAtPoint(StudentManager.SlidingDoorOpen, base.transform.position);
		}
		Student = null;
	}

	private void LockDoor()
	{
		Open = false;
		Prompt.Hide();
		Prompt.enabled = false;
	}

	private void CheckDirection()
	{
		North = false;
		if (OneWayDoor)
		{
			return;
		}
		RelativeCharacter = ((Student != null) ? Student.transform : Yandere.transform);
		if (Facing == "North")
		{
			if (RelativeCharacter.position.z < base.transform.position.z)
			{
				North = true;
			}
		}
		else if (Facing == "South")
		{
			if (RelativeCharacter.position.z > base.transform.position.z)
			{
				North = true;
			}
		}
		else if (Facing == "East")
		{
			if (RelativeCharacter.position.x < base.transform.position.x)
			{
				North = true;
			}
		}
		else if (Facing == "West" && RelativeCharacter.position.x > base.transform.position.x)
		{
			North = true;
		}
	}

	public void CloseDoor()
	{
		Open = false;
		Timer = 0f;
		UpdateLabel();
		DoorColliders[0].isTrigger = true;
		if (DoorColliders[1] != null)
		{
			DoorColliders[1].isTrigger = true;
		}
		if (HidingSpot)
		{
			HideCollider.gameObject.AddComponent<BoxCollider>();
			BoxCollider component = HideCollider.GetComponent<BoxCollider>();
			component.size = new Vector3(component.size.x, component.size.y, 2f);
			component.isTrigger = true;
			HideCollider.MyCollider = component;
		}
		if (Swinging)
		{
			AudioSource.PlayClipAtPoint(StudentManager.SwingingDoorShut, base.transform.position);
		}
		else
		{
			AudioSource.PlayClipAtPoint(StudentManager.SlidingDoorShut, base.transform.position);
		}
	}

	private void UpdateLabel()
	{
		if (Open)
		{
			Prompt.Label[0].text = "     Close";
		}
		else
		{
			Prompt.Label[0].text = "     Open";
		}
	}

	private void UpdatePlate()
	{
		switch (RoomID)
		{
		case 1:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
			break;
		case 2:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
			break;
		case 3:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0f, 0.25f);
			break;
		case 4:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0f, 0f);
			break;
		case 5:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
			break;
		case 6:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
			break;
		case 8:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.25f, 0f);
			break;
		case 9:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
			break;
		case 10:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
			break;
		case 11:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
			break;
		case 12:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.5f, 0f);
			break;
		case 13:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
			break;
		case 14:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
			break;
		case 15:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
			break;
		case 16:
			Sign.material.mainTexture = Plates[1];
			Sign.material.mainTextureOffset = new Vector2(0.75f, 0f);
			break;
		case 17:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
			break;
		case 18:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
			break;
		case 19:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0f, 0.25f);
			break;
		case 20:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0f, 0f);
			break;
		case 21:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
			break;
		case 22:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
			break;
		case 23:
			Sign.material.mainTexture = Plates[3];
			Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
			break;
		case 24:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.25f, 0f);
			break;
		case 25:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
			break;
		case 26:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
			break;
		case 27:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
			break;
		case 28:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.5f, 0f);
			break;
		case 29:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
			break;
		case 30:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
			break;
		case 31:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
			break;
		case 32:
			Sign.material.mainTexture = Plates[2];
			Sign.material.mainTextureOffset = new Vector2(0.75f, 0f);
			break;
		case 33:
			Sign.material.mainTexture = Plates[3];
			Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
			break;
		case 34:
			Sign.material.mainTexture = Plates[3];
			Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
			break;
		case 40:
			Sign.material.mainTexture = Plates[3];
			Sign.material.mainTextureOffset = new Vector2(0f, 0.25f);
			break;
		case 7:
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
			break;
		}
	}

	private void TopicCheck()
	{
		if (RoomID > 25 && RoomID < 37)
		{
			StudentManager.TutorialWindow.ShowClubMessage = true;
		}
		switch (RoomID)
		{
		case 3:
			if (!ConversationGlobals.GetTopicDiscovered(22))
			{
				ConversationGlobals.SetTopicDiscovered(22, value: true);
				Yandere.NotificationManager.TopicName = "School";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 13:
			if (!ConversationGlobals.GetTopicDiscovered(18))
			{
				ConversationGlobals.SetTopicDiscovered(18, value: true);
				Yandere.NotificationManager.TopicName = "Reading";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 22:
			if (!ConversationGlobals.GetTopicDiscovered(11))
			{
				ConversationGlobals.SetTopicDiscovered(11, value: true);
				ConversationGlobals.SetTopicDiscovered(12, value: true);
				ConversationGlobals.SetTopicDiscovered(13, value: true);
				ConversationGlobals.SetTopicDiscovered(14, value: true);
				Yandere.NotificationManager.TopicName = "Video Games";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				Yandere.NotificationManager.TopicName = "Anime";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				Yandere.NotificationManager.TopicName = "Cosplay";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				if (!StudentManager.Eighties)
				{
					Yandere.NotificationManager.TopicName = "Memes";
				}
				else
				{
					Yandere.NotificationManager.TopicName = "Jokes";
				}
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 26:
			if (!ConversationGlobals.GetTopicDiscovered(1))
			{
				ConversationGlobals.SetTopicDiscovered(1, value: true);
				Yandere.NotificationManager.TopicName = "Cooking";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 27:
			if (!ConversationGlobals.GetTopicDiscovered(2))
			{
				ConversationGlobals.SetTopicDiscovered(2, value: true);
				Yandere.NotificationManager.TopicName = "Drama";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(25, value: true);
				Yandere.NotificationManager.TopicName = "Money";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 28:
			if (!ConversationGlobals.GetTopicDiscovered(3))
			{
				ConversationGlobals.SetTopicDiscovered(3, value: true);
				Yandere.NotificationManager.TopicName = "Occult";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 29:
			if (!ConversationGlobals.GetTopicDiscovered(4))
			{
				ConversationGlobals.SetTopicDiscovered(4, value: true);
				Yandere.NotificationManager.TopicName = "Art";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 30:
			if (!ConversationGlobals.GetTopicDiscovered(5))
			{
				ConversationGlobals.SetTopicDiscovered(5, value: true);
				Yandere.NotificationManager.TopicName = "Music";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 31:
			if (!ConversationGlobals.GetTopicDiscovered(6))
			{
				ConversationGlobals.SetTopicDiscovered(6, value: true);
				Yandere.NotificationManager.TopicName = "Martial Arts";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			if (!ConversationGlobals.GetTopicDiscovered(16))
			{
				ConversationGlobals.SetTopicDiscovered(16, value: true);
				Yandere.NotificationManager.TopicName = "Justice";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			if (!ConversationGlobals.GetTopicDiscovered(17))
			{
				ConversationGlobals.SetTopicDiscovered(17, value: true);
				Yandere.NotificationManager.TopicName = "Violence";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 32:
			if (!ConversationGlobals.GetTopicDiscovered(7))
			{
				ConversationGlobals.SetTopicDiscovered(7, value: true);
				Yandere.NotificationManager.TopicName = "Photography";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 34:
			if (!ConversationGlobals.GetTopicDiscovered(8))
			{
				ConversationGlobals.SetTopicDiscovered(8, value: true);
				Yandere.NotificationManager.TopicName = "Science";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 35:
			if (!ConversationGlobals.GetTopicDiscovered(9))
			{
				ConversationGlobals.SetTopicDiscovered(9, value: true);
				Yandere.NotificationManager.TopicName = "Sports";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 36:
			if (!ConversationGlobals.GetTopicDiscovered(10))
			{
				ConversationGlobals.SetTopicDiscovered(10, value: true);
				Yandere.NotificationManager.TopicName = "Gardening";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			if (!ConversationGlobals.GetTopicDiscovered(24))
			{
				ConversationGlobals.SetTopicDiscovered(24, value: true);
				Yandere.NotificationManager.TopicName = "Nature";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 1:
		case 2:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 23:
		case 24:
		case 25:
		case 33:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
			break;
		}
	}
}
