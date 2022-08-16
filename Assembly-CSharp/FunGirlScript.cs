// Decompiled with JetBrains decompiler
// Type: FunGirlScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FunGirlScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public GameObject Jukebox;
  public Transform Yandere;
  public UIPanel HUD;
  public float Speed;

  private void Start() => this.ChaseYandereChan();

  private void Update()
  {
    if ((double) this.Speed < 5.0)
      this.Speed += Time.deltaTime * 0.1f;
    else
      this.Speed = 5f;
    this.transform.position = Vector3.MoveTowards(this.transform.position, this.Yandere.position, Time.deltaTime * this.Speed);
    this.transform.LookAt(this.Yandere.position);
    if ((double) Vector3.Distance(this.transform.position, this.Yandere.position) >= 0.5)
      return;
    Application.Quit();
  }

  private void ChaseYandereChan()
  {
    SchoolGlobals.SchoolAtmosphereSet = true;
    SchoolGlobals.SchoolAtmosphere = 0.0f;
    this.StudentManager.SetAtmosphere();
    foreach (StudentScript student in this.StudentManager.Students)
    {
      if ((Object) student != (Object) null)
        student.gameObject.SetActive(false);
    }
    this.StudentManager.Yandere.NoDebug = true;
    this.gameObject.SetActive(true);
    this.Jukebox.SetActive(false);
    this.HUD.enabled = false;
  }
}
