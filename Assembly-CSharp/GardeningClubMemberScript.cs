// Decompiled with JetBrains decompiler
// Type: GardeningClubMemberScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using Pathfinding;
using UnityEngine;

public class GardeningClubMemberScript : MonoBehaviour
{
  public PickpocketMinigameScript PickpocketMinigame;
  public DetectionMarkerScript DetectionMarker;
  public CameraEffectsScript CameraEffects;
  public CharacterController MyController;
  public CabinetDoorScript CabinetDoor;
  public ReputationScript Reputation;
  public SubtitleScript Subtitle;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public DoorScript ShedDoor;
  public AIPath Pathfinding;
  public UIPanel PickpocketPanel;
  public UISprite TimeBar;
  public Transform PickpocketSpot;
  public Transform Destination;
  public GameObject Padlock;
  public GameObject Marker;
  public GameObject Key;
  public bool Moving;
  public bool Leader;
  public bool Angry;
  public string AngryAnim = "idle_01";
  public string IdleAnim = string.Empty;
  public string WalkAnim = string.Empty;
  public float Timer;
  public int Phase = 1;
  public int ID = 1;
  public GardeningClubMemberScript ClubLeader;
  public Camera VisionCone;
  public Transform Eyes;
  public float Alarm;

  private void Start()
  {
    Animation component = this.GetComponent<Animation>();
    component["f02_angryFace_00"].layer = 2;
    component.Play("f02_angryFace_00");
    component["f02_angryFace_00"].weight = 0.0f;
    if (this.Leader || !((Object) GameObject.Find("DetectionCamera") != (Object) null))
      return;
    this.DetectionMarker = Object.Instantiate<GameObject>(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
    this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
    this.DetectionMarker.Target = this.transform;
  }

  private void Update()
  {
    if (!this.Angry)
    {
      if (this.Phase == 1)
      {
        while ((double) Vector3.Distance(this.transform.position, this.Destination.position) < 1.0)
          this.Destination.position = this.ID != 1 ? new Vector3(Random.Range(-28f, -23f), this.Destination.position.y, Random.Range(-15f, -7f)) : new Vector3(Random.Range(-61f, -71f), this.Destination.position.y, Random.Range(-14f, 14f));
        this.GetComponent<Animation>().CrossFade(this.WalkAnim);
        this.Moving = true;
        if (this.Leader)
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          this.PickpocketPanel.enabled = false;
        }
        ++this.Phase;
      }
      else if (this.Moving)
      {
        if ((double) Vector3.Distance(this.transform.position, this.Destination.position) >= 1.0)
        {
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.Destination.transform.position - this.transform.position), 1f * Time.deltaTime);
          int num = (int) this.MyController.Move(this.transform.forward * Time.deltaTime);
        }
        else
        {
          this.GetComponent<Animation>().CrossFade(this.IdleAnim);
          this.Moving = false;
          if (this.Leader)
            this.PickpocketPanel.enabled = true;
        }
      }
      else
      {
        this.Timer += Time.deltaTime;
        if (this.Leader)
          this.TimeBar.fillAmount = (float) (1.0 - (double) this.Timer / (double) this.GetComponent<Animation>()[this.IdleAnim].length);
        if ((double) this.Timer > (double) this.GetComponent<Animation>()[this.IdleAnim].length)
        {
          if (this.Leader && this.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
          {
            this.PickpocketMinigame.Failure = true;
            this.PickpocketMinigame.End();
            this.Punish();
          }
          this.Timer = 0.0f;
          this.Phase = 1;
        }
      }
      if (this.Leader)
      {
        if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
        {
          this.Prompt.Circle[0].fillAmount = 1f;
          if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
          {
            this.PickpocketMinigame.PickpocketSpot = this.PickpocketSpot;
            this.PickpocketMinigame.Show = true;
            this.PickpocketMinigame.ID = this.ID;
            this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_pickpocketing_00");
            this.Yandere.Pickpocketing = true;
            this.Yandere.EmptyHands();
            this.Yandere.CanMove = false;
          }
        }
        if (this.PickpocketMinigame.ID == this.ID)
        {
          if (this.PickpocketMinigame.Success)
          {
            this.PickpocketMinigame.Success = false;
            this.PickpocketMinigame.ID = 0;
            if (this.ID == 1)
            {
              this.ShedDoor.Prompt.Label[0].text = "     Open";
              this.Padlock.SetActive(false);
              this.ShedDoor.Locked = false;
              this.Yandere.Inventory.ShedKey = true;
            }
            else
            {
              this.CabinetDoor.Prompt.Label[0].text = "     Open";
              this.CabinetDoor.Locked = false;
              this.Yandere.Inventory.CabinetKey = true;
            }
            this.Prompt.gameObject.SetActive(false);
            this.Key.SetActive(false);
          }
          if (this.PickpocketMinigame.Failure)
          {
            this.PickpocketMinigame.Failure = false;
            this.PickpocketMinigame.ID = 0;
            this.Punish();
          }
        }
      }
      else
        this.LookForYandere();
    }
    else
    {
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position), 10f * Time.deltaTime);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 10.0)
      {
        this.GetComponent<Animation>()["f02_angryFace_00"].weight = 0.0f;
        this.Angry = false;
        this.Timer = 0.0f;
      }
      else if ((double) this.Timer > 1.0 && this.Phase == 0)
      {
        this.Subtitle.UpdateLabel(SubtitleType.PickpocketReaction, 0, 8f);
        ++this.Phase;
      }
    }
    if (!this.Leader || !this.PickpocketPanel.enabled)
      return;
    if ((Object) this.Yandere.PickUp == (Object) null && (Object) this.Yandere.Pursuer == (Object) null)
    {
      this.Prompt.enabled = true;
    }
    else
    {
      this.Prompt.enabled = false;
      this.Prompt.Hide();
    }
  }

  private void Punish()
  {
    Animation component = this.GetComponent<Animation>();
    component["f02_angryFace_00"].weight = 1f;
    component.CrossFade(this.AngryAnim);
    this.Reputation.PendingRep -= 10f;
    this.CameraEffects.Alarm();
    this.Angry = true;
    this.Phase = 0;
    this.Timer = 0.0f;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.PickpocketPanel.enabled = false;
  }

  private void LookForYandere()
  {
    float num = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
    if ((double) num < (double) this.VisionCone.farClipPlane)
    {
      if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(this.VisionCone), this.Yandere.GetComponent<Collider>().bounds))
      {
        RaycastHit hitInfo;
        if (Physics.Linecast(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), out hitInfo))
        {
          if ((Object) hitInfo.collider.gameObject == (Object) this.Yandere.gameObject)
          {
            if (this.Yandere.Pickpocketing)
            {
              if (!this.ClubLeader.Angry)
              {
                this.Alarm = Mathf.MoveTowards(this.Alarm, 100f, Time.deltaTime * (100f / num));
                if ((double) this.Alarm == 100.0)
                {
                  this.PickpocketMinigame.NotNurse = true;
                  this.PickpocketMinigame.End();
                  this.ClubLeader.Punish();
                }
              }
              else
                this.Alarm = Mathf.MoveTowards(this.Alarm, 0.0f, Time.deltaTime * 100f);
            }
            else
              this.Alarm = Mathf.MoveTowards(this.Alarm, 0.0f, Time.deltaTime * 100f);
          }
          else
            this.Alarm = Mathf.MoveTowards(this.Alarm, 0.0f, Time.deltaTime * 100f);
        }
        else
          this.Alarm = Mathf.MoveTowards(this.Alarm, 0.0f, Time.deltaTime * 100f);
      }
      else
        this.Alarm = Mathf.MoveTowards(this.Alarm, 0.0f, Time.deltaTime * 100f);
    }
    this.DetectionMarker.Tex.transform.localScale = new Vector3(this.DetectionMarker.Tex.transform.localScale.x, this.Alarm / 100f, this.DetectionMarker.Tex.transform.localScale.z);
    if ((double) this.Alarm > 0.0)
    {
      if (!this.DetectionMarker.Tex.enabled)
        this.DetectionMarker.Tex.enabled = true;
      this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, this.Alarm / 100f);
    }
    else
    {
      if ((double) this.DetectionMarker.Tex.color.a == 0.0)
        return;
      this.DetectionMarker.Tex.enabled = false;
      this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0.0f);
    }
  }
}
