using System;
using UnityEngine;

// Token: 0x020003CF RID: 975
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B5C RID: 7004 RVA: 0x00133A94 File Offset: 0x00131C94
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

	// Token: 0x06001B5D RID: 7005 RVA: 0x00133AEC File Offset: 0x00131CEC
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

	// Token: 0x04002EBB RID: 11963
	public Renderer[] Renderers;
}
