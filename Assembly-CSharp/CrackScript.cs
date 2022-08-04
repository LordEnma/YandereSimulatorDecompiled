// Decompiled with JetBrains decompiler
// Type: CrackScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CrackScript : MonoBehaviour
{
  public UITexture Texture;

  private void Update() => this.Texture.fillAmount += Time.deltaTime * 10f;
}
