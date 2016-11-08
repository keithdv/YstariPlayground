using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Ystari.ObjectState;

namespace Ystari
{
    public interface IEditableObject : IDomainObject, INotifyPropertyChanged, INotifyPropertyChanging, INotifyDataErrorInfo
    { }

    public class EditableObject : IEditableObject
    {
        int IDomainObject.GraphId { get; set; }

        public bool HasErrors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected IObjectState ObjectState { get; private set; }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
