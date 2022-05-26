// Decompiled with JetBrains decompiler
// Type: DramaticPanUpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DramaticPanUpScript : MonoBehaviour
{
  public bool Pan;
  public float Height;
  public float Power;

  private void Update()
  {
    if (Input.GetKeyDown("space"))
      this.Pan = true;
    if (!this.Pan)
      return;
    this.Power += Time.deltaTime * 0.5f;
    this.Height = Mathf.Lerp(this.Height, 1.4f, this.Power * Time.deltaTime);
    this.transform.localPosition = new Vector3(0.0f, this.Height, 1f);
  }
}
