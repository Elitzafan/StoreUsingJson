using System.Diagnostics;
using Windows.UI.Xaml.Controls;

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
            Storage<Person> storagePerson;
            Person person;
            string fileNamePerson;

            storagePerson = new Storage<Person>();
            person = new Person();

            // person.txt
            fileNamePerson = "person";

            // Saves the file in this path:
            // C:\Users\USER_ACCOUNT\AppData\Local\Packages\StoreUsingJson_yy5qmf57p1xxr\LocalState
            storagePerson.Save(person, fileNamePerson);
            Person avraham = await storagePerson.Load(fileNamePerson);

            // See Output window. Writes only when debugging
            Debug.WriteLine(avraham.PrintMyCollection(avraham.MyIntArr));
            Debug.WriteLine(avraham.PrintMyCollection(avraham.Details));
            Debug.WriteLine(avraham.EllipseStroke);

            // Ellipse does get serialized so will have its default values.
            Debug.WriteLine(avraham.Ellipse);
        }
    }
}
