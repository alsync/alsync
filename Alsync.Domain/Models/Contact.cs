using System;
using System.Collections.Generic;
using System.Text;

namespace Alsync.Domain.Models
{
    public class Contact : Entity
    {
        public Contact() { }

        public string Label { get; protected set; }

        public string Phone { get; protected set; }

        public DateTime CreateDate { get; protected set; }

        public Guid ProfileID { get; protected set; }

        public virtual UserProfile Profile { get; protected set; }
    }
}
