using System;
using UnityEngine;

// Token: 0x020003D4 RID: 980
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B7D RID: 7037 RVA: 0x00136308 File Offset: 0x00134508
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

	// Token: 0x06001B7E RID: 7038 RVA: 0x00136360 File Offset: 0x00134560
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

	// Token: 0x04002F2E RID: 12078
	public Renderer[] Renderers;
}
