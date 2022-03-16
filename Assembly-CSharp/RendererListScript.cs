using System;
using UnityEngine;

// Token: 0x020003D1 RID: 977
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B73 RID: 7027 RVA: 0x00135894 File Offset: 0x00133A94
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

	// Token: 0x06001B74 RID: 7028 RVA: 0x001358EC File Offset: 0x00133AEC
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

	// Token: 0x04002F15 RID: 12053
	public Renderer[] Renderers;
}
