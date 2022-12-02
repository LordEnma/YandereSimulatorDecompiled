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
		for (int i = 0; i < SpawnedObjectList.Length; i++)
		{
			if (SpawnedTransforms[i] != null)
			{
				SpawnedPositions[i] = SpawnedTransforms[i].position;
			}
		}
	}

	public void RespawnObjects()
	{
		for (int i = 0; i < SpawnedObjectList.Length; i++)
		{
			if (SpawnedObjectList[i] == SpawnedObjectType.SmokeBomb)
			{
				Object.Instantiate(SmokeBomb, SpawnedPositions[i], Quaternion.identity);
			}
		}
	}
}
