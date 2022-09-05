// Decompiled with JetBrains decompiler
// Type: YandereShoeLockerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YandereShoeLockerScript : MonoBehaviour
{
  public PromptScript Prompt;
  public YandereScript Yandere;
  public bool Outdoors = true;

  private void Update()
  {
    if ((double) this.Yandere.transform.position.y >= 1.0 || !this.Yandere.CanMove || this.Yandere.Schoolwear != 1 || this.Yandere.ClubAttire || this.Yandere.Egg || this.Yandere.WearingRaincoat || this.Yandere.CanCloak)
      return;
    if (this.Outdoors)
    {
      if ((double) this.Yandere.transform.position.x <= -30.0 || (double) this.Yandere.transform.position.x >= 30.0 || (double) this.Yandere.transform.position.z <= -34.0 || (double) this.Yandere.transform.position.z >= 30.0)
        return;
      this.Outdoors = false;
      this.UpdateShoes();
    }
    else
    {
      if ((double) this.Yandere.transform.position.z <= 30.0 && ((double) this.Yandere.transform.position.z >= -34.0 || (double) this.Yandere.transform.position.x <= -6.0 || (double) this.Yandere.transform.position.x >= 6.0))
        return;
      this.Outdoors = true;
      this.UpdateShoes();
    }
  }

  private void UpdateShoes()
  {
    int bloodiness1 = this.Yandere.RightFootprintSpawner.Bloodiness;
    int bloodiness2 = this.Yandere.LeftFootprintSpawner.Bloodiness;
    this.Yandere.Casual = this.Outdoors;
    this.Yandere.ChangeSchoolwear();
    this.Yandere.CanMove = true;
    this.Yandere.RightFootprintSpawner.Bloodiness = bloodiness1;
    this.Yandere.LeftFootprintSpawner.Bloodiness = bloodiness2;
  }
}
