// Decompiled with JetBrains decompiler
// Type: SpawnedObjectManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
