using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace ADO.NetEntityFramewrokAUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (CarsContext db = new())
            {

                Cars newCar = new()
                {
                    Make = Make.Text,
                    Model = Model.Text,
                    Year = Year.Text,
                    StNumber = StNumber.Text
                };
                db.Carss.Add(newCar);
                db.SaveChanges();
                Update.IsEnabled = true;
                Delete.IsEnabled = true;
                showCarss(db.Carss.ToList());
            }
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Cars cars = null;

            using (var db = new CarsContext())
            {
                cars = db.Carss.FirstOrDefault(s => s.StNumber==StNumber.Text)!;
                if (cars is not null)
                {
                    cars.Make = Make.Text;
                    cars.Model = Model.Text;
                    cars.Year= Year.Text;
                    cars.StNumber= StNumber.Text;
                    db.Carss.Update(cars);
                    db.SaveChanges();
                }
                showCarss(db.Carss.ToList());
            }

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CarsContext())
            {
                var car = db.Carss.FirstOrDefault(s => s.StNumber == StNumber.Text);
                db.Remove(car);
                db.SaveChanges();
                showCarss(db.Carss.ToList());
            }
        }



        void showCarss(List<Cars> Carss)
        {
            ListViewCars.Items.Clear();
            Carss.ForEach(s => ListViewCars.Items.Add(s.ToString()));
        }

    }
}
