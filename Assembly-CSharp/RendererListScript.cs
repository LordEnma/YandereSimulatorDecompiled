using System;
using UnityEngine;

// Token: 0x020003D5 RID: 981
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B83 RID: 7043 RVA: 0x00136520 File Offset: 0x00134720
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

	// Token: 0x06001B84 RID: 7044 RVA: 0x00136578 File Offset: 0x00134778
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

	// Token: 0x04002F31 RID: 12081
	public Renderer[] Renderers;
}
