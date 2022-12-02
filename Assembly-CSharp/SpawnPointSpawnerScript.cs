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
		while (ID < Limit)
		{
			if (Iterations == 0)
			{
				GameObject gameObject = null;
				gameObject = ((!SpawnGirl) ? Object.Instantiate(SpawnPoint, new Vector3(Column, 0f, Row), Quaternion.identity) : Object.Instantiate(SimpleGirl, new Vector3(Column, 0f, Row), Quaternion.identity));
				gameObject.transform.parent = SpawnPointParent;
				Iterations += IterationsToWait;
				Row--;
				ID++;
				gameObject.name = "SpawnPoint_" + ID;
			}
			Column += Direction;
			if (Column > 4 || Column < -4)
			{
				Direction *= -1;
			}
			if (Column > 4)
			{
				Column -= 2;
			}
			if (Column < -4)
			{
				Column += 2;
			}
			if (Column == 0)
			{
				Column += Direction;
			}
			Iterations--;
		}
	}
}
