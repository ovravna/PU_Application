using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PU_Application.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public string Username
        {
            get => Settings.Username;
            set
            {
                if (string.Equals(Settings.Username, value, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                Settings.Username = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}