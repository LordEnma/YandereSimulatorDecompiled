using System;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x060020EE RID: 8430 RVA: 0x001E6160 File Offset: 0x001E4360
	private void Start()
	{
		Camera component = base.GetComponent<Camera>();
		this.renderTexture = new RenderTexture(component.pixelWidth, component.pixelHeight, 24);
		Shader.SetGlobalTexture("_CameraNormalsTexture", this.renderTexture);
		GameObject gameObject = new GameObject("Normals camera");
		this.camera = gameObject.AddComponent<Camera>();
		this.camera.CopyFrom(component);
		this.camera.transform.SetParent(base.transform);
		this.camera.targetTexture = this.renderTexture;
		this.camera.SetReplacementShader(this.normalsShader, "RenderType");
		this.camera.depth = component.depth - 1f;
	}

	// Token: 0x0400489E RID: 18590
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x0400489F RID: 18591
	private RenderTexture renderTexture;

	// Token: 0x040048A0 RID: 18592
	private Camera camera;
}
