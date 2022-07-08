using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace StoreUsingJson
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            StorageTest();
        }
        public async void StorageTest()
        {
            //IStorage<Person> storagePerson;
            // Declares 
            Storage<Person> storagePerson;
            Person person;
            string fileNamePerson;

            storagePerson = new Storage<Person>();
            person = new Person();

            // person.txt
            fileNamePerson = "person";
            person.Ellipse = new Ellipse
            {
                Name = "Yaakov",
                Stroke = new SolidColorBrush(Colors.AliceBlue)
            };
            person.Details = new Dictionary<string, string>
            {
                { "EllipseName", person.Ellipse.Name },
                // #FFF0F8FF
                // You can set it again to 'Ellipse' when loading
                { "EllipseStroke", Colors.AliceBlue.ToString() }
            };
            person.EllipseStroke = person.Details["EllipseStroke"];
            storagePerson.Save(person, fileNamePerson);
            Person avraham = await storagePerson.Load(fileNamePerson);

            // See Output window. Writes only when debugging
            Debug.WriteLine(avraham.PrintMyCollection(avraham.MyIntArr));
            Debug.WriteLine(avraham.PrintMyCollection(avraham.Details));
            Debug.WriteLine(avraham.EllipseStroke);
            //avraham.Ellipse 

            // Ellipse does get serialized so will have its default values.
            Debug.WriteLine(avraham.Ellipse);
            // Set values to 'Ellipse' using extension method
            //avraham.Ellipse.Stroke = avraham.EllipseStroke.ConvertColorFromHexString();
            // Set values to 'Ellipse' using a regular method
            avraham.Ellipse = new Ellipse();
            avraham.Ellipse.Stroke = HexStringToColorConverter.ConvertColorFromHexString(avraham.EllipseStroke);
            Debug.Assert(
                avraham.Ellipse.Stroke.ToString() == 
                person.Ellipse.Stroke.ToString(),
                "This message is printed when the condition is False"
                );
        }
    }
}
