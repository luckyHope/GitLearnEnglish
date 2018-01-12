using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Word : INotifyPropertyChanged
    {
        private int wordId;
        public int WordId
        {
            get { return wordId; }
            set
            {
                if (value == wordId) return;
                WordId = value;
                OnPropertyChanged(nameof(WordId));
            }
        }

        private string englishWord;
        public string EnglishWord
        {
            get { return englishWord; }
            set
            {
                if (value == englishWord) return;
                EnglishWord = value;
                OnPropertyChanged(nameof(EnglishWord));
            }
        }

        private string russianWord;
        public string RussianWord
        {
            get { return russianWord; }
            set
            {
                if (value == russianWord) return;
                RussianWord = value;
                OnPropertyChanged(nameof(RussianWord));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public Word(string englishWord, string russianWord)
        //{
        //    this.EnglishWord = englishWord;
        //    this.RussianWord = russianWord;
        //}

    }
}
