using System;
using Pathfinding;
using UnityEngine;

// Token: 0x020002D7 RID: 727
public class GardeningClubMemberScript : MonoBehaviour
{
	// Token: 0x060014C1 RID: 5313 RVA: 0x000CC878 File Offset: 0x000CAA78
	private void Start()
	{
		Animation component = base.GetComponent<Animation>();
		component["f02_angryFace_00"].layer = 2;
		component.Play("f02_angryFace_00");
		component["f02_angryFace_00"].weight = 0f;
		if (!this.Leader && GameObject.Find("DetectionCamera") != null)
		{
			this.DetectionMarker = UnityEngine.Object.Instantiate<GameObject>(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
			this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
			this.DetectionMarker.Target = base.transform;
		}
	}

	// Token: 0x060014C2 RID: 5314 RVA: 0x000CC938 File Offset: 0x000CAB38
	private void Update()
	{
		if (!this.Angry)
		{
			if (this.Phase == 1)
			{
				while (Vector3.Distance(base.transform.position, this.Destination.position) < 1f)
				{
					if (this.ID == 1)
					{
						this.Destination.position = new Vector3(UnityEngine.Random.Range(-61f, -71f), this.Destination.position.y, UnityEngine.Random.Range(-14f, 14f));
					}
					else
					{
						this.Destination.position = new Vector3(UnityEngine.Random.Range(-28f, -23f), this.Destination.position.y, UnityEngine.Random.Range(-15f, -7f));
					}
				}
				base.GetComponent<Animation>().CrossFade(this.WalkAnim);
				this.Moving = true;
				if (this.Leader)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.PickpocketPanel.enabled = false;
				}
				this.Phase++;
			}
			else if (this.Moving)
			{
				if (Vector3.Distance(base.transform.position, this.Destination.position) >= 1f)
				{
					Quaternion b = Quaternion.LookRotation(this.Destination.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, 1f * Time.deltaTime);
					this.MyController.Move(base.transform.forward * Time.deltaTime);
				}
				else
				{
					base.GetComponent<Animation>().CrossFade(this.IdleAnim);
					this.Moving = false;
					if (this.Leader)
					{
						this.PickpocketPanel.enabled = true;
					}
				}
			}
			else
			{
				this.Timer += Time.deltaTime;
				if (this.Leader)
				{
					this.TimeBar.fillAmount = 1f - this.Timer / base.GetComponent<Animation>()[this.IdleAnim].length;
				}
				if (this.Timer > base.GetComponent<Animation>()[this.IdleAnim].length)
				{
					if (this.Leader && this.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
					{
						this.PickpocketMinigame.Failure = true;
						this.PickpocketMinigame.End();
						this.Punish();
					}
					this.Timer = 0f;
					this.Phase = 1;
				}
			}
			if (this.Leader)
			{
				if (this.Prompt.Circle[0].fillAmount == 0f)
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
			{
				this.LookForYandere();
			}
		}
		else
		{
			Quaternion b2 = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, 10f * Time.deltaTime);
			this.Timer += Time.deltaTime;
			if (this.Timer > 10f)
			{
				base.GetComponent<Animation>()["f02_angryFace_00"].weight = 0f;
				this.Angry = false;
				this.Timer = 0f;
			}
			else if (this.Timer > 1f && this.Phase == 0)
			{
				this.Subtitle.UpdateLabel(SubtitleType.PickpocketReaction, 0, 8f);
				this.Phase++;
			}
		}
		if (this.Leader && this.PickpocketPanel.enabled)
		{
			if (this.Yandere.PickUp == null && this.Yandere.Pursuer == null)
			{
				this.Prompt.enabled = true;
				return;
			}
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}

	// Token: 0x060014C3 RID: 5315 RVA: 0x000CCF0C File Offset: 0x000CB10C
	private void Punish()
	{
		Animation component = base.GetComponent<Animation>();
		component["f02_angryFace_00"].weight = 1f;
		component.CrossFade(this.AngryAnim);
		this.Reputation.PendingRep -= 10f;
		this.CameraEffects.Alarm();
		this.Angry = true;
		this.Phase = 0;
		this.Timer = 0f;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.PickpocketPanel.enabled = false;
	}

	// Token: 0x060014C4 RID: 5316 RVA: 0x000CCFA0 File Offset: 0x000CB1A0
	private void LookForYandere()
	{
		float num = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
		if (num < this.VisionCone.farClipPlane)
		{
			if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(this.VisionCone), this.Yandere.GetComponent<Collider>().bounds))
			{
				Vector3 end = new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z);
				RaycastHit raycastHit;
				if (Physics.Linecast(this.Eyes.transform.position, end, out raycastHit))
				{
					if (raycastHit.collider.gameObject == this.Yandere.gameObject)
					{
						if (this.Yandere.Pickpocketing)
						{
							if (!this.ClubLeader.Angry)
							{
								this.Alarm = Mathf.MoveTowards(this.Alarm, 100f, Time.deltaTime * (100f / num));
								if (this.Alarm == 100f)
								{
									this.PickpocketMinigame.NotNurse = true;
									this.PickpocketMinigame.End();
									this.ClubLeader.Punish();
								}
							}
							else
							{
								this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
							}
						}
						else
						{
							this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
						}
					}
					else
					{
						this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
					}
				}
				else
				{
					this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
				}
			}
			else
			{
				this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
			}
		}
		this.DetectionMarker.Tex.transform.localScale = new Vector3(this.DetectionMarker.Tex.transform.localScale.x, this.Alarm / 100f, this.DetectionMarker.Tex.transform.localScale.z);
		if (this.Alarm > 0f)
		{
			if (!this.DetectionMarker.Tex.enabled)
			{
				this.DetectionMarker.Tex.enabled = true;
			}
			this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, this.Alarm / 100f);
			return;
		}
		if (this.DetectionMarker.Tex.color.a != 0f)
		{
			this.DetectionMarker.Tex.enabled = false;
			this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0f);
		}
	}

	// Token: 0x040020A3 RID: 8355
	public PickpocketMinigameScript PickpocketMinigame;

	// Token: 0x040020A4 RID: 8356
	public DetectionMarkerScript DetectionMarker;

	// Token: 0x040020A5 RID: 8357
	public CameraEffectsScript CameraEffects;

	// Token: 0x040020A6 RID: 8358
	public CharacterController MyController;

	// Token: 0x040020A7 RID: 8359
	public CabinetDoorScript CabinetDoor;

	// Token: 0x040020A8 RID: 8360
	public ReputationScript Reputation;

	// Token: 0x040020A9 RID: 8361
	public SubtitleScript Subtitle;

	// Token: 0x040020AA RID: 8362
	public YandereScript Yandere;

	// Token: 0x040020AB RID: 8363
	public PromptScript Prompt;

	// Token: 0x040020AC RID: 8364
	public DoorScript ShedDoor;

	// Token: 0x040020AD RID: 8365
	public AIPath Pathfinding;

	// Token: 0x040020AE RID: 8366
	public UIPanel PickpocketPanel;

	// Token: 0x040020AF RID: 8367
	public UISprite TimeBar;

	// Token: 0x040020B0 RID: 8368
	public Transform PickpocketSpot;

	// Token: 0x040020B1 RID: 8369
	public Transform Destination;

	// Token: 0x040020B2 RID: 8370
	public GameObject Padlock;

	// Token: 0x040020B3 RID: 8371
	public GameObject Marker;

	// Token: 0x040020B4 RID: 8372
	public GameObject Key;

	// Token: 0x040020B5 RID: 8373
	public bool Moving;

	// Token: 0x040020B6 RID: 8374
	public bool Leader;

	// Token: 0x040020B7 RID: 8375
	public bool Angry;

	// Token: 0x040020B8 RID: 8376
	public string AngryAnim = "idle_01";

	// Token: 0x040020B9 RID: 8377
	public string IdleAnim = string.Empty;

	// Token: 0x040020BA RID: 8378
	public string WalkAnim = string.Empty;

	// Token: 0x040020BB RID: 8379
	public float Timer;

	// Token: 0x040020BC RID: 8380
	public int Phase = 1;

	// Token: 0x040020BD RID: 8381
	public int ID = 1;

	// Token: 0x040020BE RID: 8382
	public GardeningClubMemberScript ClubLeader;

	// Token: 0x040020BF RID: 8383
	public Camera VisionCone;

	// Token: 0x040020C0 RID: 8384
	public Transform Eyes;

	// Token: 0x040020C1 RID: 8385
	public float Alarm;
}
