using UnityEngine;

public class PhoneCharmScript : MonoBehaviour
{
	public Renderer MyRenderer;

	private void Update()
	{
		if (MyRenderer.isVisible)
		{
			base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
		}
	}
}
