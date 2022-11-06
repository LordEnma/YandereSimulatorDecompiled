// Decompiled with JetBrains decompiler
// Type: ObstacleDetectorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ObstacleDetectorScript : MonoBehaviour
{
  public YandereScript Yandere;
  public int Obstacles;
  public int Frame;
  public int ID;

  private void Update()
  {
    ++this.Frame;
    if (this.Frame == 3)
    {
      this.Frame = 0;
      this.Obstacles = 0;
      this.gameObject.SetActive(false);
    }
    else if (this.Frame == 2)
    {
      if (this.Obstacles > 0)
      {
        this.Yandere.NotificationManager.CustomText = "Something's in the way.";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        this.Yandere.NotificationManager.CustomText = "You can't set the cello case down here.";
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      else
      {
        this.Frame = 0;
        this.Yandere.Container.Drop();
        this.Yandere.WeaponMenu.UpdateSprites();
        this.gameObject.SetActive(false);
      }
    }
    else
    {
      int frame = this.Frame;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!this.Yandere.Container.CelloCase || other.gameObject.layer == 1 || other.gameObject.layer == 2 || other.gameObject.layer == 8 || other.gameObject.layer == 13 || other.gameObject.layer == 14)
      return;
    Debug.Log((object) ("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer.ToString()));
    ++this.Obstacles;
  }
}
