using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B55 RID: 6997 RVA: 0x00133764 File Offset: 0x00131964
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

	// Token: 0x06001B56 RID: 6998 RVA: 0x001337BC File Offset: 0x001319BC
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

	// Token: 0x04002EB5 RID: 11957
	public Renderer[] Renderers;
}
