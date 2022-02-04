using System;
using UnityEngine;

// Token: 0x020004EF RID: 1263
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x060020DB RID: 8411 RVA: 0x001E4EC8 File Offset: 0x001E30C8
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

	// Token: 0x04004882 RID: 18562
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x04004883 RID: 18563
	private RenderTexture renderTexture;

	// Token: 0x04004884 RID: 18564
	private Camera camera;
}
