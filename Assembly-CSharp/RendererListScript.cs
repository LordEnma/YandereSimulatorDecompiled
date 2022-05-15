using System;
using UnityEngine;

// Token: 0x020003D6 RID: 982
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B91 RID: 7057 RVA: 0x00137BC0 File Offset: 0x00135DC0
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

	// Token: 0x06001B92 RID: 7058 RVA: 0x00137C18 File Offset: 0x00135E18
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

	// Token: 0x04002F5B RID: 12123
	public Renderer[] Renderers;
}
