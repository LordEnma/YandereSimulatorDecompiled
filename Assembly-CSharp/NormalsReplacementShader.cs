using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x060020D3 RID: 8403 RVA: 0x001E3640 File Offset: 0x001E1840
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

	// Token: 0x0400486A RID: 18538
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x0400486B RID: 18539
	private RenderTexture renderTexture;

	// Token: 0x0400486C RID: 18540
	private Camera camera;
}
