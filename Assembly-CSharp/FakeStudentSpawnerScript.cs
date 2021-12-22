using System;
using UnityEngine;

// Token: 0x020002C1 RID: 705
public class FakeStudentSpawnerScript : MonoBehaviour
{
	// Token: 0x0600147A RID: 5242 RVA: 0x000C79F0 File Offset: 0x000C5BF0
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

	// Token: 0x04001FAC RID: 8108
	public Transform FakeStudentParent;

	// Token: 0x04001FAD RID: 8109
	public GameObject NewStudent;

	// Token: 0x04001FAE RID: 8110
	public GameObject FakeFemale;

	// Token: 0x04001FAF RID: 8111
	public GameObject FakeMale;

	// Token: 0x04001FB0 RID: 8112
	public GameObject Student;

	// Token: 0x04001FB1 RID: 8113
	public bool AlreadySpawned;

	// Token: 0x04001FB2 RID: 8114
	public int CurrentFloor;

	// Token: 0x04001FB3 RID: 8115
	public int CurrentRow;

	// Token: 0x04001FB4 RID: 8116
	public int FloorLimit;

	// Token: 0x04001FB5 RID: 8117
	public int RowLimit;

	// Token: 0x04001FB6 RID: 8118
	public int StudentIDLimit;

	// Token: 0x04001FB7 RID: 8119
	public int StudentID;

	// Token: 0x04001FB8 RID: 8120
	public int Spawned;

	// Token: 0x04001FB9 RID: 8121
	public int Height;

	// Token: 0x04001FBA RID: 8122
	public int NESW;

	// Token: 0x04001FBB RID: 8123
	public int ID;

	// Token: 0x04001FBC RID: 8124
	public GameObject[] SuspiciousObjects;
}
