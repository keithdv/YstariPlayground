using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Ystari
{
    public interface IEditableList<T> : IDomainObject, IEnumerable<T>
        where T : IEditableObject
    { }

    //public class EditableList<T> : ObservableCollection<T>, IEditableList<T>
    //    where T : IEditableObject
    //{
    //    int IDomainObject.GraphId { get; set; }
    //}
}
