using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOSU2_Laboration3.PresentationLayer.ViewModels
{
    // A base class for view model objects that provides property change notification functionality
    public class ObservableObject : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // [CallerMemberName] attribute automatically fills in the property name if not provided explicitly.
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to update a property value and raise PropertyChanged event if the value has changed.
        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return false; // If the value hasn't changed, return false to indicate no change
            backingField = value;  // Update the backing field with the new value.
            OnPropertyChanged(propertyName); 
            return true; // Return true to indicate that the property has changed.
        }
    }
}
