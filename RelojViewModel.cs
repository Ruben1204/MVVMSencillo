using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSencillo
{
    public class RelojViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private DateTime _dateTime;

        private Timer _timer;

        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                OnPropertyChanged();
                
            }
        }

        public RelojViewModel()
        {
            this.DateTime = DateTime.Now;

            _timer = new Timer(new TimerCallback((s) => this.DateTime = DateTime.Now),
                null,TimeSpan.Zero,TimeSpan.FromSeconds(1));
        }

        ~RelojViewModel() => _timer.Dispose();

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
