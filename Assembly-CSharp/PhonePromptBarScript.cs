using UnityEngine;

public class PhonePromptBarScript : MonoBehaviour
{
	public UIPanel Panel;

	public bool Show;

	public UILabel Label;

	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		Panel.enabled = false;
	}

	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (!Show)
		{
			if (Panel.enabled)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 631f, t), base.transform.localPosition.z);
				if (base.transform.localPosition.y < 630f)
				{
					base.transform.localPosition = new Vector3(base.transform.localPosition.x, 631f, base.transform.localPosition.z);
					Panel.enabled = false;
				}
			}
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 530f, t), base.transform.localPosition.z);
		}
	}
}
