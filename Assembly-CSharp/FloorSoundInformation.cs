using UnityEngine;

[CreateAssetMenu(fileName = "FloorSound", menuName = "Create Floor Sound", order = 1)]
public class FloorSoundInformation : ScriptableObject
{
	public float BarefootRunVolume;

	public AudioClip[] BarefootRun;

	public float BarefootWalkVolume;

	public AudioClip[] BarefootWalk;

	public float RunVolume;

	public AudioClip[] Run;

	public float WalkVolume;

	public AudioClip[] Walk;
}
