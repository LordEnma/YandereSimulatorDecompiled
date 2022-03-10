using System;
using UnityEngine;

// Token: 0x020003A9 RID: 937
public class PlaceholderStudentScript : MonoBehaviour
{
	// Token: 0x06001ABC RID: 6844 RVA: 0x00122602 File Offset: 0x00120802
	private void Start()
	{
		this.Target = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject).transform;
		this.ChooseNewDestination();
	}

	// Token: 0x06001ABD RID: 6845 RVA: 0x00122620 File Offset: 0x00120820
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

	// Token: 0x06001ABE RID: 6846 RVA: 0x001228B4 File Offset: 0x00120AB4
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

	// Token: 0x04002C9F RID: 11423
	public FakeStudentSpawnerScript FakeStudentSpawner;

	// Token: 0x04002CA0 RID: 11424
	public GameObject EmptyGameObject;

	// Token: 0x04002CA1 RID: 11425
	public bool ShootRaycasts;

	// Token: 0x04002CA2 RID: 11426
	public Transform Target;

	// Token: 0x04002CA3 RID: 11427
	public Transform Eyes;

	// Token: 0x04002CA4 RID: 11428
	public int StudentID;

	// Token: 0x04002CA5 RID: 11429
	public int Phase;

	// Token: 0x04002CA6 RID: 11430
	public int NESW;
}
