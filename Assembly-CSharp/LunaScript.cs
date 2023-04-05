using UnityEngine;

public class LunaScript : MonoBehaviour
{
	public Transform Head;

	public float ExtraLength;

	private void LateUpdate()
	{
		Head.transform.localPosition += new Vector3(0f, ExtraLength, 0f);
	}
}
