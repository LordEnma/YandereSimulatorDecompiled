using System;
using UnityEngine;

// Token: 0x020004EF RID: 1263
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x060020DE RID: 8414 RVA: 0x001E50CC File Offset: 0x001E32CC
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

	// Token: 0x04004885 RID: 18565
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x04004886 RID: 18566
	private RenderTexture renderTexture;

	// Token: 0x04004887 RID: 18567
	private Camera camera;
}
