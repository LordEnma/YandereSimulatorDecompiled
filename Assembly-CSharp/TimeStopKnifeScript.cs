using UnityEngine;

public class TimeStopKnifeScript : MonoBehaviour
{
	public GameObject FemaleScream;

	public GameObject MaleScream;

	public bool Unfreeze;

	public float Speed = 0.1f;

	private float Timer;

	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	private void Update()
	{
		if (!Unfreeze)
		{
			Speed = Mathf.MoveTowards(Speed, 0f, Time.deltaTime);
			if (base.transform.localScale.x < 0.99f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
		}
		else
		{
			Speed = 10f;
			Timer += Time.deltaTime;
			if (Timer > 5f)
			{
				Object.Destroy(base.gameObject);
			}
		}
		base.transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!Unfreeze || other.gameObject.layer != 9)
		{
			return;
		}
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			if (component.Male)
			{
				Object.Instantiate(MaleScream, base.transform.position, Quaternion.identity);
			}
			else
			{
				Object.Instantiate(FemaleScream, base.transform.position, Quaternion.identity);
			}
			component.DeathType = DeathType.EasterEgg;
			component.BecomeRagdoll();
		}
	}
}
