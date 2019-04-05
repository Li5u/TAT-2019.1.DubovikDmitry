namespace ChainOfResponsibility
{
    abstract class Builder
    {
        internal double epsilon = 0.001;
        public Builder Successor { get; set; }

        public Builder(Builder successor)
        {
            Successor = successor;
        }

        virtual public Triangle BuildTriangle(Point a, Point b, Point c)
        {
            return new Triangle();
        }
    }
}
