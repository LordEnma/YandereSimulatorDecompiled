// Decompiled with JetBrains decompiler
// Type: NotificationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NotificationScript : MonoBehaviour
{
  public NotificationManagerScript NotificationManager;
  public UISprite[] Icon;
  public UIPanel Panel;
  public UILabel Label;
  public bool Display;
  public float Timer;
  public int ID;

  private void Start()
  {
    if (!MissionModeGlobals.MissionMode)
      return;
    this.Icon[0].color = new Color(1f, 1f, 1f, 1f);
    this.Icon[1].color = new Color(1f, 1f, 1f, 1f);
    this.Label.color = new Color(1f, 1f, 1f, 1f);
    this.Label.applyGradient = false;
  }

  private void Update()
  {
    if (!this.Display)
    {
      this.Panel.alpha -= Time.deltaTime * (this.NotificationManager.NotificationsSpawned > this.ID + 2 ? 3f : 1f);
      if ((double) this.Panel.alpha > 0.0)
        return;
      Object.Destroy((Object) this.gameObject);
    }
    else
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 4.0)
        this.Display = false;
      if (this.NotificationManager.NotificationsSpawned <= this.ID + 2)
        return;
      this.Display = false;
    }
  }
}
