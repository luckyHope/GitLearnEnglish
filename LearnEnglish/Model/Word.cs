using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.Model
{
    [Table("Words")]
    public class Word
    {
        [Key]
        public int WordId { get; set; }
        [Required]
        [Column("EnglishWord")]
        public string EnglishWord { get; set; }
        [Required]
        [Column("RussianWord")]
        public string RussianWord { get; set; }

        public Word(string englishWord, string russianWord)
        {
            this.EnglishWord = englishWord;
            this.RussianWord = russianWord;
        }

    }
}
