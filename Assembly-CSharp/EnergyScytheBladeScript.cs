using UnityEngine;

public class EnergyScytheBladeScript : MonoBehaviour
{
	public SkinnedMeshRenderer Mesh;

	public int Phase;

	private void LateUpdate()
	{
		if (Phase == 1)
		{
			Mesh.SetBlendShapeWeight(0, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(0), 100f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(1, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(1), 0f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(2, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(2), 0f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(3, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(3), 0f, Time.deltaTime * 1000f));
			if (Mesh.GetBlendShapeWeight(0) == 100f)
			{
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			Mesh.SetBlendShapeWeight(0, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(0), 0f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(1, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(1), 100f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(2, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(2), 0f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(3, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(3), 0f, Time.deltaTime * 1000f));
			if (Mesh.GetBlendShapeWeight(1) == 100f)
			{
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			Mesh.SetBlendShapeWeight(0, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(0), 0f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(1, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(1), 0f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(2, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(2), 100f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(3, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(3), 0f, Time.deltaTime * 1000f));
			if (Mesh.GetBlendShapeWeight(2) == 100f)
			{
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			Mesh.SetBlendShapeWeight(0, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(0), 0f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(1, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(1), 0f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(2, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(2), 0f, Time.deltaTime * 1000f));
			Mesh.SetBlendShapeWeight(3, Mathf.MoveTowards(Mesh.GetBlendShapeWeight(3), 100f, Time.deltaTime * 1000f));
			if (Mesh.GetBlendShapeWeight(3) == 100f)
			{
				Phase = 1;
			}
		}
	}
}
