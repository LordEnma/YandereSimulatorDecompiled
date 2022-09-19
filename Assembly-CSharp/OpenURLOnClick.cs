// Decompiled with JetBrains decompiler
// Type: OpenURLOnClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
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
