// Decompiled with JetBrains decompiler
// Type: PlaceholderStudentScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    this.Target = Object.Instantiate<GameObject>(this.EmptyGameObject).transform;
    this.ChooseNewDestination();
  }

  private void Update()
  {
    this.transform.LookAt(this.Target.position);
    this.transform.position = Vector3.MoveTowards(this.transform.position, this.Target.position, Time.deltaTime);
    if ((double) Vector3.Distance(this.transform.position, this.Target.position) < 1.0)
      this.ChooseNewDestination();
    if (Input.GetKeyDown("space"))
    {
      if (!this.ShootRaycasts)
        this.ShootRaycasts = true;
      else
        ++this.Phase;
    }
    if ((double) this.transform.position.y >= 1.0 || !this.ShootRaycasts)
      return;
    if (this.Phase == 0)
    {
      Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[0].transform.position, Color.red);
      Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[1].transform.position, Color.red);
      Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[2].transform.position, Color.red);
    }
    else
    {
      if (this.StudentID >= this.FakeStudentSpawner.StudentID + 5 || this.StudentID <= this.FakeStudentSpawner.StudentID - 5)
        return;
      if ((double) Vector3.Distance(this.transform.position, this.FakeStudentSpawner.SuspiciousObjects[0].transform.position) < 5.0)
        Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[0].transform.position, Color.red);
      if ((double) Vector3.Distance(this.transform.position, this.FakeStudentSpawner.SuspiciousObjects[1].transform.position) < 5.0)
        Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[1].transform.position, Color.red);
      if ((double) Vector3.Distance(this.transform.position, this.FakeStudentSpawner.SuspiciousObjects[2].transform.position) >= 5.0)
        return;
      Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[2].transform.position, Color.red);
    }
  }

  private void ChooseNewDestination()
  {
    if (this.NESW == 1)
      this.Target.position = new Vector3(Random.Range(-21f, 21f), this.transform.position.y, Random.Range(21f, 19f));
    else if (this.NESW == 2)
      this.Target.position = new Vector3(Random.Range(19f, 21f), this.transform.position.y, Random.Range(29f, -37f));
    else if (this.NESW == 3)
    {
      this.Target.position = new Vector3(Random.Range(-21f, 21f), this.transform.position.y, Random.Range(-21f, -19f));
    }
    else
    {
      if (this.NESW != 4)
        return;
      this.Target.position = new Vector3(Random.Range(-19f, -21f), this.transform.position.y, Random.Range(29f, -37f));
    }
  }
}
