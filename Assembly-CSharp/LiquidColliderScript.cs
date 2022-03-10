using System;
using UnityEngine;

// Token: 0x02000352 RID: 850
public class LiquidColliderScript : MonoBehaviour
{
	// Token: 0x06001963 RID: 6499 RVA: 0x000FEF98 File Offset: 0x000FD198
	private void Start()
	{
		if (this.Bucket)
		{
			base.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 400f);
		}
	}

	// Token: 0x06001964 RID: 6500 RVA: 0x000FEFBC File Offset: 0x000FD1BC
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

	// Token: 0x06001965 RID: 6501 RVA: 0x000FF13C File Offset: 0x000FD33C
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

	// Token: 0x04002837 RID: 10295
	private GameObject NewPool;

	// Token: 0x04002838 RID: 10296
	public AudioClip SplashSound;

	// Token: 0x04002839 RID: 10297
	public GameObject GroundSplash;

	// Token: 0x0400283A RID: 10298
	public GameObject Splash;

	// Token: 0x0400283B RID: 10299
	public GameObject Pool;

	// Token: 0x0400283C RID: 10300
	public bool AlreadyDoused;

	// Token: 0x0400283D RID: 10301
	public bool Static;

	// Token: 0x0400283E RID: 10302
	public bool Bucket;

	// Token: 0x0400283F RID: 10303
	public bool Brown;

	// Token: 0x04002840 RID: 10304
	public bool Blood;

	// Token: 0x04002841 RID: 10305
	public bool Gas;
}
