namespace StoreUsingJson
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public int[] MyArr { get; set; }
        public override string ToString() =>
            $"Name: {Name}\n" +
            $"Id: {Id}\n" +
            $"Age: {Age}\n" +
            $"MyArr: {PrintMyArr()}";
        private object PrintMyArr()
        {
            string output = "";
            foreach (var num in MyArr)
                output += $"{num}\t";
            return output;            
        }
    }
}