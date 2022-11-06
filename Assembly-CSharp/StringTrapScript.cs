// Decompiled with JetBrains decompiler
// Type: StringTrapScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StringTrapScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public WaterCoolerScript WaterCooler;
  public GameObject BrownPaintPuddle;
  public GameObject GasolinePuddle;
  public GameObject BloodPuddle;
  public GameObject WaterPuddle;
  public GameObject BrownPaint;
  public GameObject Gasoline;
  public GameObject Blood;
  public GameObject Water;
  public GameObject Puddle;
  public Transform[] PuddleSpawn;
  public Transform Spawn;

  private void Update()
  {
    if (!this.WaterCooler.Gasoline || !((Object) this.StudentManager.Students[this.StudentManager.RivalID] != (Object) null) || this.StudentManager.Students[this.StudentManager.RivalID].GasWarned)
      return;
    StudentScript follower = this.StudentManager.Students[this.StudentManager.RivalID].Follower;
    if (!((Object) follower != (Object) null) || !follower.Alive || follower.CurrentAction != StudentActionType.Follow || (double) Vector3.Distance(this.StudentManager.Students[this.StudentManager.RivalID].transform.position, follower.transform.position) >= 10.0 || (double) Vector3.Distance(this.transform.position, this.StudentManager.Students[this.StudentManager.RivalID].transform.position) >= 10.0)
      return;
    this.WaterCooler.Prompt.Yandere.Subtitle.UpdateLabel(SubtitleType.GasWarning, 1, 5f);
    this.StudentManager.Students[this.StudentManager.RivalID].GasWarned = true;
  }

  private void OnTriggerStay(Collider other)
  {
    if (other.gameObject.layer != 9)
      return;
    Debug.Log((object) "A character just came into contact with a tripwire trap!");
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null) || component.ClubActivityPhase >= 16)
      return;
    if (component.Club == ClubType.Council || (Object) component != (Object) null && component.Teacher || component.WillRemoveTripwire || component.GasWarned)
    {
      this.WaterCooler.Yandere.NotificationManager.CustomText = component.Name + " dismantled tripwire trap!";
      this.WaterCooler.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      if (component.WillRemoveTripwire)
      {
        this.WaterCooler.Yandere.Subtitle.CustomText = "Let's get rid of this real quick...";
        this.WaterCooler.Yandere.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
        component.WillRemoveTripwire = false;
      }
      else
      {
        this.WaterCooler.Yandere.Subtitle.CustomText = "Someone tried to pull a prank? How childish...";
        this.WaterCooler.Yandere.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
      }
      this.transform.parent.gameObject.SetActive(false);
      this.WaterCooler.Prompt.HideButton[3] = false;
      this.WaterCooler.PickUp.enabled = true;
      this.WaterCooler.Prompt.enabled = true;
      this.WaterCooler.TrapSet = false;
      this.WaterCooler.Prompt.Label[1].text = "     Create Tripwire Trap";
      this.WaterCooler.Prompt.Label[1].applyGradient = false;
      this.WaterCooler.Prompt.Label[1].color = Color.red;
    }
    else
    {
      if (this.WaterCooler.BrownPaint)
      {
        Object.Instantiate<GameObject>(this.BrownPaint, this.Spawn.position, this.WaterCooler.transform.rotation);
        this.Puddle = this.BrownPaintPuddle;
      }
      else if (this.WaterCooler.Blood)
      {
        Object.Instantiate<GameObject>(this.Blood, this.Spawn.position, this.WaterCooler.transform.rotation);
        this.Puddle = this.BloodPuddle;
      }
      else if (this.WaterCooler.Gasoline)
      {
        Object.Instantiate<GameObject>(this.Gasoline, this.Spawn.position, this.WaterCooler.transform.rotation);
        this.Puddle = this.GasolinePuddle;
      }
      else
      {
        Object.Instantiate<GameObject>(this.Water, this.Spawn.position, this.WaterCooler.transform.rotation);
        this.Puddle = this.WaterPuddle;
      }
      GameObject gameObject1 = Object.Instantiate<GameObject>(this.Puddle, this.PuddleSpawn[1].position, Quaternion.identity);
      GameObject gameObject2 = Object.Instantiate<GameObject>(this.Puddle, this.PuddleSpawn[2].position, Quaternion.identity);
      GameObject gameObject3 = Object.Instantiate<GameObject>(this.Puddle, this.PuddleSpawn[3].position, Quaternion.identity);
      gameObject1.transform.eulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
      gameObject2.transform.eulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
      gameObject3.transform.eulerAngles = new Vector3(90f, Random.Range(0.0f, 360f), 0.0f);
      if (this.WaterCooler.Blood)
      {
        gameObject1.transform.parent = this.WaterCooler.Yandere.Police.BloodParent;
        gameObject2.transform.parent = this.WaterCooler.Yandere.Police.BloodParent;
        gameObject3.transform.parent = this.WaterCooler.Yandere.Police.BloodParent;
      }
      else
      {
        gameObject1.transform.parent = this.WaterCooler.Yandere.StudentManager.PuddleParent.transform;
        gameObject2.transform.parent = this.WaterCooler.Yandere.StudentManager.PuddleParent.transform;
        gameObject3.transform.parent = this.WaterCooler.Yandere.StudentManager.PuddleParent.transform;
      }
      this.WaterCooler.Prompt.enabled = true;
      this.WaterCooler.BrownPaint = false;
      this.WaterCooler.Blood = false;
      this.WaterCooler.Gasoline = false;
      this.WaterCooler.Water = false;
      this.WaterCooler.TrapSet = false;
      this.WaterCooler.Empty = true;
      this.WaterCooler.Timer = 1f;
      this.WaterCooler.Prompt.Label[1].text = "     Create Tripwire Trap";
      this.WaterCooler.Prompt.Label[1].applyGradient = false;
      this.WaterCooler.Prompt.Label[1].color = Color.red;
      this.transform.parent.gameObject.SetActive(false);
      this.WaterCooler.Prompt.HideButton[3] = false;
      this.WaterCooler.PickUp.enabled = true;
      this.WaterCooler.MyRigidbody.isKinematic = false;
    }
  }
}
