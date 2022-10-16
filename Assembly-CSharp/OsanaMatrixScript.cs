// Decompiled with JetBrains decompiler
// Type: OsanaMatrixScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class OsanaMatrixScript : MonoBehaviour
{
  public CameraFilterPack_3D_Matrix MatrixEffect;
  public GameObject Rivals;
  public int Phase = 1;

  private void Update()
  {
    if (Input.GetKeyDown("z"))
      ++this.Phase;
    if (this.Phase == 2)
      this.MatrixEffect.Fade = Mathf.MoveTowards(this.MatrixEffect.Fade, 1f, Time.deltaTime);
    else if (this.Phase == 3)
    {
      this.MatrixEffect.Fade = Mathf.MoveTowards(this.MatrixEffect.Fade, 0.0f, Time.deltaTime);
    }
    else
    {
      if (this.Phase != 4)
        return;
      this.Rivals.SetActive(true);
    }
  }
}
