using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
public class DoorScript : MonoBehaviour
{
	// Token: 0x1700034A RID: 842
	// (get) Token: 0x060013C0 RID: 5056 RVA: 0x000B9BD3 File Offset: 0x000B7DD3
	private bool Double
	{
		get
		{
			return this.Doors.Length == 2;
		}
	}

	// Token: 0x060013C1 RID: 5057 RVA: 0x000B9BE0 File Offset: 0x000B7DE0
	public void Start()
	{
		if (!this.Initialized)
		{
			this.Initialized = true;
			this.Identifier = base.GetComponent<YanSaveIdentifier>();
			this.TrapSwing = 12.15f;
			this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
			this.StudentManager = this.Yandere.StudentManager;
			this.StudentManager.Doors[this.StudentManager.DoorID] = this;
			this.StudentManager.DoorID++;
			this.DoorID = this.StudentManager.DoorID;
			if (this.Identifier != null)
			{
				this.Identifier.ObjectID = "Door_" + this.DoorID.ToString();
			}
			else
			{
				Debug.Log(base.gameObject.name + " doesn't have an identifier.");
			}
			if (this.StudentManager.EastBathroomArea.bounds.Contains(base.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(base.transform.position))
			{
				this.RoomName = "Toilet Stall";
			}
			if (this.Swinging)
			{
				this.OriginX[0] = this.Doors[0].transform.localPosition.z;
				if (this.OriginX.Length > 1)
				{
					this.OriginX[1] = this.Doors[1].transform.localPosition.z;
				}
				this.TimeLimit = 1f;
			}
			if (this.Labels.Length != 0)
			{
				this.Labels[0].text = this.RoomName;
				this.Labels[1].text = this.RoomName;
				this.UpdatePlate();
			}
			if (this.Club != ClubType.None && ClubGlobals.GetClubClosed(this.Club))
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.enabled = false;
			}
			if (this.DisableSelf)
			{
				base.enabled = false;
			}
			this.Prompt.Student = false;
			this.Prompt.Door = true;
			this.DoorColliders = new Collider[2];
			this.DoorColliders[0] = this.Doors[0].gameObject.GetComponent<BoxCollider>();
			if (this.DoorColliders[0] == null)
			{
				this.DoorColliders[0] = this.Doors[0].GetChild(0).gameObject.GetComponent<BoxCollider>();
			}
			if (this.Doors.Length > 1)
			{
				this.DoorColliders[1] = this.Doors[1].GetComponent<BoxCollider>();
			}
			if (!this.StudentManager.Eighties && this.RoomID == 22)
			{
				this.Club = ClubType.None;
			}
			if (base.transform.position.z < 55f && Mathf.Abs(base.transform.position.x) < 62f)
			{
				base.GetComponent<BoxCollider>().size = new Vector3(0.2f, 0.01f, 0.2f);
				return;
			}
			base.GetComponent<BoxCollider>().size = new Vector3(0.2f, 0.1f, 0.2f);
		}
	}

