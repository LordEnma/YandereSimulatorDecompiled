using System;
using UnityEngine;

// Token: 0x020003CB RID: 971
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B41 RID: 6977 RVA: 0x00131E5C File Offset: 0x0013005C
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

	// Token: 0x06001B42 RID: 6978 RVA: 0x00131EB4 File Offset: 0x001300B4
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

	// Token: 0x04002E70 RID: 11888
	public Renderer[] Renderers;
}
