using UnityEngine;

public class CrackScript : MonoBehaviour
{
	public UITexture Texture;

	private void Update()
	{
		Texture.fillAmount += Time.deltaTime * 10f;
	}
}
