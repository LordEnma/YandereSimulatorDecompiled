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
		Animation component = GetComponent<Animation>();
		component["f02_angryFace_00"].layer = 2;
		component.Play("f02_angryFace_00");
		component["f02_angryFace_00"].weight = 0f;
		if (!Leader && GameObject.Find("DetectionCamera") != null)
		{
			DetectionMarker = Object.Instantiate(Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
			DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
			DetectionMarker.Target = base.transform;
		}
	}

	private void Update()
	{
		if (!Angry)
		{
			if (Phase == 1)
			{
				while (Vector3.Distance(base.transform.position, Destination.position) < 1f)
				{
					if (ID == 1)
					{
						Destination.position = new Vector3(Random.Range(-61f, -71f), Destination.position.y, Random.Range(-14f, 14f));
					}
					else
					{
						Destination.position = new Vector3(Random.Range(-28f, -23f), Destination.position.y, Random.Range(-15f, -7f));
					}
				}
				GetComponent<Animation>().CrossFade(WalkAnim);
				Moving = true;
				if (Leader)
				{
					Prompt.Hide();
					Prompt.enabled = false;
					PickpocketPanel.enabled = false;
				}
				Phase++;
			}
			else if (Moving)
			{
				if (Vector3.Distance(base.transform.position, Destination.position) >= 1f)
				{
					Quaternion b = Quaternion.LookRotation(Destination.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, 1f * Time.deltaTime);
					MyController.Move(base.transform.forward * Time.deltaTime);
				}
				else
				{
					GetComponent<Animation>().CrossFade(IdleAnim);
					Moving = false;
					if (Leader)
					{
						PickpocketPanel.enabled = true;
					}
				}
			}
			else
			{
				Timer += Time.deltaTime;
				if (Leader)
				{
					TimeBar.fillAmount = 1f - Timer / GetComponent<Animation>()[IdleAnim].length;
				}
				if (Timer > GetComponent<Animation>()[IdleAnim].length)
				{
					if (Leader && Yandere.Pickpocketing && PickpocketMinigame.ID == ID)
					{
						PickpocketMinigame.Failure = true;
						PickpocketMinigame.End();
						Punish();
					}
					Timer = 0f;
					Phase = 1;
				}
			}
			if (Leader)
			{
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					Prompt.Circle[0].fillAmount = 1f;
					if (!Yandere.Chased && Yandere.Chasers == 0)
					{
						PickpocketMinigame.PickpocketSpot = PickpocketSpot;
						PickpocketMinigame.Show = true;
						PickpocketMinigame.ID = ID;
						Yandere.Character.GetComponent<Animation>().CrossFade("f02_pickpocketing_00");
						Yandere.Pickpocketing = true;
						Yandere.EmptyHands();
						Yandere.CanMove = false;
					}
				}
				if (PickpocketMinigame.ID == ID)
				{
					if (PickpocketMinigame.Success)
					{
						PickpocketMinigame.Success = false;
						PickpocketMinigame.ID = 0;
						if (ID == 1)
						{
							ShedDoor.Prompt.Label[0].text = "     Open";
							Padlock.SetActive(value: false);
							ShedDoor.Locked = false;
							Yandere.Inventory.ShedKey = true;
						}
						else
						{
							CabinetDoor.Prompt.Label[0].text = "     Open";
							CabinetDoor.Locked = false;
							Yandere.Inventory.CabinetKey = true;
						}
						Prompt.gameObject.SetActive(value: false);
						Key.SetActive(value: false);
					}
					if (PickpocketMinigame.Failure)
					{
						PickpocketMinigame.Failure = false;
						PickpocketMinigame.ID = 0;
						Punish();
					}
				}
			}
			else
			{
				LookForYandere();
			}
		}
		else
		{
			Quaternion b2 = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, 10f * Time.deltaTime);
			Timer += Time.deltaTime;
			if (Timer > 10f)
			{
				GetComponent<Animation>()["f02_angryFace_00"].weight = 0f;
				Angry = false;
				Timer = 0f;
			}
			else if (Timer > 1f && Phase == 0)
			{
				Subtitle.UpdateLabel(SubtitleType.PickpocketReaction, 0, 8f);
				Phase++;
			}
		}
		if (Leader && PickpocketPanel.enabled)
		{
			if (Yandere.PickUp == null && Yandere.Pursuer == null)
			{
				Prompt.enabled = true;
				return;
			}
			Prompt.enabled = false;
			Prompt.Hide();
		}
	}

	private void Punish()
	{
		Animation component = GetComponent<Animation>();
		component["f02_angryFace_00"].weight = 1f;
		component.CrossFade(AngryAnim);
		Reputation.PendingRep -= 10f;
		CameraEffects.Alarm();
		Angry = true;
		Phase = 0;
		Timer = 0f;
		Prompt.Hide();
		Prompt.enabled = false;
		PickpocketPanel.enabled = false;
	}

	private void LookForYandere()
	{
		float num = Vector3.Distance(base.transform.position, Yandere.transform.position);
		if (num < VisionCone.farClipPlane)
		{
			if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(VisionCone), Yandere.GetComponent<Collider>().bounds))
			{
				if (Physics.Linecast(end: new Vector3(Yandere.transform.position.x, Yandere.Head.position.y, Yandere.transform.position.z), start: Eyes.transform.position, hitInfo: out var hitInfo))
				{
					if (hitInfo.collider.gameObject == Yandere.gameObject)
					{
						if (Yandere.Pickpocketing)
						{
							if (!ClubLeader.Angry)
							{
								Alarm = Mathf.MoveTowards(Alarm, 100f, Time.deltaTime * (100f / num));
								if (Alarm == 100f)
								{
									PickpocketMinigame.NotNurse = true;
									PickpocketMinigame.End();
									ClubLeader.Punish();
								}
							}
							else
							{
								Alarm = Mathf.MoveTowards(Alarm, 0f, Time.deltaTime * 100f);
							}
						}
						else
						{
							Alarm = Mathf.MoveTowards(Alarm, 0f, Time.deltaTime * 100f);
						}
					}
					else
					{
						Alarm = Mathf.MoveTowards(Alarm, 0f, Time.deltaTime * 100f);
					}
				}
				else
				{
					Alarm = Mathf.MoveTowards(Alarm, 0f, Time.deltaTime * 100f);
				}
			}
			else
			{
				Alarm = Mathf.MoveTowards(Alarm, 0f, Time.deltaTime * 100f);
			}
		}
		DetectionMarker.Tex.transform.localScale = new Vector3(DetectionMarker.Tex.transform.localScale.x, Alarm / 100f, DetectionMarker.Tex.transform.localScale.z);
		if (Alarm > 0f)
		{
			if (!DetectionMarker.Tex.enabled)
			{
				DetectionMarker.Tex.enabled = true;
			}
			DetectionMarker.Tex.color = new Color(DetectionMarker.Tex.color.r, DetectionMarker.Tex.color.g, DetectionMarker.Tex.color.b, Alarm / 100f);
		}
		else if (DetectionMarker.Tex.color.a != 0f)
		{
			DetectionMarker.Tex.enabled = false;
			DetectionMarker.Tex.color = new Color(DetectionMarker.Tex.color.r, DetectionMarker.Tex.color.g, DetectionMarker.Tex.color.b, 0f);
		}
	}
}
