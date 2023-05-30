using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class Employee : INotifyPropertyChanged
    {

        public string Name { get; set; } = "";

        private PaymentType paymentType;
        public PaymentType PaymentType
        {
            get => paymentType;
            set
            {
                paymentType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PaymentType))); 
            }
        }

        public double Payment { get; set; }  // зарплата или почасовая ставка или стоимость проекта

        public float Hours { get; set; }   // только для почасовых сотрудников


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
