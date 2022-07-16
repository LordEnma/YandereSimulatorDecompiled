// Decompiled with JetBrains decompiler
// Type: EmergencyExitScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EmergencyExitScript : MonoBehaviour
{
  public StudentScript Student;
  public Transform Yandere;
  public Transform Pivot;
  public float Timer;
  public bool Open;

  private void Update()
  {
    if ((double) Vector3.Distance(this.Yandere.position, this.transform.position) < 2.0)
      this.Open = true;
    else if ((double) this.Timer == 0.0)
    {
      this.Student = (StudentScript) null;
      this.Open = false;
    }
    if (!this.Open)
    {
      this.Pivot.localEulerAngles = new Vector3(this.Pivot.localEulerAngles.x, Mathf.Lerp(this.Pivot.localEulerAngles.y, 0.0f, Time.deltaTime * 10f), this.Pivot.localEulerAngles.z);
    }
    else
    {
      this.Pivot.localEulerAngles = new Vector3(this.Pivot.localEulerAngles.x, Mathf.Lerp(this.Pivot.localEulerAngles.y, 90f, Time.deltaTime * 10f), this.Pivot.localEulerAngles.z);
      this.Timer = Mathf.MoveTowards(this.Timer, 0.0f, Time.deltaTime);
    }
  }

  private void OnTriggerStay(Collider other)
  {
    this.Student = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) this.Student != (Object) null))
      return;
    this.Timer = 1f;
    this.Open = true;
  }
}
