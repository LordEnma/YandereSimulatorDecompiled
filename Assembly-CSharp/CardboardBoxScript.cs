using UnityEngine;

public class CardboardBoxScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Start()
	{
		Physics.IgnoreCollision(Prompt.Yandere.GetComponent<Collider>(), GetComponent<Collider>());
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.MyCollider.enabled = false;
			Prompt.Circle[0].fillAmount = 1f;
			GetComponent<Rigidbody>().isKinematic = true;
			GetComponent<Rigidbody>().useGravity = false;
			Prompt.enabled = false;
			Prompt.Hide();
			base.transform.parent = Prompt.Yandere.Hips;
			base.transform.localPosition = new Vector3(0f, -0.3f, 0.21f);
			base.transform.localEulerAngles = new Vector3(-13.333f, 0f, 0f);
		}
		if (base.transform.parent == Prompt.Yandere.Hips)
		{
			base.transform.localEulerAngles = Vector3.zero;
			if (Prompt.Yandere.Stance.Current != StanceType.Crawling)
			{
				base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
			}
			if (Input.GetButtonDown("RB"))
			{
				Prompt.MyCollider.enabled = true;
				GetComponent<Rigidbody>().isKinematic = false;
				GetComponent<Rigidbody>().useGravity = true;
				base.transform.parent = null;
				Prompt.enabled = true;
			}
		}
	}
}
