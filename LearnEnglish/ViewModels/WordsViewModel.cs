using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Data.SQLite;
using System.Data.Entity;
using System.IO;
using System.Windows;
using LearnEnglish.Views;

namespace LearnEnglish.ViewModels
{
    class WordsViewModel :INotifyPropertyChanged
    {
        //private ApplicationContext db;
        RelayCommand startToWorkCommand;
        RelayCommand openVocabularyCommand;
        private string dbFileName = "BaseName.db";
        

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        public RelayCommand StartToWorkCommand
        {
            get
            {
                return startToWorkCommand ??
                       (startToWorkCommand = new RelayCommand((o) =>
                       {
                           if (!File.Exists(dbFileName))
                               SQLiteConnection.CreateFile(dbFileName);
                           using (SQLiteConnection conn = new SQLiteConnection(dbFileName))
                               {
                               
                               }

                       }));
            }
        }

        public RelayCommand OpenVocabularyCommand
        {
            get
            {
                return openVocabularyCommand ??
                       (openVocabularyCommand = new RelayCommand((o) =>
                       {
                           using (SQLiteConnection conn = new SQLiteConnection(dbFileName))
                           {
                               Vocabulary vc = new Vocabulary();
                               vc.ShowDialog();
                               
                           }

                       }));
            }
        }



    }
    
}
