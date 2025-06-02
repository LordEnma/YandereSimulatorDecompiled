using UnityEngine;

public class TreeBranchAnimationScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public float Max;

	public float Min;

	public Vector3 StartRotation;

	public float[] Rotation;

	public float[] Target;

	public float[] Speed;

	private void Start()
	{
		StartRotation = base.transform.localEulerAngles;
	}

	private void Update()
	{
		if (!MyRenderer.isVisible)
		{
			return;
		}
		for (int i = 1; i < 3; i++)
		{
			Speed[i] += Time.deltaTime;
			Rotation[i] = Mathf.Lerp(Rotation[i], Target[i], Speed[i] * Time.deltaTime);
			if (Rotation[i] > Target[i] - 0.1f && Rotation[i] < Target[i] + 0.1f)
			{
				Target[i] = Random.Range(Min, Max);
				Speed[i] = 0f;
			}
		}
		base.transform.localEulerAngles = StartRotation + new Vector3(Rotation[1], Rotation[2], Rotation[3]);
	}
}
