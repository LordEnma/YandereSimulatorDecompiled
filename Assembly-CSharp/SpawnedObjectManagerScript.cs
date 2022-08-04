// Decompiled with JetBrains decompiler
// Type: SpawnedObjectManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpawnedObjectManagerScript : MonoBehaviour
{
  public SpawnedObjectType[] SpawnedObjectList;
  public Transform[] SpawnedTransforms;
  public Vector3[] SpawnedPositions;
  public GameObject SmokeBomb;
  public int ObjectsSpawned;

  public void RememberObjects()
  {
    for (int index = 0; index < this.SpawnedObjectList.Length; ++index)
    {
      if ((Object) this.SpawnedTransforms[index] != (Object) null)
        this.SpawnedPositions[index] = this.SpawnedTransforms[index].position;
    }
  }

  public void RespawnObjects()
  {
    for (int index = 0; index < this.SpawnedObjectList.Length; ++index)
    {
      if (this.SpawnedObjectList[index] == SpawnedObjectType.SmokeBomb)
        Object.Instantiate<GameObject>(this.SmokeBomb, this.SpawnedPositions[index], Quaternion.identity);
    }
  }
}
