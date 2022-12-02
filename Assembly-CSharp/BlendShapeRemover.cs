using UnityEngine;

public class BlendShapeRemover : MonoBehaviour
{
	public SkinnedMeshRenderer SelectedMesh;

	private void Awake()
	{
		if (!SystemInfo.supportsComputeShaders)
		{
			SelectedMesh.sharedMesh.ClearBlendShapes();
		}
	}
}
