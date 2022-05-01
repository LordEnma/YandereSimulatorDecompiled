using System;
using UnityEngine;

// Token: 0x020003D5 RID: 981
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B8B RID: 7051 RVA: 0x00136FA8 File Offset: 0x001351A8
	private void Start()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		int num = 0;
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.gameObject.GetComponent<Renderer>() != null)
			{
				this.Renderers[num] = transform.gameObject.GetComponent<Renderer>();
				num++;
			}
		}
	}

	// Token: 0x06001B8C RID: 7052 RVA: 0x00137000 File Offset: 0x00135200
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			foreach (Renderer renderer in this.Renderers)
			{
				renderer.enabled = !renderer.enabled;
			}
		}
	}

	// Token: 0x04002F46 RID: 12102
	public Renderer[] Renderers;
}
