using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Domain.Common
{
    public class ChordFilter
    {
        public string? NameContains { get; set; }
        public string? Tone { get; set; }
        public int? TypeId { get; set; }
        public int? InstrumentId { get; set; }
        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public int? CreatedBy { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsDeleted { get; set; }

        // Extend with more properties if needed
    }

}
