//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLPERSONEL
    {
        public byte ID { get; set; }
        [Required(ErrorMessage = "Personel Alan�n� Bo� B�rakmay�n�z.")]
        public string PERSONAL { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string MAIL { get; set; }
        [Required(ErrorMessage = "��fre Alan�n� Bo� B�rakmay�n�z.")]
        public string SIFRE { get; set; }
    }
}
