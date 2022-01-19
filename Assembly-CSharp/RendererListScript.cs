using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B52 RID: 6994 RVA: 0x00133084 File Offset: 0x00131284
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

	// Token: 0x06001B53 RID: 6995 RVA: 0x001330DC File Offset: 0x001312DC
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

	// Token: 0x04002EAB RID: 11947
	public Renderer[] Renderers;
}
