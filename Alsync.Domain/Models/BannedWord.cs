using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    public class BannedWord : AggregateRoot
    {
        public string Words { get; set; }
    }
}
