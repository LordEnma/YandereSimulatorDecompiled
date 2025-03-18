using UnityEngine;

public class ModernTaskPromptScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Renderer MyRenderer;

	public Texture NewTexture;

	public bool Removed;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			ChangeFlag();
			Prompt.Yandere.Inventory.AmericanFlag = true;
			Removed = true;
			Prompt.enabled = false;
			base.enabled = false;
			Prompt.Hide();
		}
	}

	public void ChangeFlag()
	{
		MyRenderer.material.mainTexture = NewTexture;
	}
}
