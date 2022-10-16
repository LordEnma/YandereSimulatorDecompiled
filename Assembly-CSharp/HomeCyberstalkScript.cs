// Decompiled with JetBrains decompiler
// Type: HomeCyberstalkScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeCyberstalkScript : MonoBehaviour
{
  public HomeDarknessScript HomeDarkness;

  private void Update()
  {
    if (Input.GetButtonDown("A"))
    {
      this.HomeDarkness.Sprite.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.HomeDarkness.Cyberstalking = true;
      this.HomeDarkness.FadeOut = true;
      this.gameObject.SetActive(false);
      for (int topicID = 1; topicID < 26; ++topicID)
      {
        ConversationGlobals.SetTopicLearnedByStudent(topicID, this.HomeDarkness.HomeCamera.HomeInternet.Student, true);
        ConversationGlobals.SetTopicDiscovered(topicID, true);
      }
    }
    if (!Input.GetButtonDown("B"))
      return;
    this.gameObject.SetActive(false);
  }
}
