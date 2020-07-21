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
    }
}
