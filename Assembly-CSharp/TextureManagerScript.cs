// Decompiled with JetBrains decompiler
// Type: TextureManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TextureManagerScript : MonoBehaviour
{
  public Texture[] UniformTextures;
  public Texture[] CasualTextures;
  public Texture[] SocksTextures;
  public Texture2D PurpleStockings;
  public Texture2D GreenStockings;
  public Texture2D Base2D;
  public Texture2D Overlay2D;

  public Texture2D MergeTextures(Texture2D BackgroundTex, Texture2D TopTex)
  {
    Texture2D texture2D = new Texture2D(1024, 1024);
    Color32[] pixels32_1 = BackgroundTex.GetPixels32();
    Color32[] pixels32_2 = TopTex.GetPixels32();
    for (int index = 0; index < pixels32_2.Length; ++index)
    {
      if (pixels32_2[index].a != (byte) 0)
        pixels32_1[index] = pixels32_2[index];
    }
    texture2D.SetPixels32(pixels32_1);
    texture2D.Apply();
    return texture2D;
  }
}
