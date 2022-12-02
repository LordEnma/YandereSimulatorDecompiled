using UnityEngine;

public class StringScript : MonoBehaviour
{
	public Transform Origin;

	public Transform Target;

	public Transform String;

	public int ArrayID;

	private void Start()
	{
		if (ArrayID == -1)
		{
			Target.position = Origin.position;
		}
	}

	private void Update()
	{
		String.position = Origin.position;
		String.LookAt(Target);
		String.localScale = new Vector3(String.localScale.x, String.localScale.y, Vector3.Distance(Origin.position, Target.position) * 0.5f);
	}
}
