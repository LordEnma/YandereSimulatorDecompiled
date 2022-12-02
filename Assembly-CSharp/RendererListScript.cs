using UnityEngine;

public class RendererListScript : MonoBehaviour
{
	public Renderer[] Renderers;

	private void Start()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		int num = 0;
		Transform[] array = componentsInChildren;
		foreach (Transform transform in array)
		{
			if (transform.gameObject.GetComponent<Renderer>() != null)
			{
				Renderers[num] = transform.gameObject.GetComponent<Renderer>();
				num++;
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			Renderer[] renderers = Renderers;
			foreach (Renderer obj in renderers)
			{
				obj.enabled = !obj.enabled;
			}
		}
	}
}
