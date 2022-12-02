using UnityEngine;

public class IntroYandereScript : MonoBehaviour
{
	public Transform Hips;

	public Transform Spine;

	public Transform Spine1;

	public Transform Spine2;

	public Transform Spine3;

	public Transform Neck;

	public Transform Head;

	public Transform RightUpLeg;

	public Transform RightLeg;

	public Transform RightFoot;

	public Transform LeftUpLeg;

	public Transform LeftLeg;

	public Transform LeftFoot;

	public float X;

	private void LateUpdate()
	{
		Hips.localEulerAngles = new Vector3(Hips.localEulerAngles.x + X, Hips.localEulerAngles.y, Hips.localEulerAngles.z);
		Spine.localEulerAngles = new Vector3(Spine.localEulerAngles.x + X, Spine.localEulerAngles.y, Spine.localEulerAngles.z);
		Spine1.localEulerAngles = new Vector3(Spine1.localEulerAngles.x + X, Spine1.localEulerAngles.y, Spine1.localEulerAngles.z);
		Spine2.localEulerAngles = new Vector3(Spine2.localEulerAngles.x + X, Spine2.localEulerAngles.y, Spine2.localEulerAngles.z);
		Spine3.localEulerAngles = new Vector3(Spine3.localEulerAngles.x + X, Spine3.localEulerAngles.y, Spine3.localEulerAngles.z);
		Neck.localEulerAngles = new Vector3(Neck.localEulerAngles.x + X, Neck.localEulerAngles.y, Neck.localEulerAngles.z);
		Head.localEulerAngles = new Vector3(Head.localEulerAngles.x + X, Head.localEulerAngles.y, Head.localEulerAngles.z);
		RightUpLeg.localEulerAngles = new Vector3(RightUpLeg.localEulerAngles.x - X, RightUpLeg.localEulerAngles.y, RightUpLeg.localEulerAngles.z);
		RightLeg.localEulerAngles = new Vector3(RightLeg.localEulerAngles.x - X, RightLeg.localEulerAngles.y, RightLeg.localEulerAngles.z);
		RightFoot.localEulerAngles = new Vector3(RightFoot.localEulerAngles.x - X, RightFoot.localEulerAngles.y, RightFoot.localEulerAngles.z);
		LeftUpLeg.localEulerAngles = new Vector3(LeftUpLeg.localEulerAngles.x - X, LeftUpLeg.localEulerAngles.y, LeftUpLeg.localEulerAngles.z);
		LeftLeg.localEulerAngles = new Vector3(LeftLeg.localEulerAngles.x - X, LeftLeg.localEulerAngles.y, LeftLeg.localEulerAngles.z);
		LeftFoot.localEulerAngles = new Vector3(LeftFoot.localEulerAngles.x - X, LeftFoot.localEulerAngles.y, LeftFoot.localEulerAngles.z);
	}
}
