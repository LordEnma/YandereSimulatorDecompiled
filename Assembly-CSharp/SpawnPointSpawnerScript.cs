// Decompiled with JetBrains decompiler
// Type: SpawnPointSpawnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpawnPointSpawnerScript : MonoBehaviour
{
  public Transform SpawnPointParent;
  public GameObject SimpleGirl;
  public GameObject SpawnPoint;
  public int IterationsToWait = 3;
  public int Direction = 1;
  public int Column = -4;
  public int Iterations;
  public int Limit;
  public int Row;
  public int ID;
  public bool SpawnGirl;

  private void Start()
  {
    while (this.ID < this.Limit)
    {
      if (this.Iterations == 0)
      {
        GameObject gameObject = !this.SpawnGirl ? Object.Instantiate<GameObject>(this.SpawnPoint, new Vector3((float) this.Column, 0.0f, (float) this.Row), Quaternion.identity) : Object.Instantiate<GameObject>(this.SimpleGirl, new Vector3((float) this.Column, 0.0f, (float) this.Row), Quaternion.identity);
        gameObject.transform.parent = this.SpawnPointParent;
        this.Iterations += this.IterationsToWait;
        --this.Row;
        ++this.ID;
        gameObject.name = "SpawnPoint_" + this.ID.ToString();
      }
      this.Column += this.Direction;
      if (this.Column > 4 || this.Column < -4)
        this.Direction *= -1;
      if (this.Column > 4)
        this.Column -= 2;
      if (this.Column < -4)
        this.Column += 2;
      if (this.Column == 0)
        this.Column += this.Direction;
      --this.Iterations;
    }
  }
}
