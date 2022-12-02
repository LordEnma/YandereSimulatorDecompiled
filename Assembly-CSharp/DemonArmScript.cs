using UnityEngine;

public class DemonArmScript : MonoBehaviour
{
	public GameObject DismembermentCollider;

	public Animation MyAnimation;

	public Collider ClawCollider;

	public bool Attacking;

	public bool Attacked;

	public bool Rising = true;

	public string IdleAnim = "DemonArmIdle";

	public string AttackAnim = "DemonArmAttack";

	public AudioClip Whoosh;

	public float AnimSpeed = 1f;

	public float AnimTime;

	private void Start()
	{
		MyAnimation = GetComponent<Animation>();
		if (!Rising)
		{
			MyAnimation[IdleAnim].speed = AnimSpeed * 0.5f;
		}
		MyAnimation[AttackAnim].speed = 1f;
	}

	private void Update()
	{
		if (!Rising)
		{
			if (!Attacking)
			{
				MyAnimation.CrossFade(IdleAnim);
				return;
			}
			if (!Attacked)
			{
				if (MyAnimation[AttackAnim].time >= MyAnimation[AttackAnim].length * 0.15f)
				{
					ClawCollider.enabled = true;
					Attacked = true;
				}
				return;
			}
			if (MyAnimation[AttackAnim].time >= MyAnimation[AttackAnim].length * 0.4f)
			{
				ClawCollider.enabled = false;
			}
			if (MyAnimation[AttackAnim].time >= MyAnimation[AttackAnim].length)
			{
				MyAnimation.CrossFade(IdleAnim);
				ClawCollider.enabled = false;
				Attacking = false;
				Attacked = false;
				AnimTime = 0f;
			}
		}
		else if (MyAnimation["DemonArmRise"].time >= MyAnimation["DemonArmRise"].length)
		{
			Rising = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			AudioSource component2 = GetComponent<AudioSource>();
			component2.clip = Whoosh;
			component2.pitch = Random.Range(-0.9f, 1.1f);
			component2.Play();
			GetComponent<Animation>().CrossFade(AttackAnim);
			Attacking = true;
		}
	}
}
