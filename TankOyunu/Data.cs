using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TankOyunu
{
    public class Data : INotifyPropertyChanged
    {
        private int fX;
        private int fY;

        public int X
        {
            get
            {
                return fX;
            }
            set
            {
                fX = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("X"));
            }
        }
        public int Y
        {
            get { return fY; }
            set
            {
                fY = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Y"));
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
