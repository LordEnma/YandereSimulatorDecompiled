using UnityEngine;

public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	public YanvaniaDraculaScript Dracula;

	public Transform SecondBeamParent;

	public Renderer SecondBeam;

	public Renderer FirstBeam;

	public bool InformedDracula;

	public float Timer;

	private void Start()
	{
		FirstBeam.material.color = new Color(FirstBeam.material.color.r, FirstBeam.material.color.g, FirstBeam.material.color.b, 0f);
		SecondBeam.material.color = new Color(SecondBeam.material.color.r, SecondBeam.material.color.g, SecondBeam.material.color.b, 0f);
		FirstBeam.transform.localScale = new Vector3(0f, FirstBeam.transform.localScale.y, 0f);
		SecondBeamParent.transform.localScale = new Vector3(SecondBeamParent.transform.localScale.x, 0f, SecondBeamParent.transform.localScale.z);
	}
}
