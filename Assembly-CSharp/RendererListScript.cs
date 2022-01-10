using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B52 RID: 6994 RVA: 0x00132EB4 File Offset: 0x001310B4
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

	// Token: 0x06001B53 RID: 6995 RVA: 0x00132F0C File Offset: 0x0013110C
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

	// Token: 0x04002EA7 RID: 11943
	public Renderer[] Renderers;
}
