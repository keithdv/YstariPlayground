using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Ystari
{
    public interface IBindableObject : IDomainObject, INotifyPropertyChanged, INotifyPropertyChanging
    { }

    public class BindableObject : DomainObject, IBindableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
    }
}
