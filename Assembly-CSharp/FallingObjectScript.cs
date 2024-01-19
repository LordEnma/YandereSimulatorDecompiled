using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
	public float PreviousVelocity;

	public float Velocity;

	public float Timer;

	public bool Nonlethal;

	public int Frame;

	public Rigidbody MyRigidbody;

	public Collider MyCollider;

	private void Start()
	{
		MyRigidbody.useGravity = true;
		if (MyCollider != null)
		{
			MyCollider.enabled = true;
		}
	}

	private void Update()
	{
		Frame++;
		if (Frame > 1)
		{
			Velocity = Mathf.Abs(MyRigidbody.velocity.x) + Mathf.Abs(MyRigidbody.velocity.y) + Mathf.Abs(MyRigidbody.velocity.z);
			if (Velocity < PreviousVelocity - 10f)
			{
				Debug.Log("Struck the ground or a person on this frame.");
				GetComponent<AudioSource>().Play();
				Nonlethal = true;
			}
			if (Nonlethal)
			{
				Timer += Time.deltaTime;
			}
			if (MyRigidbody.velocity == Vector3.zero || (Nonlethal && Timer > 5f))
			{
				MyRigidbody.useGravity = false;
				MyRigidbody.isKinematic = true;
				Nonlethal = false;
				base.enabled = false;
				base.gameObject.layer = 15;
				Velocity = 0f;
				Frame = 0;
				Timer = 0f;
			}
			PreviousVelocity = Velocity;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (!(PreviousVelocity > 5f) || Nonlethal)
		{
			return;
		}
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (!(component != null))
		{
			return;
		}
		if (component.StudentID == 1)
		{
			Debug.Log(component.Name + " just dodged a falling object.");
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
			component.DeathType = DeathType.Weight;
			component.BecomeRagdoll();
			component.MapMarker.gameObject.layer = 10;
			Debug.Log(component.Name + "'s ''Alive'' variable is: " + component.Alive);
			Object.Instantiate(component.AlarmDisc, new Vector3(component.Hips.position.x, 1f, component.Hips.position.z), Quaternion.identity).transform.localScale = new Vector3(1000f, 1f, 1000f);
			Nonlethal = true;
		}
	}
}
