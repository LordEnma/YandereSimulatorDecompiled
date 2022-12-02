using UnityEngine;

public class NuzzleScript : MonoBehaviour
{
	public Vector3 OriginalRotation;

	public float Rotate;

	public float Limit;

	public float Speed;

	private bool Down;

	private void Start()
	{
		OriginalRotation = base.transform.localEulerAngles;
	}

	private void Update()
	{
		if (!Down)
		{
			Rotate += Time.deltaTime * Speed;
			if (Rotate > Limit)
			{
				Down = true;
			}
		}
		else
		{
			Rotate -= Time.deltaTime * Speed;
			if (Rotate < -1f * Limit)
			{
				Down = false;
			}
		}
		base.transform.localEulerAngles = OriginalRotation + new Vector3(Rotate, 0f, 0f);
	}
}
