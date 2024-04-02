using UnityEngine;

public class PosterScatterScript : MonoBehaviour
{
	public float X;

	public float Y;

	public float Z;

	private void Start()
	{
		int num = 0;
		foreach (Transform item in base.transform)
		{
			float x = Random.Range(X * -1f, X);
			float y = Random.Range(Y * -1f, Y);
			float z = Random.Range(Z * -1f, Z);
			item.localPosition = new Vector3(x, y, item.localPosition.z);
			item.localEulerAngles = new Vector3(0f, 180f, z);
			item.localPosition += new Vector3(0f, 0f, (float)num * 0.0001f);
			num++;
		}
	}
}
