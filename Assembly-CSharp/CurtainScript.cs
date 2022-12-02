using UnityEngine;

public class CurtainScript : MonoBehaviour
{
	public SkinnedMeshRenderer[] Curtains;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public bool Animate;

	public bool Open;

	public float Weight;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount < 1f && Prompt.Circle[0].fillAmount > 0f)
		{
			Prompt.Circle[0].fillAmount = 0f;
			MyAudio.Play();
			Animate = true;
			Open = !Open;
		}
		if (!Animate)
		{
			return;
		}
		if (!Open)
		{
			Weight = Mathf.Lerp(Weight, 0f, Time.deltaTime * 10f);
			if (Weight < 0.01f)
			{
				Animate = false;
				Weight = 0f;
			}
		}
		else
		{
			Weight = Mathf.Lerp(Weight, 100f, Time.deltaTime * 10f);
			if (Weight > 99.99f)
			{
				Animate = false;
				Weight = 100f;
			}
		}
		Curtains[0].SetBlendShapeWeight(0, Weight);
		Curtains[1].SetBlendShapeWeight(0, Weight);
	}

	private void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.layer == 13 || other.gameObject.layer == 9) && !Open)
		{
			MyAudio.Play();
			Animate = true;
			Open = true;
		}
	}
}
