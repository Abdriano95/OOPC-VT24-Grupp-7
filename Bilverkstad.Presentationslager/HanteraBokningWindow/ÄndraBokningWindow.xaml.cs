using System;
using System.Collections.ObjectModel;
using System.Windows;
using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret; // Assuming your entities are defined here

namespace Bilverkstad.Presentationslager.HanteraBokningWindow
{
    public partial class ÄndraBokningWindow : Window
    {
        private KundController kundController = new KundController();
        private FordonController fordonController = new FordonController();
        private ReceptionistController receptionistController = new ReceptionistController();
        private BokningsController bokningsController = new BokningsController();

        private Bokning _bokning; // Stores the retrieved booking object
        private ObservableCollection<Reparation> _tillgängligaReparationer; // List of available repairs
        private ObservableCollection<Reparation> _valdaReparationer; // List of selected repairs

        public ÄndraBokningWindow()
        {
            InitializeComponent();
            _tillgängligaReparationer = new ObservableCollection<Reparation>(); // Initialize available repairs list
            _valdaReparationer = new ObservableCollection<Reparation>(); // Initialize selected repairs list
            // Populate the available repairs list with data from your data access layer
            // ...

            // Bind data context to the window for easier access in controls
            DataContext = this;
        }
          
        private void HämtaBokningButton_Click(object sender, RoutedEventArgs e)
        {
    
        }

        // Implement event handlers for modifying UI elements and managing selected repairs
        // ... (e.g., handling changes in TextBoxes, Calendars, ComboBox, adding/removing items from ListBoxes)

        private void ÄndraBokningButton_Click(object sender, RoutedEventArgs e)
        {


            MessageBox.Show("Bokningen uppdaterades!");
        }

        private void TaBortBokningButton_Click(object sender, RoutedEventArgs e)
        {


            MessageBox.Show("Bokningen togs bort!");
        }
    }
}
