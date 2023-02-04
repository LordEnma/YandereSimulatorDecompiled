public static class CardinalDirection
{
	public static Direction Reversed(Direction direction)
	{
		return direction switch
		{
			Direction.North => Direction.South, 
			Direction.East => Direction.West, 
			Direction.South => Direction.North, 
			_ => Direction.East, 
		};
	}

	public static Direction LeftPerp(Direction direction)
	{
		return direction switch
		{
			Direction.North => Direction.West, 
			Direction.East => Direction.North, 
			Direction.South => Direction.East, 
			_ => Direction.South, 
		};
	}

	public static Direction RightPerp(Direction direction)
	{
		return direction switch
		{
			Direction.North => Direction.East, 
			Direction.East => Direction.South, 
			Direction.South => Direction.West, 
			_ => Direction.North, 
		};
	}
}
