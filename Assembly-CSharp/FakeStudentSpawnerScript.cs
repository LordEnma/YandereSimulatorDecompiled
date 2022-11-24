// Decompiled with JetBrains decompiler
// Type: FakeStudentSpawnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FakeStudentSpawnerScript : MonoBehaviour
{
  public Transform FakeStudentParent;
  public GameObject NewStudent;
  public GameObject FakeFemale;
  public GameObject FakeMale;
  public GameObject Student;
  public bool AlreadySpawned;
  public int CurrentFloor;
  public int CurrentRow;
  public int FloorLimit;
  public int RowLimit;
  public int StudentIDLimit;
  public int StudentID;
  public int Spawned;
  public int Height;
  public int NESW;
  public int ID;
  public GameObject[] SuspiciousObjects;

  public void Spawn()
  {
    if (!this.AlreadySpawned)
    {
      this.Student = this.FakeFemale;
      this.NESW = 1;
      while (this.Spawned < 100)
      {
        if (this.NESW == 1)
          this.NewStudent = Object.Instantiate<GameObject>(this.Student, new Vector3(Random.Range(-21f, 21f), (float) this.Height, Random.Range(21f, 19f)), Quaternion.identity);
        else if (this.NESW == 2)
          this.NewStudent = Object.Instantiate<GameObject>(this.Student, new Vector3(Random.Range(19f, 21f), (float) this.Height, Random.Range(29f, -37f)), Quaternion.identity);
        else if (this.NESW == 3)
          this.NewStudent = Object.Instantiate<GameObject>(this.Student, new Vector3(Random.Range(-21f, 21f), (float) this.Height, Random.Range(-21f, -19f)), Quaternion.identity);
        else if (this.NESW == 4)
          this.NewStudent = Object.Instantiate<GameObject>(this.Student, new Vector3(Random.Range(-19f, -21f), (float) this.Height, Random.Range(29f, -37f)), Quaternion.identity);
        ++this.StudentID;
        this.NewStudent.GetComponent<PlaceholderStudentScript>().FakeStudentSpawner = this;
        this.NewStudent.GetComponent<PlaceholderStudentScript>().StudentID = this.StudentID;
        this.NewStudent.GetComponent<PlaceholderStudentScript>().NESW = this.NESW;
        this.NewStudent.transform.parent = this.FakeStudentParent;
        ++this.CurrentFloor;
        ++this.CurrentRow;
        ++this.Spawned;
        if (this.CurrentFloor == this.FloorLimit)
        {
          this.CurrentFloor = 0;
          this.Height += 4;
        }
        if (this.CurrentRow == this.RowLimit)
        {
          this.CurrentRow = 0;
          ++this.NESW;
          if (this.NESW > 4)
            this.NESW = 1;
        }
        this.Student = (Object) this.Student == (Object) this.FakeFemale ? this.FakeMale : this.FakeFemale;
      }
      this.StudentIDLimit = this.StudentID;
      this.StudentID = 1;
      this.AlreadySpawned = true;
    }
    else
      this.FakeStudentParent.gameObject.SetActive(!this.FakeStudentParent.gameObject.activeInHierarchy);
  }
}
