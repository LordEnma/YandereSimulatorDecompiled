// Decompiled with JetBrains decompiler
// Type: PaintBucketScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PaintBucketScript : MonoBehaviour
{
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    if (this.Prompt.Yandere.StudentManager.OriginalUniforms + this.Prompt.Yandere.StudentManager.NewUniforms > 1)
    {
      if ((double) this.Prompt.Yandere.Bloodiness != 0.0)
        return;
      ++this.Prompt.Yandere.Police.RedPaintClothing;
      this.Prompt.Yandere.Bloodiness += 100f;
      this.Prompt.Yandere.RedPaint = true;
    }
    else
    {
      if (this.Prompt.Yandere.ClothingWarning)
        return;
      this.Prompt.Yandere.NotificationManager.CustomText = "Can't do that; no spare clothing";
      this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      this.Prompt.Yandere.StudentManager.TutorialWindow.ShowClothingMessage = true;
      this.Prompt.Yandere.ClothingWarning = true;
    }
  }
}
