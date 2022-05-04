using System;
using UnityEngine;

// Token: 0x020002C5 RID: 709
public class FakeStudentSpawnerScript : MonoBehaviour
{
	// Token: 0x0600149B RID: 5275 RVA: 0x000C9B44 File Offset: 0x000C7D44
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

	// Token: 0x04001FFA RID: 8186
	public Transform FakeStudentParent;

	// Token: 0x04001FFB RID: 8187
	public GameObject NewStudent;

	// Token: 0x04001FFC RID: 8188
	public GameObject FakeFemale;

	// Token: 0x04001FFD RID: 8189
	public GameObject FakeMale;

	// Token: 0x04001FFE RID: 8190
	public GameObject Student;

	// Token: 0x04001FFF RID: 8191
	public bool AlreadySpawned;

	// Token: 0x04002000 RID: 8192
	public int CurrentFloor;

	// Token: 0x04002001 RID: 8193
	public int CurrentRow;

	// Token: 0x04002002 RID: 8194
	public int FloorLimit;

	// Token: 0x04002003 RID: 8195
	public int RowLimit;

	// Token: 0x04002004 RID: 8196
	public int StudentIDLimit;

	// Token: 0x04002005 RID: 8197
	public int StudentID;

	// Token: 0x04002006 RID: 8198
	public int Spawned;

	// Token: 0x04002007 RID: 8199
	public int Height;

	// Token: 0x04002008 RID: 8200
	public int NESW;

	// Token: 0x04002009 RID: 8201
	public int ID;

	// Token: 0x0400200A RID: 8202
	public GameObject[] SuspiciousObjects;
}
