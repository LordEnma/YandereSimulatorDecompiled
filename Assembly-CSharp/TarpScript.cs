using UnityEngine;

public class TarpScript : MonoBehaviour
{
	public PromptScript Prompt;

	public MechaScript Mecha;

	public AudioClip Tarp;

	public float PreviousSpeed;

	public float Speed;

	public bool Unwrap;

	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			AudioSource.PlayClipAtPoint(Tarp, base.transform.position);
			Unwrap = true;
			Prompt.Hide();
			Prompt.enabled = false;
			Mecha.enabled = true;
			Mecha.Prompt.enabled = true;
		}
		if (!Unwrap)
		{
			return;
		}
		Speed += Time.deltaTime * 10f;
		base.transform.localEulerAngles = Vector3.Lerp(base.transform.localEulerAngles, new Vector3(90f, 90f, 0f), Time.deltaTime * Speed);
		if (base.transform.localEulerAngles.x > 45f)
		{
			if (PreviousSpeed == 0f)
			{
				PreviousSpeed = Speed;
			}
			Speed += Time.deltaTime * 10f;
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 0.0001f), (Speed - PreviousSpeed) * Time.deltaTime);
		}
	}
}
