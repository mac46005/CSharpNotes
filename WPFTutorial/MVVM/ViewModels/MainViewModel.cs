using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTutorial.Core;
using WPFTutorial.MVVM.Models;

namespace WPFTutorial.MVVM.ViewModels
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* Commands */
        public RelayCommand SendCommand { get; set; }


        private ContactModel contactModel;

        public ContactModel SelectedContact
        {
            get { return contactModel; }
            set 
            {
                contactModel = value;
                OnPropertyChanged();
            }
        }


        private string _message;
            
        public string Message
        {
            get { return _message; }
            set 
            { 
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();


            SendCommand = new RelayCommand(o => {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });
            });




            Messages.Add(new MessageModel
            {
                Username = "Marco",
                UsernameColor = "#409aff",
                ImageSource = "",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });



            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Marco",
                    UsernameColor = "#409aff",
                    ImageSource = "",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }
            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Danielle",
                    UsernameColor = "#409aff",
                    ImageSource = "",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Danielle",
                UsernameColor = "#409aff",
                ImageSource = "",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true,
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    UserName = $"Danielle {i}",
                    ImageSource = "",
                    Messages = Messages
                });
            }


        }
    }
}
