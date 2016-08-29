
using System;

namespace ExceptionhandlingDemo.ViewModels.DataViewModels
{
    public class DataViewModelBase
    {
        public Guid ObjectId { get; set; }

        public DateTime TimestampUtc { get; set; }
    }
}