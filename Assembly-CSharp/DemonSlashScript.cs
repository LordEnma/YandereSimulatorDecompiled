using UnityEngine;

public class DemonSlashScript : MonoBehaviour
{
	public GameObject FemaleBloodyScream;

	public GameObject MaleBloodyScream;

	public AudioSource MyAudio;

	public Collider MyCollider;

	public float Timer;

	private void Start()
	{
		MyAudio = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (MyCollider.enabled)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f / 3f)
			{
				MyCollider.enabled = false;
				Timer = 0f;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Transform root = other.gameObject.transform.root;
		StudentScript component = root.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID != 1 && component.Alive)
		{
			component.DeathType = DeathType.EasterEgg;
			if (!component.Male)
			{
				Object.Instantiate(FemaleBloodyScream, root.transform.position + Vector3.up, Quaternion.identity);
			}
			else
			{
				Object.Instantiate(MaleBloodyScream, root.transform.position + Vector3.up, Quaternion.identity);
			}
			component.BecomeRagdoll();
			component.Ragdoll.Dismember();
			MyAudio.Play();
		}
	}
}
