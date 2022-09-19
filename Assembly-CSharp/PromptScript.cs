// Decompiled with JetBrains decompiler
// Type: PromptScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    if ((Object) this.MyStudent == (Object) null)
    {
      this.MinimumDistanceSqr = this.MinimumDistance * this.MinimumDistance;
      this.MaximumDistanceSqr = this.MaximumDistance * this.MaximumDistance;
    }
    else
    {
      this.MinimumDistanceSqr = this.MinimumDistance;
      this.MaximumDistanceSqr = this.MaximumDistance;
    }
    this.CurrentPosition = this.transform.position;
    this.DistanceSqr = float.PositiveInfinity;
    this.OwnerType = this.DecideOwnerType();
    if ((Object) this.RaycastTarget == (Object) null)
      this.RaycastTarget = this.transform;
    if (this.OffsetZ.Length == 0)
      this.OffsetZ = new float[4];
    if ((Object) this.Yandere == (Object) null)
    {
      this.YandereObject = GameObject.Find("YandereChan");
      if ((Object) this.YandereObject != (Object) null)
        this.Yandere = this.YandereObject.GetComponent<YandereScript>();
    }
    if (!((Object) this.Yandere != (Object) null))
      return;
    this.PromptParent = this.Yandere.PromptParent;
    if ((Object) this.PromptParent == (Object) null)
    {
      this.enabled = false;
    }
    else
    {
      this.PauseScreen = this.Yandere.PauseScreen;
      this.UICamera = this.Yandere.UICamera;
      this.MainCamera = this.Yandere.MainCamera;
      if (this.Noisy)
      {
        this.Speaker = Object.Instantiate<GameObject>(this.SpeakerObject, this.CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
        this.Speaker.transform.parent = this.PromptParent.transform;
        this.Speaker.transform.localScale = new Vector3(1f, 1f, 1f);
        this.Speaker.transform.localEulerAngles = Vector3.zero;
        this.Speaker.enabled = false;
      }
      this.Square = Object.Instantiate<GameObject>(this.PromptParent.SquareObject, this.CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
      this.Square.transform.parent = this.PromptParent.transform;
      this.Square.transform.localScale = new Vector3(1f, 1f, 1f);
      this.Square.transform.localEulerAngles = Vector3.zero;
      this.Square.applyGradient = true;
      this.Square.gradientTop = new Color(1f, 1f, 1f, 1f);
      this.Square.gradientBottom = new Color(1f, 0.75f, 1f, 1f);
      this.Square.color = new Color(1f, 1f, 1f, 0.0f);
      this.Square.color = this.Square.color with
      {
        a = 0.0f
      };
      this.Square.enabled = false;
      for (this.ID = 0; this.ID < 4; ++this.ID)
      {
        if (this.ButtonActive[this.ID])
        {
          this.Button[this.ID] = Object.Instantiate<GameObject>(this.ButtonObject[this.ID], this.CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
          UISprite uiSprite1 = this.Button[this.ID];
          uiSprite1.transform.parent = this.PromptParent.transform;
          uiSprite1.transform.localScale = new Vector3(1f, 1f, 1f);
          uiSprite1.transform.localEulerAngles = Vector3.zero;
          uiSprite1.color = new Color(uiSprite1.color.r, uiSprite1.color.g, uiSprite1.color.b, 0.0f);
          uiSprite1.enabled = false;
          this.Circle[this.ID] = Object.Instantiate<GameObject>(this.CircleObject, this.CurrentPosition, Quaternion.identity).GetComponent<UISprite>();
          UISprite uiSprite2 = this.Circle[this.ID];
          uiSprite2.transform.parent = this.Button[this.ID].transform;
          uiSprite2.transform.localScale = new Vector3(1f, 1f, 1f);
          uiSprite2.transform.localEulerAngles = Vector3.zero;
          uiSprite2.transform.localPosition = Vector3.zero;
          uiSprite2.color = new Color(uiSprite2.color.r, uiSprite2.color.g, uiSprite2.color.b, 0.0f);
          uiSprite2.enabled = false;
          this.Label[this.ID] = Object.Instantiate<GameObject>(this.LabelObject, this.CurrentPosition, Quaternion.identity).GetComponent<UILabel>();
          UILabel uiLabel = this.Label[this.ID];
          uiLabel.transform.parent = this.Button[this.ID].transform;
          uiLabel.transform.localScale = new Vector3(1f, 1f, 1f);
          uiLabel.transform.localEulerAngles = Vector3.zero;
          uiLabel.transform.localPosition = Vector3.zero;
          uiLabel.color = new Color(uiLabel.color.r, uiLabel.color.g, uiLabel.color.b, 0.0f);
          uiLabel.enabled = false;
          if (this.Suspicious)
          {
            uiLabel.color = new Color(1f, 0.0f, 0.0f, 0.0f);
          }
          else
          {
            uiLabel.applyGradient = true;
            uiLabel.gradientTop = new Color(1f, 1f, 1f, 1f);
            uiLabel.gradientBottom = new Color(1f, 0.75f, 1f, 1f);
            uiLabel.color = new Color(1f, 1f, 1f, 0.0f);
          }
          uiLabel.text = "     " + this.Text[this.ID];
        }
        this.AcceptingInput[this.ID] = true;
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
      }
      else
      {
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
  }

  private void Start()
  {
    if (!this.DisableAtStart)
      return;
    this.Hide();
    this.enabled = false;
  }

  private PromptOwnerType DecideOwnerType() => (Object) this.GetComponent<DoorScript>() != (Object) null ? PromptOwnerType.Door : PromptOwnerType.Unknown;

  private bool AllowedWhenCrouching(PromptOwnerType ownerType) => ownerType == PromptOwnerType.Door;

  private bool AllowedWhenCrawling(PromptOwnerType ownerType) => false;

  private void Update()
  {
    if ((Object) this.PauseScreen == (Object) null)
    {
      Debug.Log((object) ("My name is " + this.name + " and I am a prompt that is disabling itself because my PauseScreen reference is null."));
      this.enabled = false;
      this.Hide();
    }
    else if (!this.PauseScreen.Show)
    {
      if (this.InView)
      {
        this.CurrentPosition = this.transform.position;
        this.DistanceSqr = !((Object) this.MyStudent == (Object) null) ? this.MyStudent.DistanceToPlayer : (new Vector3(this.CurrentPosition.x, this.Yandere.transform.position.y, this.CurrentPosition.z) - this.Yandere.transform.position).sqrMagnitude;
        if ((double) this.DistanceSqr < (double) this.MaximumDistanceSqr)
        {
          this.NoCheck = true;
          bool flag1 = this.Yandere.Stance.Current == StanceType.Crouching;
          bool flag2 = this.Yandere.Stance.Current == StanceType.Crawling;
          if (this.Yandere.CanMove && (!flag1 || this.AllowedWhenCrouching(this.OwnerType)) && (!flag2 || this.AllowedWhenCrawling(this.OwnerType)) && !this.Yandere.Aiming && !this.Yandere.Mopping && !this.Yandere.NearSenpai)
          {
            this.InSight = false;
            RaycastHit hitInfo;
            if (Physics.Linecast(this.Yandere.Eyes.position + Vector3.down * this.Height, this.RaycastTarget.position, out hitInfo, this.BloodMask))
              this.InSight = (Object) hitInfo.collider == (Object) this.MyCollider;
            if (this.Carried || this.InSight)
            {
              this.SquareSet = false;
              this.Hidden = false;
              Vector2 vector2 = Vector2.zero;
              for (this.ID = 0; this.ID < 4; ++this.ID)
              {
                if (this.ButtonActive[this.ID])
                {
                  if (!this.Button[this.ID].gameObject.activeInHierarchy)
                    this.Button[this.ID].gameObject.SetActive(true);
                  if ((double) Vector3.Angle(this.Yandere.MainCamera.transform.forward, this.Yandere.MainCamera.transform.position - this.CurrentPosition) > 90.0)
                  {
                    if (this.Local)
                    {
                      Vector2 screenPoint = (Vector2) this.MainCamera.WorldToScreenPoint(this.CurrentPosition + this.transform.right * this.OffsetX[this.ID] + this.transform.up * this.OffsetY[this.ID] + this.transform.forward * this.OffsetZ[this.ID]);
                      this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, 1f));
                      if (!this.SquareSet)
                      {
                        this.Square.transform.position = this.Button[this.ID].transform.position;
                        this.SquareSet = true;
                      }
                      this.RelativePosition = screenPoint.x;
                    }
                    else
                    {
                      vector2 = (Vector2) this.MainCamera.WorldToScreenPoint(this.CurrentPosition + new Vector3(this.OffsetX[this.ID], this.OffsetY[this.ID], this.OffsetZ[this.ID]));
                      this.Button[this.ID].transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y, 1f));
                      if (!this.SquareSet)
                      {
                        this.Square.transform.position = this.Button[this.ID].transform.position;
                        this.SquareSet = true;
                      }
                      this.RelativePosition = vector2.x;
                    }
                    if (!this.HideButton[this.ID])
                    {
                      this.Square.enabled = true;
                      this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
                    }
                  }
                }
              }
              if (this.Noisy)
                this.Speaker.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(vector2.x, vector2.y + 40f, 1f));
              if ((double) this.DistanceSqr < (double) this.MinimumDistanceSqr)
              {
                if ((Object) this.Yandere.NearestPrompt == (Object) null)
                  this.Yandere.NearestPrompt = this;
                else if ((double) Mathf.Abs(this.RelativePosition - (float) Screen.width * 0.5f) < (double) Mathf.Abs(this.Yandere.NearestPrompt.RelativePosition - (float) Screen.width * 0.5f))
                  this.Yandere.NearestPrompt = this;
                if ((Object) this.Yandere.NearestPrompt == (Object) this)
                {
                  this.Square.enabled = false;
                  this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 0.0f);
                  for (this.ID = 0; this.ID < 4; ++this.ID)
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
                      this.Label[this.ID].color = this.Label[this.ID].color with
                      {
                        a = 1f
                      };
                      if ((Object) this.Speaker != (Object) null)
                      {
                        this.Speaker.enabled = true;
                        this.Speaker.color = this.Speaker.color with
                        {
                          a = 1f
                        };
                      }
                    }
                  }
                  this.ButtonHeld = !Input.GetButton("A") ? (!Input.GetButton("B") ? (!Input.GetButton("X") ? (!Input.GetButton("Y") ? 0 : 4) : 3) : 2) : 1;
                  if (this.ButtonHeld > 0)
                  {
                    for (this.ID = 0; this.ID < 4; ++this.ID)
                    {
                      if ((this.ButtonActive[this.ID] && this.ID != this.ButtonHeld - 1 || this.HideButton[this.ID]) && (Object) this.Circle[this.ID] != (Object) null)
                        this.Circle[this.ID].fillAmount = 1f;
                    }
                    if (this.ButtonActive[this.ButtonHeld - 1] && !this.HideButton[this.ButtonHeld - 1] && this.AcceptingInput[this.ButtonHeld - 1] && !this.Yandere.Attacking)
                    {
                      this.Circle[this.ButtonHeld - 1].color = new Color(1f, 1f, 1f, 1f);
                      if (!this.Attack)
                        this.Circle[this.ButtonHeld - 1].fillAmount -= Time.deltaTime * 2f;
                      else
                        this.Circle[this.ButtonHeld - 1].fillAmount = 0.0f;
                      this.ID = 0;
                    }
                  }
                  else
                  {
                    for (this.ID = 0; this.ID < 4; ++this.ID)
                    {
                      if (this.ButtonActive[this.ID])
                        this.Circle[this.ID].fillAmount = 1f;
                    }
                  }
                }
                else
                {
                  this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
                  for (this.ID = 0; this.ID < 4; ++this.ID)
                  {
                    if (this.ButtonActive[this.ID])
                    {
                      UISprite uiSprite1 = this.Button[this.ID];
                      UISprite uiSprite2 = this.Circle[this.ID];
                      UILabel uiLabel = this.Label[this.ID];
                      uiSprite1.enabled = false;
                      uiSprite2.enabled = false;
                      uiLabel.enabled = false;
                      Color color1 = uiSprite1.color;
                      Color color2 = uiSprite2.color;
                      Color color3 = uiLabel.color;
                      color1.a = 0.0f;
                      color2.a = 0.0f;
                      color3.a = 0.0f;
                      uiSprite1.color = color1;
                      uiSprite2.color = color2;
                      uiLabel.color = color3;
                    }
                  }
                  if ((Object) this.Speaker != (Object) null)
                  {
                    this.Speaker.enabled = false;
                    this.Speaker.color = this.Speaker.color with
                    {
                      a = 0.0f
                    };
                  }
                }
              }
              else
              {
                if ((Object) this.Yandere.NearestPrompt == (Object) this)
                  this.Yandere.NearestPrompt = (PromptScript) null;
                this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 1f);
                for (this.ID = 0; this.ID < 4; ++this.ID)
                {
                  if (this.ButtonActive[this.ID])
                  {
                    UISprite uiSprite3 = this.Button[this.ID];
                    UISprite uiSprite4 = this.Circle[this.ID];
                    UILabel uiLabel = this.Label[this.ID];
                    uiSprite4.fillAmount = 1f;
                    uiSprite3.enabled = false;
                    uiSprite4.enabled = false;
                    uiLabel.enabled = false;
                    Color color4 = uiSprite3.color;
                    Color color5 = uiSprite4.color;
                    Color color6 = uiLabel.color;
                    color4.a = 0.0f;
                    color5.a = 0.0f;
                    color6.a = 0.0f;
                    uiSprite3.color = color4;
                    uiSprite4.color = color5;
                    uiLabel.color = color6;
                  }
                }
                if ((Object) this.Speaker != (Object) null)
                {
                  this.Speaker.enabled = false;
                  this.Speaker.color = this.Speaker.color with
                  {
                    a = 0.0f
                  };
                }
              }
              this.Square.color = this.Square.color with
              {
                a = 1f
              };
              for (this.ID = 0; this.ID < 4; ++this.ID)
              {
                if (this.ButtonActive[this.ID] && this.HideButton[this.ID])
                {
                  UISprite uiSprite5 = this.Button[this.ID];
                  UISprite uiSprite6 = this.Circle[this.ID];
                  UILabel uiLabel = this.Label[this.ID];
                  uiSprite5.enabled = false;
                  uiSprite6.enabled = false;
                  uiLabel.enabled = false;
                  Color color7 = uiSprite5.color;
                  Color color8 = uiSprite6.color;
                  Color color9 = uiLabel.color;
                  color7.a = 0.0f;
                  color8.a = 0.0f;
                  color9.a = 0.0f;
                  uiSprite5.color = color7;
                  uiSprite6.color = color8;
                  uiLabel.color = color9;
                  if ((Object) this.Speaker != (Object) null)
                  {
                    this.Speaker.enabled = false;
                    this.Speaker.color = this.Speaker.color with
                    {
                      a = 0.0f
                    };
                  }
                }
              }
            }
            else
              this.Hide();
          }
          else
            this.Hide();
        }
        else
          this.Hide();
      }
      else
      {
        this.DistanceSqr = float.PositiveInfinity;
        this.Hide();
      }
    }
    else
      this.Hide();
  }

  private void OnBecameVisible() => this.InView = true;

  private void OnBecameInvisible()
  {
    this.InView = false;
    this.Hide();
  }

  public void Hide()
  {
    if (this.Hidden)
      return;
    this.NoCheck = false;
    this.Hidden = true;
    if (!((Object) this.Yandere != (Object) null))
      return;
    if ((Object) this.Yandere.NearestPrompt == (Object) this)
      this.Yandere.NearestPrompt = (PromptScript) null;
    if ((Object) this.Square == (Object) null)
    {
      Debug.Log((object) ("An object named " + this.gameObject.name + " doesn't have a ''Square'' Sprite. The object's root is " + this.transform.root.gameObject.name));
    }
    else
    {
      if (this.Square.enabled)
      {
        this.Square.enabled = false;
        this.Square.color = new Color(this.Square.color.r, this.Square.color.g, this.Square.color.b, 0.0f);
      }
      for (this.ID = 0; this.ID < 4; ++this.ID)
      {
        if (this.ButtonActive[this.ID])
        {
          UISprite uiSprite1 = this.Button[this.ID];
          if (uiSprite1.enabled)
          {
            UISprite uiSprite2 = this.Circle[this.ID];
            UILabel uiLabel = this.Label[this.ID];
            uiSprite2.fillAmount = 1f;
            uiSprite1.enabled = false;
            uiSprite2.enabled = false;
            uiLabel.enabled = false;
            uiSprite1.color = new Color(uiSprite1.color.r, uiSprite1.color.g, uiSprite1.color.b, 0.0f);
            uiSprite2.color = new Color(uiSprite2.color.r, uiSprite2.color.g, uiSprite2.color.b, 0.0f);
            uiLabel.color = new Color(uiLabel.color.r, uiLabel.color.g, uiLabel.color.b, 0.0f);
          }
        }
        if ((Object) this.Button[this.ID] != (Object) null)
          this.Button[this.ID].gameObject.SetActive(false);
      }
      if (!((Object) this.Speaker != (Object) null))
        return;
      this.Speaker.enabled = false;
      this.Speaker.color = new Color(this.Speaker.color.r, this.Speaker.color.g, this.Speaker.color.b, 0.0f);
    }
  }
}
