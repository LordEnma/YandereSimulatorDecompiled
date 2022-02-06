using System;
using UnityEngine;

// Token: 0x0200028C RID: 652
public class DoorScript : MonoBehaviour
{
	// Token: 0x1700034A RID: 842
	// (get) Token: 0x060013A5 RID: 5029 RVA: 0x000B8603 File Offset: 0x000B6803
	private bool Double
	{
		get
		{
			return this.Doors.Length == 2;
		}
	}

	// Token: 0x060013A6 RID: 5030 RVA: 0x000B8610 File Offset: 0x000B6810
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

	// Token: 0x060013A7 RID: 5031 RVA: 0x000B8938 File Offset: 0x000B6B38
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
			if (this.Timer >= this.TimeLimit)
			{
				this.DoorColliders[0].isTrigger = false;
				if (this.DoorColliders[1] != null)
				{
					this.DoorColliders[1].isTrigger = false;
				}
				this.Portal != null;
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

	// Token: 0x060013A8 RID: 5032 RVA: 0x000B9358 File Offset: 0x000B7558
	public void OpenDoor()
	{
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

	// Token: 0x060013A9 RID: 5033 RVA: 0x000B9497 File Offset: 0x000B7697
	private void LockDoor()
	{
		this.Open = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	// Token: 0x060013AA RID: 5034 RVA: 0x000B94B8 File Offset: 0x000B76B8
	private void CheckDirection()
	{
		this.North = false;
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
		this.Student = null;
	}

	// Token: 0x060013AB RID: 5035 RVA: 0x000B95FC File Offset: 0x000B77FC
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

	// Token: 0x060013AC RID: 5036 RVA: 0x000B96EA File Offset: 0x000B78EA
	private void UpdateLabel()
	{
		if (this.Open)
		{
			this.Prompt.Label[0].text = "     Close";
			return;
		}
		this.Prompt.Label[0].text = "     Open";
	}

	// Token: 0x060013AD RID: 5037 RVA: 0x000B9724 File Offset: 0x000B7924
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

	// Token: 0x060013AE RID: 5038 RVA: 0x000B9F88 File Offset: 0x000B8188
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

	// Token: 0x04001D1B RID: 7451
	[SerializeField]
	private Transform RelativeCharacter;

	// Token: 0x04001D1C RID: 7452
	[SerializeField]
	private YanSaveIdentifier Identifier;

	// Token: 0x04001D1D RID: 7453
	[SerializeField]
	private HideColliderScript HideCollider;

	// Token: 0x04001D1E RID: 7454
	public StudentScript Student;

	// Token: 0x04001D1F RID: 7455
	[SerializeField]
	private YandereScript Yandere;

	// Token: 0x04001D20 RID: 7456
	[SerializeField]
	private BucketScript Bucket;

	// Token: 0x04001D21 RID: 7457
	public PromptScript Prompt;

	// Token: 0x04001D22 RID: 7458
	[SerializeField]
	private Collider[] DoorColliders;

	// Token: 0x04001D23 RID: 7459
	[SerializeField]
	private float[] ClosedPositions;

	// Token: 0x04001D24 RID: 7460
	[SerializeField]
	private float[] OpenPositions;

	// Token: 0x04001D25 RID: 7461
	[SerializeField]
	private Transform[] Doors;

	// Token: 0x04001D26 RID: 7462
	[SerializeField]
	private Texture[] Plates;

	// Token: 0x04001D27 RID: 7463
	[SerializeField]
	private UILabel[] Labels;

	// Token: 0x04001D28 RID: 7464
	[SerializeField]
	private float[] OriginX;

	// Token: 0x04001D29 RID: 7465
	[SerializeField]
	private bool CanSetBucket;

	// Token: 0x04001D2A RID: 7466
	[SerializeField]
	private bool HidingSpot;

	// Token: 0x04001D2B RID: 7467
	[SerializeField]
	private bool BucketSet;

	// Token: 0x04001D2C RID: 7468
	[SerializeField]
	private bool Swinging;

	// Token: 0x04001D2D RID: 7469
	public bool Locked;

	// Token: 0x04001D2E RID: 7470
	[SerializeField]
	private bool NoTrap;

	// Token: 0x04001D2F RID: 7471
	[SerializeField]
	private bool North;

	// Token: 0x04001D30 RID: 7472
	public bool Open;

	// Token: 0x04001D31 RID: 7473
	[SerializeField]
	private bool Near;

	// Token: 0x04001D32 RID: 7474
	[SerializeField]
	private float ShiftNorth = -0.1f;

	// Token: 0x04001D33 RID: 7475
	[SerializeField]
	private float ShiftSouth = 0.1f;

	// Token: 0x04001D34 RID: 7476
	[SerializeField]
	private float Rotation;

	// Token: 0x04001D35 RID: 7477
	public float TimeLimit = 2f;

	// Token: 0x04001D36 RID: 7478
	public float Timer;

	// Token: 0x04001D37 RID: 7479
	[SerializeField]
	private float TrapSwing = 12.15f;

	// Token: 0x04001D38 RID: 7480
	[SerializeField]
	private float Swing = 150f;

	// Token: 0x04001D39 RID: 7481
	[SerializeField]
	private Renderer Sign;

	// Token: 0x04001D3A RID: 7482
	[SerializeField]
	private string RoomName = string.Empty;

	// Token: 0x04001D3B RID: 7483
	[SerializeField]
	private string Facing = string.Empty;

	// Token: 0x04001D3C RID: 7484
	[SerializeField]
	private int RoomID;

	// Token: 0x04001D3D RID: 7485
	[SerializeField]
	private ClubType Club;

	// Token: 0x04001D3E RID: 7486
	[SerializeField]
	private bool DisableSelf;

	// Token: 0x04001D3F RID: 7487
	private StudentManagerScript StudentManager;

	// Token: 0x04001D40 RID: 7488
	public OcclusionPortal Portal;

	// Token: 0x04001D41 RID: 7489
	public int DoorID;

	// Token: 0x04001D42 RID: 7490
	public bool Initialized;
}
