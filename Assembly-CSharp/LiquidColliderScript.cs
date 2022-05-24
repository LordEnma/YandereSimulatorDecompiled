using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class LiquidColliderScript : MonoBehaviour
{
	// Token: 0x06001985 RID: 6533 RVA: 0x00101084 File Offset: 0x000FF284
	private void Start()
	{
		if (this.Bucket)
		{
			base.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 400f);
		}
	}

	// Token: 0x06001986 RID: 6534 RVA: 0x001010A8 File Offset: 0x000FF2A8
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

	// Token: 0x06001987 RID: 6535 RVA: 0x00101228 File Offset: 0x000FF428
	private void OnTriggerEnter(Collider other)
	{
		if (!this.AlreadyDoused && other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				if (component.Wet || component.Fleeing || component.SenpaiWitnessingRivalDie)
				{
					component.Yandere.NotificationManager.CustomText = "Didn't care.";
					component.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					return;
				}
				if (!component.BeenSplashed && component.StudentID > 1 && !component.Reflexes && !component.Teacher && component.Club != ClubType.Council && !component.GasWarned && component.CurrentAction != StudentActionType.Sunbathe)
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

	// Token: 0x04002893 RID: 10387
	private GameObject NewPool;

	// Token: 0x04002894 RID: 10388
	public AudioClip SplashSound;

	// Token: 0x04002895 RID: 10389
	public GameObject GroundSplash;

	// Token: 0x04002896 RID: 10390
	public GameObject Splash;

	// Token: 0x04002897 RID: 10391
	public GameObject Pool;

	// Token: 0x04002898 RID: 10392
	public bool AlreadyDoused;

	// Token: 0x04002899 RID: 10393
	public bool Static;

	// Token: 0x0400289A RID: 10394
	public bool Bucket;

	// Token: 0x0400289B RID: 10395
	public bool Brown;

	// Token: 0x0400289C RID: 10396
	public bool Blood;

	// Token: 0x0400289D RID: 10397
	public bool Gas;
}
