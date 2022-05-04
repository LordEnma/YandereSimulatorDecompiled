using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x06002133 RID: 8499 RVA: 0x001EC7F0 File Offset: 0x001EA9F0
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

	// Token: 0x04004977 RID: 18807
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x04004978 RID: 18808
	private RenderTexture renderTexture;

	// Token: 0x04004979 RID: 18809
	private Camera camera;
}
