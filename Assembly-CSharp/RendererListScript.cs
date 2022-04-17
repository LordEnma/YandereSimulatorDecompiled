using System;
using UnityEngine;

// Token: 0x020003D5 RID: 981
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B87 RID: 7047 RVA: 0x00136930 File Offset: 0x00134B30
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

	// Token: 0x06001B88 RID: 7048 RVA: 0x00136988 File Offset: 0x00134B88
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

	// Token: 0x04002F3C RID: 12092
	public Renderer[] Renderers;
}
