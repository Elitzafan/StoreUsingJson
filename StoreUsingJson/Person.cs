using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace StoreUsingJson
{
    /// <summary>
    /// Represents a <see cref="Person"/> instance which has a different properties.
    /// </summary>
    public class Person
    {
        private readonly Random _random = new Random();
        public Person()
        {
            Name = "Avraham";
            Id = 0;
            Age = 175;
            Point = new Point { X = 15.25, Y = 88.77 };
            MyIntArr = GetIntArray();
            PathToImage = "MY_PATH_TO_IMAGE";
            Lives = 1000;
        }

        private int[] GetIntArray()
        {
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = _random.Next(50);
            return arr;
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public int[] MyIntArr { get; set; }
        public Point Point { get; set; }
        public int Lives { get; set; }
        public string PathToImage { get; set; }
        public string EllipseStroke { get; set; }

        // Trying to serialize .NET reference types without a type converter,
        // will get you an error. Like on 'Ellipse' property if not ignored.
        // But you CAN serialize your custom reference types.
        // Like 'Person'.
        [JsonIgnore]
        public Ellipse Ellipse { get; set; }

        // A collection of primitive\custom reference types CAN be serialized.
        public Dictionary<string, string> Details { get; set; }

        //public override string ToString() =>
        //    $"Name: {Name}\n" +
        //    $"Id: {Id}\n" +
        //    $"Age: {Age}\n" +
        //    $"Point: {Point}\n" +
        //    $"Ellipse: {Ellipse.Name}\t{Colors.AliceBlue}\n" +
        //    $"Dictionary: {PrintMyCollection(Details)}\n" +
        //    $"MyArr: {PrintMyCollection(MyIntArr)}";

        public string PrintMyCollection<T>(IEnumerable<T> collection)
        {
            string output = "";
            foreach (var num in collection)
                output += $"{num}\t";
            return output;
        }
    }
}