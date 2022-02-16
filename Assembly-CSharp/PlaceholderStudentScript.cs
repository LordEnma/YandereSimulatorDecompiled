using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PlaceholderStudentScript : MonoBehaviour
{
	// Token: 0x06001AB2 RID: 6834 RVA: 0x00121816 File Offset: 0x0011FA16
	private void Start()
	{
		this.Target = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject).transform;
		this.ChooseNewDestination();
	}

	// Token: 0x06001AB3 RID: 6835 RVA: 0x00121834 File Offset: 0x0011FA34
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

	// Token: 0x06001AB4 RID: 6836 RVA: 0x00121AC8 File Offset: 0x0011FCC8
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

	// Token: 0x04002C79 RID: 11385
	public FakeStudentSpawnerScript FakeStudentSpawner;

	// Token: 0x04002C7A RID: 11386
	public GameObject EmptyGameObject;

	// Token: 0x04002C7B RID: 11387
	public bool ShootRaycasts;

	// Token: 0x04002C7C RID: 11388
	public Transform Target;

	// Token: 0x04002C7D RID: 11389
	public Transform Eyes;

	// Token: 0x04002C7E RID: 11390
	public int StudentID;

	// Token: 0x04002C7F RID: 11391
	public int Phase;

	// Token: 0x04002C80 RID: 11392
	public int NESW;
}
