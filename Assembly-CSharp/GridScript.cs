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
		while (ID < Rows * Columns)
		{
			Object.Instantiate(Tile, new Vector3(Row, 0f, Column), Quaternion.identity).transform.parent = base.transform;
			Row++;
			if (Row > Rows)
			{
				Row = 1;
				Column++;
			}
			ID++;
		}
		base.transform.localScale = new Vector3(4f, 4f, 4f);
		base.transform.position = new Vector3(-52f, 0f, -52f);
	}
}
