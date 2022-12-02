using UnityEngine;

public class PlaceholderStudentScript : MonoBehaviour
{
	public FakeStudentSpawnerScript FakeStudentSpawner;

	public GameObject EmptyGameObject;

	public bool ShootRaycasts;

	public Transform Target;

	public Transform Eyes;

	public int StudentID;

	public int Phase;

	public int NESW;

	private void Start()
	{
		Target = Object.Instantiate(EmptyGameObject).transform;
		ChooseNewDestination();
	}

	private void Update()
	{
		base.transform.LookAt(Target.position);
		base.transform.position = Vector3.MoveTowards(base.transform.position, Target.position, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, Target.position) < 1f)
		{
			ChooseNewDestination();
		}
		if (Input.GetKeyDown("space"))
		{
			if (!ShootRaycasts)
			{
				ShootRaycasts = true;
			}
			else
			{
				Phase++;
			}
		}
		if (!(base.transform.position.y < 1f) || !ShootRaycasts)
		{
			return;
		}
		if (Phase == 0)
		{
			Debug.DrawLine(Eyes.position, FakeStudentSpawner.SuspiciousObjects[0].transform.position, Color.red);
			Debug.DrawLine(Eyes.position, FakeStudentSpawner.SuspiciousObjects[1].transform.position, Color.red);
			Debug.DrawLine(Eyes.position, FakeStudentSpawner.SuspiciousObjects[2].transform.position, Color.red);
		}
		else if (StudentID < FakeStudentSpawner.StudentID + 5 && StudentID > FakeStudentSpawner.StudentID - 5)
		{
			if (Vector3.Distance(base.transform.position, FakeStudentSpawner.SuspiciousObjects[0].transform.position) < 5f)
			{
				Debug.DrawLine(Eyes.position, FakeStudentSpawner.SuspiciousObjects[0].transform.position, Color.red);
			}
			if (Vector3.Distance(base.transform.position, FakeStudentSpawner.SuspiciousObjects[1].transform.position) < 5f)
			{
				Debug.DrawLine(Eyes.position, FakeStudentSpawner.SuspiciousObjects[1].transform.position, Color.red);
			}
			if (Vector3.Distance(base.transform.position, FakeStudentSpawner.SuspiciousObjects[2].transform.position) < 5f)
			{
				Debug.DrawLine(Eyes.position, FakeStudentSpawner.SuspiciousObjects[2].transform.position, Color.red);
			}
		}
	}

	private void ChooseNewDestination()
	{
		if (NESW == 1)
		{
			Target.position = new Vector3(Random.Range(-21f, 21f), base.transform.position.y, Random.Range(21f, 19f));
		}
		else if (NESW == 2)
		{
			Target.position = new Vector3(Random.Range(19f, 21f), base.transform.position.y, Random.Range(29f, -37f));
		}
		else if (NESW == 3)
		{
			Target.position = new Vector3(Random.Range(-21f, 21f), base.transform.position.y, Random.Range(-21f, -19f));
		}
		else if (NESW == 4)
		{
			Target.position = new Vector3(Random.Range(-19f, -21f), base.transform.position.y, Random.Range(29f, -37f));
		}
	}
}
