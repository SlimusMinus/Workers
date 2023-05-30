using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Workers
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {

        public Employee Employee { get; }

        public EmployeeViewModel(Employee employee)
        {
            Employee = employee;
            Employee.PropertyChanged += Employee_PropertyChanged;
            ShowHideHours();
        }

        private void Employee_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Employee.PaymentType)) //  == "PaymentType"
                ShowHideHours();
        }

        private void ShowHideHours()
        {
            if (Employee.PaymentType == PaymentType.Hourly)
                HoursVisibility = Visibility.Visible;
            else
                HoursVisibility = Visibility.Collapsed;
        }

        public PaymentType[] PaymentTypes { get; } = (PaymentType[])Enum.GetValues(typeof(PaymentType));

        private Visibility hoursVisibility;
        public Visibility HoursVisibility
        {
            get => hoursVisibility;
            set
            {
                hoursVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HoursVisibility)));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
