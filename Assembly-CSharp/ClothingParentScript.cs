using UnityEngine;

public class ClothingParentScript : MonoBehaviour
{
	public GameObject[] Schoolwear;

	public Vector3[] ClothingPositions;

	public Vector3[] ClothingRotations;

	public int[] Type;

	public int ClothingID;

	public void RecordAllClothing()
	{
		Debug.Log("The ClothingParent script is now running RecordAllClothing().");
		ClothingID = 0;
		Transform[] array = Object.FindObjectsOfType<Transform>();
		foreach (Transform transform in array)
		{
			FoldedUniformScript component = transform.GetComponent<FoldedUniformScript>();
			if (component != null)
			{
				Debug.Log("Allegedly, a school uniform was just recorded!");
				ClothingID++;
				if (ClothingID < 100)
				{
					ClothingPositions[ClothingID] = transform.position;
					ClothingRotations[ClothingID] = transform.eulerAngles;
				}
				Type[ClothingID] = component.Type;
			}
		}
	}

	public void RestoreAllClothing()
	{
		Debug.Log("The ClothingParent script is now running RestoreAllClothing().");
		while (ClothingID > 0)
		{
			Object.Instantiate(Schoolwear[Type[ClothingID]], ClothingPositions[ClothingID], Quaternion.identity).transform.eulerAngles = ClothingRotations[ClothingID];
			Debug.Log("Allegedly, a school uniform was just spawned!");
			ClothingID--;
		}
	}
}
