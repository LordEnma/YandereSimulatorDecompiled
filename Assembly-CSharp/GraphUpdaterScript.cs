using UnityEngine;

public class GraphUpdaterScript : MonoBehaviour
{
	public AstarPath Graph;

	public int Frames;

	private void Update()
	{
		if (Frames > 0)
		{
			Graph.Scan();
			Object.Destroy(this);
		}
		Frames++;
	}
}
