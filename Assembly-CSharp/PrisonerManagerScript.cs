// Decompiled with JetBrains decompiler
// Type: PrisonerManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PrisonerManagerScript : MonoBehaviour
{
  public HomePrisonerChanScript[] Prisoners;
  public Collider[] PrisonerTrigger;
  public Transform[] SpawnPoints;
  public Transform[] Destination;
  public Transform[] Target;
  public UILabel[] PrisonerLabel;
  public GameObject[] Boxes;
  public string[] IdleAnims;
  public Vector3 OriginalDestination;
  public Vector3 OriginalTarget;
  public HomeYandereScript Yandere;
  public GameObject Student;
  public int PrisonersToSpawn;
  public int PrisonersSpawned;
  public int ChosenPrisoner;
  public int StudentID;

  private void Start()
  {
    this.OriginalDestination = this.Destination[0].transform.position;
    this.OriginalTarget = this.Target[0].transform.position;
    for (int index = 1; index < this.Boxes.Length; ++index)
      this.Boxes[index].SetActive(true);
    this.ShufflePrisoners();
    if (StudentGlobals.Prisoner1 > 0)
      ++this.PrisonersToSpawn;
    if (StudentGlobals.Prisoner2 > 0)
      ++this.PrisonersToSpawn;
    if (StudentGlobals.Prisoner3 > 0)
      ++this.PrisonersToSpawn;
    if (StudentGlobals.Prisoner4 > 0)
      ++this.PrisonersToSpawn;
    if (StudentGlobals.Prisoner5 > 0)
      ++this.PrisonersToSpawn;
    if (StudentGlobals.Prisoner6 > 0)
      ++this.PrisonersToSpawn;
    if (StudentGlobals.Prisoner7 > 0)
      ++this.PrisonersToSpawn;
    if (StudentGlobals.Prisoner8 > 0)
      ++this.PrisonersToSpawn;
    if (StudentGlobals.Prisoner9 > 0)
      ++this.PrisonersToSpawn;
    if (StudentGlobals.Prisoner10 > 0)
      ++this.PrisonersToSpawn;
    for (this.PrisonersToSpawn = StudentGlobals.Prisoners; this.PrisonersToSpawn > this.PrisonersSpawned; ++this.PrisonersSpawned)
    {
      if (this.PrisonersSpawned > 0)
      {
        Debug.Log((object) "Spawning a prisoner!");
        GameObject gameObject = Object.Instantiate<GameObject>(this.Student, this.SpawnPoints[this.PrisonersSpawned + 1].position, this.SpawnPoints[this.PrisonersSpawned + 1].rotation);
        HomePrisonerChanScript component1 = gameObject.GetComponent<HomePrisonerChanScript>();
        component1.PrisonerID = this.PrisonersSpawned + 1;
        component1.IdleAnim = this.IdleAnims[component1.PrisonerID];
        this.Prisoners[this.PrisonersSpawned + 1] = component1;
        StudentScript component2 = gameObject.GetComponent<StudentScript>();
        component2.enabled = false;
        if (this.PrisonersSpawned == 0)
          component2.StudentID = StudentGlobals.Prisoner1;
        else if (this.PrisonersSpawned == 1)
          component2.StudentID = StudentGlobals.Prisoner2;
        else if (this.PrisonersSpawned == 2)
          component2.StudentID = StudentGlobals.Prisoner3;
        else if (this.PrisonersSpawned == 3)
          component2.StudentID = StudentGlobals.Prisoner4;
        else if (this.PrisonersSpawned == 4)
          component2.StudentID = StudentGlobals.Prisoner5;
        else if (this.PrisonersSpawned == 5)
          component2.StudentID = StudentGlobals.Prisoner6;
        else if (this.PrisonersSpawned == 6)
          component2.StudentID = StudentGlobals.Prisoner7;
        else if (this.PrisonersSpawned == 7)
          component2.StudentID = StudentGlobals.Prisoner8;
        else if (this.PrisonersSpawned == 8)
          component2.StudentID = StudentGlobals.Prisoner9;
        else if (this.PrisonersSpawned == 9)
          component2.StudentID = StudentGlobals.Prisoner10;
        component2.Cosmetic.StudentID = component2.StudentID;
        component2.Cosmetic.Start();
      }
      this.Boxes[this.PrisonersSpawned + 1].SetActive(false);
    }
  }

  private void Update()
  {
    int index1 = 0;
    for (int index2 = 1; index2 < this.PrisonersSpawned + 1; ++index2)
    {
      if ((double) Vector3.Distance(this.Yandere.transform.position, this.Prisoners[index2].transform.position) < 1.0)
      {
        this.PrisonerLabel[1].text = "Prisoner # " + index2.ToString();
        index1 = index2;
      }
    }
    this.ChosenPrisoner = index1;
    if (index1 > 0)
    {
      this.PrisonerLabel[1].alpha = Mathf.MoveTowards(this.PrisonerLabel[1].alpha, 1f, Time.deltaTime * 2f);
      this.PrisonerLabel[1].transform.position = this.Prisoners[index1].Cosmetic.Student.Head.position + Vector3.up * 0.5f;
      this.PrisonerLabel[1].transform.LookAt(Camera.main.transform.position);
      this.PrisonerLabel[1].transform.Translate(this.PrisonerLabel[1].transform.right * -0.1f);
      this.PrisonerLabel[1].transform.eulerAngles += new Vector3(0.0f, 180f, 0.0f);
      this.PrisonerTrigger[0].transform.position = this.Yandere.transform.position;
      this.PrisonerTrigger[1].transform.position = this.Yandere.transform.position;
      if (this.ChosenPrisoner > 1)
      {
        this.Target[0].transform.position = this.Prisoners[index1].Cosmetic.Student.Head.position;
        this.Target[1].transform.position = this.Prisoners[index1].Cosmetic.Student.Head.position;
        if (this.ChosenPrisoner > 7)
          this.Destination[0].transform.position = this.Prisoners[this.ChosenPrisoner].transform.position + this.Prisoners[this.ChosenPrisoner].transform.forward * 1.5f + Vector3.up * 1f;
        else if (this.ChosenPrisoner > 5)
          this.Destination[0].transform.position = this.Prisoners[this.ChosenPrisoner].transform.position + this.Prisoners[this.ChosenPrisoner].transform.forward * -0.5f + Vector3.up * 1.5f;
        else if (this.ChosenPrisoner > 3)
          this.Destination[0].transform.position = this.Prisoners[this.ChosenPrisoner].transform.position + this.Prisoners[this.ChosenPrisoner].transform.forward * 1.5f + Vector3.up * 0.5f;
        else
          this.Destination[0].transform.position = this.Prisoners[this.ChosenPrisoner].transform.position + this.Prisoners[this.ChosenPrisoner].transform.right * 1.5f + Vector3.up * 1f;
        this.Destination[1].transform.position = this.Destination[0].transform.position;
      }
      else
      {
        this.Target[0].transform.position = this.OriginalTarget;
        this.Destination[0].transform.position = this.OriginalDestination;
        this.Target[1].transform.position = this.OriginalTarget;
        this.Destination[1].transform.position = this.OriginalDestination;
      }
      if (!this.Yandere.CanMove)
        this.PrisonerLabel[1].alpha = 0.0f;
      if (this.ChosenPrisoner == 1)
        this.StudentID = StudentGlobals.Prisoner1;
      else if (this.ChosenPrisoner == 2)
        this.StudentID = StudentGlobals.Prisoner2;
      else if (this.ChosenPrisoner == 3)
        this.StudentID = StudentGlobals.Prisoner3;
      else if (this.ChosenPrisoner == 4)
        this.StudentID = StudentGlobals.Prisoner4;
      else if (this.ChosenPrisoner == 5)
        this.StudentID = StudentGlobals.Prisoner5;
      else if (this.ChosenPrisoner == 6)
        this.StudentID = StudentGlobals.Prisoner6;
      else if (this.ChosenPrisoner == 7)
        this.StudentID = StudentGlobals.Prisoner7;
      else if (this.ChosenPrisoner == 8)
        this.StudentID = StudentGlobals.Prisoner8;
      else if (this.ChosenPrisoner == 9)
        this.StudentID = StudentGlobals.Prisoner9;
      else if (this.ChosenPrisoner == 10)
        this.StudentID = StudentGlobals.Prisoner10;
    }
    else
    {
      this.PrisonerLabel[1].alpha = Mathf.MoveTowards(this.PrisonerLabel[1].alpha, 0.0f, Time.deltaTime * 2f);
      this.PrisonerTrigger[0].transform.position = new Vector3(100f, 100f, 100f);
      this.PrisonerTrigger[1].transform.position = new Vector3(100f, 100f, 100f);
    }
    this.PrisonerLabel[0].text = this.PrisonerLabel[1].text;
    this.PrisonerLabel[0].alpha = this.PrisonerLabel[1].alpha;
    this.PrisonerLabel[0].transform.position = this.PrisonerLabel[1].transform.position;
    this.PrisonerLabel[0].transform.rotation = this.PrisonerLabel[1].transform.rotation;
  }

  private void ShufflePrisoners()
  {
    if (StudentGlobals.Prisoners <= 0)
      return;
    Debug.Log((object) ("We're supposed to have " + StudentGlobals.Prisoners.ToString() + " prisoners in our basement. Checking if we need to shuffle 'em..."));
    int num = 0;
    if (StudentGlobals.Prisoner1 == 0 && StudentGlobals.Prisoners > 0)
    {
      StudentGlobals.Prisoner1 = StudentGlobals.Prisoner2;
      StudentGlobals.Prisoner2 = StudentGlobals.Prisoner3;
      StudentGlobals.Prisoner3 = StudentGlobals.Prisoner4;
      StudentGlobals.Prisoner4 = StudentGlobals.Prisoner5;
      StudentGlobals.Prisoner5 = StudentGlobals.Prisoner6;
      StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
      StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
      StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
      StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
      StudentGlobals.Prisoner10 = 0;
      ++num;
    }
    if (StudentGlobals.Prisoner2 == 0 && StudentGlobals.Prisoners > 1)
    {
      StudentGlobals.Prisoner2 = StudentGlobals.Prisoner3;
      StudentGlobals.Prisoner3 = StudentGlobals.Prisoner4;
      StudentGlobals.Prisoner4 = StudentGlobals.Prisoner5;
      StudentGlobals.Prisoner5 = StudentGlobals.Prisoner6;
      StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
      StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
      StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
      StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
      StudentGlobals.Prisoner10 = 0;
      ++num;
    }
    if (StudentGlobals.Prisoner3 == 0 && StudentGlobals.Prisoners > 2)
    {
      StudentGlobals.Prisoner3 = StudentGlobals.Prisoner4;
      StudentGlobals.Prisoner4 = StudentGlobals.Prisoner5;
      StudentGlobals.Prisoner5 = StudentGlobals.Prisoner6;
      StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
      StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
      StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
      StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
      StudentGlobals.Prisoner10 = 0;
      ++num;
    }
    if (StudentGlobals.Prisoner4 == 0 && StudentGlobals.Prisoners > 3)
    {
      StudentGlobals.Prisoner4 = StudentGlobals.Prisoner5;
      StudentGlobals.Prisoner5 = StudentGlobals.Prisoner6;
      StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
      StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
      StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
      StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
      StudentGlobals.Prisoner10 = 0;
      ++num;
    }
    if (StudentGlobals.Prisoner5 == 0 && StudentGlobals.Prisoners > 4)
    {
      StudentGlobals.Prisoner5 = StudentGlobals.Prisoner6;
      StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
      StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
      StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
      StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
      StudentGlobals.Prisoner10 = 0;
      ++num;
    }
    if (StudentGlobals.Prisoner6 == 0 && StudentGlobals.Prisoners > 5)
    {
      StudentGlobals.Prisoner6 = StudentGlobals.Prisoner7;
      StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
      StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
      StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
      StudentGlobals.Prisoner10 = 0;
      ++num;
    }
    if (StudentGlobals.Prisoner7 == 0 && StudentGlobals.Prisoners > 6)
    {
      StudentGlobals.Prisoner7 = StudentGlobals.Prisoner8;
      StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
      StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
      StudentGlobals.Prisoner10 = 0;
      ++num;
    }
    if (StudentGlobals.Prisoner8 == 0 && StudentGlobals.Prisoners > 7)
    {
      StudentGlobals.Prisoner8 = StudentGlobals.Prisoner9;
      StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
      StudentGlobals.Prisoner10 = 0;
      ++num;
    }
    if (StudentGlobals.Prisoner9 == 0 && StudentGlobals.Prisoners > 8)
    {
      StudentGlobals.Prisoner9 = StudentGlobals.Prisoner10;
      StudentGlobals.Prisoner10 = 0;
      ++num;
    }
    if (num <= 0)
      return;
    Debug.Log((object) "Yeah, we needed to shuffle 'em!");
    this.ShufflePrisoners();
  }
}
