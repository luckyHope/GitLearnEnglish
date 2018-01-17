using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;
using System.Data.SQLite.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using SQLite;


namespace LearnEnglish.Models
{
    [SQLite.Table ("Words")]
    public class Word : INotifyPropertyChanged
    {
        
        private int wordId;
        [PrimaryKey, AutoIncrement, Unique]
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
        [NotNull]
        public string EnglishWord
        {
            get { return englishWord; }
            set
            {
                if (value == englishWord) return;
                englishWord = value;
                OnPropertyChanged(nameof(EnglishWord));
            }
        }

        private string russianWord;
        [NotNull]
        public string RussianWord
        {
            get { return russianWord; }
            set
            {
                if (value == russianWord) return;
                russianWord = value;
                OnPropertyChanged(nameof(RussianWord));
            }
        }

        private string contextForWord;
        [NotNull]
        public string ContextForWord
        {
            get { return contextForWord; }
            set
            {
                if (value == contextForWord) return;
                contextForWord = value;
                OnPropertyChanged(nameof(ContextForWord));
            }
        }

        public Word(string englishWord, string russianWord, string context)
        {
            this.englishWord = englishWord;
            this.russianWord = russianWord;
            this.contextForWord = context;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
