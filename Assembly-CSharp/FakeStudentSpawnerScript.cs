using System;
using UnityEngine;

// Token: 0x020002C3 RID: 707
public class FakeStudentSpawnerScript : MonoBehaviour
{
	// Token: 0x06001484 RID: 5252 RVA: 0x000C8428 File Offset: 0x000C6628
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

	// Token: 0x04001FC2 RID: 8130
	public Transform FakeStudentParent;

	// Token: 0x04001FC3 RID: 8131
	public GameObject NewStudent;

	// Token: 0x04001FC4 RID: 8132
	public GameObject FakeFemale;

	// Token: 0x04001FC5 RID: 8133
	public GameObject FakeMale;

	// Token: 0x04001FC6 RID: 8134
	public GameObject Student;

	// Token: 0x04001FC7 RID: 8135
	public bool AlreadySpawned;

	// Token: 0x04001FC8 RID: 8136
	public int CurrentFloor;

	// Token: 0x04001FC9 RID: 8137
	public int CurrentRow;

	// Token: 0x04001FCA RID: 8138
	public int FloorLimit;

	// Token: 0x04001FCB RID: 8139
	public int RowLimit;

	// Token: 0x04001FCC RID: 8140
	public int StudentIDLimit;

	// Token: 0x04001FCD RID: 8141
	public int StudentID;

	// Token: 0x04001FCE RID: 8142
	public int Spawned;

	// Token: 0x04001FCF RID: 8143
	public int Height;

	// Token: 0x04001FD0 RID: 8144
	public int NESW;

	// Token: 0x04001FD1 RID: 8145
	public int ID;

	// Token: 0x04001FD2 RID: 8146
	public GameObject[] SuspiciousObjects;
}
