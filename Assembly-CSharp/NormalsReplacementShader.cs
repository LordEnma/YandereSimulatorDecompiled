using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x06002122 RID: 8482 RVA: 0x001EA80C File Offset: 0x001E8A0C
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

	// Token: 0x0400494F RID: 18767
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x04004950 RID: 18768
	private RenderTexture renderTexture;

	// Token: 0x04004951 RID: 18769
	private Camera camera;
}
