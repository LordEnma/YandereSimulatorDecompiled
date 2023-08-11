using UnityEngine;

public class SpawnedObjectManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public SpawnedObjectType[] SpawnedObjectList;

	public Transform[] SpawnedTransforms;

	public Vector3[] SpawnedPositions;

	public bool[] SpawnedInBags;

	public GameObject BoxOfStinkBombs;

	public GameObject BoxOfBangSnaps;

	public GameObject CleanUniform;

	public GameObject SaltySnack;

	public GameObject StinkBombs;

	public GameObject BangSnaps;

	public GameObject SmokeBomb;

	public GameObject TarpBag;

	public int ObjectsSpawned;

	public void RememberObjects()
	{
		Debug.Log("Remembering spawned objects at this moment.");
		for (int i = 0; i < SpawnedObjectList.Length; i++)
		{
			if (SpawnedTransforms[i] != null)
			{
				SpawnedPositions[i] = SpawnedTransforms[i].position;
				SpawnedInBags[i] = SpawnedTransforms[i].gameObject.GetComponent<PickUpScript>().InsideBookbag;
			}
		}
	}

	public void RespawnObjects()
	{
		for (int i = 0; i < SpawnedObjectList.Length; i++)
		{
			GameObject gameObject = null;
			if (SpawnedObjectList[i] == SpawnedObjectType.SmokeBomb)
			{
				gameObject = Object.Instantiate(SmokeBomb, SpawnedPositions[i], Quaternion.identity);
			}
			else if (SpawnedObjectList[i] == SpawnedObjectType.BoxOfBangSnaps)
			{
				gameObject = Object.Instantiate(BoxOfBangSnaps, SpawnedPositions[i], Quaternion.identity);
			}
			else if (SpawnedObjectList[i] == SpawnedObjectType.BoxOfStinkBombs)
			{
				gameObject = Object.Instantiate(BoxOfStinkBombs, SpawnedPositions[i], Quaternion.identity);
			}
			else if (SpawnedObjectList[i] == SpawnedObjectType.StinkBombs)
			{
				gameObject = Object.Instantiate(StinkBombs, SpawnedPositions[i], Quaternion.identity);
			}
			else if (SpawnedObjectList[i] == SpawnedObjectType.BangSnaps)
			{
				gameObject = Object.Instantiate(BangSnaps, SpawnedPositions[i], Quaternion.identity);
			}
			else if (SpawnedObjectList[i] == SpawnedObjectType.SaltySnack)
			{
				gameObject = Object.Instantiate(SaltySnack, SpawnedPositions[i], Quaternion.identity);
			}
			else if (SpawnedObjectList[i] == SpawnedObjectType.CleanUniform)
			{
				gameObject = Object.Instantiate(CleanUniform, SpawnedPositions[i], Quaternion.identity);
			}
			else if (SpawnedObjectList[i] == SpawnedObjectType.TarpBag)
			{
				gameObject = Object.Instantiate(TarpBag, SpawnedPositions[i], Quaternion.identity);
			}
			if (SpawnedInBags[i])
			{
				Debug.Log(gameObject.name + " is supposed to be inside of the bookbag.");
				PickUpScript component = gameObject.GetComponent<PickUpScript>();
				StudentManager.BookBag.ConcealedPickup = component;
				gameObject.SetActive(value: false);
				if (component.Prompt.Text[3] != "")
				{
					StudentManager.BookBag.Prompt.Label[0].text = "     Retrieve " + component.Prompt.Text[3];
				}
				else
				{
					StudentManager.BookBag.Prompt.Label[0].text = "     Retrieve " + component.name;
				}
			}
		}
		for (int i = 0; i < SpawnedObjectList.Length; i++)
		{
			SpawnedObjectList[i] = SpawnedObjectType.None;
			SpawnedInBags[i] = false;
		}
	}
}
