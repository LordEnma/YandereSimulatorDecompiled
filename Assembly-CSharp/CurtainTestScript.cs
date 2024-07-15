using UnityEngine;

public class CurtainTestScript : MonoBehaviour
{
	public SkinnedMeshRenderer Curtains;

	public PromptScript Prompt;

	public float AnimTimer;

	public float[] Weight;

	public bool Close;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			AnimTimer = 15f;
			Close = !Close;
		}
		if (AnimTimer > 0f)
		{
			AnimTimer = Mathf.MoveTowards(AnimTimer, 0f, Time.deltaTime);
			if (Close)
			{
				Weight[0] = Mathf.Lerp(Weight[0], 0f, Time.deltaTime * 0.333f);
				Weight[1] = Mathf.Lerp(Weight[1], 0f, Time.deltaTime * 0.666f);
				Weight[2] = Mathf.Lerp(Weight[2], 0f, Time.deltaTime * 1f);
			}
			else
			{
				Weight[0] = Mathf.Lerp(Weight[0], 100f, Time.deltaTime * 1f);
				Weight[1] = Mathf.Lerp(Weight[1], 100f, Time.deltaTime * 0.666f);
				Weight[2] = Mathf.Lerp(Weight[2], 100f, Time.deltaTime * 0.333f);
			}
			Curtains.SetBlendShapeWeight(0, Weight[0]);
			Curtains.SetBlendShapeWeight(1, Weight[1]);
			Curtains.SetBlendShapeWeight(2, Weight[2]);
		}
	}
}
