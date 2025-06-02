using HighlightingSystem;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Highlighter h;

	public Color color = new Color(1f, 1f, 1f, 1f);

	public void Awake()
	{
		h = GetComponent<Highlighter>();
		if (h == null)
		{
			h = base.gameObject.AddComponent<Highlighter>();
		}
		h.ConstantOnImmediate(color);
	}
}
