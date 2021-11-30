using System;
using UnityEngine;

// Token: 0x020002C0 RID: 704
public class FakeStudentSpawnerScript : MonoBehaviour
{
	// Token: 0x06001473 RID: 5235 RVA: 0x000C7254 File Offset: 0x000C5454
	public void Spawn()
	{
		if (!this.AlreadySpawned)
		{
			this.Student = this.FakeFemale;
			this.NESW = 1;
			while (this.Spawned < 100)
			{
				if (this.NESW == 1)
				{
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height, UnityEngine.Random.Range(21f, 19f)), Quaternion.identity);
				}
				else if (this.NESW == 2)
				{
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(19f, 21f), (float)this.Height, UnityEngine.Random.Range(29f, -37f)), Quaternion.identity);
				}
				else if (this.NESW == 3)
				{
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height, UnityEngine.Random.Range(-21f, -19f)), Quaternion.identity);
				}
				else if (this.NESW == 4)
				{
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(-19f, -21f), (float)this.Height, UnityEngine.Random.Range(29f, -37f)), Quaternion.identity);
				}
				this.StudentID++;
				this.NewStudent.GetComponent<PlaceholderStudentScript>().FakeStudentSpawner = this;
				this.NewStudent.GetComponent<PlaceholderStudentScript>().StudentID = this.StudentID;
				this.NewStudent.GetComponent<PlaceholderStudentScript>().NESW = this.NESW;
				this.NewStudent.transform.parent = this.FakeStudentParent;
				this.CurrentFloor++;
				this.CurrentRow++;
				this.Spawned++;
				if (this.CurrentFloor == this.FloorLimit)
				{
					this.CurrentFloor = 0;
					this.Height += 4;
				}
				if (this.CurrentRow == this.RowLimit)
				{
					this.CurrentRow = 0;
					this.NESW++;
					if (this.NESW > 4)
					{
						this.NESW = 1;
					}
				}
				this.Student = ((this.Student == this.FakeFemale) ? this.FakeMale : this.FakeFemale);
			}
			this.StudentIDLimit = this.StudentID;
			this.StudentID = 1;
			this.AlreadySpawned = true;
			return;
		}
		this.FakeStudentParent.gameObject.SetActive(!this.FakeStudentParent.gameObject.activeInHierarchy);
	}

	// Token: 0x04001F8C RID: 8076
	public Transform FakeStudentParent;

	// Token: 0x04001F8D RID: 8077
	public GameObject NewStudent;

	// Token: 0x04001F8E RID: 8078
	public GameObject FakeFemale;

	// Token: 0x04001F8F RID: 8079
	public GameObject FakeMale;

	// Token: 0x04001F90 RID: 8080
	public GameObject Student;

	// Token: 0x04001F91 RID: 8081
	public bool AlreadySpawned;

	// Token: 0x04001F92 RID: 8082
	public int CurrentFloor;

	// Token: 0x04001F93 RID: 8083
	public int CurrentRow;

	// Token: 0x04001F94 RID: 8084
	public int FloorLimit;

	// Token: 0x04001F95 RID: 8085
	public int RowLimit;

	// Token: 0x04001F96 RID: 8086
	public int StudentIDLimit;

	// Token: 0x04001F97 RID: 8087
	public int StudentID;

	// Token: 0x04001F98 RID: 8088
	public int Spawned;

	// Token: 0x04001F99 RID: 8089
	public int Height;

	// Token: 0x04001F9A RID: 8090
	public int NESW;

	// Token: 0x04001F9B RID: 8091
	public int ID;

	// Token: 0x04001F9C RID: 8092
	public GameObject[] SuspiciousObjects;
}
