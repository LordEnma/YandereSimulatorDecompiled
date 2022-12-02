public abstract class BucketContents
{
	public abstract BucketContentsType Type { get; }

	public abstract bool IsCleaningAgent { get; }

	public abstract bool IsFlammable { get; }

	public abstract bool CanBeLifted(int strength);
}
