using UnityEngine;

public class LiquidColliderScript : MonoBehaviour
{
	private GameObject NewPool;

	public AudioClip SplashSound;

	public GameObject GroundSplash;

	public GameObject Splash;

	public GameObject Pool;

	public bool AlreadyDoused;

	public bool Static;

	public bool Bucket;

	public bool Brown;

	public bool Blood;

	public bool Gas;

	private void Start()
	{
		if (Bucket)
		{
			GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 400f);
		}
	}

	private void Update()
	{
		if (Static)
		{
			return;
		}
		if (!Bucket)
		{
			if (base.transform.position.y < 0f)
			{
				Object.Instantiate(GroundSplash, new Vector3(base.transform.position.x, 0f, base.transform.position.z), Quaternion.identity);
				NewPool = Object.Instantiate(Pool, new Vector3(base.transform.position.x, 0.012f, base.transform.position.z), Quaternion.identity);
				NewPool.transform.localEulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
				if (Blood)
				{
					NewPool.transform.parent = GameObject.Find("BloodParent").transform;
				}
				Object.Destroy(base.gameObject);
			}
		}
		else
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x + Time.deltaTime * 2f, base.transform.localScale.y + Time.deltaTime * 2f, base.transform.localScale.z + Time.deltaTime * 2f);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (AlreadyDoused || other.gameObject.layer != 9)
		{
			return;
		}
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (!(component != null))
		{
			return;
		}
		if (component.Wet || component.Fleeing || component.SenpaiWitnessingRivalDie || (component.Schoolwear == 2 && !Brown && !Blood && !Gas) || component.Confessing || (component.Club == ClubType.Sports && component.ClubAttire && component.Clock.Period > 5 && !Brown && !Blood && !Gas))
		{
			component.Yandere.NotificationManager.CustomText = "Didn't care.";
			component.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			if (component.Schoolwear == 2 || component.ClubAttire)
			{
				component.Subtitle.CustomText = "What a stupid prank! Oh, well. I was in my swimsuit, anyway...";
				component.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
			}
			return;
		}
		if (!component.BeenSplashed && component.StudentID > 1 && !component.Reflexes && !component.Teacher && component.Club != ClubType.Council && !component.GasWarned && component.CurrentAction != StudentActionType.Sunbathe)
		{
			AudioSource.PlayClipAtPoint(SplashSound, base.transform.position);
			Object.Instantiate(Splash, new Vector3(base.transform.position.x, 1.5f, base.transform.position.z), Quaternion.identity);
			if (Blood)
			{
				component.Bloody = true;
			}
			else if (Gas)
			{
				component.Gas = true;
			}
			else if (Brown)
			{
				component.DyedBrown = true;
			}
			component.GetWet();
			AlreadyDoused = true;
			Object.Destroy(base.gameObject);
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
			Debug.Log("This student was following at the time they were slashed.");
			ParticleSystem.EmissionModule emission = component.Hearts.emission;
			emission.enabled = false;
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
