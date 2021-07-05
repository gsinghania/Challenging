using Challenging.Model;
using Challenging.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Challenging.ViewModel
{
    public class MainViewModel :INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Event to which the view's controls will subscribe.
        /// This will enable them to refresh themselves when the binded property changes provided you fire this event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// When property is changed call this method to fire the PropertyChanged Event
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            //Fire the PropertyChanged event in case somebody subscribed to it
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Private Variables

        private readonly ICommand _subjectChangeCommand;
        private readonly Model.MainModel model; 
        #endregion

        public MainViewModel()
        {
            model = new MainModel();
            SelectedSubject = "Subject1";
            selectedPage = new Uri("pack://application:,,,/View/Subject1.xaml", UriKind.Absolute);
            _subjectChangeCommand = new RelayCommandWithParameter<object>((x) => ChangePage(x));
        }

        private void ChangePage(object pageName)
        {
            SelectedSubject = (string)pageName;
            switch (pageName)
            {
                case "Subject1":
                    selectedPage = null;
                    selectedPage = new Uri("pack://application:,,,/View/Subject1.xaml", UriKind.Absolute); 
                    break;
                case "Subject2":
                    selectedPage = null;
                    selectedPage = new Uri("pack://application:,,,/View/Subject2.xaml", UriKind.Absolute);
                    break;
                case "Subject3":
                    selectedPage = null;
                    selectedPage = new Uri("pack://application:,,,/View/Subject3.xaml", UriKind.Absolute);
                    break;
                case "Subject4":
                    selectedPage = null;
                    selectedPage = new Uri("pack://application:,,,/View/Subject3.xaml", UriKind.Absolute);
                    break;
            }
        }

        public string SelectedSubject
        {
            get { return model.SelectedSubject; }
            set
            {
                model.SelectedSubject = value;
                OnPropertyChanged(" ");
            }
        }

        public Uri selectedPage
        {
            get { return model.selectedPage; }
            set
            {
                model.selectedPage = value;
                OnPropertyChanged("selectedPage");
            }
        }

        public ICommand SubjectChangeCommand { get { return _subjectChangeCommand; } }

    }
}
