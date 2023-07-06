using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
	public Rigidbody MyRigidbody;

	private void Start()
	{
		MyRigidbody.useGravity = true;
	}

	private void Update()
	{
		if (base.transform.position.y < 0.1f)
		{
			GetComponent<AudioSource>().Play();
			base.enabled = false;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (!(component != null))
		{
			return;
		}
		if (component.StudentID == 1)
		{
			Debug.Log(component.Name + " just dodged a falling air conditioner.");
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
				ParticleSystem.EmissionModule emission = component.Hearts.emission;
				emission.enabled = false;
				component.FollowCountdown.gameObject.SetActive(value: false);
				component.Yandere.Follower = null;
				component.Yandere.Followers--;
				component.Following = false;
				component.CurrentDestination = component.Destinations[component.Phase];
				component.Pathfinding.target = component.Destinations[component.Phase];
				component.Pathfinding.speed = 1f;
			}
			component.Yandere.NotificationManager.CustomText = "Senpai dodged it!";
			component.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
		else
		{
			GetComponent<AudioSource>().Play();
			component.DeathType = DeathType.Weight;
			component.BecomeRagdoll();
			base.enabled = false;
			component.MapMarker.gameObject.layer = 10;
			Debug.Log(component.Name + "'s ''Alive'' variable is: " + component.Alive);
			Object.Instantiate(component.AlarmDisc, new Vector3(component.Hips.position.x, 1f, component.Hips.position.z), Quaternion.identity).transform.localScale = new Vector3(1000f, 1f, 1000f);
		}
	}
}
