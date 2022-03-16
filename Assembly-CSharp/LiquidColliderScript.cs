using System;
using UnityEngine;

// Token: 0x02000352 RID: 850
public class LiquidColliderScript : MonoBehaviour
{
	// Token: 0x0600196A RID: 6506 RVA: 0x000FF754 File Offset: 0x000FD954
	private void Start()
	{
		if (this.Bucket)
		{
			base.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 400f);
		}
	}

	// Token: 0x0600196B RID: 6507 RVA: 0x000FF778 File Offset: 0x000FD978
	private void Update()
	{
		if (!this.Static)
		{
			if (!this.Bucket)
			{
				if (base.transform.position.y < 0f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.GroundSplash, new Vector3(base.transform.position.x, 0f, base.transform.position.z), Quaternion.identity);
					this.NewPool = UnityEngine.Object.Instantiate<GameObject>(this.Pool, new Vector3(base.transform.position.x, 0.012f, base.transform.position.z), Quaternion.identity);
					this.NewPool.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
					if (this.Blood)
					{
						this.NewPool.transform.parent = GameObject.Find("BloodParent").transform;
					}
					UnityEngine.Object.Destroy(base.gameObject);
					return;
				}
			}
			else
			{
				base.transform.localScale = new Vector3(base.transform.localScale.x + Time.deltaTime * 2f, base.transform.localScale.y + Time.deltaTime * 2f, base.transform.localScale.z + Time.deltaTime * 2f);
			}
		}
	}

	// Token: 0x0600196C RID: 6508 RVA: 0x000FF8F8 File Offset: 0x000FDAF8
	private void OnTriggerEnter(Collider other)
	{
		if (!this.AlreadyDoused && other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				if (!component.BeenSplashed && component.StudentID > 1 && component.StudentID != 10 && !component.Teacher && component.Club != ClubType.Council && !component.Fleeing && component.CurrentAction != StudentActionType.Sunbathe && !component.GasWarned)
				{
					AudioSource.PlayClipAtPoint(this.SplashSound, base.transform.position);
					UnityEngine.Object.Instantiate<GameObject>(this.Splash, new Vector3(base.transform.position.x, 1.5f, base.transform.position.z), Quaternion.identity);
					if (this.Blood)
					{
						component.Bloody = true;
					}
					else if (this.Gas)
					{
						component.Gas = true;
					}
					else if (this.Brown)
					{
						component.DyedBrown = true;
					}
					component.GetWet();
					this.AlreadyDoused = true;
					UnityEngine.Object.Destroy(base.gameObject);
					return;
				}
				if (!component.Wet && !component.Fleeing)
				{
					Debug.Log(component.Name + " just dodged some liquid.");
					if (component.Investigating)
					{
						component.StopInvestigating();
					}
					if (component.ReturningMisplacedWeapon)
					{
						component.DropMisplacedWeapon();
					}
					if (component.EatingSnack)
					{
						Debug.Log("This student was eating a snack at the point in time when they dodged the liquid, so they are forgetting about getting a drink.");
						component.StopDrinking();
						component.CurrentDestination = component.Destinations[component.Phase];
						component.Pathfinding.target = component.Destinations[component.Phase];
					}
					component.CharacterAnimation.CrossFade(component.DodgeAnim);
					component.Pathfinding.canSearch = false;
					component.Pathfinding.canMove = false;
					component.SentToLocker = false;
					component.Routine = false;
					component.DodgeSpeed = 2f;
					component.Dodging = true;
					if (component.Following)
					{
						component.Hearts.emission.enabled = false;
						component.FollowCountdown.gameObject.SetActive(false);
						component.Yandere.Follower = null;
						component.Yandere.Followers--;
						component.Following = false;
						component.CurrentDestination = component.Destinations[component.Phase];
						component.Pathfinding.target = component.Destinations[component.Phase];
						component.Pathfinding.speed = 1f;
					}
					component.Yandere.NotificationManager.CustomText = "Anticipated the trap!";
					component.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
	}

	// Token: 0x04002854 RID: 10324
	private GameObject NewPool;

	// Token: 0x04002855 RID: 10325
	public AudioClip SplashSound;

	// Token: 0x04002856 RID: 10326
	public GameObject GroundSplash;

	// Token: 0x04002857 RID: 10327
	public GameObject Splash;

	// Token: 0x04002858 RID: 10328
	public GameObject Pool;

	// Token: 0x04002859 RID: 10329
	public bool AlreadyDoused;

	// Token: 0x0400285A RID: 10330
	public bool Static;

	// Token: 0x0400285B RID: 10331
	public bool Bucket;

	// Token: 0x0400285C RID: 10332
	public bool Brown;

	// Token: 0x0400285D RID: 10333
	public bool Blood;

	// Token: 0x0400285E RID: 10334
	public bool Gas;
}
