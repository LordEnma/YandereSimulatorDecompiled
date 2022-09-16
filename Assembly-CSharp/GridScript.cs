// Decompiled with JetBrains decompiler
// Type: GridScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GridScript : MonoBehaviour
{
  public GameObject Tile;
  public int Row;
  public int Column;
  public int Rows = 25;
  public int Columns = 25;
  public int ID;

  private void Start()
  {
    for (; this.ID < this.Rows * this.Columns; ++this.ID)
    {
      Object.Instantiate<GameObject>(this.Tile, new Vector3((float) this.Row, 0.0f, (float) this.Column), Quaternion.identity).transform.parent = this.transform;
      ++this.Row;
      if (this.Row > this.Rows)
      {
        this.Row = 1;
        ++this.Column;
      }
    }
    this.transform.localScale = new Vector3(4f, 4f, 4f);
    this.transform.position = new Vector3(-52f, 0.0f, -52f);
  }
}
