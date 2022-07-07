using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StoreUsingJson
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            StorageTest();

        }
        public async void StorageTest()
        {
            Random random = new Random();
            //IStorage<Person> storagePerson;
            Storage<Person> storagePerson;
            Person person;
            string fileNamePerson;

            storagePerson = new Storage<Person>();
            person = new Person { Id = 1, Name = "Avraham", Age = 175 };
            person.MyArr = new int[10];
            for (int i = 0; i < person.MyArr.Length; i++)
                person.MyArr[i] = random.Next(50);

            fileNamePerson = "person_test";
            storagePerson.Save(person, fileNamePerson);
            Person avraham = await storagePerson.Load(fileNamePerson);
            Debug.WriteLine(avraham);
        }
    }
}
