using System;
using UnityEngine;

// Token: 0x020003D0 RID: 976
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B66 RID: 7014 RVA: 0x001349F4 File Offset: 0x00132BF4
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

	// Token: 0x06001B67 RID: 7015 RVA: 0x00134A4C File Offset: 0x00132C4C
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

	// Token: 0x04002EE1 RID: 12001
	public Renderer[] Renderers;
}
