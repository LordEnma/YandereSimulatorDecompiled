using UnityEngine;

public class PathfindingTestScript : MonoBehaviour
{
	private byte[] bytes;

	private void Update()
	{
		if (Input.GetKeyDown("left"))
		{
			bytes = AstarPath.active.astarData.SerializeGraphs();
		}
		if (Input.GetKeyDown("right"))
		{
			AstarPath.active.astarData.DeserializeGraphs(bytes);
			AstarPath.active.Scan();
		}
	}
}
