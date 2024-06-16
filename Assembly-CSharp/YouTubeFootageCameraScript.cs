using UnityEngine;

public class YouTubeFootageCameraScript : MonoBehaviour
{
	public float Rotation;

	public float Target;

	private void Update()
	{
		if (Input.GetKeyDown("x"))
		{
			if (Target == 0f)
			{
				Target = 180f;
			}
			else
			{
				Target = 0f;
			}
		}
		Rotation = Mathf.MoveTowards(Rotation, Target, Time.deltaTime * 360f);
		base.transform.eulerAngles = new Vector3(0f, Rotation, 0f);
	}
}
