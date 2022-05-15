using System;
using UnityEngine;

// Token: 0x020003AE RID: 942
public class PlaceholderStudentScript : MonoBehaviour
{
	// Token: 0x06001AE3 RID: 6883 RVA: 0x00124ED6 File Offset: 0x001230D6
	private void Start()
	{
		this.Target = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject).transform;
		this.ChooseNewDestination();
	}

	// Token: 0x06001AE4 RID: 6884 RVA: 0x00124EF4 File Offset: 0x001230F4
	private void Update()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Target.position, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Target.position) < 1f)
		{
			this.ChooseNewDestination();
		}
		if (Input.GetKeyDown("space"))
		{
			if (!this.ShootRaycasts)
			{
				this.ShootRaycasts = true;
			}
			else
			{
				this.Phase++;
			}
		}
		if (base.transform.position.y < 1f && this.ShootRaycasts)
		{
			if (this.Phase == 0)
			{
				Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[0].transform.position, Color.red);
				Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[1].transform.position, Color.red);
				Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[2].transform.position, Color.red);
				return;
			}
			if (this.StudentID < this.FakeStudentSpawner.StudentID + 5 && this.StudentID > this.FakeStudentSpawner.StudentID - 5)
			{
				if (Vector3.Distance(base.transform.position, this.FakeStudentSpawner.SuspiciousObjects[0].transform.position) < 5f)
				{
					Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[0].transform.position, Color.red);
				}
				if (Vector3.Distance(base.transform.position, this.FakeStudentSpawner.SuspiciousObjects[1].transform.position) < 5f)
				{
					Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[1].transform.position, Color.red);
				}
				if (Vector3.Distance(base.transform.position, this.FakeStudentSpawner.SuspiciousObjects[2].transform.position) < 5f)
				{
					Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[2].transform.position, Color.red);
				}
			}
		}
	}

	// Token: 0x06001AE5 RID: 6885 RVA: 0x00125188 File Offset: 0x00123388
	private void ChooseNewDestination()
	{
		if (this.NESW == 1)
		{
			this.Target.position = new Vector3(UnityEngine.Random.Range(-21f, 21f), base.transform.position.y, UnityEngine.Random.Range(21f, 19f));
			return;
		}
		if (this.NESW == 2)
		{
			this.Target.position = new Vector3(UnityEngine.Random.Range(19f, 21f), base.transform.position.y, UnityEngine.Random.Range(29f, -37f));
			return;
		}
		if (this.NESW == 3)
		{
			this.Target.position = new Vector3(UnityEngine.Random.Range(-21f, 21f), base.transform.position.y, UnityEngine.Random.Range(-21f, -19f));
			return;
		}
		if (this.NESW == 4)
		{
			this.Target.position = new Vector3(UnityEngine.Random.Range(-19f, -21f), base.transform.position.y, UnityEngine.Random.Range(29f, -37f));
		}
	}

	// Token: 0x04002D0C RID: 11532
	public FakeStudentSpawnerScript FakeStudentSpawner;

	// Token: 0x04002D0D RID: 11533
	public GameObject EmptyGameObject;

	// Token: 0x04002D0E RID: 11534
	public bool ShootRaycasts;

	// Token: 0x04002D0F RID: 11535
	public Transform Target;

	// Token: 0x04002D10 RID: 11536
	public Transform Eyes;

	// Token: 0x04002D11 RID: 11537
	public int StudentID;

	// Token: 0x04002D12 RID: 11538
	public int Phase;

	// Token: 0x04002D13 RID: 11539
	public int NESW;
}
