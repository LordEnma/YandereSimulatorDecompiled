// Decompiled with JetBrains decompiler
// Type: TaskManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TaskManagerScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public YandereScript Yandere;
  public Transform MuddyFootprintParent;
  public GameObject[] TaskObjects;
  public PromptScript[] Prompts;
  public bool[] GirlsQuestioned;
  public GameObject FixedDummy;
  public int[] TaskStatus;
  public bool Initialized;

  public void Start()
  {
    for (int taskID = 1; taskID < 101; ++taskID)
      this.TaskStatus[taskID] = TaskGlobals.GetTaskStatus(taskID);
    for (int index = 1; index < this.TaskObjects.Length; ++index)
    {
      if ((Object) this.TaskObjects[index] != (Object) null)
        this.TaskObjects[index].SetActive(false);
    }
    if (this.TaskStatus[46] == 1)
    {
      TaskGlobals.SetTaskStatus(46, 0);
      this.TaskStatus[46] = 0;
    }
    if ((Object) this.StudentManager != (Object) null)
      this.UpdateTaskStatus();
    this.Initialized = true;
  }

  public void CheckTaskPickups()
  {
    if (this.StudentManager.Eighties)
      return;
    if (this.TaskStatus[11] == 1 && (Object) this.Prompts[11].Circle[3] != (Object) null && (double) this.Prompts[11].Circle[3].fillAmount == 0.0)
    {
      if ((Object) this.StudentManager.Students[11] != (Object) null)
        this.StudentManager.Students[11].TaskPhase = 5;
      this.Yandere.NotificationManager.TopicName = "Cats";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
      this.StudentManager.SetTopicLearnedByStudent(15, 11, true);
      this.TaskStatus[11] = 2;
      Object.Destroy((Object) this.TaskObjects[11]);
    }
    if (this.TaskStatus[25] == 1 && (double) this.Prompts[25].Circle[3].fillAmount == 0.0)
    {
      if ((Object) this.StudentManager.Students[25] != (Object) null)
        this.StudentManager.Students[25].TaskPhase = 5;
      this.TaskStatus[25] = 2;
      Object.Destroy((Object) this.TaskObjects[25]);
    }
    if (this.TaskStatus[37] != 1 || !((Object) this.Prompts[37].Circle[3] != (Object) null) || (double) this.Prompts[37].Circle[3].fillAmount != 0.0)
      return;
    if ((Object) this.StudentManager.Students[37] != (Object) null)
      this.StudentManager.Students[37].TaskPhase = 5;
    this.TaskStatus[37] = 2;
    Object.Destroy((Object) this.TaskObjects[37]);
  }

  public void UpdateTaskStatus()
  {
    if (!this.StudentManager.Eighties)
    {
      if (this.TaskStatus[8] == 1 && (Object) this.StudentManager.Students[8] != (Object) null)
      {
        if (this.StudentManager.Students[8].TaskPhase == 0)
          this.StudentManager.Students[8].TaskPhase = 4;
        if (this.Yandere.Inventory.Soda)
          this.StudentManager.Students[8].TaskPhase = 5;
      }
      if (this.TaskStatus[11] == 1)
      {
        if ((Object) this.StudentManager.Students[11] != (Object) null)
        {
          if (this.StudentManager.Students[11].TaskPhase == 0)
            this.StudentManager.Students[11].TaskPhase = 4;
          this.TaskObjects[11].SetActive(true);
        }
      }
      else if ((Object) this.TaskObjects[11] != (Object) null)
        this.TaskObjects[11].SetActive(false);
      if (this.TaskStatus[25] == 1)
      {
        if ((Object) this.StudentManager.Students[25] != (Object) null)
        {
          if (this.StudentManager.Students[25].TaskPhase == 0)
            this.StudentManager.Students[25].TaskPhase = 4;
          this.TaskObjects[25].SetActive(true);
        }
      }
      else if ((Object) this.TaskObjects[25] != (Object) null)
        this.TaskObjects[25].SetActive(false);
      if (this.TaskStatus[28] == 1 && (Object) this.StudentManager.Students[28] != (Object) null)
      {
        if (this.StudentManager.Students[28].TaskPhase == 0)
          this.StudentManager.Students[28].TaskPhase = 4;
        for (int photoID = 1; photoID < 26; ++photoID)
        {
          if (TaskGlobals.GetKittenPhoto(photoID))
          {
            Debug.Log((object) "Riku's Task can be turned in.");
            this.StudentManager.Students[28].TaskPhase = 5;
          }
        }
      }
      if (this.TaskStatus[30] == 1 && (Object) this.StudentManager.Students[30] != (Object) null && this.StudentManager.Students[30].TaskPhase == 0)
        this.StudentManager.Students[30].TaskPhase = 4;
      if (this.TaskStatus[36] == 1 && (Object) this.StudentManager.Students[36] != (Object) null)
      {
        if (this.StudentManager.Students[36].TaskPhase == 0)
          this.StudentManager.Students[36].TaskPhase = 4;
        if (this.GirlsQuestioned[1] && this.GirlsQuestioned[2] && this.GirlsQuestioned[3] && this.GirlsQuestioned[4] && this.GirlsQuestioned[5])
        {
          Debug.Log((object) "Gema's task should be ready to turn in!");
          this.StudentManager.Students[36].TaskPhase = 5;
        }
      }
      if (this.TaskStatus[37] == 1)
      {
        if ((Object) this.StudentManager.Students[37] != (Object) null)
        {
          if (this.StudentManager.Students[37].TaskPhase == 0)
            this.StudentManager.Students[37].TaskPhase = 4;
          this.TaskObjects[37].SetActive(true);
        }
      }
      else if ((Object) this.TaskObjects[37] != (Object) null)
        this.TaskObjects[37].SetActive(false);
      if (this.TaskStatus[38] == 1)
      {
        if ((Object) this.StudentManager.Students[38] != (Object) null && this.StudentManager.Students[38].TaskPhase == 0)
          this.StudentManager.Students[38].TaskPhase = 4;
      }
      else if (this.TaskStatus[38] == 2 && (Object) this.StudentManager.Students[38] != (Object) null)
        this.StudentManager.Students[38].TaskPhase = 5;
      if (this.TaskStatus[46] == 1 && (Object) this.StudentManager.Students[46] != (Object) null)
      {
        if (this.StudentManager.Students[46].TaskPhase == 0)
          this.StudentManager.Students[46].TaskPhase = 4;
        if ((Object) this.StudentManager.Students[10] != (Object) null && (double) Vector3.Distance(this.StudentManager.Students[46].transform.position, this.StudentManager.Students[10].transform.position) < 2.0)
        {
          Debug.Log((object) "Budo's task should be ready to turn in!");
          this.StudentManager.Students[46].TaskPhase = 5;
        }
      }
      if (this.TaskStatus[47] == 1 && (Object) this.StudentManager.Students[47] != (Object) null)
      {
        if (this.StudentManager.Students[47].TaskPhase == 0)
          this.StudentManager.Students[47].TaskPhase = 4;
        if (this.StudentManager.CombatMinigame.PracticeWindow.DefeatedSho)
        {
          Debug.Log((object) "Sho's task should be ready to turn in!");
          this.StudentManager.Students[47].TaskPhase = 5;
        }
      }
      if (this.TaskStatus[48] == 1 && (Object) this.StudentManager.Students[48] != (Object) null)
      {
        if (this.StudentManager.Students[48].TaskPhase == 0)
          this.StudentManager.Students[48].TaskPhase = 4;
        this.Yandere.WeaponManager.DumbbellCheck(48);
        if (this.Yandere.WeaponManager.DumbbellNear)
        {
          Debug.Log((object) "Juku's task should be ready to turn in!");
          this.StudentManager.Students[48].TaskPhase = 5;
        }
      }
      if (this.TaskStatus[49] == 1 && (Object) this.StudentManager.Students[49] != (Object) null)
      {
        if (this.StudentManager.Students[49].TaskPhase == 0)
          this.StudentManager.Students[49].TaskPhase = 4;
        if (this.MuddyFootprintParent.childCount == 0)
        {
          Debug.Log((object) "Mina's task should be ready to turn in!");
          this.StudentManager.Students[49].TaskPhase = 5;
        }
      }
      if (this.TaskStatus[50] == 1 && (Object) this.StudentManager.Students[50] != (Object) null)
      {
        if (this.StudentManager.Students[50].TaskPhase == 0)
          this.StudentManager.Students[50].TaskPhase = 4;
        if (this.FixedDummy.activeInHierarchy)
        {
          Debug.Log((object) "Shima's task should be ready to turn in!");
          this.StudentManager.Students[50].TaskPhase = 5;
        }
      }
      if (ClubGlobals.GetClubClosed(ClubType.LightMusic) || (Object) this.StudentManager.Students[51] == (Object) null)
      {
        if ((Object) this.StudentManager.Students[52] != (Object) null)
          this.StudentManager.Students[52].TaskPhase = 100;
        this.TaskStatus[52] = 100;
      }
      else if (this.TaskStatus[52] == 1 && (Object) this.StudentManager.Students[52] != (Object) null)
      {
        this.StudentManager.Students[52].TaskPhase = 4;
        for (int photoID = 1; photoID < 52; ++photoID)
        {
          if (TaskGlobals.GetGuitarPhoto(photoID))
            this.StudentManager.Students[52].TaskPhase = 5;
        }
      }
      if (this.TaskStatus[81] != 1 || !((Object) this.StudentManager.Students[81] != (Object) null))
        return;
      if (this.StudentManager.Students[81].TaskPhase == 0)
        this.StudentManager.Students[81].TaskPhase = 4;
      for (int photoID = 1; photoID < 26; ++photoID)
      {
        if (TaskGlobals.GetHorudaPhoto(photoID))
        {
          Debug.Log((object) "Musume's Task can be turned in.");
          this.StudentManager.Students[81].TaskPhase = 5;
        }
      }
    }
    else
    {
      if (this.TaskStatus[79] != 1 || !((Object) this.StudentManager.Students[79] != (Object) null))
        return;
      Debug.Log((object) "Telling Yakuza's litle brother to change his destination.");
      ScheduleBlock scheduleBlock1 = this.StudentManager.Students[79].ScheduleBlocks[6];
      scheduleBlock1.destination = "Wait";
      scheduleBlock1.action = "Wait";
      ScheduleBlock scheduleBlock2 = this.StudentManager.Students[79].ScheduleBlocks[7];
      scheduleBlock2.destination = "Wait";
      scheduleBlock2.action = "Wait";
      this.StudentManager.Students[79].GetDestinations();
    }
  }

  public void SaveTaskStatuses()
  {
    for (int index = 1; index < 101; ++index)
    {
      TaskGlobals.SetTaskStatus(index, this.TaskStatus[index]);
      if ((Object) this.StudentManager.Students[index] != (Object) null)
        PlayerGlobals.SetStudentFriend(index, this.StudentManager.Students[index].Friend);
    }
  }
}
