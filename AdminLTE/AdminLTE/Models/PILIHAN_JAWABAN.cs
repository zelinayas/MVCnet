//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminLTE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PILIHAN_JAWABAN
    {
        public int ID_PILIHANJAWABAN { get; set; }
        public Nullable<int> ID_SOAL { get; set; }
        public string PILIHAN_JAWABAN1 { get; set; }
        public bool KUNCI_JAWABAN { get; set; }
        public string Created_by { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
        public string Modified_by { get; set; }
        public string PILIHAN { get; set; }
    
        public virtual SOAL SOAL { get; set; }
    }
}
