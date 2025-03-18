using UnityEngine;

namespace UnityStandardAssets.Water
{
	[ExecuteInEditMode]
	public class WaterBasic : MonoBehaviour
	{
		private void Update()
		{
			Renderer component = GetComponent<Renderer>();
			if ((bool)component)
			{
				Material sharedMaterial = component.sharedMaterial;
				if ((bool)sharedMaterial)
				{
					Vector4 vector = sharedMaterial.GetVector("WaveSpeed");
					float @float = sharedMaterial.GetFloat("_WaveScale");
					float num = Time.time / 20f;
					Vector4 vector2 = vector * (num * @float);
					Vector4 value = new Vector4(Mathf.Repeat(vector2.x, 1f), Mathf.Repeat(vector2.y, 1f), Mathf.Repeat(vector2.z, 1f), Mathf.Repeat(vector2.w, 1f));
					sharedMaterial.SetVector("_WaveOffset", value);
				}
			}
		}
	}
}
