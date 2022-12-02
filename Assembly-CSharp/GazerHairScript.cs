using UnityEngine;

public class GazerHairScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyMesh;

	public float[] TargetWeight;

	public float[] Weight;

	public float Strength = 100f;

	public int ID;

	private void Update()
	{
		for (ID = 0; ID < Weight.Length; ID++)
		{
			Weight[ID] = Mathf.MoveTowards(Weight[ID], TargetWeight[ID], Time.deltaTime * Strength);
			if (Weight[ID] == TargetWeight[ID])
			{
				TargetWeight[ID] = Random.Range(0f, 100f);
			}
			MyMesh.SetBlendShapeWeight(ID, Weight[ID]);
		}
	}
}
