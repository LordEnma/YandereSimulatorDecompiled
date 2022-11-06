// Decompiled with JetBrains decompiler
// Type: CrackScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CrackScript : MonoBehaviour
{
  public UITexture Texture;

  private void Update() => this.Texture.fillAmount += Time.deltaTime * 10f;
}
