// Decompiled with JetBrains decompiler
// Type: BakeSaleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class BakeSaleScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public GameObject AmaiSuccess;
  public GameObject AmaiFail;
  public Transform MeetSpot;
  public float Timer;
  public int ID = 46;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > 60.0 && (Object) this.StudentManager.Students[this.ID] != (Object) null)
    {
      if (this.StudentManager.Students[this.ID].Routine)
      {
        Debug.Log((object) (this.StudentManager.Students[this.ID].Name + " has decided to go to the bake sale."));
        this.Timer = 0.0f;
        this.StudentManager.Students[this.ID].Meeting = true;
        this.StudentManager.Students[this.ID].BakeSale = true;
        this.StudentManager.Students[this.ID].MeetTime = 0.0001f;
        this.StudentManager.Students[this.ID].MeetSpot = this.MeetSpot;
        this.IncreaseID();
      }
      else
        this.IncreaseID();
    }
    if (this.StudentManager.Yandere.Alerts > 0 || this.StudentManager.Yandere.Police.StudentFoundCorpse)
    {
      this.AmaiFail.SetActive(true);
      if (!Input.GetKeyDown("`"))
        return;
      SceneManager.LoadScene("LoadingScene");
    }
    else
    {
      if (!((Object) this.StudentManager.Students[12] != (Object) null) || !this.StudentManager.Students[12].Ragdoll.Disposed)
        return;
      this.AmaiSuccess.SetActive(true);
    }
  }

  private void IncreaseID()
  {
    ++this.ID;
    if (this.ID <= 89)
      return;
    this.ID = 46;
  }
}
