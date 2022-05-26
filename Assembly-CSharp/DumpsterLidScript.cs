// Decompiled with JetBrains decompiler
// Type: DumpsterLidScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DumpsterLidScript : MonoBehaviour
{
  public StudentScript Victim;
  public Transform SlideLocation;
  public Transform GarbageDebris;
  public Transform Hinge;
  public GameObject FallChecker;
  public GameObject Corpse;
  public PromptScript[] DragPrompts;
  public PromptScript Prompt;
  public float DisposalSpot;
  public float Rotation;
  public bool Slide;
  public bool Fill;
  public bool Open;
  public int StudentToGoMissing;

  private void Start()
  {
    this.FallChecker.SetActive(false);
    this.Prompt.HideButton[3] = true;
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Open)
      {
        this.Prompt.Label[0].text = "     Close";
        this.Open = true;
      }
      else
      {
        this.Prompt.Label[0].text = "     Open";
        this.Open = false;
      }
    }
    if (!this.Open)
    {
      this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 10f);
      this.Prompt.HideButton[3] = true;
    }
    else
    {
      this.Rotation = Mathf.Lerp(this.Rotation, -115f, Time.deltaTime * 10f);
      this.Prompt.HideButton[3] = !((Object) this.Corpse != (Object) null) || !((Object) this.Prompt.Yandere.PickUp != (Object) null) || !this.Prompt.Yandere.PickUp.Garbage;
      if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
      {
        Object.Destroy((Object) this.Prompt.Yandere.PickUp.gameObject);
        this.Prompt.Circle[3].fillAmount = 1f;
        this.Prompt.HideButton[3] = false;
        this.Fill = true;
      }
      if ((double) this.transform.position.z > (double) this.DisposalSpot - 0.0500000007450581 && (double) this.transform.position.z < (double) this.DisposalSpot + 0.0500000007450581)
        this.FallChecker.SetActive(this.Prompt.Yandere.RoofPush);
      else
        this.FallChecker.SetActive(false);
      if (this.Slide)
      {
        this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, this.SlideLocation.eulerAngles, Time.deltaTime * 10f);
        this.transform.position = Vector3.Lerp(this.transform.position, this.SlideLocation.position, Time.deltaTime * 10f);
        this.Corpse.GetComponent<RagdollScript>().Student.Hips.position = this.transform.position + new Vector3(0.0f, 1f, 0.0f);
        if ((double) Vector3.Distance(this.transform.position, this.SlideLocation.position) < 0.00999999977648258)
        {
          this.DragPrompts[0].enabled = false;
          this.DragPrompts[1].enabled = false;
          this.FallChecker.SetActive(false);
          this.Slide = false;
        }
      }
    }
    this.Hinge.localEulerAngles = new Vector3(this.Rotation, 0.0f, 0.0f);
    if (!this.Fill)
      return;
    this.GarbageDebris.localPosition = new Vector3(this.GarbageDebris.localPosition.x, Mathf.Lerp(this.GarbageDebris.localPosition.y, 1f, Time.deltaTime * 10f), this.GarbageDebris.localPosition.z);
    if ((double) this.GarbageDebris.localPosition.y <= 0.990000009536743)
      return;
    this.Prompt.Yandere.Police.SuicideScene = false;
    this.Prompt.Yandere.Police.Suicide = false;
    if (!this.Corpse.GetComponent<RagdollScript>().Concealed)
      --this.Prompt.Yandere.Police.HiddenCorpses;
    --this.Prompt.Yandere.Police.Corpses;
    if (this.Corpse.GetComponent<RagdollScript>().AddingToCount)
      --this.Prompt.Yandere.NearBodies;
    this.GarbageDebris.localPosition = new Vector3(this.GarbageDebris.localPosition.x, 1f, this.GarbageDebris.localPosition.z);
    this.StudentToGoMissing = this.Corpse.GetComponent<StudentScript>().StudentID;
    this.Corpse.gameObject.SetActive(false);
    this.Fill = false;
    this.Prompt.Yandere.StudentManager.UpdateStudents();
  }

  public void SetVictimMissing() => StudentGlobals.SetStudentMissing(this.StudentToGoMissing, true);
}
