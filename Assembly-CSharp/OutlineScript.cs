using System.Collections;
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
		if (h == null && base.gameObject != null)
		{
			h = base.gameObject.AddComponent<Highlighter>();
		}
		if (h != null)
		{
			h.ConstantOnImmediate(color);
		}
		if (base.gameObject.activeInHierarchy)
		{
			StartCoroutine(UpdateOutline());
		}
	}

	private IEnumerator UpdateOutline()
	{
		yield return new WaitForSeconds(5f);
		h.ConstantOnImmediate(color);
	}
}
