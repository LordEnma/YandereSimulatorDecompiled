using System;
using UnityEngine;

// Token: 0x020003D0 RID: 976
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B65 RID: 7013 RVA: 0x001344DC File Offset: 0x001326DC
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

	// Token: 0x06001B66 RID: 7014 RVA: 0x00134534 File Offset: 0x00132734
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

	// Token: 0x04002ECB RID: 11979
	public Renderer[] Renderers;
}
