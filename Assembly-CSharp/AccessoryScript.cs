using UnityEngine;

public class AccessoryScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Transform Target;

	public float X;

	public float Y;

	public float Z;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			Prompt.MyCollider.enabled = false;
			base.transform.parent = Target;
			base.transform.localPosition = new Vector3(X, Y, Z);
			base.transform.localEulerAngles = Vector3.zero;
			base.enabled = false;
		}
	}
}
