using System;
using UnityEngine;

// Token: 0x020002DB RID: 731
public class GenericPromptScript : MonoBehaviour
{
	// Token: 0x060014CD RID: 5325 RVA: 0x000CD94C File Offset: 0x000CBB4C
	private void Update()
	{
		if (this.ID == 1)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!this.Prompt.Yandere.StudentManager.YandereVisible)
				{
					bool flag = false;
					if (this.Prompt.Yandere.Inventory.EmeticPoison)
					{
						this.Prompt.Yandere.Inventory.EmeticPoison = false;
						flag = true;
					}
					else if (this.Prompt.Yandere.Inventory.RatPoison)
					{
						this.Prompt.Yandere.Inventory.RatPoison = false;
						flag = true;
					}
					else
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					if (flag)
					{
						this.Prompt.Yandere.StudentManager.Students[1].MyBento.Tampered = true;
						this.Prompt.Yandere.StudentManager.Students[1].MyBento.Emetic = true;
						this.SabotageAndDisable();
					}
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (this.ID == 2)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!this.Prompt.Yandere.StudentManager.YandereVisible)
				{
					this.SabotageAndDisable();
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (this.ID == 3)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f || this.Prompt.Circle[1].fillAmount == 0f || this.Prompt.Circle[2].fillAmount == 0f || this.Prompt.Circle[3].fillAmount == 0f)
			{
				this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!this.Prompt.Yandere.StudentManager.YandereVisible)
				{
					if (this.Prompt.Circle[0].fillAmount == 0f)
					{
						if (this.Prompt.Yandere.Inventory.Sake)
						{
							this.Prompt.Yandere.Inventory.Sake = false;
							this.SabotageAndDisable();
						}
						else
						{
							this.Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					if (this.Prompt.Circle[1].fillAmount == 0f)
					{
						if (this.Prompt.Yandere.Inventory.Condoms)
						{
							this.Prompt.Yandere.Inventory.Condoms = false;
							this.SabotageAndDisable();
						}
						else
						{
							this.Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					if (this.Prompt.Circle[2].fillAmount == 0f)
					{
						if (this.Prompt.Yandere.Inventory.Cigs)
						{
							this.Prompt.Yandere.Inventory.Cigs = false;
							this.SabotageAndDisable();
						}
						else
						{
							this.Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					if (this.Prompt.Circle[3].fillAmount == 0f)
					{
						if (this.Prompt.Yandere.Inventory.Narcotics)
						{
							this.Prompt.Yandere.Inventory.Narcotics = false;
							this.SabotageAndDisable();
						}
						else
						{
							this.Prompt.Yandere.NotificationManager.CustomText = "You don't have the required item!";
							this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Circle[1].fillAmount = 1f;
				this.Prompt.Circle[2].fillAmount = 1f;
				this.Prompt.Circle[3].fillAmount = 1f;
			}
		}
		else if (this.ID == 4)
		{
			if ((this.Prompt.Yandere.PickUp != null && this.Prompt.Yandere.PickUp.Bucket && this.Prompt.Yandere.PickUp.Bucket.Gasoline) || (this.Prompt.Yandere.PickUp != null && this.Prompt.Yandere.PickUp.JerryCan))
			{
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (!this.Prompt.Yandere.StudentManager.YandereVisible)
					{
						this.Prompt.Yandere.StudentManager.GasInWateringCan = true;
						this.MyAudio.Play();
						this.Prompt.enabled = false;
						this.Prompt.Hide();
						base.enabled = false;
					}
					else
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.enabled = false;
				this.Prompt.Hide();
			}
		}
		else if (this.ID == 5)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.Prompt.Yandere.Class.PhysicalGrade + this.Prompt.Yandere.Class.PhysicalBonus > 0)
				{
					this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (!this.Prompt.Yandere.StudentManager.YandereVisible)
					{
						this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_dumpsterPull_00");
						this.Prompt.Yandere.CanMove = false;
						this.PerformingAction = true;
					}
					else
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "You're not strong enough to move this!";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (this.ID == 6)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!this.Prompt.Yandere.StudentManager.YandereVisible)
				{
					if (Vector3.Distance(this.Prompt.Yandere.transform.position, this.Prompt.Yandere.Senpai.position) < 5f)
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "Not with him nearby...";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else
					{
						this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_bookcasePush_00");
						this.Prompt.Yandere.transform.position = this.PlayerSpot.position;
						this.Prompt.Yandere.transform.rotation = this.PlayerSpot.rotation;
						this.Prompt.Yandere.CanMove = false;
						this.PerformingAction = true;
					}
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (this.ID == 7)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				StudentScript studentScript = this.Prompt.Yandere.StudentManager.Students[15];
				if (studentScript != null && studentScript.CurrentAction == StudentActionType.Sunbathe && studentScript.SunbathePhase == 3)
				{
					if (studentScript.Blind)
					{
						this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
						if (!this.Prompt.Yandere.StudentManager.YandereVisible)
						{
							studentScript.transform.parent = base.transform.parent;
							studentScript.transform.localPosition = new Vector3(1.374146f, 0.0175f, 0.05f);
							this.PerformingAction = true;
							studentScript.enabled = false;
						}
						else
						{
							this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
							this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
					else
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "It won't work. She's not asleep.";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "Nobody is in this chair.";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (this.ID == 8)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.Prompt.Yandere.PickUp != null && this.Prompt.Yandere.PickUp.Electronic)
				{
					PickUpScript pickUp = this.Prompt.Yandere.PickUp;
					this.Prompt.Yandere.EmptyHands();
					pickUp.gameObject.SetActive(false);
					pickUp.Prompt.enabled = false;
					pickUp.Prompt.Hide();
					this.Object[1].SetActive(true);
					this.Prompt.enabled = false;
					this.Prompt.Hide();
					base.enabled = false;
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "You're not holding a power strip.";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (this.ID == 9)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.Prompt.Yandere.EquippedWeapon != null && this.Prompt.Yandere.EquippedWeapon.WeaponID == 6)
				{
					if (!this.Prompt.Yandere.StudentManager.YandereVisible)
					{
						base.gameObject.SetActive(false);
						this.Object[1].SetActive(false);
						this.Object[2].SetActive(true);
						this.Prompt.enabled = false;
						this.Prompt.Hide();
						base.enabled = false;
					}
					else
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "You're not holding a screwdriver.";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (this.ID == 10)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.Prompt.Yandere.PickUp != null && this.Prompt.Yandere.PickUp.Bucket && this.Prompt.Yandere.PickUp.Bucket.Full)
				{
					this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (!this.Prompt.Yandere.StudentManager.YandereVisible)
					{
						this.Object[1].SetActive(true);
						this.Prompt.Yandere.PickUp.Bucket.Empty();
					}
					else
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "You're not holding a bucket of water.";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (this.ID == 11 && this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Object[1].activeInHierarchy && this.Object[2].activeInHierarchy)
			{
				this.Effect.SetActive(!this.Effect.activeInHierarchy);
			}
		}
		if (this.PerformingAction)
		{
			if (this.ID == 5)
			{
				this.Rotation = Mathf.MoveTowards(this.Rotation, -90f, Time.deltaTime * 36f);
				this.ObjectToRotate.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
				this.Prompt.Yandere.transform.position = this.PlayerSpot.position;
				this.Prompt.Yandere.transform.rotation = this.PlayerSpot.rotation;
				if (this.Rotation == -90f)
				{
					this.NextPrompt.gameObject.SetActive(true);
					this.Prompt.Yandere.CanMove = true;
					this.Prompt.enabled = false;
					this.Prompt.Hide();
					base.enabled = false;
					this.PerformingAction = false;
					return;
				}
			}
			else if (this.ID == 6)
			{
				if (this.Prompt.Yandere.CharacterAnimation["f02_bookcasePush_00"].time > 0.5f)
				{
					this.ObjectToRotate.transform.localPosition = Vector3.MoveTowards(this.ObjectToRotate.transform.localPosition, new Vector3(-0.169f, 0.17f, -0.94f), Time.deltaTime);
					if (this.CrushedStudent != null && !this.CrushedStudent.Alive && this.CrushedStudent.DeathType == DeathType.Weight)
					{
						if (!this.CrushedStudent.Male)
						{
							this.CrushedStudent.CharacterAnimation.Play("f02_crushed_00");
						}
						else
						{
							this.CrushedStudent.CharacterAnimation.Play("crushed_00");
						}
					}
					this.Rotation = Mathf.MoveTowards(this.Rotation, this.TargetRotation, Time.deltaTime * 360f);
					this.ObjectToRotate.localEulerAngles = new Vector3(this.Rotation, -90f, 0f);
					this.CrushCollider.SetActive(true);
					if (this.Rotation == this.TargetRotation)
					{
						this.MyAudio.Play();
						this.CrushCollider.SetActive(false);
						this.Prompt.Yandere.CanMove = true;
						this.Prompt.enabled = false;
						this.Prompt.Hide();
						base.enabled = false;
						this.PerformingAction = false;
						this.Object[0].SetActive(true);
						if (this.Prompt.Yandere.StudentManager.Students[13] != null && this.Prompt.Yandere.StudentManager.Students[13].Alive)
						{
							Debug.Log("Updating the bookish girl's routine.");
							StudentScript studentScript2 = this.Prompt.Yandere.StudentManager.Students[13];
							ScheduleBlock scheduleBlock = studentScript2.ScheduleBlocks[2];
							scheduleBlock.destination = "Hangout";
							scheduleBlock.action = "Read";
							ScheduleBlock scheduleBlock2 = studentScript2.ScheduleBlocks[7];
							scheduleBlock2.destination = "Hangout";
							scheduleBlock2.action = "Read";
							studentScript2.GetDestinations();
							studentScript2.Pathfinding.target = studentScript2.Destinations[studentScript2.Phase];
							studentScript2.CurrentDestination = studentScript2.Destinations[studentScript2.Phase];
							return;
						}
					}
				}
			}
			else if (this.ID == 7)
			{
				this.Rotation = Mathf.MoveTowards(this.Rotation, this.TargetRotation, Time.deltaTime * 360f);
				base.transform.parent.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
				base.transform.parent.localPosition = Vector3.MoveTowards(base.transform.parent.localPosition, new Vector3(6f, 3.75f, 2f), Time.deltaTime);
				if (this.Rotation == this.TargetRotation)
				{
					if (!this.SpawnedEffect)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.Effect, base.transform.position, Quaternion.identity).transform.eulerAngles = new Vector3(-90f, 0f, 0f);
						this.Prompt.Yandere.StudentManager.Students[15].transform.parent = base.transform;
						this.SpawnedEffect = true;
					}
					base.transform.position -= new Vector3(0f, Time.deltaTime, 0f);
					if (base.transform.localPosition.y > 3.1537f)
					{
						StudentScript studentScript3 = this.Prompt.Yandere.StudentManager.Students[15];
						studentScript3.Drowned = true;
						studentScript3.BecomeRagdoll();
						studentScript3.Ragdoll.Zs.SetActive(false);
						studentScript3.Ragdoll.DestroyRigidbodies();
						studentScript3.DeathType = DeathType.Drowning;
						studentScript3.CharacterAnimation.enabled = true;
						studentScript3.CharacterAnimation.Play("f02_sunbatheSleep_00");
						this.PerformingAction = false;
						this.Prompt.enabled = false;
						this.Prompt.Hide();
						base.enabled = false;
					}
				}
			}
		}
	}

	// Token: 0x060014CE RID: 5326 RVA: 0x000CEE2D File Offset: 0x000CD02D
	public void SabotageAndDisable()
	{
		this.Event.Sabotage();
		this.Prompt.enabled = false;
		this.Prompt.Hide();
		base.enabled = false;
	}

	// Token: 0x040020C5 RID: 8389
	public GenericPromptScript NextPrompt;

	// Token: 0x040020C6 RID: 8390
	public StudentScript CrushedStudent;

	// Token: 0x040020C7 RID: 8391
	public GenericRivalEventScript Event;

	// Token: 0x040020C8 RID: 8392
	public GameObject CrushCollider;

	// Token: 0x040020C9 RID: 8393
	public GameObject Effect;

	// Token: 0x040020CA RID: 8394
	public GameObject[] Object;

	// Token: 0x040020CB RID: 8395
	public Transform ObjectToRotate;

	// Token: 0x040020CC RID: 8396
	public Transform PlayerSpot;

	// Token: 0x040020CD RID: 8397
	public PromptScript Prompt;

	// Token: 0x040020CE RID: 8398
	public AudioSource MyAudio;

	// Token: 0x040020CF RID: 8399
	public Mesh NewMesh;

	// Token: 0x040020D0 RID: 8400
	public bool PerformingAction;

	// Token: 0x040020D1 RID: 8401
	public bool SpawnedEffect;

	// Token: 0x040020D2 RID: 8402
	public float TargetRotation = 90f;

	// Token: 0x040020D3 RID: 8403
	public float Rotation;

	// Token: 0x040020D4 RID: 8404
	public float Speed;

	// Token: 0x040020D5 RID: 8405
	public int ID;
}
