using UnityEngine;

public class DumpScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyRenderer;

	public IncineratorScript Incinerator;

	public float Timer;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 5f)
		{
			Incinerator.Corpses++;
			Object.Destroy(base.gameObject);
		}
	}
}
