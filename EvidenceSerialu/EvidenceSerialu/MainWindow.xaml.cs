using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace EvidenceSerialu
{
    public partial class MainWindow : Window
    {
        
        public ObservableCollection<Show> MojeSerialy { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            
            MojeSerialy = new ObservableCollection<Show>
            {
                new Show { Id=1, Nazev="Stranger Things", Autor="Dufferové", RokVydani=2016, Zanr="Sci-Fi", PocetKusu=4, JeDostupna=true },
                new Show { Id=2, Nazev="Squid Game", Autor="Hwang Dong-hyuk", RokVydani=2021, Zanr="Thriller", PocetKusu=1, JeDostupna=true },
                new Show { Id=3, Nazev="The Last of Us", Autor="Craig Mazin", RokVydani=2023, Zanr="Drama", PocetKusu=1, JeDostupna=true },
                new Show { Id=4, Nazev="Wednesday", Autor="Alfred Gough", RokVydani=2022, Zanr="Fantasy", PocetKusu=1, JeDostupna=true }
            };

            
            dgShow.ItemsSource = MojeSerialy;
        }

        private void BtnPridat_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtNazev.Text) || string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("Musíš vyplnit název a autora!");
                return;
            }

            
            try
            {
                Show novy = new Show
                {
                    Nazev = txtNazev.Text,
                    Autor = txtAutor.Text,
                    Zanr = txtZanr.Text,
                    RokVydani = int.Parse(txtRok.Text),
                    PocetKusu = int.Parse(txtKusy.Text),
                    JeDostupna = true
                };

                MojeSerialy.Add(novy);

                
                txtNazev.Clear();
                txtAutor.Clear();
                txtRok.Clear();
                txtZanr.Clear();
                txtKusy.Clear();
            }
            catch
            {
                MessageBox.Show("Chyba: Rok a počet sérií musí být čísla!");
            }
        }

        private void BtnSmazat_Click(object sender, RoutedEventArgs e)
        {
            
            if (dgShow.SelectedItem is Show vybrany)
            {
                var dotaz = MessageBox.Show($"Opravdu chceš smazat {vybrany.Nazev}?", "Potvrzení", MessageBoxButton.YesNo);
                if (dotaz == MessageBoxResult.Yes)
                {
                    MojeSerialy.Remove(vybrany);
                }
            }
            else
            {
                MessageBox.Show("Nejdřív vyber seriál v tabulce!");
            }
        }
    }
}