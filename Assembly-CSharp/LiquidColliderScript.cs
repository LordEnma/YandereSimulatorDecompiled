using System;
using UnityEngine;

// Token: 0x02000350 RID: 848
public class LiquidColliderScript : MonoBehaviour
{
	// Token: 0x06001950 RID: 6480 RVA: 0x000FDA1C File Offset: 0x000FBC1C
	private void Start()
	{
		if (this.Bucket)
		{
			base.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 400f);
		}
	}

	// Token: 0x06001951 RID: 6481 RVA: 0x000FDA40 File Offset: 0x000FBC40
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

	// Token: 0x06001952 RID: 6482 RVA: 0x000FDBC0 File Offset: 0x000FBDC0
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
					Debug.Log(component.Name + " just dodged a bucket of liquid.");
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
				}
			}
		}
	}

	// Token: 0x040027FF RID: 10239
	private GameObject NewPool;

	// Token: 0x04002800 RID: 10240
	public AudioClip SplashSound;

	// Token: 0x04002801 RID: 10241
	public GameObject GroundSplash;

	// Token: 0x04002802 RID: 10242
	public GameObject Splash;

	// Token: 0x04002803 RID: 10243
	public GameObject Pool;

	// Token: 0x04002804 RID: 10244
	public bool AlreadyDoused;

	// Token: 0x04002805 RID: 10245
	public bool Static;

	// Token: 0x04002806 RID: 10246
	public bool Bucket;

	// Token: 0x04002807 RID: 10247
	public bool Brown;

	// Token: 0x04002808 RID: 10248
	public bool Blood;

	// Token: 0x04002809 RID: 10249
	public bool Gas;
}
