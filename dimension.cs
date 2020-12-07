using System;
using System.Collections.Generic;
using System.Text;

namespace Day_4_Exercies
{
    class Dimension
    {
        public int radius { get; set; }
        public int height { get; set; }
        public virtual double SurfaceArea()
        {
            return 0;
        }
        public virtual string Display()
        {
            return $"The Area of {this.GetType()} is {SurfaceArea()}.";
        }
    }
    class Circle : Dimension
    {

        public Circle(int radius)
        {
            this.radius = radius;
        }
        public override double SurfaceArea()
        {
            return Math.PI * this.radius * this.radius;
        }
    }
    class Cylinder : Dimension
    {

        public Cylinder(int radius, int height)
        {
            this.radius = radius;
            this.height = height;
        }
        public override double SurfaceArea()
        {
            return 2*Math.PI * this.radius *( this.radius + this.height);
        }
    }
    class Sphere : Dimension
    {

        public Sphere(int radius)
        {
            this.radius = radius;
        }
        public override double SurfaceArea()
        {
            return 4*Math.PI * this.radius * this.radius;
        }
    }
    class ShapesDriver
    {
        public static void Main()
        {
            Dimension d1 = new Dimension();
            Console.WriteLine(d1.Display());
            Dimension d2 = new Circle(5);
            Console.WriteLine(d2.Display());
            Dimension d3 = new Cylinder(5, 20);
            Console.WriteLine(d3.Display());
            Dimension d4 = new Sphere(5);
            Console.WriteLine(d4.Display());

        }
    }
}
