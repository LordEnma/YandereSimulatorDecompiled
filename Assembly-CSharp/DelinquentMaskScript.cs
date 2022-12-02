using UnityEngine;

public class DelinquentMaskScript : MonoBehaviour
{
	public MeshFilter MyRenderer;

	public Mesh[] Meshes;

	public int ID;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			ID++;
			if (ID > 4)
			{
				ID = 0;
			}
			MyRenderer.mesh = Meshes[ID];
		}
	}
}
