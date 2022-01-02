using System;
using UnityEngine;

// Token: 0x020004EC RID: 1260
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x060020C8 RID: 8392 RVA: 0x001E2CA0 File Offset: 0x001E0EA0
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

	// Token: 0x04004856 RID: 18518
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x04004857 RID: 18519
	private RenderTexture renderTexture;

	// Token: 0x04004858 RID: 18520
	private Camera camera;
}
