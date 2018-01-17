using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
//using System.Data.SQLite;
using System.Data.Entity;
using System.IO;
using System.Windows;
using LearnEnglish.Models;
using LearnEnglish.Views;
using SQLite;

namespace LearnEnglish.ViewModels
{
    class WordsViewModel :INotifyPropertyChanged
    {
        private string dbFileName = "BaseName.db";
        private SQLiteConnection conn;
        //ApplicationContext ac;

        IEnumerable<Word> words;

        public IEnumerable<Word> Words
        {
            get { return words; }
            set
            {
                words = value;
                OnPropertyChanged(nameof(Words));
            }
        }

        RelayCommand openVocabularyCommand;
        RelayCommand addWordCommand;
        RelayCommand saveAddWordCommand;

        //public WordsViewModel()
        //{
        //    ac = new ApplicationContext();
        //    ac.Words.Load();
        //    Words = ac.Words.Local.ToBindingList();
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand OpenVocabularyCommand
        {
            get
            {
                return openVocabularyCommand ?? (openVocabularyCommand = new RelayCommand((o) =>
                       {
                           using (SQLiteConnection conn = new SQLiteConnection(dbFileName))
                           {
                               Vocabulary vc = new Vocabulary();
                               vc.ShowDialog();
                           }
                       }));
            }
        }

        public RelayCommand AddWordCommand
        {
            get
            {
                return addWordCommand ?? (addWordCommand = new RelayCommand((o) =>
                {
                    using (conn = new SQLiteConnection(dbFileName))
                    {
                        AddWord aw = new AddWord();
                        aw.ShowDialog();
                    }
                }));
            }
        }

        public RelayCommand SaveAddWordCommand
        {
            get
            {
                return saveAddWordCommand ?? (saveAddWordCommand = new RelayCommand((o) =>
                {
                    using (conn = new SQLiteConnection(dbFileName))
                    {
                        conn.CreateTable<Word>();
                        Word wd = new Word();
                        conn.Insert(wd);
                    }
                    

                }));
            }
        }
    }
}
