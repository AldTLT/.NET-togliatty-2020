namespace CoordinateFormatter
{
    /// <summary>
    /// The class represents coordinates X and Y.
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Coordinate X.
        /// </summary>
        public double X { get; private set; }

        /// <summary>
        /// Coordinate Y.
        /// </summary>
        public double Y { get; private set; }

        /// <summary>
        /// Create of Coordinate instance contains coordinate X and Y.
        /// </summary>
        /// <param name="x">Value of a X coordinate.</param>
        /// <param name="y">Value of a Y coordinate.</param>
        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Converts the value of this instance to string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public override string ToString()
        {
            return $"X: {this.X} Y: {this.Y}";
        }

        /// <summary>
        /// Determines whether this instance and another specified Coordinate object have the same value.
        /// </summary>
        /// <param name="coordinate">The Coordinate object to compare to this instance.</param>
        /// <returns>True if object is Coordinate and the value X and Y of is the same as the value of this instance;
        /// otherwise, false. If value is null, the method returns false.</returns>
        public override bool Equals(object coordinate)
        {
            if (coordinate == null || GetType() != coordinate.GetType())
            {
                return false;
            }

            var coordinateToEqual = coordinate as Coordinate;

            return (X == coordinateToEqual.X) && (Y == coordinateToEqual.Y);
        }

        /// <summary>
        /// Returns the hash code for this coordinate instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
