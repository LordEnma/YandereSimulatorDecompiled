// Decompiled with JetBrains decompiler
// Type: OpenURLOnClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class OpenURLOnClick : MonoBehaviour
{
  private void OnClick()
  {
    UILabel component = this.GetComponent<UILabel>();
    if (!((Object) component != (Object) null))
      return;
    string urlAtPosition = component.GetUrlAtPosition(UICamera.lastWorldPosition);
    if (string.IsNullOrEmpty(urlAtPosition))
      return;
    Application.OpenURL(urlAtPosition);
  }
}
