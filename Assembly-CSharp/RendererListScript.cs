using System;
using UnityEngine;

// Token: 0x020003D6 RID: 982
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B92 RID: 7058 RVA: 0x00137E5C File Offset: 0x0013605C
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

	// Token: 0x06001B93 RID: 7059 RVA: 0x00137EB4 File Offset: 0x001360B4
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

	// Token: 0x04002F63 RID: 12131
	public Renderer[] Renderers;
}
