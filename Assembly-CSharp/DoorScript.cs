// Decompiled with JetBrains decompiler
// Type: DoorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
  [SerializeField]
  private Collider[] DoorColliders;
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
  public bool Initialized;

  private bool Double => this.Doors.Length == 2;

  public void Start()
  {
    if (this.Initialized)
      return;
    this.Initialized = true;
    this.Identifier = this.GetComponent<YanSaveIdentifier>();
    this.TrapSwing = 12.15f;
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    this.StudentManager = this.Yandere.StudentManager;
    this.StudentManager.Doors[this.StudentManager.DoorID] = this;
    ++this.StudentManager.DoorID;
    this.DoorID = this.StudentManager.DoorID;
    if ((Object) this.Identifier != (Object) null)
      this.Identifier.ObjectID = "Door_" + this.DoorID.ToString();
    else
      Debug.Log((object) (this.gameObject.name + " doesn't have an identifier."));
    Bounds bounds = this.StudentManager.EastBathroomArea.bounds;
    if (!bounds.Contains(this.transform.position))
    {
      bounds = this.StudentManager.WestBathroomArea.bounds;
      if (!bounds.Contains(this.transform.position))
        goto label_7;
    }
    this.RoomName = "Toilet Stall";
label_7:
    if (this.Swinging)
    {
      this.OriginX[0] = this.Doors[0].transform.localPosition.z;
      if (this.OriginX.Length > 1)
        this.OriginX[1] = this.Doors[1].transform.localPosition.z;
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
      this.Locked = true;
      this.Prompt.Label[0].text = "     Locked";
      this.Prompt.Label[2].text = "     Pick Lock";
      this.Prompt.OffsetY[2] = 1.2f;
    }
    else
      this.Prompt.HideButton[2] = true;
    if (this.DisableSelf)
      this.enabled = false;
    this.Prompt.Student = false;
    this.Prompt.Door = true;
    this.DoorColliders = new Collider[2];
    this.DoorColliders[0] = (Collider) this.Doors[0].gameObject.GetComponent<BoxCollider>();
    if ((Object) this.DoorColliders[0] == (Object) null)
      this.DoorColliders[0] = (Collider) this.Doors[0].GetChild(0).gameObject.GetComponent<BoxCollider>();
    if (this.Doors.Length > 1)
      this.DoorColliders[1] = (Collider) this.Doors[1].GetComponent<BoxCollider>();
    if (!this.StudentManager.Eighties && this.RoomID == 22)
      this.Club = ClubType.None;
    if ((double) this.transform.position.z < 55.0 && (double) Mathf.Abs(this.transform.position.x) < 62.0)
    {
      this.GetComponent<BoxCollider>().size = new Vector3(0.2f, 0.01f, 0.2f);
    }
    else
    {
      this.GetComponent<BoxCollider>().size = new Vector3(0.2f, 0.1f, 0.2f);
      if ((double) this.transform.position.x >= -64.0)
        return;
      this.GetComponent<BoxCollider>().size = new Vector3(0.2f, 0.2f, 0.2f);
    }
  }

  private void Update()
  {
    if ((double) this.Prompt.DistanceSqr <= 1.0)
    {
      if ((double) Vector3.Distance(this.Yandere.transform.position, this.transform.position) < 2.0)
      {
        if (!this.Near)
        {
          this.TopicCheck();
          this.Yandere.Location.Label.text = this.RoomName;
          this.Yandere.Location.Show = true;
          this.Near = true;
        }
        if ((double) this.Prompt.Circle[0].fillAmount < 1.0 && (double) this.Prompt.Circle[0].fillAmount > 0.0)
        {
          this.Prompt.Circle[0].fillAmount = 0.0f;
          if (!this.Locked)
          {
            if (!this.Open)
              this.OpenDoor();
            else
              this.CloseDoor();
          }
        }
        if (this.Double && this.Swinging && (double) this.Prompt.Circle[1].fillAmount == 0.0)
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
            this.Bucket.transform.parent = this.transform;
            this.Bucket.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.Bucket.Trap = true;
            this.Bucket.Prompt.Hide();
            this.Bucket.Prompt.enabled = false;
            this.CheckDirection();
            if (this.North)
              this.Bucket.transform.localPosition = new Vector3(0.0f, 2.25f, 0.2975f);
            else
              this.Bucket.transform.localPosition = new Vector3(0.0f, 2.25f, -0.2975f);
            this.Bucket.GetComponent<Rigidbody>().isKinematic = true;
            this.Bucket.GetComponent<Rigidbody>().useGravity = false;
            if (this.Open)
            {
              this.DoorColliders[0].isTrigger = true;
              this.DoorColliders[1].isTrigger = true;
            }
            this.Prompt.Label[1].text = "     Remove Bucket";
            this.Prompt.Label[1].color = Color.white;
            this.Prompt.HideButton[0] = true;
            this.CanSetBucket = false;
            this.BucketSet = true;
            this.Open = false;
            this.Timer = 0.0f;
            this.Yandere.SuspiciousActionTimer = 1f;
            this.Yandere.CreatingBucketTrap = true;
          }
          else
          {
            this.Yandere.EmptyHands();
            this.Bucket.PickUp.BePickedUp();
            this.Prompt.HideButton[0] = false;
            this.Prompt.Label[1].text = "     Set Trap";
            this.Prompt.Label[1].color = Color.red;
            this.BucketSet = false;
            this.Bucket = (BucketScript) null;
            this.Timer = 0.0f;
          }
        }
      }
    }
    else if (this.Near)
    {
      this.Yandere.Location.Show = false;
      this.Near = false;
    }
    if ((double) this.Timer < (double) this.TimeLimit)
    {
      this.Timer += Time.deltaTime;
      if (!this.Open && (double) this.Timer >= (double) this.TimeLimit)
      {
        this.DoorColliders[0].isTrigger = false;
        if ((Object) this.DoorColliders[1] != (Object) null)
          this.DoorColliders[1].isTrigger = false;
      }
      if (this.BucketSet)
      {
        for (int index = 0; index < this.Doors.Length; ++index)
        {
          Transform door = this.Doors[index];
          door.localPosition = new Vector3(door.localPosition.x, door.localPosition.y, Mathf.Lerp(door.localPosition.z, this.OriginX[index] + (this.North ? this.ShiftSouth : this.ShiftNorth), Time.deltaTime * 3.6f));
          this.Rotation = Mathf.Lerp(this.Rotation, this.North ? -this.TrapSwing : this.TrapSwing, Time.deltaTime * 3.6f);
          door.localEulerAngles = new Vector3(door.localEulerAngles.x, index == 0 ? this.Rotation : -this.Rotation, door.localEulerAngles.z);
        }
      }
      else if (!this.Open)
      {
        for (int index = 0; index < this.Doors.Length; ++index)
        {
          Transform door = this.Doors[index];
          if (!this.Swinging)
          {
            door.localPosition = new Vector3(Mathf.Lerp(door.localPosition.x, this.ClosedPositions[index], Time.deltaTime * 3.6f), door.localPosition.y, door.localPosition.z);
          }
          else
          {
            this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 3.6f);
            door.localPosition = new Vector3(door.localPosition.x, door.localPosition.y, Mathf.Lerp(door.localPosition.z, this.OriginX[index], Time.deltaTime * 3.6f));
            door.localEulerAngles = new Vector3(door.localEulerAngles.x, index == 0 ? this.Rotation : -this.Rotation, door.localEulerAngles.z);
          }
        }
      }
      else
      {
        for (int index = 0; index < this.Doors.Length; ++index)
        {
          Transform door = this.Doors[index];
          if (!this.Swinging)
          {
            door.localPosition = new Vector3(Mathf.Lerp(door.localPosition.x, this.OpenPositions[index], Time.deltaTime * 3.6f), door.localPosition.y, door.localPosition.z);
          }
          else
          {
            door.localPosition = new Vector3(door.localPosition.x, door.localPosition.y, Mathf.Lerp(door.localPosition.z, this.OriginX[index] + (this.North ? this.ShiftNorth : this.ShiftSouth), Time.deltaTime * 3.6f));
            this.Rotation = Mathf.Lerp(this.Rotation, this.North ? this.Swing : -this.Swing, Time.deltaTime * 3.6f);
            door.localEulerAngles = new Vector3(door.localEulerAngles.x, index == 0 ? this.Rotation : -this.Rotation, door.localEulerAngles.z);
          }
        }
      }
    }
    else if (this.Locked)
    {
      if ((double) this.Prompt.Circle[0].fillAmount < 1.0)
      {
        this.Prompt.Label[0].text = "     Locked";
        this.Prompt.Circle[0].fillAmount = 1f;
      }
      if (this.Yandere.Inventory.LockPick)
      {
        this.Prompt.HideButton[2] = false;
        if ((double) this.Prompt.Circle[2].fillAmount == 0.0)
        {
          this.Prompt.Yandere.Inventory.LockPick = false;
          this.Prompt.Label[0].text = "     Open";
          this.Prompt.HideButton[2] = true;
          this.Locked = false;
        }
      }
      else if (!this.Prompt.HideButton[2])
        this.Prompt.HideButton[2] = true;
    }
    if (!this.NoTrap && this.Swinging && this.Double)
    {
      if ((Object) this.Yandere.PickUp != (Object) null)
      {
        if ((Object) this.Yandere.PickUp.Bucket != (Object) null)
        {
          if (this.Yandere.PickUp.GetComponent<BucketScript>().Full)
          {
            if ((Object) this.Bucket == (Object) null)
            {
              this.Prompt.Label[1].color = Color.red;
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
    if (!this.BucketSet || !this.Bucket.Gasoline || !((Object) this.StudentManager.Students[this.StudentManager.RivalID] != (Object) null) || this.StudentManager.Students[this.StudentManager.RivalID].GasWarned)
      return;
    StudentScript follower = this.StudentManager.Students[this.StudentManager.RivalID].Follower;
    if (!((Object) follower != (Object) null) || !follower.Alive || follower.CurrentAction != StudentActionType.Follow || (double) Vector3.Distance(this.StudentManager.Students[this.StudentManager.RivalID].transform.position, follower.transform.position) >= 10.0 || (double) Vector3.Distance(this.transform.position, this.StudentManager.Students[this.StudentManager.RivalID].transform.position) >= 10.0)
      return;
    this.Yandere.Subtitle.UpdateLabel(SubtitleType.GasWarning, 1, 5f);
    this.StudentManager.Students[this.StudentManager.RivalID].GasWarned = true;
  }

  public void OpenDoor()
  {
    this.DoorColliders[0].isTrigger = true;
    if ((Object) this.DoorColliders[1] != (Object) null)
      this.DoorColliders[1].isTrigger = true;
    if ((Object) this.Portal != (Object) null)
      this.Portal.open = true;
    this.Open = true;
    this.Timer = 0.0f;
    this.UpdateLabel();
    if (this.HidingSpot)
      Object.Destroy((Object) this.HideCollider.GetComponent<BoxCollider>());
    this.CheckDirection();
    if (this.BucketSet)
    {
      if (this.Student.WillRemoveBucket)
      {
        this.Yandere.NotificationManager.CustomText = this.Student.Name + " removed bucket trap.";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        this.Yandere.Subtitle.CustomText = "Let's set this on the ground...";
        this.Yandere.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
        this.Bucket.transform.position = this.transform.position;
        this.Student.WillRemoveBucket = false;
      }
      else
      {
        this.Bucket.GetComponent<Rigidbody>().isKinematic = false;
        this.Bucket.GetComponent<Rigidbody>().useGravity = true;
        this.Bucket.UpdateAppearance = true;
        this.Bucket.Fly = true;
      }
      this.Bucket.Prompt.enabled = true;
      this.Prompt.HideButton[0] = false;
      this.Prompt.HideButton[1] = true;
      this.Prompt.Label[1].text = "     Set Trap";
      this.Prompt.Label[1].color = Color.red;
      this.Prompt.enabled = true;
      this.BucketSet = false;
      this.Bucket = (BucketScript) null;
    }
    if (this.Swinging)
      AudioSource.PlayClipAtPoint(this.StudentManager.SwingingDoorOpen, this.transform.position);
    else
      AudioSource.PlayClipAtPoint(this.StudentManager.SlidingDoorOpen, this.transform.position);
    this.Student = (StudentScript) null;
  }

  private void LockDoor()
  {
    this.Open = false;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
  }

  private void CheckDirection()
  {
    this.North = false;
    if (this.OneWayDoor)
      return;
    this.RelativeCharacter = (Object) this.Student != (Object) null ? this.Student.transform : this.Yandere.transform;
    if (this.Facing == "North")
    {
      if ((double) this.RelativeCharacter.position.z >= (double) this.transform.position.z)
        return;
      this.North = true;
    }
    else if (this.Facing == "South")
    {
      if ((double) this.RelativeCharacter.position.z <= (double) this.transform.position.z)
        return;
      this.North = true;
    }
    else if (this.Facing == "East")
    {
      if ((double) this.RelativeCharacter.position.x >= (double) this.transform.position.x)
        return;
      this.North = true;
    }
    else
    {
      if (!(this.Facing == "West") || (double) this.RelativeCharacter.position.x <= (double) this.transform.position.x)
        return;
      this.North = true;
    }
  }

  public void CloseDoor()
  {
    this.Open = false;
    this.Timer = 0.0f;
    this.UpdateLabel();
    this.DoorColliders[0].isTrigger = true;
    if ((Object) this.DoorColliders[1] != (Object) null)
      this.DoorColliders[1].isTrigger = true;
    if (this.HidingSpot)
    {
      this.HideCollider.gameObject.AddComponent<BoxCollider>();
      BoxCollider component = this.HideCollider.GetComponent<BoxCollider>();
      component.size = new Vector3(component.size.x, component.size.y, 2f);
      component.isTrigger = true;
      this.HideCollider.MyCollider = (Collider) component;
    }
    if (this.Swinging)
      AudioSource.PlayClipAtPoint(this.StudentManager.SwingingDoorShut, this.transform.position);
    else
      AudioSource.PlayClipAtPoint(this.StudentManager.SlidingDoorShut, this.transform.position);
  }

  private void UpdateLabel()
  {
    if (this.Open)
      this.Prompt.Label[0].text = "     Close";
    else
      this.Prompt.Label[0].text = "     Open";
  }

  private void UpdatePlate()
  {
    switch (this.RoomID)
    {
      case 1:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.75f);
        break;
      case 2:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.5f);
        break;
      case 3:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.25f);
        break;
      case 4:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.0f);
        break;
      case 5:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
        break;
      case 6:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
        break;
      case 7:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
        break;
      case 8:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.0f);
        break;
      case 9:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
        break;
      case 10:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
        break;
      case 11:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
        break;
      case 12:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.0f);
        break;
      case 13:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
        break;
      case 14:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
        break;
      case 15:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
        break;
      case 16:
        this.Sign.material.mainTexture = this.Plates[1];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.0f);
        break;
      case 17:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.75f);
        break;
      case 18:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.5f);
        break;
      case 19:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.25f);
        break;
      case 20:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.0f);
        break;
      case 21:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
        break;
      case 22:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
        break;
      case 23:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
        break;
      case 24:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.0f);
        break;
      case 25:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
        break;
      case 26:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
        break;
      case 27:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
        break;
      case 28:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.0f);
        break;
      case 29:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
        break;
      case 30:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
        break;
      case 31:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
        break;
      case 32:
        this.Sign.material.mainTexture = this.Plates[2];
        this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.0f);
        break;
      case 33:
        this.Sign.material.mainTexture = this.Plates[3];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.75f);
        break;
      case 34:
        this.Sign.material.mainTexture = this.Plates[3];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.5f);
        break;
      case 40:
        this.Sign.material.mainTexture = this.Plates[3];
        this.Sign.material.mainTextureOffset = new Vector2(0.0f, 0.25f);
        break;
    }
  }

  private void TopicCheck()
  {
    if (this.RoomID > 25 && this.RoomID < 37)
      this.StudentManager.TutorialWindow.ShowClubMessage = true;
    switch (this.RoomID)
    {
      case 3:
        if (ConversationGlobals.GetTopicDiscovered(22))
          break;
        ConversationGlobals.SetTopicDiscovered(22, true);
        this.Yandere.NotificationManager.TopicName = "School";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 13:
        if (ConversationGlobals.GetTopicDiscovered(18))
          break;
        ConversationGlobals.SetTopicDiscovered(18, true);
        this.Yandere.NotificationManager.TopicName = "Reading";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 22:
        if (ConversationGlobals.GetTopicDiscovered(11))
          break;
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
        this.Yandere.NotificationManager.TopicName = this.StudentManager.Eighties ? "Jokes" : "Memes";
        this.Yandere.NotificationManager.TopicName = "Memes";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 26:
        if (ConversationGlobals.GetTopicDiscovered(1))
          break;
        ConversationGlobals.SetTopicDiscovered(1, true);
        this.Yandere.NotificationManager.TopicName = "Cooking";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 27:
        if (ConversationGlobals.GetTopicDiscovered(2))
          break;
        ConversationGlobals.SetTopicDiscovered(2, true);
        this.Yandere.NotificationManager.TopicName = "Drama";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 28:
        if (ConversationGlobals.GetTopicDiscovered(3))
          break;
        ConversationGlobals.SetTopicDiscovered(3, true);
        this.Yandere.NotificationManager.TopicName = "Occult";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 29:
        if (ConversationGlobals.GetTopicDiscovered(4))
          break;
        ConversationGlobals.SetTopicDiscovered(4, true);
        this.Yandere.NotificationManager.TopicName = "Art";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 30:
        if (ConversationGlobals.GetTopicDiscovered(5))
          break;
        ConversationGlobals.SetTopicDiscovered(5, true);
        this.Yandere.NotificationManager.TopicName = "Music";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
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
        if (ConversationGlobals.GetTopicDiscovered(17))
          break;
        ConversationGlobals.SetTopicDiscovered(17, true);
        this.Yandere.NotificationManager.TopicName = "Violence";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 32:
        if (ConversationGlobals.GetTopicDiscovered(7))
          break;
        ConversationGlobals.SetTopicDiscovered(7, true);
        this.Yandere.NotificationManager.TopicName = "Photography";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 34:
        if (ConversationGlobals.GetTopicDiscovered(8))
          break;
        ConversationGlobals.SetTopicDiscovered(8, true);
        this.Yandere.NotificationManager.TopicName = "Science";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 35:
        if (ConversationGlobals.GetTopicDiscovered(9))
          break;
        ConversationGlobals.SetTopicDiscovered(9, true);
        this.Yandere.NotificationManager.TopicName = "Sports";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
      case 36:
        if (!ConversationGlobals.GetTopicDiscovered(10))
        {
          ConversationGlobals.SetTopicDiscovered(10, true);
          this.Yandere.NotificationManager.TopicName = "Gardening";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        }
        if (ConversationGlobals.GetTopicDiscovered(24))
          break;
        ConversationGlobals.SetTopicDiscovered(24, true);
        this.Yandere.NotificationManager.TopicName = "Nature";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        break;
    }
  }
}
