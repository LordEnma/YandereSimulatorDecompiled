// Decompiled with JetBrains decompiler
// Type: CrackScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CrackScript : MonoBehaviour
{
  public UITexture Texture;

  private void Update() => this.Texture.fillAmount += Time.deltaTime * 10f;
}