	// Token: 0x060013C2 RID: 5058 RVA: 0x000B9F08 File Offset: 0x000B8108
	private void Update()
	{
		if (this.Prompt.DistanceSqr <= 1f)
		{
			if (Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 2f)
			{
				if (!this.Near)
				{
					this.TopicCheck();
					this.Yandere.Location.Label.text = this.RoomName;
					this.Yandere.Location.Show = true;
					this.Near = true;
				}
				if (this.Prompt.Circle[0].fillAmount < 1f && this.Prompt.Circle[0].fillAmount > 0f)
				{
					this.Prompt.Circle[0].fillAmount = 0f;
					if (!this.Locked)
					{
						if (!this.Open)
						{
							this.OpenDoor();
						}
						else
						{
							this.CloseDoor();
						}
					}
				}
				if (this.Double && this.Swinging && this.Prompt.Circle[1].fillAmount == 0f)
				{
					this.Prompt.Circle[1].fillAmount = 1f;
					if (!this.BucketSet)
					{
						if (SchemeGlobals.GetSchemeStage(1) == 2)
						{
							SchemeGlobals.SetSchemeStage(1, 3);
							this.Yandere.PauseScreen.Schemes.UpdateInstructions();
						}
						this.Bucket = this.Yandere.PickUp.Bucket;
						this.Yandere.EmptyHands();
						this.Bucket.transform.parent = base.transform;
						this.Bucket.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						this.Bucket.Trap = true;
						this.Bucket.Prompt.Hide();
						this.Bucket.Prompt.enabled = false;
						this.CheckDirection();
						if (this.North)
						{
							this.Bucket.transform.localPosition = new Vector3(0f, 2.25f, 0.2975f);
						}
						else
						{
							this.Bucket.transform.localPosition = new Vector3(0f, 2.25f, -0.2975f);
						}
						this.Bucket.GetComponent<Rigidbody>().isKinematic = true;
						this.Bucket.GetComponent<Rigidbody>().useGravity = false;
						if (this.Open)
						{
							this.DoorColliders[0].isTrigger = true;
							this.DoorColliders[1].isTrigger = true;
						}
						this.Prompt.Label[1].text = "     Remove Bucket";
						this.Prompt.HideButton[0] = true;
						this.CanSetBucket = false;
						this.BucketSet = true;
						this.Open = false;
						this.Timer = 0f;
					}
					else
					{
						this.Yandere.EmptyHands();
						this.Bucket.PickUp.BePickedUp();
						this.Prompt.HideButton[0] = false;
						this.Prompt.Label[1].text = "     Set Trap";
						this.BucketSet = false;
						this.Bucket = null;
						this.Timer = 0f;
					}
				}
			}
		}
		else if (this.Near)
		{
			this.Yandere.Location.Show = false;
			this.Near = false;
		}
		if (this.Timer < this.TimeLimit)
		{
			this.Timer += Time.deltaTime;
			if (!this.Open && !this.OneWayDoor && this.Timer >= this.TimeLimit)
			{
				this.DoorColliders[0].isTrigger = false;
				if (this.DoorColliders[1] != null)
				{
					this.DoorColliders[1].isTrigger = false;
				}
			}
			if (this.BucketSet)
			{
				for (int i = 0; i < this.Doors.Length; i++)
				{
					Transform transform = this.Doors[i];
					transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, this.OriginX[i] + (this.North ? this.ShiftSouth : this.ShiftNorth), Time.deltaTime * 3.6f));
					this.Rotation = Mathf.Lerp(this.Rotation, this.North ? (-this.TrapSwing) : this.TrapSwing, Time.deltaTime * 3.6f);
					transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (i == 0) ? this.Rotation : (-this.Rotation), transform.localEulerAngles.z);
				}
			}
			else if (!this.Open)
			{
				for (int j = 0; j < this.Doors.Length; j++)
				{
					Transform transform2 = this.Doors[j];
					if (!this.Swinging)
					{
						transform2.localPosition = new Vector3(Mathf.Lerp(transform2.localPosition.x, this.ClosedPositions[j], Time.deltaTime * 3.6f), transform2.localPosition.y, transform2.localPosition.z);
					}
					else
					{
						this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 3.6f);
						transform2.localPosition = new Vector3(transform2.localPosition.x, transform2.localPosition.y, Mathf.Lerp(transform2.localPosition.z, this.OriginX[j], Time.deltaTime * 3.6f));
						transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, (j == 0) ? this.Rotation : (-this.Rotation), transform2.localEulerAngles.z);
					}
				}
			}
			else
			{
				for (int k = 0; k < this.Doors.Length; k++)
				{
					Transform transform3 = this.Doors[k];
					if (!this.Swinging)
					{
						transform3.localPosition = new Vector3(Mathf.Lerp(transform3.localPosition.x, this.OpenPositions[k], Time.deltaTime * 3.6f), transform3.localPosition.y, transform3.localPosition.z);
					}
					else
					{
						transform3.localPosition = new Vector3(transform3.localPosition.x, transform3.localPosition.y, Mathf.Lerp(transform3.localPosition.z, this.OriginX[k] + (this.North ? this.ShiftNorth : this.ShiftSouth), Time.deltaTime * 3.6f));
						this.Rotation = Mathf.Lerp(this.Rotation, this.North ? this.Swing : (-this.Swing), Time.deltaTime * 3.6f);
						transform3.localEulerAngles = new Vector3(transform3.localEulerAngles.x, (k == 0) ? this.Rotation : (-this.Rotation), transform3.localEulerAngles.z);
					}
				}
			}
		}
		else if (this.Locked)
		{
			if (this.Prompt.Circle[0].fillAmount < 1f)
			{
				this.Prompt.Label[0].text = "     Locked";
				this.Prompt.Circle[0].fillAmount = 1f;
			}
			if (this.Yandere.Inventory.LockPick)
			{
				this.Prompt.HideButton[2] = false;
				if (this.Prompt.Circle[2].fillAmount == 0f)
				{
					this.Prompt.Yandere.Inventory.LockPick = false;
					this.Prompt.HideButton[2] = true;
					this.Locked = false;
				}
			}
			else if (!this.Prompt.HideButton[2])
			{
				this.Prompt.HideButton[2] = true;
			}
		}
		if (!this.NoTrap && this.Swinging && this.Double)
		{
			if (this.Yandere.PickUp != null)
			{
				if (this.Yandere.PickUp.Bucket != null)
				{
					if (this.Yandere.PickUp.GetComponent<BucketScript>().Full)
					{
						if (this.Bucket == null)
						{
							this.Prompt.HideButton[1] = false;
							this.CanSetBucket = true;
						}
					}
					else if (this.CanSetBucket)
					{
						this.Prompt.HideButton[1] = true;
						this.CanSetBucket = false;
					}
				}
				else if (this.CanSetBucket)
				{
					this.Prompt.HideButton[1] = true;
					this.CanSetBucket = false;
				}
			}
			else if (this.CanSetBucket)
			{
				this.Prompt.HideButton[1] = true;
				this.CanSetBucket = false;
			}
		}
		if (this.BucketSet && this.Bucket.Gasoline && this.StudentManager.Students[this.StudentManager.RivalID] != null && !this.StudentManager.Students[this.StudentManager.RivalID].GasWarned)
		{
			StudentScript follower = this.StudentManager.Students[this.StudentManager.RivalID].Follower;
			if (follower != null && follower.Alive && follower.CurrentAction == StudentActionType.Follow && Vector3.Distance(this.StudentManager.Students[this.StudentManager.RivalID].transform.position, follower.transform.position) < 10f && Vector3.Distance(base.transform.position, this.StudentManager.Students[this.StudentManager.RivalID].transform.position) < 10f)
			{
				this.Yandere.Subtitle.UpdateLabel(SubtitleType.GasWarning, 1, 5f);
				this.StudentManager.Students[this.StudentManager.RivalID].GasWarned = true;
			}
		}
	}

	// Token: 0x060013C3 RID: 5059 RVA: 0x000BA92C File Offset: 0x000B8B2C
	public void OpenDoor()
	{
		this.DoorColliders[0].isTrigger = true;
		if (this.DoorColliders[1] != null)
		{
			this.DoorColliders[1].isTrigger = true;
		}
		if (this.Portal != null)
		{
			this.Portal.open = true;
		}
		this.Open = true;
		this.Timer = 0f;
		this.UpdateLabel();
		if (this.HidingSpot)
		{
			UnityEngine.Object.Destroy(this.HideCollider.GetComponent<BoxCollider>());
		}
		this.CheckDirection();
		if (this.BucketSet)
		{
			this.Bucket.GetComponent<Rigidbody>().isKinematic = false;
			this.Bucket.GetComponent<Rigidbody>().useGravity = true;
			this.Bucket.UpdateAppearance = true;
			this.Bucket.Prompt.enabled = true;
			this.Bucket.Fly = true;
			this.Prompt.HideButton[0] = false;
			this.Prompt.HideButton[1] = true;
			this.Prompt.Label[1].text = "     Set Trap";
			this.Prompt.enabled = true;
			this.BucketSet = false;
			this.Bucket = null;
		}
		if (this.Swinging)
		{
			AudioSource.PlayClipAtPoint(this.StudentManager.SwingingDoorOpen, base.transform.position);
			return;
		}
		AudioSource.PlayClipAtPoint(this.StudentManager.SlidingDoorOpen, base.transform.position);
	}

	// Token: 0x060013C4 RID: 5060 RVA: 0x000BAA97 File Offset: 0x000B8C97
	private void LockDoor()
	{
		this.Open = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	// Token: 0x060013C5 RID: 5061 RVA: 0x000BAAB8 File Offset: 0x000B8CB8
	private void CheckDirection()
	{
		this.North = false;
		if (!this.OneWayDoor)
		{
			this.RelativeCharacter = ((this.Student != null) ? this.Student.transform : this.Yandere.transform);
			if (this.Facing == "North")
			{
				if (this.RelativeCharacter.position.z < base.transform.position.z)
				{
					this.North = true;
				}
			}
			else if (this.Facing == "South")
			{
				if (this.RelativeCharacter.position.z > base.transform.position.z)
				{
					this.North = true;
				}
			}
			else if (this.Facing == "East")
			{
				if (this.RelativeCharacter.position.x < base.transform.position.x)
				{
					this.North = true;
				}
			}
			else if (this.Facing == "West" && this.RelativeCharacter.position.x > base.transform.position.x)
			{
				this.North = true;
			}
		}
		this.Student = null;
	}

	// Token: 0x060013C6 RID: 5062 RVA: 0x000BAC08 File Offset: 0x000B8E08
	public void CloseDoor()
	{
		this.Open = false;
		this.Timer = 0f;
		this.UpdateLabel();
		this.DoorColliders[0].isTrigger = true;
		if (this.DoorColliders[1] != null)
		{
			this.DoorColliders[1].isTrigger = true;
		}
		if (this.HidingSpot)
		{
			this.HideCollider.gameObject.AddComponent<BoxCollider>();
			BoxCollider component = this.HideCollider.GetComponent<BoxCollider>();
			component.size = new Vector3(component.size.x, component.size.y, 2f);
			component.isTrigger = true;
			this.HideCollider.MyCollider = component;
		}
		if (this.Swinging)
		{
			AudioSource.PlayClipAtPoint(this.StudentManager.SwingingDoorShut, base.transform.position);
			return;
		}
		AudioSource.PlayClipAtPoint(this.StudentManager.SlidingDoorShut, base.transform.position);
	}

	// Token: 0x060013C7 RID: 5063 RVA: 0x000BACF6 File Offset: 0x000B8EF6
	private void UpdateLabel()
	{
		if (this.Open)
		{
			this.Prompt.Label[0].text = "     Close";
			return;
		}
		this.Prompt.Label[0].text = "     Open";
	}

	// Token: 0x060013C8 RID: 5064 RVA: 0x000BAD30 File Offset: 0x000B8F30
	private void UpdatePlate()
	{
		switch (this.RoomID)
		{
		case 1:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
			return;
		case 2:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
			return;
		case 3:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.25f);
			return;
		case 4:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0f);
			return;
		case 5:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
			return;
		case 6:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
			return;
		case 7:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
			return;
		case 8:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0f);
			return;
		case 9:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
			return;
		case 10:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
			return;
		case 11:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
			return;
		case 12:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0f);
			return;
		case 13:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
			return;
		case 14:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
			return;
		case 15:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
			return;
		case 16:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0f);
			return;
		case 17:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
			return;
		case 18:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
			return;
		case 19:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.25f);
			return;
		case 20:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0f);
			return;
		case 21:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
			return;
		case 22:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
			return;
		case 23:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
			return;
		case 24:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0f);
			return;
		case 25:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
			return;
		case 26:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
			return;
		case 27:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
			return;
		case 28:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0f);
			return;
		case 29:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
			return;
		case 30:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
			return;
		case 31:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
			return;
		case 32:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0f);
			return;
		case 33:
			this.Sign.material.mainTexture = this.Plates[3];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
			return;
		case 34:
			this.Sign.material.mainTexture = this.Plates[3];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
			return;
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
			break;
		case 40:
			this.Sign.material.mainTexture = this.Plates[3];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.25f);
			break;
		default:
			return;
		}
	}

	// Token: 0x060013C9 RID: 5065 RVA: 0x000BB594 File Offset: 0x000B9794
	private void TopicCheck()
	{
		if (this.RoomID > 25 && this.RoomID < 37)
		{
			this.StudentManager.TutorialWindow.ShowClubMessage = true;
		}
		switch (this.RoomID)
		{
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
			break;
		case 3:
			if (!ConversationGlobals.GetTopicDiscovered(22))
			{
				ConversationGlobals.SetTopicDiscovered(22, true);
				this.Yandere.NotificationManager.TopicName = "School";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 13:
			if (!ConversationGlobals.GetTopicDiscovered(18))
			{
				ConversationGlobals.SetTopicDiscovered(18, true);
				this.Yandere.NotificationManager.TopicName = "Reading";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 22:
			if (!ConversationGlobals.GetTopicDiscovered(11))
			{
				ConversationGlobals.SetTopicDiscovered(11, true);
				ConversationGlobals.SetTopicDiscovered(12, true);
				ConversationGlobals.SetTopicDiscovered(13, true);
				ConversationGlobals.SetTopicDiscovered(14, true);
				this.Yandere.NotificationManager.TopicName = "Video Games";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				this.Yandere.NotificationManager.TopicName = "Anime";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				this.Yandere.NotificationManager.TopicName = "Cosplay";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				if (!this.StudentManager.Eighties)
				{
					this.Yandere.NotificationManager.TopicName = "Memes";
				}
				else
				{
					this.Yandere.NotificationManager.TopicName = "Jokes";
				}
				this.Yandere.NotificationManager.TopicName = "Memes";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 26:
			if (!ConversationGlobals.GetTopicDiscovered(1))
			{
				ConversationGlobals.SetTopicDiscovered(1, true);
				this.Yandere.NotificationManager.TopicName = "Cooking";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 27:
			if (!ConversationGlobals.GetTopicDiscovered(2))
			{
				ConversationGlobals.SetTopicDiscovered(2, true);
				this.Yandere.NotificationManager.TopicName = "Drama";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 28:
			if (!ConversationGlobals.GetTopicDiscovered(3))
			{
				ConversationGlobals.SetTopicDiscovered(3, true);
				this.Yandere.NotificationManager.TopicName = "Occult";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 29:
			if (!ConversationGlobals.GetTopicDiscovered(4))
			{
				ConversationGlobals.SetTopicDiscovered(4, true);
				this.Yandere.NotificationManager.TopicName = "Art";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 30:
			if (!ConversationGlobals.GetTopicDiscovered(5))
			{
				ConversationGlobals.SetTopicDiscovered(5, true);
				this.Yandere.NotificationManager.TopicName = "Music";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 31:
			if (!ConversationGlobals.GetTopicDiscovered(6))
			{
				ConversationGlobals.SetTopicDiscovered(6, true);
				this.Yandere.NotificationManager.TopicName = "Martial Arts";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			if (!ConversationGlobals.GetTopicDiscovered(16))
			{
				ConversationGlobals.SetTopicDiscovered(16, true);
				this.Yandere.NotificationManager.TopicName = "Justice";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			if (!ConversationGlobals.GetTopicDiscovered(17))
			{
				ConversationGlobals.SetTopicDiscovered(17, true);
				this.Yandere.NotificationManager.TopicName = "Violence";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 32:
			if (!ConversationGlobals.GetTopicDiscovered(7))
			{
				ConversationGlobals.SetTopicDiscovered(7, true);
				this.Yandere.NotificationManager.TopicName = "Photography";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 34:
			if (!ConversationGlobals.GetTopicDiscovered(8))
			{
				ConversationGlobals.SetTopicDiscovered(8, true);
				this.Yandere.NotificationManager.TopicName = "Science";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 35:
			if (!ConversationGlobals.GetTopicDiscovered(9))
			{
				ConversationGlobals.SetTopicDiscovered(9, true);
				this.Yandere.NotificationManager.TopicName = "Sports";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				return;
			}
			break;
		case 36:
			if (!ConversationGlobals.GetTopicDiscovered(10))
			{
				ConversationGlobals.SetTopicDiscovered(10, true);
				this.Yandere.NotificationManager.TopicName = "Gardening";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			if (!ConversationGlobals.GetTopicDiscovered(24))
			{
				ConversationGlobals.SetTopicDiscovered(24, true);
				this.Yandere.NotificationManager.TopicName = "Nature";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x04001D53 RID: 7507
	[SerializeField]
	private Transform RelativeCharacter;

	// Token: 0x04001D54 RID: 7508
	[SerializeField]
	private YanSaveIdentifier Identifier;

	// Token: 0x04001D55 RID: 7509
	[SerializeField]
	private HideColliderScript HideCollider;

	// Token: 0x04001D56 RID: 7510
	public StudentScript Student;

	// Token: 0x04001D57 RID: 7511
	[SerializeField]
	private YandereScript Yandere;

	// Token: 0x04001D58 RID: 7512
	[SerializeField]
	private BucketScript Bucket;

	// Token: 0x04001D59 RID: 7513
	public PromptScript Prompt;

	// Token: 0x04001D5A RID: 7514
	[SerializeField]
	private Collider[] DoorColliders;

	// Token: 0x04001D5B RID: 7515
	[SerializeField]
	private float[] ClosedPositions;

	// Token: 0x04001D5C RID: 7516
	[SerializeField]
	private float[] OpenPositions;

	// Token: 0x04001D5D RID: 7517
	[SerializeField]
	private Transform[] Doors;

	// Token: 0x04001D5E RID: 7518
	[SerializeField]
	private Texture[] Plates;

	// Token: 0x04001D5F RID: 7519
	[SerializeField]
	private UILabel[] Labels;

	// Token: 0x04001D60 RID: 7520
	[SerializeField]
	private float[] OriginX;

	// Token: 0x04001D61 RID: 7521
	[SerializeField]
	private bool CanSetBucket;

	// Token: 0x04001D62 RID: 7522
	[SerializeField]
	private bool OneWayDoor;

	// Token: 0x04001D63 RID: 7523
	[SerializeField]
	private bool HidingSpot;

	// Token: 0x04001D64 RID: 7524
	[SerializeField]
	private bool BucketSet;

	// Token: 0x04001D65 RID: 7525
	[SerializeField]
	private bool Swinging;

	// Token: 0x04001D66 RID: 7526
	public bool Locked;

	// Token: 0x04001D67 RID: 7527
	[SerializeField]
	private bool NoTrap;

	// Token: 0x04001D68 RID: 7528
	[SerializeField]
	private bool North;

	// Token: 0x04001D69 RID: 7529
	public bool Open;

	// Token: 0x04001D6A RID: 7530
	[SerializeField]
	private bool Near;

	// Token: 0x04001D6B RID: 7531
	[SerializeField]
	private float ShiftNorth = -0.1f;

	// Token: 0x04001D6C RID: 7532
	[SerializeField]
	private float ShiftSouth = 0.1f;

	// Token: 0x04001D6D RID: 7533
	[SerializeField]
	private float Rotation;

	// Token: 0x04001D6E RID: 7534
	public float TimeLimit = 2f;

	// Token: 0x04001D6F RID: 7535
	public float Timer;

	// Token: 0x04001D70 RID: 7536
	[SerializeField]
	private float TrapSwing = 12.15f;

	// Token: 0x04001D71 RID: 7537
	[SerializeField]
	private float Swing = 150f;

	// Token: 0x04001D72 RID: 7538
	[SerializeField]
	private Renderer Sign;

	// Token: 0x04001D73 RID: 7539
	[SerializeField]
	private string RoomName = string.Empty;

	// Token: 0x04001D74 RID: 7540
	[SerializeField]
	private string Facing = string.Empty;

	// Token: 0x04001D75 RID: 7541
	[SerializeField]
	private int RoomID;

	// Token: 0x04001D76 RID: 7542
	[SerializeField]
	private ClubType Club;

	// Token: 0x04001D77 RID: 7543
	[SerializeField]
	private bool DisableSelf;

	// Token: 0x04001D78 RID: 7544
	private StudentManagerScript StudentManager;

	// Token: 0x04001D79 RID: 7545
	public OcclusionPortal Portal;

	// Token: 0x04001D7A RID: 7546
	public int DoorID;

	// Token: 0x04001D7B RID: 7547
	public bool Initialized;
}
