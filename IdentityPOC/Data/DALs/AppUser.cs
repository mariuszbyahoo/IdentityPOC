using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityPOC.Data.DALs
{
    public class AppUser : IdentityUser<int>
    {
        #region Fields
        private int idWSystemieMagazynowym;
        private string imie = string.Empty;
        private string kod = string.Empty;
        private string kodKreskowy = string.Empty;
        private string nazwisko = string.Empty;
        private string nip = string.Empty;
        private string stanowisko = string.Empty;
        private string wydzial = string.Empty;
        private bool aktywny = true;

        /// <summary>
        /// Okresla czy dany pracownik jest aktywny - dostepny na raportowaniu itp.
        /// </summary>
        public bool Aktywny
        {
            get { return aktywny; }
            set { aktywny = value; }
        }

        #endregion Fields 

        #region Properties (10) 

        public int IdWSystemieMagazynowym
        {
            get { return idWSystemieMagazynowym; }
            set { idWSystemieMagazynowym = value; }
        }

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        [NotMapped]
        public string ImieNazwisko
        {
            get { return Imie + " " + Nazwisko; }
        }

        [NotMapped]
        public string Skrot
        {
            get { return (!String.IsNullOrEmpty(Kod) ? Kod : ImieNazwisko); }
        }

        public string Kod
        {
            get { return kod; }
            set { kod = value; }
        }

        /// <summary>
        /// Używany jako pole UserName dla AspNetCoreIdentity
        /// </summary>
        public string KodKreskowy
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        [NotMapped]
        public string NazwiskoImie
        {
            get { return Nazwisko + " " + Imie; }
        }

        public string Nip
        {
            get { return nip; }
            set { nip = value; }
        }

        public string Stanowisko
        {
            get { return stanowisko; }
            set { stanowisko = value; }
        }

        public string Wydzial
        {
            get { return wydzial; }
            set { wydzial = value; }
        }

        public int CzasPracyDzienny { get; set; }

        public int CzasPracyMiesieczny { get; set; }

        [MaxLength(400)]
        public string Opis { get; set; }
        #endregion
    }
}
