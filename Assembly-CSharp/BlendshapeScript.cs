using UnityEngine;

public class BlendshapeScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyMesh;

	public float Happiness;

	public float Blink;

	private void LateUpdate()
	{
		Happiness += Time.deltaTime * 10f;
		MyMesh.SetBlendShapeWeight(0, Happiness);
		Blink += Time.deltaTime * 10f;
		MyMesh.SetBlendShapeWeight(8, 100f);
	}
}
