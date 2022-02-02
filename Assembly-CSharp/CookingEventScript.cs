using System;
using UnityEngine;

// Token: 0x0200025D RID: 605
public class CookingEventScript : MonoBehaviour
{
	// Token: 0x060012C0 RID: 4800 RVA: 0x0009B09C File Offset: 0x0009929C
	private void Start()
	{
		this.Octodog.SetActive(false);
		this.Sausage.SetActive(false);
		this.Rotation = -90f;
		Transform[] octodogs = this.Octodogs;
		for (int i = 0; i < octodogs.Length; i++)
		{
			octodogs[i].gameObject.SetActive(false);
		}
		this.EventSubtitle.transform.localScale = Vector3.zero;
		this.EventCheck = true;
		if (ClubGlobals.GetClubClosed(ClubType.Cooking))
		{
			base.enabled = false;
		}
	}

	// Token: 0x060012C1 RID: 4801 RVA: 0x0009B11C File Offset: 0x0009931C
	private void Update()
	{
		Input.GetKeyDown(KeyCode.Space);
		if (!this.Clock.StopTime && this.EventCheck && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[this.EventStudentID];
			if (this.EventStudent != null && !this.EventStudent.Distracted && this.EventStudent.MeetTime == 0f && !this.EventStudent.Meeting && !this.EventStudent.Wet)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					this.Snacks.Prompt.Hide();
					this.Snacks.Prompt.enabled = false;
					this.Snacks.enabled = false;
					this.EventStudent.CurrentDestination = this.EventLocations[0];
					this.EventStudent.Pathfinding.target = this.EventLocations[0];
					this.EventStudent.Scrubber.SetActive(false);
					this.EventStudent.Eraser.SetActive(false);
					this.EventStudent.Obstacle.checkTime = 99f;
					this.EventStudent.CookingEvent = this;
					this.EventStudent.InEvent = true;
					this.EventStudent.Private = true;
					this.EventStudent.Prompt.Hide();
					this.EventCheck = false;
					this.EventActive = true;
					if (this.EventStudent.Following)
					{
						this.EventStudent.Pathfinding.canMove = true;
						this.EventStudent.Pathfinding.speed = 1f;
						this.EventStudent.Following = false;
						this.EventStudent.Routine = true;
						this.Yandere.Follower = null;
						this.Yandere.Followers--;
						this.EventStudent.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
						this.EventStudent.Prompt.Label[0].text = "     Talk";
					}
				}
				else
				{
					base.enabled = false;
				}
			}
		}
		if (this.EventActive)
		{
			if (this.Clock.HourTime > this.EventTime + 0.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || this.EventStudent.Yandere.Cooking)
			{
				this.EndEvent();
				return;
			}
			if (this.EventStudent.DistanceToDestination < 1f)
			{
				if (this.EventPhase == -1)
				{
					this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
					this.Timer += Time.deltaTime;
					if (this.Timer > 5f)
					{
						SchemeGlobals.SetSchemeStage(4, 5);
						this.Schemes.UpdateInstructions();
						this.RivalPhone.SetActive(false);
						this.EventSubtitle.text = string.Empty;
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 0)
				{
					if (!this.RivalPhone.activeInHierarchy)
					{
						this.EventStudent.CharacterAnimation.Play("f02_prepareFood_00");
						this.EventStudent.SmartPhone.SetActive(false);
						this.Octodog.transform.parent = this.EventStudent.RightHand;
						this.Octodog.transform.localPosition = new Vector3(0.0129f, -0.02475f, 0.0316f);
						this.Octodog.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
						this.Sausage.transform.parent = this.EventStudent.RightHand;
						this.Sausage.transform.localPosition = new Vector3(0.013f, -0.038f, 0.015f);
						this.Sausage.transform.localEulerAngles = Vector3.zero;
						this.EventPhase++;
					}
					else
					{
						AudioClipPlayer.Play(this.EventClip[0], this.EventStudent.transform.position + Vector3.up, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
						this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
						this.EventSubtitle.text = this.EventSpeech[0];
						this.EventPhase--;
					}
				}
				else if (this.EventPhase == 1)
				{
					this.EventStudent.CharacterAnimation.Play("f02_prepareFood_00");
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 1f)
					{
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 2)
				{
					this.Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 3f)
					{
						this.Jar.transform.parent = this.EventStudent.RightHand;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 3)
				{
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 5f)
					{
						this.JarLid.transform.parent = this.EventStudent.LeftHand;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 4)
				{
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 6f)
					{
						this.JarLid.transform.parent = this.CookingClub;
						this.JarLid.transform.localPosition = new Vector3(0.334585f, 1f, -0.2528915f);
						this.JarLid.transform.localEulerAngles = new Vector3(0f, 30f, 0f);
						this.Jar.transform.parent = this.CookingClub;
						this.Jar.transform.localPosition = new Vector3(0.29559f, 1f, 0.2029152f);
						this.Jar.transform.localEulerAngles = new Vector3(0f, -150f, 0f);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 5)
				{
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time > 7f)
					{
						this.Knife.GetComponent<WeaponScript>().FingerprintID = this.EventStudent.StudentID;
						this.Knife.parent = this.EventStudent.LeftHand;
						this.Knife.localPosition = new Vector3(0f, -0.01f, 0f);
						this.Knife.localEulerAngles = new Vector3(0f, 0f, -90f);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 6)
				{
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time >= this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length)
					{
						this.EventStudent.CharacterAnimation.CrossFade("f02_cutFood_00");
						this.Sausage.SetActive(true);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 7)
				{
					if (this.EventStudent.CharacterAnimation["f02_cutFood_00"].time > 2.66666f)
					{
						this.Octodog.SetActive(true);
						this.Sausage.SetActive(false);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 8)
				{
					if (this.EventStudent.CharacterAnimation["f02_cutFood_00"].time > 3f)
					{
						this.Rotation = Mathf.MoveTowards(this.Rotation, 90f, Time.deltaTime * 360f);
						this.Octodog.transform.localEulerAngles = new Vector3(this.Rotation, this.Octodog.transform.localEulerAngles.y, this.Octodog.transform.localEulerAngles.z);
						this.Octodog.transform.localPosition = new Vector3(this.Octodog.transform.localPosition.x, this.Octodog.transform.localPosition.y, Mathf.MoveTowards(this.Octodog.transform.localPosition.z, 0.012f, Time.deltaTime));
					}
					if (this.EventStudent.CharacterAnimation["f02_cutFood_00"].time > 6f)
					{
						this.Octodog.SetActive(false);
						this.Octodogs[this.Loop].gameObject.SetActive(true);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 9)
				{
					if (this.EventStudent.CharacterAnimation["f02_cutFood_00"].time >= this.EventStudent.CharacterAnimation["f02_cutFood_00"].length)
					{
						if (this.Loop < this.Octodogs.Length - 1)
						{
							this.Octodog.transform.localEulerAngles = new Vector3(-90f, this.Octodog.transform.localEulerAngles.y, this.Octodog.transform.localEulerAngles.z);
							this.Octodog.transform.localPosition = new Vector3(this.Octodog.transform.localPosition.x, this.Octodog.transform.localPosition.y, 0.0316f);
							this.EventStudent.CharacterAnimation["f02_cutFood_00"].time = 0f;
							this.EventStudent.CharacterAnimation.Play("f02_cutFood_00");
							this.Sausage.SetActive(true);
							this.EventPhase = 7;
							this.Rotation = -90f;
							this.Loop++;
						}
						else
						{
							this.EventStudent.CharacterAnimation.Play("f02_prepareFood_00");
							this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time = this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length;
							this.EventStudent.CharacterAnimation["f02_prepareFood_00"].speed = -1f;
							this.EventPhase++;
						}
					}
				}
				else if (this.EventPhase == 10)
				{
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time < this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 1f)
					{
						this.Knife.parent = this.CookingClub;
						this.Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
						this.Knife.localEulerAngles = new Vector3(45f, -90f, -90f);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 11)
				{
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time < this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 2f)
					{
						this.JarLid.parent = this.EventStudent.LeftHand;
						this.Jar.parent = this.EventStudent.RightHand;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 12)
				{
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time < this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 3f)
					{
						this.JarLid.parent = this.Jar;
						this.JarLid.localPosition = new Vector3(0f, 0.175f, 0f);
						this.JarLid.localEulerAngles = Vector3.zero;
						this.Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
						this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].time = this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].length;
						this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].speed = -1f;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 13)
				{
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time < this.EventStudent.CharacterAnimation["f02_prepareFood_00"].length - 5f)
					{
						this.Jar.parent = this.CookingClub;
						this.Jar.localPosition = new Vector3(0.1f, 0.941f, 0.75f);
						this.Jar.localEulerAngles = new Vector3(0f, 90f, 0f);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 14)
				{
					if (this.EventStudent.CharacterAnimation["f02_prepareFood_00"].time <= 0f)
					{
						this.Knife.GetComponent<Collider>().enabled = true;
						this.Plate.parent = this.EventStudent.RightHand;
						this.Plate.localPosition = new Vector3(0f, 0.011f, -0.156765f);
						this.Plate.localEulerAngles = new Vector3(0f, -90f, -180f);
						this.EventStudent.CurrentDestination = this.EventLocations[1];
						this.EventStudent.Pathfinding.target = this.EventLocations[1];
						this.EventStudent.CharacterAnimation[this.EventStudent.CarryAnim].weight = 1f;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 15)
				{
					this.Plate.parent = this.CookingClub;
					this.Plate.localPosition = new Vector3(-3.66666f, 0.9066666f, -2.379f);
					this.Plate.localEulerAngles = new Vector3(0f, -90f, 0f);
					this.EndEvent();
				}
				float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (num < 10f)
				{
					float num2 = Mathf.Abs((num - 10f) * 0.2f);
					if (num2 < 0f)
					{
						num2 = 0f;
					}
					if (num2 > 1f)
					{
						num2 = 1f;
					}
					this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
					return;
				}
				if (num < 11f)
				{
					this.EventSubtitle.transform.localScale = Vector3.zero;
				}
			}
		}
	}

	// Token: 0x060012C2 RID: 4802 RVA: 0x0009C18C File Offset: 0x0009A38C
	private void EndEvent()
	{
		if (!this.EventOver)
		{
			if (this.VoiceClip != null)
			{
				UnityEngine.Object.Destroy(this.VoiceClip);
			}
			this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Obstacle.checkTime = 1f;
			if (!this.EventStudent.Dying)
			{
				this.EventStudent.Prompt.enabled = true;
			}
			if (this.Plate.parent == this.EventStudent.RightHand)
			{
				this.Plate.parent = null;
				this.Plate.GetComponent<Rigidbody>().useGravity = true;
				this.Plate.GetComponent<BoxCollider>().enabled = true;
			}
			this.EventStudent.CharacterAnimation[this.EventStudent.CarryAnim].weight = 0f;
			this.EventStudent.SmartPhone.SetActive(false);
			this.EventStudent.Pathfinding.speed = 1f;
			this.EventStudent.TargetDistance = 1f;
			this.EventStudent.PhoneEvent = null;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventSubtitle.text = string.Empty;
			if (this.Knife.parent == this.EventStudent.LeftHand)
			{
				this.Knife.parent = this.CookingClub;
				this.Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
				this.Knife.localEulerAngles = new Vector3(45f, -90f, -90f);
				this.Knife.GetComponent<Collider>().enabled = true;
			}
			this.StudentManager.UpdateStudents(0);
		}
		this.EventActive = false;
		this.EventCheck = false;
	}

	// Token: 0x040018E1 RID: 6369
	public StudentManagerScript StudentManager;

	// Token: 0x040018E2 RID: 6370
	public RefrigeratorScript Snacks;

	// Token: 0x040018E3 RID: 6371
	public SchemesScript Schemes;

	// Token: 0x040018E4 RID: 6372
	public YandereScript Yandere;

	// Token: 0x040018E5 RID: 6373
	public ClockScript Clock;

	// Token: 0x040018E6 RID: 6374
	public GameObject Refrigerator;

	// Token: 0x040018E7 RID: 6375
	public GameObject RivalPhone;

	// Token: 0x040018E8 RID: 6376
	public GameObject Octodog;

	// Token: 0x040018E9 RID: 6377
	public GameObject Sausage;

	// Token: 0x040018EA RID: 6378
	public Transform CookingClub;

	// Token: 0x040018EB RID: 6379
	public Transform JarLid;

	// Token: 0x040018EC RID: 6380
	public Transform Knife;

	// Token: 0x040018ED RID: 6381
	public Transform Plate;

	// Token: 0x040018EE RID: 6382
	public Transform Jar;

	// Token: 0x040018EF RID: 6383
	public Transform[] Octodogs;

	// Token: 0x040018F0 RID: 6384
	public StudentScript EventStudent;

	// Token: 0x040018F1 RID: 6385
	public UILabel EventSubtitle;

	// Token: 0x040018F2 RID: 6386
	public Transform[] EventLocations;

	// Token: 0x040018F3 RID: 6387
	public AudioClip[] EventClip;

	// Token: 0x040018F4 RID: 6388
	public string[] EventSpeech;

	// Token: 0x040018F5 RID: 6389
	public string[] EventAnim;

	// Token: 0x040018F6 RID: 6390
	public int[] ClubMembers;

	// Token: 0x040018F7 RID: 6391
	public GameObject VoiceClip;

	// Token: 0x040018F8 RID: 6392
	public bool EventActive;

	// Token: 0x040018F9 RID: 6393
	public bool EventCheck;

	// Token: 0x040018FA RID: 6394
	public bool EventOver;

	// Token: 0x040018FB RID: 6395
	public int EventStudentID;

	// Token: 0x040018FC RID: 6396
	public float EventTime = 7f;

	// Token: 0x040018FD RID: 6397
	public int EventPhase = 1;

	// Token: 0x040018FE RID: 6398
	public DayOfWeek EventDay = DayOfWeek.Tuesday;

	// Token: 0x040018FF RID: 6399
	public int Loop;

	// Token: 0x04001900 RID: 6400
	public float CurrentClipLength;

	// Token: 0x04001901 RID: 6401
	public float Rotation;

	// Token: 0x04001902 RID: 6402
	public float Timer;
}
