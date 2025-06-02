using UnityEngine;

public class RainbowScript : MonoBehaviour
{
	[SerializeField]
	private Renderer MyRenderer;

	[SerializeField]
	private float cyclesPerSecond;

	[SerializeField]
	private float percent;

	private void Start()
	{
		MyRenderer.material.color = Color.red;
		cyclesPerSecond = 0.25f;
	}

	private void Update()
	{
		if (MyRenderer.isVisible)
		{
			percent = (percent + Time.deltaTime * cyclesPerSecond) % 1f;
			MyRenderer.material.color = Color.HSVToRGB(percent, 1f, 1f);
		}
	}
}
