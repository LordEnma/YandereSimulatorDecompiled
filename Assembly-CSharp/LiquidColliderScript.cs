using System;
using UnityEngine;

// Token: 0x02000354 RID: 852
public class LiquidColliderScript : MonoBehaviour
{
	// Token: 0x0600197A RID: 6522 RVA: 0x00100174 File Offset: 0x000FE374
	private void Start()
	{
		if (this.Bucket)
		{
			base.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 400f);
		}
	}

	// Token: 0x0600197B RID: 6523 RVA: 0x00100198 File Offset: 0x000FE398
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

	// Token: 0x0600197C RID: 6524 RVA: 0x00100318 File Offset: 0x000FE518
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
				if (!component.BeenSplashed && component.StudentID > 1 && component.StudentID != 10 && !component.Teacher && component.Club != ClubType.Council && !component.GasWarned && component.CurrentAction != StudentActionType.Sunbathe)
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

	// Token: 0x04002872 RID: 10354
	private GameObject NewPool;

	// Token: 0x04002873 RID: 10355
	public AudioClip SplashSound;

	// Token: 0x04002874 RID: 10356
	public GameObject GroundSplash;

	// Token: 0x04002875 RID: 10357
	public GameObject Splash;

	// Token: 0x04002876 RID: 10358
	public GameObject Pool;

	// Token: 0x04002877 RID: 10359
	public bool AlreadyDoused;

	// Token: 0x04002878 RID: 10360
	public bool Static;

	// Token: 0x04002879 RID: 10361
	public bool Bucket;

	// Token: 0x0400287A RID: 10362
	public bool Brown;

	// Token: 0x0400287B RID: 10363
	public bool Blood;

	// Token: 0x0400287C RID: 10364
	public bool Gas;
}
