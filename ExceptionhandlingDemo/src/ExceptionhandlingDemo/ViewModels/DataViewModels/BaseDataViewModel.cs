
using System;

namespace ExceptionhandlingDemo.ViewModels.DataViewModels
{
    public class BaseDataViewModel
    {
        public Guid ObjectId { get; set; }

        public DateTime TimestampUtc { get; set; }
    }
}