using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace exam //github: https://github.com/Oleksandr274/oop-exam-jan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Event> events = new List<Event>();


        private List<Ticket> CreateTickets()
        {
            List<Ticket> allTickets = new List<Ticket>();

            Ticket ticket1 = new Ticket()
            {
                Name = "Early Bird",
                Price = 100m,
                AvailableTickets = 100
            };

            Ticket ticket2 = new Ticket()
            {
                Name = "Platinium",
                Price = 150m,
                AvailableTickets = 100
            };

            VIPTicket VIPticket1 = new VIPTicket()
            {
                Name = "Ticket and Hotel Package",
                Price = 150m,
                AdditionalCost = 100m,
                AdditionalExtras = "4* hotel",
                AvailableTickets = 100
            };

            VIPTicket VIPticket2 = new VIPTicket()
            {
                Name = "Weekend Ticket",
                Price = 200m,
                AdditionalCost = 100m,
                AdditionalExtras = "with camping",
                AvailableTickets = 100
            };

            allTickets.Add(ticket1);
            allTickets.Add(ticket2);
            allTickets.Add(VIPticket1);
            allTickets.Add(VIPticket2);

            return allTickets;
        }

        private List<Event> CreateEvents()
        { 
            List<Event> events = new List<Event>();
            Event event1 = new Event()
            {
                Name = "Oasis Croke Park",
                EventDate = new DateTime(2025, 06, 20),
                TypeOfEvent = EventType.Music
            };

            Event event2 = new Event()
            {
                Name = "Electric Picnic",
                EventDate = new DateTime(2025, 08, 20),
                TypeOfEvent = EventType.Music,
            };
            


            //assign tickets to each event
            List<Ticket> tickets = CreateTickets();
            event1.Tickets.Add(tickets[0]);
            event1.Tickets.Add(tickets[1]);
            event1.Tickets.Add(tickets[2]);

            event2.Tickets.Add(tickets[1]);
            event2.Tickets.Add(tickets[3]);

            events.Add(event1);
            events.Add(event2);
            return events;

    }

    private List<Event> FilterEvents(string searchTerm)
    {
        List<Event> filteredList = new List<Event>();

        foreach (Event ev in events)
        {
            if (ev.Name.ToLower().Contains(searchTerm.ToLower()))
                filteredList.Add(ev);
        }

        return filteredList;
    }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create events
            events = CreateEvents();

            //diplay event in the left list box
            lsbxEvents.ItemsSource = events;

        }


        private void lsbxEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Event selectedEvent = lsbxEvents.SelectedItem as Event;
            if (selectedEvent != null)
            {
                lsbxTickets.ItemsSource = null;
                lsbxTickets.ItemsSource = selectedEvent.Tickets;
            }
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            Ticket selectedTicket = lsbxTickets.SelectedItem as Ticket;
            if (selectedTicket != null)
            {
                if (int.TryParse(txbxNumOfTickets.Text, out int amount))
                {
                    int numOfTickets = int.Parse(txbxNumOfTickets.Text);
                    if(numOfTickets <= selectedTicket.AvailableTickets)
                    {
                        selectedTicket.AvailableTickets -= numOfTickets;
                        Event selectedEventForTicket = lsbxEvents.SelectedItem as Event;


                        MessageBox.Show($"You have succesfuly bought {numOfTickets} tickets '{selectedTicket.Name}'" +
                            $" for event '{selectedEventForTicket.Name}'");

                        lsbxTickets.ItemsSource = null;
                        txbxNumOfTickets.Text = "";
                    }
                    else
                    {
                        MessageBox.Show($"Unfortunately," +
                            $" we don't have reqired amount of tikects '{selectedTicket.Name}' for you");
                    }
                }
                else
                {
                    MessageBox.Show("Not a valid amount");
                    return;
                }
            }
        }

        private void txbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txbxSearch.Text != "")
            {
                List<Event> filteredEvents = FilterEvents(txbxSearch.Text);
                if(filteredEvents.Count > 0)
                {
                    lsbxEvents.ItemsSource = null;
                    lsbxEvents.ItemsSource = filteredEvents;
                }

            }
            else
            {
                lsbxEvents.ItemsSource = null;
                lsbxEvents.ItemsSource = events;
            }

        }


    }
}