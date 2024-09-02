using UnityEngine;

public class ModernTaskPromptScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Renderer MyRenderer;

	public Texture NewTexture;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			MyRenderer.material.mainTexture = NewTexture;
			Prompt.Yandere.Inventory.AmericanFlag = true;
			Prompt.enabled = false;
			base.enabled = false;
			Prompt.Hide();
		}
	}
}
