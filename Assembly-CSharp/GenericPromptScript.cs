using UnityEngine;

public class GenericPromptScript : MonoBehaviour
{
	public GenericPromptScript NextPrompt;

	public StudentScript CrushedStudent;

	public GenericRivalEventScript Event;

	public GameObject CrushCollider;

	public GameObject AlarmDisc;

	public GameObject Effect;

	public BoxCollider Collider;

	public GameObject[] Object;

	public Transform ObjectToRotate;

	public Transform PlayerSpot;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public Mesh NewMesh;

	public bool PerformingAction;

	public bool SpawnedEffect;

	public float TargetRotation = 90f;

	public float Rotation;

	public float Speed;

	public int ID;

	private void Start()
	{
		if ((ID == 7 && !GameGlobals.Eighties) || (ID == 7 && DateGlobals.Week != 5))
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (ID == 1)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					bool flag = false;
					if (Prompt.Yandere.Inventory.EmeticPoisons > 0)
					{
						Prompt.Yandere.Inventory.EmeticPoisons--;
						Prompt.Yandere.StudentManager.UpdateAllBentos();
						flag = true;
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					if (flag)
					{
						Prompt.Yandere.StudentManager.Students[1].MyBento.Tampered = true;
						Prompt.Yandere.StudentManager.Students[1].MyBento.Emetic = true;
						SabotageAndDisable();
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 2)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					SabotageAndDisable();
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 3)
		{
			if (Prompt.Circle[0].fillAmount == 0f || Prompt.Circle[1].fillAmount == 0f || Prompt.Circle[2].fillAmount == 0f || Prompt.Circle[3].fillAmount == 0f)
			{
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					if (Prompt.Circle[0].fillAmount == 0f)
					{
						if (Prompt.Yandere.Inventory.Sake)
						{
							Prompt.Yandere.Inventory.Sake = false;
							SabotageAndDisable();
						}
						else
						{
							Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					if (Prompt.Circle[1].fillAmount == 0f)
					{
						if (Prompt.Yandere.Inventory.Condoms)
						{
							Prompt.Yandere.Inventory.Condoms = false;
							SabotageAndDisable();
						}
						else
						{
							Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					if (Prompt.Circle[2].fillAmount == 0f)
					{
						if (Prompt.Yandere.Inventory.Cigs)
						{
							Prompt.Yandere.Inventory.Cigs = false;
							SabotageAndDisable();
						}
						else
						{
							Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					if (Prompt.Circle[3].fillAmount == 0f)
					{
						if (Prompt.Yandere.Inventory.Narcotics)
						{
							Prompt.Yandere.Inventory.Narcotics = false;
							SabotageAndDisable();
						}
						else
						{
							Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Circle[1].fillAmount = 1f;
				Prompt.Circle[2].fillAmount = 1f;
				Prompt.Circle[3].fillAmount = 1f;
			}
			if (Prompt.Yandere.StudentManager.Clock.Period > 2)
			{
				Debug.Log("Disabling Senpai's Wednesday gift box. It shouldn't be active during - or after - lunchtime.");
				base.gameObject.SetActive(value: false);
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		else if (ID == 4)
		{
			if ((Prompt.Yandere.PickUp != null && (bool)Prompt.Yandere.PickUp.Bucket && Prompt.Yandere.PickUp.Bucket.Gasoline) || (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.JerryCan))
			{
				Prompt.enabled = true;
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					Prompt.Circle[0].fillAmount = 1f;
					Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (!Prompt.Yandere.StudentManager.YandereVisible)
					{
						Prompt.Yandere.StudentManager.GasInWateringCan = true;
						MyAudio.Play();
						Prompt.enabled = false;
						Prompt.Hide();
						base.enabled = false;
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
			}
			else if (Prompt.enabled)
			{
				Prompt.enabled = false;
				Prompt.Hide();
			}
		}
		else if (ID == 5)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (Prompt.Yandere.Class.PhysicalGrade + Prompt.Yandere.Class.PhysicalBonus > 0)
				{
					Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (!Prompt.Yandere.StudentManager.YandereVisible)
					{
						Prompt.Yandere.CharacterAnimation.CrossFade("f02_dumpsterPull_00");
						Prompt.Yandere.CanMove = false;
						PerformingAction = true;
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "You're not strong enough to move this!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 6)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					if (Vector3.Distance(Prompt.Yandere.transform.position, Prompt.Yandere.Senpai.position) < 5f)
					{
						Prompt.Yandere.NotificationManager.CustomText = "Not with him nearby...";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else
					{
						Prompt.Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Prompt.Yandere.Numbness;
						Prompt.Yandere.CharacterAnimation.CrossFade("f02_bookcasePush_00");
						Prompt.Yandere.transform.position = PlayerSpot.position;
						Prompt.Yandere.transform.rotation = PlayerSpot.rotation;
						Prompt.Yandere.CanMove = false;
						PerformingAction = true;
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 7)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				StudentScript studentScript = Prompt.Yandere.StudentManager.Students[15];
				if (studentScript != null && studentScript.CurrentAction == StudentActionType.Sunbathe && studentScript.SunbathePhase == 3)
				{
					if (studentScript.Blind)
					{
						Prompt.Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Prompt.Yandere.Numbness;
						studentScript.transform.parent = base.transform.parent;
						studentScript.transform.localPosition = new Vector3(1.374146f, 0.0175f, 0.05f);
						Prompt.Yandere.MurderousActionTimer = 1f;
						PerformingAction = true;
						studentScript.enabled = false;
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "It won't work. She's not asleep.";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "Nobody is in this chair.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 8)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.Electronic)
				{
					PickUpScript pickUp = Prompt.Yandere.PickUp;
					Prompt.Yandere.EmptyHands();
					pickUp.gameObject.SetActive(value: false);
					pickUp.Prompt.enabled = false;
					pickUp.Prompt.Hide();
					Object[1].SetActive(value: true);
					Prompt.enabled = false;
					Prompt.Hide();
					base.enabled = false;
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "You're not holding a power strip.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 9)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (Prompt.Yandere.EquippedWeapon != null && Prompt.Yandere.EquippedWeapon.WeaponID == 6)
				{
					if (!Prompt.Yandere.StudentManager.YandereVisible)
					{
						base.gameObject.SetActive(value: false);
						Object[1].SetActive(value: false);
						Object[2].SetActive(value: true);
						Prompt.enabled = false;
						Prompt.Hide();
						base.enabled = false;
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "You're not holding a screwdriver.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 10)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (Prompt.Yandere.PickUp != null && (bool)Prompt.Yandere.PickUp.Bucket && Prompt.Yandere.PickUp.Bucket.Full)
				{
					Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (!Prompt.Yandere.StudentManager.YandereVisible)
					{
						Object[1].SetActive(value: true);
						Prompt.Yandere.PickUp.Bucket.Empty();
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "You're not holding a bucket of water.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (ID == 11 && Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Object[2].activeInHierarchy)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Create a puddle of water in front of the microphone.";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			if (!Object[1].activeInHierarchy)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Sabotage the power strip with a screwdriver.";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.NotificationManager.CustomText = "Plug a power strip into this machine.";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			if (Object[1].activeInHierarchy && Object[2].activeInHierarchy)
			{
				Effect.SetActive(!Effect.activeInHierarchy);
				if (Effect.activeInHierarchy)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Electricity on!";
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "Electricity off.";
				}
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		if (!PerformingAction)
		{
			return;
		}
		if (ID == 5)
		{
			Rotation = Mathf.MoveTowards(Rotation, -90f, Time.deltaTime * 36f);
			ObjectToRotate.localEulerAngles = new Vector3(0f, Rotation, 0f);
			Prompt.Yandere.transform.position = PlayerSpot.position;
			Prompt.Yandere.transform.rotation = PlayerSpot.rotation;
			if (Rotation == -90f)
			{
				NextPrompt.gameObject.SetActive(value: true);
				Prompt.Yandere.CanMove = true;
				Prompt.enabled = false;
				Prompt.Hide();
				base.enabled = false;
				PerformingAction = false;
			}
		}
		else if (ID == 6)
		{
			if (!(Prompt.Yandere.CharacterAnimation["f02_bookcasePush_00"].time > 0.5f))
			{
				return;
			}
			ObjectToRotate.transform.localPosition = Vector3.MoveTowards(ObjectToRotate.transform.localPosition, new Vector3(-0.169f, 0.17f, -0.94f), Time.deltaTime);
			if (CrushedStudent != null && !CrushedStudent.Alive && CrushedStudent.DeathType == DeathType.Weight)
			{
				if (!CrushedStudent.Male)
				{
					CrushedStudent.CharacterAnimation.Play("f02_crushed_00");
				}
				else
				{
					CrushedStudent.CharacterAnimation.Play("crushed_00");
				}
			}
			Rotation = Mathf.MoveTowards(Rotation, TargetRotation, Time.deltaTime * 360f);
			ObjectToRotate.localEulerAngles = new Vector3(Rotation, -90f, 0f);
			CrushCollider.SetActive(value: true);
			if (Rotation == TargetRotation)
			{
				GameObject obj = UnityEngine.Object.Instantiate(AlarmDisc, Prompt.Yandere.transform.position + Vector3.up, Quaternion.identity);
				obj.GetComponent<AlarmDiscScript>().NoScream = true;
				obj.transform.localScale = new Vector3(1000f, 1f, 1000f);
				MyAudio.Play();
				CrushCollider.SetActive(value: false);
				Prompt.Yandere.CanMove = true;
				Prompt.enabled = false;
				Prompt.Hide();
				base.enabled = false;
				PerformingAction = false;
				Object[0].SetActive(value: true);
				Collider.center = new Vector3(0f, 1f, 0.33333f);
				Collider.size = new Vector3(1.9f, 2f, 1f);
				if (Prompt.Yandere.StudentManager.Students[13] != null && Prompt.Yandere.StudentManager.Students[13].Alive)
				{
					Debug.Log("Updating the bookish girl's routine.");
					StudentScript studentScript2 = Prompt.Yandere.StudentManager.Students[13];
					ScheduleBlock obj2 = studentScript2.ScheduleBlocks[2];
					obj2.destination = "Hangout";
					obj2.action = "Read";
					ScheduleBlock obj3 = studentScript2.ScheduleBlocks[7];
					obj3.destination = "Hangout";
					obj3.action = "Read";
					studentScript2.GetDestinations();
					studentScript2.Pathfinding.target = studentScript2.Destinations[studentScript2.Phase];
					studentScript2.CurrentDestination = studentScript2.Destinations[studentScript2.Phase];
				}
			}
		}
		else
		{
			if (ID != 7)
			{
				return;
			}
			if (Rotation != TargetRotation)
			{
				Rotation = Mathf.MoveTowards(Rotation, TargetRotation, Time.deltaTime * 360f);
				base.transform.parent.localEulerAngles = new Vector3(0f, 0f, Rotation);
				base.transform.parent.localPosition = Vector3.MoveTowards(base.transform.parent.localPosition, new Vector3(6f, 3.75f, 3f), Time.deltaTime);
				return;
			}
			if (!SpawnedEffect)
			{
				UnityEngine.Object.Instantiate(Effect, base.transform.position, Quaternion.identity).transform.eulerAngles = new Vector3(-90f, 0f, 0f);
				Prompt.Yandere.StudentManager.Students[15].transform.parent = base.transform;
				SpawnedEffect = true;
			}
			base.transform.parent.position -= new Vector3(0f, Time.deltaTime, 0f);
			Debug.Log("Now lowering pool chair.");
			if (base.transform.parent.position.y < 0.6f)
			{
				Debug.Log("Pool chair is now lowered?");
				StudentScript obj4 = Prompt.Yandere.StudentManager.Students[15];
				obj4.Drowned = true;
				obj4.BecomeRagdoll();
				obj4.Ragdoll.Zs.SetActive(value: false);
				obj4.Ragdoll.DestroyRigidbodies();
				obj4.DeathType = DeathType.Drowning;
				obj4.CharacterAnimation.enabled = true;
				obj4.CharacterAnimation.Play("f02_sunbatheSleep_00");
				PerformingAction = false;
				Prompt.enabled = false;
				Prompt.Hide();
				base.enabled = false;
			}
		}
	}

	public void SabotageAndDisable()
	{
		Event.Sabotage();
		Prompt.enabled = false;
		Prompt.Hide();
		base.enabled = false;
	}
}
